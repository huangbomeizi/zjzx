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
    public class SBZRRBGJLFacade
    {
        private static readonly SBZRRBGJLDao dao = new SBZRRBGJLDao();
        public bool add(SBZRRBGJL entity)
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
        public bool update(SBZRRBGJL entity)
        {
            return dao.update(entity);
        }
        public SBZRRBGJL getEntity(int id)
        {
            return dao.getEntity(id);
        }
        public DataRecordTable getList(string fieldList, string orderField, bool orderBy, int pageIndex, int pageSize, string where)
        {
            return dao.getList(fieldList, orderField, orderBy, pageIndex, pageSize, where);
        }
    }
}
