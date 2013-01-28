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
    public class BZWJ:Entity
    {
        private string wjmc;

        public string Wjmc
        {
            get { return wjmc; }
            set { wjmc = value; }
        }
        private int bzId;

        public int BzId
        {
            get { return bzId; }
            set { bzId = value; }
        }
        private int xdbzId;

        public int XdbzId
        {
            get { return xdbzId; }
            set { xdbzId = value; }
        }
    }
}
