using Antra.CRMApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Core.Contract.Service
{
    public interface IRegionServiceAsync
    {
        Task<IEnumerable<RegionResponseModel>> GetAllAsync();
        Task<int> AddRegionAsync(RegionRequestModel model);
        Task<RegionResponseModel> GetRegionByIdAsync(int id);
        Task<int> InsertRegionAsync(RegionRequestModel model);
        Task<int> UpdateRegionAsync(RegionRequestModel model);
        Task<int> DeleteRegionAsync(int id);
    }
}