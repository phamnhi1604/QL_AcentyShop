using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using DevExpress.AspNetCore;
using DevExpress.AspNetCore.Reporting;
using DevExpress.Security.Resources;
using DevExpress.XtraReports.Web.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DevExpressProjectTemplate.Services;
using DevExpressProjectTemplate.Data;
//#if(DocumentStorage == "FileStorage" || DocumentStorage == "AzureStorage" || DocumentStorage == "XPOStorage")
using DevExpress.XtraReports.Web.WebDocumentViewer;
//#endif
//#if(DocumentStorage == "AzureStorage")
using DevExpress.AspNetCore.Reporting.Azure;
//#endif

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDevExpressControls();
builder.Services.AddScoped<ReportStorageWebExtension, CustomReportStorageWebExtension>();
builder.Services.AddMvc();
//#if(DocumentStorage == "DistributedCache")
builder.Services.AddDistributedMemoryCache();
//#endif
builder.Services.ConfigureReportingServices(configurator => {
    if(builder.Environment.IsDevelopment()) {
        configurator.UseDevelopmentMode();
    }
    configurator.ConfigureReportDesigner(designerConfigurator => {
//#if(add-data-source)
        designerConfigurator.RegisterDataSourceWizardConnectionStringsProvider<CustomSqlDataSourceWizardConnectionStringsProvider>();
//#endif
//#if(AddJsonDataSourceService)
        designerConfigurator.RegisterDataSourceWizardJsonConnectionStorage<CustomDataSourceWizardJsonDataConnectionStorage>(true);
//#endif
//#if(AddObjectDataSourceProvider)
        designerConfigurator.RegisterObjectDataSourceWizardTypeProvider<ObjectDataSourceWizardCustomTypeProvider>();
//#endif
    });
    configurator.ConfigureWebDocumentViewer(viewerConfigurator => {
        viewerConfigurator.UseCachedReportSourceBuilder();
//#if(AddJsonDataSourceService)
        viewerConfigurator.RegisterJsonDataConnectionProviderFactory<CustomJsonDataConnectionProviderFactory>();
//#endif
        viewerConfigurator.RegisterConnectionProviderFactory<CustomSqlDataConnectionProviderFactory>();
//#if(DocumentStorage=="FileStorage")
        viewerConfigurator.UseFileDocumentStorage(Path.Combine(builder.Environment.ContentRootPath, "ReportDocuments"), StorageSynchronizationMode.InterProcess);
        viewerConfigurator.UseFileReportStorage(Path.Combine(builder.Environment.ContentRootPath, "PreviewedReports"), StorageSynchronizationMode.InterProcess);
        viewerConfigurator.UseFileExportedDocumentStorage(Path.Combine(builder.Environment.ContentRootPath, "ExportedDocuments"), StorageSynchronizationMode.InterProcess);
//#endif
//#if(DocumentStorage == "DistributedCache")
        viewerConfigurator.UseDistributedCache();
//#endif
//#if(DocumentStorage == "XPOStorage")
        viewerConfigurator.UseDbStorage(builder.Configuration.GetConnectionString("DocumentViewerStorageConnectionString"));
//#endif
//#if(DocumentStorage == "AzureStorage")
        viewerConfigurator.UseAzureCachedReportSourceBuilder(builder.Configuration.GetConnectionString("AzureStorageConnectionString"), StorageSynchronizationMode.InterThread);
//#endif
    });
});
builder.Services.AddDbContext<ReportDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("ReportsDataConnectionString")));

var app = builder.Build();
using(var scope = app.Services.CreateScope()) {
    var services = scope.ServiceProvider;
    services.GetService<ReportDbContext>().InitializeDatabase();
//#if(DocumentStorage == "XPOStorage")
    services.GetRequiredService<IStorageDbInitializer>().InitDbSchema();
//#endif
}
var contentDirectoryAllowRule = DirectoryAccessRule.Allow(new DirectoryInfo(Path.Combine(builder.Environment.ContentRootPath, "Content")).FullName);
AccessSettings.ReportingSpecificResources.TrySetRules(contentDirectoryAllowRule, UrlAccessRule.Allow());
//#if(add-designer)
DevExpress.XtraReports.Configuration.Settings.Default.UserDesignerOptions.DataBindingMode = DevExpress.XtraReports.UI.DataBindingMode.Expressions;
//#endif
app.UseDevExpressControls();
System.Net.ServicePointManager.SecurityProtocol |= System.Net.SecurityProtocolType.Tls12;
if(app.Environment.IsDevelopment()) {
    app.UseDeveloperExceptionPage();
} else {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

//#if(AddObjectDataSourceProvider)
DevExpress.Utils.DeserializationSettings.RegisterTrustedClass(typeof(DevExpressProjectTemplate.Employees.DataSource));
//#endif

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();