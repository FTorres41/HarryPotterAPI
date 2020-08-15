using HarryPotter.Model.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace HarryPotter.Service.Interfaces
{
    public interface IPotterAPI
    {
        [Get("/houses")]
        IList<House> GetHouses();
    }
}
