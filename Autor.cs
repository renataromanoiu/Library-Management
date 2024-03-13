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
    public partial class Autor : Form
    {
        public Autor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conString = "Data Source = DESKTOP-24A32IQ\\SQLEXPRESS; Initial Catalog=Biblioteca; Integrated Security = True";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Nume,Prenume,Nationalitate,Sex,DataNastere  from Autor", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Autor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bibliotecaDataSet.Autor' table. You can move, or remove it, as needed.
            this.autorTableAdapter.Fill(this.bibliotecaDataSet.Autor);

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-24A32IQ\\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True"))
            {
                connection.Open();

                string query = "INSERT INTO Autor (Nume, Prenume, Nationalitate, Sex, DataNastere) VALUES (@Nume, @Prenume, @Nationalitate, @Sex, @DataNastere)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Nume", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@Prenume", textBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@Nationalitate", textBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@Sex", textBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@DataNastere", textBox5.Text.Trim());

                    try
                    {
                        cmd.ExecuteNonQuery();
                        // After insertion, refresh the data in the DataGridView to reflect the changes
                        RefreshDataGridView();
                    }
                    catch (SqlException ex)
                    {
                        // Handle the exception (e.g., display an error message)
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        // Metodă pentru a reîncărca datele în DataGridView
        private void RefreshDataGridView()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-24A32IQ\\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True"))
            {
                connection.Open();

                string query = "SELECT Nume, Prenume, Nationalitate, Sex, DataNastere FROM Autor";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        // Crearea unui DataSet pentru a stoca datele
                        DataSet dataSet = new DataSet();

                        // Umplerea DataSet-ului cu datele din baza de date
                        adapter.Fill(dataSet, "Autor");

                        // Setarea sursei de date pentru DataGridView
                        dataGridView1.DataSource = dataSet.Tables["Autor"];
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonDelete_Click_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-24A32IQ\\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True"))
                {
                    connection.Open();

                    string query = "DELETE FROM Autor WHERE Nume = @Nume AND Prenume = @Prenume";

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
        }

        private void buttonUpdate_Click_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-24A32IQ\\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True"))
            {
                connection.Open();

                string query = "UPDATE Autor SET Nationalitate = @Nationalitate, Sex = @Sex, DataNastere = @DataNastere WHERE Nume = @Nume AND Prenume = @Prenume";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Nationalitate", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Sex", textBox4.Text);
                    cmd.Parameters.AddWithValue("@DataNastere", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Nume", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Prenume", textBox2.Text);

                    cmd.ExecuteNonQuery();
                }

                // După actualizare, reîncărcați datele în DataGridView pentru a reflecta modificările
                RefreshDataGridView();
            }
        }
    }
}
