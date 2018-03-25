using System;

public class Product
{
    public int ID { get; set; }

    public string Name { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}