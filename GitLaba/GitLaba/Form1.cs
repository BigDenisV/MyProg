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
            string[] des = new string[] {"Жулебино", "Котельник","Выхино","Савеловская","Дмитровская"};
            string[] r_t = new string[] { "Кухня", "Спальня", "Санузел", "Гостиная","Прочее"};
            Random rand = new Random();
            int i = rand.Next(5);
            House house = new House(a_n[i], rand.Next(19)+1, rand.Next(13) + 1, des[i]);
            for (int j = 1; j < rand.Next(3) + 1; j++)
            {
                house.add_Room(r_t[rand.Next(5)], rand.Next(20) + 1);
            }
            AllHouse.Add(house);
            File.WriteAllText(fdir, JsonConvert.SerializeObject(AllHouse));
            SetGrid(AllHouse);
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
    }
}
