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
    public class OrderServiceAsync : IOrderServiceAsync
    {
        private readonly IOrderRepositoryAsync orderRepositoryAsync;


        public OrderServiceAsync(IOrderRepositoryAsync _orderRepositoryAsync)
        {
            orderRepositoryAsync = _orderRepositoryAsync;
        }

        public async Task<int> AddOrderAsync(OrderRequestModel order)
        {
            Order ord = new Order();
            ord.Id = order.Id;
            return await orderRepositoryAsync.InsertAsync(ord);
        }

        public async Task<int> DeleteOrderAsync(int id)
        {
            return await orderRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrderResponseModel>> GetAllAsync()
        {
            var collection = await orderRepositoryAsync.GetAllAsync();

            if (collection != null)
            {
                List<OrderResponseModel> result = new List<OrderResponseModel>();
                foreach (var item in collection)
                {
                    OrderResponseModel model = new OrderResponseModel();
                    model.Id = item.Id;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<OrderResponseModel> GetByIdAsync(int id)
        {
            var item = await orderRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                OrderResponseModel model = new OrderResponseModel();
                model.Id = item.Id;
                return model;
            }
            return null;
        }

        public async Task<OrderRequestModel> GetOrderForEditAsync(int id)
        {
            var item = await orderRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                OrderRequestModel model = new OrderRequestModel();
                model.Id = item.Id;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateOrderAsync(OrderRequestModel order)
        {
            Order ord = new Order();
            ord.Id = order.Id;
            return await orderRepositoryAsync.UpdateAsync(ord);
        }
    }
}

