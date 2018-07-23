﻿using CSSPEnums;
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
    public partial class SpillLanguageService
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
        private IQueryable<SpillLanguage> FillSpillLanguageReport(IQueryable<SpillLanguage> spillLanguageQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

            spillLanguageQuery = (from c in spillLanguageQuery
                                  let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                 where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                 && cl.Language == LanguageRequest
                                                                 select cl.TVText).FirstOrDefault()
                                  select new SpillLanguage
                                  {
                                      SpillLanguageID = c.SpillLanguageID,
                                      SpillID = c.SpillID,
                                      Language = c.Language,
                                      SpillComment = c.SpillComment,
                                      TranslationStatus = c.TranslationStatus,
                                      LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                      LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                      SpillLanguageWeb = new SpillLanguageWeb
                                      {
                                          LastUpdateContactTVText = LastUpdateContactTVText,
                                          LanguageText = (from e in LanguageEnumList
                                                          where e.EnumID == (int?)c.Language
                                                          select e.EnumText).FirstOrDefault(),
                                          TranslationStatusText = (from e in TranslationStatusEnumList
                                                                   where e.EnumID == (int?)c.TranslationStatus
                                                                   select e.EnumText).FirstOrDefault(),
                                      },
                                      SpillLanguageReport = new SpillLanguageReport
                                      {
                                          SpillLanguageReportTest = "SpillLanguageReportTest",
                                      },
                                      HasErrors = false,
                                      ValidationResults = null,
                                  });

            return spillLanguageQuery;
        }
        #endregion Functions private
    }
}
