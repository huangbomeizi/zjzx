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
    public class LC : Entity
    {
        private string lcmc;

        public string Lcmc
        {
            get { return lcmc; }
            set { lcmc = value; }
        }
        private int ssId;

        public int SsId
        {
            get { return ssId; }
            set { ssId = value; }
        }
        private string bzrId;

        public string BzrId
        {
            get { return bzrId; }
            set { bzrId = value; }
        }
        private int pxh;

        public int Pxh
        {
            get { return pxh; }
            set { pxh = value; }
        }
        private bool sfdqlc;

        public bool Sfdqlc
        {
            get { return sfdqlc; }
            set { sfdqlc = value; }
        }
        private int sslx;

        public int Sslx
        {
            get { return sslx; }
            set { sslx = value; }
        }
    }
}
