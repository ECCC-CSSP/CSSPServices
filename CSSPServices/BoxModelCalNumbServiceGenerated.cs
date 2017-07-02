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
        public BoxModelCalNumbService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            BoxModelCalNumb boxModelCalNumb = validationContext.ObjectInstance as BoxModelCalNumb;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            retStr = enums.BoxModelResultTypeOK(boxModelCalNumb.BoxModelResultType);
            if (boxModelCalNumb.BoxModelResultType == BoxModelResultTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelCalNumbBoxModelResultType), new[] { ModelsRes.BoxModelCalNumbBoxModelResultType });
            }

            //CalLength_m is required but no testing needed as it is automatically set to 0.0f

            //CalRadius_m is required but no testing needed as it is automatically set to 0.0f

            //CalSurface_m2 is required but no testing needed as it is automatically set to 0.0f

            //CalVolume_m3 is required but no testing needed as it is automatically set to 0.0f

            //CalWidth_m is required but no testing needed as it is automatically set to 0.0f

            //FixLength (bool) is required but no testing needed 

            //FixWidth (bool) is required but no testing needed 

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (!string.IsNullOrWhiteSpace(boxModelCalNumb.Error) && (boxModelCalNumb.Error.Length < 0) || (boxModelCalNumb.Error.Length > 255))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.BoxModelCalNumbError, "0", "255"), new[] { ModelsRes.BoxModelCalNumbError });
            }

            // BoxModelResultType no min or max length set
            if (boxModelCalNumb.CalLength_m < 0f)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelCalNumbCalLength_m, "0f"), new[] { ModelsRes.BoxModelCalNumbCalLength_m });
            }

            if (boxModelCalNumb.CalRadius_m < 0f)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelCalNumbCalRadius_m, "0f"), new[] { ModelsRes.BoxModelCalNumbCalRadius_m });
            }

            if (boxModelCalNumb.CalSurface_m2 < 0f)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelCalNumbCalSurface_m2, "0f"), new[] { ModelsRes.BoxModelCalNumbCalSurface_m2 });
            }

            if (boxModelCalNumb.CalVolume_m3 < 0f)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelCalNumbCalVolume_m3, "0f"), new[] { ModelsRes.BoxModelCalNumbCalVolume_m3 });
            }

            if (boxModelCalNumb.CalWidth_m < 0f)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelCalNumbCalWidth_m, "0f"), new[] { ModelsRes.BoxModelCalNumbCalWidth_m });
            }


        }
        #endregion Validation

    }
}
