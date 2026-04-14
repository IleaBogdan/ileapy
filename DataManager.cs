using ileapy.ileapyDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ileapy.Cache;

namespace ileapy
{
    public class DataManager
    {
        private ileapyDataSet ileapyDataSet;
        private System.Windows.Forms.BindingSource cardsBindingSource;
        private System.Windows.Forms.BindingSource transactionsBindingSource;
        private System.Windows.Forms.BindingSource usersBindingSource;
        public ileapyDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        public ileapyDataSetTableAdapters.CardsTableAdapter cardsTableAdapter;
        public ileapyDataSetTableAdapters.TransactionsTableAdapter transactionsTableAdapter;
        public ileapyDataSetTableAdapters.UsersTableAdapter usersTableAdapter;

        public DataManager()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.ileapyDataSet = new ileapyDataSet();

            this.cardsTableAdapter = new ileapyDataSetTableAdapters.CardsTableAdapter();
            this.transactionsTableAdapter = new ileapyDataSetTableAdapters.TransactionsTableAdapter();
            this.usersTableAdapter = new ileapyDataSetTableAdapters.UsersTableAdapter();

            this.tableAdapterManager = new ileapyDataSetTableAdapters.TableAdapterManager();
            this.tableAdapterManager.CardsTableAdapter = this.cardsTableAdapter;
            this.tableAdapterManager.TransactionsTableAdapter = this.transactionsTableAdapter;
            this.tableAdapterManager.UsersTableAdapter = this.usersTableAdapter;
            this.tableAdapterManager.UpdateOrder = ileapyDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;

            this.cardsBindingSource = new System.Windows.Forms.BindingSource();
            this.transactionsBindingSource = new System.Windows.Forms.BindingSource();
            this.usersBindingSource = new System.Windows.Forms.BindingSource();

            this.cardsBindingSource.DataSource = this.ileapyDataSet;
            this.cardsBindingSource.DataMember = "Cards";

            this.transactionsBindingSource.DataSource = this.ileapyDataSet;
            this.transactionsBindingSource.DataMember = "Transactions";

            this.usersBindingSource.DataSource = this.ileapyDataSet;
            this.usersBindingSource.DataMember = "Users";

            this.usersTableAdapter.Fill(this.ileapyDataSet.Users);
            this.cardsTableAdapter.Fill(this.ileapyDataSet.Cards);
            this.transactionsTableAdapter.Fill(this.ileapyDataSet.Transactions);

            this.ileapyDataSet.EnforceConstraints = false;

            this.usersTableAdapter.Connection.Open();
            this.cardsTableAdapter.Connection.Open();
            this.transactionsTableAdapter.Connection.Open();
        }
        public static void add_card()
        {
            var ci = new CardInfo();
            var res = Program.GlobalDataManager.cardsTableAdapter.AddNewCard(ci.CardNumber, ci.CVC, ci.ExpDate, Cache.user_id, (decimal)ci.Amount);
            if (res <= 0)
            {
                throw new Exception("Failed to add card");
            }
            card_list.Add(ci);
        }
        public static double RefreshAmount(int idx)
        {
            double amount = (double)Program.GlobalDataManager.cardsTableAdapter.RefrashCard(Cache.card_list[idx].CardNumber, Cache.card_list[idx].ExpDate, user_id);
            Cache.card_list[idx].Amount = amount;
            //Console.WriteLine(amount);
            return amount;
        }
        public static void UpdateAmount(int idx, double amount)
        {
            var rez = Program.GlobalDataManager.cardsTableAdapter.UpdateAmount((decimal)amount, Cache.card_list[idx].CardNumber, Cache.card_list[idx].CVC, Cache.card_list[idx].ExpDate, Cache.user_id);
            if (rez <= 0)
            {
                Cache.card_list[idx].Amount = amount;
            }
        }
        public static void GetAllUsers(ref List<Pair<int, string>> ids_and_unames)
        {
            ids_and_unames.Clear();
            ileapyDataSet.UsersDataTable dataTable =new ileapyDataSet.UsersDataTable();
            try
            {
                Program.GlobalDataManager.usersTableAdapter.GetIdsAndUnames(ref dataTable);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            for(int i = 0; i < dataTable.Count; ++i)
            {
                ids_and_unames.Add(new Pair<int, string>(dataTable[i].Id, dataTable[i].Uname));
            }
        }

        public BindingSource CardsBindingSource => cardsBindingSource;
        public BindingSource TransactionsBindingSource => transactionsBindingSource;
        public BindingSource UsersBindingSource => usersBindingSource;

        public ileapyDataSet DataSet => ileapyDataSet;
    }
}