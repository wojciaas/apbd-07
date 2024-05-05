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

        if (!await _warehouseRepository.DoesProductExist(idProduct))
            throw new ArgumentException($"Product with id = {idProduct} does not exist!");
        
        if (!await _warehouseRepository.DoesWarehouseExist(idWarehouse))
            throw new ArgumentException($"Warehouse with id = {idProduct} does not exist!");
        
        if (!await _warehouseRepository.DoesOrderExist(idProduct, amount, createdAt))
            throw new ArgumentException($"Order with product id = {idProduct} " +
                                        $"in amount of = {amount} " +
                                        $"after {createdAt} does not exist!");

        int orderId = await _warehouseRepository.GetOrderId(idProduct, amount, createdAt);
        decimal price = await _warehouseRepository.GetProductPrice(idProduct);

        return await _warehouseRepository.AddGoods(idWarehouse, idProduct, orderId, amount, price * amount);
    }

    public async Task<int> AddGoodsByProcedure(WarehouseDTO warehouseDto)
    {
        (int idProduct, int idWarehouse, int amount, DateTime createdAt) = warehouseDto;
        
        return await _warehouseRepository.AddGoodsByProcedure(idProduct, idWarehouse, amount);
    }
}