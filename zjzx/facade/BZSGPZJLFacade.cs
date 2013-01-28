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
    public class BZSGPZJLFacade
    {
        private static readonly BZSGPZJLDao dao = new BZSGPZJLDao();
        public bool add(BZSGPZJL bzsgpzjl)
        {
            return dao.add(bzsgpzjl);
        }
        public bool delete(int id)
        {
            return dao.delete(id);
        }
        public bool batchDelete(string ids)
        {
            return dao.batchDelete(ids);
        }
        public bool update(BZSGPZJL bzsgpzjl)
        {
            return dao.update(bzsgpzjl);
        }
        public DataRecordTable getList(string fieldList, string orderField, bool orderBy, int pageIndex, int pageSize, string where)
        {
            return dao.getList(fieldList, orderField, orderBy, pageIndex, pageSize, where);
        }
        public BZSGPZJL getEntity(int id)
        {
            return dao.getEntity(id);
        }
    }
}
