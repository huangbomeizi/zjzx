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
    public class SBBFDPZJLDao
    {
        private static readonly string ADD = "insert into SBBFDPZJL values (@SBBFD_ID,@PZR_ID,@SFTY,@YJ,@SPSJ)";
        private static readonly string DELETE = "delete from SBBFDPZJL where ID=@ID";
        private static readonly string UPDATE = "update SBBFDPZJL set SBBFD_ID=@SBBFD_ID,PZR_ID=@PZR_ID,SFTY=@SFTY,YJ=@YJ,SPSJ=@SPSJ where ID=@ID";
        private static readonly string GET_LIST = "proc_getpagedata";
        private static readonly string GET_ENTITY = "select * from SBBFDPZJL";
        private static readonly string BATCH_DELETE = "delete from SBBFDPZJL where ID in ({0})";
        public bool add(SBBFDPZJL sbbfdpzjl)
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
                    param[0] = new SqlParameter("@SBBFD_ID", sbbfdpzjl.SbbfdId);
                    param[1] = new SqlParameter("@PZR_ID", sbbfdpzjl.PzrId);
                    param[2] = new SqlParameter("@SFTY", sbbfdpzjl.Sfty);
                    param[3] = new SqlParameter("@YJ", sbbfdpzjl.Yj);
                    param[4] = new SqlParameter("@SPSJ", sbbfdpzjl.Spsj);
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
        public bool update(SBBFDPZJL sbbfdpzjl)
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
                    param[0] = new SqlParameter("@SBBFD_ID", sbbfdpzjl.SbbfdId);
                    param[1] = new SqlParameter("@PZR_ID", sbbfdpzjl.PzrId);
                    param[2] = new SqlParameter("@SFTY", sbbfdpzjl.Sfty);
                    param[3] = new SqlParameter("@YJ", sbbfdpzjl.Yj);
                    param[4] = new SqlParameter("@SPSJ", sbbfdpzjl.Spsj);
                    param[5] = new SqlParameter("@ID", sbbfdpzjl.Id);
                    foreach (DbParameter p in param)
                        cmd.Parameters.Add(p);
                    row = cmd.ExecuteNonQuery();
                }
            }
            return row > 0;
        }
        public SBBFDPZJL getEntity(int id)
        {
            SBBFDPZJL sbbfdpzjl = null;
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
                            sbbfdpzjl = new SBBFDPZJL();
                            sbbfdpzjl.SbbfdId = int.Parse(reader["SBBFD_ID"].ToString());
                            sbbfdpzjl.PzrId = reader["PZR_ID"].ToString();
                            sbbfdpzjl.Sfty = bool.Parse(reader["SFTY"].ToString());
                            sbbfdpzjl.Yj = reader["YJ"].ToString();
                            if (reader["SPSJ"] != null && reader["SPSJ"].ToString().Length > 0)
                                sbbfdpzjl.Spsj = DateTime.Parse(reader["SPSJ"].ToString());
                            sbbfdpzjl.Id = id;
                        }
                    }
                }
            }
            return sbbfdpzjl;
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
                param[0] = new SqlParameter("@TableName", "SBBFDPZJL");
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
