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
    
    public partial class act_hotel
    {
        public int id_ciudad { get; set; }
        public string nombre { get; set; }
        public int id_act { get; set; }
        public int grado { get; set; }
    
        public virtual actividades actividades { get; set; }
        public virtual hoteles hoteles { get; set; }
    }
}