using ContactCatalog1.Models;

namespace ContactCatalog1.Repositories;

public interface IContactRepository
{
    void Add(Contact contact);
    IEnumerable<Contact> GetAll();
    Contact ? GetById(int id);
    IEnumerable<Contact> SearchByName(string name);
    IEnumerable<Contact> FilterByTag(string tag);
}