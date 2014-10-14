using DonAR.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donar.Data.Definition
{
    public class IGenericRepository
    {
        IEnumerable<T> GetAll<T>() where T : Entity;
        T Get<T>(int id) where T : Entity;
        T Persist<T>(T entity) where T : Entity;
        void Persist<T>(IEnumerable<T> entities) where T : Entity;
    }
}
