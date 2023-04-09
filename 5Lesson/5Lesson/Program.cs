using System.IO.Compression;

namespace HW5
{
    public static class Program
    {//первая программа
        public static void Main(string[] args)
        {
            const string sourceFileName = @"D:\HomeWork\HW5\Archive.zip";
            const string destDirName = @"D:\HomeWork\HW5\DirForArchive";
            const string InfoFileName = @"D:\HomeWork\HW5\Info.csv";
            const string SavePathName = @"D:\HomeWork\HW5\Lesson5Homework.txt";

            // Проверяю и создаю
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // извлекаю
            try
            {
                ZipFile.ExtractToDirectory(sourceFileName, destDirName);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Файла нет: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            string[] files = Directory.GetFiles(destDirName);
            string[] directories = Directory.GetDirectories(destDirName);

            try
            {
                using (StreamWriter writer = new StreamWriter(InfoFileName, false))
                {
                    // файл
                    foreach (string file in files)
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        string fileType = "File";
                        string fileName = fileInfo.Name;
                        string fileDate = fileInfo.LastWriteTime.ToString();
                        writer.WriteLine($"{fileType}\t{fileName}\t{fileDate}");
                    }
                    // директория
                    foreach (string directory in directories)
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                        string fileType = "Directory";
                        string directoryName = directoryInfo.Name;
                        string directoryDate = directoryInfo.LastWriteTime.ToString();
                        writer.WriteLine($"{fileType}\t{directoryName}\t{directoryDate}");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка создания info.csv: {ex.Message}");
            }

            //удаляю
            Directory.Delete(destDirName, true);


            //сохраняю путь
            try
            {
                using (StreamWriter writer = new StreamWriter(SavePathName))
                {
                    writer.WriteLine(InfoFileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }


        }
        //вторая программа
        static void Mains (string[] args)
        {
            const string SavePathName = @"D:\HomeWork\HW5\Lesson5Homework.txt";
            string InfoFilePath = "";

            // считываю путь
            try
            {
                using (StreamReader reader = new(SavePathName))
                {
                    InfoFilePath = reader.ReadLine();
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
                using (StreamReader reader = new(InfoFilePath))
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
          
            File.Delete(SavePathName);
        }
    }

    public class FileData
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}