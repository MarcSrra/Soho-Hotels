using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Soho_hotels.Models
{
    public static class HotelsORM
    {
        public static List<hoteles> Select()
        {
            List<hoteles> hotels =
                (from a in Orm.bd.hoteles
                 orderby a.nombre
                 select a
                ).ToList();

            return hotels;
        }

        public static hoteles SelectById(String nombre, int id_ciudad)
        {
            List<hoteles> hoteles =
                (from a in Orm.bd.hoteles
                 where a.nombre == nombre && a.id_ciudad == id_ciudad
                 select a
                ).ToList();

            hoteles hotel = hoteles[0];

            return hotel;
        }

        public static List<hoteles> SelectByCadena(String cif)
        {
            List<hoteles> hotels =
                (from a in Orm.bd.hoteles
                 where a.cif == cif
                 orderby a.nombre
                 select a
                ).ToList();

            return hotels;
        }

        public static List<hoteles> SelectByNom(String nom)
        {
            List<hoteles> hotels =
                (from a in Orm.bd.hoteles
                 where a.nombre.Contains(nom)
                 orderby a.nombre
                 select a
                ).ToList();

            return hotels;
        }

        public static List<hoteles> SelectByNomCadena(String nom, String cif)
        {
            List<hoteles> hotels =
                (from a in Orm.bd.hoteles
                 where a.nombre.Contains(nom) && a.cif == cif
                 orderby a.nombre
                 select a
                ).ToList();

            return hotels;
        }

        public static List<hoteles> SelectByCif(String cif)
        {
            List<hoteles> hotels =
                (from a in Orm.bd.hoteles
                 where a.cif == cif
                 select a
                ).ToList();

            return hotels;
        }

        public static String Update()
        {
            String missatge = "";
            missatge = Orm.MySaveCganges();
            return missatge;
        }

        public static String Delete(hoteles updatedhotel)
        {
            String missatge = "";
            Orm.bd.hoteles.Remove(updatedhotel);
            missatge = Orm.MySaveCganges();
            return missatge;
        }

        public static String Insert(hoteles _hotel)
        {
            String missatge = "";
            Orm.bd.hoteles.Add(_hotel);
            missatge = Orm.MySaveCganges();
            return missatge;
        }
    }
}
