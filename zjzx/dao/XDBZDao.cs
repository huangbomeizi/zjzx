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
using System.Data.SqlClient;
using zjzx.entity;
using System.Data.Common;

namespace zjzx.dao
{
    public class XDBZDao
    {
        private static readonly string ADD = "insert into XDBZ values (@BZH,@FBSJ,@SSSJ,@BZ_ID,@CJR_ID,@CJSJ)";
        private static readonly string DELETE = "delete from XDBZ where ID=@ID";
        private static readonly string UPDATE = "update XDBZ set BZH=@BZH,FBSJ=@FBSJ,SSSJ=@SSSJ,BZ_ID=@BZ_ID,CJR_ID=@CJR_ID,CJSJ=@CJSJ where ID=@ID";
        private static readonly string GET_LIST = "proc_getpagedata";
        private static readonly string GET_ENTITY = "select * from XDBZ";
        private static readonly string BATCH_DELETE = "delete from XDBZ where ID in ({0})";
        public bool add(XDBZ xdbz)
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
                    param[0] = new SqlParameter("@BZH", xdbz.Bzh);
                    param[1] = new SqlParameter("@FBSJ", xdbz.Fbsj);
                    param[2] = new SqlParameter("@SSSJ", xdbz.Sssj);
                    param[3] = new SqlParameter("@BZ_ID", xdbz.BzId);
                    param[4] = new SqlParameter("@CJR_ID", xdbz.CjrId);
                    param[5] = new SqlParameter("@CJSJ", xdbz.Cjsj);
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
        public bool update(XDBZ xdbz)
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
                    param[0] = new SqlParameter("@BZH", xdbz.Bzh);
                    param[1] = new SqlParameter("@FBSJ", xdbz.Fbsj);
                    param[2] = new SqlParameter("@SSSJ", xdbz.Sssj);
                    param[3] = new SqlParameter("@BZ_ID", xdbz.BzId);
                    param[4] = new SqlParameter("@CJR_ID", xdbz.CjrId);
                    param[5] = new SqlParameter("@CJSJ", xdbz.Cjsj);
                    param[6] = new SqlParameter("@ID", xdbz.Id);
                    foreach (DbParameter p in param)
                        cmd.Parameters.Add(p);
                    row = cmd.ExecuteNonQuery();
                }
            }
            return row > 0;
        }
        public XDBZ getEntity(int id)
        {
            XDBZ xdbz = null;
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
                            xdbz = new XDBZ();
                            xdbz.Bzh = reader["BZH"].ToString();
                            if (reader["FBSJ"] != null && reader["FBSJ"].ToString().Length>0)
                                xdbz.Fbsj = DateTime.Parse(reader["FBSJ"].ToString());
                            if (reader["SSSJ"] != null && reader["SSSJ"].ToString().Length>0)
                                xdbz.Sssj = DateTime.Parse(reader["SSSJ"].ToString());
                            xdbz.BzId = int.Parse(reader["BZ_ID"].ToString());
                            xdbz.CjrId = reader["CJR_ID"].ToString();
                            if (reader["CJSJ"] != null && reader["CJSJ"].ToString().Length>0)
                                xdbz.Cjsj = DateTime.Parse(reader["CJSJ"].ToString());
                            xdbz.Id = id;
                        }
                    }
                }
            }
            return xdbz;
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
                param[0] = new SqlParameter("@TableName", "XDBZ");
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
