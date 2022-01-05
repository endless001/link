﻿using System.ComponentModel.DataAnnotations;
using Identity.BusinessLogic.Shared.Dtos;
using Identity.EntityFramework.Enums;

namespace Identity.BusinessLogic.Dtos.Configuration;

public class ApiSecretsDto
{
    public ApiSecretsDto()
    {
        ApiSecrets = new List<ApiSecretDto>();
    }

    public int ApiResourceId { get; set; }

    public int ApiSecretId { get; set; }

    public string ApiResourceName { get; set; }

    [Required]
    public string Type { get; set; } = "SharedSecret";

    public List<SelectItemDto> TypeList { get; set; }

    public string Description { get; set; }

    [Required]
    public string Value { get; set; }

    public string HashType { get; set; }

    public HashType HashTypeEnum => Enum.TryParse(HashType, true, out HashType result) ? result : EntityFramework.Enums .HashType.Sha256;

    public List<SelectItemDto> HashTypes { get; set; }

    public DateTime? Expiration { get; set; }

    public int TotalCount { get; set; }

    public int PageSize { get; set; }

    public List<ApiSecretDto> ApiSecrets { get; set; }
}