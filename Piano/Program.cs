using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<ConsoleKey, int[]> octaves = new Dictionary<ConsoleKey, int[]>()
    {
        { ConsoleKey.D1, new int[] { 1635, 1732, 1835, 1945, 2060, 2183, 2312, 2450, 2596, 2750, 2914 } },
        { ConsoleKey.D2, new int[] { 3270, 3465, 3671, 3889, 4120, 4365, 4625, 4900, 5191, 5500, 5827 } }
    };

    static int[]? currentOctave;

    static void Main(string[] args)
    {
        currentOctave = octaves[ConsoleKey.D1];
        Console.WriteLine("Виртуальное пианино");

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            Console.Clear();

            if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.D2)
            {
                currentOctave = ChangeOctave(keyInfo.Key);
            }
            else
            {
                PlaySound(keyInfo.Key, currentOctave);
            }
        }
    }

    static void PlaySound(ConsoleKey key, int[] octave)
    {
        Dictionary<ConsoleKey, int> keyToIndex = new Dictionary<ConsoleKey, int>
        {
            { ConsoleKey.A, 0 },
            { ConsoleKey.W, 1 },
            { ConsoleKey.S, 2 },
            { ConsoleKey.E, 4 },
            { ConsoleKey.D, 5 },
            { ConsoleKey.F, 6 },
            { ConsoleKey.T, 7 },
            { ConsoleKey.G, 8 },
            { ConsoleKey.Y, 9 },
            { ConsoleKey.H, 10 }
        };

        if (keyToIndex.ContainsKey(key))
        {
            int index = keyToIndex[key];
            Console.Beep(octave[index], 700);
        }
    }

    static int[] ChangeOctave(ConsoleKey key)
    {
        int[] octaveOne = octaves[ConsoleKey.D1];
        int[] octaveTwo = octaves[ConsoleKey.D2];

        Console.WriteLine(key == ConsoleKey.D1 ? "Первая октава" : "Вторая октава");
        return key == ConsoleKey.D1 ? octaveOne : octaveTwo;
    }
}