using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // створюємо екземпляр класу для відкритого підлючення до БД sql
        private SqlConnection sqlConnection = null;
        // створюємо екземпляр класу для роботи із даними, які будуть отримані в результаті запитів до бд, та їх трансформації (приведення до необхідного типу) для відображення та роботи з ними
        private SqlDataAdapter adapter = null;
        // створюємо екземпляр класу для представлення таблиці в пам'яті комп'ютера, тобто у відповідній структі данних
        private DataTable table = null;

        private void button1_Click(object sender, EventArgs e)
        {
            // оновлення бд по кнопці додане опціонально хоч і в завданні про це не сказано

            // очищуємо нашу таблицю (тут все ок - вона точно не null оск. при завантаженні форми (див. нижче Form1_Load ) вона ініціалізується)
            table.Clear();
            // завантажує таблицю із пам'яті в об'єкт для відображення в dataGrid на формі
            adapter.Fill(table);
            // заповнюємо елемент на формі цією таблицею
            dataGridView1.DataSource = table;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ініціалізуємо підключення по ключу підключення
            sqlConnection = new SqlConnection(@"Data Source=DESKTOP-ITPQVOL\SQLEXPRESS;Initial Catalog=TestDatabase;Integrated Security=True");

            // відкриваємо підключення
            sqlConnection.Open();

            // запускаємо запи(1 параметр) у підключення(2 параметр) та записуємо результат у adapter
            adapter = new SqlDataAdapter("SELECT * FROM MyFriends",sqlConnection);
            // ініціалізуємо таблицю
            table = new DataTable();
            // завантажує таблицю із пам'яті в об'єкт для відображення в dataGrid на формі
            adapter.Fill(table);
            // заповнюємо елемент на формі цією таблицею
            dataGridView1.DataSource = table;



        }
    }
}
