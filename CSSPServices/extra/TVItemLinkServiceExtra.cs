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
    public partial class TVItemLinkService
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
        private IQueryable<TVItemLink> FillTVItemLinkReport(IQueryable<TVItemLink> tvItemLinkQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));

            tvItemLinkQuery = (from c in tvItemLinkQuery
                               let FromTVItemLanguage = (from cl in db.TVItemLanguages
                                                         where cl.TVItemID == c.FromTVItemID
                                                         && cl.Language == LanguageRequest
                                                         select cl).FirstOrDefault()
                               let ToTVItemLanguage = (from cl in db.TVItemLanguages
                                                       where cl.TVItemID == c.ToTVItemID
                                                       && cl.Language == LanguageRequest
                                                       select cl).FirstOrDefault()
                               let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                                                                      where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                      && cl.Language == LanguageRequest
                                                                      select cl).FirstOrDefault()
                               select new TVItemLink
                               {
                                   TVItemLinkID = c.TVItemLinkID,
                                   FromTVItemID = c.FromTVItemID,
                                   ToTVItemID = c.ToTVItemID,
                                   FromTVType = c.FromTVType,
                                   ToTVType = c.ToTVType,
                                   StartDateTime_Local = c.StartDateTime_Local,
                                   EndDateTime_Local = c.EndDateTime_Local,
                                   Ordinal = c.Ordinal,
                                   TVLevel = c.TVLevel,
                                   TVPath = c.TVPath,
                                   ParentTVItemLinkID = c.ParentTVItemLinkID,
                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                   TVItemLinkWeb = new TVItemLinkWeb
                                   {
                                       FromTVItemLanguage = FromTVItemLanguage,
                                       ToTVItemLanguage = ToTVItemLanguage,
                                       LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                                       FromTVTypeText = (from e in TVTypeEnumList
                                                         where e.EnumID == (int?)c.FromTVType
                                                         select e.EnumText).FirstOrDefault(),
                                       ToTVTypeText = (from e in TVTypeEnumList
                                                       where e.EnumID == (int?)c.ToTVType
                                                       select e.EnumText).FirstOrDefault(),
                                   },
                                   TVItemLinkReport = new TVItemLinkReport
                                   {
                                       TVItemLinkReportTest = "TVItemLinkReportTest",
                                   },
                                   HasErrors = false,
                                   ValidationResults = null,
                               });

            return tvItemLinkQuery;
        }
        #endregion Functions private    
    }
}
