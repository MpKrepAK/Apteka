﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ML.Models;

public class Preporate
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    [ForeignKey("Provider")]
    public int ProviderId { get; set; }
    public Provider Provider { get; set; }
    [ForeignKey("PreporateType")]
    public int PreporateTypeId { get; set; }
    public PreporateType PreporateType { get; set; }
    public DateTime DateOfProduction { get; set; }
    public double Cost { get; set; }
    public int Count { get; set; }
    public byte[]? Image { get; set; }
}