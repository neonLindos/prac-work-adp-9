using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac_work_adp_9.task1.HotelSystem
{
    

    public class RestaurantSystem
    {
        List<Table> tables;
        List<Room> rooms;
        List<FoodItem> foodMenu;
        public RestaurantSystem(List<Room> rooms, List<Table> tables, List<FoodItem> foodMenu)
        {
            this.tables = tables;
            this.rooms = rooms;
            this.foodMenu = foodMenu;

        }

        public bool BookTable(int tableNumber)
        {
            var table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table != null && table.IsAvailable)
            {
                table.IsAvailable = false;
                Console.WriteLine($"Table {tableNumber} booked successfully.");
                return true;
            }
            else
            {
                Console.WriteLine($"Table {tableNumber} is not available.");
                return false;
            }
        }

        public void CancelTableBooking(int tableNumber)
        {
            var table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table != null && !table.IsAvailable)
            {
                table.IsAvailable = true;
                Console.WriteLine($"Booking for table {tableNumber} canceled successfully.");
            }
            else
            {
                Console.WriteLine($"Table {tableNumber} is not currently booked.");
            }
        }

        public bool CheckTableBookingStatus(int tableNumber)
        {
            var table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table != null)
            {
                string status = table.IsAvailable ? "available" : "booked";
                Console.WriteLine($"Table {tableNumber} is currently {status}.");
                return true;
            }
            else
            {
                Console.WriteLine($"Table {tableNumber} does not exist.");
                return false;
            }
        }

        public FoodItem? OrderFoodTable(int tableNumber, string foodName)
        {
            var table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            var foodItem = foodMenu.FirstOrDefault(f =>
                f.Name.Equals(foodName, StringComparison.OrdinalIgnoreCase));

            if (foodItem == null)
            {
                Console.WriteLine($"Dish '{foodName}' not found in menu.");
                return null;
            }

            if (table != null && !table.IsAvailable)
            {
                Console.WriteLine($"Order placed: {foodItem.Name} (₸{foodItem.Price}) for table {tableNumber}.");
                return foodItem;
            }
            else
            {
                Console.WriteLine($"Cannot place order. Table {tableNumber} is either not booked or does not exist.");
                return null;
            }
        }

        public FoodItem? OrderFoodRoom(int roomNumber, string foodName)
        {
            var room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
            var foodItem = foodMenu.FirstOrDefault(f =>
                f.Name.Equals(foodName, StringComparison.OrdinalIgnoreCase));

            if (foodItem == null)
            {
                Console.WriteLine($"Dish '{foodName}' not found in menu.");
                return null;
            }

            if (room != null && !room.IsAvailable)
            {
                Console.WriteLine($"Order placed: {foodItem.Name} (₸{foodItem.Price}) for room {roomNumber}.");
                return foodItem;
            }
            else
            {
                Console.WriteLine($"Cannot place order. Room {roomNumber} is either not booked or does not exist.");
                return null;
            }
        }

        public void ShowMenu()
        {
            Console.WriteLine("\n=== Restaurant Menu ===");
            foreach (var item in foodMenu)
            {
                Console.WriteLine($"{item.Name} — ₸{item.Price}");
            }
            Console.WriteLine("=======================\n");
        }



    }
}
