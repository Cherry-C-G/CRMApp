using Antra.CRMApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Core.Contract.Service
{
    public interface IShipperServiceAsync
    {
        Task<IEnumerable<ShipperResponseModel>> GetAllAsync();
        Task<int> AddShipperAsync(ShipperRequestModel shipper);
        Task<ShipperResponseModel> GetByIdAsync(int id);
        Task<ShipperRequestModel> GetShipperForEditAsync(int id);
        Task<int> UpdateShipperAsync(ShipperRequestModel shipper);
        Task<int> DeleteShipperAsync(int id);
    }
}
