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
    public class ShipperServiceAsync : IShipperServiceAsync
    {
        private readonly IShipperRepositoryAsync shipperRepositoryAsync;

        public ShipperServiceAsync(IShipperRepositoryAsync _shipperRepositoryAsync)
        {
            shipperRepositoryAsync = _shipperRepositoryAsync;
        }


        public async Task<int> AddShipperAsync(ShipperRequestModel model)
        {
            Shipper shi = new Shipper();
            shi.Id = model.Id;
            shi.Name = model.Name;
            shi.Phone = model.Phone;
            return await shipperRepositoryAsync.InsertAsync(shi);
        }

        public async Task<int> DeleteShipperAsync(int id)
        {
            return await shipperRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<ShipperResponseModel>> GetAllAsync()
        {
            var collection = await shipperRepositoryAsync.GetAllAsync();

            if (collection != null)
            {
                List<ShipperResponseModel> result = new List<ShipperResponseModel>();
                foreach (var item in collection)
                {
                    ShipperResponseModel model = new ShipperResponseModel();
                    model.Id = item.Id;
                    model.Name = item.Name;
                    model.Phone = item.Phone;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<ShipperResponseModel> GetByIdAsync(int id)
        {
            var item = await shipperRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                ShipperResponseModel model = new ShipperResponseModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.Phone = item.Phone;
                return model;
            }
            return null;
        }

        public async Task<ShipperRequestModel> GetShipperForEditAsync(int id)
        {
            var item = await shipperRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                ShipperRequestModel model = new ShipperRequestModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.Phone = item.Phone;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateShipperAsync(ShipperRequestModel shipper)
        {
            Shipper shi = new Shipper();
            shi.Id = shipper.Id;
            shi.Name = shipper.Name;
            shi.Phone = shipper.Phone;
            return await shipperRepositoryAsync.UpdateAsync(shi);
        }
    }
}

