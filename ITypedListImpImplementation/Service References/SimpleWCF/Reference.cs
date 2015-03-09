﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ITypedListImpImplementation.SimpleWCF {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/SimpleWCF")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
                }
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SimpleWCF.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        System.IAsyncResult BeginGetData(int value, System.AsyncCallback callback, object asyncState);
        
        string EndGetData(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        ITypedListImpImplementation.SimpleWCF.CompositeType GetDataUsingDataContract(ITypedListImpImplementation.SimpleWCF.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        System.IAsyncResult BeginGetDataUsingDataContract(ITypedListImpImplementation.SimpleWCF.CompositeType composite, System.AsyncCallback callback, object asyncState);
        
        ITypedListImpImplementation.SimpleWCF.CompositeType EndGetDataUsingDataContract(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetXml", ReplyAction="http://tempuri.org/IService1/GetXmlResponse")]
        System.IO.Stream GetXml();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService1/GetXml", ReplyAction="http://tempuri.org/IService1/GetXmlResponse")]
        System.IAsyncResult BeginGetXml(System.AsyncCallback callback, object asyncState);
        
        System.IO.Stream EndGetXml(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : ITypedListImpImplementation.SimpleWCF.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetDataCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetDataCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetDataUsingDataContractCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetDataUsingDataContractCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public ITypedListImpImplementation.SimpleWCF.CompositeType Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((ITypedListImpImplementation.SimpleWCF.CompositeType)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetXmlCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetXmlCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.IO.Stream Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.IO.Stream)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<ITypedListImpImplementation.SimpleWCF.IService1>, ITypedListImpImplementation.SimpleWCF.IService1 {
        
        private BeginOperationDelegate onBeginGetDataDelegate;
        
        private EndOperationDelegate onEndGetDataDelegate;
        
        private System.Threading.SendOrPostCallback onGetDataCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetDataUsingDataContractDelegate;
        
        private EndOperationDelegate onEndGetDataUsingDataContractDelegate;
        
        private System.Threading.SendOrPostCallback onGetDataUsingDataContractCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetXmlDelegate;
        
        private EndOperationDelegate onEndGetXmlDelegate;
        
        private System.Threading.SendOrPostCallback onGetXmlCompletedDelegate;
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public event System.EventHandler<GetDataCompletedEventArgs> GetDataCompleted;
        
        public event System.EventHandler<GetDataUsingDataContractCompletedEventArgs> GetDataUsingDataContractCompleted;
        
        public event System.EventHandler<GetXmlCompletedEventArgs> GetXmlCompleted;
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetData(int value, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetData(value, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string EndGetData(System.IAsyncResult result) {
            return base.Channel.EndGetData(result);
        }
        
        private System.IAsyncResult OnBeginGetData(object[] inValues, System.AsyncCallback callback, object asyncState) {
            int value = ((int)(inValues[0]));
            return this.BeginGetData(value, callback, asyncState);
        }
        
        private object[] OnEndGetData(System.IAsyncResult result) {
            string retVal = this.EndGetData(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetDataCompleted(object state) {
            if ((this.GetDataCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetDataCompleted(this, new GetDataCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetDataAsync(int value) {
            this.GetDataAsync(value, null);
        }
        
        public void GetDataAsync(int value, object userState) {
            if ((this.onBeginGetDataDelegate == null)) {
                this.onBeginGetDataDelegate = new BeginOperationDelegate(this.OnBeginGetData);
            }
            if ((this.onEndGetDataDelegate == null)) {
                this.onEndGetDataDelegate = new EndOperationDelegate(this.OnEndGetData);
            }
            if ((this.onGetDataCompletedDelegate == null)) {
                this.onGetDataCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetDataCompleted);
            }
            base.InvokeAsync(this.onBeginGetDataDelegate, new object[] {
                        value}, this.onEndGetDataDelegate, this.onGetDataCompletedDelegate, userState);
        }
        
        public ITypedListImpImplementation.SimpleWCF.CompositeType GetDataUsingDataContract(ITypedListImpImplementation.SimpleWCF.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetDataUsingDataContract(ITypedListImpImplementation.SimpleWCF.CompositeType composite, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetDataUsingDataContract(composite, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public ITypedListImpImplementation.SimpleWCF.CompositeType EndGetDataUsingDataContract(System.IAsyncResult result) {
            return base.Channel.EndGetDataUsingDataContract(result);
        }
        
        private System.IAsyncResult OnBeginGetDataUsingDataContract(object[] inValues, System.AsyncCallback callback, object asyncState) {
            ITypedListImpImplementation.SimpleWCF.CompositeType composite = ((ITypedListImpImplementation.SimpleWCF.CompositeType)(inValues[0]));
            return this.BeginGetDataUsingDataContract(composite, callback, asyncState);
        }
        
        private object[] OnEndGetDataUsingDataContract(System.IAsyncResult result) {
            ITypedListImpImplementation.SimpleWCF.CompositeType retVal = this.EndGetDataUsingDataContract(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetDataUsingDataContractCompleted(object state) {
            if ((this.GetDataUsingDataContractCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetDataUsingDataContractCompleted(this, new GetDataUsingDataContractCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetDataUsingDataContractAsync(ITypedListImpImplementation.SimpleWCF.CompositeType composite) {
            this.GetDataUsingDataContractAsync(composite, null);
        }
        
        public void GetDataUsingDataContractAsync(ITypedListImpImplementation.SimpleWCF.CompositeType composite, object userState) {
            if ((this.onBeginGetDataUsingDataContractDelegate == null)) {
                this.onBeginGetDataUsingDataContractDelegate = new BeginOperationDelegate(this.OnBeginGetDataUsingDataContract);
            }
            if ((this.onEndGetDataUsingDataContractDelegate == null)) {
                this.onEndGetDataUsingDataContractDelegate = new EndOperationDelegate(this.OnEndGetDataUsingDataContract);
            }
            if ((this.onGetDataUsingDataContractCompletedDelegate == null)) {
                this.onGetDataUsingDataContractCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetDataUsingDataContractCompleted);
            }
            base.InvokeAsync(this.onBeginGetDataUsingDataContractDelegate, new object[] {
                        composite}, this.onEndGetDataUsingDataContractDelegate, this.onGetDataUsingDataContractCompletedDelegate, userState);
        }
        
        public System.IO.Stream GetXml() {
            return base.Channel.GetXml();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetXml(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetXml(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IO.Stream EndGetXml(System.IAsyncResult result) {
            return base.Channel.EndGetXml(result);
        }
        
        private System.IAsyncResult OnBeginGetXml(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginGetXml(callback, asyncState);
        }
        
        private object[] OnEndGetXml(System.IAsyncResult result) {
            System.IO.Stream retVal = this.EndGetXml(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetXmlCompleted(object state) {
            if ((this.GetXmlCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetXmlCompleted(this, new GetXmlCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetXmlAsync() {
            this.GetXmlAsync(null);
        }
        
        public void GetXmlAsync(object userState) {
            if ((this.onBeginGetXmlDelegate == null)) {
                this.onBeginGetXmlDelegate = new BeginOperationDelegate(this.OnBeginGetXml);
            }
            if ((this.onEndGetXmlDelegate == null)) {
                this.onEndGetXmlDelegate = new EndOperationDelegate(this.OnEndGetXml);
            }
            if ((this.onGetXmlCompletedDelegate == null)) {
                this.onGetXmlCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetXmlCompleted);
            }
            base.InvokeAsync(this.onBeginGetXmlDelegate, null, this.onEndGetXmlDelegate, this.onGetXmlCompletedDelegate, userState);
        }
    }
}