using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace VBAcousticPlugin
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class GetElementGeometry
    {
        
        public double[] Execute(Document doc, ExternalCommandData commandData)
        {
            var uiapp = commandData.Application;
            var uidoc = uiapp.ActiveUIDocument;
            var element = uidoc.Selection.GetElementIds().Select(x => doc.GetElement(x)).First();

            double length;
            double lengthA = 0;
            double lengthB = 0;
            //create Geometry option
            Options opt = new Options();
            GeometryElement geomElement = element.get_Geometry(opt);

            List<double> listAllEdgeLengths = new List<double>();
            List<double> listEdgeLengths = new List<double>();

            foreach (GeometryObject geomObject in geomElement)
            {
                Solid geomSolid = geomObject as Solid;
                if (null != geomSolid)
                {
                    foreach (Edge geomEdge in geomSolid.Edges)
                    {
                        listAllEdgeLengths.Add(geomEdge.ApproximateLength);

                    }

                }

            }

            listEdgeLengths= listAllEdgeLengths.Distinct().ToList();
            listEdgeLengths.Sort();
            int iA = listEdgeLengths.Count() - 1;
            int iB = listEdgeLengths.Count() - 2;
            lengthA = listEdgeLengths[iA];
            lengthB = listEdgeLengths[iB];

            double[] lengths = { Math.Round(lengthA * 304.8, 2), Math.Round(lengthB * 304.8, 2) };  //*304.8 Parameters in Revit are saved in inch and feet!

            return lengths;
        }

    }
}
