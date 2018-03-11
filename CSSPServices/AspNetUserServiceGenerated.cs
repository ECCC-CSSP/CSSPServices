using CSSPEnums;
using CSSPModels;
using CSSPModels.Resources;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CSSPServices
{
    /// <summary>
    ///     <para>bonjour AspNetUser</para>
    /// </summary>
    public partial class AspNetUserService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public AspNetUserService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            AspNetUser aspNetUser = validationContext.ObjectInstance as AspNetUser;
            aspNetUser.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (aspNetUser.Id == "")
                {
                    aspNetUser.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AspNetUserId), new[] { "Id" });
                }

                if (!GetRead().Where(c => c.Id == aspNetUser.Id).Any())
                {
                    aspNetUser.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.AspNetUser, CSSPModelsRes.AspNetUserId, (aspNetUser.Id == null ? "" : aspNetUser.Id.ToString())), new[] { "Id" });
                }
            }

            if (!string.IsNullOrWhiteSpace(aspNetUser.Email) && aspNetUser.Email.Length > 256)
            {
                aspNetUser.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AspNetUserEmail, "256"), new[] { "Email" });
            }

            if (!string.IsNullOrWhiteSpace(aspNetUser.PasswordHash) && aspNetUser.PasswordHash.Length > 256)
            {
                aspNetUser.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AspNetUserPasswordHash, "256"), new[] { "PasswordHash" });
            }

            if (!string.IsNullOrWhiteSpace(aspNetUser.SecurityStamp) && aspNetUser.SecurityStamp.Length > 256)
            {
                aspNetUser.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AspNetUserSecurityStamp, "256"), new[] { "SecurityStamp" });
            }

            if (!string.IsNullOrWhiteSpace(aspNetUser.PhoneNumber) && aspNetUser.PhoneNumber.Length > 256)
            {
                aspNetUser.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AspNetUserPhoneNumber, "256"), new[] { "PhoneNumber" });
            }

            if (aspNetUser.LockoutEndDateUtc != null && ((DateTime)aspNetUser.LockoutEndDateUtc).Year < 1980)
            {
                aspNetUser.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.AspNetUserLockoutEndDateUtc, "1980"), new[] { CSSPModelsRes.AspNetUserLockoutEndDateUtc });
            }

            if (aspNetUser.AccessFailedCount < 0 || aspNetUser.AccessFailedCount > 10000)
            {
                aspNetUser.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.AspNetUserAccessFailedCount, "0", "10000"), new[] { "AccessFailedCount" });
            }

            if (string.IsNullOrWhiteSpace(aspNetUser.UserName))
            {
                aspNetUser.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AspNetUserUserName), new[] { "UserName" });
            }

            if (!string.IsNullOrWhiteSpace(aspNetUser.UserName) && aspNetUser.UserName.Length > 256)
            {
                aspNetUser.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AspNetUserUserName, "256"), new[] { "UserName" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                aspNetUser.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public AspNetUser GetAspNetUserWithAspNetUserID(string Id,
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<AspNetUser> aspNetUserQuery = (from c in (EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.Id == Id
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return aspNetUserQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return null;
                case EntityQueryDetailTypeEnum.EntityReport:
                    return null;
                default:
                    return null;
            }
        }
        public IQueryable<AspNetUser> GetAspNetUserList(string FilterAndOrderText = "",
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<AspNetUser> aspNetUserQuery = (from c in GetRead()
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return aspNetUserQuery;
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return null;
                case EntityQueryDetailTypeEnum.EntityReport:
                    return null;
                default:
                    return null;
            }
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(AspNetUser aspNetUser)
        {
            aspNetUser.ValidationResults = Validate(new ValidationContext(aspNetUser), ActionDBTypeEnum.Create);
            if (aspNetUser.ValidationResults.Count() > 0) return false;

            db.AspNetUsers.Add(aspNetUser);

            if (!TryToSave(aspNetUser)) return false;

            return true;
        }
        public bool Delete(AspNetUser aspNetUser)
        {
            aspNetUser.ValidationResults = Validate(new ValidationContext(aspNetUser), ActionDBTypeEnum.Delete);
            if (aspNetUser.ValidationResults.Count() > 0) return false;

            db.AspNetUsers.Remove(aspNetUser);

            if (!TryToSave(aspNetUser)) return false;

            return true;
        }
        public bool Update(AspNetUser aspNetUser)
        {
            aspNetUser.ValidationResults = Validate(new ValidationContext(aspNetUser), ActionDBTypeEnum.Update);
            if (aspNetUser.ValidationResults.Count() > 0) return false;

            db.AspNetUsers.Update(aspNetUser);

            if (!TryToSave(aspNetUser)) return false;

            return true;
        }
        public IQueryable<AspNetUser> GetRead()
        {
            return db.AspNetUsers.AsNoTracking();
        }
        public IQueryable<AspNetUser> GetEdit()
        {
            return db.AspNetUsers;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        private bool TryToSave(AspNetUser aspNetUser)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                aspNetUser.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}