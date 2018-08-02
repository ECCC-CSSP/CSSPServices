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
    public partial class ContactPreferenceService
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
        private IQueryable<ContactPreference> FillContactPreferenceReport(IQueryable<ContactPreference> contactPreferenceQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));

            contactPreferenceQuery = (from c in contactPreferenceQuery
                                      let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                                                                     where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                     && cl.Language == LanguageRequest
                                                                     select cl).FirstOrDefault()
                                      select new ContactPreference
                                      {
                                          ContactPreferenceID = c.ContactPreferenceID,
                                          ContactID = c.ContactID,
                                          TVType = c.TVType,
                                          MarkerSize = c.MarkerSize,
                                          LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                          LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                          ContactPreferenceWeb = new ContactPreferenceWeb
                                          {
                                              LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                                              TVTypeText = (from e in TVTypeEnumList
                                                            where e.EnumID == (int?)c.TVType
                                                            select e.EnumText).FirstOrDefault(),
                                          },
                                          ContactPreferenceReport = new ContactPreferenceReport
                                          {
                                              ContactPreferenceReportText = "ContactPreferenceReportText",
                                          },
                                          HasErrors = false,
                                          ValidationResults = null,
                                      });

            return contactPreferenceQuery;
        }
        #endregion Functions private
    }
}
