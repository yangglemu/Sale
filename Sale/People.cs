using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale
{
    class People
    {
        public string bh;
        public string xm;
        public int jf;
        public bool enable;
        public string zqfs
        {
            get
            {
                if (this.enable)
                    return "会员";
                else
                    return "折扣";
            }
        }
        public People()
        {
            this.bh = null;
            this.xm = null;
            this.jf = 0;
            this.enable = false;

            
        }
        public People(string bh, string xm, int jf, bool enable)
        {
            this.bh = bh;
            this.xm = xm;
            this.jf = jf;
            this.enable = enable;
        }
    }
}
