﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public abstract class EntityBase : BindableEntity
    {
        public abstract bool IsValid();

    }
}
