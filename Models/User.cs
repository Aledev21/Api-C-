using System;

namespace User.Models;

public class Users
{
    public int Id { get; set; }
    
    public required string  Email {get; set;}

    public required string Password {get; set;}
}