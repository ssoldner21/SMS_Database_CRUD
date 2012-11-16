using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace SMS_Basic_Database_CRUD
{
    public partial class EditItem : Form
    {
        /// <summary>
        /// Used to catch primary key from FormMain and access it when executing Update query
        /// </summary>
        private string PrimaryKey;

        public EditItem(String PrimKey, String itemName)
        {
            InitializeComponent();
            textBox1.Text = itemName;
            this.PrimaryKey = PrimKey;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        { 
            // Validation - Blank String
            if (textBox1.Text.ToString() == "")
            {
                MessageBox.Show("You're trying to enter a blank item.");
            }
            else
            {
                try
                {
                    DBCommand.UpdateSelected(textBox1.Text.ToString(), this.PrimaryKey);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error running update query");
                }
            }

            this.Close();
            
        }
    }
}
