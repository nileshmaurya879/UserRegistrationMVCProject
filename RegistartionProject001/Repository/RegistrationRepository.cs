using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RegistartionProject001.Interface;
using RegistartionProject001.Models;

namespace RegistartionProject001.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        public readonly RegistrationDBContext _registrationDBContext;
        public RegistrationRepository(RegistrationDBContext registrationDBContext) {
            _registrationDBContext = registrationDBContext;
        }

        public async Task<IEnumerable<sp_getStates>> GetStates()
        {
            var data = await _registrationDBContext.sp_getStates.FromSqlRaw(@"sp_getStates").ToListAsync();
            return data;
        }
        public async Task<IEnumerable<sp_CityByStatus>> GetCityByStatus(int id)
        {
           SqlParameter sqlParameters = new SqlParameter("@id", id);
            var data = await _registrationDBContext.sp_CityByStatus.FromSqlRaw(@"sp_getCityByStatus @id", sqlParameters).ToListAsync();
            return data;
        }
        public async Task<sp_getUserRegistration> GetUserReigistrationById(int id)
        {
            SqlParameter sqlParameters = new SqlParameter("@id", id);
            var data = await _registrationDBContext.sp_getUserRegistration.FromSqlRaw(@"sp_getUserRegistrationById @id", sqlParameters).ToListAsync();
            return data.FirstOrDefault();
        }
        public async Task<IEnumerable<sp_getCity>> GetCity()
        {
            var data = await _registrationDBContext.sp_getCity.FromSqlRaw(@"sp_getCity").ToListAsync();
            return data;
        }
        public async Task<IEnumerable<sp_getUserRegistration>> GetUserRegistrations()
        {
            var data = await _registrationDBContext.sp_getUserRegistration.FromSqlRaw(@"sp_getUserRegistration").ToListAsync();
            return data;
        }
        public async Task<bool> AddRegistration(tblUserRegistartion tblUserRegistartion)
        {
            List<SqlParameter> sqlParameter = new List<SqlParameter>
            {
                new SqlParameter("@name", tblUserRegistartion.Name),
                new SqlParameter("@email", tblUserRegistartion.Email),
                new SqlParameter("@phone", tblUserRegistartion.Phone),
                new SqlParameter("@address", tblUserRegistartion.Address),
                new SqlParameter("@stateid", tblUserRegistartion.SateId),
                new SqlParameter("@cityid", tblUserRegistartion.CityId)
            };

            await _registrationDBContext.Database.ExecuteSqlRawAsync(@"sp_AddRegistration @name, @email, @phone, @address,@stateid,@cityid", sqlParameter.ToArray());
            await _registrationDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateRegistration(tblUserRegistartion tblUserRegistartion)
        {
            List<SqlParameter> sqlParameter = new List<SqlParameter>
            {
                new SqlParameter("@id", tblUserRegistartion.Id),
                new SqlParameter("@name", tblUserRegistartion.Name),
                new SqlParameter("@email", tblUserRegistartion.Email),
                new SqlParameter("@phone", tblUserRegistartion.Phone),
                new SqlParameter("@address", tblUserRegistartion.Address),
                new SqlParameter("@stateid", tblUserRegistartion.SateId),
                new SqlParameter("@cityid", tblUserRegistartion.CityId)
            };

            await _registrationDBContext.Database.ExecuteSqlRawAsync(@"sp_UpdateRegistration @id, @name, @email, @phone, @address,@stateid,@cityid", sqlParameter.ToArray());
            await _registrationDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteRegistration(int id)
        {
            List<SqlParameter> sqlParameter = new List<SqlParameter>
            {
                new SqlParameter("@id", id)
            };

            await _registrationDBContext.Database.ExecuteSqlRawAsync(@"sp_DeleteRegistration @id", sqlParameter.ToArray());
            await _registrationDBContext.SaveChangesAsync();
            return true;
        }
    }
}
