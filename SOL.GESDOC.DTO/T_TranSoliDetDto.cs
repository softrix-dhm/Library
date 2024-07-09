using System;
using System.Collections.Generic;
using System.Text;

namespace SOL.GESDOC.DTO
{
    public class T_TranSoliDetDto
    {
        public Int64 IdeSoli { get; set; }
        public Int64 IdeSoliCab { get; set; }
        public int Item { get; set; }
        public Int64 IdeProd { get; set; }
        public int CanProd { get; set; }
        public String EstRegi { get; set; }
        public String CodUscr { get; set; }
        public DateTime FecUscr { get; set; }
        public String CodUsmo { get; set; }
        public DateTime FecUsmo { get; set; }
    }
}
