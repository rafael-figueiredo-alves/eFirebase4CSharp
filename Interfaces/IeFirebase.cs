namespace eFirebase4CSharp.Interfaces
{
    public interface IeFirebase
    {
        public string GetVersion();
        public IeFirebaseAuth Auth(string API_Key);
        public IeFirebaseRealTimeDB RealTimeDB(string ProjectCode);
        public IeFirebaseStorage Storage(string ProjectCode);
    }
}
