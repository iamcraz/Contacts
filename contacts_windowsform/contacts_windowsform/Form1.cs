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
    public partial class mainform : Form
    {
        
        

        public mainform()
        {
            InitializeComponent();
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bind_selectall();
        }

        private void bind_selectall()
        {
            using(Contact_DBEntities db = new Contact_DBEntities())
            {
                dataGridView.AutoGenerateColumns = false;
                dataGridView.Columns[0].Visible = false;
                dataGridView.DataSource =db.Contact_table.ToList();
                db.SaveChanges();
            }
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            bind_selectall();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            addform Addform = new addform();
            Addform.ShowDialog();
            if (Addform.DialogResult==DialogResult.OK)
            {
                bind_selectall();
            }
        }

        private void editbtn_Click(object sender, EventArgs e)
        {

        }

        private void delbtn_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null)
            {
                if (MessageBox.Show("حذف شود ؟","هشدار",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int contact_id = int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString());
                    using (Contact_DBEntities db = new Contact_DBEntities())
                    {

                        Contact_table contact = db.Contact_table.Single(x => x.contact_id == contact_id);
                        db.Contact_table.Remove(contact);
                        db.SaveChanges();   
  
                    }
                    bind_selectall();
                }
            }
            else
            {
                MessageBox.Show("یک ردیف را انتخاب نمایید !", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void editbtn_Click_1(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null)
            {
                int contact_id = int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString());
                

                editform editform = new editform();

                editform.contact_id = contact_id;

                editform.ShowDialog();

                

                if (editform.DialogResult == DialogResult.OK)
                {
                    
                    bind_selectall();
                   
                }

            }
            else
            {
                MessageBox.Show("یک ردیف را انتخاب نمایید !", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (search_mobiletxt.Text == "")
            {
                using (Contact_DBEntities db = new Contact_DBEntities())
                {
                    dataGridView.DataSource = db.Contact_table.Where(x => x.Name.Contains(search_nametxt.Text)).ToList();
                    db.SaveChanges();
                }
            }else if (search_nametxt.Text == "")
            {
                using(Contact_DBEntities db=new Contact_DBEntities())
                {
                    dataGridView.DataSource = db.Contact_table.Where(x => x.Mobile.Contains(search_mobiletxt.Text)).ToList();
                    db.SaveChanges();
                }
                 
            }                                   
        }
    }
}
