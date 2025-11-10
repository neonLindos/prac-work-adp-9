using System;
using System.Collections.Generic;
using System.Linq;

namespace prac_work_adp_9.task1.HotelSystem
{
    

    public class CleaningService
    {
        private List<Room> availableRooms;
        private List<CleaningTask> cleaningQueue;

        public CleaningService(List<Room> rooms)
        {
            this.availableRooms = rooms;
            this.cleaningQueue = new List<CleaningTask>();
        }

        public void ScheduleCleaning(int roomNumber, DateTime scheduledTime)
        {
            var room = availableRooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
            if (room == null)
            {
                Console.WriteLine($"Room {roomNumber} does not exist.");
                return;
            }

            cleaningQueue.Add(new CleaningTask
            {
                RoomNumber = roomNumber,
                ScheduledTime = scheduledTime,
                IsCompleted = false
            });

            Console.WriteLine($"Cleaning for room {roomNumber} scheduled at {scheduledTime}.");
        }

        public void CompleteCleaning(int roomNumber)
        {
            var task = cleaningQueue.FirstOrDefault(t => t.RoomNumber == roomNumber && !t.IsCompleted);
            if (task != null)
            {
                task.IsCompleted = true;
                Console.WriteLine($"Cleaning for room {roomNumber} completed.");
            }
            else
            {
                Console.WriteLine($"No pending cleaning task found for room {roomNumber}.");
            }
        }

        public void ShowCleaningSchedule()
        {
            Console.WriteLine("\n=== Cleaning Schedule ===");
            foreach (var task in cleaningQueue.OrderBy(t => t.ScheduledTime))
            {
                string status = task.IsCompleted ? "Completed" : "Pending";
                Console.WriteLine($"Room {task.RoomNumber} — {status} — Scheduled at {task.ScheduledTime}");
            }
            Console.WriteLine("=========================\n");
        }
    }
}
