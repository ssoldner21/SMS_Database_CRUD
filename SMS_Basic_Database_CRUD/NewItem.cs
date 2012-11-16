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
    public partial class NewItem : Form
    {
        public NewItem()
        {
            InitializeComponent();
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
                    DBCommand.AddNew(textBox1.Text.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error executing add query");
                }
                this.Close();
            }
        }
    }
}
