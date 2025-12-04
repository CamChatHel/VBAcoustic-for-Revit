using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace VBAcousticPlugin
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class GetGUID 
    {
        public ElementId Execute(Document doc, ExternalCommandData commandData)
        {
            var uiapp = commandData.Application;
            var uidoc = uiapp.ActiveUIDocument;
            
            //var elementID = uidoc.Selection.GetElementIds().FirstOrDefault().ToString(); //falsche ID, Revit ID und nicht IFC GUID
            var element = uidoc.Selection.GetElementIds().Select(x => doc.GetElement(x)).First();

            // geht nicht
            //var elementId = element.get_Parameter(BuiltInParameter.IFC_GUID).AsString();
            // var selectElement1 = doc.GetElement(elementId); 

            var elementId2 = element.Id; // geht nicht, wenn in string konvertiert
            var selectElement2 = doc.GetElement(elementId2); //geht
           

            //TaskDialog.Show("Message", elementID);
            return elementId2;
        }

        
    }
}
