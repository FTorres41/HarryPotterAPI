using HarryPotter.Domain.Requests;
using System;

namespace HarryPotter.Util
{
    public static class ErrorHelper
    {
        public static string GetErrors(Request request)
        {
            var errors = string.Empty;
            foreach (var notification in request.Notifications)
                errors += $"{notification.Property}; ";

            return errors.Trim();
        }
    }
}
