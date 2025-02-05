//Створіть текстовий файл-чек на кшталт «Найменування товару – 0.00(ціна)грн.» з певною кількістю
//найменувань товарів та датою здійснення покупки. Виведіть на екран інформацію з чека у форматі
//поточної локалі користувача та у форматі локалі en-US.

using System.Globalization;

class Program
{
    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string filePath = "receipt.txt";

        CreateReceipt(filePath);

        DisplayReceipt(filePath);
    }

    static void CreateReceipt(string filePath)
    {
        string[] products = { "Хліб", "Молоко", "Кава", "Цукерки", "Йогурт", "Сир", "Сік", "Шоколад" };
        Random rand = new Random();

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine($"Дата покупки: {DateTime.Now}");

            foreach (var product in products)
            {
                double price = Math.Round(rand.NextDouble() * 100, 2);
                writer.WriteLine($"{product} – {price:F2} грн.");
            }
        }
    }

    static void DisplayReceipt(string filePath)
    {
        if(!File.Exists(filePath))
        {
            Console.WriteLine("Файл чека не знайдено!");
            return;
        }

        CultureInfo userCulture = CultureInfo.CurrentCulture;
        CultureInfo enUS = new CultureInfo("en-US");

        string[] lines = File.ReadAllLines(filePath);

        Console.WriteLine("\n📌 Чек у форматі поточної локалі:");
        foreach (var line in lines) {
            Console.WriteLine(line);
    }

        Console.WriteLine("\n📌 Чек у форматі en-US:");
        foreach (var line in lines)
        {
            if (line.StartsWith("Дата покупки"))
            {
                // Замінюємо дату на формат en-US
                string dateStr = line.Replace("Дата покупки: ", "").Trim();
                if (DateTime.TryParse(dateStr, out DateTime date))
                {
                    Console.WriteLine("Purchase Date: " + date.ToString("D", enUS));
                }
                else
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                // Замінюємо "грн." на "USD" і коригуємо формат
                string convertedLine = line.Replace(" грн.", " USD");
                Console.WriteLine(convertedLine);
            }
        }
    }
}