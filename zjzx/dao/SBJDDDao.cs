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
    public class SBJDDDao
    {
        private static readonly string ADD = "insert into SBJDD values (@SB_ID,@CLFW,@JDDW,@SQR_ID,@SQSJ,@WJ)";
        private static readonly string DELETE = "delete from SBJDD where ID=@ID";
        private static readonly string UPDATE = "update SBJDD set SB_ID=@SB_ID,CLFW=@CLFW,JDDW=@JDDW,SQR_ID=@SQR_ID,SQSJ=@SQSJ,WJ=@WJ where ID=@ID";
        private static readonly string GET_LIST = "proc_getpagedata";
        private static readonly string GET_ENTITY = "select * from SBJDD";
        private static readonly string BATCH_DELETE = "delete from SBJDD where ID in ({0})";
        public bool add(SBJDD sbjdd)
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
                    param[0] = new SqlParameter("@SB_ID", sbjdd.SbId);
                    param[1] = new SqlParameter("@CLFW", sbjdd.Clfw);
                    param[2] = new SqlParameter("@JDDW", sbjdd.Jddw);
                    param[3] = new SqlParameter("@SQR_ID", sbjdd.SqrId);
                    param[4] = new SqlParameter("@SQSJ", sbjdd.Sqsj);
                    param[5] = new SqlParameter("@WJ", sbjdd.Wj);
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
        public bool update(SBJDD sbjdd)
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
                    param[0] = new SqlParameter("@SB_ID", sbjdd.SbId);
                    param[1] = new SqlParameter("@CLFW", sbjdd.Clfw);
                    param[2] = new SqlParameter("@JDDW", sbjdd.Jddw);
                    param[3] = new SqlParameter("@SQR_ID", sbjdd.SqrId);
                    param[4] = new SqlParameter("@SQSJ", sbjdd.Sqsj);
                    param[5] = new SqlParameter("@WJ", sbjdd.Wj);
                    param[6] = new SqlParameter("@ID", sbjdd.Id);
                    foreach (DbParameter p in param)
                        cmd.Parameters.Add(p);
                    row = cmd.ExecuteNonQuery();
                }
            }
            return row > 0;
        }
        public SBJDD getEntity(int id)
        {
            SBJDD sbjdd = null;
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
                            sbjdd = new SBJDD();
                            sbjdd.SbId = int.Parse(reader["SB_ID"].ToString());
                            sbjdd.Clfw = reader["CLFW"].ToString();
                            sbjdd.Jddw = reader["JDDW"].ToString();
                            sbjdd.SqrId = reader["SQR_ID"].ToString();
                            if (reader["SQSJ"] != null && reader["SQSJ"].ToString().Length > 0)
                                sbjdd.Sqsj = DateTime.Parse(reader["SQSJ"].ToString());
                            sbjdd.Wj = reader["WJ"].ToString();
                            sbjdd.Id = id;
                        }
                    }
                }
            }
            return sbjdd;
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
                param[0] = new SqlParameter("@TableName", "SBJDD");
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
