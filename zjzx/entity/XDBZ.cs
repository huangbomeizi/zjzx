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

namespace zjzx.entity
{
    public class XDBZ:Entity
    {
        private string bzh;

        public string Bzh
        {
            get { return bzh; }
            set { bzh = value; }
        }
        private DateTime? fbsj;

        public DateTime? Fbsj
        {
            get { return fbsj; }
            set { fbsj = value; }
        }
        private DateTime? sssj;

        public DateTime? Sssj
        {
            get { return sssj; }
            set { sssj = value; }
        }
        private int bzId;

        public int BzId
        {
            get { return bzId; }
            set { bzId = value; }
        }
        private string cjrId;

        public string CjrId
        {
            get { return cjrId; }
            set { cjrId = value; }
        }
        private DateTime? cjsj;

        public DateTime? Cjsj
        {
            get { return cjsj; }
            set { cjsj = value; }
        }

    }
}
