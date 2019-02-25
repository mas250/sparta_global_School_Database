using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

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
        public User() {}
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
                sw.WriteLine(name + "," + password + "," + age + "," + sex +"," + phoneNumber + "," + picturePath + "," + ageRange + "," + eachItem);

            }
        }

        public void saveDataXML()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("allUsers");
            xmlDoc.AppendChild(rootNode);

            XmlNode userNode = xmlDoc.CreateElement("user");
            XmlAttribute attribute = xmlDoc.CreateAttribute("age");
            attribute.Value = Age.ToString();
            


            XmlNode nameNode = xmlDoc.CreateElement("name");
            nameNode.InnerText = Name;
            rootNode.AppendChild(nameNode);
            nameNode.Attributes.Append(attribute);

            XmlNode passwordNode = xmlDoc.CreateElement("password");
            passwordNode.InnerText = Password;
            rootNode.AppendChild(passwordNode);

            XmlNode ageNode = xmlDoc.CreateElement("age");
            ageNode.InnerText = Age.ToString();
            rootNode.AppendChild(ageNode);

            XmlNode sexNode = xmlDoc.CreateElement("sex");
            sexNode.InnerText = Sex;
            rootNode.AppendChild(sexNode);

            XmlNode phoneNumberNode = xmlDoc.CreateElement("phoneNumber");
            phoneNumberNode.InnerText = PhoneNumber;
            rootNode.AppendChild(phoneNumberNode);

            XmlNode imagePathNode = xmlDoc.CreateElement("imagePath");
            imagePathNode.InnerText = PicturePath;
            rootNode.AppendChild(imagePathNode);




            //attribute.Value = "42";
            //userNode.Attributes.Append(attribute);
            //userNode.InnerText = "John Doe";
            //rootNode.AppendChild(userNode);

            //userNode = xmlDoc.CreateElement("user");
            //attribute = xmlDoc.CreateAttribute("age");
            //attribute.Value = "39";
            //userNode.Attributes.Append(attribute);
            //userNode.InnerText = "Jane Doe";
            //rootNode.AppendChild(userNode);

            xmlDoc.Save("test-doc.xml");

            string eachItem = "";
            foreach (var item in transportation)
            {
                eachItem += "_" + item;
            }

            using (StreamWriter sw = File.AppendText("UserData.xml"))
            {
                sw.WriteLine(name + "," + password + "," + age + "," + sex + "," + phoneNumber + "," + picturePath + "," + ageRange + "," + eachItem);

            }
        }
    }
}
