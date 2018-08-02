using CSSPEnums;
using CSSPModels;
using CSSPModels.Resources;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class TelService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Validation
        #endregion Validation

        #region Functions public
        #endregion Functions public

        #region Functions private
        private IQueryable<Tel> FillTelReport(IQueryable<Tel> telQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TelTypeEnumList = enums.GetEnumTextOrderedList(typeof(TelTypeEnum));

            telQuery = (from c in telQuery
                        let TelTVItemLanguage = (from cl in db.TVItemLanguages
                                         where cl.TVItemID == c.TelTVItemID
                                         && cl.Language == LanguageRequest
                                         select cl).FirstOrDefault()
                        let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                                                       where cl.TVItemID == c.LastUpdateContactTVItemID
                                                       && cl.Language == LanguageRequest
                                                       select cl).FirstOrDefault()
                        select new Tel
                        {
                            TelID = c.TelID,
                            TelTVItemID = c.TelTVItemID,
                            TelNumber = c.TelNumber,
                            TelType = c.TelType,
                            LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                            LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                            TelWeb = new TelWeb
                            {
                                TelTVItemLanguage = TelTVItemLanguage,
                                LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                                TelTypeText = (from e in TelTypeEnumList
                                               where e.EnumID == (int?)c.TelType
                                               select e.EnumText).FirstOrDefault(),
                            },
                            TelReport = new TelReport
                            {
                                TelReportTest = "TelReportTest",
                            },
                            HasErrors = false,
                            ValidationResults = null,
                        });

            return telQuery;
        }
        #endregion Functions private
    }
}
