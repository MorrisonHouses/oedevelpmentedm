using Microsoft.Data.SqlClient;
using OEWebApplicationApp.Models;
using System.Data;

namespace OEWebApplicationApp
{
    public class ManagerApmMasterVendor
    {
        private ClassFunctions function = new();
        private ClassConfig configclass = new();

        //GET ALL VENDORS ======================================================================
        //GET VENDORS FROM VMORT TABLE
        public List<VendorModel> GetViewVendor(string username1)
        {
            List<VendorModel> listOfVendors = new List<VendorModel>();
            //string username = configclass.username();
            string username = username1;
            string config = configclass.vMortlSQLConnections();
            using (SqlConnection connection = new SqlConnection(config))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spr_APM_Master_Vendor";
                SqlDataAdapter sqlda = new SqlDataAdapter(command);
                DataTable dtOE = new DataTable();

                connection.Open();
                sqlda.Fill(dtOE);
                connection.Close();
                foreach (DataRow dr in dtOE.Rows)
                {
                    listOfVendors.Add(new VendorModel
                    {
                        Vendor = dr["Vendor"].ToString(),
                        Name = (dr["name"] is not DBNull) ? dr["name"].ToString() : null,
                    }); //list
                }//foreach
            }//using
            return listOfVendors;
            // return VendorModel;
        }//GetViewVendor
    }//class
}//namespace
