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
    public partial class TVTypeUserAuthorizationService
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
        #endregion Function public

        #region Function private
        private IQueryable<TVTypeUserAuthorization> FillTVTypeUserAuthorizationReport(IQueryable<TVTypeUserAuthorization> tvTypeUserAuthorizationQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));
            List<EnumIDAndText> TVAuthEnumList = enums.GetEnumTextOrderedList(typeof(TVAuthEnum));

            tvTypeUserAuthorizationQuery = (from c in tvTypeUserAuthorizationQuery
                                            let ContactTVText = (from cl in db.TVItemLanguages
                                                                 where cl.TVItemID == c.ContactTVItemID
                                                                 && cl.Language == LanguageRequest
                                                                 select cl.TVText).FirstOrDefault()
                                            let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                           where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                           && cl.Language == LanguageRequest
                                                                           select cl.TVText).FirstOrDefault()
                                            select new TVTypeUserAuthorization
                                            {
                                                TVTypeUserAuthorizationID = c.TVTypeUserAuthorizationID,
                                                ContactTVItemID = c.ContactTVItemID,
                                                TVType = c.TVType,
                                                TVAuth = c.TVAuth,
                                                LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                TVTypeUserAuthorizationWeb = new TVTypeUserAuthorizationWeb
                                                {
                                                    ContactTVText = ContactTVText,
                                                    LastUpdateContactTVText = LastUpdateContactTVText,
                                                    TVTypeText = (from e in TVTypeEnumList
                                                                  where e.EnumID == (int?)c.TVType
                                                                  select e.EnumText).FirstOrDefault(),
                                                    TVAuthText = (from e in TVAuthEnumList
                                                                  where e.EnumID == (int?)c.TVAuth
                                                                  select e.EnumText).FirstOrDefault(),
                                                },
                                                TVTypeUserAuthorizationReport = new TVTypeUserAuthorizationReport
                                                {
                                                    TVTypeUserAuthorizationReportTest = "TVTypeUserAuthorizationReportTest",
                                                },
                                                HasErrors = false,
                                                ValidationResults = null,
                                            });

            return tvTypeUserAuthorizationQuery;
        }
        #endregion Functions private    
    }
}
