using rest_api_warehouse.DTOs;

namespace rest_api_warehouse.Interfaces;

public interface IWarehouseRepository
{
    Task<bool> DoesProductExist(int id);
    Task<bool> DoesWarehouseExist(int id);
    Task<bool> DoesOrderExist(int id, int amount, DateTime createdAt);
    Task<int> GetOrderId(int id, int amount, DateTime createdAt);
    Task<decimal> GetProductPrice(int id);
    Task<int> AddGoods(int idWarehouse, int idProduct, int idOrder, int amount, decimal price);
    Task<int> AddGoodsByProcedure(int idProduct, int idWarehouse, int amount);
}