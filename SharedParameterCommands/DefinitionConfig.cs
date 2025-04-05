using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using SharedParameterCommands.Enums;
using SharedParameterCommands.Extensions;

namespace SharedParameterCommands
{
    public class DefinitionConfig : IDefinitionConfig
    {
        public string Name { get; private set; }
        public ForgeTypeId ParameterType { get; private set; }
        public ForgeTypeId GroupTypeId { get; private set; }
        public BindingKind BindingKind { get; private set; }
        public DefinitionConfig(string definitionName,ForgeTypeId parameterType, ForgeTypeId groupTypeId, BindingKind bindingKind ) {
            this.Name = definitionName;
            this.ParameterType = parameterType;
            this.GroupTypeId = groupTypeId;
            this.BindingKind = bindingKind;
        }

    }
}
