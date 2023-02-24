using System;
using System.Collections.Generic;

class Program
{
    delegate int StringLengthDelegate(string s);

    static void Main(string[] args)
    {
        
        List<string> strings = new List<string> { "Nihao", "world", "from", "Denys Spodin" };

        
        StringLengthDelegate stringLengthDelegate = s => s.Length;

        
        foreach (string s in strings)
        {
            int length = stringLengthDelegate(s);
            Console.WriteLine($"Length of '{s}': {length}");
        }
    }
}