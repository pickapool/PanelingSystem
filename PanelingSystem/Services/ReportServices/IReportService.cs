using Microsoft.AspNetCore.Mvc;
using PanelingSystem.Models;

namespace PanelingSystem.Services.ReportServices
{
    public interface IReportService
    {
        IActionResult GetMasterListReport([FromBody] List<ReportModel> scheds);    
    }
}
