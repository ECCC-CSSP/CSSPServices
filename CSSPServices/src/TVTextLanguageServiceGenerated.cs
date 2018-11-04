/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

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
        public TVTextLanguageService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVTextLanguage tvTextLanguage = validationContext.ObjectInstance as TVTextLanguage;
            tvTextLanguage.HasErrors = false;

            if (string.IsNullOrWhiteSpace(tvTextLanguage.TVText))
            {
                tvTextLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVTextLanguageTVText"), new[] { "TVText" });
            }

            //TVText has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)tvTextLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                tvTextLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVTextLanguageLanguage"), new[] { "Language" });
            }

            if (!string.IsNullOrWhiteSpace(tvTextLanguage.LanguageText) && tvTextLanguage.LanguageText.Length > 100)
            {
                tvTextLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "TVTextLanguageLanguageText", "100"), new[] { "LanguageText" });
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                tvTextLanguage.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
