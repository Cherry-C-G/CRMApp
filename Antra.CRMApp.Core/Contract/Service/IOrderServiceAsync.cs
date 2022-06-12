using Antra.CRMApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Core.Contract.Service
{
    public interface IOrderServiceAsync
    {
        Task<IEnumerable<OrderResponseModel>> GetAllAsync();
        Task<int> AddOrderAsync(OrderRequestModel order);
        Task<OrderResponseModel> GetByIdAsync(int id);
        Task<OrderRequestModel> GetOrderForEditAsync(int id);
        Task<int> UpdateOrderAsync(OrderRequestModel order);
        Task<int> DeleteOrderAsync(int id);
    }
}
