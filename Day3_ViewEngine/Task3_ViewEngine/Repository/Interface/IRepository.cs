using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task3_ViewEngine.Models;

namespace Task3_ViewEngine.Repository.Interface
{
    public interface IRepository<TEntity> where TEntity:IEntity
    {
        int Create(TEntity entity);
    }
}