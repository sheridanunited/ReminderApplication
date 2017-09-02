using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.Xml;
using Rebex.Net;

namespace ReminderApp
{
    public partial class MainForm : Form
    {
        Phone phone = new Phone();
        Tasks t;
        public MainForm()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            this.BackgroundImage = Properties.Resources.back;
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.CustomFormat = "ddddd,MMMM dd, yyyy hh:mm:ss tt";
            statusLabel.ForeColor = Color.Red;
        }
        /*
         * This method adds a new task in queue, a task can be maximum 24 days away
         * A task should not be scheduled before the current date and time
         * The user will get a call and text message 5 minutes before a task is due 
        */
        private void AddNewTask_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "The task "+taskTextBox.Text+" is enqueued...";
            statusLabel.ForeColor = Color.Blue;
            try
            {
                if (phoneTextBox.Text.Length < 10)
                {
                    statusLabel.Text="Phone number must be at least 10 characters long.";
                    statusLabel.ForeColor = Color.Red;
                    return;
                }
                var d = Convert.ToDateTime(dateTimePicker1.Text).Subtract(DateTime.Now);
                if (d.Milliseconds < 0)
                {
                    statusLabel.Text="The due date cannot be before the current date.";
                    statusLabel.ForeColor = Color.Red;
                    return;
                }
                t = new Tasks(nameTextBox.Text, taskTextBox.Text, dateTimePicker1.Value, "+1" + phoneTextBox.Text, descTextBox.Text);
                StartTaskAt(t.DueDate.AddMinutes(-5), t.TaskName + " is due on " + t.DueDate + ". 5 minutes left!", t.PhoneNumber);
                t.AddNewTask(t);
            }
            catch (ArgumentOutOfRangeException)
            {
                statusLabel.Text="The task can only be maximum 24 days away!";
                statusLabel.ForeColor=Color.Red;
            }
            catch (Exception)
            {
                t.DeleteSelectedTask(t.TaskName);
                statusLabel.Text="Please make sure you enter all values";
                statusLabel.ForeColor = Color.Red;
            }
           

        }
        /*
         * This method will open a new form that contains data retrieved from the database
         */
        private void ViewTasks_Click(object sender, EventArgs e)
        {
            TaskHistoryForm f2 = new TaskHistoryForm();
            f2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
        /*
         * This method is called by AddTask_Click method
         * It starts an asynchronous Task scheduled to run at given time
         */
        private void StartTaskAt(DateTime date, string s, string p)
        {

            var dateNow = DateTime.Now;
            TimeSpan ts;
            
            ts = date - dateNow;
            Task t = Task.Delay(ts).ContinueWith((x) =>
            {
                MethodToCall(date, s, p);

            });
        }
        /*
         * This method is called by StartTaskAt method
         * It calls the sendMessage and Call Method from Phone class
         */
        private void MethodToCall(DateTime time, string s, string p)
        {
            this.BeginInvoke((Action)(() =>
            {
                phone.sendMessage(s, p);
                statusLabel.Text = "Message sent!";
                CreateXML("Hi " + t.Name + ", Your task " + t.TaskName + " is due in 5 minutes. The task description is " + t.TaskDesc);
                Sftp();
                int milliseconds = 2000;
                Thread.Sleep(milliseconds);
                statusLabel.Text = "Call started!";
                statusLabel.ForeColor = Color.Blue;
                phone.Call(p);
            }));
        }
        public void phoneNumberFormatting(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        /*
         * This xml file is read by Twilio's text to speech engine
         * It is built everytime the user adds a new task
         * It contains Task details 
         */
        private void CreateXML(string s)
        {
            XmlTextWriter writer = new XmlTextWriter("voice.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("Response");
            CreateNode(s, writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }
        /*
         * Called to build XML elements
         * Alice is the text to speech voice
         * en is English language
         */
        private void CreateNode(string p, XmlTextWriter writer)
        {
            writer.WriteStartElement("Say");
            writer.WriteStartAttribute("voice");
            writer.WriteString("Alice");
            writer.WriteEndAttribute();
            writer.WriteStartAttribute("language");
            writer.WriteString("en");
            writer.WriteEndAttribute();
            writer.WriteString(p);
            writer.WriteEndElement();

        }
        /*
         * This method uploads the file to the web server from where Twilio API can access it for phone calls
         * It uses an external library Rebex which has a very simple implementation for SFTP 
         */
        public void Sftp() 
        {
            Sftp client = new Sftp();
            client.Connect("mobile.sheridanc.on.ca");
            client.Login("username", "password"); // enter your SFTP credentials
            client.PutFile(@"E:\C#\ReminderApp\ReminderApp\bin\Debug\voice.xml", "/home/ahmasaad/public_html/Twilio/voice.xml"); //local and server paths
            statusLabel.Text="Call initiating...." ;
            statusLabel.ForeColor = Color.Blue;
        }
        /*
         * Opens a new form to enable new phone number registration
         */
        private void registerPhoneBtn_Click(object sender, EventArgs e)
        {
            PhoneRegistrationForm f3 = new PhoneRegistrationForm();
            f3.ShowDialog();
        }
        /*
         * General info
         */
        private void infoButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This application reminds the user when a task is due. It has been developed using Twilio API, which"
            + " allows placing calls and sending text messages. " + Environment.NewLine +Environment.NewLine + "By: Saad Ahmad");
        }
    }
}
