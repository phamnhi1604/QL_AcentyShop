using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Web;
using DevExpressProjectTemplate;
//#if(add-designer || add-document-viewer) {
using DevExpress.DataAccess.Web;
using DevExpressProjectTemplate.Services;
using DevExpress.XtraReports.Services;
using DevExpress.Blazor.Reporting;
//#endif

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//#if(add-report-viewer) {
builder.Services.AddDevExpressBlazor();
builder.Services.AddDevExpressWebAssemblyBlazorReportViewer();
builder.Services.Configure<DevExpress.Blazor.Configuration.GlobalOptions>(options => {
    options.BootstrapVersion = DevExpress.Blazor.BootstrapVersion.v5;
});
//#endif

//#if(add-designer || add-document-viewer) {
builder.Services.AddDevExpressBlazorReportingWebAssembly(configure => {
    configure.UseDevelopmentMode();
});
//#if(RegisterJsonDataSource) {
builder.Services.AddScoped<IDataSourceWizardJsonConnectionStorage, CustomDataSourceWizardJsonDataConnectionStorage>();
builder.Services.AddScoped<IJsonDataConnectionProviderFactory, CustomJsonDataConnectionProviderFactory>();
//#endif
//#if(add-designer) {
builder.Services.AddScoped<IObjectDataSourceWizardTypeProvider, ObjectDataSourceWizardCustomTypeProvider>();
//#endif
DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(DevExpressProjectTemplate.Data.DataItemList));
builder.Services.AddScoped<IReportProviderAsync, CustomReportProvider>();
//#endif

await builder.Build().RunAsync();