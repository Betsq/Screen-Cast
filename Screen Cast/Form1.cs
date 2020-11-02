using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screen_Cast
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string PathFileToSave;//Переменная для сохранение пути файла, чтобы записать в файл
            //Выбор пути куда сохранять файлы
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK) { }
            PathFileToSave = fbd.SelectedPath;

            FilesCreReadWri f = new FilesCreReadWri(); //Создание экземпляра класса для записи пути 
            f.Write(PathFileToSave);//Запись пути
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FilesCreReadWri f = new FilesCreReadWri();//Создание экземпляра класса для считывание файла
            string FSave = f.Read();//Считывание файла


            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            String SetDateTime = DateTime.Now.ToString("yyyy.MM.dd_HH-mm-ss");
            printscreen.Save(FSave + "/" + SetDateTime + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
