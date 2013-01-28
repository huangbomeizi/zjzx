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
    public class SBDao
    {
        private static readonly string ADD = "insert into SB values (@SBMC,@SBXH,@SBBH,@MS,@CJSJ,@ZT,@ZRR_ID,@LQBM_ID,@LQR_ID,@LQSJ,@JDSJ,@YXQ,@YXQDW)";
        private static readonly string DELETE = "delete from SB where ID=@ID";
        private static readonly string UPDATE = "update SB set SBMC=@SBMC,SBXH=@SBXH,SBBH=@SBBH,MS=@MS,CJSJ=@CJSJ,ZRR_ID=@ZRR_ID,"+
            "LQBM_ID=@LQBM_ID,LQR_ID=@LQR_ID,LQSJ=@LQSJ,JDSJ=@JDSJ,YXQ=@YXQ,YXQDW=@YXQDW where ID=@ID";
        private static readonly string GET_LIST = "proc_getpagedata";
        private static readonly string GET_ENTITY = "select * from SB";
        private static readonly string BATCH_DELETE = "delete from SB where ID in ({0})";
        public bool add(SB sb)
        {
            int row = 0;
            using (DbConnection conn = new SqlConnection(SQLString.connString))
            {
                conn.Open();
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = ADD;
                    cmd.CommandType = CommandType.Text;
                    DbParameter[] param = new SqlParameter[13];
                    param[0] = new SqlParameter("@SBMC", sb.Sbmc);
                    param[1] = new SqlParameter("@SBXH", sb.Sbxh);
                    param[2] = new SqlParameter("@SBBH", sb.Sbbh);
                    param[3] = new SqlParameter("@MS", sb.Ms);
                    param[4] = new SqlParameter("@CJSJ", sb.Cjsj);
                    param[5] = new SqlParameter("@ZT", sb.Zt);
                    param[6] = new SqlParameter("@ZRR_ID", sb.ZrrId);
                    param[7] = new SqlParameter("@LQBM_ID", sb.LqbmId);
                    param[8] = new SqlParameter("@LQR_ID", sb.LqrId);
                    param[9] = new SqlParameter("@LQSJ", sb.Lqsj);
                    param[10] = new SqlParameter("@JDSJ", sb.Jdsj);
                    param[11] = new SqlParameter("@YXQ", sb.Yxq);
                    param[12] = new SqlParameter("@YXQDW", sb.Yxqdw);
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
        public bool update(SB sb)
        {
            int row = 0;
            using (DbConnection conn = new SqlConnection(SQLString.connString))
            {
                conn.Open();
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = UPDATE;
                    cmd.CommandType = CommandType.Text;
                    DbParameter[] param = new SqlParameter[14];
                    param[0] = new SqlParameter("@SBMC", sb.Sbmc);
                    param[1] = new SqlParameter("@SBXH", sb.Sbxh);
                    param[2] = new SqlParameter("@SBBH", sb.Sbbh);
                    param[3] = new SqlParameter("@MS", sb.Ms);
                    param[4] = new SqlParameter("@CJSJ", sb.Cjsj);
                    param[5] = new SqlParameter("@ZT", sb.Zt);
                    param[6] = new SqlParameter("@ZRR_ID", sb.ZrrId);
                    param[7] = new SqlParameter("@LQBM_ID", sb.LqbmId);
                    param[8] = new SqlParameter("@LQR_ID", sb.LqrId);
                    param[9] = new SqlParameter("@LQSJ", sb.Lqsj);
                    param[10] = new SqlParameter("@JDSJ", sb.Jdsj);
                    param[11] = new SqlParameter("@YXQ", sb.Yxq);
                    param[12] = new SqlParameter("@YXQDW", sb.Yxqdw);
                    param[13] = new SqlParameter("@ID", sb.Id);
                    foreach (DbParameter p in param)
                        cmd.Parameters.Add(p);
                    row = cmd.ExecuteNonQuery();
                }
            }
            return row > 0;
        }
        public SB getEntity(int id)
        {
            SB sb = null;
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
                            sb = new SB();
                            sb.Sbmc = reader["SBMC"].ToString();
                            sb.Sbxh = reader["SBXH"].ToString();
                            sb.Sbbh = reader["SBBH"].ToString();
                            sb.Ms = reader["MS"].ToString();
                            if (reader["CJSJ"] != null && reader["CJSJ"].ToString().Length>0)
                                sb.Cjsj = DateTime.Parse(reader["CJSJ"].ToString());
                            sb.Zt = int.Parse(reader["ZT"].ToString());
                            sb.ZrrId = reader["ZRR_ID"].ToString();
                            sb.LqbmId = int.Parse(reader["LQBM_ID"].ToString());
                            sb.LqrId = reader["LQR_ID"].ToString();
                            if (reader["LQSJ"] != null && reader["LQSJ"].ToString().Length>0)
                                sb.Lqsj = DateTime.Parse(reader["LQSJ"].ToString());
                            if (reader["JDSJ"] != null && reader["JDSJ"].ToString().Length > 0)
                                sb.Jdsj = DateTime.Parse(reader["JDSJ"].ToString());
                            sb.Yxq = int.Parse(reader["YXQ"].ToString());
                            sb.Yxqdw = reader["YXQDW"].ToString();
                            sb.Id = id;
                        }
                    }
                }
            }
            return sb;
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
                param[0] = new SqlParameter("@TableName", "SB");
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
