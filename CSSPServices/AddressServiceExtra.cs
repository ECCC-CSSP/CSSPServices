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
        public void FillAddressTVText(Address address)
        {
            if (address.CountryTVItemID == 0)
            {
                address.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AddressCountryTVItemID)) };
                return;
            }

            if (address.ProvinceTVItemID == 0)
            {
                address.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AddressProvinceTVItemID)) };
                return;
            }

            if (address.MunicipalityTVItemID == 0)
            {
                address.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AddressMunicipalityTVItemID)) };
                return;
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
                address.AddressWeb.AddressTVText = address.StreetNumber + " " + address.StreetName + ", " + MunicipalityTVText + ", " + ProvinceTVText + ", " + CountryTVText + ", " + enums.GetResValueForTypeAndID(typeof(StreetTypeEnum), (int?)address.StreetType) + "";
            }
            else
            {
                address.AddressWeb.AddressTVText = address.StreetNumber + " " + address.StreetName + ", " + MunicipalityTVText + ", " + ProvinceTVText + ", " + CountryTVText + ", " + enums.GetResValueForTypeAndID(typeof(StreetTypeEnum), (int?)address.StreetType) + "";
            }
        }
        private IQueryable<Address> FillAddress(IQueryable<Address> addressQuery, string FilterAndOrderText, EntityQueryDetailTypeEnum EntityQueryDetailType)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> AddressTypeEnumList = enums.GetEnumTextOrderedList(typeof(AddressTypeEnum));
            List<EnumIDAndText> StreetTypeEnumList = enums.GetEnumTextOrderedList(typeof(StreetTypeEnum));

            addressQuery = (from c in addressQuery
                            let ParentTVItemID = (from cl in db.TVItems
                                                  where cl.TVItemID == c.AddressTVItemID
                                                  select cl.ParentID).FirstOrDefault()
                            let AddressTVText = (from cl in db.TVItemLanguages
                                                 where cl.TVItemID == c.AddressTVItemID
                                                 && cl.Language == LanguageRequest
                                                 select cl.TVText).FirstOrDefault()
                            let CountryTVText = (from cl in db.TVItemLanguages
                                                 where cl.TVItemID == c.CountryTVItemID
                                                 && cl.Language == LanguageRequest
                                                 select cl.TVText).FirstOrDefault()
                            let ProvinceTVText = (from cl in db.TVItemLanguages
                                                  where cl.TVItemID == c.ProvinceTVItemID
                                                  && cl.Language == LanguageRequest
                                                  select cl.TVText).FirstOrDefault()
                            let MunicipalityTVText = (from cl in db.TVItemLanguages
                                                      where cl.TVItemID == c.MunicipalityTVItemID
                                                      && cl.Language == LanguageRequest
                                                      select cl.TVText).FirstOrDefault()
                            let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                           where cl.TVItemID == c.LastUpdateContactTVItemID
                                                           && cl.Language == LanguageRequest
                                                           select cl.TVText).FirstOrDefault()
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
                                HasErrors = false,
                                ValidationResults = null,
                                AddressWeb = new AddressWeb
                                {
                                    ParentTVItemID = ParentTVItemID,
                                    AddressTVText = AddressTVText,
                                    CountryTVText = CountryTVText,
                                    ProvinceTVText = ProvinceTVText,
                                    MunicipalityTVText = MunicipalityTVText,
                                    LastUpdateContactTVText = LastUpdateContactTVText,
                                    AddressTypeText = (from e in AddressTypeEnumList
                                                       where e.EnumID == (int?)c.AddressType
                                                       select e.EnumText).FirstOrDefault(),
                                    StreetTypeText = (from e in StreetTypeEnumList
                                                      where e.EnumID == (int?)c.StreetType
                                                      select e.EnumText).FirstOrDefault(),
                                },
                                AddressReport = (EntityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport ? new AddressReport()
                                {
                                    AddressReportTest = "Allo",
                                } : null),
                            });

            return addressQuery;
        }

        #endregion Functions private
    }
}
