using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nsTblBg
{
    class tblBg
    {
        public struct bg
        {
            public int Bgnr_Id { get; set; }
            public int Bgnr_StatusId { get; set; }
            public string Bgnr_DispStatus { get; set; }
            public int Bgnr_SysteemBgnrJN { get; set; }
            public int Bgnr_KlBgId { get; set; }
            public string Bgnr_DispKlBg { get; set; }
            public string Bgnr_Tnv { get; set; }
            public string Bgnr_Kort { get; set; }
            public string Bgnr_Iban { get; set; }
            public string Bgnr_IbanBankGiroKas { get; set; }
            public DateTime Bgnr_Mutatiedatum { get; set; }
            public string Bgnr_Opmerking { get; set; }
        }

    }
}
