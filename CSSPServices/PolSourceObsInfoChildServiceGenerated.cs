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
    public partial class PolSourceObsInfoChildService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceObsInfoChildService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            PolSourceObsInfoChild polSourceObsInfoChild = validationContext.ObjectInstance as PolSourceObsInfoChild;

                //Error: Type not implemented [PolSourceObsInfo] of type [PolSourceObsInfoEnum]

                //Error: Type not implemented [PolSourceObsInfo] of type [PolSourceObsInfoEnum]
                //Error: Type not implemented [PolSourceObsInfoChildStart] of type [PolSourceObsInfoEnum]

                //Error: Type not implemented [PolSourceObsInfoChildStart] of type [PolSourceObsInfoEnum]
            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
