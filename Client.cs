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

namespace Biblioteca
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conString = "Data Source = DESKTOP-24A32IQ\\SQLEXPRESS; Initial Catalog=Biblioteca; Integrated Security = True";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Nume,Prenume,CNP,Judet,Oras,Strada,NrStrada,NrTelefon from Client", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void RefreshDataGridView()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-24A32IQ\\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True"))
            {
                connection.Open();

                string query = "SELECT Nume, Prenume, CNP, Judet,Oras,Strada,NrStrada,NrTelefon FROM Client";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        // Crearea unui DataSet pentru a stoca datele
                        DataSet dataSet = new DataSet();

                        // Umplerea DataSet-ului cu datele din baza de date
                        adapter.Fill(dataSet, "Client");

                        // Setarea sursei de date pentru DataGridView
                        dataGridView1.DataSource = dataSet.Tables["Client"];
                    }
                }
            }
        }

        private void buttonInsert_Click_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-24A32IQ\\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True"))
            {
                connection.Open();

                string query = "INSERT INTO Client (Nume, Prenume, CNP, Judet,Oras,Strada,NrStrada,NrTelefon) VALUES (@Nume, @Prenume, @CNP, @Judet, @Oras, @Strada, @NrStrada, @NrTelefon )";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Nume", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Prenume", textBox2.Text);
                    cmd.Parameters.AddWithValue("@CNP", textBox8.Text);
                    cmd.Parameters.AddWithValue("@Judet", textBox7.Text);
                    cmd.Parameters.AddWithValue("@Oras", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Strada", textBox5.Text);
                    cmd.Parameters.AddWithValue("@NrStrada", textBox4.Text);
                    cmd.Parameters.AddWithValue("@NrTelefon", textBox3.Text);

                    cmd.ExecuteNonQuery();
                }

                // După inserare, reîncărcați datele în DataGridView pentru a reflecta modificările
                RefreshDataGridView();
            }
        }

        private void buttonDelete_Click_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-24A32IQ\\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True"))
            {
                connection.Open();

                string query = "DELETE FROM Client WHERE Nume = @Nume AND Prenume = @Prenume";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Nume", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Prenume", textBox2.Text);

                    cmd.ExecuteNonQuery();
                }

                // După ștergere, reîncărcați datele în DataGridView pentru a reflecta modificările
                RefreshDataGridView();
            }
        }

        private void buttonUpdate_Click_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-24A32IQ\\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True"))
            {
                connection.Open();

                string query = "UPDATE Client SET CNP = @CNP, Judet = @Judet , Oras = @Oras, Strada=@Strada, NrStrada = @NrStrada, NrTelefon = @NrTelefon WHERE Nume = @Nume AND Prenume = @Prenume";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    
                    cmd.Parameters.AddWithValue("@CNP", textBox8.Text);
                    cmd.Parameters.AddWithValue("@Judet", textBox7.Text);
                    cmd.Parameters.AddWithValue("@Oras", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Strada", textBox5.Text);
                    cmd.Parameters.AddWithValue("@NrStrada", textBox4.Text);
                    cmd.Parameters.AddWithValue("@NrTelefon", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Nume", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Prenume", textBox2.Text);

                    cmd.ExecuteNonQuery();
                }

                // După actualizare, reîncărcați datele în DataGridView pentru a reflecta modificările
                RefreshDataGridView();
            }
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }
    }
}
