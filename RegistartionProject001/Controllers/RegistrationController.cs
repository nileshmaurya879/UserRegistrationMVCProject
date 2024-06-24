using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RegistartionProject001.Interface;
using RegistartionProject001.Models;

namespace RegistartionProject001.Controllers
{
    public class RegistrationController : Controller
    {
        public readonly IRegistrationRepository _registrationRepository;
        public RegistrationController(IRegistrationRepository  registrationRepository) { 
            _registrationRepository = registrationRepository;
        }
        public async Task<IActionResult> Index()
        {
            int select = 0;
            var data = await _registrationRepository.GetUserRegistrations();
            var stateData = await _registrationRepository.GetStates();
            SelectList selectListItems = new SelectList(stateData, "Id", "StateName", select);
            ViewBag.stattes = selectListItems;
            return View(data);
        }

        public async Task<IActionResult> GetStates()
        {
            try
            {
                var data = await _registrationRepository.GetStates();
                return Ok(data);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<IActionResult> GetCityByStatus(int id)
        {
            try
            {
                int select = 0;
                var data = await _registrationRepository.GetCityByStatus(id);
                SelectList selectListItems = new SelectList(data, "Id", "CityName", select);
                ViewBag.city = selectListItems;
                return Ok(data);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<IActionResult> GetUserRegistrationById(int id)
        {
            try
            {
                int select = 1;
                var stateData = await _registrationRepository.GetStates();
                SelectList selectListItems = new SelectList(stateData, "Id", "StateName", select);
                ViewBag.stattes001 = null;
                ViewBag.stattes001 = selectListItems;
                var data = await _registrationRepository.GetUserReigistrationById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IActionResult> GetUserRegistrations()
        {
            try
            {
                var data = await _registrationRepository.GetUserRegistrations();
                return Ok(data);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<IActionResult> GetCity()
        {
            try
            {
                var data = await _registrationRepository.GetCity();
                return Ok(data);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddRegistration([FromBody]tblUserRegistartion tblUserRegistartion)
        {
            try
            {
                if(tblUserRegistartion != null)
                {
                    if(tblUserRegistartion.Id == 0)
                    {
                         var data = await _registrationRepository.AddRegistration(tblUserRegistartion);
                        return Ok(data);
                    }
                    else
                    {
                        var data = await _registrationRepository.UpdateRegistration(tblUserRegistartion);
                        return Ok(data);
                    }
                }
                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRegistration([FromBody]tblUserRegistartion tblUserRegistartion)
        {
            try
            {
                var data = await _registrationRepository.UpdateRegistration(tblUserRegistartion);
                return Ok(data);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteRegistration(int id)
        {
            try
            {
                var data = await _registrationRepository.DeleteRegistration(id);
                return Ok(data);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
