﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data.Common;
using zjzx.entity;

namespace zjzx.dao
{
    public class SBSGDPZJLDao
    {
        private static readonly string ADD = "insert into SBSGDPZJL values (@SBSGD_ID,@PZR_ID,@SFTY,@YJ,@SPSJ)";
        private static readonly string DELETE = "delete from SBSGDPZJL where ID=@ID";
        private static readonly string UPDATE = "update SBSGDPZJL set SBSGD_ID=@SBSGD_ID,PZR_ID=@PZR_ID,SFTY=@SFTY,YJ=@YJ,SPSJ=@SPSJ where ID=@ID";
        private static readonly string GET_LIST = "proc_getpagedata";
        private static readonly string GET_ENTITY = "select * from SBSGDPZJL";
        private static readonly string BATCH_DELETE = "delete from SBSGDPZJL where ID in ({0})";
        public bool add(SBSGDPZJL sbsgdpzjl)
        {
            int row = 0;
            using (DbConnection conn = new SqlConnection(SQLString.connString))
            {
                conn.Open();
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = ADD;
                    cmd.CommandType = CommandType.Text;
                    DbParameter[] param = new SqlParameter[5];
                    param[0] = new SqlParameter("@SBSGD_ID", sbsgdpzjl.SgdId);
                    param[1] = new SqlParameter("@PZR_ID", sbsgdpzjl.PzrId);
                    param[2] = new SqlParameter("@SFTY", sbsgdpzjl.Sfty);
                    param[3] = new SqlParameter("@YJ", sbsgdpzjl.Yj);
                    param[4] = new SqlParameter("@SPSJ", sbsgdpzjl.Spsj);
                    foreach (DbParameter p in param)
                        cmd.Parameters.Add(p);
                    row = cmd.ExecuteNonQuery();
                }
            }
            return row > 0;
        }
        public bool delete(int id)
        {
            int row = 0;
            using (DbConnection conn = new SqlConnection(SQLString.connString))
            {
                conn.Open();
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = DELETE;
                    cmd.CommandType = CommandType.Text;
                    DbParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter("@ID", id);
                    foreach (DbParameter p in param)
                        cmd.Parameters.Add(p);
                    row = cmd.ExecuteNonQuery();
                }
            }
            return row > 0;
        }
        public bool batchDelete(string ids)
        {
            string sql = string.Format(BATCH_DELETE, ids);
            int row = 0;
            using (DbConnection conn = new SqlConnection(SQLString.connString))
            {
                conn.Open();
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;
                    DbParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter("@IDS", ids);
                    param[0].DbType = DbType.String;
                    foreach (DbParameter p in param)
                        cmd.Parameters.Add(p);
                    row = cmd.ExecuteNonQuery();
                }
            }
            return row > 0;
        }
        public bool update(SBSGDPZJL sbsgdpzjl)
        {
            int row = 0;
            using (DbConnection conn = new SqlConnection(SQLString.connString))
            {
                conn.Open();
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = UPDATE;
                    cmd.CommandType = CommandType.Text;
                    DbParameter[] param = new SqlParameter[6];
                    param[0] = new SqlParameter("@SBSGD_ID", sbsgdpzjl.SgdId);
                    param[1] = new SqlParameter("@PZR_ID", sbsgdpzjl.PzrId);
                    param[2] = new SqlParameter("@SFTY", sbsgdpzjl.Sfty);
                    param[3] = new SqlParameter("@YJ", sbsgdpzjl.Yj);
                    param[4] = new SqlParameter("@SPSJ", sbsgdpzjl.Spsj);
                    param[5] = new SqlParameter("@ID", sbsgdpzjl.Id);
                    foreach (DbParameter p in param)
                        cmd.Parameters.Add(p);
                    row = cmd.ExecuteNonQuery();
                }
            }
            return row > 0;
        }
        public SBSGDPZJL getEntity(int id)
        {
            SBSGDPZJL sbsgdpzjl = null;
            using (DbConnection conn = new SqlConnection(SQLString.connString))
            {
                conn.Open();
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = GET_ENTITY;
                    cmd.CommandType = CommandType.Text;
                    DbParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter("@ID", id);
                    foreach (DbParameter p in param)
                        cmd.Parameters.Add(p);
                    DbDataReader reader = cmd.ExecuteReader();
                    using (reader)
                    {
                        if (reader.Read())
                        {
                            sbsgdpzjl = new SBSGDPZJL();
                            sbsgdpzjl.SgdId = int.Parse(reader["SBSGD_ID"].ToString());
                            sbsgdpzjl.PzrId = reader["PZR_ID"].ToString();
                            sbsgdpzjl.Sfty = bool.Parse(reader["SFTY"].ToString());
                            sbsgdpzjl.Yj = reader["YJ"].ToString();
                            if (reader["SPSJ"] != null && reader["SPSJ"].ToString().Length>0)
                                sbsgdpzjl.Spsj = DateTime.Parse(reader["SPSJ"].ToString());
                            sbsgdpzjl.Id = id;
                        }
                    }
                }
            }
            return sbsgdpzjl;
        }
        public DataRecordTable getList(string fieldList, string orderField, bool orderBy, int pageIndex, int pageSize, string where)
        {
            DataRecordTable table = new DataRecordTable();
            table.PageSize = pageSize;
            table.PageIndex = pageIndex;


            using (SqlConnection conn = new SqlConnection(SQLString.connString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = GET_LIST;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@TableName", "SBSGDPZJL");
                param[1] = new SqlParameter("@FieldList", fieldList);
                param[2] = new SqlParameter("@PageSize", pageSize);
                param[3] = new SqlParameter("@PageIndex", pageIndex);
                param[4] = new SqlParameter("@OrderField", orderField);
                param[5] = new SqlParameter("@OrderType", orderBy);
                param[5].DbType = DbType.Boolean;
                param[6] = new SqlParameter("@Where", where);
                param[7] = new SqlParameter("@RecordCount", SqlDbType.Int);
                param[7].Direction = ParameterDirection.Output;
                param[8] = new SqlParameter("@PageCount", SqlDbType.Int);
                param[8].Direction = ParameterDirection.Output;
                foreach (DbParameter p in param)
                    cmd.Parameters.Add(p);

                DbDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                table.RecordCount = int.Parse(cmd.Parameters["@RecordCount"].Value.ToString());
                table.PageCount = int.Parse(cmd.Parameters["@pageCount"].Value.ToString());
                table.Table = dt;
                cmd.Parameters.Clear();
            }
            return table;
        }
    }
}
