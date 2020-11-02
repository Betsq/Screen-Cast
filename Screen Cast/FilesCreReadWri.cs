using System;
using System.IO;

namespace Screen_Cast
{
    class FilesCreReadWri
    {
        string path = @"D:/path.txt";
        public void Write(string pathToFile)
        {
            if (!File.Exists(path)) //Проверка файла на наличме
                File.WriteAllText(path, pathToFile);
            else
            {
                if (pathToFile != "")
                {
                    File.Delete(path); //Удаление файла для перезаписи
                    File.AppendAllText(path, pathToFile); //Перезапись
                }         
            }            
        }
        public string Read()
        {
            string s;
                using (StreamReader sr = new StreamReader(path))
                {
                    s = sr.ReadToEnd();
                }
            return s;
        }
    }
}
