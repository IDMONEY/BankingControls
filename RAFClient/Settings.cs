namespace RAFClient {

    /*
     * Settings we want to be hardcoded in each release
     * such as the release version and its compatibilites
     * See Assembly.info for notes on release numbers.
    */
    internal sealed partial class Settings {

        public Settings(){}
        
        //The minimum version of the Security DB that is still compatible with this release
        private string DbVersionSecMinString = "1.1.0.0";
        //The max version of the Security DB that is still compatible with this release
        private string DbVersionSecMaxString = "1.1.0.0";

        public string DbVersionSecMin
        {
            get{return DbVersionSecMinString;}
        }
    
    }
}
