//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projekat
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblRacun
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblRacun()
        {
            this.tblStavkeNaRacunu = new HashSet<tblStavkeNaRacunu>();
        }
    
        public int ID { get; set; }
        public int Porez { get; set; }
        public int CenaSaPorezom { get; set; }
        public System.DateTime DatumKupovine { get; set; }
        public string Kupac { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblStavkeNaRacunu> tblStavkeNaRacunu { get; set; }
    }
}
