using System;
using System.IO;
using System.Threading.Tasks;

namespace stresstest.Services
{
    public class FileService
    {
        public FileService()
        {
        }

        public async Task<bool> WriteFile(string fileName,string content)
        {

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{fileName}.txt");
            var text = string.Empty;
            //File.WriteAllText(path, content);

            using (var writer = new StreamWriter(path))
            {
                await writer.WriteLineAsync(content);
            }

            using (var reader = new StreamReader(path))
            {
                text = await reader.ReadToEndAsync();
            }
            Console.WriteLine(text);

            //var text = File.ReadAllText(path);
            if (text != string.Empty || text != null) 
                return await Task.FromResult(true);
            else
                return await Task.FromResult(false);

        }
    }
}
