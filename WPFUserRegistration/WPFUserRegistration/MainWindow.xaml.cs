using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Microsoft.VisualBasic;
using System.Xml;


namespace WPFUserRegistration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User kc;
        public MainWindow()
        {
            InitializeComponent();
            kc = new User();
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Choose a photo";
            ofd.Filter = "All Supported image | *.jpeg;*.jpg;*.png";
            if (ofd.ShowDialog() == true)
            {
                imageField.Source = new BitmapImage(new Uri(ofd.FileName));
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {

        }

        private void registerUser(object sender, RoutedEventArgs e)
        {
            kc.Name = nameField.Text;
            kc.Password = passwordField.Password;
            kc.Age = DateTime.Now.Year - ageField.SelectedDate.Value.Year;
            kc.Sex = sexBox.Text;
            kc.PicturePath = imageField.Source.ToString();
            kc.PhoneNumber = numberField.Text;
            if (checkbox_0.IsChecked == true)
            {
                kc.Transportation[0] = "Walks";
            }
            if (checkbox_1.IsChecked == true)
            {
                kc.Transportation[1] = "Drives";
            }
            if (checkbox_2.IsChecked == true)
            {
                kc.Transportation[2] = "Cycles";
            }

            if (radio_0.IsChecked == true)
            {
                kc.AgeRange = "18-";
            }
            if (radio_1.IsChecked == true)
            {
                kc.AgeRange = "18+";
            }
            if (kc.Name != "" && kc.Password != "" && kc.Age != 0 && kc.PhoneNumber != "" && kc.PicturePath != "")
            {
                
                kc.saveData();
                kc.saveDataXML();
                MessageBox.Show("Entry Added");
            }
            else
            {
                MessageBox.Show("Please enter more data");
            }
            
        }

        private void ViewProfile(object sender, RoutedEventArgs e)
        {
          


            string searchedUser = Interaction.InputBox("please input username", "Username Search", "");
            string[] sr = File.ReadAllLines("UserData.csv");
           // MessageBox.Show(searchedUser);
            for (int i = 0; i < sr.Length; i++)
            {
                string[] str = sr[i].Split(',');
                if (searchedUser == str [0])
                {
                    //returns the line for the given username
                    //eg name.Text =str[0];
                    //password.Text = str[1];

                    nameField.Text = str[0];
                    passwordField.Password = str[1];
                    if (str[7] == "Walks")
                    {
                        checkbox_0.IsChecked = true;
                    }
                }
            }
            //string[] str = sr[0].Split(',');
            //nameField.Text = str[0];
        }
    }
}
