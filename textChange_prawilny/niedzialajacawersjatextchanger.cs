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
            comboBox1.Items.Insert(0, "*.txt*");
            comboBox1.Items.Insert(1, "*.rtf*");
            comboBox1.Items.Insert(2, "*.doc*");
            //change.textChangeWith = textBox2.Text;
            //change.textSearchFor = textBox1.Text;
            
                       
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
            if (directoryToTraverse != null)
            { ReplaceText_Folder(); }
            if (change.name != null)
            { ReplaceText_File(); }
                                         
        }
        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string added_extention = textBox3.Text;
            if (comboBox1.Text.Contains(added_extention))
                {
                    MessageBox.Show("Extention already exist");
                }
            else
                comboBox1.Items.Add(added_extention);
           
        }
        public void FindFolder()
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            DialogResult result = folderBrowserDialog1.ShowDialog();


            if (result == DialogResult.OK)
            {
                
                // The user selected a folder and pressed the OK button.
                // We print the number of files found.
                //DirectoryInfo dir = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
                files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                directoryToTraverse = folderBrowserDialog1.SelectedPath;

                MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
            }
        }
        public void FindFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @"c:\\";
            /*if (comboBox1.SelectedItem != null)
            {
                openFileDialog1.Filter = "(*"+comboBox1.SelectedItem.ToString()+"|*" + comboBox1.SelectedItem.ToString()+"|";
            }
             * */
            
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|" + "All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                change.name = openFileDialog1.FileName;

            }
        }

        public void ReplaceText_Folder() 
        {
            
                      
           change.textChangeWith = textBox2.Text;
           change.textSearchFor = textBox1.Text;

                 
            try
            {
                string fileTypeToOpen;
                // what files to open
                /*if (comboBox1.SelectedItem != null)
                {
                    fileTypeToOpen = comboBox1.SelectedItem.ToString();
                }
                */
                //else
                //{ 
                    fileTypeToOpen = "*.*";
                //}
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
            catch (IOException)
            {
                MessageBox.Show("Exception ex is handled");
            }
          

        }
        public void ReplaceText_File()
        {
            change.textChangeWith = textBox2.Text;
            change.textSearchFor = textBox1.Text;
            try
            {
                var content = string.Empty;
                using (StreamReader reader = new StreamReader(change.name))
                {
                    content = reader.ReadToEnd();
                    reader.Close();
                }

                content = Regex.Replace(content, change.textSearchFor, change.textChangeWith);

                using (StreamWriter writer = new StreamWriter(change.name))
                {
                    writer.Write(content);
                    writer.Close();
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Exception ex is handled");
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void open_file_Click(object sender, EventArgs e)
        {
            FindFile();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
 