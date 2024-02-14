using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TicTacToe;

namespace WCF
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceGame : IServiceGame
    {
        public static string connectionString = "Server = (localdb)\\LocalDB; Database = TicTacToe; Trusted_Connection = True; TrustServerCertificate = True;";
        List<User> users = new List<User>();
        int nextId = 1;
        bool activity;
        string crossOrZero;
        string[,] results;
        bool win;
        string winUserNameOrDraw;
        public User Connect(string name,int id, string password,bool create)
        {
            if(name == "")
            {
                throw new FaultException<NoDataFault>(new NoDataFault(), "Введите имя!");
            }
            User user = new User()
            {
                ID = nextId,
                Name = name,
                IdRoom = id,
                PasswordRoom = password,
                Create = create,
                OperationContext = OperationContext.Current
            };
            
            nextId++;
            users.Add(user);
            return user;
        }
        public int EnterId()
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = "select count (*) from Table_GamingHistory";
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return (int)dataTable.Rows[0][0] + 1;
            }
        }
        public bool CheckIdAndPassword(int id, string password)
        {
            foreach (var user in users)
            {
                if (user.IdRoom == id && user.PasswordRoom == password) return true;
                else throw new FaultException<NoDataFault>(new NoDataFault(), "Неправильно введён Id или пароль!");
            }
            return false;
        }

        public void CreateHistory(int id, string firstPlayer)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = "Insert into Table_GamingHistory (ID,FirstPlayer,Status) Values (@id,@firstPlayer,@status)";
                SqlCommand command = new SqlCommand(sqlExpression,connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@firstPlayer", firstPlayer);
                string status = "Waiting";
                command.Parameters.AddWithValue("@status", status);
                command.ExecuteNonQuery();
            }
        }

        public void StartGame()
        {
            foreach(var user in users)
            {
                if (user.Create)
                {
                    activity = true;
                    user.OperationContext.GetCallbackChannel<IServiceCallBack>().ClearButton();
                    user.OperationContext.GetCallbackChannel<IServiceCallBack>().ButtonEnabled();
                }
                else
                {
                    user.OperationContext.GetCallbackChannel<IServiceCallBack>().ClearButton();
                    user.OperationContext.GetCallbackChannel<IServiceCallBack>().ButtonDisenabled();
                }
            }
            results = new string[3,3];
            win = false;
        }

        public void UpdateHistory(int id,string player)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = "Update Table_GamingHistory set SecondPlayer = @Player, Status = @status where ID = @id";
                SqlCommand command = new SqlCommand(sqlExpression,connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@Player", player);
                string status = "Game";
                command.Parameters.AddWithValue("@status", status);
                command.ExecuteNonQuery();
            }
        }
        public void EnabledOrDisenabled()
        {
            foreach (var user in users)
            {
                if (activity)
                {
                    user.OperationContext.GetCallbackChannel<IServiceCallBack>().ButtonDisenabled();
                    activity = false;
                }
                else
                {
                    user.OperationContext.GetCallbackChannel<IServiceCallBack>().ButtonEnabled();
                    activity = true;
                }
            }
            activity = !activity;
        }
        public void CrossOrZero(int i)
        {
            string crossOrZero;
            foreach (var user in users)
            {
                if (activity)
                    crossOrZero = "X";
                else crossOrZero = "O";
                this.crossOrZero = crossOrZero;
                user.OperationContext.GetCallbackChannel<IServiceCallBack>().CrossOrZeroCallBack(this.crossOrZero, i);
            }
        }
        //public string GetCrossOrZero(int i)
        //{
        //    string crossOrZero = "";
        //    foreach(var user in users)
        //    {
        //        if(activity)
        //            crossOrZero = "X";
        //        else crossOrZero = "O";
        //    }
        //    return crossOrZero;
        //}
        public void CheckWin(int i,int userId)
        {
            foreach (var user in users)
            {
                switch (i)
                {
                    case 1:
                        results[0, 0] = crossOrZero;
                        break;
                    case 2:
                        results[0, 1] = crossOrZero;
                        break;
                    case 3:
                        results[0, 2] = crossOrZero;
                        break;
                    case 4:
                        results[1, 0] = crossOrZero;
                        break;
                    case 5:
                        results[1, 1] = crossOrZero;
                        break;
                    case 6:
                        results[1, 2] = crossOrZero;
                        break;
                    case 7:
                        results[2, 0] = crossOrZero;
                        break;
                    case 8:
                        results[2, 1] = crossOrZero;
                        break;
                    case 9:
                        results[2, 2] = crossOrZero;
                        break;
                }
                if (((results[0, 0] == results[0, 1] && results[0, 1] == results[0, 2]) && (results[0, 0] == "X" || results[0, 0] == "O")) ||
                    ((results[1, 0] == results[1, 1] && results[1, 1] == results[1, 2]) && (results[1, 0] == "X" || results[1, 0] == "O")) ||
                    ((results[2, 0] == results[2, 1] && results[2, 1] == results[2, 2]) && (results[2, 0] == "X" || results[2, 0] == "O")) ||

                    ((results[0, 0] == results[1, 0] && results[1, 0] == results[2, 0]) && (results[0, 0] == "X" || results[0, 0] == "O")) ||
                    ((results[0, 1] == results[1, 1] && results[1, 1] == results[2, 1]) && (results[0, 1] == "X" || results[0, 1] == "O")) ||
                    ((results[0, 2] == results[1, 2] && results[1, 2] == results[2, 2]) && (results[0, 2] == "X" || results[0, 2] == "O")) ||

                    ((results[0, 0] == results[1, 1] && results[1, 1] == results[2, 2]) && (results[0, 0] == "X" || results[0, 0] == "O")) ||
                    ((results[0, 2] == results[1, 1] && results[1, 1] == results[2, 0]) && (results[0, 2] == "X" || results[0, 2] == "O"))
                    )
                {

                    win = true;
                    var winUser = users.FirstOrDefault(j => j.ID == userId);
                    winUserNameOrDraw = winUser.Name;
                    user.OperationContext.GetCallbackChannel<IServiceCallBack>().WinOrLose();
                }
                
            }
        }
        public void CheckDraw()
        {
            if (!win)
            {
                winUserNameOrDraw = "Draw";
                foreach (var user in users)
                {
                    user.OperationContext.GetCallbackChannel<IServiceCallBack>().CheckDrawCallBack();
                }
            }
        }
        public void Agreement(int id)
        {
            foreach(var user in users) 
            {
                if(user.ID != id)
                {
                    user.OperationContext.GetCallbackChannel<IServiceCallBack>().AgreementCallBack();
                }
            }
        }
       public void LeaveGame(int id) 
       {
            foreach(var user in users)
            { 
                if(user.ID != id)
                {
                    user.OperationContext.GetCallbackChannel<IServiceCallBack>().LeaveGameCallBack();
                } 
            }
            users.Clear();
       }
       public void EndHistory(int id)
       {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = "Update Table_GamingHistory set Status = @status, WinnerOrDraw = @winnerOrDraw where ID = @id";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddWithValue("@id", id);
                string status = "End";
                command.Parameters.AddWithValue("@status", status);
                command.Parameters.AddWithValue("@winnerOrDraw", winUserNameOrDraw);
                command.ExecuteNonQuery();
            }
       }

        
    }
}
