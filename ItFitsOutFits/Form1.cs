using MySql.Data.MySqlClient;
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



namespace ItFitsOutFits
{
    public partial class FormOutfits : Form
    {
     


        public FormOutfits()
        {
            InitializeComponent();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(txtUsername.Text == "" ) // once removed Enter Username will reappear
                {
                    txtUsername.Text = "Enter Username";
                    return;
                }
                txtUsername.ForeColor = Color.White; // changes text Color to white

            }
            catch
            {

            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPass.Text == "")
                {
                    txtPass.Text.ToString();

                    return;
                }

                txtPass.ForeColor = Color.White;
                txtPass.PasswordChar = '*';
            }
            catch
            {

            }
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            txtUsername.SelectAll(); // on click it highlights text to remove it
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            txtPass.SelectAll();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.Black; // for text , soo that login text could be seen
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.Lime;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Creating my sql Conenction from server Explorer 
            try
            {
                //@ thing is connection string database
                SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\justi\Desktop\Case Study Database\Here.mdf; Integrated Security = True; Connect Timeout = 30");

                // query is how i talk to db
                string query = "Select * from [Table] Where username= '" + txtUsername.Text + "' and password= '" + txtPass.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, con); // adapter is how my query will send to server

                DataTable dtbl1 = new DataTable(); //data table is where we put login information that matches 

                sda.Fill(dtbl1); // fill the table whichever entry fits the Database  *from query
                if (dtbl1.Rows.Count == 1) // if ID 1 is a match alllow access
                {
                    MessageBox.Show("Logged in", "Succes");
                    txtUsername.Focus();
                    txtPass.Focus();
                    System.Diagnostics.Process.Start("file:///C:/Users/justi/Desktop/anon-ecommerce-website-master/index.html"); // open file upon event click
                    System.Diagnostics.Process.Start(@"C:\Users\justi\Desktop\EmguCVDemoV4.x.x-master\EmguCVDemoApp.sln");
                }
                else //if incorrect show message box
                {
                    pnlName.Visible = true;
                    pnlPass.Visible = true;
                    MessageBox.Show("Incorrect Username or Password");
                }
            }
            catch (Exception ex) // exception errors 
            {
             
                throw ex;
            }
            
        }

        private void btnClsoe_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            btnSign.ForeColor = Color.Black;
        }

        private void button1_MouseLeave_1(object sender, EventArgs e)
        {
            btnSign.ForeColor = Color.Lime;
        }

        
        private void btnSign_Click(object sender, EventArgs e)
        {
            try
            {
                string commstring = "INSERT INTO [TABLE](username, password) VALUES (@name, @pass)"; // query for updating 
                //Connecting to database
                string con_String = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\justi\Desktop\Case Study Database\Here.mdf; Integrated Security = True; Connect Timeout = 30";

                using (SqlConnection conn = new SqlConnection(con_String))

                {
                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = commstring;
                        comm.Parameters.AddWithValue("@name", txtsignUsername.Text);
                        comm.Parameters.AddWithValue("@pass", txtsignPass.Text);
                        conn.Open();

                        comm.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Signed Up Succesfully!");
            }

            catch
            {
                MessageBox.Show(" A registration error had Occured");
            }


            if(txtsignUsername.Text == "Enter Username")
            {
                pnlUserNamee.Visible = true;
                txtsignUsername.Focus();
                
                return;

            }
            if (txtsignContact.Text == "Enter Contact")
            {
                pnlContact.Visible = true;
                txtsignContact.Focus();
                txtsignContact.SelectAll();
                return;
            }
            if (txtsignPass.Text == "Enter Password")
            {
                pnlPasses.Visible = true;
                txtsignPass.Focus();
                txtsignPass.SelectAll();
                return;
            }

            if(MessageBox.Show("Are you sure You're done ?", "Account ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                pnlLogo.Visible = true;
                pnlLogin.Dock = DockStyle.Fill;
                pnlSIgnUP.Visible = false;
                pnlLogo.Dock = DockStyle.Left;
            }



        }

        private void timer1_Tick(object sender, EventArgs e) // timer for panels to show up
        {
            pnlUserNamee.Visible=pnlContact.Visible=pnlPasses.Visible=false;
        }

        private void FormOutfits_Load(object sender, EventArgs e)  // initiate timer
        {
            timer1.Start();
        }

        private void txtsignUsername_TextChanged(object sender, EventArgs e)
        {
            txtsignUsername.ForeColor = Color.White;
        }

        private void txtsignContact_TextChanged(object sender, EventArgs e)
        {
            txtsignContact.ForeColor = Color.White;
        }

        private void txtsignPass_TextChanged(object sender, EventArgs e)
        {
            txtsignPass.ForeColor = Color.White;
        }

        private void txtsignUsername_Click(object sender, EventArgs e)
        {
            txtsignUsername.SelectAll();
        }

        private void lblBACK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlLogo.Visible = true;
            pnlLogin.Dock = DockStyle.Fill;
            pnlSIgnUP.Visible = false;
            pnlLogo.Dock = DockStyle.Left;  
        }

        private void lnkAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlLogo.Visible = true;
            pnlSIgnUP.Visible = true;
            pnlLogo.Dock = DockStyle.Right;
            
            pnlSIgnUP.Dock = DockStyle.Fill;
           

        }
    }
 }

