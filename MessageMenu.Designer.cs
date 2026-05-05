namespace ileapy
{
    partial class MessageMenu
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
            this.user_select_comboBox = new System.Windows.Forms.ComboBox();
            this.send_button = new System.Windows.Forms.Button();
            this.message_textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // user_select_comboBox
            // 
            this.user_select_comboBox.FormattingEnabled = true;
            this.user_select_comboBox.Location = new System.Drawing.Point(12, 12);
            this.user_select_comboBox.Name = "user_select_comboBox";
            this.user_select_comboBox.Size = new System.Drawing.Size(243, 21);
            this.user_select_comboBox.TabIndex = 0;
            // 
            // send_button
            // 
            this.send_button.Location = new System.Drawing.Point(12, 210);
            this.send_button.Name = "send_button";
            this.send_button.Size = new System.Drawing.Size(243, 54);
            this.send_button.TabIndex = 1;
            this.send_button.Text = "Send";
            this.send_button.UseVisualStyleBackColor = true;
            this.send_button.Click += new System.EventHandler(this.send_button_Click);
            // 
            // message_textBox
            // 
            this.message_textBox.Location = new System.Drawing.Point(12, 57);
            this.message_textBox.Multiline = true;
            this.message_textBox.Name = "message_textBox";
            this.message_textBox.Size = new System.Drawing.Size(243, 127);
            this.message_textBox.TabIndex = 2;
            // 
            // MessageMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 276);
            this.Controls.Add(this.message_textBox);
            this.Controls.Add(this.send_button);
            this.Controls.Add(this.user_select_comboBox);
            this.Name = "MessageMenu";
            this.Text = "MessageMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox user_select_comboBox;
        private System.Windows.Forms.Button send_button;
        private System.Windows.Forms.TextBox message_textBox;
    }
}