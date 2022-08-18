using DBDemo1.Entities;
using System.Data.SqlClient;

namespace DBDemo1.Data
{
    public class ContactRepository : IContactsRepository
    {
        public void Delete(int id)
        {
            // Open DB Connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ContactsDb2022;Integrated Security=True;Pooling=False";
            conn.Open();

            // prepare sql delete stmt

            string sqlDelete = $"delete from contacts where contactid = {id}";

            // send sql cmd to db

            SqlCommand cmd = new SqlCommand(sqlDelete, conn);
            cmd.ExecuteNonQuery();

            // close the conn
            conn.Close();
        }

        public List<Contact> GetAllContacts()
        {
            // Open DB Connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ContactsDb2022;Integrated Security=True;Pooling=False";
            conn.Open();

            // prepare the sql select stmt

            string sqlSelect = $"select * from contacts";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);

            // execute the statement

            SqlDataReader reader = cmd.ExecuteReader();

            List<Contact> contacts = new List<Contact>();

            while (reader.Read())
            {

                // process the returned data

                Contact c = new Contact();
                c.ContactID = (int)(reader[0]);
                c.Name = reader[1].ToString();
                c.Mobile = reader[2].ToString();
                c.Email = reader[3].ToString();
                c.Location = reader[4].ToString();
                contacts.Add(c);
            }
            conn.Close();
            return contacts;
        }

        public Contact GetContact(int id)
        {
            // Open DB Connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ContactsDb2022;Integrated Security=True;Pooling=False";
            conn.Open();

            // prepare the sql select stmt

            string sqlSelect = $"select * from contacts where contactid = {id}";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);

            // execute the statement

            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            // process the returned data

            Contact c = new Contact();
            c.ContactID = (int)(reader[0]);
            c.Name = reader[1].ToString();
            c.Mobile = reader[2].ToString();
            c.Email = reader[3].ToString();
            c.Location = reader[4].ToString();

            conn.Close();
            return c;




        }

        public Contact GetContactByName(string nameToSearch)
        {
            throw new NotImplementedException();
        }

        public int GetContactCount()
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetContactsByLocation(string location)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ContactsDb2022;Integrated Security=True;Pooling=False";
            conn.Open();

            string sqlSelectbyloc = $"select * from contacts WHERE Location='{location}'";
            SqlCommand cmd = new SqlCommand(sqlSelectbyloc, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Contact> contacts = new List<Contact>();
            while (reader.Read())
            {
                Contact c = new Contact();
                c.ContactID = (int)(reader[0]);
                c.Name = reader[1].ToString();
                c.Mobile = reader[2].ToString();
                c.Email = reader[3].ToString();
                c.Location = reader[4].ToString();
                contacts.Add(c);
            }

            conn.Close();
            return contacts;




            // execute the statement

            
        }

        public void Save(Contact contactToSave)
        {
            // Open DB Connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ContactsDb2022;Integrated Security=True;Pooling=False";
            conn.Open();

            // prepare the sql insert statement

            string sqlInsert = $"insert into contacts values('{contactToSave.Name}','{contactToSave.Mobile}','{contactToSave.Email}','{contactToSave.Location}')";

            // send the sql command to db

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sqlInsert;
            cmd.ExecuteNonQuery();

            // close the db connection
            conn.Close();
        }

        public void Update(Contact contactToUpdate,int id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ContactsDb2022;Integrated Security=True;Pooling=False";
            conn.Open();

            string sqlUpdate = $"UPDATE contacts SET Name='{contactToUpdate.Name}',Mobile='{contactToUpdate.Mobile}',Email='{contactToUpdate.Email}',Location='{contactToUpdate.Location}' WHERE ContactID={id}";



            SqlCommand cmd= new SqlCommand(sqlUpdate,conn);
   
            //cmd.CommandText= sqlUpdate;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}
