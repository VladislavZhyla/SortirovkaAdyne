using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        string[] data = { "груша", "яблуко", "апельсин", "банан", "ківі", "виноград" };
        Console.WriteLine("Не відсортований масив:");
        PrintArray(data);

        Thread t1 = new Thread(() => InsertionSort(data));
        Thread t2 = new Thread(() => SelectionSort(data));
        Thread t3 = new Thread(() => BubbleSort(data));

        t1.Start();
        t2.Start();
        t3.Start();

        t1.Join();
        t2.Join();
        t3.Join();

        Console.WriteLine("Відсортований масив: ");
        PrintArray(data);

        Console.ReadLine();
    }

    static void InsertionSort(string[] data)
    {
        for (int i = 1; i < data.Length; i++)
        {
            string key = data[i];
            int j = i - 1;

            while (j >= 0 && data[j].CompareTo(key) > 0)
            {
                data[j + 1] = data[j];
                j--;
            }

            data[j + 1] = key;
        }
        Console.WriteLine("Сортування вставками завершено");
    }

    static void SelectionSort(string[] data)
    {
        for (int i = 0; i < data.Length - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < data.Length; j++)
            {
                if (data[j].CompareTo(data[minIndex]) < 0)
                {
                    minIndex = j;
                }
            }

            string temp = data[i];
            data[i] = data[minIndex];
            data[minIndex] = temp;
        }
        Console.WriteLine("Сортування вибіркой завершено");
    }

    static void BubbleSort(string[] data)
    {
        bool swapped;
        do
        {
            swapped = false;
            for (int i = 0; i < data.Length - 1; i++)
            {
                if (data[i].CompareTo(data[i + 1]) > 0)
                {
                    string temp = data[i];
                    data[i] = data[i + 1];
                    data[i + 1] = temp;
                    swapped = true;
                }
            }
        } while (swapped);
        Console.WriteLine("Сортування бульбашкою завершено");
    }

    static void PrintArray(string[] data)
    {
        foreach (string item in data)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
