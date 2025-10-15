namespace ContactCatalog1.Models;

public class Contact
{
    public int Id { get; set; } 
    public string? Name { get; set; } 
    public string Email { get; set; }
    public List<string> Tags { get; set; } 

    public Contact(int id, string name, string email, List<string> tags)
    {
        Id = id;
        Name = name;
        Email = email;
        Tags = tags;
    }
}