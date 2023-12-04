using SelfBackEnd.Models;
using SelfBackEnd.Repositories.Interfaces;
using SelfBackEnd.Services.Interfaces;

namespace SelfBackEnd.Services;

public class ContactService : IContactService
{
    private readonly IBaseRepository<Contact> _contactRepository;

    public ContactService(IBaseRepository<Contact> contactRepository)
    {
        _contactRepository = contactRepository;
    }
}
