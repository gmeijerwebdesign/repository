using System.Linq;
using System.Web.Http;
using Premium_Data.Models;

namespace Premium_Data.Controllers
{
    public class ApiLoginController : ApiController
    {
        private Cyclus_DataEntities db = new Cyclus_DataEntities();

        [HttpPost]
        [Route("api/login")]  // Attribute routing werkt omdat we config.MapHttpAttributeRoutes() aanzetten
        public IHttpActionResult Login([FromBody] LoginRequest login)
        {
            if (login == null || string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password))
            {
                return BadRequest("Gebruikersnaam en wachtwoord zijn verplicht.");
            }

            var user = db.tbl_Medewerkers
                .FirstOrDefault(u => u.INLOG_GEBRUIKERSNAAM == login.Username && u.INLOG_WACHTWOORD == login.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            if (!user.INLOG_ACTIEF)
            {
                return Content(System.Net.HttpStatusCode.Forbidden, "Gebruiker is niet actief.");
            }

            return Ok(new
            {
                userId = user.MEDEWERKER_ID,
                username = user.INLOG_GEBRUIKERSNAAM,
                role = user.INLOG_LEVEL
            });
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
