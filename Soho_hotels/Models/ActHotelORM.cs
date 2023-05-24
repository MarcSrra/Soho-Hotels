using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soho_hotels.Models
{
    public static class ActHotelORM
    {
        public static List<act_hotel> SelectByHotel(hoteles hotel)
        {
            List < act_hotel> activitats =
                (from a in Orm.bd.act_hotel
                 where a.nombre == hotel.nombre
                 select a
                ).ToList();

            return activitats;
        }

        public static String Insert(act_hotel activitel)
        {
            String missatge = "";
            Orm.bd.act_hotel.Add(activitel);
            missatge = Orm.MySaveCganges();
            return missatge;
        }

        public static String Delete(act_hotel activitel)
        {
            String missatge = "";
            Orm.bd.act_hotel.Remove(activitel);
            missatge = Orm.MySaveCganges();
            return missatge;
        }
    }
}
