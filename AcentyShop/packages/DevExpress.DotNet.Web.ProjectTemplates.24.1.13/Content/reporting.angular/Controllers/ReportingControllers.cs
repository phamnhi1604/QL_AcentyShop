//#if(add-designer) {
//#if(add-data-source) {
using DevExpress.DataAccess.Sql;
using System.Collections.Generic;
//#endif
using DevExpress.AspNetCore.Reporting.QueryBuilder;
using DevExpress.AspNetCore.Reporting.ReportDesigner;
using DevExpress.AspNetCore.Reporting.ReportDesigner.Native.Services;
using DevExpress.AspNetCore.Reporting.QueryBuilder.Native.Services;
using DevExpress.XtraReports.Web.ReportDesigner;
using DevExpress.XtraReports.Web.ReportDesigner.Services;
//#endif
using DevExpress.AspNetCore.Reporting.WebDocumentViewer;
using DevExpress.AspNetCore.Reporting.WebDocumentViewer.Native.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevExpressProjectTemplate.Controllers {
    public class CustomWebDocumentViewerController : WebDocumentViewerController {
        public CustomWebDocumentViewerController(IWebDocumentViewerMvcControllerService controllerService) : base(controllerService) {
        }
    }
//#if(add-designer) {
    public class CustomReportDesignerController : ReportDesignerController {
        public CustomReportDesignerController(IReportDesignerMvcControllerService controllerService) : base(controllerService) {
        }

        [HttpPost("[action]")]
        public IActionResult GetDesignerModel([FromForm]string reportUrl, [FromServices] IReportDesignerModelBuilder designerModelBuilder, [FromForm] ReportDesignerSettingsBase designerModelSettings) {
//#if(add-data-source) {
            var ds = new SqlDataSource("NWindConnectionString");

            // Create a SQL query to access the Products data table.
            SelectQuery query = SelectQueryFluentBuilder.AddTable("Products").SelectAllColumnsFromTable().Build("Products");
            ds.Queries.Add(query);
            ds.RebuildResultSchema();
//#endif

            var designerModel = designerModelBuilder.Report(reportUrl)
//#if(add-data-source) {
                .DataSources(dataSources => {
                    dataSources.Add("Northwind", ds);
                })
//#endif
                .BuildModel();
           designerModel.Assign(designerModelSettings);
           return DesignerModel(designerModel);
        }
    }

    public class CustomQueryBuilderController : QueryBuilderController {
        public CustomQueryBuilderController(IQueryBuilderMvcControllerService controllerService) : base(controllerService) {
        }
    }
//#endif
}
