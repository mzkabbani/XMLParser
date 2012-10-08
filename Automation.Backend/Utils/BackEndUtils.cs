using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Windows.Forms;
using Automation.Common.Utils;
using Automation.Common;


namespace Automation.Backend {
    public class BackEndUtils {

        public static string ConnectionParamter = string.Empty;

        public static string ConnectionParamterPrimary = string.Empty;

     

        public static SqlCeConnection GetSqlConnection() {
            SqlCeConnection sqlConnection1 = new SqlCeConnection();
            //sqlConnection1.ConnectionString = @"Data Source=C:\Documents and Settings\mkabbani\My Documents\Visual Studio 2008\Projects\RFT-Replaces\XmlParsersAndUi\Database.sdf";

            #region May use this for parallel databases running at same time
            //try {
            //    sqlConnection1.ConnectionString = "Data Source=" + ConnectionParamterPrimary;
            //    try {
            //        sqlConnection1.Open();
            //    } finally {
            //        sqlConnection1.Close();
            //    }
            //} catch (Exception ex) {
            //    sqlConnection1.ConnectionString = "Data Source=" + ConnectionParamter;                
            //} 
            #endregion

            sqlConnection1.ConnectionString = "Data Source=" + ConnectionParamter;
            return sqlConnection1;
        }

        public static int GetMaxId(string TableName, SqlCeConnection conn) {
            int maxId = -1;
            SqlCeCommand command = new SqlCeCommand("Select MAX(id) From " + TableName, conn);
            maxId = Convert.ToInt32(command.ExecuteScalar());
            return maxId;
        }

        public static int ExecuteRandomQuery(string query) {
            SqlCeConnection conn = GetSqlConnection();
            int value = 0;
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(query, conn);
                value = command.ExecuteNonQuery();
            } finally {
                conn.Close();
            }
            return value;
        }

        public static string GetUsedAttributesValues(List<CustomizedAttribute> list) {
            string usedAttributesValues = string.Empty;
            for (int i = 0; i < list.Count; i++) {
                if (list[i].isUsed) {
                    if (list[i].attribute == null) {
                        usedAttributesValues = usedAttributesValues + (string.IsNullOrEmpty(usedAttributesValues) ? "" : ",") + list[i].attrValue;
                    } else {
                        usedAttributesValues = usedAttributesValues + (string.IsNullOrEmpty(usedAttributesValues) ? "" : ",") + list[i].attribute.Value;
                    }
                }
            }
            return usedAttributesValues;
        }

        public static string GetUsedAttributes(List<CustomizedAttribute> list) {
            string usedAttributes = string.Empty;
            for (int i = 0; i < list.Count; i++) {
                if (list[i].isUsed) {
                    if (list[i].attribute == null) {
                        usedAttributes = usedAttributes + (string.IsNullOrEmpty(usedAttributes) ? "" : ",") + list[i].attrName;
                    } else {
                        usedAttributes = usedAttributes + (string.IsNullOrEmpty(usedAttributes) ? "" : ",") + list[i].attribute.Name;
                    }
                }
            }
            return usedAttributes;
        }

        public static object GetAllTableRowsAsDataTable(string tableName) {
            SqlCeConnection conn = GetSqlConnection();
            DataTable dataTable = new DataTable();
            try {
                conn.Open();
                using (SqlCeDataAdapter adapter = new SqlCeDataAdapter("SELECT * FROM " + tableName, conn)) {
                    // 3
                    // Use DataAdapter to fill DataTable
                    adapter.Fill(dataTable);
                    // 4
                    // Render data onto the screen
                    // dataGridView1.DataSource = t; // <-- From your designer
                }
            } finally {
                conn.Close();
            }
            return dataTable;
        }

        public static List<CustomTreeNode> GetCustomCapturePointListFromTable(DataTable capturePointsTable) {
            List<CustomTreeNode> capturePointList = new List<CustomTreeNode>();
            for (int i = 0; i < capturePointsTable.Rows.Count; i++) {
                object obj = new object();
                XmlAttributeCollection attrCol = null;
                CustomTreeNode treeNode = new CustomTreeNode(capturePointsTable.Rows[i].ItemArray[0].ToString(), attrCol);
                treeNode.nodeLevel = Convert.ToInt32(capturePointsTable.Rows[i].ItemArray[4]);
                treeNode.nodeIndex = Convert.ToInt32(capturePointsTable.Rows[i].ItemArray[5]);
                treeNode.parentLevel = Convert.ToInt32(capturePointsTable.Rows[i].ItemArray[6]);
                treeNode.parentIndex = Convert.ToInt32(capturePointsTable.Rows[i].ItemArray[7]);
                treeNode.isNodeUsed = true;
                string[] usedAttributeNames = capturePointsTable.Rows[i].ItemArray[1].ToString().Split(',');
                string parentNode = capturePointsTable.Rows[i].ItemArray[2].ToString();
                string[] usedAttributeValues = capturePointsTable.Rows[i].ItemArray[3].ToString().Split(',');
                treeNode.parentNodeText = parentNode;
                treeNode.customizedAttributeCollection = new List<CustomizedAttribute>();
                for (int j = 0; j < usedAttributeNames.Length; j++) {
                    treeNode.customizedAttributeCollection.Add(new CustomizedAttribute(usedAttributeNames[j], usedAttributeValues[j], true));
                }
                capturePointList.Add(treeNode);
            }
            return capturePointList;
        }

        public static DataSet GetAllTableNamesAsDataSet() {
            //select table_name from information_schema.tables where TABLE_TYPE <> 'VIEW'
            SqlCeConnection conn = GetSqlConnection();
            SqlCeCommand Command = new SqlCeCommand("select table_name from information_schema.tables where TABLE_TYPE <> 'VIEW'", conn);
            DataSet dataSet = new DataSet();
            try {
                SqlCeDataAdapter da = new SqlCeDataAdapter(Command);
                SqlCeCommandBuilder cb = new SqlCeCommandBuilder(da);
                da.Fill(dataSet);
            } finally {
                conn.Close();
            }
            return dataSet;
        }

    }

}