using HarryPotter.Model.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Service.Interfaces
{
    public interface IPotterAPI
    {
        [Get("/houses?key={apikey}")]
        Task<IList<House>> GetHouses(string apikey);
    }
}
