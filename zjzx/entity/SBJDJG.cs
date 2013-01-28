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
    public class SBJDJG:Entity
    {
        private int sbjddId;

        public int SbjddId
        {
            get { return sbjddId; }
            set { sbjddId = value; }
        }
        private string jg;

        public string Jg
        {
            get { return jg; }
            set { jg = value; }
        }
        private bool sftg;

        public bool Sftg
        {
            get { return sftg; }
            set { sftg = value; }
        }
        private string jzwj;

        public string Jzwj
        {
            get { return jzwj; }
            set { jzwj = value; }
        }
        private DateTime? jzsj;

        public DateTime? Jzsj
        {
            get { return jzsj; }
            set { jzsj = value; }
        }
        private DateTime? cjsj;

        public DateTime? Cjsj
        {
            get { return cjsj; }
            set { cjsj = value; }
        }
        private string sybmqdrId;

        public string SybmqdrId
        {
            get { return sybmqdrId; }
            set { sybmqdrId = value; }
        }
    }
}
