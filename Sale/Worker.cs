﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale
{
    public class Worker
    {
        public string bh;
        public string xm;
        public string mm;
        public override string ToString()
        {
            return string.Format("{0} ({1})", this.bh, this.xm);
        }
    }
}
