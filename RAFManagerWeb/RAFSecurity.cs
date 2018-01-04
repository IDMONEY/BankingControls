using System;
using System.Web.Security;
using System.Collections.Generic;

public class RAFSecurity 
{

    private String _ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["rafSecurityConnectionString"].ConnectionString;
    
    public int searchForGroup(String pHint, int ptype)
    {
        DataBaseConnection _dbc = new DataBaseConnection();
        _dbc.SetConnectionString(_ConnectionString);
        _dbc.OpenConnection();
        List<object> _result;
        try
        {
            _result = _dbc.ExecuteProcedures("Exec sp_SearchForGroups N'" + pHint + "', " + ptype, 3);
        }
        catch (Exception e)
        {
            _dbc.CloseConnection();
            return -1;
        }
        _dbc.CloseConnection();
        if (_result != null)
        {
                return (int) _result[0];
        }
        return -1;
    }

    public List<object> searchForGroups(String pHint, int ptype)
    {
        DataBaseConnection _dbc = new DataBaseConnection();
        _dbc.SetConnectionString(_ConnectionString);
        _dbc.OpenConnection();
        List<object> _result;
        try
        {
            _result = _dbc.ExecuteProcedures("Exec sp_SearchForGroups N'" + pHint + "', " + ptype, 4);
            _dbc.CloseConnection();
            return _result;
        }
        catch (Exception e)
        {
            _dbc.CloseConnection();
            _result = null;
            return _result;
        }
        
    }

    public List<object> searchForUsers(String pHint, int pType)
    {
        DataBaseConnection _dbc = new DataBaseConnection();
        _dbc.SetConnectionString(_ConnectionString);
        _dbc.OpenConnection();
        List<object> _result;
        try
        {
            if (pType == 5)
            {
                _result = _dbc.ExecuteProcedures("Exec sp_SearchForUsers N'" + pHint + "', " + pType, 2);
            }
            else
            {
                _result = _dbc.ExecuteProcedures("Exec sp_SearchForUsers N'" + pHint + "', " + pType, 7);
            }
            _dbc.CloseConnection();
            return _result;
        }
        catch (Exception e)
        {
            _dbc.CloseConnection();
            _result = null;
            return _result;
        }
        
    }

    public Boolean Login(String pPassword, String pUserName)
    {
        DataBaseConnection _dbc = new DataBaseConnection();
        _dbc.SetConnectionString(_ConnectionString);
        _dbc.OpenConnection();
        List<object> _result;
        try
        {
            _result = _dbc.ExecuteProcedures("Exec sp_Login N'" + pUserName + "', N'" + pPassword + "'", 1);
        }
        catch (Exception e)
        {
            _dbc.CloseConnection();
            return false;
        }
        _dbc.CloseConnection();
        if (_result != null)
        {
            if (((int)_result[0]) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public Boolean Logout(String pUserName)//no esta implementado falta 
    {
        DataBaseConnection _dbc = new DataBaseConnection();
        _dbc.SetConnectionString(_ConnectionString);
        _dbc.OpenConnection();
        List<object> _result;
        try
        {
            _result = _dbc.ExecuteProcedures("Exec sp_Logout N'" + pUserName + "'", 1);
        }
        catch (Exception e)
        {
            _dbc.CloseConnection();
            return false;
        }
        _dbc.CloseConnection();
        if (_result != null)
        {
            if (((int)_result[0]) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public void JoinGroup(String pHint)
    {
    }

    public Boolean insertGroup(String pName, String pDescription)
    {
        DataBaseConnection _dbc = new DataBaseConnection();
        _dbc.SetConnectionString(_ConnectionString);
        _dbc.OpenConnection();
        List<object> _result;
        try
        {
            _result = _dbc.ExecuteProcedures("Exec sp_insertUserGroup N'" + pName + "', N'" + pDescription + "'", 1);
        }
        catch (Exception ex)
        {
            _dbc.CloseConnection();
            return false;
        }
        _dbc.CloseConnection();
        if (_result != null)
        {
            if (((int)_result[0]) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public Boolean updateUser(String pFirstName, String pSecondName, String pSurName, String pSurName2, String pStatus, String pLoginName, int pActualUser)
    {
        DataBaseConnection _dbc = new DataBaseConnection();
        _dbc.SetConnectionString(_ConnectionString);
        _dbc.OpenConnection();
        List<object> _result;
        try
        {
            _result = _dbc.ExecuteProcedures("Exec sp_UpdateUser N'" + pFirstName + "', N'" + pSecondName + "', N'" + pSurName + "', N'" + pSurName2 + "', '" + pStatus + "', NULL, NULL, NULL, " + pActualUser + ", N'" + pLoginName + "', NULL, NULL, 0", 1);
        }
        catch (Exception ex)
        {
            _dbc.CloseConnection();
            return false;
        }
        _dbc.CloseConnection();
        if (_result != null)
        {
            if (((int)_result[0]) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public Boolean insertUser(String pLoginName, String pPassword, String pName, String pMName, String pSurName1, String pSurName2, String pCurrentUser)
    {
        DataBaseConnection _dbc = new DataBaseConnection();
        _dbc.SetConnectionString(_ConnectionString);
        _dbc.OpenConnection();
        List<object> _result;
        try
        {
            _result = _dbc.ExecuteProcedures("Exec sp_SearchForUsers N'" + pCurrentUser + "', "+ 5, 3);
            _result = _dbc.ExecuteProcedures("Exec sp_InsertUser N'" + pLoginName + "', " + "N'" + pName + "', " + "N'" + pMName + "', " + "N'" + pSurName1 + "', N' " + pSurName2 + "'," + "N'" + pPassword + "', "+ _result[0], 1);
        }
        catch (Exception ex)
        {
            _dbc.CloseConnection();
            return false;
        }
        _dbc.CloseConnection();
        if (_result != null)
        {
            if (((int)_result[0]) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public Boolean updateGroup(String pName, String pDescription, int pStatus)
    {
        DataBaseConnection _dbc = new DataBaseConnection();
        _dbc.SetConnectionString(_ConnectionString);
        _dbc.OpenConnection();
        List<object> _result;
        try
        {
            _result = _dbc.ExecuteProcedures("Exec sp_UpdateUserGroups N'" + pName + "',"+ pStatus + ", N'" + pDescription + "'", 1);
        }
        catch (Exception ex)
        {
            _dbc.CloseConnection();
            return false;
        }
        _dbc.CloseConnection();
        if (_result != null)
        {
            if (((int)_result[0]) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public Boolean addMembership(String pUser, String pGroup)
    {
        DataBaseConnection _dbc = new DataBaseConnection();
        _dbc.SetConnectionString(_ConnectionString);
        _dbc.OpenConnection();
        List<object> _result;
        try
        {
            _result = _dbc.ExecuteProcedures("Exec sp_AddMembership "+ pUser + "," + pGroup, 1);
        }
        catch (Exception ex)
        {
            _dbc.CloseConnection();
            return false;
        }
        _dbc.CloseConnection();
        if (_result != null)
        {
            if (((int)_result[0]) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public Boolean deleteMembership(String pUser, String pGroup)
    {
            DataBaseConnection _dbc = new DataBaseConnection();
        _dbc.SetConnectionString(_ConnectionString);
        _dbc.OpenConnection();
        List<object> _result;
        try
        {
            _result = _dbc.ExecuteProcedures("Exec sp_DeleteMembership "+ pUser + "," + pGroup, 1);
        }
        catch (Exception ex)
        {
            _dbc.CloseConnection();
            return false;
        }
        _dbc.CloseConnection();
        if (_result != null)
        {
            if (((int)_result[0]) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }


    public Boolean addRights(String pGroup, String pType, String pIdentifier)
    {
        DataBaseConnection _dbc = new DataBaseConnection();
        _dbc.SetConnectionString(_ConnectionString);
        _dbc.OpenConnection();
        String _query = "";
        if (pType == "Section")
        {
            _query = "Exec sp_GrantSectionRights ";
        }
        else if (pType == "Category")
        {
            _query = "Exec sp_GrantCategoryRights ";
        }
        else if (pType == "Page")
        {
            _query = "Exec sp_GrantPageRights ";
        }
        List<object> _result;
        try
        {
            _result = _dbc.ExecuteProcedures(_query + pIdentifier + ", " + pGroup , 1);
        }
        catch (Exception ex)
        {
            _dbc.CloseConnection();
            return false;
        }
        _dbc.CloseConnection();
        if (_result != null)
        {
            if (((int)_result[0]) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public Boolean DeleteRights(String pGroup, String pType, String pIdentifier)
    {
        DataBaseConnection _dbc = new DataBaseConnection();
        _dbc.SetConnectionString(_ConnectionString);
        _dbc.OpenConnection();
        String _query = "";
        int plap = String.Compare("Category", "Category");
        int plop = String.Compare(pType, "Category");
        if(pType == "Section"){
            _query = "Exec sp_DeleteSectionRights ";
        }
        else if (pType == "Category")
        {
            _query = "Exec sp_DeleteCategoryRights ";
        }
        else if (pType == "Page")
        {
            _query = "Exec sp_DeletePageRights ";
        }
        List<object> _result;
        try
        {
            _result = _dbc.ExecuteProcedures(_query + pIdentifier + ", " + pGroup, 1);
        }
        catch (Exception ex)
        {
            _dbc.CloseConnection();
            return false;
        }
        _dbc.CloseConnection();
        if (_result != null)
        {
            if (((int)_result[0]) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public Boolean passwordChange(String pLoginName, String pOldPass, String pNewPass, String pCurrentUser)
    {
        DataBaseConnection _dbc = new DataBaseConnection();
        _dbc.SetConnectionString(_ConnectionString);
        _dbc.OpenConnection();
        List<object> _result;
                try
        {
            _result = _dbc.ExecuteProcedures("Exec sp_UpdatePassword N'" + pLoginName + "', N'" + pOldPass + "', N'" + pNewPass + "', " + pCurrentUser, 1);
        }
        catch (Exception e)
        {
            _dbc.CloseConnection();
            return false;
        }
        _dbc.CloseConnection();
        if (_result != null)
        {
            if (((int)_result[0]) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public List<String> getUserRights(String pIdUser, String pType)
    {
        DataBaseConnection _dbc = new DataBaseConnection();
        _dbc.SetConnectionString(_ConnectionString);
        _dbc.OpenConnection();
        List<object> _queryResult;
        List<String> _result = new List<string>();
        String _query = "";
        if (pType == "Section")
        {
            _query = "Exec sp_SelectSectionsByUser ";
        }
        else if (pType == "Category")
        {
            _query = "Exec sp_SelectCategoriesByUser ";
        }
        else if (pType == "Page")
        {
            _query = "Exec sp_SelectPagesByUser ";
        }
        try
        {
            _queryResult = _dbc.ExecuteProcedures(_query + pIdUser, 1);
        }
        catch (Exception e)
        {
            _dbc.CloseConnection();
            _result = null;
            return _result;
        }
        _dbc.CloseConnection();
        if (_queryResult != null)
        {
            for (int i = 0; i < _queryResult.Count; i++)
            {
                _result.Add((String)_queryResult[i]);
            }
        }
        return _result;
    }
}