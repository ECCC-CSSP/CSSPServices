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
    public partial class AddressService
    {
        #region Functions private Generated AddressFillReport
        private IQueryable<AddressReport> FillAddressReport()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> AddressTypeEnumList = enums.GetEnumTextOrderedList(typeof(AddressTypeEnum));
            List<EnumIDAndText> StreetTypeEnumList = enums.GetEnumTextOrderedList(typeof(StreetTypeEnum));

             IQueryable<AddressReport>  AddressReportQuery = (from c in db.Addresses
                let AddressTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.AddressTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let CountryTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.CountryTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let ProvinceTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.ProvinceTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let MunicipalityTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MunicipalityTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new AddressReport
                    {
                        AddressReportTest = "Testing Report",
                        AddressTVItemLanguage = AddressTVItemLanguage,
                        CountryTVItemLanguage = CountryTVItemLanguage,
                        ProvinceTVItemLanguage = ProvinceTVItemLanguage,
                        MunicipalityTVItemLanguage = MunicipalityTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        AddressTypeText = (from e in AddressTypeEnumList
                                where e.EnumID == (int?)c.AddressType
                                select e.EnumText).FirstOrDefault(),
                        StreetTypeText = (from e in StreetTypeEnumList
                                where e.EnumID == (int?)c.StreetType
                                select e.EnumText).FirstOrDefault(),
                        AddressID = c.AddressID,
                        AddressTVItemID = c.AddressTVItemID,
                        AddressType = c.AddressType,
                        CountryTVItemID = c.CountryTVItemID,
                        ProvinceTVItemID = c.ProvinceTVItemID,
                        MunicipalityTVItemID = c.MunicipalityTVItemID,
                        StreetName = c.StreetName,
                        StreetNumber = c.StreetNumber,
                        StreetType = c.StreetType,
                        PostalCode = c.PostalCode,
                        GoogleAddressText = c.GoogleAddressText,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return AddressReportQuery;
        }
        #endregion Functions private Generated AddressFillReport

    }
}
