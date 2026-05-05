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
    public partial class MessageMenu : Form
    {
        List<Pair<int, string>> users_and_ids = new List<Pair<int, string>>();
        Dictionary<int, int> idx_id= new Dictionary<int, int>();
        public MessageMenu()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
            this.init_comboBox();
        }
        private void init_comboBox()
        {
            DataManager.GetAllUsers(ref this.users_and_ids);
            for (int i = 0; i < users_and_ids.Count; ++i)
            {
                if (users_and_ids[i].First == Cache.user_id) continue;
                this.user_select_comboBox.Items.Add(users_and_ids[i].Second);
                this.idx_id[i] = users_and_ids[i].First;
            }
        }
        private void trigger_error()
        {
            System.Windows.Forms.MessageBox.Show("An unexpected error happened, please try again later!");
            this.Close();
        }
        private void send_button_Click(object sender, EventArgs e)
        {
            if(this.user_select_comboBox.SelectedIndex == -1) return;
            if(this.message_textBox.Text.Length==0) return;
            int recv_id = idx_id[this.user_select_comboBox.SelectedIndex];
            try
            {
                DataManager.SendMessage(Cache.user_id, recv_id, this.message_textBox.Text);
            }
            catch
            {
                this.trigger_error();
                this.Close();
            }
            HomePage.complete= true;
            this.Close();
        }
    }
}
