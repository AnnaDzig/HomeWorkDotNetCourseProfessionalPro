//Створіть колекцію, до якої можна додавати покупців та категорію придбаної ними продукції.
//З колекції можна отримувати категорії товарів, які купив покупець або за категорією
//визначити покупців.
using CustomerProductManager;

public class Program
{
    public static void Main(string[] args)
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var manager = new CustomerProductManagerCollection();

        // Додати покупки
        manager.AddPurchase("Олена", "Книги");
        manager.AddPurchase("Олена", "Електроніка");
        manager.AddPurchase("Олександр", "Одяг");
        manager.AddPurchase("Олександр", "Книги");
        manager.AddPurchase("Ірина", "Електроніка");

        // Отримати категорії, які купив покупець
        Console.WriteLine("Категорії, які придбала Олена:");
        foreach (var category in manager.GetCategoriesByCustomer("Олена"))
        {
            Console.WriteLine($"- {category}");
        }

        // Отримати покупців за категорією
        Console.WriteLine("\nПокупці, які придбали товари з категорії 'Книги':");
        foreach (var customer in manager.GetCustomersByCategory("Книги"))
        {
            Console.WriteLine($"- {customer}");
        }

        Console.WriteLine("\nПокупці, які придбали товари з категорії 'Електроніка':");
        foreach (var customer in manager.GetCustomersByCategory("Електроніка"))
        {
            Console.WriteLine($"- {customer}");
        }
    }
}