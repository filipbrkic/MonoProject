using MonoProject.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Repository.Common
{
    public interface IVehicleMakeRepository
    {
        Task<int> AddAsync(VehicleMakeDTO entity);
        Task<IEnumerable<RegistrationDTO>> GetAllAsync(ISorting sorting, IFiltering filtering, IPaging paging);
        Task<RegistrationDTO> GetAsync(Guid id);
        Task<int> UpdateAsync(RegistrationDTO entity);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(RegistrationDTO entity);
    }
}
