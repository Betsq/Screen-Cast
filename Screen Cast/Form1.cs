using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Screen_Cast
{
    public partial class Form1 : Form
    {
        FilesReadWrite f = new FilesReadWrite();
        globalKeyboardHook gkh = new globalKeyboardHook();
        public Form1()
        {
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            label1.Text = f.Read();//Обновление label1 при запуске программы. Отображение пути сохранения скриншота.

            label3.Text = f.Read2();//Обновление label3 при запуске программы. Отображение горячой клавиши для скриншота.

            #region Checking hotkey selection for screenshot
            string sd = f.Read2();
            if(sd == "NumPad 0")
                gkh.HookedKeys.Add(Keys.NumPad0);
            else if (sd == "NumPad 1")
                gkh.HookedKeys.Add(Keys.NumPad1);
            else if (sd == "NumPad 2")
                gkh.HookedKeys.Add(Keys.NumPad2);
            else if (sd == "NumPad 3")
                gkh.HookedKeys.Add(Keys.NumPad3);
            else if (sd == "NumPad 4")
                gkh.HookedKeys.Add(Keys.NumPad4);
            else if (sd == "NumPad 5")
                gkh.HookedKeys.Add(Keys.NumPad5);
            else if (sd == "NumPad 6")
                gkh.HookedKeys.Add(Keys.NumPad6);
            else if (sd == "NumPad 7")
                gkh.HookedKeys.Add(Keys.NumPad7);
            else if (sd == "NumPad 8")
                gkh.HookedKeys.Add(Keys.NumPad8);
            else if (sd == "NumPad 9")
                gkh.HookedKeys.Add(Keys.NumPad9);
            gkh.KeyUp += new KeyEventHandler(button2_Click);
            #endregion

            //Отображение текста при сворачивание программы.
            notifyIcon1.BalloonTipTitle = "Screen Cast";
            notifyIcon1.BalloonTipText = "Screen Cast was folded";
            notifyIcon1.Text = "Screen Cast was folded";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK) { }//Вызов окна с выбором пути сохранения.
            f.Write(fbd.SelectedPath);//Запись в файл пути куда сохранять скриншот.

            label1.Text = f.Read();//Обновление label в реальном временни. Отображение пути сохранения скриншота.
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap printscreen = new Bitmap(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            String SetDateTime = DateTime.Now.ToString("yyyy.MM.dd_HH-mm-ss");
            printscreen.Save(f.Read() + "/" + SetDateTime + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = comboBox1.SelectedItem.ToString();//Запись в переменную выбранную горячию клавишу для скриншота.
            f.Write2(selectedState);//Запись в файл выбранной горячой клавиши.

            label3.Text = f.Read2();//Обновление label3 в реальном временни. Отображение горячой клавиши для скриншота
            
        }
        #region Trey
        //Cворачивание в трей
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;

        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
            }
            else if (FormWindowState.Normal == this.WindowState)
            { notifyIcon1.Visible = false; }
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
