using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Administrator.API.Utilities
{
    public class SwaggerGroupPerVersion : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var namespaceController = controller.ControllerType.Namespace;
            var apiVersion = namespaceController?.Split('.').Last().ToLower();
            controller.ApiExplorer.GroupName = apiVersion;
        }
    }
}
