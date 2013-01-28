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
using zjzx.dao;
using zjzx.entity;

namespace zjzx.facade
{
    public class BZFacade
    {
        private static readonly BZDao bzdao = new BZDao();
        public bool add(BZ bz)
        {
            return bzdao.add(bz);
        }
        public bool delete(int id)
        {
            return bzdao.delete(id);
        }
        public bool batchDelete(string ids)
        {
            return bzdao.batchDelete(ids);
        }
        public bool update(BZ bz)
        {
            return bzdao.update(bz);
        }
        public DataRecordTable getList(string fieldList, string orderField, bool orderBy, int pageIndex, int pageSize, string where)
        {
            return bzdao.getList(fieldList, orderField, orderBy, pageIndex, pageSize, where);
        }
        public BZ getEntity(int id)
        {
            return bzdao.getEntity(id);
        }
    }
}
