using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CroudiaSharp.Data {

    [DataContract]
    public class Error {

        internal Error() { }

        [DataMember(Name = "error")]
        public string ErrorMessage { private set; get; }
    }

}
