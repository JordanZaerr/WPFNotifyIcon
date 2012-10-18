using System.Threading;
using System.Windows.Controls.Primitives;

namespace Hardcodet.Wpf.TaskbarNotification
{
    public class CustomBalloonInfo
    {
        public object Key { get; set; }
        public Popup Popup { get; set; }
        public Timer CloseTimer { get; set; }
    }
}