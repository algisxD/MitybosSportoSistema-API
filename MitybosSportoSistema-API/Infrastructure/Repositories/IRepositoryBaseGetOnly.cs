﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitybosSportoSistema_API.Contracts
{
    public interface IRepositoryBaseGetOnly<T> where T : class
    {
        Task<ICollection<T>> FindAll();
        Task<T> FindById(int id);
    }
}
