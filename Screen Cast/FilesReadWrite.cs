using System;
using System.IO;

namespace Screen_Cast
{
    class FilesReadWrite
    {
        string MainFile = @"C:/Program Files/Screen Cast";
        string path = @"C:/Program Files/Screen Cast/Path.txt";
        string path2 = @"C:/Program Files/Screen Cast/HotKey.txt";
        public void Write(string pathToFile)
        {
            if (!File.Exists(path)) //Проверка файла на наличие
                File.WriteAllText(path, pathToFile);

            else
            {
                if (pathToFile != "")
                {
                    File.Delete(path); //Удаление файла для перезаписи
                    File.AppendAllText(path, pathToFile); //Перезапись
                }
            }

            DirectoryInfo df = new DirectoryInfo(MainFile);
            if (!df.Exists) //Проверка файла на наличме
                df.Create();

                  
        }
        public string Read()
        {
            if (!File.Exists(path)) //Проверка файла на наличие
                File.WriteAllText(path, "");
            string s;
                using (StreamReader sr = new StreamReader(path))
                {
                    s = sr.ReadToEnd();
                }
            return s;
        }

       
        public void Write2(string pathToFile)
        {
            if (!File.Exists(path2)) //Проверка файла на наличме
                File.WriteAllText(path2, pathToFile);
            else
            {
                if (pathToFile != "")
                {
                    File.Delete(path2); //Удаление файла для перезаписи
                    File.AppendAllText(path2, pathToFile); //Перезапись
                }
            }
        }
        public string Read2()
        {
            if (!File.Exists(path2)) //Проверка файла на наличие
                File.WriteAllText(path2, "");
            string s;
            using (StreamReader sr = new StreamReader(path2))
            {
                s = sr.ReadToEnd();
            }
            return s;
        }

    }
}
