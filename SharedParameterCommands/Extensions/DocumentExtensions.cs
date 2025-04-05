using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using SharedParameterCommands.Enums;

namespace SharedParameterCommands.Extensions
{
    public static class DocumentExtensions
    {
        public static void Run(this Document document, Action doAction, string transactionName = "Default transaction name")
        {
            Transaction transaction = new Transaction(document, transactionName);
            using (transaction)
            {
                transaction.Start();
                doAction.Invoke();
                transaction.Commit();
            }
        }

        public static Binding CreateBinding(this Document document, List<BuiltInCategory> builtInCategories, BindingKind bindingKind)
        {
            if (document == null) throw new ArgumentNullException(nameof(document));
            if (builtInCategories == null) throw new ArgumentException(nameof(builtInCategories));

            CategorySet categorySet = new CategorySet();
            builtInCategories.ForEach(b => categorySet.Insert(Category.GetCategory(document, b)));
            if (bindingKind is BindingKind.Instance) return new InstanceBinding(categorySet);
            return new TypeBinding(categorySet);
        }
    }
}
