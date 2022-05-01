using Microsoft.Data.SqlClient;
using System.Data;

namespace projektasSlaptazodziai
{
    public partial class Form1 : Form
    {
        readonly string connectionString =
                "Data Source=localhost; Initial Catalog=project; Trusted_Connection=True; TrustServerCertificate=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // Master password
        {
            string password = textBox1.Text;
            int dbEmpty; // Ar duomenu bazes lentele su master slaptazodziu tuscia
            if (String.IsNullOrEmpty(password))
            {
                MessageBox.Show("Áveskite slaptaþodá!");
            }
            else
            {
                dbEmpty = Database.CheckEmptyTable(connectionString);
                if (dbEmpty == 0) // Jeigu nera master password
                {
                    Database.GenerateMasterPassword(connectionString, password);
                    MessageBox.Show("Slaptaþodis áraðytas á duomenø bazæ!");
                }
                else // Master password tikrinimas
                {
                    bool result = Database.CheckCorrectPassword(connectionString, password);
                    if (result)
                    {
                        MessageBox.Show("Prisijungëte!");
                    }
                    else
                    {
                        MessageBox.Show("Ávestas slaptaþodis neteisingas!");
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) // Slaptazodzio generavimas ir tikrinimas, ar prisijungta prie DB
        {
            bool emptyText = false;
            int capitalTimes = 0;
            int smallTimes = 0;
            int digitsTimes = 0;
            int specialCharTimes = 0;


            string password = textBox1.Text;

            if (String.IsNullOrEmpty(password))
            {
                MessageBox.Show("Áveskite slaptaþodá!");
            }
                else
                {
                    int dbEmpty = Database.CheckEmptyTable(connectionString);
                    if (dbEmpty == 0) 
                    {
                        MessageBox.Show("Sukurkite slaptaþodá!");
                    }
                    else
                    {
                        bool result = Database.CheckCorrectPassword(connectionString, password); // Tikriname, ar slaptazodis vis dar ivestas
                        if (result)
                        {
                            // Lauku tikrinimas(ar irasytas skaicius, ar laukas ne tuscias)

                            //-------------------------------------------

                            if (textBox2.Text.All(char.IsDigit) && !String.IsNullOrEmpty(textBox2.Text))
                            {
                                capitalTimes = int.Parse(textBox2.Text);
                            }
                            else
                            {
                                MessageBox.Show("Laukas Capital Letters tuðèias arba áraðytas ne skaièius!");
                                emptyText = true;
                            }

                            if (textBox3.Text.All(char.IsDigit) && !String.IsNullOrEmpty(textBox3.Text))
                            {
                                smallTimes = int.Parse(textBox3.Text);
                            }
                            else
                            {
                                MessageBox.Show("Laukas Small Letters tuðèias arba áraðytas ne skaièius!");
                                emptyText = true;
                            }

                            if (textBox4.Text.All(char.IsDigit) && !String.IsNullOrEmpty(textBox4.Text))
                            {
                                digitsTimes = int.Parse(textBox4.Text);
                            }
                            else
                            {
                                MessageBox.Show("Laukas digitsTimes tuðèias arba áraðytas ne skaièius!");
                                emptyText = true;
                            }

                            if (textBox4.Text.All(char.IsDigit) && !String.IsNullOrEmpty(textBox5.Text))
                            {
                                specialCharTimes = int.Parse(textBox5.Text);
                            }
                            else
                            {
                                MessageBox.Show("Laukas Special Characters tuðèias arba áraðytas ne skaièius!");
                                emptyText = true;
                            }

                            //-------------------------------------------


                            if (!emptyText) // Jeigu visi laukai aprasyti
                            {
                                string generatedPassword = PasswordGenerator.GeneratePassword(capitalTimes, smallTimes, digitsTimes, specialCharTimes);
                                MessageBox.Show("Slaptaþodis sugeneruotas!");
                                textBox7.Text = generatedPassword; 
                            }

                        }
                        else
                        {
                            MessageBox.Show("Ávestas slaptaþodis neteisingas!");
                        }
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e) // Irasymas i DB
        {
            string password = textBox1.Text;
            string namePw = textBox6.Text;
            string generatedPassword = textBox7.Text;

            if (String.IsNullOrEmpty(password))
            {
                MessageBox.Show("Áveskite slaptaþodá!");
            }
            else
            {
                int dbEmpty = Database.CheckEmptyTable(connectionString);
                if (dbEmpty == 0)
                {
                    MessageBox.Show("Sukurkite slaptaþodá!");
                }
                else
                {
                    bool result = Database.CheckCorrectPassword(connectionString, password); // Tikriname, ar slaptazodis vis dar ivestas
                    if (result)
                    {
                        if (!String.IsNullOrEmpty(namePw) && !String.IsNullOrEmpty(generatedPassword)) // Jeigu viskas ok
                        {
                            Database.AddDataToDB(connectionString, namePw, generatedPassword);
                            MessageBox.Show("Duomenys áraðyti á duomenø bazæ!");
                        }
                        else if (String.IsNullOrEmpty(namePw))
                        {
                            MessageBox.Show("Laukas Name tuðèias!");
                        }
                        else if (String.IsNullOrEmpty(generatedPassword))
                        {
                            MessageBox.Show("Laukas Generated password tuðèias!");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Ávestas slaptaþodis neteisingas!");
                    }
                }
            }
        }
        private void textBox6_TextChanged(object sender, EventArgs e) 
        {

        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e) // Ziureti DB irasus
        {
            string password = textBox1.Text;
            string sqlQuery;
            if (String.IsNullOrEmpty(password))
            {
                MessageBox.Show("Áveskite slaptaþodá!");
            }
            else
            {
                int dbEmpty = Database.CheckEmptyTable(connectionString);
                if (dbEmpty == 0)
                {
                    MessageBox.Show("Sukurkite slaptaþodá!");
                }
                else
                {
                    bool result = Database.CheckCorrectPassword(connectionString, password); // Tikriname, ar slaptazodis vis dar ivestas
                    if (result)
                    {
                        if (checkBox1.Checked)
                        {
                            sqlQuery = "SELECT * FROM generated_password";
                        }
                        else
                        {
                            sqlQuery = "SELECT id, pw_name, date_created, time_created FROM generated_password";
                        }
                        SqlConnection connection = new SqlConnection(connectionString);
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(sqlQuery, connection);

                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Ávestas slaptaþodis neteisingas!");
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}