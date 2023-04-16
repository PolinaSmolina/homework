using System.IO.Compression;

namespace HW6_2
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            const string savePathName = @"D:\HomeWork\HW6\Lesson5Homework.txt";
            string infoFilePath = "";

            // считываю путь
            try
            {
                using (StreamReader reader = new(savePathName))
                {
                    infoFilePath = await reader.ReadLineAsync();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"файл Lesson5Homework.txt не существует: {ex.Message}");
            }

            catch (IOException ex)
            {
                Console.WriteLine($"ошибка чтения Lesson5Homework.txt {ex.Message}");
            }

            List<FileData> data = new();

            // читаю инфо 
            try
            {
                using (StreamReader reader = new(infoFilePath))
                {
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        string[] fields = line.Split('\t');
                        FileData item = new()
                        {
                            Type = fields[0],
                            Name = fields[1],
                            Date = DateTime.Parse(fields[2])
                        };
                        data.Add(item);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"файл Info.csv не существует: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"ошибка чтения Info.csv {ex.Message}");
            }


            var sortedData = data.OrderBy(item => item.Date).ToList();

            foreach (FileData item in sortedData)
            {
                Console.WriteLine($"{item.Type} {item.Name} {item.Date}");
            }

            File.Delete(savePathName);
        }
    }

    public class FileData
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}