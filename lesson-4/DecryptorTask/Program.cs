// Напишіть жартівливу програму «Дешифратор», яка в текстовому файлі могла б замінити
// всі прийменники слово «ГАВ!».

using System.Text.RegularExpressions;

class Decryptor
{
    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Введіть шлях до файлу: ");
        string filePath = Console.ReadLine();

        if(!File.Exists(filePath))
        {
            Console.WriteLine("Файл не знайдено! Переконайтеся, що шлях правильний.");
            return;
        }
        try
        {
            string text = File.ReadAllText(filePath);

            string[] prepositions = { "в", "у", "на", "до", "з", "із", "без", "при", "за", "під", "перед", "про", "через" };
            foreach (var word in prepositions)
            {
                text = Regex.Replace(text, $@"\b{word}\b", "ГАВ!", RegexOptions.IgnoreCase);
            }

            File.WriteAllText("output.txt", text);

            Console.WriteLine("Обробка завершена! Тепер це справжня собача мова 🐶. Результат у 'output.txt'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Сталася помилка: " + ex.Message);
        }
    }
}