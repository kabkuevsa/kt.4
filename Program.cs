using System;

// 1. Исключение форматирования (FormatException)
public class FormatExceptionExample
{
    // Проблема: исключение при парсинге нечисловой строки
    public int ParseNumberBad(string input)
    {
        return int.Parse(input); 
    }

    // Решение: использование TryParse
    public bool TryParseNumberGood(string input, out int result)
    {
        return int.TryParse(input, out result);
    }
}

// 2. Исключение деления на ноль (DivideByZeroException)
public class DivideByZeroExample
{
    // Проблема: исключение при делении на ноль
    public double DivideBad(int a, int b)
    {
        return a / b; 
    }

    // Решение: проверка делителя
    public double DivideGood(int a, int b)
    {
        if (b == 0)
        {
            throw new ArgumentException("Делитель не может быть нулем");
        }
        return a / b;
    }
}

// 3. Исключение работы с файлами (FileNotFoundException)
public class FileExceptionExample
{
    // Проблема: исключение при отсутствии файла
    public string ReadFileBad(string path)
    {
        return System.IO.File.ReadAllText(path); 
    }

    // Решение: обработка исключения
    public string ReadFileGood(string path)
    {
        try
        {
            return System.IO.File.ReadAllText(path);
        }
        catch (System.IO.FileNotFoundException)
        {
            return "Файл не найден";
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Пример 1: FormatException ===");
        var formatExample = new FormatExceptionExample();
        
        // Плохой подход
        try
        {
            formatExample.ParseNumberBad("не число");
        }
        catch (FormatException)
        {
            Console.WriteLine("Поймано FormatException - плохой подход");
        }

        // Хороший подход
        if (formatExample.TryParseNumberGood("123", out int number))
        {
            Console.WriteLine($"Успешно распаршено: {number} - хороший подход");
        }

        Console.WriteLine("\n=== Пример 2: DivideByZeroException ===");
        var divideExample = new DivideByZeroExample();
        
        // Плохой подход
        try
        {
            divideExample.DivideBad(10, 0);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Поймано DivideByZeroException - плохой подход");
        }

        // Хороший подход
        try
        {
            double result = divideExample.DivideGood(10, 5);
            Console.WriteLine($"Результат деления: {result} - хороший подход");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\n=== Пример 3: FileNotFoundException ===");
        var fileExample = new FileExceptionExample();
        
        // Хороший подход
        string content = fileExample.ReadFileGood("nonexistent.txt");
        Console.WriteLine($"Результат: {content} - хороший подход");
    }
}