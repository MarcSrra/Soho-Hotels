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
    
    public partial class cadenas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cadenas()
        {
            this.hoteles = new HashSet<hoteles>();
        }
    
        public string cif { get; set; }
        public string nombre { get; set; }
        public string dir_fis { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hoteles> hoteles { get; set; }

        public static explicit operator cadenas(int v)
        {
            throw new NotImplementedException();
        }
    }
}
