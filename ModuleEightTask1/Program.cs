namespace ModuleEightTask1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetFolder();
        }

        static void GetFolder()
        {
            Console.Write("Введите адрес папки: ");
            var FolderName = Console.ReadLine();
            var dir = new DirectoryInfo(FolderName);

            if (Directory.Exists(FolderName)) 
            {
                try
                {
                    foreach (FileInfo file in dir.GetFiles())
                    {
                        /// проверяем время последнего обращения к файлу
                        if (DateTime.Now - file.LastAccessTime >= TimeSpan.FromMinutes(30))
                        {
                            file.Delete();
                            Console.WriteLine($"Файл {file.Name} удалён");
                        }
                        else
                            Console.WriteLine($"Не удалось удалить файл {file.Name}");
                    }

                    foreach (DirectoryInfo direct in dir.GetDirectories())
                    {
                        /// проверяем время последнего обращения к папке
                        if (DateTime.Now - direct.LastAccessTime >= TimeSpan.FromMinutes(30))
                        {
                            direct.Delete(true); /// удаление папки со всем содержимым
                            Console.WriteLine($"Папка {direct.Name} удалена");
                        }
                        else
                            Console.WriteLine($"Не удалось удалить папку {direct.Name}");
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"Не удалось удалить папку: {ex}");
                }
            }
        }
    }
}
