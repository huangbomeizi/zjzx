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
    public class SBJDJGDao
    {
        private static readonly string ADD = "insert into SBJDJG values (@SBJDD_ID,@JG,@SFTG,@JZWJ,@JZSJ,@CJSJ,@SYBMQDR_ID)";
        private static readonly string DELETE = "delete from SBJDJG where ID=@ID";
        private static readonly string UPDATE = "update SBJDJG set SBJDD_ID=@SBJDD_ID,JG=@JG,SFTG=@SFTG,JZWJ=@JZWJ,JZSJ=@JZSJ,CJSJ=@CJSJ,SYBMQDR_ID=@SYBMQDR_ID where ID=@ID";
        private static readonly string GET_LIST = "proc_getpagedata";
        private static readonly string GET_ENTITY = "select * from SBJDJG";
        private static readonly string BATCH_DELETE = "delete from SBJDJG where ID in ({0})";
        public bool add(SBJDJG sbjdjg)
        {
            int row = 0;
            using (DbConnection conn = new SqlConnection(SQLString.connString))
            {
                conn.Open();
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = ADD;
                    cmd.CommandType = CommandType.Text;
                    DbParameter[] param = new SqlParameter[7];
                    param[0] = new SqlParameter("@SBJDD_ID", sbjdjg.SbjddId);
                    param[1] = new SqlParameter("@JG", sbjdjg.Jg);
                    param[2] = new SqlParameter("@SFTG", sbjdjg.Sftg);
                    param[3] = new SqlParameter("@JZWJ", sbjdjg.Jzwj);
                    param[4] = new SqlParameter("@JZSJ", sbjdjg.Jzsj);
                    param[5] = new SqlParameter("@CJSJ", sbjdjg.Cjsj);
                    param[6] = new SqlParameter("@SYBMQDR_ID", sbjdjg.SybmqdrId);
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
        public bool update(SBJDJG sbjdjg)
        {
            int row = 0;
            using (DbConnection conn = new SqlConnection(SQLString.connString))
            {
                conn.Open();
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = UPDATE;
                    cmd.CommandType = CommandType.Text;
                    DbParameter[] param = new SqlParameter[8];
                    param[0] = new SqlParameter("@SBJDD_ID", sbjdjg.SbjddId);
                    param[1] = new SqlParameter("@JG", sbjdjg.Jg);
                    param[2] = new SqlParameter("@SFTG", sbjdjg.Sftg);
                    param[3] = new SqlParameter("@JZWJ", sbjdjg.Jzwj);
                    param[4] = new SqlParameter("@JZSJ", sbjdjg.Jzsj);
                    param[5] = new SqlParameter("@CJSJ", sbjdjg.Cjsj);
                    param[6] = new SqlParameter("@SYBMQDR_ID", sbjdjg.SybmqdrId);
                    param[7] = new SqlParameter("@ID", sbjdjg.Id);
                    foreach (DbParameter p in param)
                        cmd.Parameters.Add(p);
                    row = cmd.ExecuteNonQuery();
                }
            }
            return row > 0;
        }
        public SBJDJG getEntity(int id)
        {
            SBJDJG sbjdjg = null;
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
                            sbjdjg = new SBJDJG();
                            sbjdjg.SbjddId = int.Parse(reader["SBJDD_ID"].ToString());
                            sbjdjg.Jg = reader["JG"].ToString();
                            sbjdjg.Sftg = bool.Parse(reader["SFTG"].ToString());
                            sbjdjg.Jzwj = reader["JZWJ"].ToString();
                            if (reader["JZSJ"] != null && reader["JZSJ"].ToString().Length > 0)
                                sbjdjg.Jzsj = DateTime.Parse(reader["JZSJ"].ToString());
                            if (reader["CJSJ"] != null && reader["CJSJ"].ToString().Length > 0)
                                sbjdjg.Cjsj = DateTime.Parse(reader["CJSJ"].ToString());
                            sbjdjg.SybmqdrId = reader["SYBMQDR_ID"].ToString();
                            sbjdjg.Id = id;
                        }
                    }
                }
            }
            return sbjdjg;
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
                param[0] = new SqlParameter("@TableName", "SBJDJG");
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
