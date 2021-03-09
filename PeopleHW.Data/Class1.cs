using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PeopleHW.Data
{
  
public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
 public class PeopleDB
    {
        private readonly string _connectionString;
        public PeopleDB(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select * from Borrower";
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                people.Add(new Person
                {
                    Id = (int)reader["Id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]

                });
            }

            return people;

        }
        public void AddPerson(Person person)
        {
          
            
                using SqlConnection connection = new SqlConnection(_connectionString);
                using SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "insert into Borrower (FirstName, LastName, Age) VALUES (@FirstName, @LastName, @Age)";
                cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
                cmd.Parameters.AddWithValue("@LastName", person.LastName);
                cmd.Parameters.AddWithValue("@Age", person.Age);
                connection.Open();
                cmd.ExecuteNonQuery();
            
            
        }
    }
}
   
