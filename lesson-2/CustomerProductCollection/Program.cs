// Створіть колекцію C#, до якої можна додавати покупців та категорію придбаної
// ними продукції. З колекції можна отримувати категорії товарів, які купив покупець
// або за категорією визначити покупців.

using CustomerProductCollection;

class Program
{
    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8; 

        var collection = new CustomerProduct();

        collection.AddPurchase("Олена", "Електроніка");
        collection.AddPurchase("Олена", "Книги");
        collection.AddPurchase("Андрій", "Книги");
        collection.AddPurchase("Ірина", "Одяг");

        Console.WriteLine("Категорії, які придбала Олена:");
        foreach (var category in collection.GetCategoriesByCustomer("Олена"))
        {
            Console.WriteLine($"- {category}");
        }

        Console.WriteLine("\nПокупці, які придбали товари з категорії 'Книги':");
        foreach (var customer in collection.GetCustomersByCategory("Книги"))
        {
            Console.WriteLine($"- {customer}");
        }
    }
}
