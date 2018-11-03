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
    public partial class TVFileService
    {
        #region Functions private Generated FillTVFileExtraB
        private IQueryable<TVFileExtraB> FillTVFileExtraB()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));
            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> FilePurposeEnumList = enums.GetEnumTextOrderedList(typeof(FilePurposeEnum));
            List<EnumIDAndText> FileTypeEnumList = enums.GetEnumTextOrderedList(typeof(FileTypeEnum));

             IQueryable<TVFileExtraB> TVFileExtraBQuery = (from c in db.TVFiles
                let TVFileReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let TVFileName = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TVFileTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let TemplateTVTypeText = (from e in TVTypeEnumList
                    where e.EnumID == (int?)c.TemplateTVType
                    select e.EnumText).FirstOrDefault()
                let LanguageText = (from e in LanguageEnumList
                    where e.EnumID == (int?)c.Language
                    select e.EnumText).FirstOrDefault()
                let FilePurposeText = (from e in FilePurposeEnumList
                    where e.EnumID == (int?)c.FilePurpose
                    select e.EnumText).FirstOrDefault()
                let FileTypeText = (from e in FileTypeEnumList
                    where e.EnumID == (int?)c.FileType
                    select e.EnumText).FirstOrDefault()
                    select new TVFileExtraB
                    {
                        TVFileReportTest = TVFileReportTest,
                        TVFileName = TVFileName,
                        LastUpdateContactText = LastUpdateContactText,
                        TemplateTVTypeText = TemplateTVTypeText,
                        LanguageText = LanguageText,
                        FilePurposeText = FilePurposeText,
                        FileTypeText = FileTypeText,
                        TVFileID = c.TVFileID,
                        TVFileTVItemID = c.TVFileTVItemID,
                        TemplateTVType = c.TemplateTVType,
                        ReportTypeID = c.ReportTypeID,
                        Parameters = c.Parameters,
                        Year = c.Year,
                        Language = c.Language,
                        FilePurpose = c.FilePurpose,
                        FileType = c.FileType,
                        FileSize_kb = c.FileSize_kb,
                        FileInfo = c.FileInfo,
                        FileCreatedDate_UTC = c.FileCreatedDate_UTC,
                        FromWater = c.FromWater,
                        ClientFilePath = c.ClientFilePath,
                        ServerFileName = c.ServerFileName,
                        ServerFilePath = c.ServerFilePath,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return TVFileExtraBQuery;
        }
        #endregion Functions private Generated FillTVFileExtraB

    }
}