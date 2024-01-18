namespace HostelManagementSystem
{
    partial class Login
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
            this.email = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.con_password = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.emailadd = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gender = new System.Windows.Forms.ComboBox();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.l_name = new System.Windows.Forms.TextBox();
            this.first_name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hidepass = new System.Windows.Forms.CheckBox();
            this.hidepass1 = new System.Windows.Forms.CheckBox();
            this.email.SuspendLayout();
            this.SuspendLayout();
            // 
            // email
            // 
            this.email.BackColor = System.Drawing.Color.MidnightBlue;
            this.email.Controls.Add(this.hidepass1);
            this.email.Controls.Add(this.hidepass);
            this.email.Controls.Add(this.linkLabel1);
            this.email.Controls.Add(this.button1);
            this.email.Controls.Add(this.con_password);
            this.email.Controls.Add(this.label8);
            this.email.Controls.Add(this.password);
            this.email.Controls.Add(this.label7);
            this.email.Controls.Add(this.emailadd);
            this.email.Controls.Add(this.label9);
            this.email.Controls.Add(this.address);
            this.email.Controls.Add(this.label6);
            this.email.Controls.Add(this.gender);
            this.email.Controls.Add(this.date);
            this.email.Controls.Add(this.l_name);
            this.email.Controls.Add(this.first_name);
            this.email.Controls.Add(this.label5);
            this.email.Controls.Add(this.label4);
            this.email.Controls.Add(this.label3);
            this.email.Controls.Add(this.label2);
            this.email.Controls.Add(this.label1);
            this.email.Location = new System.Drawing.Point(129, 12);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(593, 577);
            this.email.TabIndex = 0;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.SystemColors.Control;
            this.linkLabel1.Location = new System.Drawing.Point(195, 475);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(73, 20);
            this.linkLabel1.TabIndex = 24;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Sign In";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.ForeColor = System.Drawing.Color.Navy;
            this.button1.Location = new System.Drawing.Point(296, 468);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 39);
            this.button1.TabIndex = 23;
            this.button1.Text = "Sign Up";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // con_password
            // 
            this.con_password.Location = new System.Drawing.Point(361, 364);
            this.con_password.Name = "con_password";
            this.con_password.Size = new System.Drawing.Size(184, 22);
            this.con_password.TabIndex = 21;
            this.con_password.TextChanged += new System.EventHandler(this.con_password_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(357, 341);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(163, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "Confirm Password";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(362, 270);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(184, 22);
            this.password.TabIndex = 19;
            this.password.TextChanged += new System.EventHandler(this.password_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(359, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Password";
            // 
            // emailadd
            // 
            this.emailadd.Location = new System.Drawing.Point(361, 183);
            this.emailadd.Name = "emailadd";
            this.emailadd.Size = new System.Drawing.Size(184, 22);
            this.emailadd.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(358, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "Email";
            // 
            // address
            // 
            this.address.Location = new System.Drawing.Point(363, 95);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(184, 22);
            this.address.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(359, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Address";
            // 
            // gender
            // 
            this.gender.FormattingEnabled = true;
            this.gender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.gender.Location = new System.Drawing.Point(79, 362);
            this.gender.Name = "gender";
            this.gender.Size = new System.Drawing.Size(124, 24);
            this.gender.TabIndex = 9;
            // 
            // date
            // 
            this.date.Location = new System.Drawing.Point(80, 270);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(200, 22);
            this.date.TabIndex = 8;
            // 
            // l_name
            // 
            this.l_name.Location = new System.Drawing.Point(80, 183);
            this.l_name.Name = "l_name";
            this.l_name.Size = new System.Drawing.Size(175, 22);
            this.l_name.TabIndex = 7;
            // 
            // first_name
            // 
            this.first_name.Location = new System.Drawing.Point(80, 97);
            this.first_name.Name = "first_name";
            this.first_name.Size = new System.Drawing.Size(176, 22);
            this.first_name.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(77, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "LastName";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(76, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Birth Day";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(76, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Gender";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(78, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "FirstName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(225, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sign Up";
            // 
            // hidepass
            // 
            this.hidepass.AutoSize = true;
            this.hidepass.ForeColor = System.Drawing.SystemColors.Control;
            this.hidepass.Location = new System.Drawing.Point(361, 298);
            this.hidepass.Name = "hidepass";
            this.hidepass.Size = new System.Drawing.Size(124, 20);
            this.hidepass.TabIndex = 34;
            this.hidepass.Text = "Show password";
            this.hidepass.UseVisualStyleBackColor = true;
            this.hidepass.CheckedChanged += new System.EventHandler(this.hidepass_CheckedChanged);
            // 
            // hidepass1
            // 
            this.hidepass1.AutoSize = true;
            this.hidepass1.ForeColor = System.Drawing.SystemColors.Control;
            this.hidepass1.Location = new System.Drawing.Point(361, 392);
            this.hidepass1.Name = "hidepass1";
            this.hidepass1.Size = new System.Drawing.Size(124, 20);
            this.hidepass1.TabIndex = 35;
            this.hidepass1.Text = "Show password";
            this.hidepass1.UseVisualStyleBackColor = true;
            this.hidepass1.CheckedChanged += new System.EventHandler(this.hidepass1_CheckedChanged);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HostelManagementSystem.Properties.Resources._3747425;
            this.ClientSize = new System.Drawing.Size(852, 601);
            this.Controls.Add(this.email);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.Text = "Login";
            this.email.ResumeLayout(false);
            this.email.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel email;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox gender;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.TextBox l_name;
        private System.Windows.Forms.TextBox first_name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox con_password;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox emailadd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox hidepass1;
        private System.Windows.Forms.CheckBox hidepass;
    }
}