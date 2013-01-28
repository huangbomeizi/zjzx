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
    public class SBBFDPZJL:Entity
    {
        private int sbbfdId;

        public int SbbfdId
        {
            get { return sbbfdId; }
            set { sbbfdId = value; }
        }
        private string pzrId;

        public string PzrId
        {
            get { return pzrId; }
            set { pzrId = value; }
        }
        private bool sfty;

        public bool Sfty
        {
            get { return sfty; }
            set { sfty = value; }
        }
        private string yj;

        public string Yj
        {
            get { return yj; }
            set { yj = value; }
        }
        private DateTime? spsj;

        public DateTime? Spsj
        {
            get { return spsj; }
            set { spsj = value; }
        }
    }
}
