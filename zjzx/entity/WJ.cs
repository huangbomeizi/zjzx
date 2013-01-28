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
    public class WJ:Entity
    {
        private int wjlbId;

        public int WjlbId
        {
            get { return wjlbId; }
            set { wjlbId = value; }
        }
        private string wj;

        public string Wj
        {
            get { return wj; }
            set { wj = value; }
        }
        private int bmId;

        public int BmId
        {
            get { return bmId; }
            set { bmId = value; }
        }
        private string cjrId;

        public string CjrId
        {
            get { return cjrId; }
            set { cjrId = value; }
        }
    }
}
