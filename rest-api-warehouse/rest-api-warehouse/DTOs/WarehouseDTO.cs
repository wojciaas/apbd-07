using System.ComponentModel.DataAnnotations;

namespace rest_api_warehouse.DTOs;

public record WarehouseDTO(
    [Required]
    int IdProduct, 
    [Required]
    int IdWarehouse, 
    [Required]
    [Range(1, int.MaxValue)]
    int Amount,
    [Required]
    DateTime CreatedAt
);