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
            for (int i = 0; i < Cache.card_list.Count; ++i)
            {
                this.add_tab();
                this.set_balance(Cache.card_list[i].Amount,i);
                //CurrencyIniter.InitCurrecnys(ref this.Currencys, ref this.RevCurrencys, ref this.tabList, ref this.Selected_Currency,ref this.cardsTabControl);
                CurrencyIniter.InitCurrecnys(i,ref this.Currencys,ref this.RevCurrencys, ref this.tabList, ref this.Selected_Currency);
            }


            this.usersTableAdapter = Program.GlobalDataManager.usersTableAdapter;
            this.transactionsTableAdapter = Program.GlobalDataManager.transactionsTableAdapter;
            this.cardsTableAdapter = Program.GlobalDataManager.cardsTableAdapter;

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
        private void set_balance(double new_balance)
        {
            set_balance(new_balance, this.cardsTabControl.SelectedIndex);
        }
        private void set_balance(double new_balance,int index)
        {
            string new_text = Convert.ToDouble(String.Format("{0:0.00}", new_balance)).ToString();
            //Console.WriteLine(new_text);
            try
            {
                if (new_text[new_text.Length - 2] == '.') new_text += "0";
                if (new_text[new_text.Length - 3] != '.') new_text += ".00";
            }
            catch(Exception E)
            {
                if(E.Message== "Index was outside the bounds of the array.")
                {
                    new_text += ".00";
                }
                else
                {
                    throw E;
                }
            }
            try
            {
                this.tabList[index].balance_label.Text = new_text + " " + RevCurrencys["" + this.tabList[index].Currency_ComboBox.SelectedItem];
            }
            catch {
                this.tabList[index].balance_label.Text = new_text + " eur";
            }
            this.tabList[index].balance_label.Left = (this.ClientSize.Width - this.tabList[index].balance_label.Width) / 2;
            this.tabList[index].UpdateControlPositions();
        }


        private void ConvertButton_Click(object sender, EventArgs e)
        {
            string from = "eur";
            string to = RevCurrencys["" + this.tabList[this.cardsTabControl.SelectedIndex].Currency_ComboBox.SelectedItem];
            if (to==from)
            {
                set_balance(Cache.card_list[this.cardsTabControl.SelectedIndex].Amount);
                return;
            }
            double multiplier = CurrencyConverter.CoinDiff(from, to);
            if (multiplier < 0)
            {
                throw new ArgumentException("multiplier calculation failed");
            }
            set_balance(multiplier * Convert.ToDouble(Cache.card_list[this.cardsTabControl.SelectedIndex].Amount));
            Selected_Currency = to;
        }
        private void RefreshButton_Click(Object sender, EventArgs e)
        {
            double amount=Cache.RefreshAmount(this.cardsTabControl.SelectedIndex);
            set_balance(amount);
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
            tb.Refresh_Button.Click += new System.EventHandler(this.RefreshButton_Click);

            this.tabList.Add(tb);

            TabPage myTabPage = new TabPage("Card " + (this.cardsTabControl.TabPages.Count + 1).ToString());

            // Add controls to tab page
            myTabPage.Controls.Add(tb.balance_label);
            myTabPage.Controls.Add(tb.Currency_ComboBox);
            myTabPage.Controls.Add(tb.Convert_Button);
            myTabPage.Controls.Add(tb.Refresh_Button);

            myTabPage.Location = new System.Drawing.Point(8, 22);
            myTabPage.Padding = new System.Windows.Forms.Padding(3);
            myTabPage.Size = new System.Drawing.Size(539, 463);
            myTabPage.TabIndex = 0;
            myTabPage.UseVisualStyleBackColor = true;

            this.cardsTabControl.TabPages.Add(myTabPage);

            // Center the controls in tab
            tb.CenterControls(myTabPage);
        }

        private void new_card_button_Click(object sender, EventArgs e)
        {
            this.add_tab();
            Cache.add_card();
            int i=Cache.card_list.Count-1;
            this.set_balance(Cache.card_list[i].Amount, i);
            //CurrencyIniter.InitCurrecnys(ref this.Currencys, ref this.RevCurrencys, ref this.tabList, ref this.Selected_Currency,ref this.cardsTabControl);
            CurrencyIniter.InitCurrecnys(i, ref this.Currencys, ref this.RevCurrencys, ref this.tabList, ref this.Selected_Currency);
        }
    }
}
