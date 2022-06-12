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
    public class CustomerServiceAsync : ICustomerServiceAsync
    {
        private readonly ICustomerRepositoryAsync customerRepositoryAsync;
        public CustomerServiceAsync(ICustomerRepositoryAsync _customerRepositoryAsync)
        {
            customerRepositoryAsync = _customerRepositoryAsync;
        }

        public async Task<int> AddCustomerAsync(CustomerRequestModel customer)
        {
            Customer cus = new Customer();
            cus.Id = customer.Id;
            cus.Name = customer.Name;
            cus.Title = customer.Title;
            cus.Address = customer.Address;
            cus.City = customer.City;
            cus.RegionId = customer.RegionId;
            cus.PostalCode = customer.PostalCode;
            cus.Country = customer.Country;
            cus.Phone = customer.Phone;
            return await customerRepositoryAsync.InsertAsync(cus);
        }

        public async Task<int> DeleteCustomerAsync(int id)
        {
            return await customerRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<CustomerResponseModel>> GetAllAsync()
        {
            var collection = await customerRepositoryAsync.GetAllAsync();

            if (collection != null)
            {
                List<CustomerResponseModel> result = new List<CustomerResponseModel>();
                foreach (var item in collection)
                {
                    CustomerResponseModel model = new CustomerResponseModel();
                    model.Id = item.Id;
                    model.Name = item.Name;
                    model.Title = item.Title;
                    model.Address = item.Address;
                    model.City = item.City;
                    model.RegionId = item.RegionId;
                    model.PostalCode = item.PostalCode;
                    model.Country = item.Country;
                    model.Phone = item.Phone;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<CustomerResponseModel> GetByIdAsync(int id)
        {
            var item = await customerRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                CustomerResponseModel model = new CustomerResponseModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.Title = item.Title;
                model.Address= item.Address;
                model.City= item.City;
                model.RegionId = item.RegionId;
                model.PostalCode= item.PostalCode;
                model.Country= item.Country;
                model.Phone= item.Phone;
                return model;
            }
            return null;
        }

        public async Task<CustomerRequestModel> GetCustomerForEditAsync(int id)
        {
            var item = await customerRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                CustomerRequestModel model = new CustomerRequestModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.Title = item.Title;
                model.Address = item.Address;
                model.City = item.City;
                model.RegionId = item.RegionId;
                model.PostalCode = item.PostalCode;
                model.Country = item.Country;
                model.Phone = item.Phone;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateCustomerAsync(CustomerRequestModel customer)
        {
            Customer cus = new Customer();
            cus.Id = customer.Id;
            cus.Name = customer.Name;
            cus.Title = customer.Title;
            cus.Address = customer.Address;
            cus.City = customer.City;   
            cus.RegionId = customer.RegionId;   
            cus.PostalCode = customer.PostalCode;   
            cus.Country = customer.Country;
            cus.Phone = customer.Phone;
            return await customerRepositoryAsync.UpdateAsync(cus);
        }

    }
}
