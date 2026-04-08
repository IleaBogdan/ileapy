using ileapy.ileapyDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ileapy
{
    internal class DataManager
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

        public BindingSource CardsBindingSource => cardsBindingSource;
        public BindingSource TransactionsBindingSource => transactionsBindingSource;
        public BindingSource UsersBindingSource => usersBindingSource;

        public ileapyDataSet DataSet => ileapyDataSet;
    }
}