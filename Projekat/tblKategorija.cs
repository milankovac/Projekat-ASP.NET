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
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;
    using static Projekat.Controllers.KategorijaController;

    public partial class tblKategorija
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblKategorija()
        {
            this.tblKomadNamestaja = new HashSet<tblKomadNamestaja>();
        }
        public string Text { get; set; }
        public int ID { get; set; }
        [Required(ErrorMessage = "Morate uneti naziv.")]
        [StringLength(50, ErrorMessage = "Maksimum 40 karaktera")]
        [Remote("nazivJedinstven", "Kategorija", ErrorMessage = "Naziv kategorije je vec u upotrebi!")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Morate uneti opis.")]
        [StringLength(50, ErrorMessage = "Maksimum 40 karaktera")]
        public string Opis { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblKomadNamestaja> tblKomadNamestaja { get; set; }
    }
}
