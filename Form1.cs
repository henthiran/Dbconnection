using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //1 st query to import
namespace dbonnection
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Secound query connection Sring copy and pate 
        /// go to server Exploer copy connectionsring and past bellow
        /// 
        SqlConnection con = new SqlConnection(@"Data Source=HARDY-PC\SQLEXPRESS;Initial Catalog=db_Students;Integrated Security=True");

        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        int index = 0;

        public Form1()
        {
            InitializeComponent();
        }
        public void display()
        {
            dataGridView.DataSource = ds;
            ds.Clear();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM student";
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "student");
            dataGridView.DataSource = ds.Tables["student"];
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string gender = "";                                                         

            if (rdMale.Checked)
            {
                gender = "male";
            }
            if (rdFemale.Checked)
            {
                 gender = "female";
            }
            // ternary operator
            //string gender = (rdMale.Checked) ? "male" : "female";


            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Student(reg_no,name,contact_no,address,gender,course) VALUES('"+txtRegNo.Text+"','"+txtName.Text+"','"+txtContactNO.Text+"','"+txtAddress.Text+"','"+gender+"','"+cmbCourse.Text+"')";
            cmd.ExecuteNonQuery();
            display();
            con.Close();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM student WHERE reg_no='" + txtRegNo.Text + "'";
            cmd.ExecuteNonQuery();

            display();
            con.Close();


        }

        private void btnView_Click(object sender, EventArgs e)
        {
            con.Open();
            display();
            con.Close();

           
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {


            string gender = dataGridView.CurrentRow.Cells["gender"].FormattedValue.ToString();

            if (gender.StartsWith("fe"))
            {
                rdFemale.Checked = true;
            }
            else
            {
                rdMale.Checked = true;
            }

            txtRegNo.Text = dataGridView.CurrentRow.Cells["reg_no"].FormattedValue.ToString();
            txtName.Text = dataGridView.CurrentRow.Cells["name"].FormattedValue.ToString();
            txtContactNO.Text = dataGridView.CurrentRow.Cells["contact_no"].FormattedValue.ToString(); 
            txtAddress.Text = dataGridView.CurrentRow.Cells["address"].FormattedValue.ToString();
            cmbCourse.Text = dataGridView.CurrentRow.Cells["course"].FormattedValue.ToString();
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string gender = (rdMale.Checked) ? "male" : "female";
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE student SET name='" + txtName.Text + "',contact_no='" + txtContactNO.Text + "',address='" + txtAddress.Text + "',gender='" + gender + "',course='" + cmbCourse.Text + "' WHERE reg_no='" + txtRegNo.Text + "'";
            cmd.ExecuteNonQuery();

            display();
            con.Close();



        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                index--;//index = index - 1;
                txtRegNo.Text = ds.Tables[0].Rows[index]["reg_no"].ToString();
                txtName.Text = ds.Tables[0].Rows[index]["name"].ToString();
                txtContactNO.Text = ds.Tables[0].Rows[index]["contact_no"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[index]["address"].ToString();
                string gender = ds.Tables[0].Rows[index]["gender"].ToString();
                if (gender.StartsWith("fe"))
                {
                    rdFemale.Checked = true;
                }
                else
                {
                    rdMale.Checked = true;
                }
                cmbCourse.Text = ds.Tables[0].Rows[index]["course"].ToString();
            }
            else
            {
                MessageBox.Show("You have reached the first row");

            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (index < ds.Tables[0].Rows.Count - 1)
            {
                index++;//index = index + 1;
                txtRegNo.Text = ds.Tables[0].Rows[index]["reg_no"].ToString();
                txtName.Text = ds.Tables[0].Rows[index]["name"].ToString();
                txtContactNO.Text = ds.Tables[0].Rows[index]["contact_no"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[index]["address"].ToString();
                string gender = ds.Tables[0].Rows[index]["gender"].ToString();
                if (gender.StartsWith("fe"))
                {
                    rdFemale.Checked = true;
                }
                else
                {
                    rdMale.Checked = true;
                }
                cmbCourse.Text = ds.Tables[0].Rows[index]["course"].ToString();
            }
            else
            {
                MessageBox.Show("You have reached the last row");
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            index = ds.Tables[0].Rows.Count - 1;
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtRegNo.Text = ds.Tables[0].Rows[index]["reg_no"].ToString();
                txtName.Text = ds.Tables[0].Rows[index]["name"].ToString();
                txtContactNO.Text = ds.Tables[0].Rows[index]["contact_no"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[index]["address"].ToString();
                string gender = ds.Tables[0].Rows[index]["gender"].ToString();
                if (gender.StartsWith("fe"))
                {
                    rdFemale.Checked = true;
                }
                else
                {
                    rdMale.Checked = true;
                }
                cmbCourse.Text = ds.Tables[0].Rows[index]["course"].ToString();
            }
            else
            {
                MessageBox.Show("Empty Table");
            }
        }

        private void btnfirst_Click(object sender, EventArgs e)
        {
            index = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtRegNo.Text = ds.Tables[0].Rows[index]["reg_no"].ToString();
                txtName.Text = ds.Tables[0].Rows[index]["name"].ToString();
                txtContactNO.Text = ds.Tables[0].Rows[index]["contact_no"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[index]["address"].ToString();
                string gender = ds.Tables[0].Rows[index]["gender"].ToString();
                if (gender.StartsWith("fe"))
                {
                    rdFemale.Checked = true;
                }
                else
                {
                    rdMale.Checked = true;
                }
                cmbCourse.Text = ds.Tables[0].Rows[index]["course"].ToString();
            }
            else
            {
                MessageBox.Show("Empty Table");
            }
        }
    }
    
    
}
