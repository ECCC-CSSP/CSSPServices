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
    ///     <para>bonjour BoxModelCalNumb</para>
    /// </summary>
    public partial class BoxModelCalNumbService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public BoxModelCalNumbService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            BoxModelCalNumb boxModelCalNumb = validationContext.ObjectInstance as BoxModelCalNumb;
            boxModelCalNumb.HasErrors = false;

            if (string.IsNullOrWhiteSpace(boxModelCalNumb.Error))
            {
                boxModelCalNumb.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.BoxModelCalNumbError), new[] { "Error" });
            }

            if (!string.IsNullOrWhiteSpace(boxModelCalNumb.Error) && boxModelCalNumb.Error.Length > 255)
            {
                boxModelCalNumb.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.BoxModelCalNumbError, "255"), new[] { "Error" });
            }

            retStr = enums.EnumTypeOK(typeof(BoxModelResultTypeEnum), (int?)boxModelCalNumb.BoxModelResultType);
            if (boxModelCalNumb.BoxModelResultType == BoxModelResultTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                boxModelCalNumb.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.BoxModelCalNumbBoxModelResultType), new[] { "BoxModelResultType" });
            }

            if (boxModelCalNumb.CalLength_m < 0)
            {
                boxModelCalNumb.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.BoxModelCalNumbCalLength_m, "0"), new[] { "CalLength_m" });
            }

            if (boxModelCalNumb.CalRadius_m < 0)
            {
                boxModelCalNumb.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.BoxModelCalNumbCalRadius_m, "0"), new[] { "CalRadius_m" });
            }

            if (boxModelCalNumb.CalSurface_m2 < 0)
            {
                boxModelCalNumb.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.BoxModelCalNumbCalSurface_m2, "0"), new[] { "CalSurface_m2" });
            }

            if (boxModelCalNumb.CalVolume_m3 < 0)
            {
                boxModelCalNumb.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.BoxModelCalNumbCalVolume_m3, "0"), new[] { "CalVolume_m3" });
            }

            if (boxModelCalNumb.CalWidth_m < 0)
            {
                boxModelCalNumb.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.BoxModelCalNumbCalWidth_m, "0"), new[] { "CalWidth_m" });
            }

            if (!string.IsNullOrWhiteSpace(boxModelCalNumb.BoxModelResultTypeText) && boxModelCalNumb.BoxModelResultTypeText.Length > 100)
            {
                boxModelCalNumb.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.BoxModelCalNumbBoxModelResultTypeText, "100"), new[] { "BoxModelResultTypeText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                boxModelCalNumb.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
