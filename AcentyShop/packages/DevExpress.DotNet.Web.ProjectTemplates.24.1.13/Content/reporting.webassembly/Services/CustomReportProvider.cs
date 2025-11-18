//#if(add-document-viewer || add-designer) {
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Services;
using DevExpressProjectTemplate.PredefinedReports;

namespace DevExpressProjectTemplate.Services
{
    public class CustomReportProvider : IReportProviderAsync {
        public Task<XtraReport> GetReportAsync(string id, ReportProviderContext context) {
            return Task.FromResult(ReportsFactory.GetReport(id));
        }
    }
}
//#endif