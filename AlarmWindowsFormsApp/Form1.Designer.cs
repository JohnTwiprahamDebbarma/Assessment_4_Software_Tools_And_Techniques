namespace AlarmWindowsFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            lblCurrentTime = new Label();
            lblStatus = new Label();
            txtTimeInput = new TextBox();
            btnStart = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 41);
            label1.Name = "label1";
            label1.Size = new Size(136, 15);
            label1.TabIndex = 0;
            label1.Text = "Alarm Clock Application";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 67);
            label2.Name = "label2";
            label2.Size = new Size(162, 15);
            label2.TabIndex = 1;
            label2.Text = "Enter time in HH:MM format:";
            // 
            // lblCurrentTime
            // 
            lblCurrentTime.AutoSize = true;
            lblCurrentTime.Location = new Point(41, 179);
            lblCurrentTime.Name = "lblCurrentTime";
            lblCurrentTime.Size = new Size(116, 15);
            lblCurrentTime.TabIndex = 2;
            lblCurrentTime.Text = "Current time: --:--:--";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(41, 194);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(135, 15);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Status: Waiting for input";
            lblStatus.Click += lblStatus_Click;
            // 
            // txtTimeInput
            // 
            txtTimeInput.Location = new Point(41, 85);
            txtTimeInput.Name = "txtTimeInput";
            txtTimeInput.Size = new Size(100, 23);
            txtTimeInput.TabIndex = 4;
            txtTimeInput.Text = "12:00:00";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(41, 124);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 5;
            btnStart.Text = "Start Alarm";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnStart);
            Controls.Add(txtTimeInput);
            Controls.Add(lblStatus);
            Controls.Add(lblCurrentTime);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label lblCurrentTime;
        private Label lblStatus;
        private TextBox txtTimeInput;
        private Button btnStart;
    }
}
