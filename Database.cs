using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Npgsql;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace TestApplicationShulte
{
    class Database
    {
        // Строка подключения к БД
        private static string connectionString = "Server=localhost;Database=test_bd; User Id=postgres; Password=3421416;";

        // получение хэша SHA256 от строки
        public string getHash(string str)
        {
            return BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(str))).Replace("-", "").ToLower();
        }

        // Открыть соединение к БД (строка подключения)
        // Возвращается false
        private bool openConnection(string connString, out NpgsqlConnection conn, out string errorMessage)
        {
            conn = null;
            errorMessage = string.Empty;
            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();
                if (conn == null || conn.FullState != ConnectionState.Open)
                    throw new Exception();
                else return true;
            }
            catch (Exception)
            {
                errorMessage = "Не удалось установить соединение с базой данных!\nПожалуйста, повторите попытку позже...";
                return false;
            }
        }

        // Авторизация по логину и паролю
        public int authorization(string login, string password, out string errorMessage, out User userObject)
        {
            errorMessage = "";
            userObject = null;
            NpgsqlConnection conn = null;

            try
            {
                if (openConnection(Database.connectionString, out conn, out string message) == false)
                {
                    throw new Exception(errorMessage);
                }
                NpgsqlCommand query = null;
                NpgsqlDataReader sqlReader = null;
                try
                {
                    query = new NpgsqlCommand("SELECT id, login, name, birthday, gender, user_type, passhash FROM public.users WHERE TRIM(login) = TRIM(@login);", conn);
                    query.Parameters.AddWithValue("login", login);
                    sqlReader = query.ExecuteReader();
                }
                catch (Exception error)
                {
                    throw new Exception("Ошибка доступа к базе данных!\nПожалуйста, повторите попытку позже...");
                }

                if (sqlReader.Read() == false) // если введенный логин не найден
                {
                    throw new Exception("Неверные логин или пароль!");
                }
                else
                    try
                    {
                        if (password != sqlReader.GetString(6).ToLower()) // если введенный пароль не совпал
                        {
                            throw new Exception("Неверные логин или пароль!");
                        }
                        else
                        {
                            userObject = new User();
                            userObject.id = sqlReader.GetGuid(0);
                            userObject.login = login;
                            userObject.name = sqlReader.GetString(2);
                            userObject.birthday = sqlReader.GetDateTime(3);
                            userObject.gender = sqlReader.GetString(4);
                            userObject.user_type = sqlReader.GetString(5);
                            userObject.passHash = sqlReader.GetString(6);

                            if (conn != null) conn.Close();

                            if (userObject.user_type == "user")
                                return 1;

                            if (userObject.user_type == "admin")
                                return 2;
                        }
                    }
                    catch (Exception)
                    {
                        throw new Exception("Ошибка получения данных из базы данных!\nПожалуйста, повторите попытку позже...");
                    }
            }
            catch (Exception error)
            {
                if (conn != null) conn.Close();
                errorMessage = error.Message;
                return 0;
            }

            return 0;
        }

        // TODO // Считывание всех пользователей в список
        public bool readAllUsers(out DataTable Res, out string errorMessage)
        {
            DataSet ds = new DataSet();
            errorMessage = "";
            NpgsqlConnection conn = null;
            try
            {
                if (this.openConnection(Database.connectionString, out conn, out string message) == false)
                {
                    throw new Exception(message);
                }

                NpgsqlDataAdapter query = null;
                try
                {
                    query = new NpgsqlDataAdapter("SELECT * FROM public.users", conn);
                }
                catch (Exception error)
                {
                    throw new Exception("Ошибка доступа к базе данных при выполнении sql-запроса!\nПожалуйста, повторите попытку позже...");
                }
                try
                {
                    ds.Reset();
                    query.Fill(ds);
                    Res = ds.Tables[0];
                    if (conn != null)
                        conn.Close();
                    return true;
                }
                catch (Exception)
                {
                    throw new Exception("Ошибка получения данных из базы данных при выполнении sql-запроса!\nПожалуйста, повторите попытку позже...");
                }
            }
            catch (Exception error)
            {
                if (conn != null)
                    conn.Close();
                errorMessage = error.Message;
                Res = null;
                return false;
            }

            return false;
        }

        // Добавление нового пользователя
        public bool registerNewUser(User user, out string errorMessage)
        {
            errorMessage = "";
            NpgsqlConnection conn = null;

            try
            {
                if (openConnection(connectionString, out conn, out string message) == false)
                {
                    throw new Exception(message);
                }
                NpgsqlCommand query = null;
                try
                {
                    user.id = Guid.NewGuid();
                    query = new NpgsqlCommand("INSERT INTO public.users (id, login, name, birthday, gender, user_type, passhash) VALUES (@id::uuid, @login, @name, @birthday::timestamp, @gender, @user_type, @passhash);", conn);
                    query.Parameters.AddWithValue("id", user.id);
                    query.Parameters.AddWithValue("login", user.login);
                    query.Parameters.AddWithValue("name", user.name);
                    query.Parameters.AddWithValue("birthday", user.birthday.ToString());
                    query.Parameters.AddWithValue("gender", user.gender);
                    query.Parameters.AddWithValue("user_type", user.user_type);
                    query.Parameters.AddWithValue("passhash", user.passHash);
                    query.ExecuteNonQuery();
                    if (conn != null) conn.Close();
                    return true;
                }
                catch (Exception error)
                {
                    throw new Exception("Ошибка доступа к базе данных при добавлении записи пользователя!\n");
                }

            }
            catch (Exception error)
            {
                if (conn != null) conn.Close();
                errorMessage = error.Message;
                return false;
            }
        }

        // Изменение информации о пользователе
        public bool UpDate(List<User> Users, out string errorMessage)
        {
            errorMessage = "";
            NpgsqlConnection conn = null;

            try
            {
                if (openConnection(Database.connectionString, out conn, out string message) == false)
                {
                    throw new Exception(message);
                }
                NpgsqlCommand update = null;
                try
                {
                    for (int i = 0; i < Users.Count; i++)
                    {
                        update = new NpgsqlCommand("UPDATE users SET login = @login, name = @name, birthday = @birthday::timestamp, gender = @gender, user_type = @user_type, passhash = @passhash WHERE id = @id::uuid;", conn);
                        update.Parameters.AddWithValue("id", Users[i].id);
                        update.Parameters.AddWithValue("login", Users[i].login);
                        update.Parameters.AddWithValue("name", Users[i].name);
                        update.Parameters.AddWithValue("birthday", Users[i].birthday.ToString());
                        update.Parameters.AddWithValue("gender", Users[i].gender);
                        update.Parameters.AddWithValue("user_type", Users[i].user_type);
                        update.Parameters.AddWithValue("passhash", Users[i].passHash);
                        update.ExecuteNonQuery();
                    }
                    if (conn != null)
                        conn.Close();
                    return true;
                }
                catch (Exception error)
                {
                    string s = error.Message;
                    throw new Exception("Ошибка доступа к базе данных при изменении записи пользователя!\n");
                }

            }
            catch (Exception error)
            {
                if (conn != null)
                    conn.Close();
                errorMessage = error.Message;
                return false;
            }
        }

        // Сохранение результата в БД
        public bool saveResult(Result res, out string errorMessage)
        {
            errorMessage = "";
            NpgsqlConnection conn = null;

            try
            {
                if (this.openConnection(Database.connectionString, out conn, out string message) == false)
                {
                    throw new Exception(message);
                }
                NpgsqlCommand query = null;

                //res.id = Guid.NewGuid(); // генерация нового id для результата

                query = new NpgsqlCommand("INSERT INTO public.tests (id, login, created_date, workability, mental_stab) VALUES (@id::uuid, @login, @created_date::timestamp, @workability, @mental_stab);", conn);
                query.Parameters.AddWithValue("id", res.id);
                query.Parameters.AddWithValue("login", res.login);
                query.Parameters.AddWithValue("created_date", res.dateCreated.ToString());
                query.Parameters.AddWithValue("workability", res.workability);
                query.Parameters.AddWithValue("mental_stab", res.mental_stab);
                query.ExecuteNonQuery();
                if (conn != null) conn.Close();
                return true;
            }
            catch (Exception error)
            {
                if (conn != null) conn.Close();
                errorMessage = error.Message;
                return false;
            }
        }

        // Загрузка результатов одного пользователя
        public bool loadResultsUser(Guid userID, out List<Result> listRes, out string errorMessage)
        {
            listRes = new List<Result>();
            errorMessage = "";
            NpgsqlConnection conn = null;
            try
            {
                if (this.openConnection(Database.connectionString, out conn, out string message) == false)
                {
                    throw new Exception(message);
                }

                NpgsqlCommand query = null;
                NpgsqlDataReader sqlReader = null;
                try
                {
                    query = new NpgsqlCommand("SELECT id, login, created_date, workability, mental_stab FROM public.tests WHERE id = @id::uuid;", conn);
                    query.Parameters.AddWithValue("id", userID.ToString());
                    sqlReader = query.ExecuteReader();
                }
                catch (Exception error)
                {
                    throw new Exception("Ошибка доступа к базе данных при выполнении sql-запроса!\nПожалуйста, повторите попытку позже...");
                }
                try
                {
                    while (sqlReader.Read() == true)
                    {
                        Result temp = new Result();

                        temp.id = sqlReader.GetGuid(0);
                        temp.login = sqlReader.GetString(1);
                        temp.dateCreated = sqlReader.GetDateTime(2);
                        temp.workability = sqlReader.GetDouble(3);
                        temp.mental_stab = sqlReader.GetDouble(4);

                        listRes.Add(temp);
                    }
                    if (conn != null) conn.Close();
                    return true;
                }
                catch (Exception)
                {
                    throw new Exception("Ошибка получения данных из базы данных при выполнении sql-запроса!\nПожалуйста, повторите попытку позже...");
                }



            }
            catch (Exception error)
            {
                if (conn != null) conn.Close();
                errorMessage = error.Message;
                return false;
            }
        }

      
        public bool loadResultsUserAdmin(string userID, out DataTable Res, out string errorMessage)
        {
            DataSet ds = new DataSet();
            errorMessage = "";
            NpgsqlConnection conn = null;
            try
            {
                if (this.openConnection(Database.connectionString, out conn, out string message) == false)
                {
                    throw new Exception(message);
                }

                NpgsqlDataAdapter query = null;
                try
                {
                    query = new NpgsqlDataAdapter("SELECT * FROM public.tests WHERE id = '" + userID + "';", conn);
                }
                catch (Exception error)
                {
                    throw new Exception("Ошибка доступа к базе данных при выполнении sql-запроса!\nПожалуйста, повторите попытку позже...");
                }
                try
                {
                    ds.Reset();
                    query.Fill(ds);
                    Res = ds.Tables[0];
                    if (conn != null)
                        conn.Close();
                    return true;
                }
                catch (Exception)
                {
                    throw new Exception("Ошибка получения данных из базы данных при выполнении sql-запроса!\nПожалуйста, повторите попытку позже...");
                }



            }
            catch (Exception error)
            {
                Res = null;
                if (conn != null)
                    conn.Close();
                errorMessage = error.Message;
                return false;
            }
        }

        public bool LoadAllRes(out DataTable Res, out string errorMessage)
        {
            DataSet ds = new DataSet();
            errorMessage = "";
            NpgsqlConnection conn = null;
            try
            {
                if (this.openConnection(Database.connectionString, out conn, out string message) == false)
                {
                    throw new Exception(message);
                }

                NpgsqlDataAdapter query = null;
                try
                {
                    query = new NpgsqlDataAdapter("SELECT * FROM public.tests", conn);
                }
                catch (Exception error)
                {
                    throw new Exception("Ошибка доступа к базе данных при выполнении sql-запроса!\nПожалуйста, повторите попытку позже...");
                }
                try
                {
                    ds.Reset();
                    query.Fill(ds);
                    Res = ds.Tables[0];
                    if (conn != null)
                        conn.Close();
                    return true;
                }
                catch (Exception)
                {
                    throw new Exception("Ошибка получения данных из базы данных при выполнении sql-запроса!\nПожалуйста, повторите попытку позже...");
                }
            }
            catch (Exception error)
            {
                if (conn != null)
                    conn.Close();
                errorMessage = error.Message;
                Res = null;
                return false;
            }
        }

        // Сохранение результата локально в файл
        public bool saveResultFile(string path, Result res, out string errorMessage)
        {
            errorMessage = "";
            string strSave = "";
            string symb = "=";

            try
            {
                strSave += res.id.ToString() + symb;
                strSave += res.dateCreated.ToString() + symb;
                strSave += res.workability.ToString() + symb;
                strSave += res.mental_stab + "=";

                System.IO.File.WriteAllText(path, strSave, Encoding.UTF8);
                errorMessage = "Результат успешно записан в файл:\n" + path;
                return true;
            }
            catch (Exception error)
            {
                errorMessage = "Не удалось сохранить результат в файл локально.\n" + error.Message;
                return false;
            }
        }

        // Загрузка результата из файл
        public bool readResultFile(string path, out Result res, out string errorMessage)
        {
            errorMessage = "";
            res = new Result();
            string strRead = "";
            char symb = '=';
            string[] words;

            try
            {
                strRead = System.IO.File.ReadAllText(path, Encoding.UTF8);
                words = strRead.Split(new char[] { symb }, StringSplitOptions.RemoveEmptyEntries);
                res.id = Guid.Parse(words[0]);
                res.dateCreated = DateTime.Parse(words[1]);
                res.workability = Convert.ToDouble(words[2]);
                res.mental_stab = Convert.ToInt32(words[3]);

                return true;
            }
            catch (Exception error)
            {
                errorMessage = "Не удалось загрузить результат из файл, возможно он поврежден.\n" + error.Message;
                return false;
            }
        }
    }
}
