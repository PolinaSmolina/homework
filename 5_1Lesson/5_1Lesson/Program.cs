using System.IO.Compression;

namespace HW5_1
{
    public static class Program
    {//первая программа
        public static void Main(string[] args)
        {
            const string sourceFileName = @"D:\HomeWork\HW5\Archive.zip";
            const string destDirName = @"D:\HomeWork\HW5\DirForArchive";
            const string infoFileName = @"D:\HomeWork\HW5\Info.csv";
            const string savePathName = @"D:\HomeWork\HW5\Lesson5Homework.txt";

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
                using (StreamWriter writer = new StreamWriter(infoFileName, false))
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
                using (StreamWriter writer = new StreamWriter(savePathName))
                {
                    writer.WriteLine(infoFileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }


        }
        
    }
}