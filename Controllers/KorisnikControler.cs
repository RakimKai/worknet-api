using Microsoft.AspNetCore.Mvc;
using System.Text;
using worknet_api.Data;
using worknet_api.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using worknet_api.Helpers.Services;
using worknet_api.Helpers.Validators;
using worknet_api.Helpers;
using worknet_api.ViewModels;
using System.Security.Cryptography;

namespace worknet_api.Controllers
{
    [Route("api/Korisnik/[action]")]
    [ApiController]
    public class KorisnikControler : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly AuthService _authService;
        private readonly GenerateToken _tokenGenerator;
        private const string SecretKey = "Dp9z2GjW8QaV7zR6TgKx5sBc3FmQ6zA1Lp7yHtG3Dv6zXp2jUs8wRhN2CgH5kFt9";
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

        public KorisnikControler(ApiContext context, AuthService authService, GenerateToken tokenGenerator)
        {
            _context = context;
            _authService = authService;
            _tokenGenerator = tokenGenerator;
        }


        [HttpPost]
        public JsonResult Create([FromBody] KorisnikCreateVM korisnik)
        {
            var usedEmail = _context.Korisnici.Any(u => u.Email == korisnik.Email);
            var validEmail = EmailValidator.IsValidEmail(korisnik.Email);
            if (usedEmail || !validEmail)
            {
                string info = validEmail ? "This email adress is already taken." : "Invalid email";
                return new JsonResult(new
                {
                    success = false,
                    message = info,
                });
            }
            else
            {
                var userSalts = Salts.GenerateSalts();
                korisnik.Password =Hashing.HashPassword(korisnik.Password, userSalts);
                var defaultLocation = _context.Locations.FirstOrDefault(x => x.Id == 1);
                var newKorisnik = new Korisnik();
                if(korisnik.ImeKompanije == string.Empty)
                {
                     newKorisnik = new Employee
                    {
                        Email = korisnik.Email,
                        FirstName = korisnik.Ime,
                        LastName = korisnik.Prezime,
                        Password = korisnik.Password,
                        Salts = userSalts,
                        Role = "Employee",
                        IsLoggedIn = true,
                        Location =  defaultLocation
                    };
                }
                else
                {
                    newKorisnik = new Company
                    {
                        Email = korisnik.Email,
                        CompanyName = korisnik.ImeKompanije,
                        Password = korisnik.Password,
                        Salts = userSalts,
                        Role = "Company",
                        IsLoggedIn = true,
                        Location = defaultLocation
                    };
                }
                _context.Korisnici.Add(newKorisnik);
                Token token = new Token
                {
                    Korisnik = newKorisnik,
                    Value = _tokenGenerator.GenerateAccessToken(newKorisnik),
                    Date = DateTime.Now
                };
                _context.Tokens.Add(token);
                _context.SaveChanges();
                return new JsonResult(new
                {
                    success = true,
                    data = newKorisnik,
                    access_token = token.Value,
                });
            }


        }

        [HttpGet]
        public JsonResult Get()
        {
            var user = _authService.GetInfo().KorisnickiNalog;
            if (user == null)
            {
                return new JsonResult(new
                {
                    success = false,
                    message = "User doesn't exist."
                });
            }

            var userInDb = _context.Korisnici
              .Include(x => x.Location)
              .Include(x => (x as Employee).Reviews).ThenInclude(x => x.Company)
              .Include(x => (x as Company).Reviews)
              .Include(x => (x as Company).Posts).ThenInclude(x => x.Industry)
              .Include(x => (x as Company).Posts).ThenInclude(x => x.EmploymentType)
              .Include(x => (x as Company).Posts).ThenInclude(x => x.Location)
              .FirstOrDefault(x => x.Id == user.Id);

            return new JsonResult(new { success = true, data = userInDb });

        }

        [HttpGet]
        public ActionResult GetById(int id)
        {
            var korisnik = _context.Korisnici
              .Include(x => x.Location)
              .Include(x => (x as Employee).Reviews).ThenInclude(x => x.Company)
              .Include(x => (x as Company).Reviews)
              .Include(x => (x as Company).Posts).ThenInclude(x=>x.Industry)
              .Include(x => (x as Company).Posts).ThenInclude(x => x.EmploymentType)
              .Include(x => (x as Company).Posts).ThenInclude(x => x.Location)
              .FirstOrDefault(x=>x.Id==id);

            if (korisnik == null){
                return BadRequest();
            }
            return Ok(korisnik);

        }


        [HttpGet]
        public JsonResult GetAll()
        {
            var users = _context.Korisnici
            .Include(x => x.Location)
            .Include(x => (x as Company).Posts)
            .Include(x => (x as Employee).Reviews)
            .ToList();

            if (users.Count() != 0)
            {

                return new JsonResult(new
                {
                    success = true,
                    data = users,
                });
            }
            else
            {
                return new JsonResult(new
                {
                    success = false,
                    message = "No users."
                });
            }

        }


        [HttpPost]
        public JsonResult Login([FromBody]KorisnikLoginVM korisnik)
        {
            var user = _context.Korisnici.FirstOrDefault(u => u.Email == korisnik.Email);

            if (user != null)
            {
                var hashedPassword = Hashing.HashPassword(korisnik.Password, user.Salts);
                if (hashedPassword == user.Password)
                {
                    if(user.IsLoggedIn)
                    {
                        return new JsonResult(new
                        {
                            success = false,
                            message = "Login failed."
                        });
                    }
                    user.IsLoggedIn = true;
                    Token token = new Token
                    {
                        Korisnik = user,
                        Value = _tokenGenerator.GenerateAccessToken(user),
                        Date = DateTime.Now
                    };
                    _context.Tokens.Add(token);
                    _context.SaveChanges();
                    return new JsonResult(new
                    {   
                        success = true,
                        access_token = token.Value
                    });
                }
                else
                {
                    return new JsonResult(new
                    {
                        success = false,
                        message = "Invalid email or password."
                    });
                }
            }
            else
            {

                return new JsonResult(new
                {
                    success = false,
                    message = "Invalid email or password."

                });
            }
        }

        [HttpPost]
        public JsonResult Logout()
        {
            Token? token = _authService.GetInfo().Token;
            if (token == null)
            {
                return new JsonResult(new
                {
                    success = false,
                    message = "User is already logged out."
                });
            }
            var user = _context.Korisnici.FirstOrDefault(u => u.Id == token.KorisnikId);
            user.IsLoggedIn = false;
            _context.Tokens.Remove(token);
            _context.SaveChanges();
            return new JsonResult(new
            {
                success = true,
                message = "User is successfully logged out."
            });
        }


        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var korisnik = _context.Korisnici.Find(id);
            if (korisnik!=null)
            {
                _context.Korisnici.Remove(korisnik);
                _context.SaveChanges();
                return new JsonResult(new
                {
                    success = true,
                    message = "User successfully deleted."
                });

            }
            else
            {
                return new JsonResult(new
                {
                    success = false,
                    message = "User doesn't exist."
                });

            }
        }

        [HttpPut]
        public JsonResult Edit([FromBody] KorisnikEditVM editedUser)
        {
            var userInDb = _authService.GetInfo().KorisnickiNalog;
            if (userInDb == null)
            {
                return new JsonResult(new
                {
                    success = false,
                    message = "User is logged out."
                });
            }
            userInDb.About = editedUser.About;
            userInDb.Image = editedUser.Image;
            userInDb.PhoneNumber = editedUser.PhoneNumber;
            var location = _context.Locations.Where(x => x.Id == editedUser.Location.Id).FirstOrDefault(); 
            userInDb.Location = location;
            if (userInDb.Role == "Employee")
            {
                var employee = _context.Employees.FirstOrDefault(x=>x.Id==userInDb.Id);
                employee.University = editedUser.University;
                employee.WorkedAt = editedUser.WorkedAt;
            }
            else
            {
                var company = _context.Companies.FirstOrDefault(x => x.Id == userInDb.Id);
                company.CompanyOwner = editedUser.Owner;
            }
            _context.Update(userInDb);
            _context.SaveChanges();
            return new JsonResult(new
            {
                success = true,
                message = "User successfully edited."
            });
        }


        [HttpPost]
        public IActionResult ValidateToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            Token token = _authService.GetInfo().Token;
            if(token!= null) 
            {
                tokenHandler.ValidateToken(token.Value, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = _signingKey,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return Ok(new { isValid = true });
            }
            else
            {
                return Ok(new { isValid = false });
            }
        }


    }
}
