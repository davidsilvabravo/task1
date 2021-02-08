using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace MyStore.Utils
{
    class DataGenerator
    {
        //Generar un string de una longitud determinada
        public static string RandomString(int length)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            var rString = "";
            for (var i = 0; i < length; i++)
                rString += ((char)(random.Next(1, 26) + 64)).ToString().ToUpper();
            Thread.Sleep(1);
            return rString;
        }


        //Generar un correo aleatorio
        public static string RandomEmail()
        {
            return "user" + (new Random().Next(10000)) + "@gmail.com";
        }


        //Generar un string con formato de número de celular
        public static string RandomMobile()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            var rString = "";
            for (var i = 0; i < 9; i++)
                rString += ((char)(random.Next(48, 57) )).ToString();
            Thread.Sleep(1);
            return rString;
        }


        //Generar un string con formato de número fijo
        public static string RandomHome()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            var rString = "";
            for (var i = 0; i < 7; i++)
                rString += ((char)(random.Next(48, 57))).ToString();
            Thread.Sleep(1);
            return rString;
        }


        //Generar un string con formato de número. Recibe como parámetros 2 posibles valores: mínimo y máximo
        public static string RandomNumber(int min, int max)
        {
            int random = new Random().Next(min,max);
            return random.ToString();
        }


        //Generar un string con formato de zipcode
        public static string RandomZipCode()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            var rString = "";
            for (var i = 0; i < 5; i++)
                rString += ((char)(random.Next(48, 57))).ToString();
            Thread.Sleep(1);
            return rString;
        }
    }
}
