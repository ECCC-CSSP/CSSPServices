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

            //MapInfoID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mapObj.MapInfoID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MapObjMapInfoID, "1"), new[] { "MapInfoID" });
            }

            retStr = enums.MapInfoDrawTypeOK(mapObj.MapInfoDrawType);
            if (mapObj.MapInfoDrawType == MapInfoDrawTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MapObjMapInfoDrawType), new[] { "MapInfoDrawType" });
            }

            if (!string.IsNullOrWhiteSpace(mapObj.MapInfoDrawTypeText) && mapObj.MapInfoDrawTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MapObjMapInfoDrawTypeText, "100"), new[] { "MapInfoDrawTypeText" });
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
