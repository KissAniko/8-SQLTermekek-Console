using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_SQLTermekek_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string kapcsolatleiro = "datasource=127.0.0.1;port=3306;database=hardver;username=root;password=;";

            MySqlConnection SQLkapcsolat = new MySqlConnection(kapcsolatleiro);
            try
            {
                SQLkapcsolat.Open();
            }
            catch (MySqlException hiba)
            {
                Console.WriteLine(hiba.Message);
                Environment.Exit(1);
            }

            // Mekkora különbség van a legolcsóbb és legdrágább egér között?

            string SQLSelect = " SELECT MAX(Ár)-MIN(Ár) as különbség " +
                               " FROM termékek " +
                               " WHERE Kategória = 'Egér'";

            MySqlCommand SQLparancs = new MySqlCommand(SQLSelect, SQLkapcsolat);
            MySqlDataReader eredmenyOlvaso = SQLparancs.ExecuteReader();
            while (eredmenyOlvaso.Read())
            {
                //Console.Write(eredmenyOlvaso.GetString("MAX(Ár)-MIN(Ár)") + " - ");
                Console.WriteLine("A különbség:");
                Console.WriteLine(Convert.ToInt32(eredmenyOlvaso.GetString("különbség")) + "\tFt");
            }
            eredmenyOlvaso.Close();
            SQLkapcsolat.Close();

        }
    }
}
