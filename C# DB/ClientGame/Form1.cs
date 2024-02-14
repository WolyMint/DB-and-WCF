using System;
using System.Windows.Forms;
using System.ServiceModel;
using ClientGame.ServiceGame;
using WCF;
using TicTacToe;

namespace ClientGame
{
    public partial class Form1 : Form, IServiceGameCallback
    {
        ServiceGameClient client;
        Game game;
        public User user;
        int count = 0;
        bool create = true;
        
        public Form1()
        {
            InitializeComponent();
            client = new ServiceGameClient(new InstanceContext(this));
            rbJoin.Checked = true;
        }
        public void ButtonEnabled()
        {
            game.ButtonEnabled();
        }
        public void ButtonDisenabled()
        {
            game.ButtonDisenabled();
        }
        public void CrossOrZeroCallBack(string crossOrZero, int i)
        {
            game.CrossOrZeroCallBack(crossOrZero,i);
        }
        public void CheckDrawCallBack()
        {
            game.CheckDrawCallBack();
        }
        public void AgreementCallBack()
        {
            game.AgreementCallBack();
        }
        public void ClearButton()
        {
            game.ClearButton();
        }
        public void LeaveGameCallBack()
        {
            game.LeaveGameCallback();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(tbId.Text);
                string password = tbPassword.Text;
                string player = tbNickname.Text;
                client = new ServiceGameClient(new InstanceContext(this));
                if (rbCreate.Checked && create)
                {
                    count++;
                    create = false;
                    user = client.Connect(player, id, password, true);
                    game = new Game(client, user);
                    client.CreateHistory(id, player);
                    Visible = false;
                    if(game.ShowDialog() == DialogResult.OK) DialogResult = DialogResult.OK;
                }

               
                if (rbJoin.Checked && client.CheckIdAndPassword(id, password))
                {
                    count++;
                    user = client.Connect(player, id, password, false);
                    game = new Game(client, user);
                    client.UpdateHistory(id, player);
                    client.StartGame();
                    Visible = false;
                    if(game.ShowDialog() == DialogResult.OK) DialogResult = DialogResult.OK;
                }
            }
            catch(FaultException<NoDataFault> ex)
            {
                MessageBox.Show(ex.Message,"Опа-чки",MessageBoxButtons.OK);
            }
            
            
            
        }

        private void rbCreate_Click(object sender, EventArgs e)
        {
            if (rbCreate.Checked)
            {
                tbId.Text = client.EnterId().ToString();
                tbId.Enabled = false;
            }
        }
        private void rbJoin_CheckedChanged(object sender, EventArgs e)
        {
            if(rbJoin.Checked)
            {
                tbId.Text = "";
                tbId.Enabled = true;
                
            }
        }
        public void WinOrLose()
        {
            game.WinOrLose();
        }
    }
}
