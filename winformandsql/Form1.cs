using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winformandsql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }


        private void btnfill_Click(object sender, EventArgs e)
        {
            FetchData();
        }


        private void FetchData()
        {

            //BIRINCI DATABASE ILE ELAQE QURURUQ , DAHA SONRA DATABASEDEN GET GETIR DEYE BIR COMMAND YAZACAYIQ 

            SqlConnection sqlConnection = new SqlConnection();
            //bu bizim database ile baglanti yaratmagimizi temin edecek obyektdir ! 

            //indi burda bu hansi servere getmelidi < hansi database getmelidi < ve hansi melumatlari
            //almali oldugunu gostermeliyik  

            //sqlConnection.ConnectionString = "Server =DESKTOP-G936QCF;Database = Library ; User =Taleh; Pwd =123";
            //bu sql authentication ile baglanmadir .


            //eger windows authentification a baglaniriq sa yeni ki  shexsi sql e shexsi serverimizle 
            //yox komp ile giririkse o zaman yuxaridaki kimi server , database ve user vermeli deyilik 
            //onun eveine   <.> burada noqte localhost anlamina gelir , burada yegane ferqli shey 
            //integrated security = true edirik bunun menasi ise windows authentification a baglan 
            // demekdir 

            sqlConnection.ConnectionString = "Server=.; Database = Library ; Integrated Security = true;";
            //bu windows authentication ile baglanmadir . 


            //eger server uzaqdaki bir severdise onu bucur etmek olmur ,mecburi user ve server adi verilmelidir. 


            //sql komandalarini burda verib gedib sql den melumat cekmek ucun bize lazim olan SQL COMMAND DIR 

            SqlCommand command = new SqlCommand();
            //sql command bize deyir ki database de hansi commanda ishe salim ve hansi database  e gedim 
            command.CommandText = "select * from Students";

            command.Connection = sqlConnection;
            //daha sonra ise yazdigimiz commandi ishe salmaq ucun execute etmeliyik eyni ile sql deki kimi
            //burada ise  ExecuteReader edirik < bundan bahsqa yollarla da is salmaq mumkundur ; >

            //command.ExecuteReader(); // bu bize SqlDataReader qaytarir  yeni ki biz yazdigimiz kodun yerine 
            //bele bir sheyde yaza bilerik ki 

            //hemcinin burada biz execute etmemishden once bunlar arasindaki baglantini acmaliyiq daha sonra ise
            //baglanmalidir   ; 

            try
            {


                sqlConnection.Open();



                SqlDataReader rdr = command.ExecuteReader();
                //bu koda esasen sql den  sorgu vasitesi ile aldigimiz data lari  <rdr> obyektine atmish oluruq 


                //hemcinin  bir burada database deki melumatlari listbox da oxuyacayiq deye bir dongu acmaliyhiq ki 
                //hamsini oxusun


                //bize setirleri tek tek getirecek ve daha sonra ashaqi dushecek
                //indi ise biz gelen setirlerden neleri gormek isteyirik olari yazacayiq 
                while (rdr.Read())
                {
                    string id = rdr["Id"].ToString();
                    string firstname = rdr["FirstName"].ToString();
                    string lastname = rdr["LastName"].ToString();

                    listNSF.Items.Add(string.Format("{0}-{1}-{2}", id, firstname, lastname));
                }
            }
            finally
            {
                sqlConnection.Close();


            }

            //istesek baglamaya bilerik amma bele bir problem olacaq ki eger yeniden nese elde etmek 
            //istesek data base den ve open etsek onda error alacayiq  !!!
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            InsertData();
        }


        private void InsertData ()
        {
            SqlConnection sqlConnection1 = new SqlConnection();
            sqlConnection1.ConnectionString = "Server=.; Database = Library ; Integrated Security = true;";
                SqlCommand sqlCommand1 = new SqlCommand(); 
                sqlCommand1.CommandText = "INSERT INTO Students (Id,FirstName,LastName ,Id_Group , Term ) VALUES (26 , 'Johny' , 'Deep' , 333 , 2)";
                sqlCommand1.Connection = sqlConnection1;

            try
            {
                sqlConnection1.Open();
                SqlDataReader rdr1  = sqlCommand1.ExecuteReader();

                

            }
            finally
            {
                sqlConnection1.Close();
            }

        }






    }
}
