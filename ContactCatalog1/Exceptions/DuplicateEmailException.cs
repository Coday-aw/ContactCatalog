namespace ContactCatalog1.Exceptions;

public class DuplicateEmailException : Exception
{
    public DuplicateEmailException(string email) : base($"Duplicate email: {email}") { } 
}