using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Infrastructure.Service
{
    public class RegionServiceAsync : IRegionServiceAsync
    {
        private readonly IRegionRepositoryAsync regionRepositoryAsync;
        public RegionServiceAsync(IRegionRepositoryAsync repo)
        {
            regionRepositoryAsync = repo;
        }
        public async Task<int> AddRegionAsync(RegionRequestModel model)
        {
            Region region = new Region();
            region.Name = model.Name;
            return await regionRepositoryAsync.InsertAsync(region);
        }

        public async Task<int> DeleteRegionAsync(int id)
        {
            return await regionRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<RegionResponseModel>> GetAllAsync()
        {
            var collection = await regionRepositoryAsync.GetAllAsync();
            if (collection != null)
            {
                List<RegionResponseModel> regionModels = new List<RegionResponseModel>();
                foreach (var item in collection)
                {
                    RegionResponseModel model = new RegionResponseModel();
                    model.Name = item.Name;
                    model.Id = item.Id;
                    regionModels.Add(model);
                }
                return regionModels;
            }
            return null;
        }

        public async Task<RegionResponseModel> GetByIdAsync(int id)
        {
            var item = await regionRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                RegionResponseModel model = new RegionResponseModel();
                model.Id = item.Id;
                model.Name = item.Name;
                return model;
            }
            return null;
        }

        public async Task<RegionRequestModel> GetRegionForEditAsync(int id)
        {
            var item = await regionRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                RegionRequestModel model = new RegionRequestModel();
                model.Id = item.Id;
                model.Name = item.Name;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateRegionAsync(RegionRequestModel region)
        {
            Region reg = new Region();
            reg.Id = region.Id;
            reg.Name = region.Name;
            return await regionRepositoryAsync.UpdateAsync(reg);
        }
    }
}