using CSSPEnums;
using CSSPModels;
using CSSPModels.Resources;
using CSSPServices.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

namespace CSSPServices
{
    public partial class AspNetUserService
    {
        #region Variables
        #endregion Variables

        #region Properties
        //public UserManager<ApplicationUser> _UserManager { get; private set; }
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Validation
        #endregion Validation

        #region Functions public

        //// Helper
        //public async Task<IdentityResult> CreateUser(ApplicationUser applicationUser, string Password)
        //{
        //    ApplicationUser user = new ApplicationUser() { Email = applicationUser.Email, UserName = applicationUser.Email };
        //    IdentityResult result = await _UserManager.CreateAsync(user, Password);

        //    return result;
        //}

        //// Post
        //public async Task<IdentityResult> AddFirstAspNetUserDB(AspNetUser aspNetUser)
        //{
        //    if (GetRead().Count() > 0)
        //    {
        //        aspNetUser.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.ToAddFirst_Requires_TableToBeEmpty, ModelsRes.AspNetUser, ModelsRes.AspNetUser)) };
        //        List<IdentityError> identityErrorList = new List<IdentityError>() { new IdentityError() { Code = "AddFirstAspNetUserDB", Description = string.Format(ServicesRes.ToAddFirst_Requires_TableToBeEmpty, ModelsRes.AspNetUser, ModelsRes.AspNetUser) } };
        //        return IdentityResult.Failed(identityErrorList.ToArray());
        //    }

        //    aspNetUser.ValidationResults = Validate(new ValidationContext(aspNetUser), ActionDBTypeEnum.Create);

        //    if (aspNetUser.ValidationResults.Count() > 0)
        //    {
        //        List<IdentityError> identityErrorList = new List<IdentityError>() { new IdentityError() { Code = "AddFirstAspNetUserDB", Description = aspNetUser.ValidationResults.FirstOrDefault().ErrorMessage } };
        //        return IdentityResult.Failed(identityErrorList.ToArray());
        //    }

        //    if (GetRead().Where(c => c.Email == aspNetUser.Email).Any())
        //    {
        //        aspNetUser.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.UserWithLoginEmail_AlreadyExist, aspNetUser.Email)) };
        //        List<IdentityError> identityErrorList = new List<IdentityError>() { new IdentityError() { Code = "AddFirstAspNetUserDB", Description = aspNetUser.ValidationResults.FirstOrDefault().ErrorMessage } };
        //        return IdentityResult.Failed(identityErrorList.ToArray());
        //    }

        //    ApplicationUser applicationUser = new ApplicationUser() { UserName = aspNetUser.Email, Email = aspNetUser.Email };

        //    AspNetUser aspNetUserNew = new AspNetUser();

        //    using (TransactionScope ts = new TransactionScope())
        //    {
        //        try
        //        {
        //            IdentityResult result = await CreateUser(applicationUser, aspNetUser.Password);
        //        }
        //        catch (Exception)
        //        {
        //            // nothing for now
        //        }

        //        aspNetUser.PasswordHash = applicationUser.PasswordHash;
        //        aspNetUser.SecurityStamp = applicationUser.SecurityStamp;
        //        aspNetUser.AccessFailedCount = applicationUser.AccessFailedCount;
        //        aspNetUser.Email = aspNetUser.Email;
        //        aspNetUser.UserName = aspNetUser.Email;
        //        aspNetUser.EmailConfirmed = applicationUser.EmailConfirmed;
        //        aspNetUser.Id = applicationUser.Id;
        //        aspNetUser.LockoutEnabled = applicationUser.LockoutEnabled;
        //        aspNetUser.LockoutEndDateUtc = applicationUser.LockoutEnd;
        //        aspNetUser.PhoneNumber = applicationUser.PhoneNumber;
        //        aspNetUser.PhoneNumberConfirmed = applicationUser.PhoneNumberConfirmed;
        //        aspNetUser.TwoFactorEnabled = applicationUser.TwoFactorEnabled;

        //        if (!Add(aspNetUser))
        //        {
        //            aspNetUser.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.UserWithLoginEmail_AlreadyExist, aspNetUser.Email)) };
        //            List<IdentityError> identityErrorList = new List<IdentityError>() { new IdentityError() { Code = "AddFirstAspNetUserDB", Description = aspNetUser.ValidationResults.FirstOrDefault().ErrorMessage } };
        //            return IdentityResult.Failed(identityErrorList.ToArray());
        //        }

        //        ts.Complete();
        //    }
        //    return IdentityResult.Success;
            
        //}
        //public async Task<IdentityResult> AddAspNetUserDB(AspNetUser aspNetUser, bool LoggedIn)
        //{
        //    aspNetUser.ValidationResults = Validate(new ValidationContext(aspNetUser), ActionDBTypeEnum.Create);

        //    if (aspNetUser.ValidationResults.Count() > 0)
        //    {
        //        List<IdentityError> identityErrorList = new List<IdentityError>() { new IdentityError() { Code = "AddAspNetUserDB", Description = aspNetUser.ValidationResults.FirstOrDefault().ErrorMessage } };
        //        return IdentityResult.Failed(identityErrorList.ToArray());
        //    }

        //    if (GetRead().Where(c => c.Email == aspNetUser.Email) != null)
        //    {
        //        aspNetUser.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.UserWithLoginEmail_AlreadyExist, aspNetUser.Email)) };
        //        List<IdentityError> identityErrorList = new List<IdentityError>() { new IdentityError() { Code = "AddAspNetUserDB", Description = aspNetUser.ValidationResults.FirstOrDefault().ErrorMessage } };
        //        return IdentityResult.Failed(identityErrorList.ToArray());
        //    }

        //    if (LoggedIn)
        //    {
        //            ContactService contactService = new ContactService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);
        //            Contact contactLoggedIn = contactService.GetEdit().Where(c => c.LoginEmail == User.Identity.Name).FirstOrDefault();
        //            if (contactLoggedIn == null)
        //            {
        //                aspNetUser.ValidationResults = new List<ValidationResult>() { new ValidationResult(ServicesRes.NeedToBeLoggedIn) };
        //                List<IdentityError> identityErrorList = new List<IdentityError>() { new IdentityError() { Code = "AddAspNetUserDB", Description = aspNetUser.ValidationResults.FirstOrDefault().ErrorMessage } };
        //                return IdentityResult.Failed(identityErrorList.ToArray());
        //            }
        //    }

        //    string LoginEmail = aspNetUser.Email;
        //    ApplicationUser applicationUser = new ApplicationUser() { UserName = LoginEmail };

        //    AspNetUser aspNetUserNew = new AspNetUser();

        //    using (TransactionScope ts = new TransactionScope())
        //    {
        //        try
        //        {
        //            IdentityResult result = await CreateUser(applicationUser, aspNetUser.Password);
        //        }
        //        catch (Exception)
        //        {
        //            //return new AspNetUserModel() { Error = ex.Message };
        //        }

        //        aspNetUser.PasswordHash = applicationUser.PasswordHash;
        //        aspNetUser.SecurityStamp = applicationUser.SecurityStamp;
        //        aspNetUser.AccessFailedCount = applicationUser.AccessFailedCount;
        //        aspNetUser.Email = aspNetUser.Email;
        //        aspNetUser.UserName = aspNetUser.Email;
        //        aspNetUser.EmailConfirmed = applicationUser.EmailConfirmed;
        //        aspNetUser.Id = applicationUser.Id;
        //        aspNetUser.LockoutEnabled = applicationUser.LockoutEnabled;
        //        aspNetUser.LockoutEndDateUtc = applicationUser.LockoutEnd;
        //        aspNetUser.PhoneNumber = applicationUser.PhoneNumber;
        //        aspNetUser.PhoneNumberConfirmed = applicationUser.PhoneNumberConfirmed;
        //        aspNetUser.TwoFactorEnabled = applicationUser.TwoFactorEnabled;

        //        if (!Add(aspNetUser))
        //        {
        //            aspNetUser.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.UserWithLoginEmail_AlreadyExist, aspNetUser.Email)) };
        //            List<IdentityError> identityErrorList = new List<IdentityError>() { new IdentityError() { Code = "AddFirstAspNetUserDB", Description = aspNetUser.ValidationResults.FirstOrDefault().ErrorMessage } };
        //            return IdentityResult.Failed(identityErrorList.ToArray());
        //        }

        //        ts.Complete();
        //    }
        //    return IdentityResult.Success;
        //}
        #endregion Functions public

        #region Functions private
        #endregion Functions private  
    }
}
