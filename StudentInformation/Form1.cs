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

namespace StudentInformation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
                            // Save Data //

            SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-F842VI4\SQLEXPRESS; Database = StudentInformation; Trusted_Connection = True");
            con.Open();

            SqlCommand cmd = new SqlCommand("StudentSave", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name",    txtSaveName.Text);
            cmd.Parameters.AddWithValue("@Mobile",  txtSaveMobile.Text);
            cmd.Parameters.AddWithValue("@Email",   txtSaveEmail.Text);
            cmd.Parameters.AddWithValue("@Grade",   txtSaveGrade.Text);
            
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Your Data Saved Successfully","Student Information-Status",MessageBoxButtons.OK,MessageBoxIcon.Information);
            lstBoxShowData.Items.Add(txtSaveName.Text);
            
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
                            // Get Data //

            SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-F842VI4\SQLEXPRESS; Database = StudentInformation; Trusted_Connection = True");
            con.Open();

            SqlCommand cmd = new SqlCommand("StudentGet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RollNo", txtGetRollNo.Text);

            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                lblGetName.Text = reader["Name"].ToString();
                lblGetMobile.Text = reader["Mobile"].ToString();
                lblGetEmail.Text=reader["Email"].ToString();
                lblGetGrade.Text=reader["Grade"].ToString();
            }
            else 
                {
                    MessageBox.Show("No Data To Display","Student Information-Status",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                con.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
                                // Update Data //
            SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-F842VI4\SQLEXPRESS; Database = StudentInformation; Trusted_Connection = True");
            con.Open();

            SqlCommand cmd = new SqlCommand("StudentUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RollNo",txtUpdateData.Text);
            cmd.Parameters.AddWithValue("@Name", txtUpdateName.Text);
            cmd.Parameters.AddWithValue("@Email", txtUpdateEmail.Text);
            cmd.Parameters.AddWithValue("@Mobile", txtUpdateMobile.Text);
            cmd.Parameters.AddWithValue("@Grade", txtUpdateGrade.Text);

                MessageBox.Show("Updated", "Student Information-Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
                            // Delete Data //

            SqlConnection con=new SqlConnection(@"Data Source = DESKTOP-F842VI4\SQLEXPRESS; Database = StudentInformation; Trusted_Connection = True");
            con.Open();

            SqlCommand cmd = new SqlCommand("StudentGet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RollNo", txtDelete.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Deleted","Student Information-Status",MessageBoxButtons.OK,MessageBoxIcon.Information);
            lstBoxShowData.Items.Remove(txtDelete.Text);

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClearSave_Click(object sender, EventArgs e)
        {
            txtSaveEmail.Text = txtSaveGrade.Text = txtSaveMobile.Text = txtSaveName.Text = "";
        }

        private void btnGetClear_Click(object sender, EventArgs e)
        {
            lblGetEmail.Text = lblGetGrade.Text = lblGetName.Text = lblGetMobile.Text =txtGetRollNo.Text ="";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtUpdateGrade.Text = txtUpdateEmail.Text = txtUpdateData.Text = txtUpdateName.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
