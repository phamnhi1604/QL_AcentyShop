//#if(add-designer) {
using DevExpress.DataAccess.Web;

namespace DevExpressProjectTemplate.Services {
    public class ObjectDataSourceWizardCustomTypeProvider : IObjectDataSourceWizardTypeProvider {
        public IEnumerable<Type> GetAvailableTypes(string context) {
            return new[] { typeof(Data.DataItemList) };
        }
    }
}
//#endif