namespace lab7
{
    public class TableReservationApp
    {
        static void Main(string[] args)
        {
            var reservationManager = new ReservationManager();
            reservationManager.AddRestaurant("PuzataHata", 8);
            reservationManager.AddRestaurant("AromaKava", 5);
            reservationManager.AddRestaurant("McDonalds", 3);

            while (true)
            {
                try
                {
                    Console.WriteLine("Select a restaurant:\n");
                    for (int i = 0; i < reservationManager.GetRestaurants().Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {reservationManager.GetRestaurants()[i].Name}");
                    }

                    if (!int.TryParse(Console.ReadLine(), out int restaurantChoice) || restaurantChoice < 1 || restaurantChoice > reservationManager.GetRestaurants().Count)
                    {
                        Console.WriteLine("Invalid choice. Try again.");
                        continue;
                    }

                    var selectedRestaurant = reservationManager.GetRestaurants()[restaurantChoice - 1];
                    Console.WriteLine($"You selected {selectedRestaurant.Name}.");

                    int currentDay = DateTime.Today.Day;
                    int daysInMonth = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
                    Console.WriteLine($"Enter the day of the month to book a table ({currentDay}-{daysInMonth}):\n");

                    if (!int.TryParse(Console.ReadLine(), out int day) || day < currentDay || day > daysInMonth)
                    {
                        Console.WriteLine("Invalid day. Please select a valid day within the remaining days of this month.");
                        continue;
                    }

                    DateTime bookingDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, day);

                    while (true)
                    {
                        Console.WriteLine("Enter table number to book:");
                        if (!int.TryParse(Console.ReadLine(), out int tableNumber))
                        {
                            Console.WriteLine("Invalid input. Try again.");
                            continue;
                        }

                        if (selectedRestaurant.BookTable(bookingDate, tableNumber))
                        {
                            Console.WriteLine($"Table {tableNumber} successfully booked in {selectedRestaurant.Name} on {bookingDate:yyyy-MM-dd}.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Table {tableNumber} is either invalid or already booked. Try again.");
                        }
                    }

                    Console.WriteLine("Currently booked tables:");
                    foreach (var restaurant in reservationManager.GetRestaurants())
                    {
                        Console.WriteLine($"{restaurant.Name}:");
                        foreach (var entry in restaurant.GetBookedTablesWithDates())
                        {
                            Console.WriteLine(entry);
                        }
                    }

                    Console.WriteLine("\nWhat would you like to do next?");
                    Console.WriteLine("1. Book another table");
                    Console.WriteLine("2. View free tables in a restaurant");
                    Console.WriteLine("3. View all tables in a restaurant");
                    Console.WriteLine("4. Exit");

                    if (!int.TryParse(Console.ReadLine(), out int actionChoice) || actionChoice < 1 || actionChoice > 4)
                    {
                        Console.WriteLine("Invalid choice. Returning to main menu.");
                        continue;
                    }

                    switch (actionChoice)
                    {
                        case 1:
                            continue;

                        case 2:
                            Console.WriteLine("Select a restaurant to view free tables:");
                            for (int i = 0; i < reservationManager.GetRestaurants().Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {reservationManager.GetRestaurants()[i].Name}");
                            }

                            if (!int.TryParse(Console.ReadLine(), out int freeTablesChoice) || freeTablesChoice < 1 || freeTablesChoice > reservationManager.GetRestaurants().Count)
                            {
                                Console.WriteLine("Invalid choice. Returning to main menu.");
                                continue;
                            }

                            var freeTablesRestaurant = reservationManager.GetRestaurants()[freeTablesChoice - 1];
                            Console.WriteLine($"Free tables in {freeTablesRestaurant.Name}:");
                            foreach (var table in freeTablesRestaurant.GetFreeTables(DateTime.Today))
                            {
                                Console.WriteLine(table);
                            }
                            break;

                        case 3:
                            Console.WriteLine("Select a restaurant to view all tables:");
                            for (int i = 0; i < reservationManager.GetRestaurants().Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {reservationManager.GetRestaurants()[i].Name}");
                            }

                            if (!int.TryParse(Console.ReadLine(), out int allTablesChoice) || allTablesChoice < 1 || allTablesChoice > reservationManager.GetRestaurants().Count)
                            {
                                Console.WriteLine("Invalid choice. Returning to main menu.");
                                continue;
                            }

                            var allTablesRestaurant = reservationManager.GetRestaurants()[allTablesChoice - 1];
                            Console.WriteLine($"All tables in {allTablesRestaurant.Name}:");
                            foreach (var table in allTablesRestaurant.GetBookedTablesWithDates())
                            {
                                Console.WriteLine(table);
                            }
                            break;

                        case 4:
                            Console.WriteLine("Exiting the application. Goodbye!");
                            return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}