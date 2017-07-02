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
    public partial class LastUpdateAndContactService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LastUpdateAndContactService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            LastUpdateAndContact lastUpdateAndContact = validationContext.ObjectInstance as LastUpdateAndContact;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

                //Error: Type not implemented [LastUpdateDate_UTC] of type [System.DateTime]

            //LastUpdateContactTVItemID is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            // Error no min or max length set
            if (lastUpdateAndContact.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.LastUpdateAndContactLastUpdateContactTVItemID, "1"), new[] { ModelsRes.LastUpdateAndContactLastUpdateContactTVItemID });
            }


        }
        #endregion Validation

    }
}
