using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCapture
{
    internal class CaptureScreen
    {
        string directoryToSave = string.Empty;
        System.Timers.Timer timingInterval;

        public CaptureScreen(string locationToSave)
        {
            directoryToSave = locationToSave;
            timingInterval = new System.Timers.Timer();
            timingInterval.Interval = TimeSpan.FromMinutes(1).TotalMilliseconds;
            timingInterval.Elapsed += TimingInterval_Elapsed;
           
        }
        internal void StartCapturing()
        {
            timingInterval.Start();
        }
        internal void StopCapturing()
        {
            timingInterval.Stop();
        }


        private void TimingInterval_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Capture();
        }

        internal void Capture()
        {
            string fileName = $"{Guid.NewGuid()}.png";
            string filePath = Path.Combine(directoryToSave, fileName);

            using (Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                              Screen.PrimaryScreen.Bounds.Height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
                }

                bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        
    }
}
