using System.IO.Compression;

namespace HW6_1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            const string sourceFileName = @"D:\HomeWork\HW6\Archive.zip";
            const string destDirName = @"D:\HomeWork\HW6\DirForArchive";
            const string infoFileName = @"D:\HomeWork\HW6\Info.csv";
            const string savePathName = @"D:\HomeWork\HW6\Lesson5Homework.txt";

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
                        await writer.WriteLineAsync($"{fileType}\t{fileName}\t{fileDate}");
                    }
                    // директория
                    foreach (string directory in directories)
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                        string fileType = "Directory";
                        string directoryName = directoryInfo.Name;
                        string directoryDate = directoryInfo.LastWriteTime.ToString();
                        await writer.WriteLineAsync($"{fileType}\t{directoryName}\t{directoryDate}");
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
                    await writer.WriteLineAsync(infoFileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }


        }

    }
}