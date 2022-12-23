using System;
using System.Collections.Generic;
using System.Linq;
using Spire.Doc;
using Spire.Doc.Documents;
using System.IO;
using Spire.Doc.Fields;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Diagnostics.Contracts;
using System.Reflection;

namespace Core
{
    public static class ReportService
    {
        public static void ExportToWord(Deal deal) 
        {
            Document doc = new Document();
            doc.LoadFromFile(@"..\..\Resources\Template.docx");
            doc.Replace("Applicant.LastName", deal.Applicant.LastName, true, true);
            doc.Replace("Applicant.FirstName", deal.Applicant.FirstName, true, true);

            doc.Replace("Vacancy.Name", deal.Vacancy.Name, true, true);
            doc.Replace("Employer.Name", deal.Vacancy.Employer.Name, true, true);
            doc.Replace("Agent.Name", $"{deal.Agent.LastName} {deal.Agent.FirstName[0]}.{deal.Agent.Patronymic[0]}.", true, true);
            doc.Replace("Deal.CompilationDate", deal.CompilationDate.ToString("dd.MM.yyyy"), true, true);

            doc.SaveToFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $@"\Договор .docx", FileFormat.Docx);

        }
    }
}
