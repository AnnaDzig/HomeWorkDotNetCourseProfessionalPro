// Створіть метод, який як аргумент приймає масив цілих чисел і повертає
// колекцію квадратів усіх непарних чисел масиву. Для формування колекції
// використовуйте оператор yield.

class Program
{
    static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
        Console.WriteLine("Squares of odd numbers:");
        foreach (var squere in GetSqueresOfOdds(numbers))
        { Console.WriteLine(squere); }
    }
    static IEnumerable<int> GetSqueresOfOdds(int[] numbers)
    {
        foreach (var number in numbers)
        {
            if (number % 2 != 0)
            {
                yield return number * number;
            }
        }
    }
}