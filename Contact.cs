using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_4_Miracle
{
    class Contact
    {
        string name, middleName, lastName,phone, address, gender;
        string imageLoc;
        
        public Contact(string name, string middleName, string lastName, 
            string phone, string address, string gender, string imageLoc)
        {
            this.name = name;
            this.middleName = middleName;
            this.lastName = lastName;
            this.phone = phone;
            this.address = address;
            this.gender = gender;
            this.imageLoc = imageLoc; 
        }
        public Contact(string name, string middleName, string lastName,
           string phone, string address, string gender)
        {
            this.name = name;
            this.middleName = middleName;
            this.lastName = lastName;
            this.phone = phone;
            this.address = address;
            this.gender = gender;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string MiddleName
        {
            get
            {
                return middleName;
            }
            set
            {
                middleName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }
        public string ImageLoc
        {
            get
            {
                return imageLoc;
            }
            set
            {
                imageLoc = value;
            }
        }
    }
}
