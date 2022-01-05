using System;
using System.ComponentModel.DataAnnotations;
using Identity.EntityFramework.Enums;

namespace Identity.Administration.API.Dtos.Clients;

public class ClientSecretApiDto
{
    [Required]
    public string Type { get; set; } = "SharedSecret";

    public int Id { get; set; }

    public string Description { get; set; }

    [Required]
    public string Value { get; set; }

    public string HashType { get; set; }

    public HashType HashTypeEnum => Enum.TryParse(HashType, true, out HashType result) ? result : Identity.EntityFramework.Enums.HashType.Sha256;

    public DateTime? Expiration { get; set; }
}