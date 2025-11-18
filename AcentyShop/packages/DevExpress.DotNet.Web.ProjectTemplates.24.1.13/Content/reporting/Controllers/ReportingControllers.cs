//#if(add-designer) {
using DevExpress.AspNetCore.Reporting.QueryBuilder;
using DevExpress.AspNetCore.Reporting.QueryBuilder.Native.Services;
using DevExpress.AspNetCore.Reporting.ReportDesigner;
using DevExpress.AspNetCore.Reporting.ReportDesigner.Native.Services;
//#endif
//#if(add-designer || add-viewer) {
using DevExpress.AspNetCore.Reporting.WebDocumentViewer;
using DevExpress.AspNetCore.Reporting.WebDocumentViewer.Native.Services;

namespace  DevExpressProjectTemplate.Controllers {
//#endif
//#if(add-designer) {
    public class CustomReportDesignerController : ReportDesignerController {
        public CustomReportDesignerController(IReportDesignerMvcControllerService controllerService) : base(controllerService) {
        }
    }

    public class CustomQueryBuilderController : QueryBuilderController {
        public CustomQueryBuilderController(IQueryBuilderMvcControllerService controllerService) : base(controllerService) {
        }
    }
//#endif

//#if(add-designer || add-viewer) {
    public class CustomWebDocumentViewerController : WebDocumentViewerController {
        public CustomWebDocumentViewerController(IWebDocumentViewerMvcControllerService controllerService) : base(controllerService) {
        }
    }
}
//#endif