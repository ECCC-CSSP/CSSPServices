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
    public partial class MWQMSiteSampleFCService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSiteSampleFCService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MWQMSiteSampleFC mwqmSiteSampleFC = validationContext.ObjectInstance as MWQMSiteSampleFC;

            if (string.IsNullOrWhiteSpace(mwqmSiteSampleFC.Error))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSiteSampleFCError), new[] { ModelsRes.MWQMSiteSampleFCError });
            }

            //Error has no StringLength Attribute

            if (mwqmSiteSampleFC.SampleDate == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSiteSampleFCSampleDate), new[] { ModelsRes.MWQMSiteSampleFCSampleDate });
            }

                //Error: Type not implemented [FC] of type [Nullable`1]

            if (mwqmSiteSampleFC.FC < 1 || mwqmSiteSampleFC.FC > 100000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSiteSampleFCFC, "1", "100000000"), new[] { ModelsRes.MWQMSiteSampleFCFC });
            }

                //Error: Type not implemented [Sal] of type [Nullable`1]

            //Sal has no Range Attribute

                //Error: Type not implemented [Temp] of type [Nullable`1]

            //Temp has no Range Attribute

                //Error: Type not implemented [PH] of type [Nullable`1]

            //PH has no Range Attribute

                //Error: Type not implemented [DO] of type [Nullable`1]

            //DO has no Range Attribute

                //Error: Type not implemented [Depth] of type [Nullable`1]

            //Depth has no Range Attribute

                //Error: Type not implemented [SampCount] of type [Nullable`1]

            //SampCount has no Range Attribute

                //Error: Type not implemented [MinFC] of type [Nullable`1]

            //MinFC has no Range Attribute

                //Error: Type not implemented [MaxFC] of type [Nullable`1]

            //MaxFC has no Range Attribute

                //Error: Type not implemented [GeoMean] of type [Nullable`1]

            //GeoMean has no Range Attribute

                //Error: Type not implemented [Median] of type [Nullable`1]

            //Median has no Range Attribute

                //Error: Type not implemented [P90] of type [Nullable`1]

            //P90 has no Range Attribute

                //Error: Type not implemented [PercOver43] of type [Nullable`1]

            //PercOver43 has no Range Attribute

                //Error: Type not implemented [PercOver260] of type [Nullable`1]

            //PercOver260 has no Range Attribute

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
