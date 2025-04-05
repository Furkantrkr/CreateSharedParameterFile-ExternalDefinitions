using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using SharedParameterCommands.Enums;

namespace SharedParameterCommands.Extensions
{
    public static class DefinitionConfigExtensions
    {
        public static void TryAddToDocuments
            (this IEnumerable<IDefinitionConfig> definitionConfigs,
            Document document,
            List<BuiltInCategory> builtInCategories,
            BindingKind bindingKind = BindingKind.Instance
            )
        {
            if (definitionConfigs == null) throw new ArgumentNullException(nameof(definitionConfigs));
            if (builtInCategories == null) throw new ArgumentException(nameof(builtInCategories));
            if (document == null) throw new ArgumentNullException(nameof(document));

            BindingMap bindingMap = document.ParameterBindings;
            DefinitionFile definitionFile = document.Application.OpenSharedParameterFile();

            foreach (DefinitionConfig definitionConfig in definitionConfigs)
            {
                Definition definition = definitionFile?.Groups
                                        .Cast<DefinitionGroup>()
                                        .SelectMany(g => g.Definitions.Cast<Definition>())
                                        .FirstOrDefault(d => d.Name == definitionConfig.Name);
                if(definition is ExternalDefinition externalDefinition && !bindingMap.Contains(definition))
                {
                    Binding binding = document.CreateBinding(builtInCategories, definitionConfig.BindingKind);
                    bindingMap.Insert(externalDefinition,binding, definitionConfig.GroupTypeId);
                }
            }

        }
    }
}
