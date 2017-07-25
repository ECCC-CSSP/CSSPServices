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
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelCalNumbError), new[] { ModelsRes.BoxModelCalNumbError });
            }

            if (!string.IsNullOrWhiteSpace(boxModelCalNumb.Error) && boxModelCalNumb.Error.Length > 255)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.BoxModelCalNumbError, "255"), new[] { ModelsRes.BoxModelCalNumbError });
            }

            retStr = enums.BoxModelResultTypeOK(boxModelCalNumb.BoxModelResultType);
            if (boxModelCalNumb.BoxModelResultType == BoxModelResultTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelCalNumbBoxModelResultType), new[] { ModelsRes.BoxModelCalNumbBoxModelResultType });
            }

            //CalLength_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelCalNumb.CalLength_m < 0)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelCalNumbCalLength_m, "0"), new[] { ModelsRes.BoxModelCalNumbCalLength_m });
            }

            //CalRadius_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelCalNumb.CalRadius_m < 0)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelCalNumbCalRadius_m, "0"), new[] { ModelsRes.BoxModelCalNumbCalRadius_m });
            }

            //CalSurface_m2 (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelCalNumb.CalSurface_m2 < 0)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelCalNumbCalSurface_m2, "0"), new[] { ModelsRes.BoxModelCalNumbCalSurface_m2 });
            }

            //CalVolume_m3 (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelCalNumb.CalVolume_m3 < 0)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelCalNumbCalVolume_m3, "0"), new[] { ModelsRes.BoxModelCalNumbCalVolume_m3 });
            }

            //CalWidth_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelCalNumb.CalWidth_m < 0)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelCalNumbCalWidth_m, "0"), new[] { ModelsRes.BoxModelCalNumbCalWidth_m });
            }

            //FixLength (bool) is required but no testing needed 

            //FixWidth (bool) is required but no testing needed 

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
