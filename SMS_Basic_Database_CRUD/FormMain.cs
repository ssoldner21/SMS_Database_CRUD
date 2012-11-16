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
    /// <summary>
    /// Basic database crud for a restaurant menu
    /// </summary>
    public partial class frmMain : Form
    {
        public frmMain()
        {
            try
            {
                Program.conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to database");
            }

            InitializeComponent();
        }

        ~frmMain()
        {
            //close db connection when program closes
            try
            {
                Program.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error closing database connection");
            }
        }

        public void RefreshFormData()
        {
            lstMenuItems.Items.Clear();

            try
            {
                //execute and print results from select all query
                OleDbDataReader reader = DBCommand.SelectAll();
                while (reader.Read())
                {
                    lstMenuItems.Items.Add(reader.GetInt32(0).ToString()).SubItems.Add(reader.GetString(1).ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error running SelectAll query");    
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            RefreshFormData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NewItem addNewItem = new NewItem();
            addNewItem.ShowDialog();
            RefreshFormData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshFormData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstMenuItems.SelectedItems.Count == 0)
            {
                MessageBox.Show("Unable to open Edit Menu \nNo item selected.");
            }
            else
            {
                //instantiate new edit item menu -- sending item name and primary key
                EditItem editAnItem = new EditItem(lstMenuItems.SelectedItems[0].SubItems[0].Text, lstMenuItems.SelectedItems[0].SubItems[1].Text);
                editAnItem.ShowDialog();
            }
             
            RefreshFormData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DBCommand.DelSelected(lstMenuItems.SelectedItems[0].SubItems[0].Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error running delete query");
            }

            RefreshFormData();
        }

        //Prevents resizing of columns (still hows resizing handle)
        private void lstMenuItems_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lstMenuItems.Columns[e.ColumnIndex].Width;
        }
    }
}