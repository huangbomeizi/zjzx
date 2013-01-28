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
    public class SBJDX:Entity
    {
        private int sbjddId;

        public int SbjddId
        {
            get { return sbjddId; }
            set { sbjddId = value; }
        }
        private string cs;

        public string Cs
        {
            get { return cs; }
            set { cs = value; }
        }
        private string jzfw;

        public string Jzfw
        {
            get { return jzfw; }
            set { jzfw = value; }
        }
        private string zqddj;

        public string Zqddj
        {
            get { return zqddj; }
            set { zqddj = value; }
        }
    }
}
