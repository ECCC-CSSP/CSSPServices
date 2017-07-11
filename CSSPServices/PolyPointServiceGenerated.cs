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
    public partial class PolyPointService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolyPointService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            PolyPoint polyPoint = validationContext.ObjectInstance as PolyPoint;

            //XCoord (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (polyPoint.XCoord < -180 || polyPoint.XCoord > 180)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.PolyPointXCoord, "-180", "180"), new[] { ModelsRes.PolyPointXCoord });
            }

            //YCoord (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (polyPoint.YCoord < -90 || polyPoint.YCoord > 90)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.PolyPointYCoord, "-90", "90"), new[] { ModelsRes.PolyPointYCoord });
            }

            //Z (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //Z has no Range Attribute

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
