using Flunt.Notifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PR.Domain.Helper
{
    public static class _BuildResult
    {
        public static string[] BuildResult(IReadOnlyCollection<Notification> Notifications)
        {
            string[] result = new string[0];

            result = new string[Notifications.Count];

            int i = 0;
            foreach (var notification in Notifications)
            {
                if (i < Notifications.Count)
                    result[i] = $"{notification.Property} {notification.Message}";
                i++;
            }
            return result;
        }

    }
}

