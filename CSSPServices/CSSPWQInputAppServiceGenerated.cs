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
    ///     <para>bonjour CSSPWQInputApp</para>
    /// </summary>
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
            cSSPWQInputApp.HasErrors = false;

            if (string.IsNullOrWhiteSpace(cSSPWQInputApp.AccessCode))
            {
                cSSPWQInputApp.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPWQInputAppAccessCode), new[] { "AccessCode" });
            }

            if (!string.IsNullOrWhiteSpace(cSSPWQInputApp.AccessCode) && (cSSPWQInputApp.AccessCode.Length < 1 || cSSPWQInputApp.AccessCode.Length > 100))
            {
                cSSPWQInputApp.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.CSSPWQInputAppAccessCode, "1", "100"), new[] { "AccessCode" });
            }

            if (string.IsNullOrWhiteSpace(cSSPWQInputApp.ActiveYear))
            {
                cSSPWQInputApp.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPWQInputAppActiveYear), new[] { "ActiveYear" });
            }

            if (!string.IsNullOrWhiteSpace(cSSPWQInputApp.ActiveYear) && (cSSPWQInputApp.ActiveYear.Length < 4 || cSSPWQInputApp.ActiveYear.Length > 4))
            {
                cSSPWQInputApp.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.CSSPWQInputAppActiveYear, "4", "4"), new[] { "ActiveYear" });
            }

            if (cSSPWQInputApp.DailyDuplicatePrecisionCriteria < 0 || cSSPWQInputApp.DailyDuplicatePrecisionCriteria > 100)
            {
                cSSPWQInputApp.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.CSSPWQInputAppDailyDuplicatePrecisionCriteria, "0", "100"), new[] { "DailyDuplicatePrecisionCriteria" });
            }

            if (cSSPWQInputApp.IntertechDuplicatePrecisionCriteria < 0 || cSSPWQInputApp.IntertechDuplicatePrecisionCriteria > 100)
            {
                cSSPWQInputApp.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.CSSPWQInputAppIntertechDuplicatePrecisionCriteria, "0", "100"), new[] { "IntertechDuplicatePrecisionCriteria" });
            }

            if (string.IsNullOrWhiteSpace(cSSPWQInputApp.ApprovalCode))
            {
                cSSPWQInputApp.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPWQInputAppApprovalCode), new[] { "ApprovalCode" });
            }

            if (!string.IsNullOrWhiteSpace(cSSPWQInputApp.ApprovalCode) && (cSSPWQInputApp.ApprovalCode.Length < 1 || cSSPWQInputApp.ApprovalCode.Length > 100))
            {
                cSSPWQInputApp.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.CSSPWQInputAppApprovalCode, "1", "100"), new[] { "ApprovalCode" });
            }

            if (cSSPWQInputApp.ApprovalDate.Year == 1)
            {
                cSSPWQInputApp.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPWQInputAppApprovalDate), new[] { "ApprovalDate" });
            }
            else
            {
                if (cSSPWQInputApp.ApprovalDate.Year < 1980)
                {
                cSSPWQInputApp.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.CSSPWQInputAppApprovalDate, "1980"), new[] { "ApprovalDate" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                cSSPWQInputApp.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
