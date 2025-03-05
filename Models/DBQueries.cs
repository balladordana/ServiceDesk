using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using System.Xml.Linq;
using System.Reflection;
using System.Net;

namespace ServiceDesk.Models
{
    public class DBQueries
    {
        private OleDbConnection Con;
        private OleDbCommand cmd;
        private OleDbDataAdapter da;
        private DataTable dt;
        public DBQueries() {
            Con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=D:\\Лабы\\4 курс\\диплом\\ServiceDesk\\ServiceDesk.accdb");
            cmd = new OleDbCommand();
            cmd.Connection = Con;
            Con.Open();
        }
        public string Login(string login, string pass)
        {
            string Query = ("SELECT [Роль пользователя] FROM [Пользователи] WHERE ([Логин]=@login AND [Пароль]=@pass);");
            OleDbCommand cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@pass", pass);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;
            DataTable ds = new DataTable();
            da.Fill(ds);
            return ds.Rows[0][0].ToString();
        }
        public string LoginID(string login, string pass)
        {
            string Query = ("SELECT [Код пользователя] FROM [Пользователи] WHERE ([Логин]=@login AND [Пароль]=@pass);");
            OleDbCommand cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@pass", pass);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;
            DataTable ds = new DataTable();
            da.Fill(ds);
            return ds.Rows[0][0].ToString();
        }
        public DataTable GetBrigads()
        {
            string Query = "SELECT * FROM [Бригады];";
            da = new OleDbDataAdapter(Query, Con);
            dt = new DataTable();
            da.Fill(dt);
            
            return dt;
        }
        public DataTable GetBrigadsName()
        {
            string Query = "SELECT [Наименование бригады] FROM [Бригады];";
            da = new OleDbDataAdapter(Query, Con);
            dt = new DataTable();
            da.Fill(dt);
            
            return dt;
        }

        public void DeleteBrigads(int id)
        {
            string Query = "DELETE * FROM [Бригады] WHERE [Код бригады]=@id;";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@id", id);
            da = new OleDbDataAdapter();
            da.DeleteCommand = cmd;
            cmd.ExecuteNonQuery();
            
        }
        public void EditBrigads( string name, string FIO, int kol, string tel, int idb)
        {
            string Query = "UPDATE [Бригады] SET [Наименование бригады] = @name, [ФИО бригадира]=@FIO, [Количество работников] = @kol, [Телефон бригадира] = @tel  WHERE [Код бригады]=@idb;";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@FIO", FIO);
            cmd.Parameters.AddWithValue("@kol", kol);
            cmd.Parameters.AddWithValue("@tel", tel);
            cmd.Parameters.AddWithValue("@idb", idb);
            da = new OleDbDataAdapter();
            da.DeleteCommand = cmd;
            cmd.ExecuteNonQuery();
            
        }
        public void AddBrigads(string name, string FIO, int kol, string tel)
        {
            string Query = "INSERT INTO [Бригады] ([Наименование бригады], [ФИО бригадира], [Количество работников], [Телефон бригадира]) VALUES (@name,@FIO,@kol,@tel);";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@FIO", FIO);
            cmd.Parameters.AddWithValue("@kol", kol);
            cmd.Parameters.AddWithValue("@tel", tel);
            da = new OleDbDataAdapter();
            da.DeleteCommand = cmd;
            cmd.ExecuteNonQuery();
            
        }

        public DataTable GetClients()
        {
            string Query = "SELECT * FROM [Клиенты];";
            da = new OleDbDataAdapter(Query, Con);
            dt = new DataTable();
            da.Fill(dt);
            
            return dt;
        }

        public void DeleteClients(int id)
        {
            string Query = "DELETE * FROM [Клиенты] WHERE [Код клиента]=@id;";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@id", id);
            da = new OleDbDataAdapter();
            da.DeleteCommand = cmd;
            cmd.ExecuteNonQuery();
            
        }
        public void EditClients(string fam, string name,  string otch, string add, int idb)
        {
            string Query = "UPDATE [Клиенты] SET [Фамилия] = @fam, [Имя]=@name, [Отчество] = @otch, [Адрес] = @add  WHERE [Код клиента]=@id;";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@fam", fam);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@otch", otch);
            cmd.Parameters.AddWithValue("@add", add);
            cmd.Parameters.AddWithValue("@idb", idb);
            da = new OleDbDataAdapter();
            da.DeleteCommand = cmd;
            cmd.ExecuteNonQuery();
            
        }
        public void AddClients(string name, string fam, string otch, string add)
        {
            string Query = "INSERT INTO [Клиенты] ([Имя],[Фамилия],  [Отчество], [Адрес]) VALUES (@name,@fam,@otch,@add);";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@fam", fam);
            cmd.Parameters.AddWithValue("@otch", otch);
            cmd.Parameters.AddWithValue("@add", add);
            da = new OleDbDataAdapter();
            da.DeleteCommand = cmd;
            cmd.ExecuteNonQuery();
            
        }
        public DataTable GetTime(string date)
        {
            string Query = "SELECT [Наименование бригады], " +
                "IIF([Заявки].[Номер заявки] <> '' AND [Монтажи].[Время начала] <= '08:00' AND [Монтажи].[Время окончания] >= '08:00', [Заявки].[Номер заявки], '') AS [08:00]," +
                "IIF([Заявки].[Номер заявки] <> '' AND [Монтажи].[Время начала] <= '08:30' AND [Монтажи].[Время окончания] >= '08:30', [Заявки].[Номер заявки], '') AS [08:30]," +
                "IIF([Заявки].[Номер заявки] <> '' AND [Монтажи].[Время начала] <= '09:00' AND [Монтажи].[Время окончания] >= '09:00', [Заявки].[Номер заявки], '') AS [09:00], " +
                "IIF([Заявки].[Номер заявки] <> '' AND [Монтажи].[Время начала] <= '09:30' AND [Монтажи].[Время окончания] >= '09:30', [Заявки].[Номер заявки], '') AS [09:30], " +
                "IIF([Заявки].[Номер заявки] <> '' AND [Монтажи].[Время начала] <= '10:00' AND [Монтажи].[Время окончания] >= '10:00', [Заявки].[Номер заявки], '') AS [10:00], " +
                "IIF([Заявки].[Номер заявки] <> '' AND [Монтажи].[Время начала] <= '10:30' AND [Монтажи].[Время окончания] >= '10:30', [Заявки].[Номер заявки], '') AS [10:30], " +
                "IIF([Заявки].[Номер заявки] <> '' AND [Монтажи].[Время начала] <= '11:00' AND [Монтажи].[Время окончания] >= '11:00', [Заявки].[Номер заявки], '') AS [11:00], " +
                "IIF([Заявки].[Номер заявки] <> '' AND [Монтажи].[Время начала] <= '11:30' AND [Монтажи].[Время окончания] >= '11:30', [Заявки].[Номер заявки], '') AS [11:30], " +
                "IIF([Заявки].[Номер заявки] <> '' AND [Монтажи].[Время начала] <= '12:00' AND [Монтажи].[Время окончания] >= '12:00', [Заявки].[Номер заявки], '') AS [12:00], " +
                "IIF([Заявки].[Номер заявки] <> '' AND [Монтажи].[Время начала] <= '12:30' AND [Монтажи].[Время окончания] >= '12:30', [Заявки].[Номер заявки], '') AS [12:30], " +
                "IIF([Заявки].[Номер заявки] <> '' AND [Монтажи].[Время начала] <= '13:00' AND [Монтажи].[Время окончания] >= '13:00', [Заявки].[Номер заявки], '') AS [13:00], " +
                "IIF([Заявки].[Номер заявки] <> '' AND [Монтажи].[Время начала] <= '13:30' AND [Монтажи].[Время окончания] >= '13:30', [Заявки].[Номер заявки], '') AS [13:30], " +
                "IIF([Заявки].[Номер заявки] <> '' AND [Монтажи].[Время начала] <= '14:00' AND [Монтажи].[Время окончания] >= '14:00', [Заявки].[Номер заявки], '') AS [14:00], " +
                "IIF([Заявки].[Номер заявки] <> '' AND [Монтажи].[Время начала] <= '14:30' AND [Монтажи].[Время окончания] >= '14:30', [Заявки].[Номер заявки], '') AS [14:30], " +
                "IIF([Заявки].[Номер заявки] <> '' AND [Монтажи].[Время начала] <= '15:00' AND [Монтажи].[Время окончания] >= '15:00', [Заявки].[Номер заявки], '') AS [15:00], " +
                "IIF([Заявки].[Номер заявки] <> '' AND [Монтажи].[Время начала] <= '15:30' AND [Монтажи].[Время окончания] >= '15:30', [Заявки].[Номер заявки], '') AS [15:30], " +
                "IIF([Заявки].[Номер заявки] <> '' AND [Монтажи].[Время начала] <= '16:00' AND [Монтажи].[Время окончания] >= '16:00', [Заявки].[Номер заявки], '') AS [16:00], " +
                "IIF([Заявки].[Номер заявки] <> '' AND [Монтажи].[Время начала] <= '16:30' AND [Монтажи].[Время окончания] >= '16:30', [Заявки].[Номер заявки], '') AS [16:30], " +
                "IIF([Заявки].[Номер заявки] <> '' AND [Монтажи].[Время начала] <= '17:00' AND [Монтажи].[Время окончания] >= '17:00', [Заявки].[Номер заявки], '') AS [17:00], " +
                "IIF([Заявки].[Номер заявки] <> '' AND [Монтажи].[Время начала] <= '17:30' AND [Монтажи].[Время окончания] >= '17:30', [Заявки].[Номер заявки], '') AS [17:30], " +
                "IIF([Заявки].[Номер заявки] <> '' AND [Монтажи].[Время начала] <= '18:00' AND [Монтажи].[Время окончания] >= '18:00', [Заявки].[Номер заявки], '') AS [18:00], " +
                "IIF([Заявки].[Номер заявки] <> '' AND [Монтажи].[Время начала] <= '18:30' AND [Монтажи].[Время окончания] >= '18:30', [Заявки].[Номер заявки], '') AS [18:30], " +
                "IIF([Заявки].[Номер заявки] <> '' AND [Монтажи].[Время начала] <= '19:00' AND [Монтажи].[Время окончания] >= '19:00', [Заявки].[Номер заявки], '') AS [19:00], " +
                "IIF([Заявки].[Номер заявки] <> '' AND [Монтажи].[Время начала] <= '19:30' AND [Монтажи].[Время окончания] >= '19:30', [Заявки].[Номер заявки], '') AS [19:30] " +
                "FROM ([Монтажи] INNER JOIN [Бригады] ON [Монтажи].[Код бригады] = [Бригады].[Код бригады])  " +
                "INNER JOIN [Заявки] ON [Монтажи].[Код заявки] = [Заявки].[Код заявки]" +
                "WHERE [Монтажи].[Дата] = @date;";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@date", date);
            da = new OleDbDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            
            return dt;
        }

        public DataTable GetApplications()
        {
            string Query = "SELECT Заявки.[Номер заявки], Клиенты.Фамилия, Клиенты.Имя, Клиенты.Отчество, Клиенты.Адрес, [Тип конструкции].[Наименование конструкции], " +
                "Состояния.Наименование, [Тип заявки].[Наименование заявки] FROM [Тип заявки] INNER JOIN (Состояния INNER JOIN ([Тип конструкции] INNER JOIN " +
                "(Клиенты INNER JOIN Заявки ON Клиенты.[Код клиента] = Заявки.[Код клиента]) ON [Тип конструкции].[Код конструкции] = Заявки.[Код конструкции]) " +
                "ON Состояния.[Код состояния] = Заявки.[Код состояния]) ON [Тип заявки].[Код типа заявки] = Заявки.[Код типа заявки]" +
                "ORDER BY Заявки.[Код заявки] DESC;";
            da = new OleDbDataAdapter(Query, Con);
            dt = new DataTable();
            da.Fill(dt);
            
            return dt;
        }
        public DataTable GetApplicationsZamer()
        {
            string Query = "SELECT Заявки.[Номер заявки], Клиенты.Фамилия, Клиенты.Имя, Клиенты.Отчество, Клиенты.Адрес, [Тип конструкции].[Наименование конструкции], " +
                "Состояния.Наименование, [Тип заявки].[Наименование заявки] FROM [Тип заявки] INNER JOIN (Состояния INNER JOIN ([Тип конструкции] INNER JOIN " +
                "(Клиенты INNER JOIN Заявки ON Клиенты.[Код клиента] = Заявки.[Код клиента]) ON [Тип конструкции].[Код конструкции] = Заявки.[Код конструкции]) " +
                "ON Состояния.[Код состояния] = Заявки.[Код состояния]) ON [Тип заявки].[Код типа заявки] = Заявки.[Код типа заявки]" +
                "WHERE Состояния.Наименование = @status ORDER BY Заявки.[Код заявки] DESC;";
            string status = "Замер";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@status", status);
            da = new OleDbDataAdapter();
            dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
        public DataTable GetApplication(string App)
        {
            string Query = "SELECT Заявки.[Номер заявки], Клиенты.Фамилия, Клиенты.Имя, Клиенты.Отчество, Клиенты.Адрес, [Тип конструкции].[Наименование конструкции], " +
                "Состояния.Наименование, [Тип заявки].[Наименование заявки] FROM [Тип заявки] INNER JOIN (Состояния INNER JOIN ([Тип конструкции] INNER JOIN " +
                "(Клиенты INNER JOIN Заявки ON Клиенты.[Код клиента] = Заявки.[Код клиента]) ON [Тип конструкции].[Код конструкции] = Заявки.[Код конструкции]) " +
                "ON Состояния.[Код состояния] = Заявки.[Код состояния]) ON [Тип заявки].[Код типа заявки] = Заявки.[Код типа заявки]" +
                "WHERE Заявки.[Номер заявки] = @app;";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@app", App);
            da = new OleDbDataAdapter();
            dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
        public DataTable GetReklamaApplications()
        {
            string Query = "SELECT Заявки.[Номер заявки], Клиенты.Фамилия, Клиенты.Имя, Клиенты.Отчество, Клиенты.Адрес, [Тип конструкции].[Наименование конструкции], " +
                "Состояния.Наименование, [Тип заявки].[Наименование заявки] FROM [Тип заявки] INNER JOIN (Состояния INNER JOIN ([Тип конструкции] INNER JOIN " +
                "(Клиенты INNER JOIN Заявки ON Клиенты.[Код клиента] = Заявки.[Код клиента]) ON [Тип конструкции].[Код конструкции] = Заявки.[Код конструкции]) " +
                "ON Состояния.[Код состояния] = Заявки.[Код состояния]) ON [Тип заявки].[Код типа заявки] = Заявки.[Код типа заявки]" +
                "WHERE [Тип заявки].[Код типа заявки] = 1;";
            da = new OleDbDataAdapter(Query, Con);
            dt = new DataTable();
            da.Fill(dt);
            
            return dt;
        }
        public DataTable GetSortApplications()
        {
            string Query = "SELECT Заявки.[Номер заявки], Клиенты.Фамилия, Клиенты.Имя, Клиенты.Отчество, Клиенты.Адрес, [Тип конструкции].[Наименование конструкции], " +
                "Состояния.Наименование, [Тип заявки].[Наименование заявки] FROM [Тип заявки] INNER JOIN (Состояния INNER JOIN ([Тип конструкции] INNER JOIN " +
                "(Клиенты INNER JOIN Заявки ON Клиенты.[Код клиента] = Заявки.[Код клиента]) ON [Тип конструкции].[Код конструкции] = Заявки.[Код конструкции]) " +
                "ON Состояния.[Код состояния] = Заявки.[Код состояния]) ON [Тип заявки].[Код типа заявки] = Заявки.[Код типа заявки]" +
                "ORDER BY Заявки.[Код заявки] ASC;";
            da = new OleDbDataAdapter(Query, Con);
            dt = new DataTable();
            da.Fill(dt);
            
            return dt;
        }
        public DataTable GetFilterApplications(string status)
        {
            string Query = "SELECT Заявки.[Номер заявки], Клиенты.Фамилия, Клиенты.Имя, Клиенты.Отчество, Клиенты.Адрес, [Тип конструкции].[Наименование конструкции], " +
                "Состояния.Наименование, [Тип заявки].[Наименование заявки] FROM [Тип заявки] INNER JOIN (Состояния INNER JOIN ([Тип конструкции] INNER JOIN " +
                "(Клиенты INNER JOIN Заявки ON Клиенты.[Код клиента] = Заявки.[Код клиента]) ON [Тип конструкции].[Код конструкции] = Заявки.[Код конструкции]) " +
                "ON Состояния.[Код состояния] = Заявки.[Код состояния]) ON [Тип заявки].[Код типа заявки] = Заявки.[Код типа заявки]" +
                "WHERE Состояния.[Наименование] = @status;";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@status", status);
            da = new OleDbDataAdapter();
            dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);            
            return dt;
        }
        public void SetApplication(string App, string Name, string Surname, string Otch, string Address, string Type, string Construct, string LoginID)
        {
            string Query = "INSERT INTO [Клиенты] ([Фамилия], [Имя], [Отчество], [Адрес]) VALUES (@surname, @name, @otch, @address)";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@surname", Surname);
            cmd.Parameters.AddWithValue("@name", Name);
            cmd.Parameters.AddWithValue("@otch", Otch);
            cmd.Parameters.AddWithValue("@address", Address);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.InsertCommand = cmd;
            cmd.ExecuteNonQuery();
            Query = "SELECT [Код типа заявки] FROM [Тип заявки] WHERE [Наименование заявки] = @type";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@type", Type);
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);
            int type = Convert.ToInt32(dt.Rows[0][0]);
            Query = "SELECT [Код конструкции] FROM [Тип конструкции] WHERE [Наименование конструкции] = @construct";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@construct", Construct);
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);
            int construct = Convert.ToInt32(dt.Rows[0][0]);
            Query = "SELECT [Код сотрудника] FROM [Сотрудники] WHERE [Код пользователя] = @id";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@id", LoginID);
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);
            int id = Convert.ToInt32(dt.Rows[0][0]);
            Query = "SELECT TOP 1 Клиенты.[Код клиента] FROM [Клиенты] ORDER BY Клиенты.[Код клиента] DESC";
            da = new OleDbDataAdapter(Query, Con);
            dt = new DataTable();
            da.Fill(dt);
            int client = Convert.ToInt32(dt.Rows[0][0]);
            Query = "INSERT INTO [Заявки] ([Номер заявки], [Код клиента], [Код типа заявки], [Код сотрудника], [Код конструкции])" +
                "VALUES (@app , @client , @type,  @id , @construct);";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@app", App);
            cmd.Parameters.AddWithValue("@client", client);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@construct", construct);
            da.InsertCommand = cmd;
            cmd.ExecuteNonQuery();
            
        }
        public void SetResponsible(string FIO, string App)
        {
            string Query = "SELECT [Код сотрудника], [Код пользователя] FROM [Сотрудники] " +
                "WHERE [Сотрудники]![Фамилия сотрудника] & \" \" & [Сотрудники]![Имя сотрудника] & \" \" & [Сотрудники]![Отчество сотрудника] = @fio;";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@fio", FIO);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);

            int sotrud = Convert.ToInt32(dt.Rows[0][0]);
            int pol = Convert.ToInt32(dt.Rows[0][1]);

            Query = "UPDATE [Заявки] SET [Код сотрудника] = @sotrud " +
                "WHERE [Номер заявки] = @app;";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@sotrud", sotrud);
            cmd.Parameters.AddWithValue("@app", App);
            da.UpdateCommand = cmd;
            cmd.ExecuteNonQuery();

            Query = "SELECT [Роль пользователя] FROM [Пользователи] " +
                "WHERE [Код пользователя] = @pol;";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@pol", pol);
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);
            
            if (dt.Rows[0][0].ToString() == "Специалист-замерщик")
            {
                SetStatus(App, 2);
            }
            
        }
        public void SetStatus(string App, int status)
        {
            string date = DateTime.Now.ToString("dd.MM.yyyy");
            string Query = "UPDATE [Заявки] SET [Код состояния] = @status, [Дата изменения состояния] = @date WHERE [Номер заявки] = @app;";
            OleDbCommand cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@app", App);
            OleDbDataAdapter da = new OleDbDataAdapter
            {
                UpdateCommand = cmd
            };
            cmd.ExecuteNonQuery();            
        }
        public string GetStatus(string App)
        {
            DateTime date = DateTime.Now.AddDays(-3);
            string Query = "SELECT Состояния.Наименование, Заявки.[Дата изменения состояния] FROM Состояния INNER JOIN Заявки " +
                "ON Состояния.[Код состояния] = Заявки.[Код состояния]" +
                "WHERE Заявки.[Номер заявки] = @app;";
            OleDbCommand cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@app", App);
            dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count == 0) return "";
            else 
            {
                if (dt.Rows[0][0].ToString() == "Замер") 
                {
                    if (DateTime.Parse(dt.Rows[0][1].ToString()) < date) return dt.Rows[0][0].ToString(); 
                    else  return "";
                }  
                else return dt.Rows[0][0].ToString();
            };    
        }
        public DataTable GetExpired()
        {

            string Query = "SELECT Заявки.[Номер заявки], Бригады.[Наименование бригады], Бригады.[ФИО бригадира], Бригады.[Телефон бригадира]" +
                "FROM Состояния INNER JOIN (Заявки INNER JOIN (Бригады INNER JOIN Монтажи ON Бригады.[Код бригады] = Монтажи.[Код бригады]) " +
                "ON Заявки.[Код заявки] = Монтажи.[Код заявки]) ON Состояния.[Код состояния] = Заявки.[Код состояния] " +
                "WHERE Состояния.Наименование = @status;";
            string status = "Просрочено";
            OleDbCommand cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@status", status);
            dt = new DataTable();
            da = new OleDbDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
        public DataTable GetExpiredDate()
        {

            string Query = "SELECT Монтажи.Дата FROM Состояния INNER JOIN (Заявки INNER JOIN Монтажи ON Заявки.[Код заявки] = Монтажи.[Код заявки]) " +
                "ON Состояния.[Код состояния] = Заявки.[Код состояния] WHERE Состояния.Наименование= @status;";
            string status = "Просрочено";
            OleDbCommand cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@status", status);
            dt = new DataTable();
            da = new OleDbDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
        public DataTable GetFired()
        {

            string Query = "SELECT Заявки.[Номер заявки], Бригады.[Наименование бригады], Бригады.[ФИО бригадира], Бригады.[Телефон бригадира]" +
                "FROM Состояния INNER JOIN (Заявки INNER JOIN (Бригады INNER JOIN Монтажи ON Бригады.[Код бригады] = Монтажи.[Код бригады]) " +
                "ON Заявки.[Код заявки] = Монтажи.[Код заявки]) ON Состояния.[Код состояния] = Заявки.[Код состояния] " +
                "WHERE Состояния.Наименование = @status AND Заявки.[Дата изменения состояния] <= @date;";
            string status = "Замер";
            OleDbCommand cmd = new OleDbCommand(Query, Con);
            DateTime date = DateTime.Now.AddDays(-3);
            string sdate = date.ToString("dd.MM.yyyy");
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@date", sdate);
            dt = new DataTable();
            da = new OleDbDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
        public void SetComment(string App, string Comment)
        {
            string Query = "UPDATE [Заявки] SET [Комментарий замерщика] = @comment " +
                "WHERE [Номер заявки] = @app;";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@comment", Comment);
            cmd.Parameters.AddWithValue("@app", App);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.UpdateCommand = cmd;
            cmd.ExecuteNonQuery();
            SetStatus(App, 3);
        }
        public DataTable GetWorks()
        {
            string Query = "SELECT [Наименование работы] FROM [Нормативы работ];";
            da = new OleDbDataAdapter(Query, Con);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetAllWorks(string App, string Type)
        {
            string Query = "SELECT [Код норматива работы] FROM [Нормативы работ] WHERE [Наименование работы] = @type";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@type", Type);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);
            int type = Convert.ToInt32(dt.Rows[0][0]);

            Query = "SELECT [Код заявки] FROM [Заявки] WHERE [Номер заявки] = @app";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@app", App);
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);
            int app = Convert.ToInt32(dt.Rows[0][0]);

            Query = "SELECT [Нормативы работ].[Наименование работы], [Нормативы работ].Длительность, Работы.[Объем работы] " +
                "FROM Заявки INNER JOIN ([Нормативы работ] INNER JOIN Работы ON [Нормативы работ].[Код норматива работы] = Работы.[Код норматива работы]) ON Заявки.[Код заявки] = Работы.[Код заявки]" +
                "WHERE(((Заявки.[Номер заявки]) = @app)); ";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@app", App);
            da = new OleDbDataAdapter();
            dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            
            return dt;
        }
        public void SetAllWorks(string App, string Type, int Ob)
        {
            string Query = "SELECT [Код норматива работы] FROM [Нормативы работ] WHERE [Наименование работы] = @type";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@type", Type);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);
            int type = Convert.ToInt32(dt.Rows[0][0]);

            Query = "SELECT [Код заявки] FROM [Заявки] WHERE [Номер заявки] = @app";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@app", App);
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);
            int app = Convert.ToInt32(dt.Rows[0][0]);

            Query = "INSERT INTO [Работы] ([Код заявки], [Код норматива работы], [Объем работы]) VALUES (@app, @type, @ob)";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@app", app);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@ob", Ob);
            da.InsertCommand = cmd;
            cmd.ExecuteNonQuery();
        }
        public int GetAllWorksTime(string App)
        {
            string Query = "SELECT SUM([Нормативы работ].Длительность * Работы.[Объем работы])" +
                "FROM Заявки INNER JOIN ([Нормативы работ] INNER JOIN Работы ON [Нормативы работ].[Код норматива работы] = Работы.[Код норматива работы]) ON Заявки.[Код заявки] = Работы.[Код заявки]" +
                "WHERE(((Заявки.[Номер заявки]) = @app)); ";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@app", App);
            OleDbDataAdapter da = new OleDbDataAdapter();
            dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
        public int GetAllWorksTime(string App, string Brigada, string Date, string Time, int Dif)
        {
            string Query = "SELECT [Код бригады] FROM [Бригады] WHERE [Наименование бригады] = @brigada";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@brigada", Brigada);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);
            int brigada = Convert.ToInt32(dt.Rows[0][0]);

            Query = "SELECT [Код заявки] FROM [Заявки] WHERE [Номер заявки] = @app";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@app", App);
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);
            int app = Convert.ToInt32(dt.Rows[0][0]);

            Query = "SELECT [Время начала], [Время окончания] FROM [Монтажи] " +
                "WHERE [Код заявки] = @app AND [Код бригады] = @brigada AND [Дата] = @date";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@app", app);
            cmd.Parameters.AddWithValue("@brigada", brigada);
            cmd.Parameters.AddWithValue("@date", Date);
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);
            DateTime time = DateTime.Parse(Time);
            if (dt.Rows.Count > 0)
            {
                for (int i = dt.Rows.Count; i > 0; i--)
                {
                    DateTime time1 = DateTime.Parse(dt.Rows[i - 1][0].ToString());
                    DateTime time2 = DateTime.Parse(dt.Rows[i - 1][1].ToString());
                    DateTime time3 = time.AddMinutes(Dif);
                    if ((time >= time1 && time <= time2) || (time3 >= time1 && time3 <= time2)) return 1;
                }
            }

            if (Dif % 30 != 0) Dif = Dif + (30 - Dif % 30);
            Query = "INSERT INTO [Монтажи] ([Код бригады], [Код заявки], [Дата], [Время начала], [Время окончания])" +
                " VALUES (@brigada, @app, @date, @timefirst, @timelast)";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@brigada", brigada);
            cmd.Parameters.AddWithValue("@app", app);
            cmd.Parameters.AddWithValue("@date", Date);
            cmd.Parameters.AddWithValue("@timefirst", Time);
            cmd.Parameters.AddWithValue("@timelast", time.AddMinutes(Dif).TimeOfDay);
            da = new OleDbDataAdapter();
            da.InsertCommand = cmd;
            cmd.ExecuteNonQuery();
            SetStatus(App, 4);
            return 0;
        }
        public void CheckExpired()
        {
            string date = DateTime.Now.ToString("dd.MM.yyyy");
            string Query = "SELECT  [Номер заявки], [Время окончания], [Дата] FROM " +
                "[Монтажи] INNER JOIN [Заявки] ON Монтажи.[Код заявки] = Заявки.[Код заявки] " +
                "WHERE [Дата] = @date;";
            cmd = new OleDbCommand(Query, Con);
            cmd.Parameters.AddWithValue("@date", date);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;
            cmd.ExecuteNonQuery();
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = dt.Rows.Count; i > 0; i--)
                {
                    DateTime time2 = DateTime.Parse(dt.Rows[i - 1][1].ToString());
                    DateTime time = DateTime.Now.ToLocalTime();
                    if (time >= time2) SetStatus(dt.Rows[i - 1][0].ToString(), 6);
                }
            }
        }
        public DataTable GetTypes()
        {
            string Query = "SELECT [Наименование заявки] FROM [Тип заявки];";
            da = new OleDbDataAdapter(Query, Con);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetConstructions()
        {
            string Query = "SELECT [Наименование конструкции] FROM [Тип конструкции];";
            da = new OleDbDataAdapter(Query, Con);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetSotrudniki()
        {
            string Query = "SELECT [Сотрудники]![Фамилия сотрудника] & \" \" & [Сотрудники]![Имя сотрудника] & \" \" & [Сотрудники]![Отчество сотрудника] AS ФИО  FROM [Сотрудники];";
            da = new OleDbDataAdapter(Query, Con);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetStatuses()
        {
            string Query = "SELECT [Наименование] FROM [Состояния];";
            da = new OleDbDataAdapter(Query, Con);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

    }
}
