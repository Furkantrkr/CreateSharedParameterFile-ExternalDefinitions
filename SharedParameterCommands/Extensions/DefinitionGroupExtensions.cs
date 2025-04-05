using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace SharedParameterCommands.Extensions
{
    public static class DefinitionGroupExtensions
    {
        public static ExternalDefinition CreateExternalDefinition
            (this DefinitionGroup definitionGroup,
             string definitionName,
             ForgeTypeId parameterType
            )
        {
            if (definitionGroup == null) throw new ArgumentNullException(nameof(definitionGroup));
            if (definitionName == null) throw new ArgumentNullException(nameof(definitionName));
            if(definitionGroup.ContainDefinition(definitionName))
                throw new ArgumentException( $"{definitionGroup.Name} group already contains definition {definitionName}");

            return definitionGroup.Definitions.Create(new ExternalDefinitionCreationOptions(definitionName, parameterType)) as ExternalDefinition;
        }

        public static List<ExternalDefinition> CreateExternalDefinitions
            (this DefinitionGroup definitionGroup, 
             List<IDefinitionConfig> definitionConfigs
            )
        {
            if(definitionGroup == null) throw new ArgumentNullException(nameof(definitionGroup));
            if(definitionConfigs == null) throw new ArgumentNullException(nameof(definitionConfigs));
            return definitionConfigs
                .Select(c => definitionGroup.CreateExternalDefinition(c.Name,c.ParameterType))
                .ToList();
        }

        public static bool ContainDefinition
            (this DefinitionGroup definitionGroup, 
            string definitionName)
        {
            if( definitionGroup == null ) throw new ArgumentNullException (nameof (definitionGroup));
            if( definitionName == null ) throw new ArgumentNullException (nameof (definitionName));
            if (definitionGroup.Definitions.get_Item(definitionName) != null) return true;
            else return false;
        }
    }
}
