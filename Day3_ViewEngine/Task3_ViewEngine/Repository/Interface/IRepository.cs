using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Day3_WebApplication.Models;

namespace Day3_WebApplication.Repository.Interface
{
    public interface IRepository<TEntity> where TEntity:IEntity
    {
        int Create(TEntity entity);
        void Edit(TEntity entity);
        TEntity GetById(int id);
    }
}