using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBAcousticPlugin
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class GetRevitName
    {
        public string RevitName;
        public string RevitCategory;

        public GetRevitName(Document doc, ExternalCommandData commandData, Element element)
        {
            Execute(doc, commandData, element);
        }

        private void Execute(Document doc, ExternalCommandData commandData, Element revitElement)
        {
            var uiapp = commandData.Application;
            var uidoc = uiapp.ActiveUIDocument;
            
            RevitCategory = revitElement.Category.Name;
            RevitName = revitElement.Name;

            
        }
    }
}
