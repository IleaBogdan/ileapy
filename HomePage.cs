using ileapy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ileapy
{
    public partial class HomePage : Form
    {
        Dictionary<string, string> Currencys = new Dictionary<string, string>();
        Dictionary<string, string> RevCurrencys = new Dictionary<string, string>();
        private string Selected_Currency;
        public HomePage()
        {
            InitializeComponent();
            InitCurrecnys();
            this.Currency_ComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.Currency_ComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.Currency_ComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            set_balance(1000000000.1);
        }
        private void InitCurrecnys()
        {
            string data = CurrencyConverter.LoadCurrencys();
            int i = 0;
            while (true)
            {
                try
                {
                    string key = MyStrings.split_Quotation(data, ref i);
                    string val = MyStrings.split_Quotation(data, ref i);
                    if ("" == key) break;
                    if ("" == val) continue;
                    if (":" == val) continue;
                    if (": " == val) continue;
                    Currencys[key]=val;
                    RevCurrencys[val]= key;
                }
                catch (Exception err)
                {
                    if (err is ArgumentOutOfRangeException) break;
                    Console.WriteLine(err.Message);
                    Environment.Exit(-2); // The program '[20996] ileapy.exe' has exited with code 4294967294 (0xfffffffe).
                }
            }
            this.Currency_ComboBox.Items.Clear();
            foreach (var e in Currencys)
            {
                //Console.WriteLine($"Key: {e.Key}, Value: {e.Value}");
                this.Currency_ComboBox.Items.Add(e.Value);
            }
            this.Currency_ComboBox.SelectedIndex = this.Currency_ComboBox.FindString("Euro");
            Selected_Currency = "eur";
        }
        private void set_balance(double new_balance)
        {
            string new_text = Convert.ToDouble(String.Format("{0:0.00}", new_balance)).ToString();
            if (new_text[new_text.Length - 2] == '.') new_text+="0";
            if (new_text[new_text.Length - 3] != '.') new_text += ".00";
            this.balance_label.Text = new_text+" "+ RevCurrencys[""+this.Currency_ComboBox.SelectedItem];
            this.balance_label.Left = (this.ClientSize.Width - this.balance_label.Width) / 2;
        }
        private void ConvertButton_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(RevCurrencys["" + this.Currency_ComboBox.SelectedItem]);
            string from =Selected_Currency;
            if(!RevCurrencys.ContainsKey("" + this.Currency_ComboBox.SelectedItem))
            {
                return;
            }
            string to = RevCurrencys["" + this.Currency_ComboBox.SelectedItem];
            double multiplier = CurrencyConverter.CoinDiff(from, to);
            if (multiplier < 0)
            {
                throw new ArgumentException("multiplier calculation failed");
            }
            set_balance(multiplier *Convert.ToDouble(this.balance_label.Text.Substring(
                                            0, 
                                            this.balance_label.Text.IndexOf(" ")
                                            )));
            Selected_Currency = to;
        }

        private void cardsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.cardsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.ileapyDataSet);
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ileapyDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.ileapyDataSet.Users);
            // TODO: This line of code loads data into the 'ileapyDataSet.Transactions' table. You can move, or remove it, as needed.
            this.transactionsTableAdapter.Fill(this.ileapyDataSet.Transactions);
            // TODO: This line of code loads data into the 'ileapyDataSet.Cards' table. You can move, or remove it, as needed.
            this.cardsTableAdapter.Fill(this.ileapyDataSet.Cards);
        }
    }
}
