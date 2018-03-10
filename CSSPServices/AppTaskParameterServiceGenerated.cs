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
    ///     <para>bonjour AppTaskParameter</para>
    /// </summary>
    public partial class AppTaskParameterService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public AppTaskParameterService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            AppTaskParameter appTaskParameter = validationContext.ObjectInstance as AppTaskParameter;
            appTaskParameter.HasErrors = false;

            if (string.IsNullOrWhiteSpace(appTaskParameter.Name))
            {
                appTaskParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppTaskParameterName), new[] { "Name" });
            }

            if (!string.IsNullOrWhiteSpace(appTaskParameter.Name) && appTaskParameter.Name.Length > 255)
            {
                appTaskParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AppTaskParameterName, "255"), new[] { "Name" });
            }

            if (string.IsNullOrWhiteSpace(appTaskParameter.Value))
            {
                appTaskParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppTaskParameterValue), new[] { "Value" });
            }

            if (!string.IsNullOrWhiteSpace(appTaskParameter.Value) && appTaskParameter.Value.Length > 255)
            {
                appTaskParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AppTaskParameterValue, "255"), new[] { "Value" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                appTaskParameter.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
