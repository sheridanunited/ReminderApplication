using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Data.SqlClient;

namespace ReminderApp
{
    /*
     * This class is used to display data from Tasks table 
     * The user is allowed to select and remove data
     * The user can also empty the table using the functionality provided
     */
    public partial class TaskHistoryForm : Form
    {
        private static string connectionString = Tasks._connStr;
        string sql = "DELETE FROM Tasks WHERE RowID = @RowID";
        private SqlConnection sqlConnection;
        private SqlDataAdapter sqlDataAdapter ;
        TasksDBDataSet tds;
        Tasks _task=new Tasks();
        List<string> timeList = new List<string>();
        public TaskHistoryForm()
        {
           
            InitializeComponent();
            GetTimeLeft();
            sqlConnection = new SqlConnection(connectionString);
            sqlDataAdapter = new SqlDataAdapter(sql,sqlConnection);
            sqlConnection.Open();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
            dataGridView1.Columns[3].DefaultCellStyle.Format = "ddddd,MMMM dd, yyyy hh:mm:ss tt";
            // This line of code loads data into the 'tasksDBDataSet.Tasks' table.
            this.tasksTableAdapter.Fill(this.tasksDBDataSet.Tasks);
            GetTimeLeft();
        }
        /*
         * This method calculates the time left for a task to be completed everytime the form is loaded
         * It is used to populate the second DataGridView element which contains unbound data
         */
        private void GetTimeLeft()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                TimeSpan timeLeft = Convert.ToDateTime(tasksDBDataSet.Tables[0].Rows[i][3]) - DateTime.Now;
                if (timeLeft.TotalMilliseconds <= 0)
                {
                    string time = String.Format("{0} {1} late", timeLeft.Hours, timeLeft.Hours == 1 ? "hour" : "hours").Replace('-', ' ');
                    timeList.Add(time);
                }
                else
                {
                    string time = String.Format("{0} {1} {2} {3} {4} {5} ",timeLeft.Days, timeLeft.Days  ==1 ? "day" : "days",
                      timeLeft.Hours, timeLeft.Hours == 1 ? "hour" : "hours", timeLeft.Minutes, timeLeft.Minutes == 1 ? "minute" : "minutes");
                    timeList.Add(time);
                }
            }
            foreach (string s in timeList)
            {
                dataGridView2.Rows.Add(s);
            }


        }
        /*
         * This method is used to format the layout of tasks that are overdue
         */
        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView2.Columns[e.ColumnIndex].Name == "TimeRemaining")
            {
                if (e.Value != null && e.Value.ToString().Contains("late"))
                {
                    dataGridView2.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }
        /*
         * This method invokes simultaneous scrolling of both DataGridView elements
         */
        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                PropertyInfo verticalOffset = dataGridView2.GetType().GetProperty("VerticalOffset", BindingFlags.NonPublic | BindingFlags.Instance);
                verticalOffset.SetValue(this.dataGridView2, dataGridView1.VerticalScrollingOffset, null);
            }
            catch (Exception) 
            {

            }
        }
        /*
         * This method invokes simultaneous scrolling of both DataGridView elements
         */
        private void dataGridView2_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                PropertyInfo verticalOffset = dataGridView1.GetType().GetProperty("VerticalOffset", BindingFlags.NonPublic | BindingFlags.Instance);
                verticalOffset.SetValue(this.dataGridView1, dataGridView2.VerticalScrollingOffset, null);
            }
            catch (Exception) 
            {
            }
        }
        /*
         * Truncates the table and clears the form
         */
        private void ClearTasks_Click(object sender, EventArgs e)
        {
            _task.EmptyTable();
            this.Hide();
            TaskHistoryForm f2 = new TaskHistoryForm();
            f2.ShowDialog();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Int32 rowindex = dataGridView1.CurrentCell.RowIndex;
            if (rowindex >= 0 && rowindex < this.dataGridView2.Rows.Count)
            {
                this.dataGridView2.CurrentCell = this.dataGridView2.Rows[rowindex].Cells[0];
            }
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.tasksTableAdapter.FillBy(this.tasksDBDataSet.Tasks);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.tasksTableAdapter.FillBy(this.tasksDBDataSet.Tasks);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.tasksTableAdapter.FillBy1(this.tasksDBDataSet.Tasks);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
        /*
         * Used to delete a selected task and reload the form 
         */
        private void dltSelectedBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                using (SqlCommand sql = new SqlCommand("delete from tasks where id=@id", sqlConnection))
                {
                    sql.Parameters.AddWithValue("@id", row.Cells[0].Value.ToString());
                    sql.ExecuteNonQuery();
                }
                if (int.Parse(row.Index.ToString()) != 0)
                    dataGridView1.Rows.Remove(row);
                sqlConnection.Close();
                this.Hide();
                TaskHistoryForm f2 = new TaskHistoryForm();
                f2.ShowDialog();
            }
            catch (Exception) 
            {

            }
        }

      




    }
}
