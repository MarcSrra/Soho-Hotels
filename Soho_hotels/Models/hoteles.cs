//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Soho_hotels.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class hoteles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public hoteles()
        {
            this.act_hotel = new HashSet<act_hotel>();
        }
    
        public int id_ciudad { get; set; }
        public string nombre { get; set; }
        public int categoria { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
        public string tipo { get; set; }
        public string cif { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<act_hotel> act_hotel { get; set; }
        public virtual cadenas cadenas { get; set; }
        public virtual ciudades ciudades { get; set; }
    }
}
