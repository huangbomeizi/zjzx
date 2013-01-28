using System;
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
using zjzx.entity;
using System.Data.Common;
using System.Data.SqlClient;

namespace zjzx.dao
{
    public class LCDao
    {
        private static readonly string ADD = "insert into LC values (@LCMC,@SS_ID,@BZR_ID,@PXH,@SFDQLC,@SSLX)";
        private static readonly string DELETE = "delete from LC where ID=@ID";
        private static readonly string UPDATE = "update LC set LCMC=@LCMC,SS_ID=@SS_ID,BZR_ID=@BZR_ID,PXH=@PXH,SFDQLC=@SFDQLC,SSLX=@SSLX where ID=@ID";
        private static readonly string GET_LIST = "proc_getpagedata";
        private static readonly string GET_ENTITY = "select * from LC";
        private static readonly string BATCH_DELETE = "delete from LC where ID in ({0})";
        public bool add(LC lc)
        {
            int row = 0;
            using (DbConnection conn = new SqlConnection(SQLString.connString))
            {
                conn.Open();
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = ADD;
                    cmd.CommandType = CommandType.Text;
                    DbParameter[] param = new SqlParameter[6];
                    param[0] = new SqlParameter("@LCMC", lc.Lcmc);
                    param[1] = new SqlParameter("@SS_ID", lc.SsId);
                    param[2] = new SqlParameter("@BZR_ID", lc.BzrId);
                    param[3] = new SqlParameter("@PXH", lc.Pxh);
                    param[4] = new SqlParameter("@SFDQLC", lc.Sfdqlc);
                    param[5] = new SqlParameter("@SSLX", lc.Sslx);
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
        public bool update(LC lc)
        {
            int row = 0;
            using (DbConnection conn = new SqlConnection(SQLString.connString))
            {
                conn.Open();
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = UPDATE;
                    cmd.CommandType = CommandType.Text;
                    DbParameter[] param = new SqlParameter[7];
                    param[0] = new SqlParameter("@LCMC", lc.Lcmc);
                    param[1] = new SqlParameter("@SS_ID", lc.SsId);
                    param[2] = new SqlParameter("@BZR_ID", lc.BzrId);
                    param[3] = new SqlParameter("@PXH", lc.Pxh);
                    param[4] = new SqlParameter("@SFDQLC", lc.Sfdqlc);
                    param[5] = new SqlParameter("@SSLX", lc.Sslx);
                    param[6] = new SqlParameter("@ID", lc.Id);
                    foreach (DbParameter p in param)
                        cmd.Parameters.Add(p);
                    row = cmd.ExecuteNonQuery();
                }
            }
            return row > 0;
        }
        public LC getEntity(int id)
        {
            LC lc = null;
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
                            lc = new LC();
                            lc.Lcmc = reader["LCMC"].ToString();
                            lc.Sslx = int.Parse(reader["SS_ID"].ToString());
                            lc.BzrId = reader["BZR_ID"].ToString();
                            lc.Pxh = int.Parse(reader["PXH"].ToString());
                            lc.Sfdqlc = bool.Parse(reader["SFDQLC"].ToString());
                            lc.Sslx = int.Parse(reader["SSLX"].ToString());
                            lc.Id = id;
                        }
                    }
                }
            }
            return lc;
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
                param[0] = new SqlParameter("@TableName", "LC");
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
