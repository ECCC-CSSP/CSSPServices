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
    ///     <para>bonjour DataPathOfTide</para>
    /// </summary>
    public partial class DataPathOfTideService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public DataPathOfTideService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            DataPathOfTide dataPathOfTide = validationContext.ObjectInstance as DataPathOfTide;
            dataPathOfTide.HasErrors = false;

            if (string.IsNullOrWhiteSpace(dataPathOfTide.Text))
            {
                dataPathOfTide.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "DataPathOfTideText"), new[] { "Text" });
            }

            if (!string.IsNullOrWhiteSpace(dataPathOfTide.Text) && (dataPathOfTide.Text.Length < 1 || dataPathOfTide.Text.Length > 200))
            {
                dataPathOfTide.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "DataPathOfTideText", "1", "200"), new[] { "Text" });
            }

            if (dataPathOfTide.WebTideDataSet != null)
            {
                retStr = enums.EnumTypeOK(typeof(WebTideDataSetEnum), (int?)dataPathOfTide.WebTideDataSet);
                if (dataPathOfTide.WebTideDataSet == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    dataPathOfTide.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "DataPathOfTideWebTideDataSet"), new[] { "WebTideDataSet" });
                }
            }

            if (!string.IsNullOrWhiteSpace(dataPathOfTide.WebTideDataSetText) && dataPathOfTide.WebTideDataSetText.Length > 100)
            {
                dataPathOfTide.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "DataPathOfTideWebTideDataSetText", "100"), new[] { "WebTideDataSetText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                dataPathOfTide.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}