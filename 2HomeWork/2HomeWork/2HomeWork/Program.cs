
public class Program
{ 
public static void Main()
{
    Console.WriteLine("Введи колличество элементов массива:");
    string text = Console.ReadLine();
    int countElements;
    int[] numberArray;
    try
    {
        countElements = Convert.ToInt32(text);
        numberArray = new int[countElements];
        for (int i = 0; i < numberArray.Length; i++)
        {
            Console.WriteLine($"Введи элемент под индексом {i}");
            numberArray[i] = int.Parse(Console.ReadLine());
        }
        int[] newNumberArray = numberArray.Distinct().ToArray(); //удаление дублей
        Array.Sort(newNumberArray);
        Console.WriteLine($"Твоё число: {newNumberArray[newNumberArray.Length - 2]}");

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