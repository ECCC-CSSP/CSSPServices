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
    ///     <para>bonjour TVItemInfrastructureTypeTVItemLink</para>
    /// </summary>
    public partial class TVItemInfrastructureTypeTVItemLinkService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVItemInfrastructureTypeTVItemLinkService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVItemInfrastructureTypeTVItemLink tvItemInfrastructureTypeTVItemLink = validationContext.ObjectInstance as TVItemInfrastructureTypeTVItemLink;
            tvItemInfrastructureTypeTVItemLink.HasErrors = false;

            retStr = enums.EnumTypeOK(typeof(InfrastructureTypeEnum), (int?)tvItemInfrastructureTypeTVItemLink.InfrastructureType);
            if (tvItemInfrastructureTypeTVItemLink.InfrastructureType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                tvItemInfrastructureTypeTVItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemInfrastructureTypeTVItemLinkInfrastructureType), new[] { "InfrastructureType" });
            }

            //SeeOtherTVItemID has no Range Attribute

            if (!string.IsNullOrWhiteSpace(tvItemInfrastructureTypeTVItemLink.InfrastructureTypeText) && tvItemInfrastructureTypeTVItemLink.InfrastructureTypeText.Length > 100)
            {
                tvItemInfrastructureTypeTVItemLink.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TVItemInfrastructureTypeTVItemLinkInfrastructureTypeText, "100"), new[] { "InfrastructureTypeText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                tvItemInfrastructureTypeTVItemLink.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
