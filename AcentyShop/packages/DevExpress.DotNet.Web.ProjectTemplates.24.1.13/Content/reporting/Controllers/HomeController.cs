//#if(add-data-source) {
using System.Collections.Generic;
using DevExpress.DataAccess.Sql;
//#endif
//#if(add-designer) {
using DevExpress.XtraReports.Web.ReportDesigner.Services;
//#endif
//#if(add-viewer) {
using DevExpress.XtraReports.Web.WebDocumentViewer;
//#endif
using Microsoft.AspNetCore.Mvc;

namespace DevExpressProjectTemplate.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }
        public IActionResult Error() {
            Models.ErrorModel model = new Models.ErrorModel();
            return View(model);
        }
        
//#if(add-designer) {
        public IActionResult ReportDesigner(
            [FromServices] IReportDesignerModelBuilder reportDesignerModelBuilder, 
            [FromQuery] string reportName) {
//#if(add-data-source) {
            // Create a SQL data source with the specified connection string.
            SqlDataSource ds = new SqlDataSource("NWindConnectionString");
            // Create a SQL query to access the Products data table.
            SelectQuery query = SelectQueryFluentBuilder.AddTable("Products").SelectAllColumnsFromTable().Build("Products");
            ds.Queries.Add(query);
            ds.RebuildResultSchema();
//#endif

            reportName = string.IsNullOrEmpty(reportName) ? "TestReport" : reportName;
            var designerModel = reportDesignerModelBuilder
                .Report(reportName)
//#if(add-data-source) {
                .DataSources(x => {
                    x.Add("Northwind", ds);
                })
//#endif
                .BuildModel();
            return View(designerModel);
        }
//#endif

//#if(add-viewer) {
        public IActionResult DocumentViewer(
            [FromServices] IWebDocumentViewerClientSideModelGenerator viewerModelGenerator,
            [FromQuery] string reportName) {
            reportName = string.IsNullOrEmpty(reportName) ? "TestReport" : reportName;
            var viewerModel = viewerModelGenerator.GetModel(reportName, CustomWebDocumentViewerController.DefaultUri);
            return View(viewerModel);
        }
//#endif
    }
}
