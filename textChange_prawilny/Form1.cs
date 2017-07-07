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

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*|";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openfileDialog1.GetDirectory
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                change.name = openFileDialog1.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            change.textSearchFor = textBox1.Text;
            change.textChangeWith = textBox2.Text;



            /*var content = string.Empty;
            using (StreamReader reader = new StreamReader(change.name))
            {
                content = reader.ReadToEnd();
                reader.Close();
            }

            content = Regex.Replace(content, change.textSearchFor, change.textChangeWith);
            //content = Regex.Replace(content, textBox1.Text, textBox2.Text);

            using (StreamWriter writer = new StreamWriter(change.name))
            {
                writer.Write(content);
                writer.Close();
                
            }
             * */
            DirSearch(openFileDialog1.);
                                
        }
        private  void DirSearch(string sDir)
        {
            try
            {
                foreach (var directory in Directory.GetDirectories(sDir))
                {
                    foreach (var filename in Directory.GetFiles(directory))
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

                    DirSearch(directory);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
       

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
           
        }

    }
}
