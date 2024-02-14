using ClientGame.ServiceGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe;
using WCF;

namespace ClientGame
{
    public partial class Game : Form
    {
        public ServiceGameClient client;
        public User User { get; set; }
        public int Id { get; set; }
        public string Password { get; set; }
        public string CrossOrZero { get; set; }
        
        
        public Game(ServiceGameClient client, User user)
        {
            this.client = client;
            User = user;
            InitializeComponent();
            tbId.Text = $"ID комнаты = {User.IdRoom}";
            tbPassword.Text = $"Пароль = {User.PasswordRoom}";
            lblNickname.Text = $"Ваш никнейм: {User.Name}";
            foreach(var control in Controls)
            {
                if(control is Button && ((Button)control) != btnRestartGame && ((Button)control) != btnLeaveGame)
                    ((Button)control).Enabled = false;
            }
            
        }
        
        public void ButtonEnabled()
        {
            foreach (var control in Controls)
            {
                if (control is Button && ((Button)control).Text == "")
                    ((Button)control).Enabled = true;
            }

        }
        public void ButtonDisenabled()
        {
            foreach (var control in Controls)
            {
                if (control is Button && ((Button)control) != btnRestartGame && ((Button)control) != btnLeaveGame)
                    ((Button)control).Enabled = false;
            }
        }
        public void CheckDrawCallBack()
        {
            bool t = true;
            foreach (var control in Controls)
            {
                if (control is Button && ((Button)control).Text == "")
                {
                    t = false;
                    break;
                }
            }
            if (t) MessageBox.Show("Ничья", "О-го", MessageBoxButtons.OK);
        }
        public void ClearButton()
        {
            foreach (var control in Controls)
            {
                if (control is Button && ((Button)control) != btnRestartGame && ((Button)control) != btnLeaveGame)
                {
                    ((Button)control).Text = "";
                }
            }
        }
        public void CrossOrZeroCallBack(string crossOrZero, int i)
        {
            switch (i)
            {
                case 1: 
                    btn1.Text = crossOrZero;
                    btn1.Enabled = false;
                    break;
                case 2:
                    btn2.Text = crossOrZero;
                    btn2.Enabled = false;
                    break;
                case 3:
                    btn3.Text = crossOrZero;
                    btn3.Enabled = false;
                    break;
                case 4:
                    btn4.Text = crossOrZero;
                    btn4.Enabled = false;
                    break;
                case 5:
                    btn5.Text = crossOrZero;
                    btn5.Enabled = false;
                    break;
                case 6:
                    btn6.Text = crossOrZero;
                    btn6.Enabled = false;
                    break;
                case 7:
                    btn7.Text = crossOrZero;
                    btn7.Enabled = false;
                    break;
                case 8:
                    btn8.Text = crossOrZero;
                    btn8.Enabled = false;
                    break;
                case 9:
                    btn9.Text = crossOrZero;
                    btn9.Enabled = false;
                    break;

            }
        }
        public void WinOrLose()
        {
            MessageBox.Show("Игра окончена", "Удивительно", MessageBoxButtons.OK);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            client.CrossOrZero(1);
            client.EnabledOrDisenabled();
            client.CheckWin(1,User.ID);
            client.CheckDraw();
            
        }

        private void btnRestartGame_Click(object sender, EventArgs e)
        {
            client.Agreement(User.ID);
        }
        public void AgreementCallBack()
        {
            DialogResult dialogResult = MessageBox.Show("Противник хочет начать игру сначала. Вы согласны?", "Опа-чки", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                client.StartGame();
            }
        }

        private void btnLeaveGame_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            client.EndHistory(User.IdRoom);
            client.LeaveGame(User.ID);
        }

        public void LeaveGameCallback()
        {
            MessageBox.Show("Противник покинул игру", "Упс", MessageBoxButtons.OK);
            DialogResult = DialogResult.OK;
            
        }

        
        private void btn2_Click(object sender, EventArgs e)
        {
            client.CrossOrZero(2);
            client.EnabledOrDisenabled();
            client.CheckWin(2,User.ID);
            client.CheckDraw();

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            client.CrossOrZero(3);
            client.EnabledOrDisenabled();
            client.CheckWin(3, User.ID);
            client.CheckDraw();

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            client.CrossOrZero(4);
            client.EnabledOrDisenabled();
            client.CheckWin(4, User.ID);
            client.CheckDraw();

        }

        private void btn5_Click(object sender, EventArgs e)
        {
            client.CrossOrZero(5);
            client.EnabledOrDisenabled();
            client.CheckWin(5, User.ID);
            client.CheckDraw();

        }

        private void btn6_Click(object sender, EventArgs e)
        {
            client.CrossOrZero(6);
            client.EnabledOrDisenabled();
            client.CheckWin(6, User.ID);
            client.CheckDraw();

        }

        private void btn7_Click(object sender, EventArgs e)
        {
            client.CrossOrZero(7);
            client.EnabledOrDisenabled();
            client.CheckWin(7, User.ID);
            client.CheckDraw();

        }

        private void btn8_Click(object sender, EventArgs e)
        {
            client.CrossOrZero(8);
            client.EnabledOrDisenabled();
            client.CheckWin(8, User.ID);
            client.CheckDraw();

        }

        private void btn9_Click(object sender, EventArgs e)
        {
            client.CrossOrZero(9);
            client.EnabledOrDisenabled();
            client.CheckWin(9, User.ID);
            client.CheckDraw();

        }

    }
}
