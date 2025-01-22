//Створіть колекцію, в яку можна записувати два значення одного слова,
//на кшталт російсько-англо-українського словника. І в ній можна для українського
//слова знайти або лише російське значення, або лише англійське та вивести його на екран. 

using MultiDictionary;

class Program
{

    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var multiDict = new MultiDict();

        // Додавання слів до словника
        multiDict.AddWord("кіт", "kat", "cat");
        multiDict.AddWord("собака", "hund", "dog");
        multiDict.AddWord("птах", "fugel", "bird");

        // Пошук перекладу
        Console.WriteLine("Enter a Ukrainian word to find its Danish translation:");
        string ukrWord = Console.ReadLine();
        Console.WriteLine($"Danish: {multiDict.FindDanish(ukrWord) ?? "Not found"}");

        Console.WriteLine("\nEnter a Ukrainian word to find its English translation:");
        ukrWord = Console.ReadLine();
        Console.WriteLine($"English: {multiDict.FindEnglish(ukrWord) ?? "Not found"}");

        Console.WriteLine("\nAll words in the dictionary:");
        multiDict.PrintAll();
    }
}
