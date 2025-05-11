/// <summary>
/// Представляє однозв'язний список з елементами типу short.
/// </summary>
public class CustomLinkedList : IEnumerable<short>
{
    /// <summary>
    /// Вузол списку.
    /// </summary>
    private class Node
    {
        /// <summary>
        /// Значення вузла.
        /// </summary>
        public short Value { get; set; }
        
        /// <summary>
        /// Посилання на наступний вузол.
        /// </summary>
        public Node Next { get; set; }

        /// <summary>
        /// Ініціалізує новий вузол з вказаним значенням.
        /// </summary>
        /// <param name="value">Значення вузла.</param>
        public Node(short value)
        {
            Value = value;
            Next = null;
        }
    }

    private Node _head;
    private int _count;

    /// <summary>
    /// Отримує кількість елементів у списку.
    /// </summary>
    public int Count => _count;

    /// <summary>
    /// Ініціалізує новий пустий список.
    /// </summary>
    public CustomLinkedList()
    {
        _head = null;
        _count = 0;
    }

    /// <summary>
    /// Додає елемент після першого елементу списку.
    /// </summary>
    /// <param name="value">Значення для додавання.</param>
    public void AddAfterFirst(short value)
    {
        Node newNode = new Node(value);

        if (_head == null)
        {
            _head = newNode;
        }
        else
        {
            newNode.Next = _head.Next;
            _head.Next = newNode;
        }
        _count++;
    }

    /// <summary>
    /// Знаходить перше входження елементу більше заданого значення.
    /// </summary>
    /// <param name="value">Значення для порівняння.</param>
    /// <returns>Перший елемент більший за задане значення або null, якщо такого немає.</returns>
    public short? FirstGreaterThan(short value)
    {
        Node current = _head;
        while (current != null)
        {
            if (current.Value > value)
            {
                return current.Value;
            }
            current = current.Next;
        }
        return null;
    }

    /// <summary>
    /// Обчислює середнє значення елементів списку.
    /// </summary>
    /// <returns>Середнє значення.</returns>
    private double CalculateAverage()
    {
        if (_count == 0) return 0;
        
        double sum = 0;
        Node current = _head;
        while (current != null)
        {
            sum += current.Value;
            current = current.Next;
        }
        return sum / _count;
    }

    /// <summary>
    /// Знаходить суму елементів більших за середнє значення.
    /// </summary>
    /// <returns>Сума елементів більших за середнє.</returns>
    public short SumGreaterThanAverage()
    {
        double average = CalculateAverage();
        short sum = 0;
        Node current = _head;
        while (current != null)
        {
            if (current.Value > average)
            {
                sum += current.Value;
            }
            current = current.Next;
        }
        return sum;
    }

    /// <summary>
    /// Отримує новий список з елементів менших за середнє значення.
    /// </summary>
    /// <returns>Новий список з елементів менших за середнє.</returns>
    public CustomLinkedList GetLessThanAverage()
    {
        CustomLinkedList newList = new CustomLinkedList();
        double average = CalculateAverage();
        Node current = _head;
        while (current != null)
        {
            if (current.Value < average)
            {
                newList.AddAfterFirst(current.Value);
            }
            current = current.Next;
        }
        return newList;
    }

    /// <summary>
    /// Видаляє елементи, які розташовані після максимального елементу.
    /// </summary>
    public void RemoveAfterMax()
    {
        if (_head == null || _head.Next == null) return;

        Node maxNode = _head;
        Node current = _head.Next;

        // Знаходимо максимальний елемент
        while (current != null)
        {
            if (current.Value > maxNode.Value)
            {
                maxNode = current;
            }
            current = current.Next;
        }

        // Видаляємо всі елементи після максимального
        maxNode.Next = null;
        _count = GetCountFromHead();
    }

    /// <summary>
    /// Перераховує кількість елементів у списку.
    /// </summary>
    /// <returns>Кількість елементів.</returns>
    private int GetCountFromHead()
    {
        int count = 0;
        Node current = _head;
        while (current != null)
        {
            count++;
            current = current.Next;
        }
        return count;
    }

    /// <summary>
    /// Видаляє елемент за вказаним індексом.
    /// </summary>
    /// <param name="index">Індекс елемента для видалення.</param>
    /// <exception cref="ArgumentOutOfRangeException">Викидається, коли індекс виходить за межі діапазону.</exception>
    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
        }

        if (index == 0)
        {
            _head = _head.Next;
        }
        else
        {
            Node previous = GetNodeAt(index - 1);
            previous.Next = previous.Next?.Next;
        }
        _count--;
    }

    /// <summary>
    /// Отримує вузол за вказаним індексом.
    /// </summary>
    /// <param name="index">Індекс вузла.</param>
    /// <returns>Вузол за вказаним індексом.</returns>
    private Node GetNodeAt(int index)
    {
        Node current = _head;
        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }
        return current;
    }

    /// <summary>
    /// Отримує значення елемента за вказаним індексом.
    /// </summary>
    /// <param name="index">Індекс елемента.</param>
    /// <returns>Значення елемента.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Викидається, коли індекс виходить за межі діапазону.</exception>
    public short this[int index]
    {
        get
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
            }
            return GetNodeAt(index).Value;
        }
    }

    /// <summary>
    /// Повертає перелічувач для ітерації по списку.
    /// </summary>
    /// <returns>Перелічувач.</returns>
    public IEnumerator<short> GetEnumerator()
    {
        Node current = _head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    /// <summary>
    /// Повертає перелічувач для ітерації по списку.
    /// </summary>
    /// <returns>Перелічувач.</returns>
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}