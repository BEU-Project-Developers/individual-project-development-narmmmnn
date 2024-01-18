﻿namespace HostelManagementSystem
{
    partial class Rooms
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.RoomStatus = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.RoomStatusCb = new System.Windows.Forms.ComboBox();
            this.YesRadio = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.NoRadio = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.RoomNumber = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RoomDGV = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // RoomStatus
            // 
            this.RoomStatus.BackColor = System.Drawing.Color.MidnightBlue;
            this.RoomStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RoomStatus.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomStatus.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RoomStatus.Location = new System.Drawing.Point(53, 284);
            this.RoomStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RoomStatus.Name = "RoomStatus";
            this.RoomStatus.Size = new System.Drawing.Size(158, 36);
            this.RoomStatus.TabIndex = 5;
            this.RoomStatus.Text = "Room Status";
            this.RoomStatus.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.Gainsboro;
            this.panel2.Location = new System.Drawing.Point(0, 119);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1131, 10);
            this.panel2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(706, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 34);
            this.label2.TabIndex = 9;
            this.label2.Text = "Room List";
            // 
            // RoomStatusCb
            // 
            this.RoomStatusCb.BackColor = System.Drawing.SystemColors.Window;
            this.RoomStatusCb.FormattingEnabled = true;
            this.RoomStatusCb.Items.AddRange(new object[] {
            "Active",
            "NotActive"});
            this.RoomStatusCb.Location = new System.Drawing.Point(254, 291);
            this.RoomStatusCb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RoomStatusCb.Name = "RoomStatusCb";
            this.RoomStatusCb.Size = new System.Drawing.Size(133, 27);
            this.RoomStatusCb.TabIndex = 11;
            this.RoomStatusCb.SelectedIndexChanged += new System.EventHandler(this.RoomStatusCb_SelectedIndexChanged);
            // 
            // YesRadio
            // 
            this.YesRadio.AutoSize = true;
            this.YesRadio.BackColor = System.Drawing.SystemColors.Control;
            this.YesRadio.Checked = true;
            this.YesRadio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.YesRadio.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YesRadio.ForeColor = System.Drawing.Color.Navy;
            this.YesRadio.Location = new System.Drawing.Point(259, 378);
            this.YesRadio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.YesRadio.Name = "YesRadio";
            this.YesRadio.Size = new System.Drawing.Size(55, 20);
            this.YesRadio.TabIndex = 12;
            this.YesRadio.TabStop = true;
            this.YesRadio.Text = "Yes";
            this.YesRadio.UseVisualStyleBackColor = false;
            this.YesRadio.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MidnightBlue;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(53, 368);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 36);
            this.button2.TabIndex = 13;
            this.button2.Text = "Booked";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // NoRadio
            // 
            this.NoRadio.AutoSize = true;
            this.NoRadio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NoRadio.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoRadio.ForeColor = System.Drawing.Color.Navy;
            this.NoRadio.Location = new System.Drawing.Point(331, 378);
            this.NoRadio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NoRadio.Name = "NoRadio";
            this.NoRadio.Size = new System.Drawing.Size(47, 20);
            this.NoRadio.TabIndex = 14;
            this.NoRadio.Text = "No";
            this.NoRadio.UseVisualStyleBackColor = true;
            this.NoRadio.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // RoomNumber
            // 
            this.RoomNumber.BackColor = System.Drawing.Color.MidnightBlue;
            this.RoomNumber.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RoomNumber.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomNumber.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RoomNumber.Location = new System.Drawing.Point(53, 199);
            this.RoomNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RoomNumber.Name = "RoomNumber";
            this.RoomNumber.Size = new System.Drawing.Size(158, 36);
            this.RoomNumber.TabIndex = 17;
            this.RoomNumber.Text = "Room Number";
            this.RoomNumber.UseVisualStyleBackColor = false;
            this.RoomNumber.Click += new System.EventHandler(this.RoomNumber_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Control;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button4.Location = new System.Drawing.Point(188, 639);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(98, 36);
            this.button4.TabIndex = 18;
            this.button4.Text = "BACK";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.Control;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button5.Location = new System.Drawing.Point(321, 563);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(122, 36);
            this.button5.TabIndex = 19;
            this.button5.Text = "DELETE";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.Control;
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button6.Location = new System.Drawing.Point(178, 563);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(117, 36);
            this.button6.TabIndex = 20;
            this.button6.Text = "UPDATE";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.Control;
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button7.Location = new System.Drawing.Point(53, 563);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(98, 36);
            this.button7.TabIndex = 21;
            this.button7.Text = "ADD";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 746);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1131, 23);
            this.panel4.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(341, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(310, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "www.StepInnMyeongdong.com";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(254, 206);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(133, 25);
            this.textBox1.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1131, 119);
            this.panel1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(1081, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 36);
            this.label3.TabIndex = 1;
            this.label3.Text = "X";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(398, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "ROOM INFORMATION";
            // 
            // RoomDGV
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.RoomDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RoomDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.RoomDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.RoomDGV.DefaultCellStyle = dataGridViewCellStyle6;
            this.RoomDGV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.RoomDGV.Location = new System.Drawing.Point(476, 206);
            this.RoomDGV.Name = "RoomDGV";
            this.RoomDGV.RowHeadersVisible = false;
            this.RoomDGV.RowHeadersWidth = 51;
            this.RoomDGV.RowTemplate.Height = 24;
            this.RoomDGV.Size = new System.Drawing.Size(619, 486);
            this.RoomDGV.TabIndex = 24;
            this.RoomDGV.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.RoomDGV.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.RoomDGV.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.RoomDGV.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.RoomDGV.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.RoomDGV.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.RoomDGV.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.RoomDGV.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.RoomDGV.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.RoomDGV.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomDGV.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.RoomDGV.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoomDGV.ThemeStyle.HeaderStyle.Height = 4;
            this.RoomDGV.ThemeStyle.ReadOnly = false;
            this.RoomDGV.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.RoomDGV.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.RoomDGV.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomDGV.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.RoomDGV.ThemeStyle.RowsStyle.Height = 24;
            this.RoomDGV.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.RoomDGV.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.RoomDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoomDGV_CellContentClick_1);
            // 
            // Rooms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1131, 769);
            this.Controls.Add(this.RoomDGV);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.RoomNumber);
            this.Controls.Add(this.NoRadio);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.YesRadio);
            this.Controls.Add(this.RoomStatusCb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RoomStatus);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Rooms";
            this.Text = "Rooms";
            this.Load += new System.EventHandler(this.Rooms_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RoomStatus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox RoomStatusCb;
        private System.Windows.Forms.RadioButton YesRadio;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton NoRadio;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button RoomNumber;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView RoomDGV;
    }
}