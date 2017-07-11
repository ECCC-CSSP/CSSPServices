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
    public partial class ContourPolygonService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ContourPolygonService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            ContourPolygon contourPolygon = validationContext.ObjectInstance as ContourPolygon;

            //ContourValue (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (contourPolygon.ContourValue < 0)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ContourPolygonContourValue, "0"), new[] { ModelsRes.ContourPolygonContourValue });
            }

            //Layer (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (contourPolygon.Layer < 1 || contourPolygon.Layer > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ContourPolygonLayer, "1", "100"), new[] { ModelsRes.ContourPolygonLayer });
            }

            //Depth (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (contourPolygon.Depth < 1 || contourPolygon.Depth > 10000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ContourPolygonDepth, "1", "10000"), new[] { ModelsRes.ContourPolygonDepth });
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
