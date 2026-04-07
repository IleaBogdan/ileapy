using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ileapy
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
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

        private void Signup_Button_Click(object sender, EventArgs e)
        {
            // signup: (@Id,@Uname,@Hpass,@Mail,@Phone,@BDay,@Address)

        }
    }
}
