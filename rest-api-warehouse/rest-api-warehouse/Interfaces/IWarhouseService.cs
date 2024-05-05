using rest_api_warehouse.DTOs;

namespace rest_api_warehouse.Interfaces;

public interface IWarhouseService
{
    public Task<int> AddGoods(WarehouseDTO warehouseDto);
}