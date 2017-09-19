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
    ///     <para>bonjour CSSPWQInputParam</para>
    /// </summary>
    public partial class CSSPWQInputParamService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public CSSPWQInputParamService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            CSSPWQInputParam cSSPWQInputParam = validationContext.ObjectInstance as CSSPWQInputParam;
            cSSPWQInputParam.HasErrors = false;

            retStr = enums.EnumTypeOK(typeof(CSSPWQInputTypeEnum), (int?)cSSPWQInputParam.CSSPWQInputType);
            if (cSSPWQInputParam.CSSPWQInputType == CSSPWQInputTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                cSSPWQInputParam.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPWQInputParamCSSPWQInputType), new[] { "CSSPWQInputType" });
            }

            if (string.IsNullOrWhiteSpace(cSSPWQInputParam.Name))
            {
                cSSPWQInputParam.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPWQInputParamName), new[] { "Name" });
            }

            if (!string.IsNullOrWhiteSpace(cSSPWQInputParam.Name) && (cSSPWQInputParam.Name.Length < 1 || cSSPWQInputParam.Name.Length > 200))
            {
                cSSPWQInputParam.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.CSSPWQInputParamName, "1", "200"), new[] { "Name" });
            }

            //TVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (cSSPWQInputParam.TVItemID < 1)
            {
                cSSPWQInputParam.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.CSSPWQInputParamTVItemID, "1"), new[] { "TVItemID" });
            }

            if (!string.IsNullOrWhiteSpace(cSSPWQInputParam.CSSPWQInputTypeText) && cSSPWQInputParam.CSSPWQInputTypeText.Length > 100)
            {
                cSSPWQInputParam.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.CSSPWQInputParamCSSPWQInputTypeText, "100"), new[] { "CSSPWQInputTypeText" });
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                cSSPWQInputParam.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
