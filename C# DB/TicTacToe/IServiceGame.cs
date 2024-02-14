using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using TicTacToe;

namespace WCF
{
    [ServiceContract(CallbackContract = typeof(IServiceCallBack))]
    public interface IServiceGame
    {
        [OperationContract]
        [FaultContract(typeof(NoDataFault))]
        User Connect(string name,int id, string password,bool createOrJoin);

        [OperationContract]
        int EnterId();
        [OperationContract]
        [FaultContract(typeof(NoDataFault))]
        bool CheckIdAndPassword(int id, string password);

        [OperationContract]
        void CreateHistory(int id, string nickname);

        [OperationContract(IsOneWay = true)]
        void StartGame();

        [OperationContract]
        void UpdateHistory(int id,string player);

        [OperationContract(IsOneWay = true)]
        void EnabledOrDisenabled();
        [OperationContract(IsOneWay = true)]
        void CrossOrZero(int i);
        [OperationContract(IsOneWay = true)]
        void CheckWin(int i,int userId);
        [OperationContract(IsOneWay = true)]
        void CheckDraw();
        [OperationContract(IsOneWay = true)]
        void Agreement(int id);
        [OperationContract]
        void LeaveGame(int id);
        [OperationContract]
        void EndHistory(int id);
    }
    [ServiceContract]
    public interface IServiceCallBack
    {
        [OperationContract(IsOneWay = true)]
        void ButtonEnabled();
        [OperationContract(IsOneWay = true)]
        void ButtonDisenabled();
        [OperationContract(IsOneWay = true)]
        void CrossOrZeroCallBack(string crossOrZero,int i);
        [OperationContract(IsOneWay = true)]
        void WinOrLose();
        [OperationContract(IsOneWay = true)]
        void CheckDrawCallBack();
        [OperationContract(IsOneWay = true)]
        void AgreementCallBack();
        [OperationContract(IsOneWay = true)]
        void ClearButton();
        [OperationContract(IsOneWay = true)]
        void LeaveGameCallBack();
    }
    [DataContract]
    public class NoDataFault { }

}
