using GoodeBooks.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Models.BaseModels
{
    public class BaseModel : IBaseEntity
    {
        public string Id { get; set; }
        public BaseModel()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
