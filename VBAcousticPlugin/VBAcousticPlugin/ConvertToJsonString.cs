using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace VBAcousticPlugin
{
    public class ConvertToJsonString
    {
        private List<BuildingElementJSON> elements { get; set; } = new List<BuildingElementJSON>();
        private List<JsonJunction> junctions { get; set; } = new List<JsonJunction>();

        public JsonElementwithAllJunctions allInfos { get; set; }


        public ConvertToJsonString(List<JunctionBuilder> allJunctions)
        {

        }


        public JsonElementwithAllJunctions GetJsonString()
        {
            return allInfos;
        }



        public class JsonJunction
        {

            public string ID { get; set; }

            public string SeparatingElementID { get; set; }
            public double? CommonLength { get; set; }
            public string TypeOfJunction { get; set; }
            public string TypeOfFastener { get; set; }

            public List<BuildingElementJSON> BuildingElementsID { get; set; } = new List<BuildingElementJSON>();

            public List<TransmissionPathJSON> TransmissionPaths { get; set; } = new List<TransmissionPathJSON>();

        }

        public class JsonElementwithAllJunctions
        {
            public string Name { get; set; }
            public List<JsonJunction> AllJunctions { get; set; }

        }

        public class TransmissionPathJSON
        {

            public string GlobalId { get; set; }

            public string pathName;

            public string Is_i { get; set; }
            public string Is_j { get; set; }



        }

        public class BuildingElementJSON
        {

            public string ElementID { get; set; }

            public string ElementName { get; set; }
            public string ElementMaterial { get; set; }
            public string Covering1ID { get; set; }
            public string Covering1Material { get; set; }
            public string Covering2ID { get; set; }
            public string Covering2Material { get; set; }
        }
    }
}
