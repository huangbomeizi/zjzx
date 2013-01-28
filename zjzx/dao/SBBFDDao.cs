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
using System.Data.Common;
using System.Data.SqlClient;
using zjzx.entity;

namespace zjzx.dao
{
    public class SBBFDDao
    {
        private static readonly string ADD = "insert into SBBFD values (@SB_ID,@SBZCZT,@BFYY,@SQR_ID,@SQSJ)";
        private static readonly string DELETE = "delete from SBBFD where ID=@ID";
        private static readonly string UPDATE = "update SBBFD set SB_ID=@SB_ID,SBZCZT=@SBZCZT,BFYY=@BFYY,SQR_ID=@SQR_ID,SQSJ=@SQSJ where ID=@ID";
        private static readonly string GET_LIST = "proc_getpagedata";
        private static readonly string GET_ENTITY = "select * from SBBFD";
        private static readonly string BATCH_DELETE = "delete from SBBFD where ID in ({0})";
        public bool add(SBBFD sbbfd)
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
                    param[0] = new SqlParameter("@SB_ID", sbbfd.SbId);
                    param[1] = new SqlParameter("@SBZCZT", sbbfd.Sbzczt);
                    param[2] = new SqlParameter("@BFYY", sbbfd.Bfyy);
                    param[3] = new SqlParameter("@SQR_ID", sbbfd.SqrId);
                    param[4] = new SqlParameter("@SQSJ", sbbfd.Sqsj);
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
        public bool update(SBBFD sbbfd)
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
                    param[0] = new SqlParameter("@SB_ID", sbbfd.SbId);
                    param[1] = new SqlParameter("@SBZCZT", sbbfd.Sbzczt);
                    param[2] = new SqlParameter("@BFYY", sbbfd.Bfyy);
                    param[3] = new SqlParameter("@SQR_ID", sbbfd.SqrId);
                    param[4] = new SqlParameter("@SQSJ", sbbfd.Sqsj);
                    param[5] = new SqlParameter("@ID", sbbfd.Id);
                    foreach (DbParameter p in param)
                        cmd.Parameters.Add(p);
                    row = cmd.ExecuteNonQuery();
                }
            }
            return row > 0;
        }
        public SBBFD getEntity(int id)
        {
            SBBFD sbbfd = null;
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
                            sbbfd = new SBBFD();
                            sbbfd.SbId = int.Parse(reader["SB_ID"].ToString());
                            sbbfd.Sbzczt = int.Parse(reader["SBZCZT"].ToString());
                            sbbfd.Bfyy = reader["BFYY"].ToString();
                            sbbfd.SqrId = reader["SQR_ID"].ToString();
                            if (reader["SQSJ"] != null && reader["SQSJ"].ToString().Length > 0)
                                sbbfd.Sqsj = DateTime.Parse(reader["SQSJ"].ToString());
                            sbbfd.Id = id;
                        }
                    }
                }
            }
            return sbbfd;
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
                param[0] = new SqlParameter("@TableName", "SBBFD");
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
