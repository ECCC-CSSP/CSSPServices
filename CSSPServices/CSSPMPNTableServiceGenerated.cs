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
    public partial class CSSPMPNTableService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public CSSPMPNTableService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            CSSPMPNTable cSSPMPNTable = validationContext.ObjectInstance as CSSPMPNTable;

            //Tube10 (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (cSSPMPNTable.Tube10 < 0 || cSSPMPNTable.Tube10 > 5)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.CSSPMPNTableTube10, "0", "5"), new[] { ModelsRes.CSSPMPNTableTube10 });
            }

            //Tube1_0 (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (cSSPMPNTable.Tube1_0 < 0 || cSSPMPNTable.Tube1_0 > 5)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.CSSPMPNTableTube1_0, "0", "5"), new[] { ModelsRes.CSSPMPNTableTube1_0 });
            }

            //Tube0_1 (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (cSSPMPNTable.Tube0_1 < 0 || cSSPMPNTable.Tube0_1 > 5)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.CSSPMPNTableTube0_1, "0", "5"), new[] { ModelsRes.CSSPMPNTableTube0_1 });
            }

            //MPN (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (cSSPMPNTable.MPN < 0 || cSSPMPNTable.MPN > 100000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.CSSPMPNTableMPN, "0", "100000000"), new[] { ModelsRes.CSSPMPNTableMPN });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
