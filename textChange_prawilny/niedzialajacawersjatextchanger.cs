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
using System.Text.RegularExpressions;

namespace textChange_prawilny
{
    public partial class Form1 : Form
    {
        Changer change = new Changer();
        string[] files;
        string directoryToTraverse;
        

        public Form1()
        {
            InitializeComponent();
            change.name = "";
                       
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

              FindFolder();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReplaceText();
                                         
        }
        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
           
        }
        public void FindFolder()
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            DialogResult result = folderBrowserDialog1.ShowDialog();


            if (result == DialogResult.OK)
            {
                //
                // The user selected a folder and pressed the OK button.
                // We print the number of files found.
                //
                //DirectoryInfo dir = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
                files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                directoryToTraverse = folderBrowserDialog1.SelectedPath;

                MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
            }
        }
        public void FindFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|" + "All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;



            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                change.name = openFileDialog1.FileName;

            }
        }
        
        public void ReplaceText() 
        {
            
                      
           change.textChangeWith = textBox2.Text;
           change.textSearchFor = textBox1.Text;

                 
            try
            {
                
                // what files to open

                string fileTypeToOpen = "*.*";
                // what to look for

                //var regExp = new Regex(change.name);

                //  var regExp = new Regex(patternToMatch);

                // the new content
                //  var patternToReplace = @"<OutputPath>;C:\bin\$(Configuration)\</OutputPath>";

                //var allFiles = Directory.GetFiles(path, fileTypeToOpen, SearchOption.AllDirectories);
                var allFiles = Directory.GetFiles(directoryToTraverse, fileTypeToOpen, SearchOption.AllDirectories);

                foreach (var file in allFiles)

                {
                    // open, replace, overwrite
                    var content = File.ReadAllText(file);
                    content = Regex.Replace(content, change.textSearchFor, change.textChangeWith);
                    //var newContent = regExp.Replace(contents, patternToReplace);
                    //var newContent = Regex.Replace(content, change.textSearchFor, change.textChangeWith);

                   

                    File.WriteAllText(file, content);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception ex is handled"+ ex);
            }
          

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

    }
}
 