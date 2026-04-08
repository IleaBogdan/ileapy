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
            this.Convert_Button = new System.Windows.Forms.Button();
            this.balance_label = new System.Windows.Forms.Label();
            this.Currency_ComboBox = new System.Windows.Forms.ComboBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.ileapyDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Convert_Button
            // 
            this.Convert_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Convert_Button.Location = new System.Drawing.Point(352, 137);
            this.Convert_Button.Name = "Convert_Button";
            this.Convert_Button.Size = new System.Drawing.Size(62, 84);
            this.Convert_Button.TabIndex = 0;
            this.Convert_Button.Text = "Convert";
            this.Convert_Button.UseVisualStyleBackColor = true;
            this.Convert_Button.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // balance_label
            // 
            this.balance_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.balance_label.AutoSize = true;
            this.balance_label.Font = new System.Drawing.Font("Arial", 34F);
            this.balance_label.Location = new System.Drawing.Point(315, 54);
            this.balance_label.Name = "balance_label";
            this.balance_label.Size = new System.Drawing.Size(146, 52);
            this.balance_label.TabIndex = 1;
            this.balance_label.Text = "label1";
            this.balance_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Currency_ComboBox
            // 
            this.Currency_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Currency_ComboBox.FormattingEnabled = true;
            this.Currency_ComboBox.Location = new System.Drawing.Point(324, 110);
            this.Currency_ComboBox.Name = "Currency_ComboBox";
            this.Currency_ComboBox.Size = new System.Drawing.Size(121, 21);
            this.Currency_ComboBox.TabIndex = 2;
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
            this.logout_button.Location = new System.Drawing.Point(28, 411);
            this.logout_button.Name = "logout_button";
            this.logout_button.Size = new System.Drawing.Size(65, 48);
            this.logout_button.TabIndex = 3;
            this.logout_button.Text = "Log out";
            this.logout_button.UseVisualStyleBackColor = true;
            this.logout_button.Click += new System.EventHandler(this.logout_button_Click);
            // 
            // username_display_label
            // 
            this.username_display_label.AutoSize = true;
            this.username_display_label.Font = new System.Drawing.Font("Arial", 15F);
            this.username_display_label.Location = new System.Drawing.Point(12, 9);
            this.username_display_label.Name = "username_display_label";
            this.username_display_label.Size = new System.Drawing.Size(63, 23);
            this.username_display_label.TabIndex = 4;
            this.username_display_label.Text = "User: ";
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 507);
            this.Controls.Add(this.username_display_label);
            this.Controls.Add(this.logout_button);
            this.Controls.Add(this.Currency_ComboBox);
            this.Controls.Add(this.balance_label);
            this.Controls.Add(this.Convert_Button);
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

        private System.Windows.Forms.Button Convert_Button;
        private System.Windows.Forms.Label balance_label;
        private System.Windows.Forms.ComboBox Currency_ComboBox;
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
    }
}

