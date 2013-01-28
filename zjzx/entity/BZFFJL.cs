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
    public class BZFFJL:Entity
    {
        private int bzId;

        public int BzId
        {
            get { return bzId; }
            set { bzId = value; }
        }
        private int bmId;

        public int BmId
        {
            get { return bmId; }
            set { bmId = value; }
        }
        private string skh;

        public string Skh
        {
            get { return skh; }
            set { skh = value; }
        }
        private DateTime? ffsj;

        public DateTime? Ffsj
        {
            get { return ffsj; }
            set { ffsj = value; }
        }
    }
}
