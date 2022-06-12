using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;
using Antra.CRMApp.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Infrastructure.Service
{
    public class VendorServiceAsync : IVendorServiceAsync
    {
        private readonly IVendorRepositoryAsync vendorRepositoryAsync;


        public VendorServiceAsync(IVendorRepositoryAsync _vendorRepositoryAsync)
        {
            vendorRepositoryAsync = _vendorRepositoryAsync;
        }


        public async Task<int> AddVendorAsync(VendorRequestModel model)
        {
            Vendor ven = new Vendor();
            ven.Id = model.Id;
            ven.Name = model.Name;
            ven.Country = model.Country;
            ven.Mobile = model.Mobile;
            ven.City = model.City;
            ven.EmailId = model.EmailId;
            ven.IsActive = model.IsActive;
            return await vendorRepositoryAsync.InsertAsync(ven);
        }

        public async Task<int> DeleteVendorAsync(int id)
        {
            return await vendorRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<VendorResponseModel>> GetAllAsync()
        {
            var collection = await vendorRepositoryAsync.GetAllAsync();

            if (collection != null)
            {
                List<VendorResponseModel> result = new List<VendorResponseModel>();
                foreach (var item in collection)
                {
                    VendorResponseModel model = new VendorResponseModel();
                    model.Id = item.Id;
                    model.Name = item.Name;
                    model.City = item.City;
                    model.EmailId = item.EmailId;
                    model.IsActive = item.IsActive;
                    model.Country = item.Country;
                    model.Mobile = item.Mobile;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<VendorResponseModel> GetByIdAsync(int id)
        {
            var item = await vendorRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                VendorResponseModel model = new VendorResponseModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.City = item.City;
                model.EmailId = item.EmailId;
                model.IsActive = item.IsActive;
                model.Country = item.Country;
                model.Mobile = item.Mobile;
                return model;
            }
            return null;
        }

        public async Task<VendorRequestModel> GetVendorForEditAsync(int id)
        {
            var item = await vendorRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                VendorRequestModel model = new VendorRequestModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.City = item.City;
                model.EmailId = item.EmailId;
                model.IsActive = item.IsActive;
                model.Country = item.Country;
                model.Mobile = item.Mobile;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateVendorAsync(VendorRequestModel model)
        {
            Vendor ven = new Vendor();
            ven.Id = model.Id;
            ven.Name = model.Name;
            ven.Country = model.Country;
            ven.Mobile = model.Mobile;
            ven.City = model.City;
            ven.EmailId = model.EmailId;
            ven.IsActive = model.IsActive;
            return await vendorRepositoryAsync.UpdateAsync(ven);
        }
    }
}
