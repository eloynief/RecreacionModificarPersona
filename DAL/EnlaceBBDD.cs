using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class EnlaceBBDD
    {

        /// <summary>
        /// enlace para conectarse a la base de datos
        /// </summary>
        /// <returns></returns>
        public static string Conexion()
        {
            return "server=siobhantt.database.windows.net;database=LuisaBD;uid=prueba;pwd=fernandoG321;trustServerCertificate=true;";
        }

    }
}
