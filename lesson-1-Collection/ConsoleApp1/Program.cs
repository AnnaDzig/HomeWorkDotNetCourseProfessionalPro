// Створіть колекцію, в якій зберігалися б найменування 12 місяців,
// порядковий номер і кількість днів у відповідному місяці.
// Реалізуйте можливість вибору місяців як за порядковим номером,
// так і кількістю днів у місяці, при цьому результатом може бути
// не тільки один місяць.

using ConsoleApp1;

class Program
{
    static void Main()
    {
        // Створюємо колекцію місяців
        List<Month> months = new List<Month>
        {
            new Month { Number = 1, Name = "January", Days = 31 },
            new Month { Number = 2, Name = "February", Days = 28 },
            new Month { Number = 3, Name = "March", Days = 31 },
            new Month { Number = 4, Name = "April", Days = 30 },
            new Month { Number = 5, Name = "May", Days = 31 },
            new Month { Number = 6, Name = "June", Days = 30 },
            new Month { Number = 7, Name = "July", Days = 31 },
            new Month { Number = 8, Name = "August", Days = 31 },
            new Month { Number = 9, Name = "September", Days = 30 },
            new Month { Number = 10, Name = "October", Days = 31 },
            new Month { Number = 11, Name = "November", Days = 30 },
            new Month { Number = 12, Name = "December", Days = 31 }
        };

        Console.WriteLine("Enter search type (1 for month number, 2 for days):");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.Write("Enter month number (1-12): ");
                int monthNumber = int.Parse(Console.ReadLine());
                var monthByNumber = months.FirstOrDefault(m => m.Number == monthNumber);
                if (monthByNumber != null)
                {
                    Console.WriteLine($"Result: {monthByNumber}");
                }
                else
                {
                    Console.WriteLine("Month not found.");
                }
                break;

                case 2:
      
                Console.Write("Enter number of days: ");
                int days = int.Parse(Console.ReadLine());
                var monthsByDays = months.Where(m => m.Days == days).ToList();
                if (monthsByDays.Any())
                {
                    Console.WriteLine("Results:");
                    foreach (var month in monthsByDays)
                    {
                        Console.WriteLine(month);
                    }
                }
                else
                {
                    Console.WriteLine("No months found with that number of days.");
                }
                break;

            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

}
