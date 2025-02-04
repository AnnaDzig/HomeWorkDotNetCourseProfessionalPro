//Напишіть програму, яка дозволила б за вказаною адресою web-сторінки вибирати
//всі посилання на інші сторінки, номери телефонів, поштові адреси та зберігала
//отриманий результат у файл.

using System.Net;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Введіть URL сторінки: ");
        string url = Console.ReadLine();

        if(string.IsNullOrEmpty(url) )
        {
            Console.WriteLine("URL не може бути порожнім.");
            return;
        }
        try
        {
            string htmlContent = GetWebPageContent(url);

            var links = ExtractLinks(htmlContent);
            var phoneNumbers = ExtractPhoneNumbers(htmlContent);
            var emails = ExtractEmails(htmlContent);

            SaveResultsToFile(url, links, phoneNumbers, emails);

            Console.WriteLine("Результати збережено у 'output.txt'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }
    }

static string GetWebPageContent(string url)
{
    using WebClient client = new WebClient();
    return client.DownloadString(url);
}
static string[] ExtractLinks(string html)
{
    Regex regex = new Regex(@"<a\s+[^>]*href=['""]([^'""]+)['""]", RegexOptions.IgnoreCase);
    MatchCollection matches = regex.Matches(html);
    return GetMatches(matches);
}
    static string[] ExtractPhoneNumbers(string html)
    {
        Regex regex = new Regex(@"\b(?:\+?\d{1,3}[-. ]?)?\(?\d{2,4}\)?[-. ]?\d{2,4}[-. ]?\d{2,4}\b");
        MatchCollection matches = regex.Matches(html);
        return GetMatches(matches);
    }
    static string[] ExtractEmails(string html)
    {
        Regex regex = new Regex(@"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,7}\b");
        MatchCollection matches = regex.Matches(html);
        return GetMatches(matches);
    }
    static string[] GetMatches(MatchCollection matches)
    {
        string[] results = new string[matches.Count];
        for (int i = 0; i < matches.Count; i++)
        {
            results[i] = matches[i].Groups[1].Value;
        }
        return results;
    }
    static void SaveResultsToFile(string url, string[] links, string[] phones, string[] emails)
    {
        using StreamWriter writer = new StreamWriter("output.txt");

        writer.WriteLine($"Результати для: {url}\n");

        writer.WriteLine("🔗 Посилання:");
        foreach (string link in links) writer.WriteLine(link);

        writer.WriteLine("\n📞 Телефони:");
        foreach (string phone in phones) writer.WriteLine(phone);

        writer.WriteLine("\n📧 Email-адреси:");
        foreach (string email in emails) writer.WriteLine(email);
    }
}