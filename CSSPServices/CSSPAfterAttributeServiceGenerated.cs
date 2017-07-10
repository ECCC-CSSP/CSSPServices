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
    public partial class CSSPAfterAttributeService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPAfterAttributeService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
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
            CSSPAfterAttribute cSSPAfterAttribute = validationContext.ObjectInstance as CSSPAfterAttribute;

            //Year (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

                Year = CreateValidationNotRequiredLengths_ConditionShouldNotHappenIn_Int,

            if (string.IsNullOrWhiteSpace(cSSPAfterAttribute.ErrorMessage))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.CSSPAfterAttributeErrorMessage), new[] { ModelsRes.CSSPAfterAttributeErrorMessage });
            }

            // ErrorMessage has no validation

            if (string.IsNullOrWhiteSpace(cSSPAfterAttribute.ErrorMessageResourceName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.CSSPAfterAttributeErrorMessageResourceName), new[] { ModelsRes.CSSPAfterAttributeErrorMessageResourceName });
            }

            // ErrorMessageResourceName has no validation

                //Error: Type not implemented [ErrorMessageResourceType] of type [Type]

                //Error: Type not implemented [ErrorMessageResourceType] of type [Type]

        }
        #endregion Validation

        #region Functions public
        public bool Add(CSSPAfterAttribute cSSPAfterAttribute)
        {
            cSSPAfterAttribute.ValidationResults = Validate(new ValidationContext(cSSPAfterAttribute), ActionDBTypeEnum.Create);
            if (cSSPAfterAttribute.ValidationResults.Count() > 0) return false;

            db.CSSPAfterAttributes.Add(cSSPAfterAttribute);

            if (!TryToSave(cSSPAfterAttribute)) return false;

            return true;
        }
        public bool AddRange(List<CSSPAfterAttribute> cSSPAfterAttributeList)
        {
            foreach (CSSPAfterAttribute cSSPAfterAttribute in cSSPAfterAttributeList)
            {
                cSSPAfterAttribute.ValidationResults = Validate(new ValidationContext(cSSPAfterAttribute), ActionDBTypeEnum.Create);
                if (cSSPAfterAttribute.ValidationResults.Count() > 0) return false;
            }

            db.CSSPAfterAttributes.AddRange(cSSPAfterAttributeList);

            if (!TryToSaveRange(cSSPAfterAttributeList)) return false;

            return true;
        }
        public bool Delete(CSSPAfterAttribute cSSPAfterAttribute)
        {
            if (!db.CSSPAfterAttributes.Where(c => c.CSSPAfterAttributeID == cSSPAfterAttribute.CSSPAfterAttributeID).Any())
            {
                cSSPAfterAttribute.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "CSSPAfterAttribute", "CSSPAfterAttributeID", cSSPAfterAttribute.CSSPAfterAttributeID.ToString())) }.AsEnumerable();
                return false;
            }

            db.CSSPAfterAttributes.Remove(cSSPAfterAttribute);

            if (!TryToSave(cSSPAfterAttribute)) return false;

            return true;
        }
        public bool DeleteRange(List<CSSPAfterAttribute> cSSPAfterAttributeList)
        {
            foreach (CSSPAfterAttribute cSSPAfterAttribute in cSSPAfterAttributeList)
            {
                if (!db.CSSPAfterAttributes.Where(c => c.CSSPAfterAttributeID == cSSPAfterAttribute.CSSPAfterAttributeID).Any())
                {
                    cSSPAfterAttributeList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "CSSPAfterAttribute", "CSSPAfterAttributeID", cSSPAfterAttribute.CSSPAfterAttributeID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.CSSPAfterAttributes.RemoveRange(cSSPAfterAttributeList);

            if (!TryToSaveRange(cSSPAfterAttributeList)) return false;

            return true;
        }
        public bool Update(CSSPAfterAttribute cSSPAfterAttribute)
        {
            cSSPAfterAttribute.ValidationResults = Validate(new ValidationContext(cSSPAfterAttribute), ActionDBTypeEnum.Update);
            if (cSSPAfterAttribute.ValidationResults.Count() > 0) return false;

            db.CSSPAfterAttributes.Update(cSSPAfterAttribute);

            if (!TryToSave(cSSPAfterAttribute)) return false;

            return true;
        }
        public bool UpdateRange(List<CSSPAfterAttribute> cSSPAfterAttributeList)
        {
            foreach (CSSPAfterAttribute cSSPAfterAttribute in cSSPAfterAttributeList)
            {
                cSSPAfterAttribute.ValidationResults = Validate(new ValidationContext(cSSPAfterAttribute), ActionDBTypeEnum.Update);
                if (cSSPAfterAttribute.ValidationResults.Count() > 0) return false;
            }
            db.CSSPAfterAttributes.UpdateRange(cSSPAfterAttributeList);

            if (!TryToSaveRange(cSSPAfterAttributeList)) return false;

            return true;
        }
        public IQueryable<CSSPAfterAttribute> GetRead()
        {
            return db.CSSPAfterAttributes.AsNoTracking();
        }
        public IQueryable<CSSPAfterAttribute> GetEdit()
        {
            return db.CSSPAfterAttributes;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(CSSPAfterAttribute cSSPAfterAttribute)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                cSSPAfterAttribute.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<CSSPAfterAttribute> cSSPAfterAttributeList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                cSSPAfterAttributeList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
