//Створіть колекцію, яка б за своєю структурою нагадувала «родове дерево»
//(ім'я людини, рік народження), причому до неї можна додавати/вилучати нового родича,
//є можливість побачити всіх спадкоємців обраної людини, відібрати родичів за роком народження.

using FamilyTree;

class Program
{
    static void Main()
    {
        // Створення кореня родового дерева
        Person root = new Person { Name = "Anna", YearOfBirth = 1984 };

        // Додавання спадкоємців
        root.AddDescendant(new Person { Name = "Viktoriia", YearOfBirth = 2008 });
        root.AddDescendant(new Person { Name = "Marcin", YearOfBirth = 1981 });
        root.AddDescendant(new Person { Name = "Mihal", YearOfBirth = 2006 });
        root.AddDescendant(new Person { Name = "Stepan", YearOfBirth = 1979 });

        // Виведення всіх спадкоємців
        Console.WriteLine("All descendants of Anna:");
        foreach (var descendant in root.GetDescendants())
        {
            Console.WriteLine(descendant);
        }

        // Фільтрація за роком народження
        Console.WriteLine("\nDescendants born in 1981:");
        foreach (var descendant in root.GetDescendantsByYear(1981))
        {
            Console.WriteLine(descendant);
        }

        // Видалення спадкоємця
        root.RemoveDescendant("Stepan");

        Console.WriteLine("\nAfter removing Stepan:");
        foreach (var descendant in root.GetDescendants())
        {
            Console.WriteLine(descendant);
        }
    }
}
