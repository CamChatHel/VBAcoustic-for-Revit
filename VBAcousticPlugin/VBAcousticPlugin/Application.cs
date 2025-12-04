using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing.Imaging;
using Autodesk.Revit.UI;
using System.Reflection;
using System.Windows.Media.Imaging;
using System.IO;


namespace VBAcousticPlugin
{
    //C:\Users\chca426\AppData\Roaming\Autodesk\Revit\Addins\2024
    public class Application :IExternalApplication
    {
        public Result OnStartup(UIControlledApplication app)
        {
            
            
            //path where app is being compiled
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;
            RibbonPanel panel = DoRibbonPanel(app, thisAssemblyPath);

            

            return Result.Succeeded;

        }

        public Result OnShutdown(UIControlledApplication app)
        {
            return Result.Succeeded;
        }

        //create Tab and Ribbonpanel
        public RibbonPanel DoRibbonPanel(UIControlledApplication app, string thisAssemblyPath)
        {
            string tab = "VBAcoustic";
            RibbonPanel ribbonPanel = null;
            try
            {
                app.CreateRibbonTab(tab);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

            }

            try
            {
                app.CreateRibbonPanel(tab, "Start");
                app.CreateRibbonPanel(tab, "Export");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            List<RibbonPanel> panels = app.GetRibbonPanels(tab);
            foreach (RibbonPanel p in panels.Where(p => p.Name == "Start"))
            {
                ribbonPanel = p;
            }

            RibbonPanel ribbonPanelStart = panels.Find(p => p.Name == "Start");
            RibbonPanel ribbonPanelExport = panels.Find(p => p.Name == "Export");

            //TODO: change absolute paths to relative paths for icons
            //https://www.youtube.com/watch?v=zvU00Cp-8FM Minute 7:16
            //add button to the panel
            PushButton buttonStart = ribbonPanelStart.AddItem(new PushButtonData("Start","start" , thisAssemblyPath, "VBAcousticPlugin.OpenWPF")) as PushButton;
            buttonStart.ToolTip = "VBAcoustic Plugin";

            //Uri uri = new Uri(Path.Combine(Path.GetDirectoryName(thisAssemblyPath), "Resources",
            //    "VBAcousticIcon.png"));
            //BitmapImage bitmap = new BitmapImage(uri);
            //buttonStart.LargeImage = bitmap;

            BitmapImage bitmapStart = new BitmapImage();
            bitmapStart.BeginInit();
            bitmapStart.UriSource = new Uri("Resources/VBAcousticIcon.png", UriKind.Relative);
            bitmapStart.DecodePixelWidth = 96;
            bitmapStart.EndInit();
            buttonStart.LargeImage = bitmapStart;

            // buttonStart.LargeImage = new BitmapImage(new Uri("Resources/VBAcousticIcon.ico", UriKind.Relative));

            PushButton buttonExport = ribbonPanelExport.AddItem(new PushButtonData("Export", "Akustik Fachmodell", thisAssemblyPath, "VBAcousticPlugin.ExportToExcel")) as PushButton;
            buttonExport.ToolTip = "Export Fachmodell";
            Uri uriExport = new Uri("Resources/excelIcon.ico", UriKind.Relative);
            BitmapImage bitmapExport = new BitmapImage(uriExport);
            buttonExport.LargeImage = bitmapExport;


            return ribbonPanel;
        }
    }
}
