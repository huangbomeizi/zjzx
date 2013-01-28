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
    public class SBQYD:Entity
    {
        private int sbId;

        public int SbId
        {
            get { return sbId; }
            set { sbId = value; }
        }
        private string qyyy;

        public string Qyyy
        {
            get { return qyyy; }
            set { qyyy = value; }
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
