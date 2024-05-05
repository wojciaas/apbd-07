using rest_api_warehouse.DTOs;

namespace rest_api_warehouse.Interfaces;

public interface IWarhouseService
{
    Task<int> AddGoods(WarehouseDTO warehouseDto);
    Task<int> AddGoodsByProcedure(WarehouseDTO warehouseDto);
}