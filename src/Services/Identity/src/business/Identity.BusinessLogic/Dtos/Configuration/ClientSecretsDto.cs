﻿using System.ComponentModel.DataAnnotations;
using Identity.BusinessLogic.Shared.Dtos;
using Identity.EntityFramework.Enums;

namespace Identity.BusinessLogic.Dtos.Configuration;

public class ClientSecretsDto
{
    public ClientSecretsDto()
    {
        ClientSecrets = new List<ClientSecretDto>();
    }

    public int ClientId { get; set; }

    public string ClientName { get; set; }

    public int ClientSecretId { get; set; }

    [Required]
    public string Type { get; set; } = "SharedSecret";

    public List<SelectItemDto> TypeList { get; set; }

    public string Description { get; set; }

    [Required]
    public string Value { get; set; }

    public string HashType { get; set; }

    public HashType HashTypeEnum => Enum.TryParse(HashType, true, out HashType result) ? result : EntityFramework.Enums.HashType.Sha256;

    public List<SelectItemDto> HashTypes { get; set; }

    public DateTime? Expiration { get; set; }

    public int TotalCount { get; set; }

    public int PageSize { get; set; }

    public List<ClientSecretDto> ClientSecrets { get; set; }
}