using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlServerCe;
using Automation.Common.Utils;
using System.Windows.Forms;

namespace Automation.Backend{
    public class Folder_Names {


        public static DataSet GetAllFolderNamesAsDataset() {
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            DataSet dataSet = new DataSet();
            try {
                SqlCeDataAdapter da = new SqlCeDataAdapter(Folder_Names_SQL.commandGetAllFolderNamesTable, conn);
                SqlCeCommandBuilder cb = new SqlCeCommandBuilder(da);
                da.Fill(dataSet);
            } finally {
                conn.Close();
            }
            return dataSet;
        }

        public static void DeleteAllFileNames(SqlCeTransaction transaction, SqlCeConnection conn) {
            SqlCeCommand command = new SqlCeCommand(Folder_Names_SQL.commandDeleteAllFolderNames, conn);
            command.Transaction = transaction;
            command.Connection = conn;
            command.ExecuteNonQuery();
        }

        public static void InsertFolderName(int index, string folderName, object parentId, string generatedID, SqlCeTransaction transaction, SqlCeConnection conn) {
            try {
                SqlCeCommand command = new SqlCeCommand(Folder_Names_SQL.commandInsertFolderName, conn);
                command.Parameters.Add("@id", index);
                command.Parameters.Add("@folderName", folderName);
                command.Parameters.Add("@parentId", parentId);
                command.Parameters.Add("@generatedID", generatedID);
                command.Transaction = transaction;
                command.Connection = conn;
                command.ExecuteNonQuery();
            } catch (Exception ex) {
                FrontendUtils.LogError(ex.Message, ex);
            }
        }

        public static void InsertUpdatedFileNames(List<TreeNode> treeNodes, SqlCeTransaction transaction, SqlCeConnection conn) {
            try {
                for (int i = 0; i < treeNodes.Count; i++) {
                    int parentId = treeNodes[i].Parent == null ? -1 : treeNodes.IndexOf(treeNodes[i].Parent);
                    if (parentId != -1) {
                        InsertFolderName(i, treeNodes[i].Text, parentId, treeNodes[i].Tag.ToString(), transaction, conn);
                    } else {
                        InsertFolderName(i, treeNodes[i].Text, DBNull.Value, treeNodes[i].Tag.ToString(), transaction, conn);
                    }
                }
            } catch (Exception ex) {
                FrontendUtils.LogError(ex.Message,ex);
            }
        }

        public static void UpdateTreeNodesTransaction(List<TreeNode> treeNodes) {
            SqlCeTransaction transaction;
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            try {
                conn.Open();
                transaction = conn.BeginTransaction();
                try {
                    DeleteAllFileNames(transaction, conn);
                    InsertUpdatedFileNames(treeNodes, transaction, conn);
                    transaction.Commit();
                } catch (Exception ex) {
                    FrontendUtils.LogError(ex.Message, ex);
                    transaction.Rollback();
                }
            } finally {
                conn.Close();
            }
        }
        
       

      

    }
}
