using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Кт_4
{
    public class FileManager
    {
        public string ReadFile(string filePath)
        {
            string content = string.Empty;
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    content = reader.ReadToEnd();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Файл не найден: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Нет доступа к файлу: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            return content;
        }

        public string WriteFile(string filePath, string content)
        {
            string result = "Файл успешно записан.";
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(filePath);
                writer.Write(content);
                
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Файл не найден: {ex.Message}");
                result = "Файл не найден.";
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Нет доступа к файлу: {ex.Message}");
                result = "Нет доступа к файлу.";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                result = "Произошла ошибка при записи файла.";
            }
            finally
            {
                if ( writer != null )
                {
                    writer.Close();
                }
            }
            if (result == "Файл успешно записан.")
            {
                try
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        result = reader.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                    result = "Произошла ошибка при чтении файла.";
                }
                
            }

            return result;
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                FileManager fileManager = new FileManager();

                string readFilePath = @"C:\Users\porya\Desktop\ithub\база данных\ms sql\Кт\NewFile.txt";
                string content = fileManager.ReadFile(readFilePath);
                Console.WriteLine("Содержимое файла:");
                Console.WriteLine(content);
                string writeFilePath = @"C:\Users\porya\Desktop\ithub\база данных\ms sql\Кт\OutputFile.txt";

                string result = fileManager.WriteFile("output.txt", "Привет, мир!");
                Console.WriteLine(result);
                result = fileManager.WriteFile(writeFilePath, "Привет, мир!");
                Console.WriteLine(result);
                Console.ReadLine();
            }
        }
    }
}
