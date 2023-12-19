﻿using System.ComponentModel.DataAnnotations;

namespace ScooterRental.DataAccess.Entities;

public interface IBaseEntity
{
    [Key]
    public int Id { get; set; }

    public Guid ExternalId { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }
}
