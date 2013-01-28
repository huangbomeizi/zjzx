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
using zjzx.dao;

namespace zjzx.facade
{
    public class SBQYDPZJLFacade
    {
        private static readonly SBQYDPZJLDao dao = new SBQYDPZJLDao();
        public bool add(SBQYDPZJL entity)
        {
            return dao.add(entity);
        }
        public bool delete(int id)
        {
            return dao.delete(id);
        }
        public bool batchDelete(string ids)
        {
            return dao.batchDelete(ids);
        }
        public bool update(SBQYDPZJL entity)
        {
            return dao.update(entity);
        }
        public SBQYDPZJL getEntity(int id)
        {
            return dao.getEntity(id);
        }
        public DataRecordTable getList(string fieldList, string orderField, bool orderBy, int pageIndex, int pageSize, string where)
        {
            return dao.getList(fieldList, orderField, orderBy, pageIndex, pageSize, where);
        }
    }
}
