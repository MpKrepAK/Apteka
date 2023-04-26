﻿namespace ML.Mapper;

public class UserCard
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EMail { get; set; }
    public string Password { get; set; }
    public byte[]? Image { get; set; }
}