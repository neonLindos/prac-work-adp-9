using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac_work_adp_9.task1.HotelSystem
{
    
    public class EventManagementSystem
    {
        private List<EventRoom> eventRooms;

        public EventManagementSystem(List<EventRoom> eventRooms)
        {
            this.eventRooms = eventRooms;
        }


        public void OrderEventRoom(int roomNumber)
        {
            var eventRoom = eventRooms.FirstOrDefault(er => er.RoomNumber == roomNumber);
            if (eventRoom != null && !eventRoom.IsOrdered)
            {
                eventRoom.IsOrdered = true;
                Console.WriteLine($"Event Room {roomNumber} ordered successfully.");
            }
            else
            {
                Console.WriteLine($"Event Room {roomNumber} is not available for order.");
            }
        }

        public void CancelEventRoomOrder(int roomNumber)
        {
            var eventRoom = eventRooms.FirstOrDefault(er => er.RoomNumber == roomNumber);
            if (eventRoom != null && eventRoom.IsOrdered)
            {
                eventRoom.IsOrdered = false;
                Console.WriteLine($"Order for Event Room {roomNumber} canceled successfully.");
            }
            else
            {
                Console.WriteLine($"Event Room {roomNumber} is not currently ordered.");
            }
        }

        public bool CheckEventRoomOrderStatus(int roomNumber)
        {
            var eventRoom = eventRooms.FirstOrDefault(er => er.RoomNumber == roomNumber);
            if (eventRoom != null)
            {
                string status = eventRoom.IsOrdered ? "ordered" : "available";
                Console.WriteLine($"Event Room {roomNumber} is currently {status}.");
                return true;
            }
            else
            {
                Console.WriteLine($"Event Room {roomNumber} does not exist.");
                return false;
            }
        }
    }
}
