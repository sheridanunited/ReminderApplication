using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio;

namespace ReminderApp
{
    /*
     * This class contains functionality to add a new phone number.
     * The phone number which gets added can be used to receive task reminders
     */
    public partial class PhoneRegistrationForm : Form
    {
        static string accountSid = "";// Enter your account's SID from www.twilio.com/console
        static string authToken = "";// Enter your Authentication Token from www.twilio.com/console
        TwilioRestClient twilio = new TwilioRestClient(accountSid, authToken);
        public PhoneRegistrationForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void AddNumber_Click(object sender, EventArgs e)
        {
            RegisterNumber();
        }
        public void phoneNumberFormatting(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void RegisterNumber() 
        {
            try
            {
                var addNewNumber = twilio.AddOutgoingCallerId(phoneTextBox.Text, phoneTextBox.Text, null, null);
                /*
                 * If number is valid, it gets called and a six digit code is displayed. 
                 * The user is required to enter that code to finish registration
                 */
                if (addNewNumber.RestException == null)
                {
                    MessageBox.Show("Please enter " + addNewNumber.ValidationCode + " in the call you receive from +1 415-723-400");
                }
                else
                {
                    throw new CustomException("Number does not exist");
                    MessageBox.Show(addNewNumber.RestException.Message);
                }
            }
            catch (CustomException) 
            {
                MessageBox.Show("Number is invalid, failed to register");
            }
        }
    }
}
