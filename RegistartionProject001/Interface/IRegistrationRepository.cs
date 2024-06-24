using RegistartionProject001.Models;

namespace RegistartionProject001.Interface
{
    public interface IRegistrationRepository
    {
        Task<IEnumerable<sp_getStates>> GetStates();
        Task<IEnumerable<sp_getCity>> GetCity();
        Task<IEnumerable<sp_CityByStatus>> GetCityByStatus(int id);
        Task<bool> AddRegistration(tblUserRegistartion tblUserRegistartion);
        Task<bool> UpdateRegistration(tblUserRegistartion tblUserRegistartion);
        Task<bool> DeleteRegistration(int id);
        Task<IEnumerable<sp_getUserRegistration>> GetUserRegistrations();
        Task<sp_getUserRegistration> GetUserReigistrationById(int id);
    }
}
