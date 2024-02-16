using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace contacts_windowsform
{
    public partial class editform : Form 
    {
        
        public editform()
        {
            InitializeComponent();
        }
        
        public int contact_id;

        private void edit_Form_Load(object sender, EventArgs e) 
        {
            using(Contact_DBEntities db = new Contact_DBEntities())
            {
                dataGridView.DataSource = db.Contact_table.Where(x => x.contact_id==contact_id).ToList();
                db.SaveChanges();
            }

            

            nametxt.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            mobiletxt.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            emailtxt.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
            agetxt.Text = dataGridView.CurrentRow.Cells[4].Value.ToString();


            dataGridView.Visible = false;


        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void nametxt_TextChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            int convert_age = Convert.ToInt32(agetxt.Text);
            using(Contact_DBEntities db=new Contact_DBEntities())
            {
                Contact_table contact = new Contact_table();
                contact = db.Contact_table.Find(contact_id);
                contact.Name = nametxt.Text;
                contact.Mobile = mobiletxt.Text;
                contact.Email = emailtxt.Text;
                contact.Age = convert_age;
                db.SaveChanges();
            }
            

            DialogResult = DialogResult.OK;
            
            
        }
    }
}
