using System.Windows.Forms;

namespace ileapy
{
    partial class LoginPage
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
            this.uname_display_label = new System.Windows.Forms.Label();
            this.uname_textBox = new System.Windows.Forms.TextBox();
            this.Login_Button = new System.Windows.Forms.Button();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.password_display_label = new System.Windows.Forms.Label();
            this.Signup_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uname_display_label
            // 
            this.uname_display_label.AutoSize = true;
            this.uname_display_label.Location = new System.Drawing.Point(12, 22);
            this.uname_display_label.Name = "uname_display_label";
            this.uname_display_label.Size = new System.Drawing.Size(58, 13);
            this.uname_display_label.TabIndex = 11;
            this.uname_display_label.Text = "Username:";
            // 
            // uname_textBox
            // 
            this.uname_textBox.Location = new System.Drawing.Point(76, 19);
            this.uname_textBox.Name = "uname_textBox";
            this.uname_textBox.Size = new System.Drawing.Size(80, 20);
            this.uname_textBox.TabIndex = 1;
            // 
            // Login_Button
            // 
            this.Login_Button.Location = new System.Drawing.Point(192, 28);
            this.Login_Button.Name = "Login_Button";
            this.Login_Button.Size = new System.Drawing.Size(74, 38);
            this.Login_Button.TabIndex = 3;
            this.Login_Button.Text = "Login";
            this.Login_Button.UseVisualStyleBackColor = true;
            this.Login_Button.Click += new System.EventHandler(this.Login_Button_Click);
            // 
            // password_textBox
            // 
            this.password_textBox.Location = new System.Drawing.Point(80, 52);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.PasswordChar = '*';
            this.password_textBox.Size = new System.Drawing.Size(75, 20);
            this.password_textBox.TabIndex = 2;
            // 
            // password_display_label
            // 
            this.password_display_label.AutoSize = true;
            this.password_display_label.Location = new System.Drawing.Point(14, 53);
            this.password_display_label.Name = "password_display_label";
            this.password_display_label.Size = new System.Drawing.Size(56, 13);
            this.password_display_label.TabIndex = 10;
            this.password_display_label.Text = "Password:";
            // 
            // Signup_Button
            // 
            this.Signup_Button.Location = new System.Drawing.Point(192, 161);
            this.Signup_Button.Name = "Signup_Button";
            this.Signup_Button.Size = new System.Drawing.Size(74, 38);
            this.Signup_Button.TabIndex = 12;
            this.Signup_Button.Text = "Sign Up";
            this.Signup_Button.UseVisualStyleBackColor = true;
            this.Signup_Button.Click += new System.EventHandler(this.Signup_Button_Click);
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Signup_Button);
            this.Controls.Add(this.password_display_label);
            this.Controls.Add(this.password_textBox);
            this.Controls.Add(this.Login_Button);
            this.Controls.Add(this.uname_textBox);
            this.Controls.Add(this.uname_display_label);
            this.Name = "LoginPage";
            this.Text = "Login Page";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uname_display_label;
        private System.Windows.Forms.TextBox uname_textBox;
        private System.Windows.Forms.Button Login_Button;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.Label password_display_label;
        private Button Signup_Button;
    }
}