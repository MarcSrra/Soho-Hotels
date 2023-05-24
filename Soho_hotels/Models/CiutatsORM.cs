using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soho_hotels.Models
{
    public static class CiutatsORM
    {
        public static List<ciudades> Select()
        {
            List<ciudades> ciutats =
                (from a in Orm.bd.ciudades
                 select a
                ).ToList();

            return ciutats;
        }

        public static ciudades SelectCiutatsByID(int id)
        {
            List<ciudades> ciutats =
                (from a in Orm.bd.ciudades
                 where a.id_ciudad == id
                 select a
                ).ToList();

            ciudades ciutat = ciutats[0];

            return ciutat;
        }
    }
}
