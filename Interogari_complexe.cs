using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Biblioteca
{
    public partial class Interogari_complexe : Form
    {
        public Interogari_complexe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            // Stringul de conexiune la baza de date
            string connString = "Data Source = DESKTOP-24A32IQ\\SQLEXPRESS; Initial Catalog=Biblioteca; Integrated Security = True";
            //Afișați autorii care au un număr minim(2) de cărți publicate și data de naștere înainte de 1990.       
            string queryString = @"
                SELECT
                    A.AutorID,
                    A.Nume,
                    A.Prenume,
                    (SELECT COUNT(*) FROM CarteAutor WHERE AutorID = A.AutorID) AS NumarCartiPublicate,
                    A.DataNastere
                FROM Autor A
                WHERE
                    (SELECT COUNT(*) FROM CarteAutor WHERE AutorID = A.AutorID) >= 2
                    AND YEAR(A.DataNastere) < 1990;
            ";
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
            //Afișați informații despre împrumuturi, inclusiv numele clientului și titlul cărții, pentru împrumuturile care au fost returnate înainte de data estimată.     
            string queryString = @"
                SELECT
                    I.ImprumutID,
                    (SELECT Nume FROM Client WHERE ClientID = I.ClientID) AS NumeClient,
                    (SELECT Prenume FROM Client WHERE ClientID = I.ClientID) AS PrenumeClient,
                    (SELECT Titlu FROM Carte WHERE CarteID = I.CarteID) AS TitluCarte,
                    I.DataImprumut,
                    I.DataRestituireEstimata,
                    I.DataRestituireReala
                FROM Imprumut I
                WHERE I.DataRestituireReala < I.DataRestituireEstimata;
            ";

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
            //Afișați autorii care au colaborat la cărți cu cel puțin doi co-autori.     
            string queryString = @"
                SELECT DISTINCT
                    A.AutorID,
                    A.Nume,
                    A.Prenume
                FROM Autor A
                WHERE A.AutorID IN (SELECT AutorID FROM CarteAutor WHERE RolAutor = 'Co-autor' GROUP BY AutorID HAVING COUNT(*) >= 2);
            ";

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

        private void button6_Click(object sender, EventArgs e)
        {
            // Stringul de conexiune la baza de date
            string connString = "Data Source = DESKTOP-24A32IQ\\SQLEXPRESS; Initial Catalog=Biblioteca; Integrated Security = True";
            //Afișează numele editurilor și numărul total de cărți publicate de fiecare editură
            // Obțineți valoarea din TextBox
            // Obțineți valoarea din TextBox pentru data minimă de naștere
            DateTime dataMinimaNastere = DateTime.Parse(textBox1.Text);

            // Construiți interogarea SQL
            string queryString = @"
                SELECT
                C.Nume AS NumeClient,
                (
                    SELECT TOP 1 A.Nume + ' ' + A.Prenume
                    FROM Autor A
                    JOIN CarteAutor CAu ON A.AutorID = CAu.AutorID
                    WHERE CAu.CarteID = CA.CarteID
                ) AS NumeAutor,
                CA.Titlu AS TitluCarte,
                I.DataImprumut,
                I.DataRestituireEstimata,
                I.DataRestituireReala
            FROM Imprumut I
            JOIN Client C ON I.ClientID = C.ClientID
            JOIN Carte CA ON I.CarteID = CA.CarteID
            WHERE I.DataImprumut >= @DataMinimaImprumut;
        ";


            // Crearea conexiunii și a obiectului SqlCommand
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                // Adăugarea parametrului la comandă
                command.Parameters.AddWithValue("@DataMinimaImprumut", dataMinimaNastere);
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
    

