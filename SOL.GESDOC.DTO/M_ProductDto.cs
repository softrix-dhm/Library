using System;
using System.Collections.Generic;
using System.Text;

namespace SOL.GESDOC.DTO
{
    public class M_ProductDto
    {
        public Int64 IdeProd { get; set; }
        public Int64 IdeCate { get; set; }
        public String CodBarrProd { get; set; }
        public String DesProd { get; set; }
        public Decimal PrecProd { get; set; }
        public String ObsProd { get; set; }
        public String Titulo { get; set; }
        public String Autor { get; set; }
        public String EstRegi { get; set; }
        public String CodUscr { get; set; }
        public DateTime FecUscr { get; set; }
        public String CodUsmo { get; set; }
        public DateTime FecUsmo { get; set; }
    }
}
