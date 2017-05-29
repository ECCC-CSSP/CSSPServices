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
    public partial class AspNetRoleService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public AspNetRoleService(LanguageEnum LanguageRequest, IPrincipal User, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, User)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            AspNetRole aspNetRole = validationContext.ObjectInstance as AspNetRole;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (string.IsNullOrWhiteSpace(aspNetRole.Id))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AspNetRoleId), new[] { ModelsRes.AspNetRoleId });
                }
            }

            if (string.IsNullOrWhiteSpace(aspNetRole.Name))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AspNetRoleName), new[] { ModelsRes.AspNetRoleName });
            }

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (!string.IsNullOrWhiteSpace(aspNetRole.Name) && aspNetRole.Name.Length > 256)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AspNetRoleName, "256"), new[] { ModelsRes.AspNetRoleName });
            }


        }
        #endregion Validation

        #region Functions public
        public bool Add(AspNetRole aspNetRole)
        {
            aspNetRole.ValidationResults = Validate(new ValidationContext(aspNetRole), ActionDBTypeEnum.Create);
            if (aspNetRole.ValidationResults.Count() > 0) return false;

            db.AspNetRoles.Add(aspNetRole);

            if (!TryToSave(aspNetRole)) return false;

            return true;
        }
        public bool AddRange(List<AspNetRole> aspNetRoleList)
        {
            foreach (AspNetRole aspNetRole in aspNetRoleList)
            {
                aspNetRole.ValidationResults = Validate(new ValidationContext(aspNetRole), ActionDBTypeEnum.Create);
                if (aspNetRole.ValidationResults.Count() > 0) return false;
            }

            db.AspNetRoles.AddRange(aspNetRoleList);

            if (!TryToSaveRange(aspNetRoleList)) return false;

            return true;
        }
        public bool Delete(AspNetRole aspNetRole)
        {
            if (!db.AspNetRoles.Where(c => c.Id == aspNetRole.Id).Any())
            {
                aspNetRole.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "AspNetRole", "Id", aspNetRole.Id.ToString())) }.AsEnumerable();
                return false;
            }

            db.AspNetRoles.Remove(aspNetRole);

            if (!TryToSave(aspNetRole)) return false;

            return true;
        }
        public bool DeleteRange(List<AspNetRole> aspNetRoleList)
        {
            foreach (AspNetRole aspNetRole in aspNetRoleList)
            {
                if (!db.AspNetRoles.Where(c => c.Id == aspNetRole.Id).Any())
                {
                    aspNetRoleList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "AspNetRole", "Id", aspNetRole.Id.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.AspNetRoles.RemoveRange(aspNetRoleList);

            if (!TryToSaveRange(aspNetRoleList)) return false;

            return true;
        }
        public bool Update(AspNetRole aspNetRole)
        {
            aspNetRole.ValidationResults = Validate(new ValidationContext(aspNetRole), ActionDBTypeEnum.Update);
            if (aspNetRole.ValidationResults.Count() > 0) return false;

            db.AspNetRoles.Update(aspNetRole);

            if (!TryToSave(aspNetRole)) return false;

            return true;
        }
        public bool UpdateRange(List<AspNetRole> aspNetRoleList)
        {
            foreach (AspNetRole aspNetRole in aspNetRoleList)
            {
                aspNetRole.ValidationResults = Validate(new ValidationContext(aspNetRole), ActionDBTypeEnum.Update);
                if (aspNetRole.ValidationResults.Count() > 0) return false;
            }
            db.AspNetRoles.UpdateRange(aspNetRoleList);

            if (!TryToSaveRange(aspNetRoleList)) return false;

            return true;
        }
        public IQueryable<AspNetRole> GetRead()
        {
            return db.AspNetRoles.AsNoTracking();
        }
        public IQueryable<AspNetRole> GetEdit()
        {
            return db.AspNetRoles;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(AspNetRole aspNetRole)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                aspNetRole.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<AspNetRole> aspNetRoleList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                aspNetRoleList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
