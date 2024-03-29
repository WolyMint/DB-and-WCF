﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientGame.ServiceGame {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="NoDataFault", Namespace="http://schemas.datacontract.org/2004/07/WCF")]
    [System.SerializableAttribute()]
    public partial class NoDataFault : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceGame.IServiceGame", CallbackContract=typeof(ClientGame.ServiceGame.IServiceGameCallback))]
    public interface IServiceGame {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceGame/Connect", ReplyAction="http://tempuri.org/IServiceGame/ConnectResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(ClientGame.ServiceGame.NoDataFault), Action="http://tempuri.org/IServiceGame/ConnectNoDataFaultFault", Name="NoDataFault", Namespace="http://schemas.datacontract.org/2004/07/WCF")]
        TicTacToe.User Connect(string name, int id, string password, bool createOrJoin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceGame/Connect", ReplyAction="http://tempuri.org/IServiceGame/ConnectResponse")]
        System.Threading.Tasks.Task<TicTacToe.User> ConnectAsync(string name, int id, string password, bool createOrJoin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceGame/EnterId", ReplyAction="http://tempuri.org/IServiceGame/EnterIdResponse")]
        int EnterId();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceGame/EnterId", ReplyAction="http://tempuri.org/IServiceGame/EnterIdResponse")]
        System.Threading.Tasks.Task<int> EnterIdAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceGame/CheckIdAndPassword", ReplyAction="http://tempuri.org/IServiceGame/CheckIdAndPasswordResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(ClientGame.ServiceGame.NoDataFault), Action="http://tempuri.org/IServiceGame/CheckIdAndPasswordNoDataFaultFault", Name="NoDataFault", Namespace="http://schemas.datacontract.org/2004/07/WCF")]
        bool CheckIdAndPassword(int id, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceGame/CheckIdAndPassword", ReplyAction="http://tempuri.org/IServiceGame/CheckIdAndPasswordResponse")]
        System.Threading.Tasks.Task<bool> CheckIdAndPasswordAsync(int id, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceGame/CreateHistory", ReplyAction="http://tempuri.org/IServiceGame/CreateHistoryResponse")]
        void CreateHistory(int id, string nickname);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceGame/CreateHistory", ReplyAction="http://tempuri.org/IServiceGame/CreateHistoryResponse")]
        System.Threading.Tasks.Task CreateHistoryAsync(int id, string nickname);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceGame/StartGame")]
        void StartGame();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceGame/StartGame")]
        System.Threading.Tasks.Task StartGameAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceGame/UpdateHistory", ReplyAction="http://tempuri.org/IServiceGame/UpdateHistoryResponse")]
        void UpdateHistory(int id, string player);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceGame/UpdateHistory", ReplyAction="http://tempuri.org/IServiceGame/UpdateHistoryResponse")]
        System.Threading.Tasks.Task UpdateHistoryAsync(int id, string player);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceGame/EnabledOrDisenabled")]
        void EnabledOrDisenabled();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceGame/EnabledOrDisenabled")]
        System.Threading.Tasks.Task EnabledOrDisenabledAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceGame/CrossOrZero")]
        void CrossOrZero(int i);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceGame/CrossOrZero")]
        System.Threading.Tasks.Task CrossOrZeroAsync(int i);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceGame/CheckWin")]
        void CheckWin(int i, int userId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceGame/CheckWin")]
        System.Threading.Tasks.Task CheckWinAsync(int i, int userId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceGame/CheckDraw")]
        void CheckDraw();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceGame/CheckDraw")]
        System.Threading.Tasks.Task CheckDrawAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceGame/Agreement")]
        void Agreement(int id);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceGame/Agreement")]
        System.Threading.Tasks.Task AgreementAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceGame/LeaveGame", ReplyAction="http://tempuri.org/IServiceGame/LeaveGameResponse")]
        void LeaveGame(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceGame/LeaveGame", ReplyAction="http://tempuri.org/IServiceGame/LeaveGameResponse")]
        System.Threading.Tasks.Task LeaveGameAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceGame/EndHistory", ReplyAction="http://tempuri.org/IServiceGame/EndHistoryResponse")]
        void EndHistory(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceGame/EndHistory", ReplyAction="http://tempuri.org/IServiceGame/EndHistoryResponse")]
        System.Threading.Tasks.Task EndHistoryAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceGameCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceGame/ButtonEnabled")]
        void ButtonEnabled();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceGame/ButtonDisenabled")]
        void ButtonDisenabled();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceGame/CrossOrZeroCallBack")]
        void CrossOrZeroCallBack(string crossOrZero, int i);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceGame/WinOrLose")]
        void WinOrLose();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceGame/CheckDrawCallBack")]
        void CheckDrawCallBack();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceGame/AgreementCallBack")]
        void AgreementCallBack();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceGame/ClearButton")]
        void ClearButton();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceGame/LeaveGameCallBack")]
        void LeaveGameCallBack();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceGameChannel : ClientGame.ServiceGame.IServiceGame, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceGameClient : System.ServiceModel.DuplexClientBase<ClientGame.ServiceGame.IServiceGame>, ClientGame.ServiceGame.IServiceGame {
        
        public ServiceGameClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ServiceGameClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ServiceGameClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceGameClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceGameClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public TicTacToe.User Connect(string name, int id, string password, bool createOrJoin) {
            return base.Channel.Connect(name, id, password, createOrJoin);
        }
        
        public System.Threading.Tasks.Task<TicTacToe.User> ConnectAsync(string name, int id, string password, bool createOrJoin) {
            return base.Channel.ConnectAsync(name, id, password, createOrJoin);
        }
        
        public int EnterId() {
            return base.Channel.EnterId();
        }
        
        public System.Threading.Tasks.Task<int> EnterIdAsync() {
            return base.Channel.EnterIdAsync();
        }
        
        public bool CheckIdAndPassword(int id, string password) {
            return base.Channel.CheckIdAndPassword(id, password);
        }
        
        public System.Threading.Tasks.Task<bool> CheckIdAndPasswordAsync(int id, string password) {
            return base.Channel.CheckIdAndPasswordAsync(id, password);
        }
        
        public void CreateHistory(int id, string nickname) {
            base.Channel.CreateHistory(id, nickname);
        }
        
        public System.Threading.Tasks.Task CreateHistoryAsync(int id, string nickname) {
            return base.Channel.CreateHistoryAsync(id, nickname);
        }
        
        public void StartGame() {
            base.Channel.StartGame();
        }
        
        public System.Threading.Tasks.Task StartGameAsync() {
            return base.Channel.StartGameAsync();
        }
        
        public void UpdateHistory(int id, string player) {
            base.Channel.UpdateHistory(id, player);
        }
        
        public System.Threading.Tasks.Task UpdateHistoryAsync(int id, string player) {
            return base.Channel.UpdateHistoryAsync(id, player);
        }
        
        public void EnabledOrDisenabled() {
            base.Channel.EnabledOrDisenabled();
        }
        
        public System.Threading.Tasks.Task EnabledOrDisenabledAsync() {
            return base.Channel.EnabledOrDisenabledAsync();
        }
        
        public void CrossOrZero(int i) {
            base.Channel.CrossOrZero(i);
        }
        
        public System.Threading.Tasks.Task CrossOrZeroAsync(int i) {
            return base.Channel.CrossOrZeroAsync(i);
        }
        
        public void CheckWin(int i, int userId) {
            base.Channel.CheckWin(i, userId);
        }
        
        public System.Threading.Tasks.Task CheckWinAsync(int i, int userId) {
            return base.Channel.CheckWinAsync(i, userId);
        }
        
        public void CheckDraw() {
            base.Channel.CheckDraw();
        }
        
        public System.Threading.Tasks.Task CheckDrawAsync() {
            return base.Channel.CheckDrawAsync();
        }
        
        public void Agreement(int id) {
            base.Channel.Agreement(id);
        }
        
        public System.Threading.Tasks.Task AgreementAsync(int id) {
            return base.Channel.AgreementAsync(id);
        }
        
        public void LeaveGame(int id) {
            base.Channel.LeaveGame(id);
        }
        
        public System.Threading.Tasks.Task LeaveGameAsync(int id) {
            return base.Channel.LeaveGameAsync(id);
        }
        
        public void EndHistory(int id) {
            base.Channel.EndHistory(id);
        }
        
        public System.Threading.Tasks.Task EndHistoryAsync(int id) {
            return base.Channel.EndHistoryAsync(id);
        }
    }
}
