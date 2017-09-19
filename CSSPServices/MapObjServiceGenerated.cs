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
        public MapObjService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
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

            //MapInfoID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

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

            //HasErrors (bool) is required but no testing needed 

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
