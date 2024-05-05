using Microsoft.AspNetCore.Mvc;
using rest_api_warehouse.DTOs;
using rest_api_warehouse.Interfaces;

namespace rest_api_warehouse.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WarehouseController : ControllerBase
{
    private readonly IWarhouseService _warehouseService;

    public WarehouseController(IWarhouseService service)
    {
        _warehouseService = service;
    }

    [HttpPost]
    public async Task<IActionResult> AddGoods(WarehouseDTO warehouseDto)
    {
        try
        {
            return Ok($"Product has been added with id = {await _warehouseService.AddGoods(warehouseDto)}");
        }
        catch (Exception e)
        {
            return NotFound(e.StackTrace);
        }
    }  
}