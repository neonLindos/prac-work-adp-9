using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac_work_adp_9.task1.HotelSystem
{
    

    public class RoomBookingSystem
    {
        private List<Room> rooms;
        public RoomBookingSystem(List<Room> rooms)
        {
            this.rooms = rooms;
        }

      

        public bool BookRoom(int roomNumber)
        {
            var room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
            if (room != null && room.IsAvailable)
            {
                room.IsAvailable = false;
                Console.WriteLine($"Room {roomNumber} booked successfully.");
                return true;
            }
            else
            {
                Console.WriteLine($"Room {roomNumber} is not available.");
                return false;
            }
        }
        public void CancelBooking(int roomNumber)
        {
            var room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
            if (room != null && !room.IsAvailable)
            {
                room.IsAvailable = true;
                Console.WriteLine($"Booking for room {roomNumber} canceled successfully.");
            }
            else
            {
                Console.WriteLine($"Room {roomNumber} is not currently booked.");
            }
        }

        public bool RoomCheckBookingStatus(int roomNumber)
        {
            var room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
            if (room != null)
            {
                string status = room.IsAvailable ? "available" : "booked";
                Console.WriteLine($"Room {roomNumber} is currently {status}.");
                return true;
            }
            else
            {
                return false;
                Console.WriteLine($"Room {roomNumber} does not exist.");
            }
        }

    }
}
