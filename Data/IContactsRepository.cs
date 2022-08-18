using DBDemo1.Entities;

namespace DBDemo1.Data
{
    public interface IContactsRepository
    {
        void Save(Contact contactToSave);
        void Delete(int id);

        Contact GetContact(int id);

        List<Contact> GetAllContacts();

        void Update(Contact contactToUpdate,int id);

        List<Contact> GetContactsByLocation(string location);

        Contact GetContactByName(string nameToSearch);

        int GetContactCount();
    }
}
