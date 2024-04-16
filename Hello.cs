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

namespace ProjectCity
{
    public partial class Hello : Form
    {
        public static string cityEdit = "";
        public static int offset = 0;

        public Hello()
        {
            InitializeComponent();
            string selectquery = "select * from cities_tbl order by nameCity";
            fillTable(selectquery);


        }
        private void fillTable(string selectquery)
        {
            DataTable table = new DataTable();
            string selectquery3 = selectquery + " OFFSET " + (offset) + " rows fetch next " + (5) + " rows only";
            SqlConnection con;
            string cs = @"Data Source=MICHAL;Initial Catalog=Cities ;Integrated Security=True";
            con = new SqlConnection(cs);
            if (offset == 0)
            {
                button5.Enabled = false;

            }
            else
            {
                button5.Enabled = true;

            }

            if (offset + 1 > 0)
            {
                SqlDataAdapter adpt = new SqlDataAdapter(selectquery3, con);
                adpt.Fill(table);
                dataGridView1.DataSource = table;

            }

            string selectquery2 = "select count(*) from cities_tbl";

            SqlCommand sc = new SqlCommand(selectquery2, con);
            SqlDataReader sd;
            con.Open();
            int count = (int)sc.ExecuteScalar();

            sd = sc.ExecuteReader();
            
           
                if (offset> count)
                    button6.Enabled = false;


                else
                {
                    button6.Enabled = true;
                }
            


            con.Close();

        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            cityEdit = textBox3.Text;
            Edit ed = new Edit();
            ed.Show();
        }
        // חיפוש

        Dictionary<char, char> letters = new Dictionary<char, char>{

            {'t', 'א'},
            {'c', 'ב'},
            {'d', 'ג'},
            {'s', 'ד'},
            {'v', 'ה'},
            {'u', 'ו'},
            {'z', 'ז'},
            {'j', 'ח'},
            {'y', 'ט'},
            {'h', 'י'},
            {'f', 'כ'},
            {'k', 'ל'},
            {'n', 'מ'},
            {'b', 'נ'},
            {'x', 'ס'},
            {'g', 'ע'},
            {'p', 'פ'},
            {'m', 'צ'},
            {'e', 'ק'},
            {'r', 'ר'},
            {'a', 'ש'},
            {',', 'ת'}
            };
        private void button2_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=MICHAL;Initial Catalog=Cities ;Integrated Security=True";
            string s = textBox1.Text;
            string st = "";
            SqlDataReader sd;

            if (s[0] > 'a' && s[0] < 'z')
            {
                for (int i = 0; i < textBox1.Text.Length; i++)
                {
                    st += letters[s[i]];
                }
                string sqlString1 = "select nameCity from cities_tbl where nameCity like " + "'%" + st + "%'";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand sc = new SqlCommand(sqlString1, con);
                sd = sc.ExecuteReader();
                if (sd.Read())
                {
                    textBox3.Text = sd.GetValue(0).ToString();

                }
                else
                {
                    MessageBox.Show("נתון לא נמצא");

                }
                con.Close();
            }
            else
            {
                string sqlString = "select nameCity from cities_tbl where nameCity like " + "'%" + s + "%'";
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand sc = new SqlCommand(sqlString, con);
                sd = sc.ExecuteReader();
                if (sd.Read())
                {
                    textBox3.Text = sd.GetValue(0).ToString();

                }
                else
                {
                    MessageBox.Show("נתון לא נמצא");

                }
                con.Close();
            }




        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        public event EventHandler<string> ValueSelected;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell selectedCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            string selectedValue = selectedCell.Value.ToString();
            textBox3.Text = selectedValue;
            ValueSelected?.Invoke(this, selectedValue);

        }



        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=MICHAL;Initial Catalog=Cities ;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            string selectquery = "select * from cities_tbl order by nameCity";
            fillTable(selectquery);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=MICHAL;Initial Catalog=Cities ;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            string selectquery = "select * from cities_tbl order by nameCity desc";
            fillTable(selectquery);

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string selectquery = "select * from cities_tbl order by nameCity";

            offset -= 5;
            fillTable(selectquery);


        }

        private void button6_Click(object sender, EventArgs e)
        {
            string selectquery = "select * from cities_tbl order by nameCity";

            offset += 5;
            fillTable(selectquery);
        }
    }
}
