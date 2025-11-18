//#if(AddObjectDataSourceProvider && (add-document-viewer || add-designer)) {
using DevExpress.DataAccess.Web;
using System;
using System.Collections.Generic;

namespace DevExpressProjectTemplate.Services {
    public class ObjectDataSourceWizardCustomTypeProvider : IObjectDataSourceWizardTypeProvider {
        public IEnumerable<Type> GetAvailableTypes(string context) {
            return new[] { typeof(Employees.DataSource) };
        }
    }
}
//#endif