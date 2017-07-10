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
    public partial class CSSPBiggerAttributeService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPBiggerAttributeService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            CSSPBiggerAttribute cSSPBiggerAttribute = validationContext.ObjectInstance as CSSPBiggerAttribute;

            if (string.IsNullOrWhiteSpace(cSSPBiggerAttribute.OtherField))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.CSSPBiggerAttributeOtherField), new[] { ModelsRes.CSSPBiggerAttributeOtherField });
            }

            // OtherField has no validation

            if (string.IsNullOrWhiteSpace(cSSPBiggerAttribute.ErrorMessage))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.CSSPBiggerAttributeErrorMessage), new[] { ModelsRes.CSSPBiggerAttributeErrorMessage });
            }

            // ErrorMessage has no validation

            if (string.IsNullOrWhiteSpace(cSSPBiggerAttribute.ErrorMessageResourceName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.CSSPBiggerAttributeErrorMessageResourceName), new[] { ModelsRes.CSSPBiggerAttributeErrorMessageResourceName });
            }

            // ErrorMessageResourceName has no validation

                //Error: Type not implemented [ErrorMessageResourceType] of type [Type]

                //Error: Type not implemented [ErrorMessageResourceType] of type [Type]

        }
        #endregion Validation

        #region Functions public
        public bool Add(CSSPBiggerAttribute cSSPBiggerAttribute)
        {
            cSSPBiggerAttribute.ValidationResults = Validate(new ValidationContext(cSSPBiggerAttribute), ActionDBTypeEnum.Create);
            if (cSSPBiggerAttribute.ValidationResults.Count() > 0) return false;

            db.CSSPBiggerAttributes.Add(cSSPBiggerAttribute);

            if (!TryToSave(cSSPBiggerAttribute)) return false;

            return true;
        }
        public bool AddRange(List<CSSPBiggerAttribute> cSSPBiggerAttributeList)
        {
            foreach (CSSPBiggerAttribute cSSPBiggerAttribute in cSSPBiggerAttributeList)
            {
                cSSPBiggerAttribute.ValidationResults = Validate(new ValidationContext(cSSPBiggerAttribute), ActionDBTypeEnum.Create);
                if (cSSPBiggerAttribute.ValidationResults.Count() > 0) return false;
            }

            db.CSSPBiggerAttributes.AddRange(cSSPBiggerAttributeList);

            if (!TryToSaveRange(cSSPBiggerAttributeList)) return false;

            return true;
        }
        public bool Delete(CSSPBiggerAttribute cSSPBiggerAttribute)
        {
            if (!db.CSSPBiggerAttributes.Where(c => c.CSSPBiggerAttributeID == cSSPBiggerAttribute.CSSPBiggerAttributeID).Any())
            {
                cSSPBiggerAttribute.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "CSSPBiggerAttribute", "CSSPBiggerAttributeID", cSSPBiggerAttribute.CSSPBiggerAttributeID.ToString())) }.AsEnumerable();
                return false;
            }

            db.CSSPBiggerAttributes.Remove(cSSPBiggerAttribute);

            if (!TryToSave(cSSPBiggerAttribute)) return false;

            return true;
        }
        public bool DeleteRange(List<CSSPBiggerAttribute> cSSPBiggerAttributeList)
        {
            foreach (CSSPBiggerAttribute cSSPBiggerAttribute in cSSPBiggerAttributeList)
            {
                if (!db.CSSPBiggerAttributes.Where(c => c.CSSPBiggerAttributeID == cSSPBiggerAttribute.CSSPBiggerAttributeID).Any())
                {
                    cSSPBiggerAttributeList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "CSSPBiggerAttribute", "CSSPBiggerAttributeID", cSSPBiggerAttribute.CSSPBiggerAttributeID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.CSSPBiggerAttributes.RemoveRange(cSSPBiggerAttributeList);

            if (!TryToSaveRange(cSSPBiggerAttributeList)) return false;

            return true;
        }
        public bool Update(CSSPBiggerAttribute cSSPBiggerAttribute)
        {
            cSSPBiggerAttribute.ValidationResults = Validate(new ValidationContext(cSSPBiggerAttribute), ActionDBTypeEnum.Update);
            if (cSSPBiggerAttribute.ValidationResults.Count() > 0) return false;

            db.CSSPBiggerAttributes.Update(cSSPBiggerAttribute);

            if (!TryToSave(cSSPBiggerAttribute)) return false;

            return true;
        }
        public bool UpdateRange(List<CSSPBiggerAttribute> cSSPBiggerAttributeList)
        {
            foreach (CSSPBiggerAttribute cSSPBiggerAttribute in cSSPBiggerAttributeList)
            {
                cSSPBiggerAttribute.ValidationResults = Validate(new ValidationContext(cSSPBiggerAttribute), ActionDBTypeEnum.Update);
                if (cSSPBiggerAttribute.ValidationResults.Count() > 0) return false;
            }
            db.CSSPBiggerAttributes.UpdateRange(cSSPBiggerAttributeList);

            if (!TryToSaveRange(cSSPBiggerAttributeList)) return false;

            return true;
        }
        public IQueryable<CSSPBiggerAttribute> GetRead()
        {
            return db.CSSPBiggerAttributes.AsNoTracking();
        }
        public IQueryable<CSSPBiggerAttribute> GetEdit()
        {
            return db.CSSPBiggerAttributes;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(CSSPBiggerAttribute cSSPBiggerAttribute)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                cSSPBiggerAttribute.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<CSSPBiggerAttribute> cSSPBiggerAttributeList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                cSSPBiggerAttributeList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
