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
    public partial class TransactionMenu : Form
    {
        private List<Pair<int,string>>ids_and_unames=new List<Pair<int,string>>();
        public TransactionMenu()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
            this.from_card_comboBox.Items.Clear();
            for (int i = 0; i < Cache.card_list.Count;)
            {
                double amount = Cache.card_list[i].Amount;
                string hcnr = Cache.card_list[i].HideCardNumber();
                this.from_card_comboBox.Items.Add("Card " + MyStrings.Aligne(++i, Cache.card_list.Count.ToString().Length) + " ("+hcnr+") --- " + amount.ToString() + " eur");
            }
        }
        private int cardSelected=-1;

        private void from_card_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine(this.from_card_comboBox.SelectedIndex);
            int idx= this.from_card_comboBox.SelectedIndex;

            cardSelected = idx;

            // here we will change the max transfer amount label
            this.max_amount_label.Text="<= " + Cache.card_list[idx].Amount.ToString();
        }

        private void next_button1_Click(object sender, EventArgs e)
        {
            if (cardSelected < 0)
            {
                System.Windows.Forms.MessageBox.Show("Please selecta card before transfering!");
                return;
            }
            string al = this.transfer_sum_textBox.Text;
            for (int i = 0; i < al.Length; ++i)
            {
                if (al[i] == '.') continue;
                if (!(al[i] >= '0' && al[i] <= '9'))
                {
                    System.Windows.Forms.MessageBox.Show("Please enter a valid number!");
                    return;
                }
            }
            double Tamount;
            Double.TryParse(al,out Tamount);
            if (Tamount > 0)
            {
                if (Tamount > Cache.card_list[cardSelected].Amount)
                {
                    System.Windows.Forms.MessageBox.Show("You don't have enough money!");
                    return;
                }
                this.transaction_progressBar.Value += 25;
                this.Controls.Remove(this.max_amount_label);
                this.Controls.Remove(this.transfer_amount_label);
                this.Controls.Remove(this.transfer_sum_textBox);
                this.Controls.Remove(this.from_card_comboBox);
                this.Controls.Remove(this.from_select_label);
                this.Controls.Remove(this.next_button1);

                this.Controls.Add(this.next_button2);
                this.Controls.Add(this.to_who_label);
                this.Controls.Add(this.user_select_comboBox);
                // pupulate the the textbox with data
                DataManager.GetAllUsers(ref this.ids_and_unames);
                //for(int i = 0; i < this.ids_and_unames.Count; ++i)
                //{
                //    Console.WriteLine(this.ids_and_unames[i].First.ToString() + " " + this.ids_and_unames[i].Second);
                //}
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("You can't transfer 0 or negative money!");
            }
        }

        private void user_select_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(this.user_select_comboBox.SelectedIndex);
        }
        private void next_button2_Click(object sender, EventArgs e)
        {

        }
    }
}
