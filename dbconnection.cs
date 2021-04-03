using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
namespace CsharpWithMysql
{
    public class dbconnection
    {
        public MySqlConnection Connection;

        public dbconnection()
        {
            try
            {
                Connection = new MySqlConnection("server=localhost;port=3306;User Id=root;database=testrider; password=; Convert Zero Datetime = True;");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        private bool Open()
        {
            try
            {
                Connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }
        private bool Close()
        {
            try
            {
                Connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public void Insert()
        {
            string query = "INSERT INTO `sd-login`(`username`, `password`) VALUES ('rashid','12345')";
            if (this.Open() == true)
            {
                MySqlCommand command = new MySqlCommand(query, Connection);
                command.ExecuteNonQuery();
                this.Close();
            }
        }

        public void update()
        {
            if (this.Open() == true)
            {
                string qurey = "UPDATE `sd-login` SET `username`='rashid',`password`='123' WHERE id = 1";
                MySqlCommand command = new MySqlCommand();
                command.CommandText = qurey;
                command.Connection = Connection;
                command.ExecuteNonQuery();
                this.Close();   
            }
        }

        public void delete(int id)
        {
            string query = "DELETE FROM `sd-login` WHERE id = "+id+"";
            if (this.Open() == true)
            {
                MySqlCommand command = new MySqlCommand(query, Connection);
                command.ExecuteNonQuery();
                this.Close();
            }
        }
        public int count()
        {
            string query = "SELECT COUNT(*) FROM `sd-login`";
            int Count = -1;
            if (this.Open() == true)
            {
                MySqlCommand command = new MySqlCommand(query, Connection);
                Count = int.Parse(command.ExecuteScalar() + "");
                this.Close();
                return Count; 
            }
            else
            {
                return Count; 
            }
        }
        public List< string >[] Select()
        {
            string query = "SELECT * FROM `sd-login`";

            //Create a list to store the result
            List< string >[] list = new List< string >[3];
            list[0] = new List< string >();
            list[1] = new List< string >();
            list[2] = new List< string >();
            if (this.Open() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, Connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["username"] + "");
                    list[2].Add(dataReader["password"] + "");
                }

                Console.WriteLine(list[1].Count);
                dataReader.Close();
                this.Close();
                return list;
            }
            else
            {
                return list;
            }
        }
    }
}