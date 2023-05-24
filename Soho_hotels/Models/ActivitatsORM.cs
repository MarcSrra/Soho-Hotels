using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soho_hotels.Models
{
    public static class ActivitatsORM
    {
        public static List<actividades> Select()
        {
            List<actividades> activitats =
                (from a in Orm.bd.actividades
                 select a
                ).ToList();

            return activitats;
        }

        public static actividades SelectActivitatByID(int id)
        {
            List<actividades> activitats =
                (from a in Orm.bd.actividades
                 where a.id_act == id
                 select a
                ).ToList();

            actividades activitat = activitats[0];

            return activitat;
        }
    }
}
