// Створіть програму, в якій надайте користувачеві доступ до збірки із завдання 2.
// Реалізуйте використання методу конвертації значення температури зі шкали Цельсія
// в шкалу Фаренгейта. Виконуючи завдання використовуйте лише рефлексію.


using System;
using System.Reflection;

class TempConverterReflector
{
    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("🔹 Програма конвертації температури (Рефлексія)");

        Console.Write("Введіть температуру в Цельсіях: ");
        if (!double.TryParse(Console.ReadLine(), out double celsius))
        {
            Console.WriteLine("❌ Некоректне число. Завершення програми.");
            return;
        }

        try
        {
            // Завантажуємо збірку (DLL)
            Assembly assembly = Assembly.LoadFrom("TemperatureConverter.dll");

            // Знаходимо тип (клас)
            Type converterType = assembly.GetType("TemperatureConverter.TempConverter");

            if (converterType == null)
            {
                Console.WriteLine("❌ Клас не знайдено у збірці!");
                return;
            }

            // Отримуємо метод для конвертації
            MethodInfo convertMethod = converterType.GetMethod("CelsiusToFahrenheit");

            if (convertMethod == null)
            {
                Console.WriteLine("❌ Метод не знайдено у класі!");
                return;
            }
            object converterInstance = Activator.CreateInstance(converterType);

            // Викликаємо метод через рефлексію
            object result = convertMethod.Invoke(converterInstance, new object[] { celsius });

            Console.WriteLine($"✅ {celsius}°C = {result}°F");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Сталася помилка: {ex.Message}");
        }
    }
}
