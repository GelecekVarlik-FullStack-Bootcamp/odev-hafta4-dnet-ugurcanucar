using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Dal.Abstract.IRepository;
using WorkManagement.Entity.Dto;
using WorkManagement.Entity.Models;
using WorkManagement.Interface.Services;

namespace WorkManagement.Bll.Managers
{
    public class RequestManager : GenericManager<Request, DtoRequest>, IRequestService
    {

        public readonly IRequestRepository requestRepository;
        public RequestManager(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            requestRepository = serviceProvider.GetService<IRequestRepository>();
        }


    }
     
}
