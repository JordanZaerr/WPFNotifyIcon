using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Samples.Tutorials.Balloons
{
    /// <summary>
    /// Interaction logic for BalloonSampleWindow.xaml
    /// </summary>
    public partial class BalloonSampleWindow : Window
    {
        public BalloonSampleWindow()
        {
            InitializeComponent();
        }

        private readonly Queue<int> _balloonIds = new Queue<int>();
        private readonly Random _idGenerator = new Random();

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            //clean up notifyicon (would otherwise stay open until application finishes)
            MyNotifyIcon.Dispose();

            base.OnClosing(e);
        }

        private void btnShowCustomBalloon_Click(object sender, RoutedEventArgs e)
        {
            var id = _idGenerator.Next();
            _balloonIds.Enqueue(id);
            var balloon = new FancyBalloon(id);
            balloon.BalloonText = "Custom Balloon";

            //show balloon and close it after 5 seconds
            MyNotifyIcon.ShowCustomBalloon(id, balloon, PopupAnimation.None, 5000);
        }

        private void btnHideStandardBalloon_Click(object sender, RoutedEventArgs e)
        {
            MyNotifyIcon.HideBalloonTip();
        }


        private void btnShowStandardBalloon_Click(object sender, RoutedEventArgs e)
        {
            string title = "WPF NotifyIcon";
            string text = "This is a standard balloon";

            MyNotifyIcon.ShowBalloonTip(title, text, MyNotifyIcon.Icon);
        }

        private void btnCloseCustomBalloon_Click(object sender, RoutedEventArgs e)
        {
            if (_balloonIds.Count > 0)
            {
                MyNotifyIcon.CloseBalloon(_balloonIds.Dequeue());
            }
        }
    }
}
