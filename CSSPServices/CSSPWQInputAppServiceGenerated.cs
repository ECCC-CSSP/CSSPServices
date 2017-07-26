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
        public CSSPWQInputAppService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            CSSPWQInputApp cSSPWQInputApp = validationContext.ObjectInstance as CSSPWQInputApp;

            if (string.IsNullOrWhiteSpace(cSSPWQInputApp.AccessCode))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.CSSPWQInputAppAccessCode), new[] { ModelsRes.CSSPWQInputAppAccessCode });
            }

            if (!string.IsNullOrWhiteSpace(cSSPWQInputApp.AccessCode) && (cSSPWQInputApp.AccessCode.Length < 1 || cSSPWQInputApp.AccessCode.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.CSSPWQInputAppAccessCode, "1", "100"), new[] { ModelsRes.CSSPWQInputAppAccessCode });
            }

            if (string.IsNullOrWhiteSpace(cSSPWQInputApp.ActiveYear))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.CSSPWQInputAppActiveYear), new[] { ModelsRes.CSSPWQInputAppActiveYear });
            }

            if (!string.IsNullOrWhiteSpace(cSSPWQInputApp.ActiveYear) && (cSSPWQInputApp.ActiveYear.Length < 4 || cSSPWQInputApp.ActiveYear.Length > 4))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.CSSPWQInputAppActiveYear, "4", "4"), new[] { ModelsRes.CSSPWQInputAppActiveYear });
            }

            //DailyDuplicatePrecisionCriteria (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (cSSPWQInputApp.DailyDuplicatePrecisionCriteria < 0 || cSSPWQInputApp.DailyDuplicatePrecisionCriteria > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.CSSPWQInputAppDailyDuplicatePrecisionCriteria, "0", "100"), new[] { ModelsRes.CSSPWQInputAppDailyDuplicatePrecisionCriteria });
            }

            //IntertechDuplicatePrecisionCriteria (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (cSSPWQInputApp.IntertechDuplicatePrecisionCriteria < 0 || cSSPWQInputApp.IntertechDuplicatePrecisionCriteria > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.CSSPWQInputAppIntertechDuplicatePrecisionCriteria, "0", "100"), new[] { ModelsRes.CSSPWQInputAppIntertechDuplicatePrecisionCriteria });
            }

            //IncludeLaboratoryQAQC (bool) is required but no testing needed 

            if (string.IsNullOrWhiteSpace(cSSPWQInputApp.ApprovalCode))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.CSSPWQInputAppApprovalCode), new[] { ModelsRes.CSSPWQInputAppApprovalCode });
            }

            if (!string.IsNullOrWhiteSpace(cSSPWQInputApp.ApprovalCode) && (cSSPWQInputApp.ApprovalCode.Length < 1 || cSSPWQInputApp.ApprovalCode.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.CSSPWQInputAppApprovalCode, "1", "100"), new[] { ModelsRes.CSSPWQInputAppApprovalCode });
            }

            if (cSSPWQInputApp.ApprovalDate.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.CSSPWQInputAppApprovalDate), new[] { ModelsRes.CSSPWQInputAppApprovalDate });
            }
            else
            {
                if (cSSPWQInputApp.ApprovalDate.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.CSSPWQInputAppApprovalDate, "1980"), new[] { ModelsRes.CSSPWQInputAppApprovalDate });
                }
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
