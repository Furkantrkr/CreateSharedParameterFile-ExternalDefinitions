using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;

namespace SharedParameterCommands.Extensions
{
    public static class ApplicationExtensions
    {
        public static DefinitionFile CreateSharedParameterFile(this Application application, string path)
        {
            if (application == null) throw new ArgumentNullException(nameof(application));
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (File.Exists(path))
                return application.OpenSharedParameterFile();

            using (File.Create(path))
            {
                application.SharedParametersFilename = path;
            }
            return application.OpenSharedParameterFile();
        }
    }
}
