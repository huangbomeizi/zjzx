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
    public class SBJDD:Entity
    {
        private int sbId;

        public int SbId
        {
            get { return sbId; }
            set { sbId = value; }
        }
        private string clfw;

        public string Clfw
        {
            get { return clfw; }
            set { clfw = value; }
        }
        private string jddw;

        public string Jddw
        {
            get { return jddw; }
            set { jddw = value; }
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
        private string wj;

        public string Wj
        {
            get { return wj; }
            set { wj = value; }
        }
    }
}
