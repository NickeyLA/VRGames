using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Controls;

namespace VRgames
{
    public static class Adapter
    {
        public static BDclasses.User ActiveUser;
        public static BDclasses.Admin ActiveAdmin;
        public static BDclasses.LastDB[] ZapEl { get { return AnotherLIst.ToArray(); } }
        private static List<BDclasses.LastDB> AnotherLIst = new List<BDclasses.LastDB>();
        public static BDclasses.LastDBCli[] ZapElCli { get { return AnotherLIstCli.ToArray(); } }
        private static List<BDclasses.LastDBCli> AnotherLIstCli = new List<BDclasses.LastDBCli>();
        private static MySqlConnection DBConnector = new MySqlConnection("server=localhost;port=3306;user=root;password=root;database=vrgames");

        public static BDclasses.LastDB[] GetServerPredZap()
        {
            DBConnector.Close();
            DBConnector.Open();
            
            string sql = $"SELECT * FROM `last`";
            MySqlCommand command = new MySqlCommand(sql, DBConnector);
            MySqlDataReader rdr = command.ExecuteReader();
            DBConnector.Close();
            DBConnector.Open();
            DataTable temp = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(temp);
            var zapis = new List<BDclasses.LastDB>();
            foreach (DataRow item in temp.Rows)
            {
                BDclasses.LastDB zap = new BDclasses.LastDB()
                {
                    id = (uint)item.Field<int>(0),
                    user_login = item.Field<string>(1),
                    time = item.Field<string>(2),
                    data = item.Field<string>(3),
                };
                zapis.Add(zap);
            }
            DBConnector.Close();
            AnotherLIst = zapis;
            return zapis.ToArray();


        }

        public static void RemoveElementToLast(BDclasses.LastDB zap)
        {
            AnotherLIst.Remove(zap);
            DBConnector.Open();
            string sql = "";
            sql = $"DELETE FROM `last` WHERE id = '{zap.id}'";
            MySqlCommand command = new MySqlCommand(sql, DBConnector);
            MySqlDataReader rdr = command.ExecuteReader();
            rdr.Close();
            DBConnector.Close();
        }

        public static bool Login(string login, string password, out string Message)
        {
            bool respowns;
            DBConnector.Open();
            string sql = $"SELECT * FROM `users` WHERE login = '{login}' AND password = '{password}' ";
            MySqlCommand command = new MySqlCommand(sql, DBConnector);
            MySqlDataReader rdr = command.ExecuteReader();
            rdr.Read();
            if (rdr.HasRows)
            {
                Message = "Вход выполнен успешно";
                ActiveUser = new BDclasses.User
                {
                    id = rdr.GetUInt32("id"),
                    login = rdr.GetString("login"),
                    password = rdr.GetString("password"),
                };
                respowns = true;
            }
            else
            {
                Message = "Пароль или логин введены не правильно";
                respowns = false;
            }
            DBConnector.Close();
            return respowns;
        }

        public static bool AdminLogin(string login, string password, out string Message)
        {
            bool respowns;
            DBConnector.Open();
            string sql = $"SELECT * FROM `admin` WHERE login = '{login}' AND password = '{password}' ";
            MySqlCommand command = new MySqlCommand(sql, DBConnector);
            MySqlDataReader rdr = command.ExecuteReader();
            rdr.Read();
            if (rdr.HasRows)
            {
                Message = "Вход выполнен успешно";
                ActiveAdmin = new BDclasses.Admin
                {
                    id = rdr.GetUInt32("id"),
                    login = rdr.GetString("login"),
                    password = rdr.GetString("password"),
                };
                respowns = true;
            }
            else
            {
                Message = "Пароль или логин введены не правильно";
                respowns = false;
            }
            GetServerPredZap();
            GetServerPredZapCli();
            DBConnector.Close();
            return respowns;
        }

        public static bool Registration(string login, string password, out string Message)
        {
            bool respowns;
            DBConnector.Open();
            string sql = $"SELECT * FROM `users` WHERE login = '{login}' ";
            MySqlCommand command = new MySqlCommand(sql, DBConnector);
            MySqlDataReader rdr = command.ExecuteReader();
            rdr.Read();
            if (rdr.HasRows)
            {
                Message = "Такой логин уже занят";
                respowns = false;
            }
            else
            {
                MySqlCommand command2 = new MySqlCommand($"INSERT INTO `users`(`id`, `login`, `password`) VALUES (null, '{login}','{password}')", DBConnector);
                rdr.Close();
                command2.ExecuteNonQuery();
                Message = "Регистрация успешна!";
                respowns = true;
            }
            DBConnector.Close();
            return respowns;
        }

        public static BDclasses.LastDBCli[] GetServerPredZapCli()
        {
            DBConnector.Close();
            DBConnector.Open();

            string sql = $"SELECT * FROM `lastCli`";
            MySqlCommand command = new MySqlCommand(sql, DBConnector);
            MySqlDataReader rdr = command.ExecuteReader();
            DBConnector.Close();
            DBConnector.Open();
            DataTable tempCli = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(tempCli);
            var zapis = new List<BDclasses.LastDBCli>();
            foreach (DataRow itemCli in tempCli.Rows)
            {
                BDclasses.LastDBCli zap = new BDclasses.LastDBCli()
                {
                    id = (uint)itemCli.Field<int>(0),
                    user_login = itemCli.Field<string>(1),
                    time = itemCli.Field<string>(2),
                    data = itemCli.Field<string>(3),
                };
                zapis.Add(zap);
            }
            DBConnector.Close();
            AnotherLIstCli = zapis;
            return zapis.ToArray();


        }

        public static void OutNewCli(string dataCli, string timeCli, string FIOCli)
        {
            DBConnector.Open();
            MySqlCommand command = new MySqlCommand($"INSERT INTO `lastCli`(`id`, `time`, `data`, `user_login`) VALUES (null, '{timeCli}','{dataCli}', '{FIOCli}')", DBConnector);
            command.ExecuteNonQuery();
            DBConnector.Close();
            GetServerPredZapCli();
        }

        public static void AddElLastCli(BDclasses.LastDBCli zapCli)
        {
            AnotherLIstCli.Add(zapCli);
        }

        public static void RemoveElementToLastCli(BDclasses.LastDBCli zapCli)
        {
            AnotherLIstCli.Remove(zapCli);
            DBConnector.Open();
            string sql = "";
            sql = $"DELETE FROM `lastCli` WHERE id = '{zapCli.id}'";
            MySqlCommand command = new MySqlCommand(sql, DBConnector);
            MySqlDataReader rdr = command.ExecuteReader();
            rdr.Close();
            DBConnector.Close();
        }

        public static bool OutLast(string data, string time, string FIO, out string Message)
        {
            bool respowns;
            DBConnector.Open();
            string sql = $"SELECT * FROM `last` WHERE time = '{time}' AND data = '{data}'";
            MySqlCommand command = new MySqlCommand(sql, DBConnector);
            MySqlDataReader rdr = command.ExecuteReader();
            rdr.Read();
            if (rdr.HasRows)
            {
                Message = "На это время и этот день уже есть запись";
                respowns = false;
            }
            else
            {
                MySqlCommand command2 = new MySqlCommand($"INSERT INTO `last`(`id`, `time`, `data`, `user_login`) VALUES (null, '{time}','{data}', '{FIO}')", DBConnector);
                rdr.Close();
                command2.ExecuteNonQuery();
                Message = "Запись существует";
                respowns = true;
            }
            DBConnector.Close();
            return respowns;
        }
    }
}