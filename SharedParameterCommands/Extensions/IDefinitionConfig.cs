using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using SharedParameterCommands.Enums;

namespace SharedParameterCommands.Extensions
{
    public interface IDefinitionConfig
    {
        string Name { get; }
        ForgeTypeId ParameterType { get; }
        ForgeTypeId GroupTypeId { get; }

        BindingKind BindingKind { get; }
    }
}
