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
            this.signup_display_label = new System.Windows.Forms.Label();
            this.phone_textBox = new System.Windows.Forms.TextBox();
            this.phone_label = new System.Windows.Forms.Label();
            this.mail_label = new System.Windows.Forms.Label();
            this.birthday_label = new System.Windows.Forms.Label();
            this.address_label = new System.Windows.Forms.Label();
            this.mail_textBox = new System.Windows.Forms.TextBox();
            this.address_textBox = new System.Windows.Forms.TextBox();
            this.bday_dateTimePicker = new System.Windows.Forms.DateTimePicker();
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
            this.Signup_Button.Location = new System.Drawing.Point(192, 177);
            this.Signup_Button.Name = "Signup_Button";
            this.Signup_Button.Size = new System.Drawing.Size(74, 38);
            this.Signup_Button.TabIndex = 12;
            this.Signup_Button.Text = "Sign Up";
            this.Signup_Button.UseVisualStyleBackColor = true;
            this.Signup_Button.Click += new System.EventHandler(this.Signup_Button_Click);
            // 
            // signup_display_label
            // 
            this.signup_display_label.AutoSize = true;
            this.signup_display_label.Location = new System.Drawing.Point(14, 106);
            this.signup_display_label.Name = "signup_display_label";
            this.signup_display_label.Size = new System.Drawing.Size(90, 13);
            this.signup_display_label.TabIndex = 13;
            this.signup_display_label.Text = "Only For Sign Up:";
            // 
            // phone_textBox
            // 
            this.phone_textBox.Location = new System.Drawing.Point(80, 134);
            this.phone_textBox.Name = "phone_textBox";
            this.phone_textBox.Size = new System.Drawing.Size(83, 20);
            this.phone_textBox.TabIndex = 14;
            // 
            // phone_label
            // 
            this.phone_label.AutoSize = true;
            this.phone_label.Location = new System.Drawing.Point(14, 137);
            this.phone_label.Name = "phone_label";
            this.phone_label.Size = new System.Drawing.Size(55, 13);
            this.phone_label.TabIndex = 15;
            this.phone_label.Text = "Phone Nr:";
            // 
            // mail_label
            // 
            this.mail_label.AutoSize = true;
            this.mail_label.Location = new System.Drawing.Point(14, 161);
            this.mail_label.Name = "mail_label";
            this.mail_label.Size = new System.Drawing.Size(29, 13);
            this.mail_label.TabIndex = 16;
            this.mail_label.Text = "Mail:";
            // 
            // birthday_label
            // 
            this.birthday_label.AutoSize = true;
            this.birthday_label.Location = new System.Drawing.Point(13, 222);
            this.birthday_label.Name = "birthday_label";
            this.birthday_label.Size = new System.Drawing.Size(48, 13);
            this.birthday_label.TabIndex = 17;
            this.birthday_label.Text = "Birthday:";
            // 
            // address_label
            // 
            this.address_label.AutoSize = true;
            this.address_label.Location = new System.Drawing.Point(13, 193);
            this.address_label.Name = "address_label";
            this.address_label.Size = new System.Drawing.Size(48, 13);
            this.address_label.TabIndex = 18;
            this.address_label.Text = "Address:";
            // 
            // mail_textBox
            // 
            this.mail_textBox.Location = new System.Drawing.Point(80, 160);
            this.mail_textBox.Name = "mail_textBox";
            this.mail_textBox.Size = new System.Drawing.Size(83, 20);
            this.mail_textBox.TabIndex = 19;
            // 
            // address_textBox
            // 
            this.address_textBox.Location = new System.Drawing.Point(81, 186);
            this.address_textBox.Name = "address_textBox";
            this.address_textBox.Size = new System.Drawing.Size(82, 20);
            this.address_textBox.TabIndex = 21;
            // 
            // bday_dateTimePicker
            // 
            this.bday_dateTimePicker.Location = new System.Drawing.Point(81, 216);
            this.bday_dateTimePicker.Name = "bday_dateTimePicker";
            this.bday_dateTimePicker.Size = new System.Drawing.Size(18, 20);
            this.bday_dateTimePicker.TabIndex = 22;
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.bday_dateTimePicker);
            this.Controls.Add(this.address_textBox);
            this.Controls.Add(this.mail_textBox);
            this.Controls.Add(this.address_label);
            this.Controls.Add(this.birthday_label);
            this.Controls.Add(this.mail_label);
            this.Controls.Add(this.phone_label);
            this.Controls.Add(this.phone_textBox);
            this.Controls.Add(this.signup_display_label);
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
        private Label signup_display_label;
        private TextBox phone_textBox;
        private Label phone_label;
        private Label mail_label;
        private Label birthday_label;
        private Label address_label;
        private TextBox mail_textBox;
        private TextBox address_textBox;
        private DateTimePicker bday_dateTimePicker;
        private ileapyDataSet ileapyDataSet;
        private System.Windows.Forms.BindingSource cardsBindingSource;
        private System.Windows.Forms.BindingSource transactionsBindingSource;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private ileapyDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private ileapyDataSetTableAdapters.CardsTableAdapter cardsTableAdapter;
        private ileapyDataSetTableAdapters.TransactionsTableAdapter transactionsTableAdapter;
        private ileapyDataSetTableAdapters.UsersTableAdapter usersTableAdapter;
    }
}