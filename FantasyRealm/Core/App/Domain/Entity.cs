﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.App.Domain
{
    public abstract class Entity
    {
        public int Id { get; set; }

        protected Entity(int id)
        {
            Id = id;
        }

        protected Entity() { }
    }
}
