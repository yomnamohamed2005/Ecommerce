using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.entities
{
 public  class BaseEntity<TKey>
    {
        public TKey  id { get; set; }
    }
}
