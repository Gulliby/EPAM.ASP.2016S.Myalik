using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using WebApplication.Models;
using WebApplication.Repository.Interface;

namespace WebApplication.Repository
{
    public class UserRepository : IRepository<User>
    {
        private static volatile UserRepository instance;
        private static readonly object instanceRoot = new object();
        private readonly ReaderWriterLockSlim readWriteLock = new ReaderWriterLockSlim();
        private readonly List<User> users;

        public IEnumerable<User> Users => users.ToArray();

        public static UserRepository Instance
        {
            get
            {
                if (instance != null) return instance;
                lock (instanceRoot)
                {
                    if (instance == null)
                        instance = new UserRepository();
                }
                return instance;
            }
        }

        private UserRepository() { users = new List<User>(); }

        public int Create(User entity)
        {
            readWriteLock.EnterWriteLock();
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                var count = users.Count + 1;
                entity.Id = count;
                users.Add(entity);
                return count;
            }
            finally
            {
                readWriteLock.ExitWriteLock();
            }
        }

        public void Edit(User entity)
        {
            readWriteLock.EnterWriteLock();
            try
            {
                var index = users.FindIndex(e => e.Id == entity.Id);
                users[index] = entity;
            }
            finally
            {
                readWriteLock.ExitWriteLock();
            }
        }

        public User GetById(int id)
        {
            readWriteLock.EnterReadLock();
            try
            {
                return users.FirstOrDefault(e => e.Id == id);
            }
            finally
            {
                readWriteLock.ExitReadLock();
            }
        }

        public void Delete(int id)
        {
            readWriteLock.EnterReadLock();
            try
            {
                var temp = users.FirstOrDefault(entity => entity.Id == id);
                users.Remove(temp);
            }
            finally
            {
                readWriteLock.ExitReadLock();
            }
        }
    }
}