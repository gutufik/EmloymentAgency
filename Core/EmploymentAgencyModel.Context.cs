﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EmploymentAgencyEntities : DbContext
    {
        public EmploymentAgencyEntities()
            : base("name=EmploymentAgencyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ActivityType> ActivityTypes { get; set; }
        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<Deal> Deals { get; set; }
        public virtual DbSet<Employer> Employers { get; set; }
        public virtual DbSet<Qualification> Qualifications { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Vacancy> Vacancies { get; set; }
    }
}
