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
    public partial class CSSPTypeAttributeService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPTypeAttributeService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            CSSPTypeAttribute cSSPTypeAttribute = validationContext.ObjectInstance as CSSPTypeAttribute;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
            }

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            // ErrorMessage no min or max length set
            // ErrorMessageResourceName no min or max length set
                ErrorMessageResourceType = GetRandomSomethingElse(),

        }
        #endregion Validation

        #region Functions public
        public bool Add(CSSPTypeAttribute cSSPTypeAttribute)
        {
            cSSPTypeAttribute.ValidationResults = Validate(new ValidationContext(cSSPTypeAttribute), ActionDBTypeEnum.Create);
            if (cSSPTypeAttribute.ValidationResults.Count() > 0) return false;

            db.CSSPTypeAttributes.Add(cSSPTypeAttribute);

            if (!TryToSave(cSSPTypeAttribute)) return false;

            return true;
        }
        public bool AddRange(List<CSSPTypeAttribute> cSSPTypeAttributeList)
        {
            foreach (CSSPTypeAttribute cSSPTypeAttribute in cSSPTypeAttributeList)
            {
                cSSPTypeAttribute.ValidationResults = Validate(new ValidationContext(cSSPTypeAttribute), ActionDBTypeEnum.Create);
                if (cSSPTypeAttribute.ValidationResults.Count() > 0) return false;
            }

            db.CSSPTypeAttributes.AddRange(cSSPTypeAttributeList);

            if (!TryToSaveRange(cSSPTypeAttributeList)) return false;

            return true;
        }
        public bool Delete(CSSPTypeAttribute cSSPTypeAttribute)
        {
            if (!db.CSSPTypeAttributes.Where(c => c.CSSPTypeAttributeID == cSSPTypeAttribute.CSSPTypeAttributeID).Any())
            {
                cSSPTypeAttribute.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "CSSPTypeAttribute", "CSSPTypeAttributeID", cSSPTypeAttribute.CSSPTypeAttributeID.ToString())) }.AsEnumerable();
                return false;
            }

            db.CSSPTypeAttributes.Remove(cSSPTypeAttribute);

            if (!TryToSave(cSSPTypeAttribute)) return false;

            return true;
        }
        public bool DeleteRange(List<CSSPTypeAttribute> cSSPTypeAttributeList)
        {
            foreach (CSSPTypeAttribute cSSPTypeAttribute in cSSPTypeAttributeList)
            {
                if (!db.CSSPTypeAttributes.Where(c => c.CSSPTypeAttributeID == cSSPTypeAttribute.CSSPTypeAttributeID).Any())
                {
                    cSSPTypeAttributeList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "CSSPTypeAttribute", "CSSPTypeAttributeID", cSSPTypeAttribute.CSSPTypeAttributeID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.CSSPTypeAttributes.RemoveRange(cSSPTypeAttributeList);

            if (!TryToSaveRange(cSSPTypeAttributeList)) return false;

            return true;
        }
        public bool Update(CSSPTypeAttribute cSSPTypeAttribute)
        {
            cSSPTypeAttribute.ValidationResults = Validate(new ValidationContext(cSSPTypeAttribute), ActionDBTypeEnum.Update);
            if (cSSPTypeAttribute.ValidationResults.Count() > 0) return false;

            db.CSSPTypeAttributes.Update(cSSPTypeAttribute);

            if (!TryToSave(cSSPTypeAttribute)) return false;

            return true;
        }
        public bool UpdateRange(List<CSSPTypeAttribute> cSSPTypeAttributeList)
        {
            foreach (CSSPTypeAttribute cSSPTypeAttribute in cSSPTypeAttributeList)
            {
                cSSPTypeAttribute.ValidationResults = Validate(new ValidationContext(cSSPTypeAttribute), ActionDBTypeEnum.Update);
                if (cSSPTypeAttribute.ValidationResults.Count() > 0) return false;
            }
            db.CSSPTypeAttributes.UpdateRange(cSSPTypeAttributeList);

            if (!TryToSaveRange(cSSPTypeAttributeList)) return false;

            return true;
        }
        public IQueryable<CSSPTypeAttribute> GetRead()
        {
            return db.CSSPTypeAttributes.AsNoTracking();
        }
        public IQueryable<CSSPTypeAttribute> GetEdit()
        {
            return db.CSSPTypeAttributes;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(CSSPTypeAttribute cSSPTypeAttribute)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                cSSPTypeAttribute.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<CSSPTypeAttribute> cSSPTypeAttributeList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                cSSPTypeAttributeList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
