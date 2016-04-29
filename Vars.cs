using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using tblLi;
using nsTblPd;

/*
Prefix Type    Represents                                                   Range                                                   Def. value
b      bool    Boolean value 	                                             True or False 	                                         False
uy     byte    8-bit unsigned integer 	                                     0 to 255 	                                             0
c      char    16-bit Unicode character     	                             U +0000 to U +ffff 	                                 '\0'
dc     decimal 128-bit precise decimal values with 28-29 significant digits (-7.9 x 1028 to 7.9 x 1028) / 100 to 28 	             0.0M
d      double  64-bit double-precision floating point type 	             (+/-)5.0 x 10-324 to (+/-)1.7 x 10308 	                 0.0D
f      float   32-bit single-precision floating point type 	             -3.4 x 1038 to + 3.4 x 1038 	                         0.0F
i      int 	32-bit signed integer type 	                                 -2,147,483,648 to 2,147,483,647 	                     0
l      long    64-bit signed integer type 	                                 -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807 0L
sy     sbyte   8-bit signed integer type 	                                 -128 to 127 	                                         0
sh     short   16-bit signed integer type 	                                 -32,768 to 32,767 	                                     0
ui     uint    32-bit unsigned integer type 	                             0 to 4,294,967,295                                  	 0
ul     ulong   64-bit unsigned integer type 	                             0 to 18,446,744,073,709,551,615 	                     0
us     ushort  16-bit unsigned integer type 	                             0 to 65,535 	                                         0
o      object
s      string

=> variabele toekenning: variabeletype variabelenaam (event. = waarde);

*/
namespace globalVars
{
    class gv
    {
        public static string sProgPad;
        public static string sDataPad;
        public static string sDataFilePad;
        public static string sLicentieFilePad;
        public static SQLiteConnection dbcDa;
        public static int actieveLicentieIndex;
        public static tblLicentie.liRecord actieveLicentie;
        public static Boolean bmoduleBasis;
        public static Boolean bmoduleExt;
        public static Boolean bmoduleIncas;
        public static Boolean bmoduleExport;
        public static int errorReturn;
        public static int instellingDemoAantalProducten;
        public static int instellingDemoExtraAantalProducten;
        public static int instellingUserMode;
     }

    class moVars
    {
        public struct moRecord
        {
            public int Id { get; set; }
            public string Kort { get; set; }
            public string Lang { get; set; }
            public int Actief { get; set; }
            public int licentieId { get; set; }
            public DateTime Mutatiedatum { get; set; }
            public string Opmerking { get; set; }
        }

        public List<moRecord> lstModuleRecord;
    }

    

}
