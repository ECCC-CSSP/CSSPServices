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
    public partial class AppTaskParameterService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public AppTaskParameterService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            AppTaskParameter appTaskParameter = validationContext.ObjectInstance as AppTaskParameter;

            if (string.IsNullOrWhiteSpace(appTaskParameter.Name))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskParameterName), new[] { ModelsRes.AppTaskParameterName });
            }

            if (!string.IsNullOrWhiteSpace(appTaskParameter.Name) && appTaskParameter.Name.Length > 255)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppTaskParameterName, "255"), new[] { ModelsRes.AppTaskParameterName });
            }

            if (string.IsNullOrWhiteSpace(appTaskParameter.Value))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskParameterValue), new[] { ModelsRes.AppTaskParameterValue });
            }

            if (!string.IsNullOrWhiteSpace(appTaskParameter.Value) && appTaskParameter.Value.Length > 255)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppTaskParameterValue, "255"), new[] { ModelsRes.AppTaskParameterValue });
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
