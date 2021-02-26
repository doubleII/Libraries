using MvvMLightLib.Properties;
using Tulpep.NotificationWindow;

namespace PatientenMonitor.Notification
{
    public static class PopupWindow
    {
        public static void ShowNotification(string title, string text)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Resources.information;
            popup.TitleText = title;
            popup.ContentText = text;
            popup.Popup();
        }
    }
}
