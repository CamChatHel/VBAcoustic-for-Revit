using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Autodesk.Revit.DB.Mechanical;

namespace VBAcousticPlugin
{
    public class junctionTypesEnumerations
    {

        /// <summary>
        /// Enumeration with all different junction types possible in timber construction
        /// Will be loaded in WPF in the comboboxes
        /// </summary>
        
        public List<string> JunctionTypeList; //dash = Bindestrich, colon = Doppelpunkt

        public junctionTypesEnumerations()
        {
            var myList = new List<string>();
            myList.Add("Lh1-2");
            myList.Add("Lv1-2");
            myList.Add("Tv1-24");
            myList.Add("Tv2-13");
            myList.Add("Th1-24");
            
            myList.Add("Th2-1-4");
            myList.Add("Tv2-1-4");
            ;
            myList.Add("Th1-2:4");
            myList.Add("Tv1-2:4");
            myList.Add("Tv2-1:3");
            myList.Add("Xh1-24-3");
            myList.Add("Xv2-13-4");
            myList.Add("Xv1-24-3");
            myList.Add("Xh2-1:3-4");
            myList.Add("Xv2-1:3-4");
            myList.Add("JunctionTypeError");

            JunctionTypeList = myList;

        }


    }

    
}
