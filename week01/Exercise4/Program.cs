using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.Write("Enter number: ");
        int number = int.Parse(Console.ReadLine());
        while (number != 0 )
        {
            numbers.Add(number);
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
        }

        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }

        Console.WriteLine($"The sum of the numbers is {sum}");

        double average = (double)sum / numbers.Count;
        Console.WriteLine($"The average of the numbers is {average:0.##}");
        
        int largest = numbers[0];
        foreach (int num in numbers)
        {
            if (largest < num)
            {
                largest = num;
            }
        }

        Console.WriteLine($"The largest number is {largest}");


    }
}