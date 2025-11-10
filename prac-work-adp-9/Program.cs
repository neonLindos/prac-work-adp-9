



using prac_work_adp_9.task1;
using prac_work_adp_9.task2;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

void TestTask1()
{
    // Создаем фасад
    var hotel = new HotelFacade();

    Console.WriteLine("=== Тест бронирования номера ===");
    hotel.BookRoom(101); // Бронируем номер
    hotel.BookRoom(101); // Пробуем забронировать снова (должен игнорироваться)
    hotel.OrderCleningRoom(101, DateTime.Now.AddHours(2)); // Запланировать уборку

    Console.WriteLine("\n=== Тест бронирования стола ===");
    hotel.BookTable(2); // Бронируем стол
    hotel.BookTable(2); // Повторная попытка брони

    Console.WriteLine("\n=== Тест заказа еды ===");
    hotel.OrderFoodTable(2, "Pizza"); // Заказ еды для стола
    hotel.OrderFoodTable(2, "Burger"); // Попытка заказать несуществующее блюдо
    hotel.OrderFoodRoom(101, "Salad"); // Заказ еды для комнаты

    Console.WriteLine("\n=== Тест заказа комнаты для мероприятия ===");
    hotel.OrderEventRoom(1); // Заказ зала
    hotel.OrderEventRoom(1); // Попытка заказать снова

    Console.WriteLine("\n=== Тест брони стола и вызова такси ===");
    hotel.BookTableAndSendTaxi(3); // Бронируем стол и заказываем такси
}

void TestTask2()
{
    var alice = new Employee("Alice", "Developer", 7000);
    var bob = new Employee("Bob", "Designer", 6500);
    var charlie = new Contractor("Charlie", "Contractor", 4000);
    var david = new Employee("David", "Manager", 10000);

    var devDept = new Department("Development");
    var designDept = new Department("Design");
    var mainDept = new Department("Head Office");

    devDept.Add(alice);
    devDept.Add(charlie);
    designDept.Add(bob);
    mainDept.Add(devDept);
    mainDept.Add(designDept);
    mainDept.Add(david);

    mainDept.Display();
    Console.WriteLine($"Total budget: ${mainDept.GetBudget()}");
    Console.WriteLine($"Total staff: {mainDept.GetStaffCount()}");

    alice.SetSalary(7500);
    Console.WriteLine($"Updated budget after Alice's raise: ${mainDept.GetBudget()}");

    var employee = mainDept.FindEmployee("Bob");
    if (employee != null)
        Console.WriteLine($"Found employee: {employee.Name} ({employee.Position}) - ${employee.Salary}");

    Console.WriteLine("All employees in Head Office:");
    foreach (var emp in mainDept.ListAllEmployees())
    {
        Console.WriteLine($"- {emp.Name} ({emp.Position})");
    }
}


TestTask1();
TestTask2();