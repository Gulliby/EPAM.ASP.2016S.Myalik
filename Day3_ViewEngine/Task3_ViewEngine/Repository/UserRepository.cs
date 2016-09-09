using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Day3_WebApplication.Models;
using Day3_WebApplication.Repository.Interface;

namespace Day3_WebApplication.Repository
{
    public class UserRepository : IRepository<Person>
    {
        private static volatile UserRepository instance;
        private static readonly object syncRoot = new object();
        private static readonly object writeRoot = new object();
        private readonly List<Person> persons;

        public IEnumerable<Person> Persons => persons.ToArray();

        public static UserRepository Instance
        {
            get
            {
                if (instance != null) return instance;
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new UserRepository();
                }
                return instance;
            }
        }

        private UserRepository() { persons = new List<Person>(); }

        public int Create(Person entity)
        {
            lock (writeRoot)
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                var count = persons.Count + 1;
                entity.Id = count;
                persons.Add(entity);
                return count;
            }
        }

        public void Edit(Person entity)
        {
            lock (writeRoot)
            {
                var index = persons.FindIndex(e => e.Id == entity.Id);
                persons[index] = entity;
            }
        }

        public Person GetById(int id)
        {
            return persons.FirstOrDefault(e => e.Id == id);
        }
    }
}