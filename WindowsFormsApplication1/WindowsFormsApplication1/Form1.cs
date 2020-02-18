using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security;



namespace WindowsFormsApplication1
{
 

    public partial class Form1 : Form
    {
        // Constants 
        public const int Frequency = 1;
        public const int Real = 2;
        public const int Imaginary = 3;

        public Form1()
        {
            InitializeComponent();
        }

        private void SetRichTextDestination(string text)
        {
            richTextDestination.Text = text;
        }
        
        private void SetRichTextPreview(string text)
        {
            richTextPreview.Text = text;
        }

        private void SetRichTextDestinationAdd(string text)
        {
             richTextDestination.Text += text;
        }

        private void ReadLineByLine(string fileName)
        {
            string line;
            int counter = 0;
            string resultLine = "";
            
            char delimiter =' ';
            System.IO.StreamReader file = new System.IO.StreamReader(fileName);
            System.IO.StreamWriter fileWriter = new StreamWriter("C:/Users/Robert D McI/Source/Repos/Merging-Files/WindowsFormsApplication1/WindowsFormsApplication1/testFile.txt");
            
            while ((line = file.ReadLine()) != null)
            {
                if (counter == 0)
                {
                    SetRichTextDestinationAdd("100\n");
                    fileWriter.WriteLine("100");
                }
                if (counter > 0)
                {
                    resultLine = "";
                    string[] values = line.Split(delimiter);
                    resultLine += counter + " ";
                    resultLine += values[Real] + " ";
                    resultLine += values[Imaginary] + " ";
                    resultLine += values[Frequency];

                    fileWriter.WriteLine(resultLine);

                    SetRichTextDestinationAdd(resultLine+"\n");
                }
                counter++;
            }
            fileWriter.Close();
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(openFileDialog1.FileName);
                    SetRichTextPreview(sr.ReadToEnd());
                    string fileLocation = openFileDialog1.FileName;
                    ReadLineByLine(fileLocation);
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
    }
}
