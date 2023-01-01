using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Project_4_Miracle
{
    public partial class addContact : Form
    {
        string names, middleName, lastName, phone, address, gender, 
            imageLoc="",imageDec=@"images\";

        private void addContact_Load(object sender, EventArgs e)
        {
            pbxImage.Image = Properties.Resources._1;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFl = new OpenFileDialog();
            openFl.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (openFl.ShowDialog() == DialogResult.OK)
            {
                Image img = new Bitmap(openFl.FileName);
                imageLoc = Path.GetDirectoryName(openFl.FileName).ToString()+@"\"+openFl.SafeFileName;
                imageDec += openFl.SafeFileName;
                pbxImage.Image = img.GetThumbnailImage(0, 0, null, new IntPtr());
                openFl.RestoreDirectory = true;
                
            }
        }

        int contactCounter = 0;
        public addContact()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.ShowDialog();
            this.Close();
        }
        private void clearData()
        {
            txbAddress.Text = "";
            txbLastName.Text = "";
            txbMiddleName.Text = "";
            txbName.Text = "";
            txbPhone.Text = "";
            imageDec = @"images\";
            imageLoc = "";
            rdbFemale.Checked = false;
            rdbMale.Checked = false;
            pbxImage.Image = Properties.Resources._1;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            names = txbName.Text;
            middleName = txbMiddleName.Text;
            lastName = txbLastName.Text;
            phone = txbPhone.Text;
            address = txbAddress.Text;
            if (rdbMale.Checked)
            {
                gender = rdbMale.Text;
            }else if(rdbFemale.Checked)
            {
                gender = rdbFemale.Text;
            }
            if (names==""||lastName==""||phone==""||address==""||gender=="")
            {
                MessageBox.Show("Write all data!");
            }
            else
            {
                FileStream fs = new FileStream("contacts.txt", FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                if (imageLoc != "")
                {
                    AllContacts.allContacts.Add(new Contact(names, middleName, lastName, phone, address, gender, imageDec));
                    File.Copy(imageLoc, Path.GetDirectoryName(Application.ExecutablePath)+ @"\" + imageDec, true);
                    contactCounter = AllContacts.allContacts.Count;
                    sw.WriteLine("Name: " + AllContacts.allContacts[contactCounter - 1].Name+"." +
                    "\nMiddleName: " + AllContacts.allContacts[contactCounter - 1].MiddleName + "." +
                    "\nLastName: " + AllContacts.allContacts[contactCounter - 1].LastName + "." +
                    "\nphone: " + AllContacts.allContacts[contactCounter - 1].Phone + "." +
                    "\nAddress: " + AllContacts.allContacts[contactCounter - 1].Address + "." +
                    "\nGender: " + AllContacts.allContacts[contactCounter - 1].Gender + "." +
                    "\nFile: " + AllContacts.allContacts[contactCounter - 1].ImageLoc + "|" +
                    "\n##################################################");
                }
                else { 
                AllContacts.allContacts.Add(new Contact(names, middleName, lastName, phone, address, gender));
                contactCounter = AllContacts.allContacts.Count;
                sw.WriteLine("Name: "+AllContacts.allContacts[contactCounter-1].Name + "." +
                    "\nMiddleName: "+AllContacts.allContacts[contactCounter-1].MiddleName + "." +
                    "\nLastName: " + AllContacts.allContacts[contactCounter - 1].LastName + "." +
                    "\nphone: " + AllContacts.allContacts[contactCounter - 1].Phone + "." +
                    "\nAddress: " + AllContacts.allContacts[contactCounter - 1].Address + "." +
                    "\nGender: " + AllContacts.allContacts[contactCounter - 1].Gender + "." +
                    "\nFile: " + "The file does not exist|" +
                    "\n+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                }
                MessageBox.Show("Added successfully");
                clearData();
                sw.Close();
                fs.Close();
            }
        }
    }
}
