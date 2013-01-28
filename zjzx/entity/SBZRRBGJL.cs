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
    public class SBZRRBGJL:Entity
    {
        private int sbId;

        public int SbId
        {
            get { return sbId; }
            set { sbId = value; }
        }
        private string zrrId;

        public string ZrrId
        {
            get { return zrrId; }
            set { zrrId = value; }
        }
        private DateTime? bgsj;

        public DateTime? Bgsj
        {
            get { return bgsj; }
            set { bgsj = value; }
        }
    }
}
