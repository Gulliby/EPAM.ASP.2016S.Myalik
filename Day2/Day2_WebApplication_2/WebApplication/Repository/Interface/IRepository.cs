using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.Interface;

namespace WebApplication.Repository.Interface
{
    public interface IRepository<TEntity> where TEntity:IEntity
    {
        int Create(TEntity entity);
        void Edit(TEntity entity);
        TEntity GetById(int id);
        void Delete(int id);
    }
}