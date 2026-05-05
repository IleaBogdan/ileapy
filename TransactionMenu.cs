using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ileapy
{
    public partial class TransactionMenu : Form
    {
        private List<Pair<int,string>>ids_and_unames=new List<Pair<int,string>>();
        private Dictionary<string,int>map=new Dictionary<string,int>();
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
            try
            {
                //Console.WriteLine(this.from_card_comboBox.SelectedIndex);
                int idx = this.from_card_comboBox.SelectedIndex;

                cardSelected = idx;

                // here we will change the max transfer amount label
                this.max_amount_label.Text = "<= " + Cache.card_list[idx].Amount.ToString();
            }
            catch
            {
                this.trigger_error();
            }
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
                if (Tamount < 1.0)
                {
                    System.Windows.Forms.MessageBox.Show("Transfer to small");
                    return;
                }
                this.transfer_amount= Tamount;
                this.transaction_progressBar.Value += 34;
                this.Controls.Remove(this.max_amount_label);
                this.Controls.Remove(this.transfer_amount_label);
                this.Controls.Remove(this.transfer_sum_textBox);
                this.Controls.Remove(this.from_card_comboBox);
                this.Controls.Remove(this.from_select_label);
                this.Controls.Remove(this.next_button1);

                this.Controls.Add(this.next_button2);
                this.Controls.Add(this.to_who_label);
                this.Controls.Add(this.user_select_comboBox);
                this.Controls.Add(this.select_to_card_label_label);
                this.Controls.Add(this.select_to_card_comboBox);
                // pupulate the the textbox with data
                DataManager.GetAllUsers(ref this.ids_and_unames);
                this.user_select_comboBox.Items.Clear();
                for (int i = 0; i < this.ids_and_unames.Count; ++i)
                {
                    //Console.WriteLine(this.ids_and_unames[i].First.ToString() + " " + this.ids_and_unames[i].Second);
                    if (this.ids_and_unames[i].First != Cache.user_id)
                    {
                        this.user_select_comboBox.Items.Add(this.ids_and_unames[i].Second);
                    }
                    else
                    {
                        this.user_select_comboBox.Items.Add(this.ids_and_unames[i].Second+" (You)");
                    }
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("You can't transfer 0 or negative money!");
            }
        }

        private List<string> cards_list_to = new List<string>();
        private void user_select_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Console.WriteLine(this.user_select_comboBox.SelectedIndex);
                this.select_to_card_comboBox.Items.Clear();
                var cards = DataManager.QueryCardNumbers(this.ids_and_unames[this.user_select_comboBox.SelectedIndex].First);
                int i = 1;
                map.Clear();
                cards_list_to.Clear();
                foreach (var card in cards.First)
                {
                    if (card == Cache.card_list[cardSelected].CardNumber) continue;
                    this.select_to_card_comboBox.Items.Add("Card " + i.ToString() + ": " + MyStrings.BlurCard((string)card));
                    map[(string)card] = cards.Second[i - 1];
                    //Console.WriteLine(cards.Second[i - 1]);
                    ++i;
                    cards_list_to.Add((string)card);
                }
                this.select_to_card_comboBox.SelectedIndex = 0;
            }
            catch
            {
                return;
            }
        }
        private void trigger_error()
        {
            System.Windows.Forms.MessageBox.Show("An unexpected error happened, please try again later!");
            this.Close();
        }
        private int to_id { get; set; }
        private int from_id {  get; set; }
        private double transfer_amount { get; set; }
        private void next_button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.to_id = map[cards_list_to[this.select_to_card_comboBox.SelectedIndex]];
                this.from_id = DataManager.GetCardId(Cache.card_list[cardSelected].CardNumber, Cache.card_list[cardSelected].CVC, Cache.card_list[cardSelected].ExpDate);
                if (this.from_id < 0)
                {
                    throw new Exception("failed something, goodluck");
                }
                this.transaction_progressBar.Value += 33;
                this.Controls.Remove(this.next_button2);
                this.Controls.Remove(this.to_who_label);
                this.Controls.Remove(this.user_select_comboBox);
                this.Controls.Remove(this.select_to_card_label_label);
                this.Controls.Remove(this.select_to_card_comboBox);

                this.Controls.Add(this.next_button3);
                this.Controls.Add(this.message_textBox);
            }
            catch{
                this.trigger_error();
            }
        }
        private void next_button3_Click(object sender, EventArgs e)
        {
            try
            {
                string message = (string)this.message_textBox.Text;
                //Console.Write(message);
                if (message.Length == 0)
                {
                    System.Windows.Forms.MessageBox.Show("You must type a message!");
                    return;
                }
                this.transaction_progressBar.Value += 33;
                DataManager.MakeTransaction(this.from_id, this.to_id, message, this.transfer_amount);
                this.Close();
            }
            catch
            {
                this.trigger_error();
            }
        }
    }
}
