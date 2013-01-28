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
    public class BZWZSGD:Entity
    {
        private int bzwzId;

        public int BzwzId
        {
            get { return bzwzId; }
            set { bzwzId = value; }
        }
        private string sgyy;

        public string Sgyy
        {
            get { return sgyy; }
            set { sgyy = value; }
        }
        private string sqrId;

        public string SqrId
        {
            get { return sqrId; }
            set { sqrId = value; }
        }
        private DateTime? sqsj;

        public DateTime? Sqsj
        {
            get { return sqsj; }
            set { sqsj = value; }
        }
    }
}
