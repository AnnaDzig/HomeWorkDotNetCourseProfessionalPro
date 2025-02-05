//Напишіть консольну програму, яка дозволяє користувачеві зареєструватися під «Логіном»,
//що складається тільки з символів латинського алфавіту, і пароля, що складається з цифр і символів.

using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("🔹 Реєстрація користувача 🔹");

        string login = GetValidLogin();
        string password = GetValidPassword();

        Console.WriteLine("\n✅ Реєстрація успішна!");
        Console.WriteLine($"🔹 Ваш логін: {login}");
        Console.WriteLine($"🔹 Ваш пароль: {new string('*', password.Length)} (приховано)");
    }

    static string GetValidLogin()
    {
        while (true) {
            Console.Write("\n🔹 Введіть логін (лише латинські букви): ");
            string login = Console.ReadLine();

            if ( Regex.IsMatch(login, @"^[A-Za-z]+$"))
                return login;
            Console.WriteLine("❌ Помилка! Логін має містити лише букви латинського алфавіту (A-Z, a-z).");

    
        }
}
    static string GetValidPassword()
    {
        while (true)
        {
            Console.Write("\n🔹 Введіть пароль (лише цифри та спецсимволи, без букв): ");
            string password = Console.ReadLine();

            if (Regex.IsMatch(password, @"^[\d\W]+$")) // Тільки цифри та спецсимволи
                return password;

            Console.WriteLine("❌ Помилка! Пароль повинен містити тільки цифри (0-9) і спецсимволи (!@#$% тощо), без букв.");
        }
    }
}