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
    ///     <para>bonjour ContactOK</para>
    /// </summary>
    public partial class ContactOKService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ContactOKService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            ContactOK contactOK = validationContext.ObjectInstance as ContactOK;
            contactOK.HasErrors = false;

            if (string.IsNullOrWhiteSpace(contactOK.Error))
            {
                contactOK.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ContactOKError"), new[] { "Error" });
            }

            if (!string.IsNullOrWhiteSpace(contactOK.Error) && contactOK.Error.Length > 255)
            {
                contactOK.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "ContactOKError", "255"), new[] { "Error" });
            }

            if (contactOK.ContactID < 1)
            {
                contactOK.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "ContactOKContactID", "1"), new[] { "ContactID" });
            }

            if (contactOK.ContactTVItemID < 1)
            {
                contactOK.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "ContactOKContactTVItemID", "1"), new[] { "ContactTVItemID" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                contactOK.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
