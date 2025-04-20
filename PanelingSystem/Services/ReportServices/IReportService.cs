using Microsoft.AspNetCore.Mvc;
using PanelingSystem.Models;

namespace PanelingSystem.Services.ReportServices
{
    public interface IReportService
    {
        IActionResult GetMasterListReport(List<ReportModel> scheds);
        IActionResult GetGradeSheetReport(List<GradeSheetModel> grades, Enums.FilePosition DefenseType);
    }
}
