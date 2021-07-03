using MonoProject.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Service.Common
{
    public interface IVehicleModelService
    {
        Task<IEnumerable<VehicleModelDTO>> GetAllAsync(ISorting sorting, IFiltering filtering, IPaging paging);
        Task<int> AddAsync(RegistrationDTO entity);
        Task<RegistrationDTO> GetAsync(Guid id);
        Task<int> UpdateAsync(RegistrationDTO entity);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(RegistrationDTO entity);
    }
}
