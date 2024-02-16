using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace contacts_windowsform
{
    public partial class addform : Form
    {
       
        public addform()
        {
            InitializeComponent();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (isvaild_input())
                {
                    
                    int convert_age = Convert.ToInt32(agetxt.Text);
                    using(Contact_DBEntities db=new Contact_DBEntities())
                    {
                        Contact_table contact = new Contact_table();
                        contact.Name = nametxt.Text;
                        contact.Mobile = mobiletxt.Text;
                        contact.Email = emailtxt.Text;
                        contact.Age = convert_age;
                        db.Contact_table.Add(contact);
                        db.SaveChanges();

                        MessageBox.Show("با موفقیت انجام شد !", " موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }
                                        
                }
            }
            catch
            {
                MessageBox.Show("مشکلی در ورود اطلاعات وجود دارد !", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 
            
        }

        private void addform_Load(object sender, EventArgs e)
        {
            
            
        }

        bool isvaild_input()
        {
            bool isvalid = true;
            
            if (nametxt.Text=="")
            {
               
                MessageBox.Show("لطفا نام را وارد کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }if( mobiletxt.Text == "")
            {

                MessageBox.Show("لطفا شماره موبایل را وارد کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }if (agetxt.Text == ""){

                MessageBox.Show("لطفا سن را وارد کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }if (emailtxt.Text == "")
            {
                MessageBox.Show("لطفا ایمیل را وارد کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }


            return isvalid;
        }
    }
}
