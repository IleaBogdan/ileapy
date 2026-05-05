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
            this.ileapyDataSet.EnforceConstraints = false;

            this.cardsTableAdapter = new ileapyDataSetTableAdapters.CardsTableAdapter();
            this.transactionsTableAdapter = new ileapyDataSetTableAdapters.TransactionsTableAdapter();
            this.usersTableAdapter = new ileapyDataSetTableAdapters.UsersTableAdapter();

            // IMPORTANT: keep all TableAdapters on the same database file.
            // The generated adapters currently use different Settings connection strings:
            // - CardsTableAdapter: ileapyConnectionString (absolute path MDF)
            // - TransactionsTableAdapter/UsersTableAdapter: ileapyConnectionString1 (|DataDirectory| MDF copy)
            // If left as-is, cards update and transactions insert happen in different MDFs.
            var connectionString = this.cardsTableAdapter.Connection.ConnectionString;
            this.transactionsTableAdapter.Connection.ConnectionString = connectionString;
            this.usersTableAdapter.Connection.ConnectionString = connectionString;

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
        public static Pair<List<string>,List<int>> QueryCardNumbers(int index)
        {
            ileapyDataSet.CardsDataTable data=new ileapyDataSet.CardsDataTable();
            try
            {
                Program.GlobalDataManager.cardsTableAdapter.GetCardsVIAId(index, ref data);
            }
            catch { } // empty catch because some random error that is thrown for no reason
            //Console.WriteLine("chestie: "+data.Rows.Count);
            var row = data.Rows[0];
            string cardsDetails = row["cards_details"]?.ToString();
            string[] cards = cardsDetails.Split(',');
            var card_list = new Pair<List<string>,List<int>>();
            card_list.First = new List<string>();
            card_list.Second = new List<int>();
            if (cards == null) return new Pair<List<string>, List<int>>();
            for (int i = 0; i < cards.Length; ++i)
            {
                string[] card = cards[i].Split('|');
                if (card == null) continue;
                if (card.Length != 2) continue;
                string c = card[0];
                //Console.WriteLine(c);
                card_list.First.Add(c);
                card_list.Second.Add(Int32.Parse(card[1]));
            }

            return card_list;
        }
        public static int GetCardId(string CardNumber,string CVC,string ExpDate)
        {
            try
            {
                var x = Program.GlobalDataManager.cardsTableAdapter.GetCardIdBy(CardNumber, CVC, ExpDate);
                //Console.WriteLine(x);
                return (int)x;
            }
            catch
            {
                return -1;
            }
        }
        public static void MakeTransaction(int id_from,int id_to,string message,double amount)
        {
            if (id_to == id_from||amount<1.0) throw new Exception("same card id");
            // one transaction that has type 1 and the other has type 2
            var date = DateTime.Now;

            // get current card data
            double amount_from=(double)Program.GlobalDataManager.cardsTableAdapter.GetAmountById(id_from);
            double amount_to=(double)Program.GlobalDataManager.cardsTableAdapter.GetAmountById(id_to);

            if (amount_from < amount)
            {
                throw new Exception("insufficient funds");
            }

            double new_amount_from = amount_from- amount;
            double new_amount_to = amount_to +amount;

            Console.WriteLine(new_amount_from);

            var insert1 = Program.GlobalDataManager.transactionsTableAdapter.InsertTransaction(
                id_from, id_to, (decimal)amount, message, date, 1
            );
            var insert2 = Program.GlobalDataManager.transactionsTableAdapter.InsertTransaction(
                id_to, id_from, (decimal)amount, message, date, 2
            );
            if (insert1 <= 0 || insert2 <= 0)
            {
                throw new Exception("failed to insert transaction");
            }

            // refresh in-memory table so I can see the new rows
            Program.GlobalDataManager.transactionsTableAdapter.Fill(Program.GlobalDataManager.DataSet.Transactions);

            // update the 2 cards
            // UpdateCardAmount signature is (Amount, Id, Original_Amount) (optimistic concurrency).
            var updTo = Program.GlobalDataManager.cardsTableAdapter.UpdateCardAmount(
                (decimal)new_amount_to, id_to, (decimal)amount_to
            );
            var updFrom = Program.GlobalDataManager.cardsTableAdapter.UpdateCardAmount(
                (decimal)new_amount_from, id_from, (decimal)amount_from
            );
            if (updTo <= 0 || updFrom <= 0)
            {
                throw new Exception("failed to update card amount");
            }
        }
        public static dynamic GetTransactionsById(int id)
        {
            return Program.GlobalDataManager.transactionsTableAdapter.GetTransactions(id);
        }

        public BindingSource CardsBindingSource => cardsBindingSource;
        public BindingSource TransactionsBindingSource => transactionsBindingSource;
        public BindingSource UsersBindingSource => usersBindingSource;

        public ileapyDataSet DataSet => ileapyDataSet;
    }
}