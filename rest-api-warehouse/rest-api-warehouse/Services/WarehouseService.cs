using rest_api_warehouse.DTOs;
using rest_api_warehouse.Interfaces;

namespace rest_api_warehouse.Services;

public class WarehouseService : IWarhouseService
{
    private readonly IWarehouseRepository _warehouseRepository;

    public WarehouseService(IWarehouseRepository repository)
    {
        _warehouseRepository = repository;
    }
    
    public async Task<int> AddGoods(WarehouseDTO warehouseDto)
    {
        (int idProduct, int idWarehouse, int amount, DateTime createdAt) = warehouseDto;

        if (!_warehouseRepository.DoesProductExist(idProduct).Result)
            throw new ArgumentException($"Product with id = {idProduct} does not exist!");
        
        if (!_warehouseRepository.DoesWarehouseExist(idWarehouse).Result)
            throw new ArgumentException($"Warehouse with id = {idProduct} does not exist!");
        
        if (!_warehouseRepository.DoesOrderExist(idProduct, amount, createdAt).Result)
            throw new ArgumentException($"Order with product id = {idProduct} " +
                                        $"in amount of = {amount} " +
                                        $"after {createdAt} does not exist!");

        int orderId = _warehouseRepository.GetOrderId(idProduct, amount, createdAt).Result;
        decimal price = _warehouseRepository.GetProductPrice(idProduct).Result;

        return await _warehouseRepository.AddGoods(idWarehouse, idProduct, orderId, amount, price * amount);
    }
}