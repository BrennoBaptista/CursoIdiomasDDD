using System;
using System.Collections.Generic;
using System.Text;

namespace CursoIdiomas.Infrastructure.Data.Factories
{
    public class GuidFactory : IIdFactory<Guid>
    {
        public Guid GenereteId()
        {
            return Guid.NewGuid();
        }
    }
}
