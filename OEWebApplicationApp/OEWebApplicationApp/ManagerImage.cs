using Microsoft.Data.SqlClient;
using OEWebApplicationApp.Models;
using System.Data;

namespace OEWebApplicationApp
{
    public class ManagerImage
    {
        private ClassConfig configclass = new();

        //GET ALL IMAGES PER REQUEST ID============================================================================================================
        //FOR THE INDEX============================================================================================================================
        public List<ImageModel> GetImages(string id)
        {
            List<ImageModel> listOfOERequest = new List<ImageModel>();
            string config = configclass.MorSQLConnections();
            using (SqlConnection connection = new SqlConnection(config))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spr_GetImages";
                command.Parameters.AddWithValue("@RequestId", id);
                SqlDataAdapter sqlda = new SqlDataAdapter(command);
                DataTable dtOE = new DataTable();
                connection.Open();
                sqlda.Fill(dtOE);
                connection.Close();
                foreach (DataRow dr in dtOE.Rows)
                {
                    listOfOERequest.Add(new ImageModel
                    {
                        RequestId = Convert.ToInt32(dr["RequestId"]),
                        FileName = (dr["FileName"] is not DBNull) ? dr["FileName"].ToString() : null,
                        Path = (dr["Path"] is not DBNull) ? dr["Path"].ToString() : null,
                        Location = (dr["Location"] is not DBNull) ? dr["Location"].ToString() : null,
                        InsertDate = Convert.ToDateTime(dr["InsertDate"]),

                    });//list
                }//foreach
            }//using
            return listOfOERequest;
        }//GetImages
        
        //GET ONE IMAGES PER FILE NAME============================================================================================================
        //CREATED FOR DELETE SPECIFIC=============================================================================================================
        public List<ImageModel> GetImage(string id)
        {
            List<ImageModel> listOfOERequest = new List<ImageModel>();
            string config = configclass.MorSQLConnections();
            using (SqlConnection connection = new SqlConnection(config))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spr_GetImage";
                command.Parameters.AddWithValue("@FileName", id);
                SqlDataAdapter sqlda = new SqlDataAdapter(command);
                DataTable dtOE = new DataTable();
                connection.Open();
                sqlda.Fill(dtOE);
                connection.Close();
                foreach (DataRow dr in dtOE.Rows)
                {
                    listOfOERequest.Add(new ImageModel
                    {
                        RequestId = Convert.ToInt32(dr["RequestId"]),
                        FileName = (dr["FileName"] is not DBNull) ? dr["FileName"].ToString() : null,
                        Path = (dr["Path"] is not DBNull) ? dr["Path"].ToString() : null,
                        Location = (dr["Location"] is not DBNull) ? dr["Location"].ToString() : null,
                        InsertDate = Convert.ToDateTime(dr["InsertDate"]),

                    });//list
                }//foreach
            }//using
            return listOfOERequest;
        }//GetImages

        //UPDATE IMAGE===========================================================================================================================
        //update the database with location=================================================
        public bool UpdateImageTbl(string filename, string path, ImageModel model)
        {

            string config = configclass.MorSQLConnections();
            int i = 0;
            using (SqlConnection connection = new SqlConnection(config))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spr_UploadImages";
                string fileNameWithPath = path;
                command.Parameters.AddWithValue("@RequestId", model.RequestId);
                if (filename != null) { command.Parameters.AddWithValue("@FileName", filename); } else { command.Parameters.AddWithValue("@FileName", DBNull.Value); };
                if (fileNameWithPath != null) { command.Parameters.AddWithValue("@Path", fileNameWithPath); } else { command.Parameters.AddWithValue("@Path", DBNull.Value); };
                if (model.Location != null) { command.Parameters.AddWithValue("@Location", model.Location); } else { command.Parameters.AddWithValue("@Location", DBNull.Value); };

                connection.Open();
                i = command.ExecuteNonQuery();
                connection.Close();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }//using
        }//UpdateImageTbl

        //DELETE SINGLE IMAGE ========================================================================================================================
        //REMOVE THE IMAGE FROM DATABASE LOCATION AND LOCAL REPOSITORY=================================================
        public string DeleteImage(string filePath, ImageModel imageModel)
        {
            string value = "Success";
            if (filePath != null) 
            {
                //DELETE FILE FROM SYSTEM===================================
                File.Delete(filePath);

                //DELETE FILE FROM INDEX====================================
                string? result = "";
                string config = configclass.MorSQLConnections();
                using (SqlConnection connection = new SqlConnection(config))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spr_DeleteImage";
                    if (filePath != null) { command.Parameters.AddWithValue("@FileName", imageModel.FileName); } else { command.Parameters.AddWithValue("@FileName", DBNull.Value); };
                    command.Parameters.Add("@OutputMessage", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                    connection.Open();
                    command.ExecuteNonQuery();
                    result = command.Parameters["@OutputMessage"].Value.ToString();
                    connection.Close();
                }//using
                return value;
            }
            else
            {
                value = "Failure";
                return value;
            }
        }

        //DELETE MULIPLE IMAGES============================================================================================================
        //REMOVE IMAGES FROM THE REPOSITORY AND THE DATABASE===============================================================================
        public void DeleteAllImages(int id, TblCgyoeModel tblCgyoe)
        {
            GetAllImageFilePaths(id);
            DeleteImagesByRequestid(id, tblCgyoe);

        }//DeleteAllImages

        //DELETE: RETRIEVE IMAGES LIST FROM DATABASE AND DELETE FROM FILE.====================
        private List<ImageModel> GetAllImageFilePaths(int id)
        {
            List<ImageModel> listOfOERequest = new List<ImageModel>();
            string config = configclass.MorSQLConnections();
            using (SqlConnection connection = new SqlConnection(config))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spr_GetImages";
                command.Parameters.AddWithValue("@RequestId", id);
                SqlDataAdapter sqlda = new SqlDataAdapter(command);
                DataTable dtOE = new DataTable();
                connection.Open();
                sqlda.Fill(dtOE);
                connection.Close();
                foreach (DataRow dr in dtOE.Rows)
                {
                    File.Delete((dr["Path"] is not DBNull) ? dr["Path"].ToString() : null);
                }//foreach

            }//using
            return listOfOERequest;
        }//GetAllImageFilePaths

        //DELETE: REMOVE ALL IMAGES FROM DATABASE===========================================
        private string DeleteImagesByRequestid(int id, TblCgyoeModel tblCgyoe)
        {
            string value = "Success";
            if (id != null)
            {
                string? result = "";
                string config = configclass.MorSQLConnections();
                using (SqlConnection connection = new SqlConnection(config))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spr_DeleteAllImage";
                if (id != null) { command.Parameters.AddWithValue("@RequestId", tblCgyoe.RequestId); } else { command.Parameters.AddWithValue("@RequestId", DBNull.Value); };
                command.Parameters.Add("@OutputMessage", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                connection.Open();
                command.ExecuteNonQuery();
                result = command.Parameters["@OutputMessage"].Value.ToString();
                connection.Close();
            }//using
                return value;
            }
            else
            {
                value = "Failure";
                return value;
            }
        }//DeleteImagesByRequestid

    }//class
}//namespace
