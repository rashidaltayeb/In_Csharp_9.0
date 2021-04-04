# in_Csharp_9.0  

.Net 5 is paired with C# 9.0, which brings many new features to the language. The new language features include : \
1- top-level statements\
2- records\
3- init-only setters

## top-level statements 

With top-level statements, you can replace the main method with the using statement and the single line that does the work to output the result.
```
System.Console.WriteLine("I'm Running Without Main Method");
```

here is result 
![Rashid](https://github.com/rashidaltayeb/New_in_Csharp_9.0/blob/main/screen%20Shoot/top.png) 
 
## records

Record types make it easy to create immutable reference types in .NET.
![Rashid](https://github.com/rashidaltayeb/New_in_Csharp_9.0/blob/main/screen%20Shoot/rec.png)


## Init only setters

is provide consistent syntax to initialize members of an object. Property initializers make it clear which value is setting which property. The downside is that those properties must be settable. Starting with C# 9.0, you can create init accessors instead of set accessors for properties and indexers. Callers can use property initializer syntax to set these values in creation expressions, but those properties are readonly once construction has completed.

![Rashid](https://github.com/rashidaltayeb/New_in_Csharp_9.0/blob/main/screen%20Shoot/in3.png)

you can test the **c# 9.0** with **mysql** database : 
```
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
                Connection = new MySqlConnection("server=localhost;port=3306;User Id=root;database=dbtest; password=; Convert Zero Datetime = True;");
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
```
