using ContactCatalog1.Exceptions;
using ContactCatalog1.Models;

namespace ContactCatalog1.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly Dictionary<int, Contact> _byId = new();
    private readonly HashSet<string> _emails = new(StringComparer.OrdinalIgnoreCase);

    //Add a new contact
    public void Add(Contact contact)
    {
        if (!IsInvalid(contact.Email)) 
            throw new InvalidCastException(contact.Email);
        
        if(!_emails.Add(contact.Email))
            throw new DuplicateEmailException(contact.Email);
        
        _byId.Add(contact.Id, contact);
    }
    
    //get all contacts from the dictionary 
    public IEnumerable<Contact> GetAll() => _byId.Values;

    //get contact by id 
    public Contact ? GetById(int id) => 
        _byId.TryGetValue(id, out var contact) ? contact : null;

    //get contacts by name search 
    public IEnumerable<Contact> SearchByName(string name) =>
        _byId
            .Values.Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

    //get contacts by tag
    public IEnumerable<Contact> FilterByTag(string tag) =>
        _byId.Values.Where(c => c.Tags.Contains(tag, StringComparer.OrdinalIgnoreCase)).OrderBy(c => c.Name);
    
    //method to validate email
    private bool IsInvalid(string email)
    {
        return System.Text.RegularExpressions.Regex.IsMatch(
            email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }
}