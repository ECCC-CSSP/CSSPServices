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
    public partial class MWQMLookupMPNService
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
        private IQueryable<MWQMLookupMPN> FillMWQMLookupMPNReport(IQueryable<MWQMLookupMPN> mwqmLookupMPNQuery)
        {
            mwqmLookupMPNQuery = (from c in mwqmLookupMPNQuery
                                  let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                                                                 where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                 && cl.Language == LanguageRequest
                                                                 select cl).FirstOrDefault()
                                  select new MWQMLookupMPN
                                  {
                                      MWQMLookupMPNID = c.MWQMLookupMPNID,
                                      Tubes10 = c.Tubes10,
                                      Tubes1 = c.Tubes1,
                                      Tubes01 = c.Tubes01,
                                      MPN_100ml = c.MPN_100ml,
                                      LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                      LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                      MWQMLookupMPNWeb = new MWQMLookupMPNWeb
                                      {
                                          LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                                      },
                                      MWQMLookupMPNReport = new MWQMLookupMPNReport
                                      {
                                          MWQMLookupMPNReportTest = "MWQMLookupMPNReportTest",
                                      },
                                      HasErrors = false,
                                      ValidationResults = null,
                                  });

            return mwqmLookupMPNQuery;
        }
        #endregion Functions private
    }
}
