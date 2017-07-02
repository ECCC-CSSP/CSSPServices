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
    public partial class CSSPWQInputAppService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public CSSPWQInputAppService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            CSSPWQInputApp cSSPWQInputApp = validationContext.ObjectInstance as CSSPWQInputApp;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (string.IsNullOrWhiteSpace(cSSPWQInputApp.AccessCode))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.CSSPWQInputAppAccessCode), new[] { ModelsRes.CSSPWQInputAppAccessCode });
            }

            if (string.IsNullOrWhiteSpace(cSSPWQInputApp.ActiveYear))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.CSSPWQInputAppActiveYear), new[] { ModelsRes.CSSPWQInputAppActiveYear });
            }

            //DailyDuplicatePrecisionCriteria is required but no testing needed as it is automatically set to 0.0f

            //IntertechDuplicatePrecisionCriteria is required but no testing needed as it is automatically set to 0.0f

            //IncludeLaboratoryQAQC (bool) is required but no testing needed 

            if (string.IsNullOrWhiteSpace(cSSPWQInputApp.ApprovalCode))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.CSSPWQInputAppApprovalCode), new[] { ModelsRes.CSSPWQInputAppApprovalCode });
            }

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (!string.IsNullOrWhiteSpace(cSSPWQInputApp.AccessCode) && (cSSPWQInputApp.AccessCode.Length < 1) || (cSSPWQInputApp.AccessCode.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.CSSPWQInputAppAccessCode, "1", "100"), new[] { ModelsRes.CSSPWQInputAppAccessCode });
            }

            if (!string.IsNullOrWhiteSpace(cSSPWQInputApp.ActiveYear) && (cSSPWQInputApp.ActiveYear.Length < 4) || (cSSPWQInputApp.ActiveYear.Length > 4))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.CSSPWQInputAppActiveYear, "4", "4"), new[] { ModelsRes.CSSPWQInputAppActiveYear });
            }

            if (cSSPWQInputApp.DailyDuplicatePrecisionCriteria < 0f || cSSPWQInputApp.DailyDuplicatePrecisionCriteria > 100f)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.CSSPWQInputAppDailyDuplicatePrecisionCriteria, "0f", "100f"), new[] { ModelsRes.CSSPWQInputAppDailyDuplicatePrecisionCriteria });
            }

            if (cSSPWQInputApp.IntertechDuplicatePrecisionCriteria < 0f || cSSPWQInputApp.IntertechDuplicatePrecisionCriteria > 100f)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.CSSPWQInputAppIntertechDuplicatePrecisionCriteria, "0f", "100f"), new[] { ModelsRes.CSSPWQInputAppIntertechDuplicatePrecisionCriteria });
            }

            if (!string.IsNullOrWhiteSpace(cSSPWQInputApp.ApprovalCode) && (cSSPWQInputApp.ApprovalCode.Length < 1) || (cSSPWQInputApp.ApprovalCode.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.CSSPWQInputAppApprovalCode, "1", "100"), new[] { ModelsRes.CSSPWQInputAppApprovalCode });
            }


        }
        #endregion Validation

    }
}
