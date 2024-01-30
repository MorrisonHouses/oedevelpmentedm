using Microsoft.Data.SqlClient;
using OEWebApplicationApp.Models;
using System.Data;

namespace OEWebApplicationApp
{
    public class ManagerViewGLaccount
    {
        private ClassFunctions function = new();
        private ClassConfig configclass = new();

        // insures that the person loggin in is a requester based on the GateKeeper field======================================================
        public Boolean GetRequestBool(string username1)
        {
            ClassConfig classConfig = new ClassConfig();
            //int count = GetAllGlAccounts().Where(x => x.GateKeeper.Trim() == classConfig.username().Trim()).Count();
            int count = GetAllGlAccounts(username1).Where(x => x.GateKeeper.ToLower().Trim() == username1.Trim()).Count();
            bool check = false;
            if (count > 0) { check = true; } else { check = false; };
            return check;
        }//GetRequestBool

        // checks if the person loggin in is an approver based on the ApprovalGateKeeper field=================================================
        public Boolean GetApprovalBool(string username)
        {
            ClassConfig classConfig = new ClassConfig();
            //int count = GetAllGlAccounts().Where(x => x.ApprovalGateKeeper.Trim() == classConfig.username().Trim()).Count();
            int count = GetAllGlAccounts(username).Where(x => x.ApprovalGateKeeper.ToLower().Trim() == username).Count();
            bool check = false;
            if (count > 0) { check = true; } else { check = false; };
            return check;
        }//GetApprovalBool

        //GET ALL GLACCOUNTS ======================================================================
        //RETRIEVED FROM THE VMORTL DATABASE=======================================================
        public List<ViewGlaccountModel> GetAllGlAccounts(string username1)
        {
            List<ViewGlaccountModel> listOfGls = new List<ViewGlaccountModel>();
            //string username = configclass.username();
            string username = username1;
            string config = configclass.vMortlSQLConnections();
            using (SqlConnection connection = new SqlConnection(config))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spr_GLM_Accounts_User";
                command.Parameters.AddWithValue("@windowsUser", username1);
                SqlDataAdapter sqlda = new SqlDataAdapter(command);
                DataTable dtOE = new DataTable();
                connection.Open();
                sqlda.Fill(dtOE);
                connection.Close();
                foreach (DataRow dr in dtOE.Rows)
                {
                    listOfGls.Add(new ViewGlaccountModel
                    {
                        AccountCustomField = dr["Account_Custom_Field"].ToString(),
                        AccountTitle = dr["Account_Title"].ToString(),
                        ApprovalGateKeeper = (string)dr["Approval_Gate_Keeper"],
                        ApprovalThreshold = (double?)dr["Approval_Threshold"],
                        GateKeeper = dr["Gate_Keeper"].ToString(),
                    }); //list
                }//foreach
            }//using
            return listOfGls;
        }//GetAllGlAccounts

        public double GetThreshold(string gl, string username1)
        {
            double value = Convert.ToDouble(GetAllGlAccounts(username1).FirstOrDefault().ApprovalThreshold);
            return value;
        }

    }//class
}//namespace
