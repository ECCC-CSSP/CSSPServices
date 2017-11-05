//using CSSPEnums;
//using CSSPModels;
//using CSSPModels.Resources;
//using CSSPServices.Resources;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Net.Mail;
//using System.Security.Principal;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;
//using System.Transactions;
//using System.IdentityModel.Tokens.Jwt;
//using Microsoft.IdentityModel.Tokens;
//using System.Security.Claims;

//namespace CSSPServices
//{
//    public partial class ContactLoginService
//    {
//        #region Variables
//        #endregion Variables

//        #region Properties
//        #endregion Properties

//        #region Constructors
//        // done in other partial ContactLoginServiceGenerated
//        #endregion Constructors

//        #region Functions public
//        public ContactLogin GetContactLoginWithLogin(string loginEmail, string password)
//        {
//            ContactLogin contactLogin = new ContactLogin();
//            byte[] passwordHash, passwordSalt;
//            CreatePasswordHash(password, out passwordHash, out passwordSalt);

//            contactLogin = GetRead().Where(c => c.LoginEmail == loginEmail && c.PasswordHash == passwordHash && c.PasswordSalt == passwordSalt).FirstOrDefault();

//            if (contactLogin != null)
//            {
//                contactLogin.PasswordHash = null;
//                contactLogin.PasswordSalt = null;
//            }

//            return contactLogin;
//        }
//        public ContactLogin CreateContactLogin(Register register)
//        {
//            ContactLogin contactLogin = new ContactLogin();
//            byte[] passwordHash, passwordSalt;
//            CreatePasswordHash(register.Password, out passwordHash, out passwordSalt);

//            contactLogin = GetRead().Where(c => c.LoginEmail == register.LoginEmail && c.PasswordHash == passwordHash && c.PasswordSalt == passwordSalt).FirstOrDefault();

//            if (contactLogin != null)
//            {
//                contactLogin.PasswordHash = null;
//                contactLogin.PasswordSalt = null;
//                contactLogin.HasErrors = true;
//                contactLogin.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes._AlreadyExists, register.LoginEmail)) }.AsEnumerable();
//                return contactLogin;
//            }

//            if (string.IsNullOrWhiteSpace(register.Password))
//            {
//                contactLogin.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPServicesRes.Password)) }.AsEnumerable();
//                return contactLogin;
//            }

//            if (_context.Users.Any(x => x.Username == user.Username))
//                throw new AppException("Username " + user.Username + " is already taken");

//            byte[] passwordHash, passwordSalt;
//            CreatePasswordHash(password, out passwordHash, out passwordSalt);

//            user.PasswordHash = passwordHash;
//            user.PasswordSalt = passwordSalt;

//            _context.Users.Add(user);
//            _context.SaveChanges();

//            return contactLogin;
//        }
//        #endregion Functions public

//        #region Functions private
//        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
//        {
//            if (password == null) throw new ArgumentNullException("password");
//            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

//            using (var hmac = new System.Security.Cryptography.HMACSHA512())
//            {
//                passwordSalt = hmac.Key;
//                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
//            }
//        }
//        private IQueryable<ContactLogin> FillContactLoginReport(IQueryable<ContactLogin> contactLoginQuery, string FilterAndOrderText)
//        {
//            contactLoginQuery = (from c in contactLoginQuery
//                                 let LastUpdateContactTVText = (from cl in db.TVItemLanguages
//                                                                where cl.TVItemID == c.LastUpdateContactTVItemID
//                                                                && cl.Language == LanguageRequest
//                                                                select cl.TVText).FirstOrDefault()
//                                 select new ContactLogin
//                                 {
//                                     ContactLoginID = c.ContactLoginID,
//                                     ContactID = c.ContactID,
//                                     LoginEmail = c.LoginEmail,
//                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
//                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
//                                     ContactLoginWeb = new ContactLoginWeb
//                                     {
//                                         LastUpdateContactTVText = LastUpdateContactTVText,
//                                     },
//                                     ContactLoginReport = null,
//                                     HasErrors = false,
//                                     ValidationResults = null,
//                                 });

//            return contactLoginQuery;
//        }

//        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
//        {
//            if (password == null) throw new ArgumentNullException("password");
//            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
//            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
//            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

//            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
//            {
//                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
//                for (int i = 0; i < computedHash.Length; i++)
//                {
//                    if (computedHash[i] != storedHash[i]) return false;
//                }
//            }

//            return true;
//        }
//        #endregion Functions private
//    }
//}
