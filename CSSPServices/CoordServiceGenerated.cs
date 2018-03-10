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
    ///     <para>bonjour Coord</para>
    /// </summary>
    public partial class CoordService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public CoordService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            Coord coord = validationContext.ObjectInstance as Coord;
            coord.HasErrors = false;

            if (coord.Lat < -180 || coord.Lat > 180)
            {
                coord.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.CoordLat, "-180", "180"), new[] { "Lat" });
            }

            if (coord.Lng < -90 || coord.Lng > 90)
            {
                coord.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.CoordLng, "-90", "90"), new[] { "Lng" });
            }

            if (coord.Ordinal < 0 || coord.Ordinal > 10000)
            {
                coord.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.CoordOrdinal, "0", "10000"), new[] { "Ordinal" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                coord.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
