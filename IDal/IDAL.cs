using Entity;
using System;
using System.Collections.Generic;

namespace Engine
{
    public interface IDAL
    {
        T Read<T>();
        T Read<T>(object pkValue);
        IEnumerable<T> ReadAll<T>();
        List<string> Update(EntityBase entity);

    }
}