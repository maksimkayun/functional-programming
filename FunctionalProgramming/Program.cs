// See https://aka.ms/new-console-template for more information

// Напишите программу, которая считывает набор слов в строку через пробел из консоли,
// а затем печатает их в консоль так, чтобы каждая строка была напечатана в новой строке.
// Используйте Action<Т>.

using System.Collections;
using FunctionalProgramming;

Action<string> WriteLn = s => Console.WriteLine(s);
//Console.ReadLine()?.Split(" ").ToList().ForEach(WriteLn);

// Напишите программу, которая считывает набор слов (или символов) в строке через пробел из консоли,
// а затем печатает их в консоль так, чтобы каждая фраза начиналась с новой строки и содержала
// «<слово> (нет в наличии)». 
// Используйте Action<T>.
Action<string> WriteLnWithEnding = s => Console.WriteLine($"{s} (нет в наличии)");
//Console.ReadLine()?.Split(" ").ToList().ForEach(WriteLnWithEnding);

// Напишите программу, которая считывает набор целых чисел через пробел из консоли
// и затем печатает минимальное из них. Используйте Func<T, T>.
Func<int[]?, int> GetMin = arr => (arr ?? Array.Empty<int>()).Min();
//var collection = Console.ReadLine()?.Split(" ").Select(int.Parse).ToArray();
//Console.Write(GetMin(collection));

// Напишите программу, которая считывает диапазон целых чисел, команду четные или нечетные (odd/even)
// и затем выводит все соответствующие числа из диапазона. Используйте Func<T, T>.
Func<IEnumerable<string>?, List<int>> GetAllOfRange = range =>
{
    List<int> output = new List<int>();
    var type = range.LastOrDefault();
    for (int i = int.Parse(range.ToList()[0]); i <= int.Parse(range.ToList()[1]); i++)
    {
        if (type.Equals("odd") && i % 2 != 0
            || type.Equals("even") && i % 2 == 0)
        {
            output.Add(i);
        }
    }

    return output;
};
var input = Console.ReadLine()?.Split(' ').ToList();
input.Add(Console.ReadLine());
GetAllOfRange(input).ForEach(e => Console.Write(e + " "));


/* Напишите программу, которая выполняет некоторые арифметические операции над заданной коллекцией. 
    В первой строке вам дается список чисел. В следующих строках вам передаются различные команды, которые нужно применить ко всем числам в списке: 
"add" -> добавить 1 к каждому числу; 
"multiply" -> умножить каждое число на 2; 
"subtract" -> вычесть 1 из каждого числа; 
    “print” -> распечатать коллекцию. 
    Ввод завершается командой "end". Использовать Functions. */

Func<int, int>? GetFunc(string? command)
{
    switch (command)
    {
        case "add": return e => e + 1;
        case "subtract": return e => e - 1;
        case "multiply": return e => e * 2;
    }

    return null;
}

void ExecuteCommand(List<int>? list, Func<int, int>? func)
{
    if (func != null)
    {
        for (int i = 0; i < list?.Count; i++)
        {
            list[i] = func(list[i]);
        }
    }
    else
    {
        list?.ForEach(e => Console.Write(e + " "));
        Console.WriteLine();
    }
}

// var collection = Console.ReadLine()?.Split(" ").Select(int.Parse).ToList();
// var command = Console.ReadLine();
// while (!string.Equals(command, "end"))
// {
//     ExecuteCommand(collection, GetFunc(command));
//     command = Console.ReadLine();
// }

// Напишите программу, которая реверсирует коллекцию и удаляет элементы,
// которые делятся на заданное целое число n. 
Func<int, int, bool> IsNotshared = (n, divider) => n % divider != 0;

// var list = Console.ReadLine()?.Split(' ').Select(int.Parse);
// var n = int.Parse(Console.ReadLine() ?? string.Empty);
// list.Where(e => IsNotshared(e, n))
//     .Reverse().ToList().ForEach(e => Console.Write(e + " "));


// Напишите программу, которая фильтрует список имен в соответствии с их длиной.
// В первой строке вам будет дано целое число n, представляющее длину имени для фильтрации.
// Во второй строке вам будут даны некоторые имена в виде строк, разделенных пробелом.
// Напишите функцию, которая выводит только те имена, длина которых меньше или равна n. 

void PrintIf(string name, Predicate<string> condition)
{
    if (condition(name))
        Console.Write(name + " ");
}

// var n = int.Parse(Console.ReadLine() ?? String.Empty);
// Console.ReadLine()?.Split(' ')
//     .ToList().ForEach(name => PrintIf(name, name => name.Length <= n));

// Реализуйте компаратор, для сортировки всех четных чисел перед всеми нечетными
// в порядке возрастания. Передайте его в функцию Array.Sort()
// (первый параметр – коллекция, второй - компаратор) и выведите результат.



var list = Console.ReadLine()?.Split(' ').Select(int.Parse).ToArray();
Array.Sort(list, new Extension());
list.ToList().ForEach(e=> Console.Write(e + " "));