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
    public partial class AddPage : Form
    {
        private int idx;
        public AddPage(int _idx)
        {
            idx= _idx;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void add_money_button_Click(object sender, EventArgs e)
        {
            string text = adding_amount_textBox.Text;
            for(int i = 0; i < text.Length; ++i)
            {
                if (text[i] == '.') continue;
                if (!(text[i] >= '0' && text[i] <= '9')) return;
            }
            double amount;
            Double.TryParse(text,out amount);
            Console.WriteLine(amount);
            if (amount <= 0.0) return;

            // we fetch for the money amount of this card and then we update
            // since in cache the amount mai not be acurate
            amount+=Cache.RefreshAmount(this.idx);
            Cache.UpdateAmount(this.idx,amount);
            HomePage.complete= true;
            this.Close();
        }
    }
}
