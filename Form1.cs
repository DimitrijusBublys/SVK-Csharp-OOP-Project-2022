namespace projektasSlaptazodziai
{
    public partial class Form1 : Form
    {
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
            string connectionString =
                "Data Source=localhost; Initial Catalog=project; Trusted_Connection=True; TrustServerCertificate=True";
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

        private void button2_Click(object sender, EventArgs e) // Slaptazodzio generavimas
        {
            bool emptyText = false;
            int capitalLetters = 0;
            int smallLetters = 0;
            int digits = 0;
            int specialChar = 0;

            // Lauku tikrinimas(ar irasytas skaicius, ar laukas ne tuscias)

            //-------------------------------------------

            if (textBox2.Text.All(char.IsDigit) && !String.IsNullOrEmpty(textBox2.Text))
            {
                capitalLetters = int.Parse(textBox2.Text);
            }
            else
            {
                MessageBox.Show("Laukas Capital Letters tuðèias arba áraðytas ne skaièius!");
                emptyText = true;
            }

            if (textBox3.Text.All(char.IsDigit) && !String.IsNullOrEmpty(textBox3.Text))
            {
                smallLetters = int.Parse(textBox3.Text);
            }
            else
            {
                MessageBox.Show("Laukas Small Letters tuðèias arba áraðytas ne skaièius!");
                emptyText = true;
            }

            if (textBox4.Text.All(char.IsDigit) && !String.IsNullOrEmpty(textBox4.Text))
            {
                digits = int.Parse(textBox4.Text);
            }
            else
            {
                MessageBox.Show("Laukas Digits tuðèias arba áraðytas ne skaièius!");
                emptyText = true;
            }

            if (textBox4.Text.All(char.IsDigit) && !String.IsNullOrEmpty(textBox5.Text))
            {
                specialChar = int.Parse(textBox5.Text);
            }
            else
            {
                MessageBox.Show("Laukas Special Characters tuðèias arba áraðytas ne skaièius!");
                emptyText = true;
            }

            //-------------------------------------------


            if (!emptyText) // Jeigu visi laukai aprasyti
            {
                MessageBox.Show("rimtega");
            }
        }
    }
}