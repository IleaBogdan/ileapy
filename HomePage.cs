using ileapy;
using ileapy.ileapyDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ileapy
{
    public partial class HomePage : Form
    {
        Dictionary<string, string> Currencys = new Dictionary<string, string>();
        Dictionary<string, string> RevCurrencys = new Dictionary<string, string>();
        private bool isLoggingOut = false; 
        private string Selected_Currency;
        List<TabButtons> tabList=new List<TabButtons>();
        public HomePage()
        {
            InitializeComponent();
            
            // this should be part of the init components, but VS will scream at me if I put it there
            this.cardsTabControl.TabPages.Clear();
            this.cardsTabControl.Selecting += cardsTabControl_Selecting;
            this.cardsTabControl.Resize += cardsTabControl_Resize;
            add_tab();

            InitCurrecnys();

            this.usersTableAdapter = Program.GlobalDataManager.usersTableAdapter;
            this.transactionsTableAdapter = Program.GlobalDataManager.transactionsTableAdapter;
            this.cardsTableAdapter = Program.GlobalDataManager.cardsTableAdapter;

            set_balance(1000000000.1);
            this.FormClosing += HomePage_FormClosing;
            isLoggingOut = false;
            this.username_display_label.Text +="\n"+ Cache.uname;
        }

        void cardsTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            Console.WriteLine(this.cardsTabControl.SelectedIndex);
        }
        private void HomePage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isLoggingOut)
            {
                Program.program_state = false;
            }
        }

        void cardsTabControl_Resize(object sender, EventArgs e)
        {
            // Re-center controls for all tabs when the tab control is resized
            foreach (TabButtons tb in tabList)
            {
                tb.UpdateControlPositions();
            }
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
            //this.tabList[this.cardsTabControl.SelectedIndex].Currency_ComboBox.Items.Clear();
            foreach (var e in Currencys)
            {
                //Console.WriteLine($"Key: {e.Key}, Value: {e.Value}");
                this.tabList[this.cardsTabControl.SelectedIndex].Currency_ComboBox.Items.Add(e.Value);
            }
            this.tabList[this.cardsTabControl.SelectedIndex].Currency_ComboBox.SelectedIndex = this.tabList[this.cardsTabControl.SelectedIndex].Currency_ComboBox.FindString("Euro");
            Selected_Currency = "eur";
        }
        private void set_balance(double new_balance)
        {
            string new_text = Convert.ToDouble(String.Format("{0:0.00}", new_balance)).ToString();
            if (new_text[new_text.Length - 2] == '.') new_text+="0";
            if (new_text[new_text.Length - 3] != '.') new_text += ".00";
            this.tabList[this.cardsTabControl.SelectedIndex].balance_label.Text = new_text + " " + RevCurrencys["" + this.tabList[this.cardsTabControl.SelectedIndex].Currency_ComboBox.SelectedItem];
            this.tabList[this.cardsTabControl.SelectedIndex].balance_label.Left = (this.ClientSize.Width - this.tabList[this.cardsTabControl.SelectedIndex].balance_label.Width) / 2;
            this.tabList[this.cardsTabControl.SelectedIndex].UpdateControlPositions();
        }
        private void ConvertButton_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(RevCurrencys["" + this.tabList[this.cardsTabControl.SelectedIndex].Currency_ComboBox.SelectedItem]);
            string from = Selected_Currency;
            if (!RevCurrencys.ContainsKey("" + this.tabList[this.cardsTabControl.SelectedIndex].Currency_ComboBox.SelectedItem))
            {
                return;
            }
            string to = RevCurrencys["" + this.tabList[this.cardsTabControl.SelectedIndex].Currency_ComboBox.SelectedItem];
            double multiplier = CurrencyConverter.CoinDiff(from, to);
            if (multiplier < 0)
            {
                throw new ArgumentException("multiplier calculation failed");
            }
            set_balance(multiplier * Convert.ToDouble(this.tabList[this.cardsTabControl.SelectedIndex].balance_label.Text.Substring(
                                            0,
                                            this.tabList[this.cardsTabControl.SelectedIndex].balance_label.Text.IndexOf(" ")
                                            )));
            Selected_Currency = to;
        }

        private void logout_button_Click(object sender, EventArgs e)
        {
            isLoggingOut = true;
            Cache.logout();
            this.Close();
        }

        private void add_tab()
        {
            TabButtons tb = new TabButtons();
            tb.Convert_Button.Click += new System.EventHandler(this.ConvertButton_Click);

            this.tabList.Add(tb);

            TabPage myTabPage = new TabPage("Card " + (this.cardsTabControl.TabPages.Count + 1).ToString());

            // Add controls to tab page
            myTabPage.Controls.Add(tb.balance_label);
            myTabPage.Controls.Add(tb.Currency_ComboBox);
            myTabPage.Controls.Add(tb.Convert_Button);

            myTabPage.Location = new System.Drawing.Point(8, 22);
            myTabPage.Padding = new System.Windows.Forms.Padding(3);
            myTabPage.Size = new System.Drawing.Size(539, 463);
            myTabPage.TabIndex = 0;
            myTabPage.UseVisualStyleBackColor = true;

            this.cardsTabControl.TabPages.Add(myTabPage);

            // Center the controls in tab
            tb.CenterControls(myTabPage);
        }
    }
}
