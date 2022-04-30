using Business.Abstract;
using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactManager : IContactManager
    {

        private readonly FruitkhaDbContext _context;

        public ContactManager(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(Contact contact)
        {
            contact.Read = 0;
            _context.Contacts.Add(contact);

            _context.SaveChanges();
        }

        public void Delete(Contact contact)
        {
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
        }

        public List<Contact> GetAll()
        {
          var contacts = _context.Contacts.ToList();
            return contacts;
        }

        public Contact GetById(int? id)
        {
          var contact = _context.Contacts.FirstOrDefault(x=>x.Id== id);
            contact.Read+=1;
            Update(contact);
            return contact;
        }

        public void Update(Contact contact)
        {
            _context.Contacts.Update(contact);
            _context.SaveChanges();
        }
    }
}
