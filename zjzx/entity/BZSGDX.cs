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
    public class BZSGDX : Entity
    {
        
        private string bzh;

        public string Bzh
        {
            get { return bzh; }
            set { bzh = value; }
        }
        private string bzmc;

        public string Bzmc
        {
            get { return bzmc; }
            set { bzmc = value; }
        }
        private int sgdId;

        public int SgdId
        {
            get { return sgdId; }
            set { sgdId = value; }
        }
    }
}
