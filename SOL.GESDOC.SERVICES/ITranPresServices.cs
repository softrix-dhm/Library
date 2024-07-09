using SOL.GESDOC.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOL.GESDOC.SERVICES
{
    public interface ITranPresServices
    {
        Boolean SolicitudPrestamo(T_TranSoliCabDto objTran);
    }
}
