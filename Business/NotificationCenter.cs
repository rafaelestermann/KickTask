using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KickTask.KickTask
{
    public static class NotificationCenter
    {
        private static List<string> s_notifications;

        public static List<string> Notifications
        {
            get
            {
                return s_notifications;
            }

            set => s_notifications = value;
        }

        public static void AddLoginNotification(string message)
        {
            if (Notifications == null)
            {
                Notifications = new List<string>();
            }
            s_notifications.Add("ShowLoginToast('" + message + "')");
        }

        public static void AddLogoutNotification()
        {
            if (Notifications == null)
            {
                Notifications = new List<string>();
            }
            Notifications.Add("ShowLogoutToast()");
        }       

        public static void AddRegistrationSuccessfull(string message)
        {
            if (Notifications == null)
            {
                Notifications = new List<string>();
            }
            Notifications.Add("ShowRegistrationSuccessfulToast('"+message+"')");
        }

        public static void AddVerificationSuccessfull(string message)
        {
            if (Notifications == null)
            {
                Notifications = new List<string>();
            }
            Notifications.Add("ShowVerificationSuccessfulToast('" + message + "')");
        }
    }
}