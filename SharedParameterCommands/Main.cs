using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using SharedParameterCommands.Enums;
using SharedParameterCommands.Extensions;

namespace SharedParameterCommands
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData externalCommandData, ref string message, ElementSet elements)
        {
            // creatred a new development branch
            UIApplication uIApplication = externalCommandData.Application;
            Application application = uIApplication.Application;
            UIDocument uiDocument = uIApplication.ActiveUIDocument;
            Document document = uiDocument.Document;
            string path = @"C:\Users\FurkanTurker\Desktop\FT\REVIT API\YT\MARIYAN DEVELOPER\05 - Create Extension Methods\SharedParameterCommands\shared.txt";

            List<IDefinitionConfig> definitionConfigs = new List<IDefinitionConfig>()
            {
                new DefinitionConfig("Length", SpecTypeId.Length, GroupTypeId.IdentityData, BindingKind.Type),
                new DefinitionConfig("Angle", SpecTypeId.Angle, GroupTypeId.IdentityData, BindingKind.Instance)
            };


            string groupName = "MyFirstGroup";
            List<BuiltInCategory> builtInCategories = new List<BuiltInCategory>()
            {
                BuiltInCategory.OST_Walls,
                BuiltInCategory.OST_Floors
            };

            document.Run(() =>
            {
                application
                    .CreateSharedParameterFile(path)
                    .CreateGroup(groupName)
                    .CreateExternalDefinitions(definitionConfigs);

                definitionConfigs.TryAddToDocuments(document, builtInCategories);
            },
            "Add shared parameters to document");

            return Result.Succeeded;
        }
    }
}
