using System;
using System.Collections.Generic;
using System.Text;

namespace CursoIdiomas.Infrastructure.Data.Factories
{
    public interface IIdFactory<TKey>
    {
        TKey GenereteId();
    }
}
