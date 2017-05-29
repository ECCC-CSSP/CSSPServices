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
    public partial class AspNetUserRoleService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public AspNetUserRoleService(LanguageEnum LanguageRequest, IPrincipal User, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, User)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            AspNetUserRole aspNetUserRole = validationContext.ObjectInstance as AspNetUserRole;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (string.IsNullOrWhiteSpace(aspNetUserRole.UserId))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AspNetUserRoleUserId), new[] { ModelsRes.AspNetUserRoleUserId });
                }
                if (string.IsNullOrWhiteSpace(aspNetUserRole.RoleId))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AspNetUserRoleRoleId), new[] { ModelsRes.AspNetUserRoleRoleId });
                }
            }

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------


        }
        #endregion Validation

        #region Functions public
        public bool Add(AspNetUserRole aspNetUserRole)
        {
            aspNetUserRole.ValidationResults = Validate(new ValidationContext(aspNetUserRole), ActionDBTypeEnum.Create);
            if (aspNetUserRole.ValidationResults.Count() > 0) return false;

            db.AspNetUserRoles.Add(aspNetUserRole);

            if (!TryToSave(aspNetUserRole)) return false;

            return true;
        }
        public bool AddRange(List<AspNetUserRole> aspNetUserRoleList)
        {
            foreach (AspNetUserRole aspNetUserRole in aspNetUserRoleList)
            {
                aspNetUserRole.ValidationResults = Validate(new ValidationContext(aspNetUserRole), ActionDBTypeEnum.Create);
                if (aspNetUserRole.ValidationResults.Count() > 0) return false;
            }

            db.AspNetUserRoles.AddRange(aspNetUserRoleList);

            if (!TryToSaveRange(aspNetUserRoleList)) return false;

            return true;
        }
        public bool Delete(AspNetUserRole aspNetUserRole)
        {
            if (!db.AspNetUserRoles.Where(c => c.UserId == aspNetUserRole.UserId).Any())
            {
                aspNetUserRole.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "AspNetUserRole", "UserId", aspNetUserRole.UserId.ToString())) }.AsEnumerable();
                return false;
            }

            db.AspNetUserRoles.Remove(aspNetUserRole);

            if (!TryToSave(aspNetUserRole)) return false;

            return true;
        }
        public bool DeleteRange(List<AspNetUserRole> aspNetUserRoleList)
        {
            foreach (AspNetUserRole aspNetUserRole in aspNetUserRoleList)
            {
                if (!db.AspNetUserRoles.Where(c => c.UserId == aspNetUserRole.UserId).Any())
                {
                    aspNetUserRoleList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "AspNetUserRole", "UserId", aspNetUserRole.UserId.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.AspNetUserRoles.RemoveRange(aspNetUserRoleList);

            if (!TryToSaveRange(aspNetUserRoleList)) return false;

            return true;
        }
        public bool Update(AspNetUserRole aspNetUserRole)
        {
            aspNetUserRole.ValidationResults = Validate(new ValidationContext(aspNetUserRole), ActionDBTypeEnum.Update);
            if (aspNetUserRole.ValidationResults.Count() > 0) return false;

            db.AspNetUserRoles.Update(aspNetUserRole);

            if (!TryToSave(aspNetUserRole)) return false;

            return true;
        }
        public bool UpdateRange(List<AspNetUserRole> aspNetUserRoleList)
        {
            foreach (AspNetUserRole aspNetUserRole in aspNetUserRoleList)
            {
                aspNetUserRole.ValidationResults = Validate(new ValidationContext(aspNetUserRole), ActionDBTypeEnum.Update);
                if (aspNetUserRole.ValidationResults.Count() > 0) return false;
            }
            db.AspNetUserRoles.UpdateRange(aspNetUserRoleList);

            if (!TryToSaveRange(aspNetUserRoleList)) return false;

            return true;
        }
        public IQueryable<AspNetUserRole> GetRead()
        {
            return db.AspNetUserRoles.AsNoTracking();
        }
        public IQueryable<AspNetUserRole> GetEdit()
        {
            return db.AspNetUserRoles;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(AspNetUserRole aspNetUserRole)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                aspNetUserRole.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<AspNetUserRole> aspNetUserRoleList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                aspNetUserRoleList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
