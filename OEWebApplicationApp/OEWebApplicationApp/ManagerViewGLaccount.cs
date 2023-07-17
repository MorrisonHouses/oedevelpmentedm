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
        public  Boolean GetRequestBool()
        {
            ClassConfig classConfig = new ClassConfig();
            int count = GetAllGlAccounts().Where(x => x.GateKeeper.Trim() == classConfig.username().Trim()).Count();
            bool check = false;
            if (count > 0) { check = true; } else { check = false; };
            return check;
        }//GetRequestBool

        // checks if the person loggin in is an approver based on the ApprovalGateKeeper field=================================================
        public Boolean GetApprovalBool()
        {
            ClassConfig classConfig = new ClassConfig();
            int count = GetAllGlAccounts().Where(x => x.ApprovalGateKeeper.Trim() == classConfig.username().Trim()).Count();
            bool check = false;
            if (count > 0) { check = true; } else { check = false; };
            return check;
        }//GetApprovalBool

        //GET ALL GLACCOUNTS ======================================================================
        //RETRIEVED FROM THE VMORTL DATABASE=======================================================
        public List<ViewGlaccountModel> GetAllGlAccounts()
        {
            List<ViewGlaccountModel> listOfGls = new List<ViewGlaccountModel>();
            string username = configclass.username();
            string config = configclass.vMortlSQLConnections();
            using (SqlConnection connection = new SqlConnection(config))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spr_GLM_Accounts_User";
                command.Parameters.AddWithValue("@windowsUser", username);
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

        public double GetThreshold(string gl)
        {
            double value = Convert.ToDouble(GetAllGlAccounts().FirstOrDefault().ApprovalThreshold);
            return value;
        }

    }//class
}//namespace
