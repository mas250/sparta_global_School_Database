using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WPFUserRegistration
{
    public class User
    {
        string name;
        string password;
        int age;
        string sex;
        string phoneNumber;
        string picturePath;
        string ageRange;
        string[] transportation = new string [3];

        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public int Age { get => age; set => age = value; }
        public string Sex { get => sex; set => sex = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string PicturePath { get => picturePath; set => picturePath = value; }
        public string AgeRange { get => ageRange; set => ageRange = value; }
        public string[] Transportation { get => transportation; set => transportation = value; }
        public User()
        {


        }
        public User(string n, string p, int a, string s, string pn, string pix, string ar, string[] t)
        {
            name = n;
            password = p;
            age = a;
            sex = s;
            phoneNumber = pn;
            picturePath = pix;
            ageRange = ar;
            transportation = t;
        }

        public void saveData()
        {
            string eachItem = "";
            foreach (var item in transportation)
            {
                eachItem += "_" + item;

            }

            using (StreamWriter sw = File.AppendText("UserData.csv"))
            {
                sw.WriteLine(name + ":" + password + ":" + age + ":" + sex +":" + phoneNumber + ":" + picturePath + ":" + ageRange + ":" + transportation);
                


            }
        }
    }
}
