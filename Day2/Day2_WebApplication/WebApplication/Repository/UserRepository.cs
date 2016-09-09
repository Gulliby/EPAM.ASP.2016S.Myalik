using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;
using WebApplication.Repository.Interface;

namespace WebApplication.Repository
{
    public class UserRepository : IRepository<User>
    {
        private static volatile UserRepository instance;
        private static readonly object syncRoot = new object();
        private static readonly object readRoot = new object();

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

        public IList<User> Users { get; }

        public UserRepository() : this(new List<User>()) { }

        public UserRepository(IList<User> users)
        {
            if(users == null)
                throw new ArgumentNullException(nameof(users));
            Users = users;
        }

        public int Create(User entity)
        {
            lock (readRoot)
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                Users.Add(entity);
            }
            return Users.Count;
        }
    }
}