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
    public class BZSGD : Entity
    {
       
        private string sgyy;

        public string Sgyy
        {
            get { return sgyy; }
            set { sgyy = value; }
        }
        private string sgrId;

        public string SgrId
        {
            get { return sgrId; }
            set { sgrId = value; }
        }
        private DateTime? sgsj;

        public DateTime? Sgsj
        {
            get { return sgsj; }
            set { sgsj = value; }
        }

    }
}
