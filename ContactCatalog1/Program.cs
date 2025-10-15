using ContactCatalog1.Models;
namespace ContactCatalog1;

class Program
{
    static void Main(string[] args)
    {

        var newContact =
            new Contact(101, "Coday awahmed", "Coday@gmail.com", new List<string>{"gym,friend"});
            
        Console.WriteLine($"\n{newContact.Id}\n{newContact.Name}\n{newContact.Email}\n{string.Join(", ", newContact.Tags)}");

        /*
          while (true)
          {
              Console.WriteLine("==== Contact Catalog ====");
              Console.WriteLine("\n1)Add new contact\n2)List contacts\n3)Search by name\n4)Filter by tag\n5)Export CSV\n0)Exit");
              string? choose = Console.ReadLine();
              break;
          }
         */
    }
}