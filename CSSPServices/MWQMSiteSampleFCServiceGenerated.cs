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
        public MWQMSiteSampleFCService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
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
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSiteSampleFCError), new[] { "Error" });
            }

            //Error has no StringLength Attribute

            if (mwqmSiteSampleFC.SampleDate.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSiteSampleFCSampleDate), new[] { "SampleDate" });
            }
            else
            {
                if (mwqmSiteSampleFC.SampleDate.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMSiteSampleFCSampleDate, "1980"), new[] { "SampleDate" });
                }
            }

            if (mwqmSiteSampleFC.FC != null)
            {
                if (mwqmSiteSampleFC.FC < 1 || mwqmSiteSampleFC.FC > 100000000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSiteSampleFCFC, "1", "100000000"), new[] { "FC" });
                }
            }

            //Sal has no Range Attribute

            //Temp has no Range Attribute

            //PH has no Range Attribute

            //DO has no Range Attribute

            //Depth has no Range Attribute

            //SampCount has no Range Attribute

            //MinFC has no Range Attribute

            //MaxFC has no Range Attribute

            //GeoMean has no Range Attribute

            //Median has no Range Attribute

            //P90 has no Range Attribute

            //PercOver43 has no Range Attribute

            //PercOver260 has no Range Attribute

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
