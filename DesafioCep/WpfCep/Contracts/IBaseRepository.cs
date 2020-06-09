using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCep.Contracts
{
    public interface IBaseRepository<T>
        where T: class
    {
        void Insert(T obj);

        List<T> SelectAll();

        
    }
}
