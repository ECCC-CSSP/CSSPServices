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
    public partial class TVItemUserAuthorizationService
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
        private IQueryable<TVItemUserAuthorization> FillTVItemUserAuthorizationReport(IQueryable<TVItemUserAuthorization> tvItemUserAuthorizationQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVAuthEnumList = enums.GetEnumTextOrderedList(typeof(TVAuthEnum));

            tvItemUserAuthorizationQuery = (from c in tvItemUserAuthorizationQuery
                                            let ContactTVText = (from cl in db.TVItemLanguages
                                                                 where cl.TVItemID == c.ContactTVItemID
                                                                 && cl.Language == LanguageRequest
                                                                 select cl.TVText).FirstOrDefault()
                                            let TVText1 = (from cl in db.TVItemLanguages
                                                           where cl.TVItemID == c.TVItemID1
                                                           && cl.Language == LanguageRequest
                                                           select cl.TVText).FirstOrDefault()
                                            let TVText2 = (from cl in db.TVItemLanguages
                                                           where cl.TVItemID == c.TVItemID2
                                                           && cl.Language == LanguageRequest
                                                           select cl.TVText).FirstOrDefault()
                                            let TVText3 = (from cl in db.TVItemLanguages
                                                           where cl.TVItemID == c.TVItemID3
                                                           && cl.Language == LanguageRequest
                                                           select cl.TVText).FirstOrDefault()
                                            let TVText4 = (from cl in db.TVItemLanguages
                                                           where cl.TVItemID == c.TVItemID4
                                                           && cl.Language == LanguageRequest
                                                           select cl.TVText).FirstOrDefault()
                                            let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                           where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                           && cl.Language == LanguageRequest
                                                                           select cl.TVText).FirstOrDefault()
                                            select new TVItemUserAuthorization
                                            {
                                                TVItemUserAuthorizationID = c.TVItemUserAuthorizationID,
                                                ContactTVItemID = c.ContactTVItemID,
                                                TVItemID1 = c.TVItemID1,
                                                TVItemID2 = c.TVItemID2,
                                                TVItemID3 = c.TVItemID3,
                                                TVItemID4 = c.TVItemID4,
                                                TVAuth = c.TVAuth,
                                                LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                TVItemUserAuthorizationWeb = new TVItemUserAuthorizationWeb
                                                {
                                                    ContactTVText = ContactTVText,
                                                    TVText1 = TVText1,
                                                    TVText2 = TVText2,
                                                    TVText3 = TVText3,
                                                    TVText4 = TVText4,
                                                    LastUpdateContactTVText = LastUpdateContactTVText,
                                                    TVAuthText = (from e in TVAuthEnumList
                                                                  where e.EnumID == (int?)c.TVAuth
                                                                  select e.EnumText).FirstOrDefault(),
                                                },
                                                TVItemUserAuthorizationReport = new TVItemUserAuthorizationReport
                                                {
                                                    TVItemUserAuthorizationReportTest = "TVItemUserAuthorizationReportTest",
                                                },
                                                HasErrors = false,
                                                ValidationResults = null,
                                            });

            return tvItemUserAuthorizationQuery;
        }
        #endregion Functions private
    }
}
