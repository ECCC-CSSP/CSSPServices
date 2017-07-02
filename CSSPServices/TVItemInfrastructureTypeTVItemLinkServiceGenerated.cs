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
    public partial class TVItemInfrastructureTypeTVItemLinkService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVItemInfrastructureTypeTVItemLinkService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVItemInfrastructureTypeTVItemLink tvItemInfrastructureTypeTVItemLink = validationContext.ObjectInstance as TVItemInfrastructureTypeTVItemLink;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            retStr = enums.InfrastructureTypeOK(tvItemInfrastructureTypeTVItemLink.InfrastructureType);
            if (tvItemInfrastructureTypeTVItemLink.InfrastructureType == InfrastructureTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemInfrastructureTypeTVItemLinkInfrastructureType), new[] { ModelsRes.TVItemInfrastructureTypeTVItemLinkInfrastructureType });
            }

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            // InfrastructureType no min or max length set
            // SeeOtherTVItemID no min or max length set

        }
        #endregion Validation

    }
}
