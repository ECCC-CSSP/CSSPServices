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
    public partial class BoxModelCalNumbService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public BoxModelCalNumbService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            BoxModelCalNumb boxModelCalNumb = validationContext.ObjectInstance as BoxModelCalNumb;

            if (string.IsNullOrWhiteSpace(boxModelCalNumb.Error))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelCalNumbError), new[] { "Error" });
            }

            if (!string.IsNullOrWhiteSpace(boxModelCalNumb.Error) && boxModelCalNumb.Error.Length > 255)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.BoxModelCalNumbError, "255"), new[] { "Error" });
            }

            retStr = enums.BoxModelResultTypeOK(boxModelCalNumb.BoxModelResultType);
            if (boxModelCalNumb.BoxModelResultType == BoxModelResultTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelCalNumbBoxModelResultType), new[] { "BoxModelResultType" });
            }

            //CalLength_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelCalNumb.CalLength_m < 0)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelCalNumbCalLength_m, "0"), new[] { "CalLength_m" });
            }

            //CalRadius_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelCalNumb.CalRadius_m < 0)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelCalNumbCalRadius_m, "0"), new[] { "CalRadius_m" });
            }

            //CalSurface_m2 (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelCalNumb.CalSurface_m2 < 0)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelCalNumbCalSurface_m2, "0"), new[] { "CalSurface_m2" });
            }

            //CalVolume_m3 (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelCalNumb.CalVolume_m3 < 0)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelCalNumbCalVolume_m3, "0"), new[] { "CalVolume_m3" });
            }

            //CalWidth_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelCalNumb.CalWidth_m < 0)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelCalNumbCalWidth_m, "0"), new[] { "CalWidth_m" });
            }

            //FixLength (bool) is required but no testing needed 

            //FixWidth (bool) is required but no testing needed 

            if (!string.IsNullOrWhiteSpace(boxModelCalNumb.BoxModelResultTypeText) && boxModelCalNumb.BoxModelResultTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.BoxModelCalNumbBoxModelResultTypeText, "100"), new[] { "BoxModelResultTypeText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
