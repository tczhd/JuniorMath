using JuniorMath.ApplicationCore.Utilities.EntityBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Interfaces.EntityBase
{
    public interface IEntity<TEntity> where TEntity : class
    {
        Sort<TEntity> DefaultOrder { get; }

        Filter<TEntity> BuildBasicFilter(TEntity filter);

        byte[] RowVersion { get; set; }
    }
}
