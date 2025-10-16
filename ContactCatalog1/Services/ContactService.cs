using ContactCatalog1.Exceptions;
using ContactCatalog1.Models;
using ContactCatalog1.Repositories;
using Microsoft.Extensions.Logging;
namespace ContactCatalog1.Services;

public class ContactService
{
    private readonly IContactRepository _contactRepository;
    private ILogger <ContactService> _logger;

    public ContactService(IContactRepository contactRepository, ILogger<ContactService> logger)
    {
        _contactRepository = contactRepository;
        _logger = logger;
    }

    public void AddContact(Contact contact)
    {
        try
        {
            _contactRepository.Add(contact);
            _logger.LogInformation("\nId: {Id}\nName: {Name}\nEmail: {Email}\nTags: {Tags}",
                contact.Id, contact.Name, contact.Email, string.Join(",", contact.Tags));
        }
        catch (InvalidEmailException e)
        {
            _logger.LogError(e.Message);
            throw;
        }
        catch (DuplicateEmailException e)
        {
            _logger.LogError(e.Message);
            throw;
        } catch(Exception ex)
        {
            _logger.LogError("error adding contact {contact}", contact);
            throw;
        }
    }
    
    public IEnumerable<Contact> GetAllContacts()
    {
        return _contactRepository.GetAll();
    }

    public Contact ?  GetContactById(int id)
    {
        return _contactRepository.GetById(id);
    }

    public IEnumerable<Contact> SearchContactByName(string name)
    {
        return _contactRepository.SearchByName(name);
    }

    public IEnumerable<Contact> FilterContactByTag(string tag)
    {
        return _contactRepository.FilterByTag(tag);
    }



}