using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Newtonsoft.Json;
using VBAcousticPlugin.StoreData;
using Control = Autodesk.Revit.DB.Control;
using Label = System.Reflection.Emit.Label;
using MessageBox = System.Windows.MessageBox;
using Visibility = System.Windows.Visibility;

namespace VBAcousticPlugin
{
    /// <summary>
    /// Interaktionslogik für UI.xaml
    /// </summary>
    public partial class UI : Window
    {
        private Document Doc;
        private ExternalCommandData CommandData;
        private UIApplication UiApp;
        private UIDocument UiDoc;

        public UI(Document doc, ExternalCommandData commandData)
        {
            InitializeComponent();
            this.Doc = doc;
            this.CommandData = commandData;
            this.UiApp = commandData.Application;
            this.UiDoc = UiApp.ActiveUIDocument;

            //hide all junction builder elements
            lbl_junction1.Visibility = Visibility.Visible;
            cbox_junction1.Visibility = Visibility.Visible;
            lbl_junction2.Visibility = Visibility.Visible;
            cbox_junction2.Visibility = Visibility.Visible;
            lbl_junction3.Visibility = Visibility.Visible;
            cbox_junction3.Visibility = Visibility.Visible;
            lbl_junction4.Visibility = Visibility.Visible;
            cbox_junction4.Visibility = Visibility.Visible;

            txt_flankingElement1Length.Visibility = Visibility.Visible;
            txt_flankingElement2Length.Visibility = Visibility.Visible;
            txt_flankingElement3Length.Visibility = Visibility.Visible;
            txt_flankingElement4Length.Visibility = Visibility.Visible;

            cmd_flankingElement11.Visibility = Visibility.Hidden;
            cmd_flankingElement12.Visibility = Visibility.Hidden;
            cmd_flankingElement13.Visibility = Visibility.Hidden;
            cmd_flankingElement14.Visibility = Visibility.Hidden;

            cmd_flankingElement21.Visibility = Visibility.Hidden;
            cmd_flankingElement22.Visibility = Visibility.Hidden;
            cmd_flankingElement23.Visibility = Visibility.Hidden;
            cmd_flankingElement24.Visibility = Visibility.Hidden;

            cmd_flankingElement31.Visibility = Visibility.Hidden;
            cmd_flankingElement32.Visibility = Visibility.Hidden;
            cmd_flankingElement33.Visibility = Visibility.Hidden;
            cmd_flankingElement34.Visibility = Visibility.Hidden;

            cmd_flankingElement41.Visibility = Visibility.Hidden;
            cmd_flankingElement42.Visibility = Visibility.Hidden;
            cmd_flankingElement43.Visibility = Visibility.Hidden;
            cmd_flankingElement44.Visibility = Visibility.Hidden;

            lbl_flankingElement11.Visibility = Visibility.Hidden;
            lbl_flankingElement12.Visibility = Visibility.Hidden;
            lbl_flankingElement13.Visibility = Visibility.Hidden;
            lbl_flankingElement14.Visibility = Visibility.Hidden;

            lbl_flankingElement21.Visibility = Visibility.Hidden;
            lbl_flankingElement22.Visibility = Visibility.Hidden;
            lbl_flankingElement23.Visibility = Visibility.Hidden;
            lbl_flankingElement24.Visibility = Visibility.Hidden;

            lbl_flankingElement31.Visibility = Visibility.Hidden;
            lbl_flankingElement32.Visibility = Visibility.Hidden;
            lbl_flankingElement33.Visibility = Visibility.Hidden;
            lbl_flankingElement34.Visibility = Visibility.Hidden;

            lbl_flankingElement41.Visibility = Visibility.Hidden;
            lbl_flankingElement42.Visibility = Visibility.Hidden;
            lbl_flankingElement43.Visibility = Visibility.Hidden;
            lbl_flankingElement44.Visibility = Visibility.Hidden;


            //combobox: choose junction types
            var junctionTypes = new junctionTypesEnumerations();
            foreach (var junctionType in junctionTypes.JunctionTypeList)
            {
                cbox_junction1.Items.Add(junctionType);
                cbox_junction2.Items.Add(junctionType);
                cbox_junction3.Items.Add(junctionType);
                cbox_junction4.Items.Add(junctionType);
            }



        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        

        private void cmd_separatingElement_Click(object sender, RoutedEventArgs e)
        {
            //take selected element and safe its GUID in label
            var idsearch = new GetGUID();
            ElementId elementID = idsearch.Execute(Doc, CommandData);
            this.lbl_separatingElement.Content = elementID.ToString();

            //get geometry
            var geomsearch = new GetElementGeometry();
            var elementEdges = geomsearch.Execute(Doc, CommandData);
            txt_separatingElementLength.Text = elementEdges[0].ToString();
            txt_separatingElementHeigth.Text = elementEdges[1].ToString();
        }


        private void cmd_flankingElement_Click(object sender, RoutedEventArgs e)
        {
            var idsearch = new GetGUID();
            ElementId elementID = idsearch.Execute(Doc, CommandData);


            //Get Number of Button
            System.Windows.Controls.Button clickedButton = (System.Windows.Controls.Button)sender;
            string strNumbers = clickedButton.Name.Remove(0, 19); //cmd_flankingElement11 -> 11

            //Write GUID in label
            System.Windows.Controls.Label lbl;
            lbl = (System.Windows.Controls.Label)FindName("lbl_flankingElement" + strNumbers); //lbl_flankingElement11
            lbl.Content = elementID;
            lbl.Visibility = Visibility.Visible;

        }


        private void cbox_junction1_DropDownClosed(object sender, EventArgs e)
        {
            pic_junction1.Visibility = Visibility.Hidden;
            ChangeJunctionImage image = new ChangeJunctionImage(pic_junction1, cbox_junction1.Text);
            //adapt visibilty of elements
            image.CorrectVisibility(this, cbox_junction1.Text, 1);
        }

        private void cbox_junction2_DropDownClosed(object sender, EventArgs e)
        {
            pic_junction2.Visibility = Visibility.Hidden;
            ChangeJunctionImage image = new ChangeJunctionImage(pic_junction2, cbox_junction2.Text);
            //adapt visibilty of elements 
            image.CorrectVisibility(this, cbox_junction2.Text, 2);
        }

        private void cbox_junction3_DropDownClosed(object sender, EventArgs e)
        {
            pic_junction3.Visibility = Visibility.Hidden;
            ChangeJunctionImage image = new ChangeJunctionImage(pic_junction3, cbox_junction3.Text);
            //adapt visibilty of elements
            image.CorrectVisibility(this, cbox_junction3.Text, 3);
        }

        private void cbox_junction4_DropDownClosed(object sender, EventArgs e)
        {
            pic_junction4.Visibility = Visibility.Hidden;
            ChangeJunctionImage image = new ChangeJunctionImage(pic_junction4, cbox_junction4.Text);
            //adapt visibilty of elements
            image.CorrectVisibility(this, cbox_junction4.Text, 4);
        }


        private JunctionBuilder.BuildingElement AllElements { get; set; }
        private JunctionBuilder.BuildingElement AllPaths { get; set; }

        private void cmd_Save_Click(object sender, RoutedEventArgs e) //Save and Export
        {
            //Create Junctions
            JunctionBuilder junction1 = new JunctionBuilder();
            JunctionBuilder junction2 = new JunctionBuilder();
            JunctionBuilder junction3 = new JunctionBuilder();
            JunctionBuilder junction4 = new JunctionBuilder();

            List<string> elementIds = new List<string>();
            if (lbl_flankingElement11.Visibility == Visibility.Visible) elementIds.Add(lbl_flankingElement11.Content.ToString());
            if (lbl_flankingElement12.Visibility == Visibility.Visible) elementIds.Add(lbl_flankingElement12.Content.ToString());
            if (lbl_flankingElement13.Visibility == Visibility.Visible) elementIds.Add(lbl_flankingElement13.Content.ToString());
            if (lbl_flankingElement14.Visibility == Visibility.Visible) elementIds.Add(lbl_flankingElement14.Content.ToString());

            if (lbl_flankingElement21.Visibility == Visibility.Visible) elementIds.Add(lbl_flankingElement21.Content.ToString());
            if (lbl_flankingElement22.Visibility == Visibility.Visible) elementIds.Add(lbl_flankingElement22.Content.ToString());
            if (lbl_flankingElement23.Visibility == Visibility.Visible) elementIds.Add(lbl_flankingElement23.Content.ToString());
            if (lbl_flankingElement24.Visibility == Visibility.Visible) elementIds.Add(lbl_flankingElement24.Content.ToString());

            if (lbl_flankingElement31.Visibility == Visibility.Visible) elementIds.Add(lbl_flankingElement31.Content.ToString());
            if (lbl_flankingElement32.Visibility == Visibility.Visible) elementIds.Add(lbl_flankingElement32.Content.ToString());
            if (lbl_flankingElement33.Visibility == Visibility.Visible) elementIds.Add(lbl_flankingElement33.Content.ToString());
            if (lbl_flankingElement34.Visibility == Visibility.Visible) elementIds.Add(lbl_flankingElement34.Content.ToString());

            if (lbl_flankingElement41.Visibility == Visibility.Visible) elementIds.Add(lbl_flankingElement41.Content.ToString());
            if (lbl_flankingElement42.Visibility == Visibility.Visible) elementIds.Add(lbl_flankingElement42.Content.ToString());
            if (lbl_flankingElement43.Visibility == Visibility.Visible) elementIds.Add(lbl_flankingElement43.Content.ToString());
            if (lbl_flankingElement44.Visibility == Visibility.Visible) elementIds.Add(lbl_flankingElement44.Content.ToString());



            List<JunctionBuilder.BuildingElement> elements = new List<JunctionBuilder.BuildingElement>();
            JunctionBuilder.BuildingElement element = new JunctionBuilder.BuildingElement();
            element.ElementRevitId = lbl_separatingElement.Content.ToString();
            Element separatingRevitElement = UiDoc.Document.GetElement(ElementId.Parse(element.ElementRevitId));
            element.ElementID = separatingRevitElement.get_Parameter(BuiltInParameter.IFC_GUID).AsString();
            elements.Add(element);
            foreach (var el in elementIds)
            {
                if (el == "Label") //missing GUID
                {
                    return;
                }
                if (!elements.Exists(x => x.ElementID == el))
                {
                    JunctionBuilder.BuildingElement flElement = new JunctionBuilder.BuildingElement();
                    flElement.ElementRevitId = el;
                    flElement.ElementID = UiDoc.Document.GetElement(ElementId.Parse(flElement.ElementRevitId)).get_Parameter(BuiltInParameter.IFC_GUID).AsString();
                    elements.Add(flElement);
                }
            }

            //Add information from revit to elements
           foreach (var el in elements)
            {
                Element revitElement = UiDoc.Document.GetElement(ElementId.Parse(el.ElementRevitId));
                //var id = Doc.GetElement(idselection);
                //Add Materialname
                GetRevitName findName = new GetRevitName(Doc, CommandData, revitElement);
                el.ElementName = findName.RevitCategory + "-" + findName.RevitName;
                //Add Materials
                GetRevitMaterials FindMaterial = new GetRevitMaterials(Doc, CommandData, revitElement);
                el.ElementMaterial = FindMaterial.Materials;
            }

            //Put Elements in Junction
            if (lbl_flankingElement11.Visibility == Visibility.Visible) junction1.AllBuildingElements[1] = elements.FirstOrDefault(x => x.ElementRevitId == lbl_flankingElement11.Content.ToString());
            if (lbl_flankingElement12.Visibility == Visibility.Visible) junction1.AllBuildingElements[2] = elements.FirstOrDefault(x => x.ElementRevitId == lbl_flankingElement12.Content.ToString());
            if (lbl_flankingElement13.Visibility == Visibility.Visible) junction1.AllBuildingElements[3] = elements.FirstOrDefault(x => x.ElementRevitId == lbl_flankingElement13.Content.ToString());
            if (lbl_flankingElement14.Visibility == Visibility.Visible) junction1.AllBuildingElements[4] = elements.FirstOrDefault(x => x.ElementRevitId == lbl_flankingElement14.Content.ToString());

            if (lbl_flankingElement21.Visibility == Visibility.Visible) junction2.AllBuildingElements[1] = elements.FirstOrDefault(x => x.ElementRevitId == lbl_flankingElement21.Content.ToString());
            if (lbl_flankingElement22.Visibility == Visibility.Visible) junction2.AllBuildingElements[2] = elements.FirstOrDefault(x => x.ElementRevitId == lbl_flankingElement22.Content.ToString());
            if (lbl_flankingElement23.Visibility == Visibility.Visible) junction2.AllBuildingElements[3] = elements.FirstOrDefault(x => x.ElementRevitId == lbl_flankingElement23.Content.ToString());
            if (lbl_flankingElement24.Visibility == Visibility.Visible) junction2.AllBuildingElements[4] = elements.FirstOrDefault(x => x.ElementRevitId == lbl_flankingElement24.Content.ToString());

            if (lbl_flankingElement31.Visibility == Visibility.Visible) junction3.AllBuildingElements[1] = elements.FirstOrDefault(x => x.ElementRevitId == lbl_flankingElement31.Content.ToString());
            if (lbl_flankingElement32.Visibility == Visibility.Visible) junction3.AllBuildingElements[2] = elements.FirstOrDefault(x => x.ElementRevitId == lbl_flankingElement32.Content.ToString());
            if (lbl_flankingElement33.Visibility == Visibility.Visible) junction3.AllBuildingElements[3] = elements.FirstOrDefault(x => x.ElementRevitId == lbl_flankingElement33.Content.ToString());
            if (lbl_flankingElement34.Visibility == Visibility.Visible) junction3.AllBuildingElements[4] = elements.FirstOrDefault(x => x.ElementRevitId == lbl_flankingElement34.Content.ToString());

            if (lbl_flankingElement41.Visibility == Visibility.Visible) junction4.AllBuildingElements[1] = elements.FirstOrDefault(x => x.ElementRevitId == lbl_flankingElement41.Content.ToString());
            if (lbl_flankingElement42.Visibility == Visibility.Visible) junction4.AllBuildingElements[2] = elements.FirstOrDefault(x => x.ElementRevitId == lbl_flankingElement42.Content.ToString());
            if (lbl_flankingElement43.Visibility == Visibility.Visible) junction4.AllBuildingElements[3] = elements.FirstOrDefault(x => x.ElementRevitId == lbl_flankingElement43.Content.ToString());
            if (lbl_flankingElement44.Visibility == Visibility.Visible) junction4.AllBuildingElements[4] = elements.FirstOrDefault(x => x.ElementRevitId == lbl_flankingElement44.Content.ToString());

            //Get CommonLength
            if (cbox_junction1.SelectedIndex > -1)
            {
                try
                {
                    junction1.CommonLength = Convert.ToDouble(txt_flankingElement1Length.Text.Replace(',', '.'));
                }
                catch (Exception ex)
                {
                    MessageBoxResult result = MessageBox.Show("Please enter a common length for junction 1");
                    txt_flankingElement1Length.Background = Brushes.Red;
                   return;
                }
                
                junction1.SeparatingElementID = lbl_separatingElement.Content.ToString();
                junction1.TypeOfJunction = cbox_junction1.Text;
                
            }
            
            if (cbox_junction2.SelectedIndex > -1)
            {

                try
                {
                    junction2.CommonLength = Convert.ToDouble(txt_flankingElement2Length.Text.Replace(',', '.'));
                    
                }
                catch (Exception ex)
                {
                    MessageBoxResult result = MessageBox.Show("Please enter a common length for junction 2");
                    txt_flankingElement2Length.Background = Brushes.Red;
                    return;
                }

                junction2.SeparatingElementID = lbl_separatingElement.Content.ToString();
                junction2.TypeOfJunction = cbox_junction2.Text;
            }
            
            if (cbox_junction3.SelectedIndex > -1)
            {
                try
                {
                    junction3.CommonLength = Convert.ToDouble(txt_flankingElement3Length.Text.Replace(',', '.'));
                }
                catch (Exception ex)
                {
                    MessageBoxResult result = MessageBox.Show("Please enter a common length for junction 3");
                    txt_flankingElement3Length.Background = Brushes.Red;
                    return;
                }
                
                junction3.SeparatingElementID = lbl_separatingElement.Content.ToString();
                junction3.TypeOfJunction = cbox_junction3.Text;
            }


            if (cbox_junction4.SelectedIndex > -1)
            {
                try
                {
                    junction4.CommonLength = Convert.ToDouble(txt_flankingElement4Length.Text.Replace(',', '.'));
                }
                catch (Exception ex)
                {
                    MessageBoxResult result = MessageBox.Show("Please enter a common length for junction 4");
                    txt_flankingElement3Length.Background = Brushes.Red;
                    return;
                }
                
                junction4.SeparatingElementID = lbl_separatingElement.Content.ToString();
                junction4.TypeOfJunction = cbox_junction4.Text;
            }


            //Build Transmission Paths
            junction1.CreatePaths(junction1.TypeOfJunction);
            junction2.CreatePaths(junction2.TypeOfJunction);
            junction3.CreatePaths(junction3.TypeOfJunction);
            junction4.CreatePaths(junction4.TypeOfJunction);
            junction1.SaveBuildingElements();
            junction2.SaveBuildingElements();
            junction3.SaveBuildingElements();
            junction4.SaveBuildingElements();
            List<JunctionBuilder> allJunctions = new List<JunctionBuilder>();
            allJunctions.Add(junction1);
            allJunctions.Add(junction2);
            allJunctions.Add(junction3);
            allJunctions.Add(junction4);

            //Store Data in Element in Revit //TODO: store data before export  //TODO: export to JSON as separate button
            //StoreDataInElement storeInElement = new StoreDataInElement(separatingRevitElement, allJunctions);
            

            //Create string for JSON
            //ConvertToJsonString jsonString = new ConvertToJsonString(this); //change to Input of junction
            //jsonString.GetJsonString();
            //save JSON in path
            JsonSerializer serializer = new JsonSerializer();

            System.Windows.Forms.FolderBrowserDialog objDialog = new FolderBrowserDialog();
            objDialog.SelectedPath = @"C:\";
            DialogResult objResult = objDialog.ShowDialog();
            string pathname="";
            if (objResult == System.Windows.Forms.DialogResult.OK)
                pathname = objDialog.SelectedPath;
            if (!(pathname == ""))
            {
                pathname = pathname + "\\" + "_JunctionInpuData_"+ lbl_separatingElement.Content.ToString() + ".json";
            }
            using (StreamWriter sw = new StreamWriter(pathname))
            //using (JsonWriter writer = new JsonTextWriter(sw))
            //{
            //    serializer.Serialize(writer, jsonString.allInfos);
            //}
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, allJunctions);
            }
            Console.WriteLine("JSON with junction was saved in: " + pathname);
            
            Close();
        }


    }

}
