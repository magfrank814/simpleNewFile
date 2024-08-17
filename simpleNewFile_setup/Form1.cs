using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace simpleNewFile_setup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = Installpath;
            
            DriveInfo driveInfo = new DriveInfo("C");  

            if (driveInfo.IsReady)  
            {  

                double totalSpaceGB = driveInfo.TotalSize / (1024.0 * 1024.0 * 1024.0);  
                double freeSpaceGB = driveInfo.AvailableFreeSpace / (1024.0 * 1024.0 * 1024.0);  
                stor = $"{freeSpaceGB:F2}GB / {totalSpaceGB:F2}GB";
                label3.Text = "It takes up about 1MB of disk space    Remaining disk space: "+stor;
            }  
            else  
            {  
                Console.WriteLine($"error");  
            }  
        }

        private string Installpath = "C:\\Program Files\\simpleNewFile";
        private string stor = "";
        
        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "请选择文件夹";
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.ShowNewFolderButton = true;
            if (textBox1.Text.Length > 0) folderBrowserDialog1.SelectedPath = textBox1.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Installpath = folderBrowserDialog1.SelectedPath;
                string driveLetter = Path.GetPathRoot(Installpath);  
  

                driveLetter = driveLetter.TrimEnd('\\');  
  
                DriveInfo driveInfo = new DriveInfo(driveLetter);  
  

                if (driveInfo.IsReady)  
                {  

                    double totalSpaceGB = driveInfo.TotalSize / (1024.0 * 1024.0 * 1024.0);  
                    double freeSpaceGB = driveInfo.AvailableFreeSpace / (1024.0 * 1024.0 * 1024.0);  
  
                    
                    stor = $"{freeSpaceGB:F2}GB / {totalSpaceGB:F2}GB";
                    label3.Text = "It takes up about 1MB of disk space    Remaining disk space: "+stor;
                }  
                textBox1.Text = Installpath;
                
            }

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i=0;i<21;i=i+1)
            {
                progressBar1.Value = i;
            }

            if (Installpath == "C:\\")
            {
                Form error = new error();
                error.Show();
                progressBar1.Value=0;
            }
            else
            {
                if (!Directory.Exists(Installpath))  
                {  
                    Directory.CreateDirectory(Installpath);  
                    
                }
                for(int i = 20; i < 41; i = i + 1)
                {
                    progressBar1.Value = i;
                }
                for(int i = 40;i<81;i=i + 1)
                {
                    progressBar1.Value = i;
                }
                for(int i = 80;i<101;i= i + 1)
                {
                    progressBar1.Value = i;
                }
                // function.ExtractResFile("simpleNewFile_setup.appmain.test.txt", Path.Combine(Installpath, "test.txt"));
                if (progressBar1.Value == 100)
                {
                    Form suc = new Completed();
                    
                    suc.Show();
                    
                    
                }
                
                
                
                
                
                
                
                

            }
        }
    }
}