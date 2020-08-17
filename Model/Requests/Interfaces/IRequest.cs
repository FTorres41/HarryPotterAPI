using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace HarryPotter.Domain.Requests
{
    public interface IRequest
    {
        void Validate();
    }
}
