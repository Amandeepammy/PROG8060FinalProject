using System;
using System.Collections.Generic;
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
using System.Collections;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace PROJECT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string name, age, gender, address, city, country, phone, eType, username, password, user, passs;
        public string sqlConnectionString = "Data Source=DESKTOP-FO8RSQ8;Initial Catalog=project;Integrated Security=True";

        public MainWindow()
        {
            InitializeComponent();
            comboGender.Items.Add("Male");
            comboGender.Items.Add("Female");
            comboEType.Items.Add("Manager");
            comboEType.Items.Add("Human Resourse");
            comboEType.Items.Add("Supervisor");
            comboEType.Items.Add("Team Leader");
            comboEType.Items.Add("Quality Assurance");
            HideFront();
            HideRear();
            ShowLogin();
        }

        
        public void HideFront()
        {
            uPass.Visibility = Visibility.Hidden;
            uName.Visibility = Visibility.Hidden;
            uCPass.Visibility = Visibility.Hidden;
            txtUserName.Visibility = Visibility.Hidden;
            txtPassword.Visibility = Visibility.Hidden;
            txtConfirmPassword.Visibility = Visibility.Hidden;
            btnBack2.Visibility = Visibility.Hidden;
            btnSave.Visibility = Visibility.Hidden;
        }

        public void ShowFront()
        {
            uPass.Visibility = Visibility.Visible;
            uName.Visibility = Visibility.Visible;
            uCPass.Visibility = Visibility.Visible;
            txtUserName.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Visible;
            txtConfirmPassword.Visibility = Visibility.Visible;
            btnBack2.Visibility = Visibility.Visible;
            btnSave.Visibility = Visibility.Visible;
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {

            user = txtUserName.Text;
            passs = txtPassword.Password.ToString();
            SqlConnection con = new SqlConnection(sqlConnectionString);
            con.Open();
            string query = $"select username,password from Employee where username='{user}' and password='{passs}'";
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                MessageBox.Show("Successfully Login");
                WriteToFile();
            }
            else
            {
                MessageBox.Show("Invalid credentials");
            }
        }

        public void HideRear()
        {
            lblName.Visibility = Visibility.Hidden;
            lblAge.Visibility = Visibility.Hidden;
            lblGender.Visibility = Visibility.Hidden;
            lblAddress.Visibility = Visibility.Hidden;
            lblCity.Visibility = Visibility.Hidden;
            lblCountry.Visibility = Visibility.Hidden;
            lblPhone.Visibility = Visibility.Hidden;
            lblEmployee.Visibility = Visibility.Hidden;
            txtAddress.Visibility = Visibility.Hidden;
            txtAge.Visibility = Visibility.Hidden;
            txtCity.Visibility = Visibility.Hidden;
            txtCountry.Visibility = Visibility.Hidden;
            txtPhoneNumber.Visibility = Visibility.Hidden;
            txtName.Visibility = Visibility.Hidden;
            comboGender.Visibility = Visibility.Hidden;
            comboEType.Visibility = Visibility.Hidden;
            btnBack.Visibility = Visibility.Hidden;
            btnNext.Visibility = Visibility.Hidden;
        }
        public void ShowRear()
        {
            lblName.Visibility = Visibility.Visible;
            lblAge.Visibility = Visibility.Visible;
            lblGender.Visibility = Visibility.Visible;
            lblAddress.Visibility = Visibility.Visible;
            lblCity.Visibility = Visibility.Visible;
            lblCountry.Visibility = Visibility.Visible;
            lblPhone.Visibility = Visibility.Visible;
            lblEmployee.Visibility = Visibility.Visible;
            txtAddress.Visibility = Visibility.Visible;
            txtAge.Visibility = Visibility.Visible;
            txtCity.Visibility = Visibility.Visible;
            txtCountry.Visibility = Visibility.Visible;
            txtPhoneNumber.Visibility = Visibility.Visible;
            txtName.Visibility = Visibility.Visible;
            comboGender.Visibility = Visibility.Visible;
            comboEType.Visibility = Visibility.Visible;
            btnBack.Visibility = Visibility.Visible;
            btnNext.Visibility = Visibility.Visible;
        }
        public void HideLogin()
        {
            btnRegister.Visibility = Visibility.Hidden;
            btnLogin.Visibility = Visibility.Hidden;
            lblForgot.Visibility = Visibility.Hidden;
            btnForgot.Visibility = Visibility.Hidden;
            uPass.Visibility = Visibility.Hidden;
            uName.Visibility = Visibility.Hidden;
            txtUserName.Visibility = Visibility.Hidden;
            txtPassword.Visibility = Visibility.Hidden;
        }
        public void ShowLogin()
        {
            btnRegister.Visibility = Visibility.Visible;
            btnLogin.Visibility = Visibility.Visible;
            lblForgot.Visibility = Visibility.Visible;
            btnForgot.Visibility = Visibility.Visible;
            uPass.Visibility = Visibility.Visible;
            uName.Visibility = Visibility.Visible;
            txtUserName.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Visible;
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            HideRear();
            HideLogin();
            ShowFront();
            name = txtName.Text;
            age = txtAge.Text;
            gender= (string)comboGender.Text;
            address = txtAddress.Text;
            city= txtCity.Text;
            country = txtCountry.Text;
            phone = txtPhoneNumber.Text;
            eType = (string)comboEType.Text;

        }

        private void BtnBack2_Click(object sender, RoutedEventArgs e)
        {
            HideFront();
            HideLogin();
            ShowRear();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            username = txtUserName.Text;
            string pass = txtPassword.Password.ToString();
            string confirmPassword = txtConfirmPassword.Password.ToString();
            if (pass.Equals(confirmPassword))
            {
                password = pass;

                try
                {
                    SqlConnection con = new SqlConnection(sqlConnectionString);
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        string query = "insert into Employee(name,age,gender,address,city,country,phone,eType,username,password) " +
                            "values('" + name + "','" + age + "','" + gender + "','" + address + "','" + city + "','" + country + "', '" + phone + "', '" + eType + "','" + username + "', '" + password + "')";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Inserted");
                    }
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Password Mismatch");
                
            }
        }

        private void WriteToFile()
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream("Amandeep.txt", FileMode.OpenOrCreate | FileMode.Append, FileAccess.Write);
                StreamWriter bw = new StreamWriter(fs);

                SqlConnection con = new SqlConnection(sqlConnectionString);
                con.Open();
                string query = $"select name,username,age,eType,phone from Employee where username='{user}' and password='{passs}'";
                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string n = dr.GetString(0);
                        string u = dr.GetString(1);
                        string a = dr.GetString(2);
                        string eT = dr.GetString(3);
                        int p = dr.GetInt32(4);
                        MessageBox.Show(n);
                        bw.Write(n);
                        bw.Write(u);
                        bw.Write(a);
                        bw.Write(eT);
                        bw.Write(p);
                    }
                }
                bw.Close();
                fs.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        private void ReadFromFile()
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream("Amandeep.bin", FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                while (fs.CanRead)
                {
                    string n1 = br.ReadString();
                    string u1 = br.ReadString();
                    string a1 = br.ReadString();
                    string eT1 = br.ReadString();
                    int p1 = br.ReadInt32();

                    //if (enumvalue == "CityAreaType")
                    //{
                    //    enumValueConvertedToString = "City";
                    //    CityAreaType a = new CityAreaType() { SizeOfHouse = sizeOfHouse, SizeOfHoldingTank = capacityOfHoldingTank, CreditCard = creditCardInput, AreaTypeSelected = enumValueConvertedToString };
                    //    list.Add(a);
                    //}
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            HideLogin();
            HideFront();
            ShowRear();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            HideFront();
            HideRear();
            ShowLogin();
        }
    }
}