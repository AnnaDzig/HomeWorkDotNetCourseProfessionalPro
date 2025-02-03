//Напишіть програму для пошуку заданого файлу на диску. Додайте код,
//який використовує клас FileStream і дозволяє переглядати файл у
//текстовому вікні. Насамкінець додайте можливість стиснення знайденого файлу.

using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Введіть шлях до файлу: ");
        string filePath = Console.ReadLine();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не знайдено.");
            return;
        }

        Console.WriteLine("Вміст файлу:");
        Console.WriteLine(File.ReadAllText(filePath));

        string compressedPath = filePath + ".gz";
        using (FileStream originalStream = new FileStream(filePath, FileMode.Open))
        using (FileStream compressedStream = new FileStream(compressedPath, FileMode.Create))
        using (GZipStream compression = new GZipStream(compressedStream, CompressionMode.Compress))
        {
            originalStream.CopyTo(compression);
        }

        Console.WriteLine($"Файл стиснуто: {compressedPath}");
    }
}

