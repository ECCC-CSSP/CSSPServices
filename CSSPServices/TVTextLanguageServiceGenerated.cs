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
    public partial class TVTextLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVTextLanguageService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVTextLanguage tvTextLanguage = validationContext.ObjectInstance as TVTextLanguage;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            retStr = enums.LanguageOK(tvTextLanguage.Language);
            if (tvTextLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVTextLanguageLanguage), new[] { ModelsRes.TVTextLanguageLanguage });
            }

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            // TVText no min or max length set
            // Language no min or max length set

        }
        #endregion Validation

    }
}
