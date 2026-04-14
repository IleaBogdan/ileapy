using System.Drawing;

namespace ileapy
{
    partial class HomePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ileapyDataSet = new ileapy.ileapyDataSet();
            this.cardsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cardsTableAdapter = new ileapy.ileapyDataSetTableAdapters.CardsTableAdapter();
            this.tableAdapterManager = new ileapy.ileapyDataSetTableAdapters.TableAdapterManager();
            this.transactionsTableAdapter = new ileapy.ileapyDataSetTableAdapters.TransactionsTableAdapter();
            this.usersTableAdapter = new ileapy.ileapyDataSetTableAdapters.UsersTableAdapter();
            this.transactionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.logout_button = new System.Windows.Forms.Button();
            this.username_display_label = new System.Windows.Forms.Label();
            this.cardsTabControl = new System.Windows.Forms.TabControl();
            this.new_card_button = new System.Windows.Forms.Button();
            this.new_transaction_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ileapyDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ileapyDataSet
            // 
            this.ileapyDataSet.DataSetName = "ileapyDataSet";
            this.ileapyDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cardsBindingSource
            // 
            this.cardsBindingSource.DataMember = "Cards";
            this.cardsBindingSource.DataSource = this.ileapyDataSet;
            // 
            // cardsTableAdapter
            // 
            this.cardsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CardsTableAdapter = this.cardsTableAdapter;
            this.tableAdapterManager.TransactionsTableAdapter = this.transactionsTableAdapter;
            this.tableAdapterManager.UpdateOrder = ileapy.ileapyDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsersTableAdapter = this.usersTableAdapter;
            // 
            // transactionsTableAdapter
            // 
            this.transactionsTableAdapter.ClearBeforeFill = true;
            // 
            // usersTableAdapter
            // 
            this.usersTableAdapter.ClearBeforeFill = true;
            // 
            // transactionsBindingSource
            // 
            this.transactionsBindingSource.DataMember = "Transactions";
            this.transactionsBindingSource.DataSource = this.ileapyDataSet;
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "Users";
            this.usersBindingSource.DataSource = this.ileapyDataSet;
            // 
            // logout_button
            // 
            this.logout_button.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logout_button.Location = new System.Drawing.Point(16, 447);
            this.logout_button.Name = "logout_button";
            this.logout_button.Size = new System.Drawing.Size(61, 48);
            this.logout_button.TabIndex = 3;
            this.logout_button.Text = "Log out";
            this.logout_button.UseVisualStyleBackColor = true;
            this.logout_button.Click += new System.EventHandler(this.logout_button_Click);
            // 
            // username_display_label
            // 
            this.username_display_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.username_display_label.AutoSize = true;
            this.username_display_label.Font = new System.Drawing.Font("Arial", 15F);
            this.username_display_label.Location = new System.Drawing.Point(12, 9);
            this.username_display_label.Name = "username_display_label";
            this.username_display_label.Size = new System.Drawing.Size(63, 23);
            this.username_display_label.TabIndex = 4;
            this.username_display_label.Text = "User: ";
            // 
            // cardsTabControl
            // 
            this.cardsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardsTabControl.Location = new System.Drawing.Point(100, 6);
            this.cardsTabControl.Multiline = true;
            this.cardsTabControl.Name = "cardsTabControl";
            this.cardsTabControl.SelectedIndex = 0;
            this.cardsTabControl.Size = new System.Drawing.Size(547, 234);
            this.cardsTabControl.TabIndex = 5;
            // 
            // new_card_button
            // 
            this.new_card_button.Location = new System.Drawing.Point(16, 112);
            this.new_card_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.new_card_button.Name = "new_card_button";
            this.new_card_button.Size = new System.Drawing.Size(61, 37);
            this.new_card_button.TabIndex = 6;
            this.new_card_button.Text = "New Card";
            this.new_card_button.UseVisualStyleBackColor = true;
            this.new_card_button.Click += new System.EventHandler(this.new_card_button_Click);
            // 
            // new_transaction_button
            // 
            this.new_transaction_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.new_transaction_button.Location = new System.Drawing.Point(688, 103);
            this.new_transaction_button.Name = "new_transaction_button";
            this.new_transaction_button.Size = new System.Drawing.Size(100, 54);
            this.new_transaction_button.TabIndex = 7;
            this.new_transaction_button.Text = "New Transaction";
            this.new_transaction_button.UseVisualStyleBackColor = true;
            this.new_transaction_button.Click += new System.EventHandler(this.new_transaction_button_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 507);
            this.Controls.Add(this.new_transaction_button);
            this.Controls.Add(this.new_card_button);
            this.Controls.Add(this.cardsTabControl);
            this.Controls.Add(this.username_display_label);
            this.Controls.Add(this.logout_button);
            this.Name = "HomePage";
            this.Text = "Home Page";
            ((System.ComponentModel.ISupportInitialize)(this.ileapyDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ileapyDataSet ileapyDataSet;
        private System.Windows.Forms.BindingSource cardsBindingSource;
        private System.Windows.Forms.BindingSource transactionsBindingSource;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private ileapyDataSetTableAdapters.CardsTableAdapter cardsTableAdapter;
        private ileapyDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private ileapyDataSetTableAdapters.TransactionsTableAdapter transactionsTableAdapter;
        private ileapyDataSetTableAdapters.UsersTableAdapter usersTableAdapter;
        private System.Windows.Forms.Button logout_button;
        private System.Windows.Forms.Label username_display_label;
        private System.Windows.Forms.TabControl cardsTabControl;
        private System.Windows.Forms.Button new_card_button;
        private System.Windows.Forms.Button new_transaction_button;
    }
}

