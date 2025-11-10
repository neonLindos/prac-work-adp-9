using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac_work_adp_9.task1
{
    public class CleaningTask
    {
        public int RoomNumber { get; set; }
        public DateTime ScheduledTime { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class Table()
    {
        public int TableNumber { get; set; }
        public int Seats { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class EventRoom
    {
        public int RoomNumber { get; set; }
        public int Capacity { get; set; }
        public bool IsOrdered { get; set; }
    }

    public class Room
    {
        public int RoomNumber { get; set; }
        public string Type { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class CleaningRoomTask
    {
        public int RoomNumber { get; set; }
        public DateTime ScheduledTime { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class FoodItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

}
