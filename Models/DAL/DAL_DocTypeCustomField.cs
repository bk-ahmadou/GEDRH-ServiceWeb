﻿using DSSGEDAdmin.Models.Entities;
using DSSGEDAdmin.Utilities.DataAccess;
using DSSGEDAdmin.Utilities.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DSSGEDAdmin.Models.DAL
{
    public class DAL_DocTypeCustomField
    {
        // Add DocTypeCustomField
        public static void Add(DocTypeCustomField docTypeCustomField)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string StrSQL = "INSERT INTO DocTypeCustomField (DocType, Cle,Valeur,TypeValeur,AccetpNull) VALUES(@DocType, @Cle,@Valeur,@TypeValeur,@AccetpNull)";
                SqlCommand cmd = new SqlCommand(StrSQL, con);
                cmd.Parameters.AddWithValue("@DocType", docTypeCustomField.DocTypeId );
                cmd.Parameters.AddWithValue("@Cle", docTypeCustomField.Key ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Valeur", docTypeCustomField.Value);
                cmd.Parameters.AddWithValue("@TypeValeur", docTypeCustomField.TypeValue ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@AccetpNull", docTypeCustomField.AcceptNull);
                DataBaseAccessUtilities.NonQueryRequest(cmd);
            }
        }
        // Update DocTypeCustomField
        public static void Update(int id, DocTypeCustomField docTypeCustomField)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string StrSQL = "UPDATE DocTypeCustomField SET DocType=@DocType, Cle=@Cle,Valeur=@Valeur,TypeValeur=@TypeValeur,AccetpNull=@AccetpNull WHERE Id = @CurId";
                SqlCommand cmd = new SqlCommand(StrSQL, con);
                cmd.Parameters.AddWithValue("@CurId", id);
                cmd.Parameters.AddWithValue("@DocType", docTypeCustomField.DocTypeId);
                cmd.Parameters.AddWithValue("@Cle", docTypeCustomField.Key ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Valeur", docTypeCustomField.Value);
                cmd.Parameters.AddWithValue("@TypeValeur", docTypeCustomField.TypeValue ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@AccetpNull", docTypeCustomField.AcceptNull);
                DataBaseAccessUtilities.NonQueryRequest(cmd);
            }
        }
        // Delete DocTypeCustomField
        public static void Delete(int id)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string StrSQL = "DELETE FROM DocTypeCustomField WHERE Id=" + id;
                SqlCommand command = new SqlCommand(StrSQL, con);
                DataBaseAccessUtilities.NonQueryRequest(command);
            }
        }

        public static void DeleteByDType(int id)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string StrSQL = "DELETE FROM DocTypeCustomField WHERE DocType=" + id;
                SqlCommand command = new SqlCommand(StrSQL, con);
                DataBaseAccessUtilities.NonQueryRequest(command);
            }
        }
        //select one record of table DocTypeCustomField
        public static DocTypeCustomField SelectById(int id)
        {
            DocTypeCustomField docTypeCustomField = new DocTypeCustomField();

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string StrSQL = "SELECT * FROM DocTypeCustomField WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(StrSQL, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        docTypeCustomField.Id = Convert.ToInt32(dataReader["Id"]);
                        docTypeCustomField.DocTypeId = Convert.ToInt32(dataReader["DocType"]);
                        docTypeCustomField.Key = dataReader["Cle"].ToString();
                        docTypeCustomField.Value = dataReader["Valeur"].ToString();
                        docTypeCustomField.TypeValue = dataReader["TypeValeur"].ToString();
                        docTypeCustomField.AcceptNull = dataReader["AccetpNull"].ToString();
                    }
                }
                catch (SqlException e)
                {
                    throw new MyException(e, "Database Error", e.Message, "DAL");
                }
                finally
                {
                    connection.Close();
                }
            }
            return docTypeCustomField;
        }

        public static List<DocTypeCustomField> SelectByDocTypeId(int id)
        {
            List<DocTypeCustomField> liste = new List<DocTypeCustomField>();

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string StrSQL = "SELECT * FROM DocTypeCustomField WHERE DocType = @Id";
                    SqlCommand command = new SqlCommand(StrSQL, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        DocTypeCustomField docTypeCustomField = new DocTypeCustomField();
                        docTypeCustomField.Id = Convert.ToInt32(dataReader["Id"]);
                        docTypeCustomField.DocTypeId = Convert.ToInt32(dataReader["DocType"]);
                        docTypeCustomField.Key = dataReader["Cle"].ToString();
                        docTypeCustomField.Value =dataReader["Valeur"].ToString();
                        docTypeCustomField.TypeValue = dataReader["TypeValeur"].ToString();
                        docTypeCustomField.AcceptNull =dataReader["AccetpNull"].ToString();
                        liste.Add(docTypeCustomField);
                    }
                }
                catch (SqlException e)
                {
                    throw new MyException(e, "Database Error", e.Message, "DAL");
                }
                finally
                {
                    connection.Close();
                }
            }
            return liste;
        }
        //// select all record of table DocTypeCustomField
        //public static List<DocTypeCustomField> SelectAll(string DBName)
        //{
        //    List<DocTypeCustomField> lstDocTypeCustomField = new List<DocTypeCustomField>();
        //    DocTypeCustomField docTypeCustomField;
        //    using (SqlConnection connection = DBConnection.GetConnection(DBName))
        //    {
        //        try
        //        {
        //            connection.Open();
        //            string StrSQL = "SELECT * FROM DocTypeCustomField";
        //            SqlCommand command = new SqlCommand(StrSQL, connection);
        //            SqlDataReader dataReader = command.ExecuteReader();
        //            while (dataReader.Read())
        //            {
        //                docTypeCustomField = new DocTypeCustomField();
        //                docTypeCustomField.Id = Convert.ToInt32(dataReader["Id"]);
        //                docTypeCustomField.Name = dataReader["Name"].ToString();
        //                docTypeCustomField.Type = dataReader["Type"].ToString();
        //                docTypeCustomField.AcceptNull = Convert.ToBoolean(dataReader["AcceptNull"].ToString());
        //                docTypeCustomField.DefaultValue = dataReader["DefaultValue"].ToString();
        //                docTypeCustomField.IdDocumentType = Convert.ToInt32(dataReader["IdDocumentType"]);
        //                docTypeCustomField.ValueList = dataReader["ValueList"].ToString();
        //                lstDocTypeCustomField.Add(docTypeCustomField);
        //            }
        //        }
        //        catch (SqlException e)
        //        {
        //            throw new MyException(e, "Erreur de la base de données", e.Message, "DAL");
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //    return lstDocTypeCustomField;
        //}
    }
}
