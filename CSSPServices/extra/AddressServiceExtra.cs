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
using System.Threading;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class AddressService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Validation
        #endregion Validation

        #region Functions private
        public string FillAddressTVText(Address address)
        {
            if (address.CountryTVItemID == 0)
            {
                address.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AddressCountryTVItemID)) };
                return "";
            }

            if (address.ProvinceTVItemID == 0)
            {
                address.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AddressProvinceTVItemID)) };
                return "";
            }

            if (address.MunicipalityTVItemID == 0)
            {
                address.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AddressMunicipalityTVItemID)) };
                return "";
            }

            string CountryTVText = (from cl in db.TVItemLanguages.AsNoTracking()
                                    where cl.Language == LanguageRequest
                                    && cl.TVItemID == address.CountryTVItemID
                                    select cl.TVText).FirstOrDefault();

            string ProvinceTVText = (from cl in db.TVItemLanguages.AsNoTracking()
                                    where cl.Language == LanguageRequest
                                    && cl.TVItemID == address.ProvinceTVItemID
                                    select cl.TVText).FirstOrDefault();

            string MunicipalityTVText = (from cl in db.TVItemLanguages.AsNoTracking()
                                    where cl.Language == LanguageRequest
                                    && cl.TVItemID == address.MunicipalityTVItemID
                                    select cl.TVText).FirstOrDefault();

            Enums enums = new Enums(LanguageRequest);
            address.AddressWeb = new AddressWeb();
            if (LanguageRequest == LanguageEnum.fr)
            {
                return address.StreetNumber + " " + address.StreetName + ", " + MunicipalityTVText + ", " + ProvinceTVText + ", " + CountryTVText + ", " + enums.GetResValueForTypeAndID(typeof(StreetTypeEnum), (int?)address.StreetType) + "";
            }
            else
            {
                return address.StreetNumber + " " + address.StreetName + ", " + MunicipalityTVText + ", " + ProvinceTVText + ", " + CountryTVText + ", " + enums.GetResValueForTypeAndID(typeof(StreetTypeEnum), (int?)address.StreetType) + "";
            }
        }
        private IQueryable<Address> FillAddressReport(IQueryable<Address> addressQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> AddressTypeEnumList = enums.GetEnumTextOrderedList(typeof(AddressTypeEnum));
            List<EnumIDAndText> StreetTypeEnumList = enums.GetEnumTextOrderedList(typeof(StreetTypeEnum));

            addressQuery = (from c in addressQuery
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
                            select new Address
                            {
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
                                AddressWeb = new AddressWeb
                                {
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
                                },
                                AddressReport = new AddressReport
                                {
                                    AddressReportTest = "AddressReportTest",
                                },
                                HasErrors = false,
                                ValidationResults = null,
                            });

            return addressQuery;
        }

        #endregion Functions private
    }
}
