using System.Drawing;

using System.Windows.Forms;
using System.Windows.Markup;
string destinationLocationToStoreScreenShot = @"E:\\Data\\Photo";
ScreenCapture.CaptureScreen captureScreen = new ScreenCapture.CaptureScreen(destinationLocationToStoreScreenShot);
captureScreen.StartCapturing();
Console.WriteLine("Screen capturing started");

Console.WriteLine("Press any key to Stop");
Console.ReadKey();
captureScreen.StopCapturing();
