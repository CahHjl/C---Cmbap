using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace nsTblBr
{
    class tblBr
    {
        public struct br
        {
            public int Bnkrgl_Id { get; set; }
            public int Bnkrgl_BgnrId { get; set; }
            public int Bnkrgl_StatusId { get; set; }
            public string Bnkrgl_DispStatus { get; set; }
            public int Bnkrgl_VerwerkId { get; set; }
            public ArrayList Bnkrgl_Bankregel { get; set; }
            public int Bnkrgl_BstlId { get; set; }
            public DateTime Bnkrgl_Mutatiedatum { get; set; }
            public string Bnkrgl_Opmerking { get; set; }
        }
    }
}
