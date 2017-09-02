namespace ReminderApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tasksDBDataSet1 = new ReminderApp.TasksDBDataSet();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.taskTextBox = new System.Windows.Forms.TextBox();
            this.addNewTaskBtn = new System.Windows.Forms.Button();
            this.viewTasksBtn = new System.Windows.Forms.Button();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.descTextBox = new System.Windows.Forms.RichTextBox();
            this.registerPhoneBtn = new System.Windows.Forms.Button();
            this.statusLbl = new System.Windows.Forms.Label();
            this.infoButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tasksDBDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // tasksDBDataSet1
            // 
            this.tasksDBDataSet1.DataSetName = "TasksDBDataSet";
            this.tasksDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(195, 72);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(263, 24);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(195, 39);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(263, 24);
            this.nameTextBox.TabIndex = 6;
            // 
            // taskTextBox
            // 
            this.taskTextBox.Location = new System.Drawing.Point(195, 102);
            this.taskTextBox.Name = "taskTextBox";
            this.taskTextBox.Size = new System.Drawing.Size(263, 24);
            this.taskTextBox.TabIndex = 7;
            // 
            // addNewTaskBtn
            // 
            this.addNewTaskBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.addNewTaskBtn.ForeColor = System.Drawing.Color.Black;
            this.addNewTaskBtn.Location = new System.Drawing.Point(14, 290);
            this.addNewTaskBtn.Name = "addNewTaskBtn";
            this.addNewTaskBtn.Size = new System.Drawing.Size(166, 34);
            this.addNewTaskBtn.TabIndex = 12;
            this.addNewTaskBtn.Text = "Add Task";
            this.addNewTaskBtn.UseVisualStyleBackColor = false;
            this.addNewTaskBtn.Click += new System.EventHandler(this.AddNewTask_Click);
            // 
            // viewTasksBtn
            // 
            this.viewTasksBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.viewTasksBtn.ForeColor = System.Drawing.Color.Black;
            this.viewTasksBtn.Location = new System.Drawing.Point(186, 290);
            this.viewTasksBtn.Name = "viewTasksBtn";
            this.viewTasksBtn.Size = new System.Drawing.Size(166, 34);
            this.viewTasksBtn.TabIndex = 13;
            this.viewTasksBtn.Text = "View Tasks";
            this.viewTasksBtn.UseVisualStyleBackColor = false;
            this.viewTasksBtn.Click += new System.EventHandler(this.ViewTasks_Click);
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(195, 133);
            this.phoneTextBox.MaxLength = 10;
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(263, 24);
            this.phoneTextBox.TabIndex = 15;
            this.phoneTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phoneNumberFormatting);
            // 
            // descTextBox
            // 
            this.descTextBox.Location = new System.Drawing.Point(195, 163);
            this.descTextBox.Name = "descTextBox";
            this.descTextBox.Size = new System.Drawing.Size(263, 102);
            this.descTextBox.TabIndex = 16;
            this.descTextBox.Text = "";
            // 
            // registerPhoneBtn
            // 
            this.registerPhoneBtn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.registerPhoneBtn.ForeColor = System.Drawing.Color.Black;
            this.registerPhoneBtn.Location = new System.Drawing.Point(359, 290);
            this.registerPhoneBtn.Name = "registerPhoneBtn";
            this.registerPhoneBtn.Size = new System.Drawing.Size(166, 34);
            this.registerPhoneBtn.TabIndex = 18;
            this.registerPhoneBtn.Text = "Register new phone #";
            this.registerPhoneBtn.UseVisualStyleBackColor = false;
            this.registerPhoneBtn.Click += new System.EventHandler(this.registerPhoneBtn_Click);
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Location = new System.Drawing.Point(208, 271);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(0, 17);
            this.statusLbl.TabIndex = 20;
            // 
            // infoButton
            // 
            this.infoButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.infoButton.BackgroundImage = global::ReminderApp.Properties.Resources.info;
            this.infoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.infoButton.ForeColor = System.Drawing.Color.Black;
            this.infoButton.Location = new System.Drawing.Point(77, 208);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(41, 40);
            this.infoButton.TabIndex = 22;
            this.infoButton.UseVisualStyleBackColor = false;
            this.infoButton.Click += new System.EventHandler(this.infoButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Image = ((System.Drawing.Image)(resources.GetObject("statusLabel.Image")));
            this.statusLabel.Location = new System.Drawing.Point(202, 271);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            this.statusLabel.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Calibri", 10F);
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(60, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter your name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("Calibri", 10F);
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.Location = new System.Drawing.Point(35, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Enter task description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Calibri", 10F);
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(50, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Enter your phone #:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Calibri", 10F);
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.Location = new System.Drawing.Point(52, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Due date and time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Calibri", 10F);
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(29, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter name of the task:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 355);
            this.Controls.Add(this.infoButton);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.registerPhoneBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.descTextBox);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.viewTasksBtn);
            this.Controls.Add(this.addNewTaskBtn);
            this.Controls.Add(this.taskTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Calibri", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Task Reminder";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tasksDBDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TasksDBDataSet tasksDBDataSet1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox taskTextBox;
        private System.Windows.Forms.Button addNewTaskBtn;
        private System.Windows.Forms.Button viewTasksBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.RichTextBox descTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button registerPhoneBtn;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.Button infoButton;


    }
}

