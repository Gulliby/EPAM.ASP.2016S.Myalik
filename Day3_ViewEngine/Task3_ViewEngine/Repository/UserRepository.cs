using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task3_ViewEngine.Models;
using Task3_ViewEngine.Repository.Interface;

namespace Task3_ViewEngine.Repository
{
    public class UserRepository : IRepository<Person>
    {
        private static volatile UserRepository instance;
        private static readonly object syncRoot = new object();
        private static readonly object writeRoot = new object();

        public IList<Person> Persons { get; }
      
        public static UserRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new UserRepository();
                    }
                }
                return instance;
            }
        }

        private UserRepository() { Persons = new List<Person>(); }

        public int Create(Person entity)
        {
            lock (writeRoot)
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                Persons.Add(entity);
                var count = Persons.Count;
                entity.Id = count;
                return count;
            }
        }
    }
}