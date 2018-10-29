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
    ///     <para>bonjour TVItemSubsectorAndMWQMSite</para>
    /// </summary>
    public partial class TVItemSubsectorAndMWQMSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVItemSubsectorAndMWQMSiteService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVItemSubsectorAndMWQMSite tvItemSubsectorAndMWQMSite = validationContext.ObjectInstance as TVItemSubsectorAndMWQMSite;
            tvItemSubsectorAndMWQMSite.HasErrors = false;

                //CSSPError: Type not implemented [TVItemSubsector] of type [TVItem]

                //CSSPError: Type not implemented [TVItemSubsector] of type [TVItem]
                //CSSPError: Type not implemented [TVItemMWQMSiteList] of type [List`1]

                //CSSPError: Type not implemented [TVItemMWQMSiteList] of type [TVItem]
                //CSSPError: Type not implemented [TVItemMWQMSiteDuplicate] of type [TVItem]

                //CSSPError: Type not implemented [TVItemMWQMSiteDuplicate] of type [TVItem]
            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                tvItemSubsectorAndMWQMSite.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
