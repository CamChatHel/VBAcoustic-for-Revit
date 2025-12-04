using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Autodesk.Revit.DB;
using Newtonsoft.Json;
using static VBAcousticPlugin.ConvertToJsonString;

namespace VBAcousticPlugin
{
    public class JunctionBuilder
    {
        /// <summary>
        /// Create junction with attributes to connect AllBuildingElements in the junction with tranmission paths
        /// </summary>
        /// <param name="CommonLength"></param>
        /// <param name="TypeOfJunction"></param>
        /// /// <param name="TypeOfFastener"></param>
        /// <returns>IfcWall</returns>
        /// 

        public Guid GlobalId { get; set; }
        public string SeparatingElementID { get; set; }
        public double? CommonLength { get; set; }
        public string TypeOfJunction { get; set; }
        public string TypeOfFastener { get; set; }


        

        public BuildingElement[] BuildingElements { get; set; } = new BuildingElement[4];
        
        public List<TransmissionPath> RelatedPaths { get; set; } = new List<TransmissionPath>();

        [JsonIgnore]
        public BuildingElement[] AllBuildingElements { get; set; } = new BuildingElement[5];

        public JunctionBuilder()
        {
            GlobalId = Guid.NewGuid();
        }




        public class BuildingElement
        {

            public string ElementID { get; set; }

            [JsonIgnore]
            public string ElementRevitId { get; set; }

            public string ElementName { get; set; }
            public string ElementMaterial { get; set; }
            public string Covering1ID { get; set; }
            public string Covering1Material { get; set; }
            public string Covering2ID { get; set; }
            public string Covering2Material { get; set; }


        }


        public class TransmissionPath //: IEquatable<TransmissionPath>
        {
            
            public TransmissionPath()
            {
                GlobalId = Guid.NewGuid();
            }

            public Guid GlobalId { get; set; }

            public PathsName? Name;

            public string Is_i { get; set; }
            public string Is_j { get; set; }

            //public RelAssociatesPaths IsDecomposedBy { get; set; }

            //public IItemSet<IfcRelDefinesByProperties> IsDefinedBy { get; }

            public enum PathsName
            {
                Df,
                Fd,
                Ff,
                DFf,
                Other
            }
        }


        public void SaveBuildingElements()
        {
            BuildingElements[0] = AllBuildingElements[1];
            BuildingElements[1] = AllBuildingElements[2];
            BuildingElements[2] = AllBuildingElements[3];
            BuildingElements[3] = AllBuildingElements[4];
        }

        public void AddPaths(TransmissionPath path)
        {
            RelatedPaths.Add(path);
        }

        public void CreatePaths(string JunctionType)
        {
            TypeOfJunction = TypeOfJunction;
            TransmissionPath pathDf = new TransmissionPath();
            TransmissionPath pathFd = new TransmissionPath();
            TransmissionPath pathFf = new TransmissionPath();

            if (JunctionType == "Lh1-2" || JunctionType == "Lv1-2")
            {
                if (SeparatingElementID == AllBuildingElements[1].ElementID)
                {
                    pathDf.Is_i = AllBuildingElements[1].ElementID;
                    pathDf.Is_j = AllBuildingElements[2].ElementID;
                    pathFd.Is_i = AllBuildingElements[2].ElementID;
                    pathFd.Is_j = AllBuildingElements[1].ElementID;
                }
                else
                {
                    pathDf.Is_i = AllBuildingElements[2].ElementID;
                    pathDf.Is_j = AllBuildingElements[1].ElementID;
                    pathFd.Is_i = AllBuildingElements[2].ElementID;
                    pathFd.Is_j = AllBuildingElements[1].ElementID;
                }

            }
            
            else if (JunctionType == "Tv1-24" || JunctionType == "Th1-24")
            {
                if (SeparatingElementID == AllBuildingElements[1].ElementID)
                {
                    pathDf.Is_i = AllBuildingElements[1].ElementID;
                    pathDf.Is_j = AllBuildingElements[2].ElementID;
                    pathFd.Is_i = AllBuildingElements[4].ElementID;
                    pathFd.Is_j = AllBuildingElements[1].ElementID;
                    pathFf.Is_i = AllBuildingElements[2].ElementID;
                    pathFf.Is_i = AllBuildingElements[4].ElementID;
                }
                else 
                {
                    pathDf.Is_i = AllBuildingElements[2].ElementID;
                    pathDf.Is_j = AllBuildingElements[1].ElementID;
                    pathFd.Is_i = AllBuildingElements[1].ElementID;
                    pathFd.Is_j = AllBuildingElements[2].ElementID;
                    pathFf.Is_i = AllBuildingElements[1].ElementID;
                    pathFf.Is_i = AllBuildingElements[4].ElementID;
                }
            }
            else if (JunctionType == "Tv2-13" || JunctionType == "Tv2-1:3")
            {
                if (SeparatingElementID == AllBuildingElements[2].ElementID)
                {
                    pathDf.Is_i = AllBuildingElements[2].ElementID;
                    pathDf.Is_j = AllBuildingElements[1].ElementID;
                    pathFd.Is_i = AllBuildingElements[3].ElementID;
                    pathFd.Is_j = AllBuildingElements[2].ElementID;
                    pathFf.Is_i = AllBuildingElements[1].ElementID;
                    pathFf.Is_i = AllBuildingElements[3].ElementID;
                }
                else
                {
                    pathDf.Is_i = AllBuildingElements[1].ElementID;
                    pathDf.Is_j = AllBuildingElements[2].ElementID;
                    pathFd.Is_i = AllBuildingElements[2].ElementID;
                    pathFd.Is_j = AllBuildingElements[1].ElementID;
                    pathFf.Is_i = AllBuildingElements[2].ElementID;
                    pathFf.Is_i = AllBuildingElements[3].ElementID;
                }
            }
            else if (JunctionType == "Th2-1-4" || JunctionType == "Tv2-1-4" || JunctionType == "Th1-2:4" || JunctionType == "Tv1-2:4")
            {
                if (SeparatingElementID == AllBuildingElements[1].ElementID)
                {
                    pathDf.Is_i = AllBuildingElements[1].ElementID;
                    pathDf.Is_j = AllBuildingElements[2].ElementID;
                    pathFd.Is_i = AllBuildingElements[4].ElementID;
                    pathFd.Is_j = AllBuildingElements[1].ElementID;
                    pathFf.Is_i = AllBuildingElements[2].ElementID;
                    pathFf.Is_i = AllBuildingElements[4].ElementID;
                }
                else
                {
                    pathDf.Is_i = AllBuildingElements[2].ElementID;
                    pathDf.Is_j = AllBuildingElements[1].ElementID;
                    pathFd.Is_i = AllBuildingElements[1].ElementID;
                    pathFd.Is_j = AllBuildingElements[2].ElementID;
                    pathFf.Is_i = AllBuildingElements[1].ElementID;
                    pathFf.Is_i = AllBuildingElements[4].ElementID;
                }
            }
            else if (JunctionType == "Xh1-24-3" || JunctionType == "Xv2-13-4" || JunctionType == "Xv1-24-3" 
                     || JunctionType == "Xh2-1:3-4" || JunctionType == "Xv2-1:3-4" || JunctionType == "Xh1-24-3")
            {
                if (SeparatingElementID == AllBuildingElements[1].ElementID)
                {
                    pathDf.Is_i = AllBuildingElements[1].ElementID;
                    pathDf.Is_j = AllBuildingElements[2].ElementID;
                    pathFd.Is_i = AllBuildingElements[4].ElementID;
                    pathFd.Is_j = AllBuildingElements[1].ElementID;
                    pathFf.Is_i = AllBuildingElements[2].ElementID;
                    pathFf.Is_i = AllBuildingElements[4].ElementID;
                }
                else
                {
                    pathDf.Is_i = AllBuildingElements[2].ElementID;
                    pathDf.Is_j = AllBuildingElements[3].ElementID;
                    pathFd.Is_i = AllBuildingElements[1].ElementID;
                    pathFd.Is_j = AllBuildingElements[2].ElementID;
                    pathFf.Is_i = AllBuildingElements[1].ElementID;
                    pathFf.Is_i = AllBuildingElements[3].ElementID;
                }
            }

            pathDf.Name = TransmissionPath.PathsName.Df;
            pathFd.Name = TransmissionPath.PathsName.Fd;
            pathFf.Name = TransmissionPath.PathsName.Ff;
            AddPaths(pathDf);
            AddPaths(pathFd);
            AddPaths(pathFf);
        }
    }
}
