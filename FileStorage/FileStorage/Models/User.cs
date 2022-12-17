using System.ComponentModel.DataAnnotations;

namespace FileStorage.Models;

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime RegistDt { get; set; }
}