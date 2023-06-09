﻿using System.ComponentModel.DataAnnotations;

namespace ML.Mapper;

public class UserAuth
{
    [EmailAddress(ErrorMessage = "Неверный формат адреса электронной почты")]
    public string EMail { get; set; }
    [Required(ErrorMessage = "Все поля должны быть заполнены")]
    public string Password { get; set; }
}