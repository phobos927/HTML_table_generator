using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using WPFFolderBrowser;


namespace HTML_table_generator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            WPFFolderBrowserDialog open = new WPFFolderBrowserDialog();
            bool sd = Convert.ToBoolean(open.ShowDialog());
            if (sd)
            {
                path = open.FileName;
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (path != null)
            {
                string[] imgmass = Directory.GetFiles(path).Select(file => System.IO.Path.GetFileName(file)).ToArray();
                string spath = textBoxP.Text;
                int width = Convert.ToInt32(textBoxW.Text);
                int height = Convert.ToInt32(textBoxH.Text);
                int kol = Convert.ToInt32(textBoxС.Text);

                int schet = 0;
                int schet2 = 0;
                using (StreamWriter outputFile = new StreamWriter("Code.txt"))
                {
                    foreach (string img in imgmass)
                    {
                        schet2++;
                        if ((img.Substring(img.Length - 4) == ".jpg") || (img.Substring(img.Length - 4) == ".png") || (img.Substring(img.Length - 4) == ".gif"))
                        {
                            schet++;
                           
                            if (schet == 1)
                            {
                                outputFile.WriteLine("<tr>");
                            }

                            outputFile.Write("<td style=\"border-image: initial;\"><a rel=\"lightbox-cats\" href=\"");
                            if (spath.Substring(0, 1) != "/")
                            {
                                outputFile.Write("/");

                            }
                            outputFile.Write(spath);
                            if (spath.Substring(spath.Length - 1, 1) != "/")
                            {
                                outputFile.Write("/");
                            }
                            outputFile.Write(img);
                            outputFile.Write("\" ><img width=\"");
                            outputFile.Write(width);
                            outputFile.Write("\" height=\"");
                            outputFile.Write(height);
                            outputFile.Write("\" src=\"");
                            //
                            if (spath.Substring(0, 1) != "/")
                            {
                                outputFile.Write("/");

                            }
                            outputFile.Write(spath);
                            if (spath.Substring(spath.Length - 1, 1) != "/")
                            {
                                outputFile.Write("/");
                            }
                            //
                            outputFile.Write(img);
                            outputFile.WriteLine("\"  /></a></td>");
                        }
                            if (schet == kol || schet2 == imgmass.Length)
                            {
                                outputFile.WriteLine("</tr>");
                                schet = 0;
                            }
                        
                    }

                        MessageBox.Show("Файл создан");
                    
                }
            }
            else { MessageBox.Show("Вы не выбрали папку"); }

            }
        }
    }

