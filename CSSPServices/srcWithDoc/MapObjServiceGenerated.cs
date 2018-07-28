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
    ///     <para>bonjour MapObj</para>
    /// </summary>
    public partial class MapObjService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MapObjService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MapObj mapObj = validationContext.ObjectInstance as MapObj;
            mapObj.HasErrors = false;

            if (mapObj.MapInfoID < 1)
            {
                mapObj.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.MapObjMapInfoID, "1"), new[] { "MapInfoID" });
            }

            retStr = enums.EnumTypeOK(typeof(MapInfoDrawTypeEnum), (int?)mapObj.MapInfoDrawType);
            if (mapObj.MapInfoDrawType == MapInfoDrawTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                mapObj.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MapObjMapInfoDrawType), new[] { "MapInfoDrawType" });
            }

            if (!string.IsNullOrWhiteSpace(mapObj.MapInfoDrawTypeText) && mapObj.MapInfoDrawTypeText.Length > 100)
            {
                mapObj.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MapObjMapInfoDrawTypeText, "100"), new[] { "MapInfoDrawTypeText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                mapObj.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
