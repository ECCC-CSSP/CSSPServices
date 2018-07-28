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
    ///     <para>bonjour ContourPolygon</para>
    /// </summary>
    public partial class ContourPolygonService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ContourPolygonService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            ContourPolygon contourPolygon = validationContext.ObjectInstance as ContourPolygon;
            contourPolygon.HasErrors = false;

            if (contourPolygon.ContourValue < 0)
            {
                contourPolygon.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.ContourPolygonContourValue, "0"), new[] { "ContourValue" });
            }

            if (contourPolygon.Layer < 1 || contourPolygon.Layer > 100)
            {
                contourPolygon.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ContourPolygonLayer, "1", "100"), new[] { "Layer" });
            }

            if (contourPolygon.Depth < 1 || contourPolygon.Depth > 10000)
            {
                contourPolygon.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ContourPolygonDepth, "1", "10000"), new[] { "Depth" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                contourPolygon.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
