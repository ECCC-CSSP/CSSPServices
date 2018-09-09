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
        #region Functions private Generated FillAddress_A
        private IQueryable<Address_A> FillAddress_A()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> AddressTypeEnumList = enums.GetEnumTextOrderedList(typeof(AddressTypeEnum));
            List<EnumIDAndText> StreetTypeEnumList = enums.GetEnumTextOrderedList(typeof(StreetTypeEnum));

             IQueryable<Address_A> Address_AQuery = (from c in db.Addresses
                let AddressText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.AddressTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let CountryText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.CountryTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let ProvinceText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.ProvinceTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let MunicipalityText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MunicipalityTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new Address_A
                    {
                        AddressText = AddressText,
                        CountryText = CountryText,
                        ProvinceText = ProvinceText,
                        MunicipalityText = MunicipalityText,
                        LastUpdateContactText = LastUpdateContactText,
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

            return Address_AQuery;
        }
        #endregion Functions private Generated FillAddress_A

    }
}
