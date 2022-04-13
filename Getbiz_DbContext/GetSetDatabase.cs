using getbiz_getster_app.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace getbiz_getster_app
{
    public class GetSetDatabase
    {
       // string connection = "Server=185.252.235.20;User ID=root;Password=Getbizapp;Database=getsterappdb; Allow User Variables=true";
        string connection = "Server=185.252.235.20;User ID=root;Password=GetBizMysqlDatabasePwd2021@;Database=getsterappdb; Allow User Variables=true";
        #region Comment Section

        public Response CreateCommentTableDyanmically(int comment_id, string comment_timestamp, int getster_id, 
            string comment_text, Int32 is_the_comment_private, string comment_reply, int comment_reply_by_getster_id, string Counter)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            MySqlParameter[] param = new MySqlParameter[8];
            using MySqlConnection con = new MySqlConnection(connection);
            try
            {
                param[0] = new MySqlParameter("p_comment_timestamp", MySqlDbType.VarChar);
                param[0].Value = comment_timestamp;

                param[1] = new MySqlParameter("p_getsterId", MySqlDbType.Int32);
                param[1].Value = getster_id;

                param[2] = new MySqlParameter("p_commentText", MySqlDbType.VarChar);
                param[2].Value = comment_text;

                param[3] = new MySqlParameter("p_is_the_comment_private", MySqlDbType.Int16);
                param[3].Value = is_the_comment_private;

                param[4] = new MySqlParameter("p_commentReply", MySqlDbType.VarChar);
                param[4].Value = comment_reply;

                param[5] = new MySqlParameter("p_comment_reply_by_getster_id", MySqlDbType.Int32);
                param[5].Value = comment_reply_by_getster_id;

                param[6] = new MySqlParameter("p_Counter", MySqlDbType.VarChar);
                param[6].Value = Counter;

                param[7] = new MySqlParameter("p_commentId", MySqlDbType.VarChar);
                param[7].Value = comment_id;

               

                ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_CreateCommentTableDyanmically", param);
            }
            catch (Exception ex)
            {

            }

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //GetAll
                    if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "GetAll")
                    {
                       List<comment_for_getster> lst_comment_For_Getster = new List<comment_for_getster>();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            comment_for_getster comment_For_Getster = new comment_for_getster();
                            comment_For_Getster.comment_id = Convert.ToInt32(ds.Tables[0].Rows[i]["comment_id"]);
                            comment_For_Getster.getster_id = Convert.ToInt32(ds.Tables[0].Rows[i]["getster_id"]);
                            comment_For_Getster.comment_timestamp = Convert.ToString(ds.Tables[0].Rows[i]["comment_timestamp"]);
                            comment_For_Getster.comment_text = Convert.ToString(ds.Tables[0].Rows[i]["comment_text"]);
                            comment_For_Getster.is_the_comment_private = Convert.ToInt32(ds.Tables[0].Rows[i]["is_the_comment_private"]);
                            comment_For_Getster.comment_reply = Convert.ToString(ds.Tables[0].Rows[i]["comment_reply"]);
                            comment_For_Getster.comment_reply_by_getster_id = Convert.ToInt32(ds.Tables[0].Rows[i]["comment_reply_by_getster_id"]);
                            lst_comment_For_Getster.Add(comment_For_Getster);
                        }
                        response.Data = lst_comment_For_Getster;

                        response.Message = "Comments data fetched successfully";
                        response.Status = true;
                    }
                    else
                    {
                        response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                        response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                    }
                }
            }

            return response;
        }

        #endregion


        #region Coummication Section

        public Response CreateGetsterAppCommunicationTableDyanmically(int getster_id, int p_communication_id, string p_communication_timestamp,
            string p_communication_text, string Counter)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            MySqlParameter[] param = new MySqlParameter[5];
            using MySqlConnection con = new MySqlConnection(connection);
            try
            {
                param[0] = new MySqlParameter("p_getster_Id", MySqlDbType.Int32);
                param[0].Value = getster_id;

                param[1] = new MySqlParameter("p_communication_id", MySqlDbType.Int32);
                param[1].Value = p_communication_id;

                param[2] = new MySqlParameter("p_communication_timestamp", MySqlDbType.VarChar);
                param[2].Value = p_communication_timestamp;

                param[3] = new MySqlParameter("p_communication_text", MySqlDbType.VarChar);
                param[3].Value = p_communication_text;

               

                param[4] = new MySqlParameter("p_Counter", MySqlDbType.VarChar);
                param[4].Value = Counter;
                 
                ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_CreateGetsterAppCommunicationTableDyanmically", param);
            }
            catch (Exception ex)
            {

            }

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //GetAll
                    if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "GetAll")
                    {
                        List<getster_app_communication> lst_getster_app_communication = new List<getster_app_communication>();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            getster_app_communication _getster_app_communication = new getster_app_communication();
                            _getster_app_communication.communication_id = Convert.ToInt32(ds.Tables[0].Rows[i]["communication_id"]);
                            _getster_app_communication.getster_id = Convert.ToInt32(ds.Tables[0].Rows[i]["getster_id"]);
                            _getster_app_communication.communication_timestamp = Convert.ToString(ds.Tables[0].Rows[i]["communication_timestamp"]);
                            _getster_app_communication.communication_text = Convert.ToString(ds.Tables[0].Rows[i]["communication_text"]);
                            lst_getster_app_communication.Add(_getster_app_communication);
                        }
                        response.Data = lst_getster_app_communication;
                        response.Message = "Communication data fetched successfully";
                        response.Status = true;
                    }
                    else
                    {
                        response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                        response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                    }
                }
            }
            return response;
        }

        #endregion
    }
}
