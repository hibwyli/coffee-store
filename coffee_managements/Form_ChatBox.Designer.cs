namespace DoAnLapTrinhMang
{
    partial class Form_ChatBox
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
            this.textbox_Chat = new System.Windows.Forms.TextBox();
            this.button_Gui = new System.Windows.Forms.Button();
            this.textBox_Gui = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textbox_Chat
            // 
            this.textbox_Chat.BackColor = System.Drawing.SystemColors.Info;
            this.textbox_Chat.Dock = System.Windows.Forms.DockStyle.Top;
            this.textbox_Chat.Location = new System.Drawing.Point(0, 0);
            this.textbox_Chat.Multiline = true;
            this.textbox_Chat.Name = "textbox_Chat";
            this.textbox_Chat.Size = new System.Drawing.Size(1274, 562);
            this.textbox_Chat.TabIndex = 12;
            // 
            // button_Gui
            // 
            this.button_Gui.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button_Gui.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Gui.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_Gui.Location = new System.Drawing.Point(858, 604);
            this.button_Gui.Name = "button_Gui";
            this.button_Gui.Size = new System.Drawing.Size(128, 50);
            this.button_Gui.TabIndex = 17;
            this.button_Gui.Text = "Gửi";
            this.button_Gui.UseVisualStyleBackColor = false;
            this.button_Gui.Click += new System.EventHandler(this.button_Gui_Click);
            // 
            // textBox_Gui
            // 
            this.textBox_Gui.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Gui.Location = new System.Drawing.Point(121, 614);
            this.textBox_Gui.Name = "textBox_Gui";
            this.textBox_Gui.Size = new System.Drawing.Size(653, 33);
            this.textBox_Gui.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 607);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 44);
            this.label1.TabIndex = 15;
            this.label1.Text = "Chat";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_Start
            // 
            this.button_Start.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button_Start.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Start.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_Start.Location = new System.Drawing.Point(1056, 604);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(177, 50);
            this.button_Start.TabIndex = 18;
            this.button_Start.Text = "Bắt Đầu";
            this.button_Start.UseVisualStyleBackColor = false;
            this.button_Start.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_ChatBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(1274, 687);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.button_Gui);
            this.Controls.Add(this.textBox_Gui);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textbox_Chat);
            this.Name = "Form_ChatBox";
            this.Text = "Form_ChatBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textbox_Chat;
        private System.Windows.Forms.Button button_Gui;
        private System.Windows.Forms.TextBox textBox_Gui;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Start;
    }
}