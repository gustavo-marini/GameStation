using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace GameStation
{
    class Basics
    {
        public static string limpaCep(string cep)
        {
            cep = cep.Replace("-", "");
            return cep;
        }


        public static string limpaString(string s)
        {
            return Regex.Replace(s, "[^0-9.]", "");
        }


        public static dynamic getBirthdate(string birth)
        {
            int day = Convert.ToInt32(birth.Split('/')[0]);
            int month = Convert.ToInt32(birth.Split('/')[1]);
            int year = Convert.ToInt32(birth.Split('/')[2]);

            return new { day = day, month = month, year = year };
        }


        public static string httpGet(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }


        public static int calculateAge(DateTime birth)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birth.Year;
            if (birth > today.AddYears(-age)) age--;

            return age;
        }
    }
}
