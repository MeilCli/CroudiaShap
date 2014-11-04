using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CroudiaSharp {
    public class Config {
        public Config() {
            TimeOut = 10;
        }

        public int TimeOut { set; get; }

        public bool IsLog { set; get; }
    }
}
