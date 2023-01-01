using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_4_Miracle
{
    public partial class showContact : Form
    {
        string alltext, firstSym = ": ", endSym = ".", resultSt = "", imageLoc, fileContact = "contacts.txt";
        List<string> allLine = new List<string>();
        List<Label> allLabel;
        int countContact=0, allContact=0,pagePrev=1,pageNext;
        public showContact()
        {
            InitializeComponent();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            allContact = 0;
            countContact -= 8;
            pagePrev--;
            btnNext.Enabled = true;
            scrollNextContact();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            allContact = 0;
            countContact += 8;
            pagePrev++;
            btnPrev.Enabled = true;
            scrollNextContact();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.ShowDialog();
            this.Close();
        }
        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }

            return "";
        }
        private void scrollNextContact()
        {
            lblPages.Text = pagePrev + " out of " + pageNext;
            if (countContact == 0)
            {
                btnPrev.Enabled = false;
            }
            if (countContact == allLine.Count - 8)
            {
                btnNext.Enabled = false;
            }
            for (int i = countContact; i < countContact + 8; i++)
            {
                alltext = allLine[i];
                if (Regex.IsMatch(alltext, "File"))
                {
                    imageLoc = getBetween(alltext, firstSym, "|");
                    //FileStream fs = new System.IO.FileStream(imageLoc, FileMode.Open, FileAccess.Read);
                    if (imageLoc== "The file does not exist")
                    {
                        pbxImage.Image = Properties.Resources._1;
                    }
                    else{
                        pbxImage.Image = Image.FromFile(imageLoc);
                    }
                    //pbxImage.Image = Image.FromStream(fs);
                    //fs.Close();
                    break;
                }
                else
                {
                    resultSt = getBetween(alltext, firstSym, endSym);
                    allLabel[allContact].Text = resultSt;
                    allLabel[allContact].Visible = true;
                    allContact++;
                }
            }
        }

        private void showContact_Load(object sender, EventArgs e)
        {
            allLabel = new List<Label>() { lblName, lblMiddleName, lblLastName, lblPhone, lblAddress, lblGender};
            if (!File.Exists(fileContact))
            {
                FileStream fs = new FileStream("contacts.txt", FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                MessageBox.Show("The contacts.txt file does not exist!");
                gbxContact.Enabled = false;
                fs.Close();
            }
            else 
            { 
                FileStream f = new FileStream(fileContact, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(f);
                while (!sr.EndOfStream)
                {
                    allLine.Add(sr.ReadLine());
                }
                pageNext = allLine.Count / 8;
                if (allLine.Count<8)
                {
                    MessageBox.Show("There are empty contacts!");
                    gbxContact.Enabled = false;
                }else
                {
                    scrollNextContact();
                }
                btnPrev.Enabled = false;
                sr.Close();
                f.Close();
            }
        }
    }
}
