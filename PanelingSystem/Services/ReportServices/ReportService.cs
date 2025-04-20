using MetadataExtractor.Formats.Xmp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using PanelingSystem.Models;
using System.Reflection;
using PanelingSystem.Commons;

namespace PanelingSystem.Services.ReportServices
{
    public class ReportService : ControllerBase, IReportService
    {
        public IActionResult GetGradeSheetReport(List<GradeSheetModel> grades, Enums.FilePosition DefenseType)
        {
            using var rs = Assembly.GetExecutingAssembly().GetManifestResourceStream("PanelingSystem.Reports.GradeSheetReport.rdlc");
            LocalReport report = new();
            report.LoadReportDefinition(rs);
            report.DataSources.Add(new ReportDataSource("gradesheetdataset", grades));
            report.SetParameters(new[]
            {
                new ReportParameter("Type", Extensions.GetEnumDescription(DefenseType))
            });

            return File(report.Render("PDF"), "application/pdf", "report." + "pdf");
        }

        public IActionResult GetMasterListReport(List<ReportModel> scheds)
        {
            using var rs = Assembly.GetExecutingAssembly().GetManifestResourceStream("PanelingSystem.Reports.Masterlistreport.rdlc");
            LocalReport report = new();
            report.LoadReportDefinition(rs);
            report.DataSources.Add(new ReportDataSource("scheduledataset", scheds));

            return File(report.Render("PDF"), "application/pdf", "report." + "pdf");
        }
    }
}
