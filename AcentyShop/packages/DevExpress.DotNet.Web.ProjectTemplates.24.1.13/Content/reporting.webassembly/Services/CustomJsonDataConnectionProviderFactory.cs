//#if(RegisterJsonDataSource && (add-document-viewer || add-designer)) {
using DevExpress.DataAccess.Json;
using DevExpress.DataAccess.Web;
namespace DevExpressProjectTemplate.Services
{
    public class CustomJsonDataConnectionProviderFactory : IJsonDataConnectionProviderFactory {
        public IJsonDataConnectionProviderService Create() {
            return new WebDocumentViewerJsonDataConnectionProvider(CustomDataSourceWizardJsonDataConnectionStorage.GetConnections());
        }
    }

    public class WebDocumentViewerJsonDataConnectionProvider : IJsonDataConnectionProviderService
    {
        readonly List<JsonDataConnection> jsonDataConnections;
        public WebDocumentViewerJsonDataConnectionProvider(List<JsonDataConnection> jsonDataConnections) {
            this.jsonDataConnections = jsonDataConnections;
        }
        public JsonDataConnection GetJsonDataConnection(string name) {
            var connection = jsonDataConnections.FirstOrDefault(x => x.Name == name);
            if(connection == null)
                throw new InvalidOperationException();
            return connection;
        }
    }
}
//#endif