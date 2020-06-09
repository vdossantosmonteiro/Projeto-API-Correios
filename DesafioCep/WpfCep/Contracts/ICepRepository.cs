using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCep.Entities;

namespace WpfCep.Contracts
{
    public interface ICepRepository : IBaseRepository<Cep>
    {
        Cep SelectCep(string numCep);
    }
}
