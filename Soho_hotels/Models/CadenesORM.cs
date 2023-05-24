using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soho_hotels.Models
{
    public static class CadenesORM
    {
        public static List<cadenas> Select()
        {
            List<cadenas> cadenes = 
                (from a in Orm.bd.cadenas
                 orderby a.nombre
                 select a
                ).ToList();

            return cadenes;
        }

        public static cadenas SelectByCIF(String cif)
        {
            List<cadenas> cadenes =
                (from a in Orm.bd.cadenas
                 where a.cif == cif
                 orderby a.nombre
                 select a
                ).ToList();

            cadenas cadena = cadenes[0];

            return cadena;
        }

        public static List<cadenas> SelectByNom(String nom)
        {
            List<cadenas> cadenes =
                (from a in Orm.bd.cadenas
                 where a.nombre.Contains(nom)
                 orderby a.nombre
                 select a
                ).ToList();

            return cadenes;
        }

        public static String Update()
        {
            String missatge = "";
            missatge = Orm.MySaveCganges();
            return missatge;
        }

        public static String Delete(cadenas cadena)
        {
            String missatge = "";
            Orm.bd.cadenas.Remove(cadena);
            missatge = Orm.MySaveCganges();
            return missatge;
        }

        public static String Insert(cadenas cadena)
        {
            String missatge = "";
            Orm.bd.cadenas.Add(cadena);
            missatge = Orm.MySaveCganges();
            return missatge;
        }
    }
}
