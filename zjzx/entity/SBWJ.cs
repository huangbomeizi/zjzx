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
    public class SBWJ:entity.Entity
    {
        private int sbId;

        public int SbId
        {
            get { return sbId; }
            set { sbId = value; }
        }
        private string wj;

        public string Wj
        {
            get { return wj; }
            set { wj = value; }
        }
    }
}
