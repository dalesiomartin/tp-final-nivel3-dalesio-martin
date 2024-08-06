using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class Seguridad
    {
        public static bool SesionActiva(object user)
        {
            Trainee trainee = user != null ? (Trainee)user : null;

            if (trainee != null && trainee.Id != 0)
                return true;   //Si hay un user "vivo" y tiene datos en la DB retorno true
            else
                return false;
        }

        public static bool EsAdmin(object user)
        {
            Trainee trainee = user != null ? (Trainee)user : null;
            return trainee != null ? trainee.Admin : false;  //al loguearme me trae de db si es admin o no (booleano)
        }
    }
}
