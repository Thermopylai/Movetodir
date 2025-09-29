namespace Movetodir
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("\nUsage: movetodir <file_name> <directory>\n");
            } 
            else
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                Console.WriteLine($"\nThe current directory is '{currentDirectory}'.\n");
                var path = Path.Combine(currentDirectory, args[1]);
                var moveFiles = Directory.EnumerateFiles(currentDirectory, args[0]);
                if (moveFiles.Count() == 0)
                {
                    Console.WriteLine($"{args[0]} can't be found in the current directory.\n");
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                    return;
                }
                else if (!Directory.Exists(path))
                {
                    Console.WriteLine($"Directory '{path}' doesn't exist.\nCreate directory? y/n\n");
                    string? response = Console.ReadLine();
                    if (response != null && response.ToLower() == "y")
                    {
                        Directory.CreateDirectory(path);
                        Console.WriteLine($"\nDirectory '{path}' created.\n");
                    }
                    else
                    {
                        Console.WriteLine("\nOperation aborted.\n");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    }
                }
                else
                {
                    try
                    {
                        int i = 0;
                        foreach (var currentFile in moveFiles)
                        {
                            string fileName = currentFile.Substring(currentDirectory.Length + 1);
                            Directory.Move(currentFile, Path.Combine(path, fileName));
                            i++;
                        }
                        Console.WriteLine($"{i} files moved to '.\\{args[1]}'.\n");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"{e.Message}\n");
                    }
                }
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
