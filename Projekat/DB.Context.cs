﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class salonDBEntities : DbContext
    {
        public salonDBEntities()
            : base("name=salonDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblKategorija> tblKategorija { get; set; }
        public virtual DbSet<tblKomadNamestaja> tblKomadNamestaja { get; set; }
        public virtual DbSet<tblKorisnik> tblKorisnik { get; set; }
        public virtual DbSet<tblRacun> tblRacun { get; set; }
        public virtual DbSet<tblSaloni> tblSaloni { get; set; }
        public virtual DbSet<tblStavke> tblStavke { get; set; }
        public virtual DbSet<tblStavkeNaRacunu> tblStavkeNaRacunu { get; set; }
        public virtual DbSet<tblUloga> tblUloga { get; set; }
    }
}
