using Evaluacion3P.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evaluacion3P.Services;

namespace Evaluacion3P.Services
{
    public interface PaisService
    {
        public Task<List<Paises>> Obtener();
    }
}
