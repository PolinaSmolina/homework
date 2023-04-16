using System.IO.Compression;

namespace HW5_2
{ 
    public static class Program
    {        
        public static void Mains (string[] args)
        {
            const string savePathName = @"D:\HomeWork\HW5\Lesson5Homework.txt";
            string infoFilePath = "";

            // считываю путь
            try
            {
                using (StreamReader reader = new(savePathName))
                {
                    infoFilePath = reader.ReadLine();
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
                    while ((line = reader.ReadLine()) != null)
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