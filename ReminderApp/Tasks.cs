using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
namespace ReminderApp
{
    /*This class contains the  SQL query functionality used to build and store Tasks in Database*/
    class Tasks
    {
        public static string _connStr = ConfigurationManager.ConnectionStrings["TaskAppConnString"].ConnectionString;
        private List<Tasks> _taskList=new List<Tasks>();
        public Tasks() 
        {
        }
        public Tasks(string name, string taskName, DateTime dueDate,string phoneNumber,string taskDesc)
        {
            this._name = name;
            this._taskName = taskName;
            this._dueDate = dueDate;
            this._phoneNumber = phoneNumber;
            this._taskDesc = taskDesc;
        }
        private string _name, _taskName, _phoneNumber, _taskDesc;

        public string TaskDesc
        {
            get { return _taskDesc; }
            set { _taskDesc = value; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        public string TaskName
        {
            get { return _taskName; }
            set { _taskName = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private DateTime _dueDate;

        public DateTime DueDate
        {
            get { return _dueDate; }
            set { _dueDate = value; }
        }

        public void AddNewTask(Tasks t1)
        {
            this._taskList.Add(t1);
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                string cmdText = "INSERT Tasks(Name,TaskName,DueDate,PhoneNumber,TaskDescription) VALUES (@name,@taskName,@dueDate,@phoneNumber,@taskDesc)";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@name", t1.Name);
                    command.Parameters.AddWithValue("@taskName", t1.TaskName);
                    command.Parameters.AddWithValue("@dueDate", t1.DueDate);
                    command.Parameters.AddWithValue("@phoneNumber", t1.PhoneNumber);
                    command.Parameters.AddWithValue("@taskDesc", t1.TaskDesc);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteSelectedTask(String taskName)
        {

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                string cmdText = "DELETE FROM Tasks where TaskName= @taskName";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@taskName", taskName);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void EmptyTable()
        {

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                string cmdText = "TRUNCATE TABLE TASKS";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        } 
    }
}
