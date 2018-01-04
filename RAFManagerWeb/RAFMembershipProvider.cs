using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;

namespace RAFManagerWeb
{
    public class RAFMembershipProvider : MembershipProvider
    {
        private String _strName; 
        private String _strApplicationName;
        private Boolean _boolEnablePasswordReset;
        private Boolean _boolEnablePasswordRetrieval;
        private Boolean _boolRequiresQuestionAndAnswer;
        private Boolean _boolRequiresUniqueEMail;
        private int _iPasswordAttemptThreshold;
        private MembershipPasswordFormat _oPasswordFormat;
        private int _intMaxInvalidPasswordAttempts;
        private int _intMinRequiredPasswordLength;
        private int _intMinRequiredNonAlphanumericCharacters;
        private String _strPasswordStrengthRegularExpression;


	public RAFMembershipProvider() 
        {
            _strName = "";
            _strApplicationName = "";
            _boolRequiresQuestionAndAnswer = false;
            _boolEnablePasswordReset = false;
            _boolEnablePasswordRetrieval = false;
            _boolRequiresQuestionAndAnswer = false;
            _boolRequiresUniqueEMail = false;
            _intMaxInvalidPasswordAttempts = 0;
            _intMinRequiredPasswordLength = 6;
            _intMinRequiredNonAlphanumericCharacters = 0;
            _strPasswordStrengthRegularExpression = ".+";
        } 
	//DFB: reads entries from web.config and initializes this class from those values
        //  Once the provider is loaded, the 
        //  runtime calls Initialize and passes the settings as name-value 
        //  pairs in an instance of the NameValueCollection class.
        //
	public override void Initialize(string strName, System.Collections.Specialized.NameValueCollection config)
	{

            _strName = strName;
            _strApplicationName = "/";
            _boolRequiresQuestionAndAnswer=false;
            _boolEnablePasswordReset = true;
            _boolEnablePasswordRetrieval = true;
            _boolRequiresQuestionAndAnswer=false ;
            _boolRequiresUniqueEMail=true;
	}
    public override bool ValidateUser(string strName, string strPassword)
	{
        RAFSecurity _securityManager = new RAFSecurity();
        if (_securityManager.Login(strPassword, strName))
        {
            this._strName = strName;
            return true;
        }
        else
        {
            return false;
        }
    }



	public override string GetPassword(string strName, string strAnswer)
	{
		throw new Exception("The method or operation is not implemented.");
	}
    public override int MaxInvalidPasswordAttempts
    {
        get
        {

            return _intMaxInvalidPasswordAttempts;
        }
    }
    public override int MinRequiredPasswordLength
    {
        get
        {

            return _intMinRequiredPasswordLength;
        }
    }
    public override int MinRequiredNonAlphanumericCharacters
    {
        get
        {

            return _intMinRequiredNonAlphanumericCharacters;
        }
    }
    public override string PasswordStrengthRegularExpression
    {
        get
        {

            return _strPasswordStrengthRegularExpression;
        }
    }    
        public override string ApplicationName
        {
            get
            {

                return _strApplicationName;
            }
            set
            {
                _strApplicationName = value;
            }
        }
        public override string Name
        {
            get
            {
                return _strName;
            }
        }
        public override bool EnablePasswordReset
        {
            get
            {

                return _boolEnablePasswordReset;
            }
        }
        public override bool EnablePasswordRetrieval
        {
            get
            {
                return _boolEnablePasswordRetrieval;
            }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get
            {
                return _oPasswordFormat;
            }
        }
        public override bool RequiresQuestionAndAnswer
        {
            get
            {
                return _boolRequiresQuestionAndAnswer;
            }
        }
        public override int PasswordAttemptWindow
        {
            get 
            { 
                throw new Exception("The method or operation is not implemented."); 
            }
        }
        public override bool RequiresUniqueEmail
        {
            get
            {
                return _boolRequiresUniqueEMail;
            }
        }

        public override MembershipUser CreateUser(	
			string username, 
	                string password, 
	                string email, 
	                string passwordQuestion, 
	                string passwordAnswer, 
	                bool isApproved, 
	                object userId, 
	                out MembershipCreateStatus status)
        {

            throw new Exception("The method or operation is not implemented."); 
        }
        public override string GetUserNameByEmail(string strEmail)
        {
            throw new Exception("The method or operation is not implemented."); 
        }
       
	public override string ResetPassword(string strName, string strAnswer)
	{
            throw new Exception("The method or operation is not implemented."); 
	}
	public override bool ChangePassword(string strName, string strOldPwd, string strNewPwd)
	{
            throw new Exception("The method or operation is not implemented."); 
	}
	public override int GetNumberOfUsersOnline()
	{
            throw new Exception("The method or operation is not implemented."); 
	}
	public override bool ChangePasswordQuestionAndAnswer(string strName, string strPassword, string strNewPwdQuestion, string strNewPwdAnswer)
	{	
	    throw new Exception("The method or operation is not implemented.");
	
	}
	public override MembershipUser GetUser(string strName, bool boolUserIsOnline)
	{
           throw new Exception("The method or operation is not implemented."); 
	}

	public override bool DeleteUser(string strName, bool boolDeleteAllRelatedData)
	{
            throw new Exception("The method or operation is not implemented.");
        }
	public override MembershipUserCollection FindUsersByEmail(string strEmailToMatch, int iPageIndex, int iPageSize, out int iTotalRecords)
	{
            throw new Exception("The method or operation is not implemented.");
	}
	public override MembershipUserCollection FindUsersByName(string strUsernameToMatch, int iPageIndex, int iPageSize, out int iTotalRecords)
	{
            throw new Exception("The method or operation is not implemented.");
	}
	public override MembershipUserCollection GetAllUsers(int iPageIndex, int iPageSize, out int iTotalRecords)
	{
            throw new Exception("The method or operation is not implemented.");
	}

        public override void UpdateUser(MembershipUser user)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override bool UnlockUser(string strUserName)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
