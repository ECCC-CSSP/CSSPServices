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
    public partial class DataPathOfTideService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public DataPathOfTideService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            DataPathOfTide dataPathOfTide = validationContext.ObjectInstance as DataPathOfTide;

            if (string.IsNullOrWhiteSpace(dataPathOfTide.Text))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.DataPathOfTideText), new[] { ModelsRes.DataPathOfTideText });
            }

            if (!string.IsNullOrWhiteSpace(dataPathOfTide.Text) && (dataPathOfTide.Text.Length < 1 || dataPathOfTide.Text.Length > 200))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.DataPathOfTideText, "1", "200"), new[] { ModelsRes.DataPathOfTideText });
            }

                //Error: Type not implemented [WebTideDataSet] of type [WebTideDataSetEnum]

                //Error: Type not implemented [WebTideDataSet] of type [WebTideDataSetEnum]
            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
