//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Deal
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public int VacancyId { get; set; }
        public int AgentId { get; set; }
        public Nullable<decimal> Comission { get; set; }
        public System.DateTime CompilationDate { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
    
        public virtual Agent Agent { get; set; }
        public virtual Applicant Applicant { get; set; }
        public virtual Vacancy Vacancy { get; set; }
    }
}
