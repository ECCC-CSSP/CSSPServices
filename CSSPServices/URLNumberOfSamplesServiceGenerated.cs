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
    public partial class URLNumberOfSamplesService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public URLNumberOfSamplesService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            URLNumberOfSamples uRLNumberOfSamples = validationContext.ObjectInstance as URLNumberOfSamples;

            if (string.IsNullOrWhiteSpace(uRLNumberOfSamples.url))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.URLNumberOfSamplesurl), new[] { ModelsRes.URLNumberOfSamplesurl });
            }

            if (!string.IsNullOrWhiteSpace(uRLNumberOfSamples.url) && (uRLNumberOfSamples.url.Length < 1 || uRLNumberOfSamples.url.Length > 255))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.URLNumberOfSamplesurl, "1", "255"), new[] { ModelsRes.URLNumberOfSamplesurl });
            }

            //NumberOfSamples (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //NumberOfSamples has no Range Attribute

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
