using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmbap
{
    class Tbls
    {
    }

    // Class voor Licentie-tabel
    class Li
    {
        public int Id { get; set; }
        public string Program { get; set; }
        public int Nr { get; set; }
        public string Code { get; set; }
        public byte Type { get; set; }
        public int Usermode { get; set; }
        public string Naamlh { get; set; }
        public string Displaynaamlh { get; set; }
        public string Contactpersoonlh { get; set; }
        public string Adreslh { get; set; }
        public string Postcodelh { get; set; }
        public string Woonplaatslh { get; set; }
        public string Telefoonnrlh { get; set; }
        public string Emailadreslh { get; set; }
        public string OudeControleCode { get; set; }
        public string NieuweControleCode { get; set; }
        public int ControleCodeType { get; set; }
        public DateTime Mutatiedatum { get; set; }
        public string Opmerking { get; set; }
    }
}
