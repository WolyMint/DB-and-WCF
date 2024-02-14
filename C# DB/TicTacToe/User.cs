using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace TicTacToe
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int IdRoom { get; set; }
        [DataMember]
        public string PasswordRoom { get; set; }
        public bool Create { get; set; }
        public OperationContext OperationContext { get; set; }

    }
}
