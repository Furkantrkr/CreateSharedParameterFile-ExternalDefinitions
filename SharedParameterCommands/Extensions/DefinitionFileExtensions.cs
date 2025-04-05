using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace SharedParameterCommands.Extensions
{
    public static class DefinitionFileExtensions
    {
        public static DefinitionGroup CreateGroup(
            this DefinitionFile definitionFile, string groupName)
        {
            if (definitionFile == null) throw new ArgumentNullException( nameof(definitionFile) );
            if (groupName == null) throw new ArgumentNullException(nameof(groupName));
            if (definitionFile.GroupExist(groupName))
                throw new ArgumentException($"The {groupName} already exists");
            return definitionFile.Groups.Create(groupName); 
        }

        public static bool GroupExist(
            this DefinitionFile definitionFile, string groupName)
        {
            if(definitionFile == null) throw new ArgumentNullException(nameof(definitionFile));
            if (groupName == null) throw new ArgumentNullException(nameof(groupName));
            return definitionFile.Groups.get_Item(groupName) != null;
        }
    }
}
