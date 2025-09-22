﻿namespace NOTE.Solutions.BLL.Contracts.Product.Responses;

public class ProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<ProductUnitResponse> ProductUnits { get; set; } = [];
}
