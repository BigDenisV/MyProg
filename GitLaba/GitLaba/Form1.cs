using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace GitLaba
{
    public partial class Form1 : Form
    {
        List<House> AllHouse = new List<House>();
        public string fileName = "DataBase.json";
        public string dir = AppDomain.CurrentDomain.BaseDirectory;
        public string fdir = AppDomain.CurrentDomain.BaseDirectory + "DataBase.json";
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(fdir))
            {
                AllHouse = JsonConvert.DeserializeObject<List<House>>(File.ReadAllText(fdir));
            }
            SetGrid(AllHouse);
         }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] a_n = new string[] { "Багратионовский проезд", "ул. Вавилова", "ул. Миля", "ул. Филипова", "ул. Солнечная" };
            string[] des = new string[] { "Жулебино", "Котельник", "Выхино", "Савеловская", "Дмитровская" };
            string[] r_t = new string[] { "Кухня", "Спальня", "Санузел", "Гостиная", "Спальня" };
            Random rand = new Random();
            for (int k = 0; k < listBox1.SelectedIndex; k++)
            {
                int i = rand.Next(5);
                House house = new House(a_n[i], rand.Next(19) + 1, rand.Next(13) + 1, des[i]);
                for (int j = 0; j < i + 1; j++)
                {
                    house.add_Room(r_t[rand.Next(5)], rand.Next(25) + 5);
                }
                AllHouse.Add(house);
                File.WriteAllText(fdir, JsonConvert.SerializeObject(AllHouse));
                SetGrid(AllHouse);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void SetGrid(List<House> ListHouse)
        {
            dataGridView1.Rows.Clear();
            List<string[]> sdata = new List<string[]>();
            
            foreach (House house in ListHouse)
            {
                string[] tmp = new string[5];
                tmp[0] = house.street_name;
                tmp[1] = house.street_number.ToString();
                tmp[2] = house.apartment.ToString();
                tmp[3] = house.full_area.ToString();
                tmp[4] = house.description;
                sdata.Add(tmp);
            }
            foreach(string[] s in sdata)
            {
                dataGridView1.Rows.Add(s);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            textBox1.Text = "Улица : " + AllHouse[i].street_name;
            textBox1.Text += "\r\nДом : " + AllHouse[i].street_number.ToString();
            textBox1.Text += "\r\nКвартира : " + AllHouse[i].apartment.ToString();
            textBox1.Text += "\r\nБлижайшее метро: " + AllHouse[i].description.ToString();
            textBox1.Text += "\r\nПлощадь (м^2): " + AllHouse[i].full_area.ToString();
            textBox1.Text += "\r\n";
            textBox1.Text += "\r\n";
            textBox1.Text += "=====================Комнаты=====================";
            int j = 1;
            foreach (Room r in AllHouse[i].Rooms)
            {
                textBox1.Text += "\r\n(" + j.ToString();
                textBox1.Text += ")\r\nКомната: " + r.room_type;
                textBox1.Text += "\r\nПлощадь: " + r.area.ToString();
                j++;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
