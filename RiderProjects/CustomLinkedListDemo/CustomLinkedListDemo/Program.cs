/// <summary>
/// Демонстраційний клас для роботи з CustomLinkedList.
/// </summary>
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        CustomLinkedList list = new CustomLinkedList();
        list.AddAfterFirst(10);
        list.AddAfterFirst(20);
        list.AddAfterFirst(60);
        list.AddAfterFirst(40);
        list.AddAfterFirst(50);

        Console.WriteLine("Початковий список:");
        PrintList(list);
        
        short threshold = 25;
        short? firstGreater = list.FirstGreaterThan(threshold);
        Console.WriteLine($"\n1. Перший елемент більший за {threshold}: {(firstGreater.HasValue ? firstGreater.ToString() : "не знайдено")}");
        
        short sumGreaterThanAvg = list.SumGreaterThanAverage();
        Console.WriteLine($"2. Сума елементів більших за середнє: {sumGreaterThanAvg}");
        
        CustomLinkedList lessThanAvgList = list.GetLessThanAverage();
        Console.WriteLine("\n3. Новий список з елементів менших за середнє:");
        PrintList(lessThanAvgList);
        
        list.RemoveAfterMax();
        Console.WriteLine("\n4. Список після видалення елементів після максимального:");
        PrintList(list);
        
        Console.WriteLine("\nДемонстрація індексатора:");
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine($"Елемент з індексом {i}: {list[i]}");
        }
        
        int indexToRemove = 1;
        list.RemoveAt(indexToRemove);
        Console.WriteLine($"\nСписок після видалення елементу з індексом {indexToRemove}:");
        PrintList(list);
        
        Console.WriteLine("\nДемонстрація foreach:");
        foreach (short item in list)
        {
            Console.WriteLine(item);
        }
    }

    /// <summary>
    /// Виводить вміст списку на консоль.
    /// </summary>
    /// <param name="list">Список для виведення.</param>
    private static void PrintList(CustomLinkedList list)
    {
        if (list.Count == 0)
        {
            Console.WriteLine("Список порожній");
            return;
        }

        foreach (short item in list)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
    }
}