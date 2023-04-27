﻿using System.ComponentModel.DataAnnotations;

namespace ML.Models;

public class Adress
{
    [Key] 
    public int Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
}