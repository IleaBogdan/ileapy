using ileapy.ileapyDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ileapy
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            this.usersTableAdapter = Program.GlobalDataManager.usersTableAdapter;
            this.transactionsTableAdapter = Program.GlobalDataManager.transactionsTableAdapter;
            this.cardsTableAdapter = Program.GlobalDataManager.cardsTableAdapter;

            this.StartPosition = FormStartPosition.Manual;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Left = (int)(Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.Top = (int)(Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            string username = this.uname_textBox.Text;
            string password = this.password_textBox.Text;

            Console.WriteLine(username + ":" + password);
        }

        public static string hash(string text)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }

        private void Signup_Button_Click(object sender, EventArgs e)
        {
            string username = this.uname_textBox.Text;
            string password = this.password_textBox.Text;
            string phone = this.phone_textBox.Text;
            string mail=this.mail_textBox.Text;
            string address=this.address_textBox.Text;
            string bday = this.bday_dateTimePicker.Value.ToString("yyyy-MM-dd HH:mm:ss");
            //Console.WriteLine(bday);
            if (null == bday || null == username || null == password || null == phone 
                || null == mail || null == address
                || "" == username || "" == password || "" == phone || "" == mail || "" == address)
            {
                System.Windows.Forms.MessageBox.Show("Please enter all values to Sign Up!");
                return;
            }
            var res=usersTableAdapter.AddUser(username,hash(password),mail,phone,bday,address);
            Console.WriteLine(res);
        }
    }
}
