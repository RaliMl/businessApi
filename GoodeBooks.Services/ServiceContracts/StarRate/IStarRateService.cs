using GoodeBooks.Services.ViewModels.StarRate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodeBooks.Services.ServiceContracts.StarRate
{
    public interface IStarRateService
    {
        public int AddRating(StarRateCreateViewModel model);
    }
}
