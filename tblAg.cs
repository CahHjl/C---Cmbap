using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tblAg
{
    class tblAg
    {
        public struct ag
        {
            public int Adrsgeg_Id { get; set; }
            public int Adrsgeg_StatusId { get; set; }
            public string Adrsgeg_DispStatus { get; set; }
            public int Adrsgeg_KlBgId { get; set; }
            public string Adrsgeg_DispKlBg { get; set; }
            public string Adrsgeg_Straatnaam { get; set; }
            public string Adrsgeg_Huisnummer { get; set; }
            public string Adrsgeg_Huisnummertoevoeging { get; set; }
            public string Adrsgeg_Adres { get; set; }
            public string Adrsgeg_Postcode { get; set; }
            public string Adrsgeg_Woonplaats { get; set; }
            public DateTime Adrsgeg_Mutatiedatum { get; set; }
            public string Adrsgeg_Opmerking { get; set; }
        }
    }
}
