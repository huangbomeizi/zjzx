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
using System.Data.SqlClient;
using System.Data.Common;
namespace zjzx.dao
{
    public class BZDao
    {
        private static readonly string ADD = "insert into BZ values (@BZH,@BZMC,@FBSJ,@SSSJ,@ZFSJ,@ZT,@TDBZ,@BZZY,@CJR_ID,@CJSJ)";
        private static readonly string DELETE = "delete from BZ where ID=@ID";
        private static readonly string UPDATE = "update BZ set BZH=@BZH,BZMC=@BZMC,FBSJ=@FBSJ,SSSJ=@SSSJ,ZFSJ=@ZFSJ,ZT=@ZT,TDBZ=@TDBZ,BZZY=@BZZY where ID=@ID";
        private static readonly string GET_LIST = "proc_getpagedata";
        private static readonly string GET_ENTITY = "select * from BZ";
        private static readonly string BATCH_DELETE = "delete from BZ where ID in ({0})";
        public bool add(BZ bz)
        {
            int row = 0;
            using (DbConnection conn = new SqlConnection(SQLString.connString))
            {
                conn.Open();
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = ADD;
                    cmd.CommandType = CommandType.Text;
                    DbParameter [] param = new SqlParameter[10];
                    param[0] = new SqlParameter("@BZH", bz.Bzh);
                    param[1] = new SqlParameter("@BZMC", bz.Bzmc);
                    param[2] = new SqlParameter("@FBSJ", bz.Fbsj);
                    param[3] = new SqlParameter("@SSSJ", bz.Sssj);
                    param[4] = new SqlParameter("@ZFSJ", bz.Zfsj);
                    param[5] = new SqlParameter("@ZT", bz.Zt);
                    param[6] = new SqlParameter("@TDBZ", bz.Tdbz);
                    param[7] = new SqlParameter("@BZZY", bz.Bzzy);
                    param[8] = new SqlParameter("@CJR_ID", bz.CjrId);
                    param[9] = new SqlParameter("@CJSJ", bz.Cjsj);
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
        public bool update(BZ bz)
        {
            int row = 0;
            using (DbConnection conn = new SqlConnection(SQLString.connString))
            {
                conn.Open();
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = UPDATE;
                    cmd.CommandType = CommandType.Text;
                    DbParameter[] param = new SqlParameter[11];
                    param[0] = new SqlParameter("@BZH", bz.Bzh);
                    param[1] = new SqlParameter("@BZMC", bz.Bzmc);
                    param[2] = new SqlParameter("@FBSJ", bz.Fbsj);
                    param[3] = new SqlParameter("@SSSJ", bz.Sssj);
                    param[4] = new SqlParameter("@ZFSJ", bz.Zfsj);
                    param[5] = new SqlParameter("@ZT", bz.Zt);
                    param[6] = new SqlParameter("@TDBZ", bz.Tdbz);
                    param[7] = new SqlParameter("@BZZY", bz.Bzzy);
                    param[8] = new SqlParameter("@CJR_ID", bz.CjrId);
                    param[9] = new SqlParameter("@CJSJ", bz.Cjsj);
                    param[10] = new SqlParameter("@ID", bz.Id);
                    foreach (DbParameter p in param)
                        cmd.Parameters.Add(p);
                    row = cmd.ExecuteNonQuery();
                }
            }
            return row > 0;
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
                param[0] = new SqlParameter("@TableName", "BZ");
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
        public BZ getEntity(int id)
        {
            BZ bz = null;
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
                            bz = new BZ();
                            bz.Bzh = reader["BZH"].ToString();
                            bz.Bzmc = reader["BZMC"].ToString();
                            bz.Bzzy = reader["BZZY"].ToString();
                            bz.CjrId = reader["CJR_ID"].ToString();
                            if(reader["CJSJ"] != null && reader["CJSJ"].ToString().Length >0)
                                bz.Cjsj = DateTime.Parse(reader["CJSJ"].ToString());
                            if (reader["FBSJ"] != null && reader["FBSJ"].ToString().Length > 0)
                                bz.Fbsj = DateTime.Parse(reader["FBSJ"].ToString());
                            bz.Id = id;
                            if (reader["SSSJ"] != null && reader["SSSJ"].ToString().Length > 0)
                                bz.Sssj = DateTime.Parse(reader["SSSJ"].ToString());
                            bz.Tdbz = reader["TDBZ"].ToString();
                            if (reader["ZFSJ"] != null && reader["ZFSJ"].ToString().Length > 0)
                                bz.Zfsj = DateTime.Parse(reader["ZFSJ"].ToString());
                            bz.Zt = int.Parse(reader["ZT"].ToString());
                        }
                    }
                }
            }
            return bz;
        }
    }
}
