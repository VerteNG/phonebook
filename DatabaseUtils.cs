using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace Projekt_Lukasz_Motak
{
    public class DatabaseUtils : IDisposable
    {
        private SqlConnection sqlConnection;

        public DatabaseUtils()
        {
            sqlConnection = new SqlConnection(GetConnectionString());
            sqlConnection.Open();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing == true)
            {
                sqlConnection.Close();
            }
        }

        ~DatabaseUtils()
        {
            Dispose(false);
        }

        public void AddContact(Contact contact)
        {
            string sqlAdd = "INSERT INTO ContactsTable ([FirstName], [LastName], [PhoneNumber], [Email], [Birthday]) VALUES('" +
                contact.FirstName   + "','" + 
                contact.LastName    + "','" + 
                contact.PhoneNumber + "','" + 
                contact.Email       + "','" + 
                contact.Birthday    + "')";
            executeSQL(sqlAdd);
        }

        public void UpdateContact(Contact contact)
        {
            if (contact.Id == 0) throw new Exception("id is 0");
            string sqlAdd = "UPDATE ContactsTable SET " +
                "FirstName = '"     + contact.FirstName     + "', " +
                "LastName = '"      + contact.LastName      + "', " +
                "PhoneNumber = '"   + contact.PhoneNumber   + "', " +
                "Email = '"         + contact.Email         + "', " +
                "Birthday = '"      + contact.Birthday      + "' WHERE Id = " + contact.Id;
            executeSQL(sqlAdd);
        }

        public List<Contact> GetContactsList()
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM [ContactsTable]", sqlConnection);
            adapter.Fill(table);
            return table.AsEnumerable().Select(row =>
             new Contact
             {
                 Id          = row.Field<int>("Id"),
                 FirstName   = row.Field<string>("FirstName"),
                 LastName    = row.Field<string>("LastName"),
                 PhoneNumber = row.Field<string>("PhoneNumber"),
                 Email       = row.Field<string>("Email"),
                 Birthday    = row.Field<string>("Birthday"),
             }).ToList();
        }

        public void DeleteContact(int id)
        {
            if (id == 0) throw new Exception("id is 0");
            string sqlDelte = "DELETE FROM [ContactsTable] WHERE Id = " + id;
            executeSQL(sqlDelte);
        }

        private void executeSQL(string sqlQuery)
        {
            SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
            command.ExecuteNonQuery();
        }

        private string GetConnectionString()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + 
                Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName.ToString() + 
                "\\ContactsDatabase.mdf;Integrated Security=True";
            return connectionString;
        }
    }
}