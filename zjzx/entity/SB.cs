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
    public class SB:Entity
    {
        private string sbmc;

        public string Sbmc
        {
            get { return sbmc; }
            set { sbmc = value; }
        }
        private string sbxh;

        public string Sbxh
        {
            get { return sbxh; }
            set { sbxh = value; }
        }
        private string sbbh;

        public string Sbbh
        {
            get { return sbbh; }
            set { sbbh = value; }
        }
        private string ms;

        public string Ms
        {
            get { return ms; }
            set { ms = value; }
        }
        private DateTime? cjsj;

        public DateTime? Cjsj
        {
            get { return cjsj; }
            set { cjsj = value; }
        }
        private int zt;

        public int Zt
        {
            get { return zt; }
            set { zt = value; }
        }
        private string zrrId;

        public string ZrrId
        {
            get { return zrrId; }
            set { zrrId = value; }
        }
        private int lqbmId;

        public int LqbmId
        {
            get { return lqbmId; }
            set { lqbmId = value; }
        }
        private string lqrId;

        public string LqrId
        {
            get { return lqrId; }
            set { lqrId = value; }
        }
        private DateTime? lqsj;

        public DateTime? Lqsj
        {
            get { return lqsj; }
            set { lqsj = value; }
        }
        private DateTime? jdsj;

        public DateTime? Jdsj
        {
            get { return jdsj; }
            set { jdsj = value; }
        }
        private int yxq;

        public int Yxq
        {
            get { return yxq; }
            set { yxq = value; }
        }
        private string yxqdw;

        public string Yxqdw
        {
            get { return yxqdw; }
            set { yxqdw = value; }
        }
    }
}
