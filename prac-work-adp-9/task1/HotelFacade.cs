using prac_work_adp_9.task1.HotelSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac_work_adp_9.task1
{
    public class HotelFacade
    {
        private CleaningService cleaningService;
        private RoomBookingSystem roomBookingSystem;
        private RestaurantSystem restaurantSystem;
        private EventManagementSystem eventManagementSystem;
        private TaxiService taxiService;

        public HotelFacade() {

            List<FoodItem> foodMenu = new List<FoodItem>();

            foodMenu.Add(new FoodItem { Name = "Pasta", Price = 12.99m });
            foodMenu.Add(new FoodItem { Name = "Pizza", Price = 15.99m });
            foodMenu.Add(new FoodItem { Name = "Salad", Price = 9.99m });

            List<Table> tables = new List<Table>
            {
                new Table { TableNumber = 1, Seats = 2, IsAvailable = true },
                new Table { TableNumber = 2, Seats = 4, IsAvailable = true },
                new Table { TableNumber = 3, Seats = 6, IsAvailable = true }
            };

            List<Room> rooms = new List<Room>
            {
                new Room { RoomNumber = 101, IsAvailable = true },
                new Room { RoomNumber = 102, IsAvailable = true },
                new Room { RoomNumber = 201, IsAvailable = true },
                new Room { RoomNumber = 202, IsAvailable = true }
            };

            List<EventRoom> eventRooms = new List<EventRoom>
            {
                new EventRoom { RoomNumber = 1, Capacity = 50, IsOrdered = false },
                new EventRoom { RoomNumber = 2, Capacity = 100, IsOrdered = false },
                new EventRoom { RoomNumber = 3, Capacity = 200, IsOrdered = false }
            };


            taxiService = new TaxiService();
            cleaningService = new CleaningService(rooms);
            roomBookingSystem = new RoomBookingSystem(rooms);
            restaurantSystem = new RestaurantSystem(rooms, tables, foodMenu);

            eventManagementSystem = new EventManagementSystem(eventRooms);
        } 

     

        public void BookRoom(int roomNumber)
        {
            if (!this.roomBookingSystem.RoomCheckBookingStatus(roomNumber))
                return;

            if (this.roomBookingSystem.BookRoom(roomNumber)){
                this.cleaningService.ScheduleCleaning(roomNumber,DateTime.Now);
            }
        }

        public void BookTable(int tableNumber)
        {
            if (!this.restaurantSystem.CheckTableBookingStatus(tableNumber))
                return;

            this.restaurantSystem.BookTable(tableNumber);
        }

        public void OrderEventRoom(int roomID)
        {

            if (this.eventManagementSystem.CheckEventRoomOrderStatus(roomID))
            {
                this.eventManagementSystem.OrderEventRoom(roomID) ;
            }
        }
        public void OrderFoodTable(int tableId, string foodName)
        {
            if (this.restaurantSystem.CheckTableBookingStatus(tableId))
            {
                var food = this.restaurantSystem.OrderFoodTable(tableId, foodName);
                if (food != null)
                {
                    Console.WriteLine($"[Facade] Successfully ordered '{food.Name}' (₸{food.Price}) for table {tableId}.");
                }
                else
                {
                    Console.WriteLine($"[Facade] Failed to order '{foodName}' for table {tableId} — item not found.");
                }
            }
            else
            {
                Console.WriteLine($"[Facade] Cannot order — table {tableId} is not booked.");
            }
        }
        public void OrderFoodRoom(int roomID, string foodName)
        {
            if (this.restaurantSystem.CheckTableBookingStatus(roomID))
            {
                var food = this.restaurantSystem.OrderFoodRoom(roomID, foodName);
                if (food != null)
                {
                    Console.WriteLine($"[Facade] Successfully ordered '{food.Name}' (₸{food.Price}) for room {roomID}.");
                }
                else
                {
                    Console.WriteLine($"[Facade] Failed to order '{foodName}' for room {roomID} — item not found.");
                }
            }
            else
            {
                Console.WriteLine($"[Facade] Cannot order — room {roomID} is not booked.");
            }
        }

        public void OrderCleningRoom(int roomID, DateTime date)
        {
            this.cleaningService.ScheduleCleaning(roomID, date);
        }

        public void BookTableAndSendTaxi(int tableID)
        {
            this.BookTable(tableID);
            this.taxiService.OrderTaxi($"Restaurant Table {tableID}");

        }

    }
}
