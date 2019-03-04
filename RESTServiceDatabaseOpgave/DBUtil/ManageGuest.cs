using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HotelModels;

namespace RESTServiceDatabaseOpgave.DBUtil
{
    public class ManageGuest : IManageGuest
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=jyrland;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Guest> GetAllGuest()
        {
            List<Guest> GuestList = new List<Guest>();
            string queryString = "SELECT * FROM DemoGuest";
           

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                //command.ExecuteNonQuery();   //alternativt command.ExecuteReader   //ved SELECT
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Guest guest = new Guest();
                        guest.GuestNr = reader.GetInt32(0);
                        guest.Name = reader.GetString(1);
                        guest.Adress = reader.GetString(2);
                        GuestList.Add(guest);
                    }
                }
                finally
                {
                    reader.Close();
                }
                
            }

            return GuestList;
        }

        public Guest GetGuestFromId(int guestNr)
        {
            string queryString = "SELECT * FROM DemoGuest WHERE Guest_No = " + guestNr;

            Guest guest = new Guest();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                //command.ExecuteNonQuery();   //alternativt command.ExecuteReader   //ved SELECT
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        guest.GuestNr = reader.GetInt32(0);
                        guest.Name = reader.GetString(1);
                        guest.Adress = reader.GetString(2);
                    }
                }
                finally
                {
                    reader.Close();
                }

            }

            return guest;
        }

        public bool CreateGuest(Guest guest)
        {
            string queryString = "INSERT INTO DemoGuest VALUES (" + ;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                //command.ExecuteNonQuery();   //alternativt command.ExecuteReader   //ved SELECT
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        guest.GuestNr = reader.GetInt32(0);
                        guest.Name = reader.GetString(1);
                        guest.Adress = reader.GetString(2);
                    }
                }
                finally
                {
                    reader.Close();
                }

            }

            return true;
        }

        public bool UpdateGuest(Guest guest, int guestNr)
        {
            throw new NotImplementedException();
        }

        public Guest DeleteGuest(int guestNr)
        {
            throw new NotImplementedException();
        }
    }
}