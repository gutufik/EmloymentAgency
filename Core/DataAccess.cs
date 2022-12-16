using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class DataAccess
    {
        public static List<Employer> GetEmployers() => EmploymentAgencyEntities.GetContext().Employers.ToList();
        public static List<ActivityType> GetActivityTypes() => EmploymentAgencyEntities.GetContext().ActivityTypes.ToList();
        public static List<Vacancy> GetVacancies() => EmploymentAgencyEntities.GetContext().Vacancies.ToList();
        public static List<Deal> GetDeals() => EmploymentAgencyEntities.GetContext().Deals.ToList();
        public static List<Agent> GetAgents() => EmploymentAgencyEntities.GetContext().Agents.ToList();
        public static List<Applicant> GetApplicants() => EmploymentAgencyEntities.GetContext().Applicants.ToList();
        public static List<Qualification> GetQualifications() => EmploymentAgencyEntities.GetContext().Qualifications.ToList();

        public static void SaveEmployer(Employer employer)
        {
            if (employer.Id == 0)
                EmploymentAgencyEntities.GetContext().Employers.Add(employer);
            EmploymentAgencyEntities.GetContext().SaveChanges();
        }
        public static void SaveApplicant(Applicant applicant)
        {
            if (applicant.Id == 0)
                EmploymentAgencyEntities.GetContext().Applicants.Add(applicant);
            EmploymentAgencyEntities.GetContext().SaveChanges();
        }
        public static void SaveVacancy(Vacancy vacancy)
        {
            if (vacancy.Id == 0)
                EmploymentAgencyEntities.GetContext().Vacancies.Add(vacancy);
            EmploymentAgencyEntities.GetContext().SaveChanges();
        }
        public static void SaveDeal(Deal deal)
        {
            if (deal.Id == 0)
                EmploymentAgencyEntities.GetContext().Deals.Add(deal);
            EmploymentAgencyEntities.GetContext().SaveChanges();
        }
    }
}
