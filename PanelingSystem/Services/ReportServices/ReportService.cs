using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using PanelingSystem.Models;
using System.Reflection;

namespace PanelingSystem.Services.ReportServices
{
    public class ReportService : ControllerBase, IReportService
    {
        public IActionResult GetMasterListReport([FromBody] List<ReportModel> scheds)
        {
            scheds.Add(new());
            using var rs = Assembly.GetExecutingAssembly().GetManifestResourceStream("PanelingSystem.Reports.Masterlistreport.rdlc");
            LocalReport report = new();
            report.LoadReportDefinition(rs);
            report.DataSources.Add(new ReportDataSource("scheduledataset", scheds));

            return File(report.Render("PDF"), "application/pdf", "report." + "pdf");
        }
    }
}
