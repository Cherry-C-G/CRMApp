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
        Task<int> AddRegionAsync(RegionRequestModel region);
        Task<RegionResponseModel> GetByIdAsync(int id);
        Task<RegionRequestModel> GetRegionForEditAsync(int id);
        Task<int> UpdateRegionAsync(RegionRequestModel region);
        Task<int> DeleteRegionAsync(int id);
    }
}
