using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Microsoft.Win32;

namespace Heavy
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Console.WriteLine("That's all folks !");
            InitializeComponent();
        }

        private void monbouton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Filter = "Fichier Excel(*.xls)|*.xls*";
            string chemin = null;
            string script1 = File.ReadAllText(@"Rama.sql");
            string sqlConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDD;Integrated Security=True";

            if (open.ShowDialog() == true)
            {
                chemin = open.FileName;
            }
            
            string script = script1.Replace("chemin", chemin);
            // split script on GO command
            IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            SqlConnection conn = new SqlConnection(sqlConnectionString);
            conn.Open();
            foreach (string commandString in commandStrings)
            {
                if (commandString.Trim() != "")
                {
                    using (var command = new SqlCommand(commandString, conn))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            conn.Close();
            MessageBox.Show("Données ajoutées dans la BDD", "Importation données", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
