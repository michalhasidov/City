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
    public partial class Edit : Form
    {

        public Edit()
        {

            InitializeComponent();
        }
        //הוספה
        private void button1_Click_2(object sender, EventArgs e)
        {

            string cs = @"Data Source=MICHAL;Initial Catalog=Cities ;Integrated Security=True";
            string sqlString = "insert into cities_tbl(nameCity)values(" + "'" + textBox1.Text + "'" + ")";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand sc = new SqlCommand(sqlString, con);
          
            if (textBox1.Text==" "|| textBox1.Text=="")
            {
                MessageBox.Show("טעות");

            }
            else
            {
                try {
                    sc.ExecuteNonQuery();
                MessageBox.Show("התווסף בהצלחה"); }
                catch {
                    MessageBox.Show("קיים במערכת");

                }
            }


            con.Close();
            textBox1.Clear();

        }
        //עדכון
        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox2.Show();
            string cs = @"Data Source=MICHAL;Initial Catalog=Cities ;Integrated Security=True";
            string sqlString = "update cities_tbl set nameCity=" + "'" + textBox2.Text + "'" + "where nameCity=" + "'" + Hello.cityEdit + "'";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand sc = new SqlCommand(sqlString, con);

            if(textBox2.Text=="")
            {
                MessageBox.Show("טעות");

            }
            else { 
                sc.ExecuteNonQuery();
                MessageBox.Show("התעדכן בהצלחה");
            }
            con.Close();
            textBox1.Clear();
            textBox2.Clear();


        }
        //מחיקה
        private void button3_Click(object sender, EventArgs e)
        {

            string cs = @"Data Source=MICHAL;Initial Catalog=Cities ;Integrated Security=True";
            string sqlString = "delete from cities_tbl where nameCity=" + "'" + textBox1.Text + "'";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand sc = new SqlCommand(sqlString, con);
           
               if( sc.ExecuteNonQuery()==1)
                MessageBox.Show("נמחק בהצלחה");
            
            else
            {
                MessageBox.Show("טעות");
            }
            con.Close();
            textBox1.Clear();
        }
        //public void UpdateTextBox(string selectedValue)
        //{
        //    textBox1.Text = selectedValue;
        //}
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            // Update the textbox with the received value from the first form

        }

        private void Edit_Load(object sender, EventArgs e)
        {
            textBox1.Text = Hello.cityEdit;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
