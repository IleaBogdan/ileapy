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
    public partial class passwordCheck : Form
    {
        public passwordCheck()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
            fail_counter = 0;
        }
        public int fail_counter = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            string password = this.textBox1.Text;
            string hpassword =Program.hash(password);

            if (hpassword != Cache.hpassword)
            {
                ++fail_counter;
                if (fail_counter >= 3)
                {
                    Cache.logout();
                    System.Windows.Forms.MessageBox.Show("3 failed attempts!");
                    this.Close();
                    Program.kill();
                    return;
                }
                System.Windows.Forms.MessageBox.Show("Wrong password!");
                return;
            }
            TransactionMenu.should_close = true;
            this.Close();
        }
    }
}
