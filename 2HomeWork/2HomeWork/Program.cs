
public class Program
{ 
public static void Main()
{
    Console.WriteLine("Введи колличество элементов массива:");
    string text = Console.ReadLine();
    int countElements;
    int[] thisArray;
    try
    {
        countElements = Convert.ToInt32(text);
        thisArray = new int[countElements];
        for (int i = 0; i < thisArray.Length; i++)
        {
            Console.WriteLine($"Введи элемент под индексом {i}");
            thisArray[i] = int.Parse(Console.ReadLine());
        }
        int[] newThisArray = thisArray.Distinct().ToArray(); //удаление дублей
        /*for (int i = 0; i < newThisArray.Length; i++) //проверка вывода без дублей
        {
            Console.WriteLine(newThisArray[i]);
        }
        */
        Array.Sort(newThisArray);
        Console.WriteLine($"Твоё число: {newThisArray[newThisArray.Length - 2]}");

    }
    catch (FormatException)
    {
        Console.WriteLine("Вводи только целые числа");
    }
    catch (IndexOutOfRangeException)
    {
        Console.WriteLine("В твоём массиве меньше двух элементов,или число повторяющихся элементов равно числу всех элементов в массиве. Исправь!");
    }
    finally
    {
        Console.WriteLine("Программа сработала!");
    }
}

}