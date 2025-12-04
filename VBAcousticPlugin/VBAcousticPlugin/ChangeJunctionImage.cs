using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Autodesk.Revit.DB;
using Visibility = System.Windows.Visibility;

namespace VBAcousticPlugin
{
    public class ChangeJunctionImage
    {
        
        public ChangeJunctionImage(System.Windows.Controls.Image wpfImage, string WpfJunction)
        {
            
            if (WpfJunction != null)
            {
                BitmapImage myBitmapImage = new BitmapImage();
                
                if (WpfJunction == "Lh1-2")
                {
                    myBitmapImage.BeginInit();
                    myBitmapImage.UriSource = new Uri("Resources/Lh1-2.png", UriKind.Relative);
                    myBitmapImage.DecodePixelWidth = 200;
                    myBitmapImage.EndInit();
                    
                    
                }
                else if (WpfJunction == "Lv1-2")
                {
                    myBitmapImage.BeginInit();
                    myBitmapImage.UriSource = new Uri("Resources/Lv1-2.png", UriKind.Relative);
                    myBitmapImage.DecodePixelWidth = 200;
                    myBitmapImage.EndInit();
                }
                else if (WpfJunction == "Tv1-24")
                {
                    myBitmapImage.BeginInit();
                    myBitmapImage.UriSource = new Uri("Resources/Tv1-24.png", UriKind.Relative);
                    myBitmapImage.DecodePixelWidth = 200;
                    myBitmapImage.EndInit();
                }
                else if (WpfJunction == "Tv2-13")
                {
                    myBitmapImage.BeginInit();
                    myBitmapImage.UriSource = new Uri("Resources/Tv2-13.png", UriKind.Relative);
                    myBitmapImage.DecodePixelWidth = 200;
                    myBitmapImage.EndInit();
                }
                else if (WpfJunction == "Th1-24")
                {
                    myBitmapImage.BeginInit();
                    myBitmapImage.UriSource = new Uri("Resources/Th1-24.png", UriKind.Relative);
                    myBitmapImage.DecodePixelWidth = 200;
                    myBitmapImage.EndInit();
                }
                else if (WpfJunction == "Th2-1-4")
                {
                    myBitmapImage.BeginInit();
                    myBitmapImage.UriSource = new Uri("Resources/Th2-1-4.png", UriKind.Relative);
                    myBitmapImage.DecodePixelWidth = 200;
                    myBitmapImage.EndInit();
                }
                else if (WpfJunction == "Tv2-1-4")
                {
                    myBitmapImage.BeginInit();
                    myBitmapImage.UriSource = new Uri("Resources/Tv2-1-4.png", UriKind.Relative);
                    myBitmapImage.DecodePixelWidth = 200;
                    myBitmapImage.EndInit();
                }
                else if (WpfJunction == "Th1-2:4")
                {
                    myBitmapImage.BeginInit();
                    myBitmapImage.UriSource = new Uri("Resources/Th1-2dp4.png", UriKind.Relative);
                    myBitmapImage.DecodePixelWidth = 200;
                    myBitmapImage.EndInit();
                }
                else if (WpfJunction == "Tv1-2:4")
                {
                    myBitmapImage.BeginInit();
                    myBitmapImage.UriSource = new Uri("Resources/Tv1-2dp4.png", UriKind.Relative);
                    myBitmapImage.DecodePixelWidth = 200;
                    myBitmapImage.EndInit();
                }
                else if (WpfJunction == "Tv2-1:3")
                {
                    myBitmapImage.BeginInit();
                    myBitmapImage.UriSource = new Uri("Resources/Tv2-1dp3.png", UriKind.Relative);
                    myBitmapImage.DecodePixelWidth = 200;
                    myBitmapImage.EndInit();
                }
                else if (WpfJunction == "Xh1-24-3")
                {
                    myBitmapImage.BeginInit();
                    myBitmapImage.UriSource = new Uri("Resources/Xh1-24-3.png", UriKind.Relative);
                    myBitmapImage.DecodePixelWidth = 200;
                    myBitmapImage.EndInit();
                }
                else if (WpfJunction == "Xv2-13-4")
                {
                    myBitmapImage.BeginInit();
                    myBitmapImage.UriSource = new Uri("Resources/Xv2-13-4.png", UriKind.Relative);
                    myBitmapImage.DecodePixelWidth = 200;
                    myBitmapImage.EndInit();
                }
                else if (WpfJunction == "Xv1-24-3")
                {
                    myBitmapImage.BeginInit();
                    myBitmapImage.UriSource = new Uri("Resources/Xv1-24-3.png", UriKind.Relative);
                    myBitmapImage.DecodePixelWidth = 200;
                    myBitmapImage.EndInit();
                }
                else if (WpfJunction == "Xh2-1:3-4")
                {
                    myBitmapImage.BeginInit();
                    myBitmapImage.UriSource = new Uri("Resources/Xh2-1dp3-4.png", UriKind.Relative);
                    myBitmapImage.DecodePixelWidth = 200;
                    myBitmapImage.EndInit();
                }
                else if (WpfJunction == "Xv2-1:3-4")
                {
                    myBitmapImage.BeginInit();
                    myBitmapImage.UriSource = new Uri("Resources/Xv2-1dp3-4.png", UriKind.Relative);
                    myBitmapImage.DecodePixelWidth = 200;
                    myBitmapImage.EndInit();
                }
                else if (WpfJunction == "Xh1-24-3")
                {
                    myBitmapImage.BeginInit();
                    myBitmapImage.UriSource = new Uri("Resources/Xh1-24-3.png", UriKind.Relative);
                    myBitmapImage.DecodePixelWidth = 200;
                    myBitmapImage.EndInit();

                }
                

                if (myBitmapImage.UriSource != null)
                {
                    wpfImage.Source = myBitmapImage;
                    wpfImage.Visibility = Visibility.Visible;
                }
                else wpfImage.Visibility = Visibility.Hidden;
                
                
            }
        }


     
        public void CorrectVisibility(VBAcousticPlugin.UI myWpf, string junctionType, int junctionNr)
        {
            System.Windows.Controls.Label lbl1 = new System.Windows.Controls.Label();
            System.Windows.Controls.Label lbl2 = new System.Windows.Controls.Label();
            System.Windows.Controls.Label lbl3 = new System.Windows.Controls.Label();
            System.Windows.Controls.Label lbl4 = new System.Windows.Controls.Label();

            System.Windows.Controls.Button cmd1 = new System.Windows.Controls.Button();
            System.Windows.Controls.Button cmd2 = new System.Windows.Controls.Button();
            System.Windows.Controls.Button cmd3 = new System.Windows.Controls.Button();
            System.Windows.Controls.Button cmd4 = new System.Windows.Controls.Button();

            //find which junction elements to change
            if (junctionNr == 1)
            {
                lbl1 = myWpf.lbl_flankingElement11;
                lbl2 = myWpf.lbl_flankingElement12;
                lbl3 = myWpf.lbl_flankingElement13;
                lbl4 = myWpf.lbl_flankingElement14;

                cmd1 = myWpf.cmd_flankingElement11;
                cmd2 = myWpf.cmd_flankingElement12;
                cmd3 = myWpf.cmd_flankingElement13;
                cmd4 = myWpf.cmd_flankingElement14;
            }
            else if (junctionNr == 2)
            {
                lbl1 = myWpf.lbl_flankingElement21;
                lbl2 = myWpf.lbl_flankingElement22;
                lbl3 = myWpf.lbl_flankingElement23;
                lbl4 = myWpf.lbl_flankingElement24;

                cmd1 = myWpf.cmd_flankingElement21;
                cmd2 = myWpf.cmd_flankingElement22;
                cmd3 = myWpf.cmd_flankingElement23;
                cmd4 = myWpf.cmd_flankingElement24;
            }
            else if (junctionNr == 3)
            {
                lbl1 = myWpf.lbl_flankingElement31;
                lbl2 = myWpf.lbl_flankingElement32;
                lbl3 = myWpf.lbl_flankingElement33;
                lbl4 = myWpf.lbl_flankingElement34;

                cmd1 = myWpf.cmd_flankingElement31;
                cmd2 = myWpf.cmd_flankingElement32;
                cmd3 = myWpf.cmd_flankingElement33;
                cmd4 = myWpf.cmd_flankingElement34;
            }
            else if (junctionNr == 4)
            {
                lbl1 = myWpf.lbl_flankingElement41;
                lbl2 = myWpf.lbl_flankingElement42;
                lbl3 = myWpf.lbl_flankingElement43;
                lbl4 = myWpf.lbl_flankingElement44;

                cmd1 = myWpf.cmd_flankingElement41;
                cmd2 = myWpf.cmd_flankingElement42;
                cmd3 = myWpf.cmd_flankingElement43;
                cmd4 = myWpf.cmd_flankingElement44;
            }
            else return;

            if (junctionType == "Lh1-2" || junctionType == "Lv1-2")
            {
                lbl1.Visibility = Visibility.Visible;
                lbl2.Visibility = Visibility.Visible;
                lbl3.Visibility = Visibility.Hidden;
                lbl4.Visibility = Visibility.Hidden;

                cmd1.Visibility = Visibility.Visible;
                cmd2.Visibility = Visibility.Visible;
                cmd3.Visibility = Visibility.Hidden;
                cmd4.Visibility = Visibility.Hidden;


            }
            else if (junctionType == "Tv2-13" || junctionType == "Tv2-1:3")
            {
                lbl1.Visibility = Visibility.Visible;
                lbl2.Visibility = Visibility.Visible;
                lbl3.Visibility = Visibility.Visible;
                lbl4.Visibility = Visibility.Hidden;

                cmd1.Visibility = Visibility.Visible;
                cmd2.Visibility = Visibility.Visible;
                cmd3.Visibility = Visibility.Visible;
                cmd4.Visibility = Visibility.Hidden;

               // if (junctionType == "Tv2-13") cmd3.Text = cmd1.Text;

            }
            else if (junctionType == "Tv1-24" || junctionType == "Th1-24" || junctionType == "Th2-1-4" || junctionType == "Tv2-1-4" || junctionType == "Th1-2:4" || junctionType == "Tv1-2:4")
            {
                lbl1.Visibility = Visibility.Visible;
                lbl2.Visibility = Visibility.Visible;
                lbl3.Visibility = Visibility.Hidden;
                lbl4.Visibility = Visibility.Visible;

                cmd1.Visibility = Visibility.Visible;
                cmd2.Visibility = Visibility.Visible;
                cmd3.Visibility = Visibility.Hidden;
                cmd4.Visibility = Visibility.Visible;

              //  if (junctionType == "Tv1-24") cmd4.Text = cmd2.Text;
               // if (junctionType == "Th1-24") cmd4.Text = cmd2.Text;
            }
            else if (junctionType == "Xh1-24-3" || junctionType == "Xv2-13-4" || junctionType == "Xv1-24-3" || junctionType == "Xh2-1:3-4" || junctionType == "Xv2-1:3-4")
            {
                lbl1.Visibility = Visibility.Visible;
                lbl2.Visibility = Visibility.Visible;
                lbl3.Visibility = Visibility.Visible;
                lbl4.Visibility = Visibility.Visible;

                cmd1.Visibility = Visibility.Visible;
                cmd2.Visibility = Visibility.Visible;
                cmd3.Visibility = Visibility.Visible;
                cmd4.Visibility = Visibility.Visible;

               // if (junctionType == "Xh1-24-3" || junctionType == "Xv1-24-3") cmd4.Text = cmd2.Text;
               // if (junctionType == "Xv2-13-4") cmd3.Text = cmd1.Text;
            }

        }
    }

    
}
