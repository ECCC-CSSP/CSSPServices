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
    public partial class ContactOKService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ContactOKService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            ContactOK contactOK = validationContext.ObjectInstance as ContactOK;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            //ContactID is required but no testing needed as it is automatically set to 0

            //ContactTVItemID is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (contactOK.ContactID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ContactOKContactID, "1"), new[] { ModelsRes.ContactOKContactID });
            }

            if (contactOK.ContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ContactOKContactTVItemID, "1"), new[] { ModelsRes.ContactOKContactTVItemID });
            }

            if (!string.IsNullOrWhiteSpace(contactOK.Error) && (contactOK.Error.Length < 1) || (contactOK.Error.Length > 255))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ContactOKError, "1", "255"), new[] { ModelsRes.ContactOKError });
            }


        }
        #endregion Validation

    }
}
