using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ViewModels.Volumes
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
    }
}
