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
    ///     <para>bonjour CSSPMPNTable</para>
    /// </summary>
    public partial class CSSPMPNTableService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public CSSPMPNTableService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            CSSPMPNTable cSSPMPNTable = validationContext.ObjectInstance as CSSPMPNTable;
            cSSPMPNTable.HasErrors = false;

            if (cSSPMPNTable.Tube10 < 0 || cSSPMPNTable.Tube10 > 5)
            {
                cSSPMPNTable.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "CSSPMPNTableTube10", "0", "5"), new[] { "Tube10" });
            }

            if (cSSPMPNTable.Tube1_0 < 0 || cSSPMPNTable.Tube1_0 > 5)
            {
                cSSPMPNTable.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "CSSPMPNTableTube1_0", "0", "5"), new[] { "Tube1_0" });
            }

            if (cSSPMPNTable.Tube0_1 < 0 || cSSPMPNTable.Tube0_1 > 5)
            {
                cSSPMPNTable.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "CSSPMPNTableTube0_1", "0", "5"), new[] { "Tube0_1" });
            }

            if (cSSPMPNTable.MPN < 0 || cSSPMPNTable.MPN > 100000000)
            {
                cSSPMPNTable.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "CSSPMPNTableMPN", "0", "100000000"), new[] { "MPN" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                cSSPMPNTable.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
