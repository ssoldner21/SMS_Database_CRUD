using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace SMS_Basic_Database_CRUD
{
    public class DBCommand
    {
        private static OleDbDataReader dbReader;
        private static OleDbCommand cmdSelectAll;
        private static OleDbCommand cmdDeleteSelected;
        private static OleDbCommand cmdAddNew;
        private static OleDbCommand cmdUpdateSelected;

        public static void UpdateSelected(string itemName, string primaryKey)
        {
            cmdUpdateSelected = new OleDbCommand("UPDATE menuItem SET itemName='" + itemName + "' WHERE id=" + primaryKey + ";", Program.conn);
            cmdUpdateSelected.ExecuteNonQuery();
        }

        public static void AddNew(string itemName)
        {
            cmdAddNew = new OleDbCommand("INSERT INTO menuItem (itemName) VALUES ('" + itemName + "');", Program.conn);
            cmdAddNew.ExecuteNonQuery();
        }

        public static void DelSelected(string primaryKey)
        {
            cmdDeleteSelected = new OleDbCommand("DELETE FROM menuItem WHERE id=" + primaryKey + ";", Program.conn);
            cmdDeleteSelected.ExecuteNonQuery();
        }

        public static OleDbDataReader SelectAll()
        {
            cmdSelectAll = new OleDbCommand("SELECT id, itemName FROM menuItem;", Program.conn);
            dbReader = cmdSelectAll.ExecuteReader();
            return dbReader; 
        }
    }
}
