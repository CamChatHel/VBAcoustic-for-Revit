using Autodesk.Revit.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Collections;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace VBAcousticPlugin
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class GetRevitMaterials
    {
        public string Materials;

        public GetRevitMaterials(Document doc,  ExternalCommandData commandData, Element element)
        {
            Execute(doc, commandData, element);
        }

        private void Execute(Document doc, ExternalCommandData commandData, Element revitElement)
        {
            var uiapp = commandData.Application;
            var uidoc = uiapp.ActiveUIDocument;

            string materials = "";

            
            if (revitElement is Wall)
            {
                Wall revitWall = (Wall)revitElement;
                CompoundStructure revitWallstructure = revitWall.WallType.GetCompoundStructure();
                var revitWallLayers = revitWallstructure.GetLayers();
                
                foreach (var layer in revitWallLayers)
                {
                    var layerWidth = layer.Width * 304.8; //*304.8 Parameters in Revit are saved in inch and feet!
                    var layerMaterial = uidoc.Document.GetElement(layer.MaterialId).Name;
                    materials = materials + layerMaterial + "_" + layerWidth + ";";
                }
            }
            if (revitElement is Ceiling)
            {
                Ceiling revitSlab = (Ceiling)revitElement;
                var revitSlabType = (CeilingType)uidoc.Document.GetElement(revitSlab.GetTypeId()) ;
                CompoundStructure revitSlabstructure = null ;
                try
                {
                    revitSlabstructure = revitSlabType.GetCompoundStructure();
                    
                }
                catch { }

                if (revitSlabstructure == null)
                {
                    materials = revitSlabType.Name;
                }
                else
                {
                    var revitSlabLayers = revitSlabstructure.GetLayers();
                    foreach (var layer in revitSlabLayers)
                    {
                        var layerWidth = layer.Width * 304.8; //*304.8 Parameters in Revit are saved in inch and feet!
                        var layerMaterial = uidoc.Document.GetElement(layer.MaterialId).Name;
                        materials = materials + layerMaterial + "_" + layerWidth + ";";
                    }
                }
                
            }
            if (revitElement is Floor)
            {
                Floor revitSlab = (Floor)revitElement;
                var revitSlabType = (FloorType)uidoc.Document.GetElement(revitSlab.GetTypeId());
                var revitSlabstructure = revitSlabType.GetCompoundStructure();
                var revitSlabLayers = revitSlabstructure.GetLayers();

                foreach (var layer in revitSlabLayers)
                {
                    var layerWidth = layer.Width * 304.8; //*304.8 Parameters in Revit are saved in inch and feet!
                    var layerMaterial = uidoc.Document.GetElement(layer.MaterialId).Name;
                    materials = materials + layerMaterial + "_" + layerWidth + ";";
                }
            }

            Materials = materials;
            
            
        }

    }
}
