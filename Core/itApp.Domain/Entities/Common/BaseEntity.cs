﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grammerGame.Domain.Entities.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        virtual public DateTime UpdatedDate { get; set; } // belki kullanmak istemeyiz diye ezilebilir yapıyoruz
    }
}
