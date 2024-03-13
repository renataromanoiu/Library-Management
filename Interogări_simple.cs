using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class Interogări_simple : Form
    {
        public Interogări_simple()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            // Stringul de conexiune la baza de date
            string connString = "Data Source = DESKTOP-24A32IQ\\SQLEXPRESS; Initial Catalog=Biblioteca; Integrated Security = True";
            //Această interogare afișează titlurile cărților, numele și prenumele autorilor de sex feminin care au avut rolul de traducător pentru acele cărți.
            string queryString = "SELECT C.Titlu, A.Nume, A.Prenume, CA.RolAutor " +
                                  "FROM CarteAutor CA " +
                                  "JOIN Carte C ON CA.CarteID = C.CarteID " +
                                  "JOIN Autor A ON CA.AutorID = A.AutorID " +
                                  "WHERE A.Sex = 'F' AND CA.RolAutor = 'Traductor';";


            // Crearea conexiunii și a obiectului SqlCommand
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                // Deschiderea conexiunii
                connection.Open();

                // Executarea comenzii SQL și citirea rezultatelor într-un obiect SqlDataReader
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Crearea unui obiect DataTable pentru a stoca rezultatele
                    System.Data.DataTable dataTable = new System.Data.DataTable();

                    // Umplerea DataTable cu datele din SqlDataReader
                    dataTable.Load(reader);

                    // Afișarea rezultatelor în DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            // Stringul de conexiune la baza de date
            string connString = "Data Source = DESKTOP-24A32IQ\\SQLEXPRESS; Initial Catalog=Biblioteca; Integrated Security = True";
            //Această interogare afișează informații despre împrumuturile care s-au produs într-un anumit interval de timp 
            string queryString = "SELECT CL.Nume AS NumeClient, CL.Prenume AS PrenumeClient, C.Titlu, I.DataImprumut, I.DataRestituireEstimata " +
                                 "FROM Imprumut I " +
                                 "JOIN Client CL ON I.ClientID = CL.ClientID " +
                                 "JOIN Carte C ON I.CarteID = C.CarteID " +
                                 "WHERE I.DataImprumut >= '2023-01-01' AND I.DataImprumut <= '2023-12-31';";


            // Crearea conexiunii și a obiectului SqlCommand
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                // Deschiderea conexiunii
                connection.Open();

                // Executarea comenzii SQL și citirea rezultatelor într-un obiect SqlDataReader
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Crearea unui obiect DataTable pentru a stoca rezultatele
                    System.Data.DataTable dataTable = new System.Data.DataTable();

                    // Umplerea DataTable cu datele din SqlDataReader
                    dataTable.Load(reader);

                    // Afișarea rezultatelor în DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Stringul de conexiune la baza de date
            string connString = "Data Source = DESKTOP-24A32IQ\\SQLEXPRESS; Initial Catalog=Biblioteca; Integrated Security = True";
            //Afișează numele și prenumele autorilor care au colaborat la cărți publicate de editura "Minerva".
            string queryString = @"SELECT Autor.Nume, Autor.Prenume
                             FROM Autor
                             JOIN CarteAutor ON Autor.AutorID = CarteAutor.AutorID
                             JOIN Carte ON CarteAutor.CarteID = Carte.CarteID
                             JOIN Editura ON Carte.EdituraID = Editura.EdituraID
                             WHERE Editura.Nume = 'Minerva';";

            // Crearea conexiunii și a obiectului SqlCommand
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                // Deschiderea conexiunii
                connection.Open();

                // Executarea comenzii SQL și citirea rezultatelor într-un obiect SqlDataReader
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Crearea unui obiect DataTable pentru a stoca rezultatele
                    System.Data.DataTable dataTable = new System.Data.DataTable();

                    // Umplerea DataTable cu datele din SqlDataReader
                    dataTable.Load(reader);

                    // Afișarea rezultatelor în DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Stringul de conexiune la baza de date
            string connString = "Data Source = DESKTOP-24A32IQ\\SQLEXPRESS; Initial Catalog=Biblioteca; Integrated Security = True";
            //Afișează titlurile cărților împrumutate, numele clienților și data estimată de restituire pentru împrumuturile returnate după data estimată
            string queryString = @"SELECT Carte.Titlu, Client.Nume + ' ' + Client.Prenume AS NumeClient, Imprumut.DataRestituireEstimata, Imprumut.DataRestituireReala
                             FROM Imprumut
                             JOIN Carte ON Imprumut.CarteID = Carte.CarteID
                             JOIN Client ON Imprumut.ClientID = Client.ClientID
                             WHERE Imprumut.DataRestituireReala > Imprumut.DataRestituireEstimata;";

            // Crearea conexiunii și a obiectului SqlCommand
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                // Deschiderea conexiunii
                connection.Open();

                // Executarea comenzii SQL și citirea rezultatelor într-un obiect SqlDataReader
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Crearea unui obiect DataTable pentru a stoca rezultatele
                    System.Data.DataTable dataTable = new System.Data.DataTable();

                    // Umplerea DataTable cu datele din SqlDataReader
                    dataTable.Load(reader);

                    // Afișarea rezultatelor în DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Stringul de conexiune la baza de date
            string connString = "Data Source = DESKTOP-24A32IQ\\SQLEXPRESS; Initial Catalog=Biblioteca; Integrated Security = True";
            //Afișează numele editurilor și numărul total de cărți publicate de fiecare editură
            string queryString = @"SELECT Editura.Nume, COUNT(Carte.CarteID) AS NumarCartiPublicate
                             FROM Editura
                             LEFT JOIN Carte ON Editura.EdituraID = Carte.EdituraID
                             GROUP BY Editura.Nume;";

            // Crearea conexiunii și a obiectului SqlCommand
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                // Deschiderea conexiunii
                connection.Open();

                // Executarea comenzii SQL și citirea rezultatelor într-un obiect SqlDataReader
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Crearea unui obiect DataTable pentru a stoca rezultatele
                    System.Data.DataTable dataTable = new System.Data.DataTable();

                    // Umplerea DataTable cu datele din SqlDataReader
                    dataTable.Load(reader);

                    // Afișarea rezultatelor în DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Stringul de conexiune la baza de date
            string connString = "Data Source = DESKTOP-24A32IQ\\SQLEXPRESS; Initial Catalog=Biblioteca; Integrated Security = True";
            //Afișează numele editurilor și numărul total de cărți publicate de fiecare editură
            // Obțineți valoarea din TextBox
            int numarMinimCarti = int.Parse(textBox1.Text);

            // Construiți interogarea SQL
            string queryString = @"
                SELECT
                    A.AutorID,
                    A.Nume,
                    A.Prenume,
                    COUNT(CA.CarteID) AS NumarCartiPublicate,
                    A.DataNastere
                FROM Autor A
                JOIN CarteAutor CA ON A.AutorID = CA.AutorID
                GROUP BY A.AutorID, A.Nume, A.Prenume, A.DataNastere
                HAVING COUNT(CA.CarteID) >= @NumarMinimCarti;
            ";

            // Crearea conexiunii și a obiectului SqlCommand
            using (SqlConnection connection = new SqlConnection(connString))
            {
                // Construirea comenzii SQL cu parametrul @NumarMinimCarti
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@NumarMinimCarti", numarMinimCarti);
                // Deschiderea conexiunii
                connection.Open();

                // Executarea comenzii SQL și citirea rezultatelor într-un obiect SqlDataReader
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Crearea unui obiect DataTable pentru a stoca rezultatele
                    System.Data.DataTable dataTable = new System.Data.DataTable();

                    // Umplerea DataTable cu datele din SqlDataReader
                    dataTable.Load(reader);
                    // Afișarea rezultatelor în DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
        }
    }
}
    

