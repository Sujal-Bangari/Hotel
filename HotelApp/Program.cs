using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelLibrary;
namespace HotelApp
{
    public class Hotel
    {
        private DatabaseHelper db = new DatabaseHelper();
        public void AddGuest(string name,string contact)
        {
            string query = $"INSERT INTO Guests(Name,Contact)VALUES('{name}','{contact}')";
            db.ExecuteQuery(query);
        }
        public void BookRoom(int guestOd, int roomId, string checkInDate, string checkOutDate)
        {
            string query = $"INSERT INTO Bookings(GuestId,RoomID,ChecKInDate,CheckOutDate)VALUES({guestOd},{roomId},'{checkInDate}','{checkOutDate}')";
            db.ExecuteQuery(query);
        }
        public void ShowGuests()
        {
            DataTable dt = db.GetData("SELECT * FROM Guests");
            foreach(DataRow row in dt.Rows)
            {
                Console.WriteLine($"Guest ID:{row["GuestId"]}, Name:{row["Name"]}, contact: {row["Contact"]}");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Hotel h = new Hotel();
            h.AddGuest("John Doe", "1345678");
            h.BookRoom(1, 101, "2025-03-10", "2025-03-15");
            h.ShowGuests();
        }
    }
}
