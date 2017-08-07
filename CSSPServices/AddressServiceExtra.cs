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

        //#region Functions public get
        //public Address GetAddressWithAddressTVItemID(int AddressTVItemID)
        //{
        //    IQueryable<Address> addressQuery = (from c in db.Addresses.AsNoTracking()
        //                                        where c.AddressTVItemID == AddressTVItemID
        //                                        select c);

        //    return FillAddress(addressQuery).FirstOrDefault();
        //}
        //#endregion Functions public get

        #region Functions private
        private void FillAddressTVText(Address address)
        {
            if (address.CountryTVItemID == 0)
            {
                address.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AddressCountryTVItemID)) };
                return;
            }

            if (address.ProvinceTVItemID == 0)
            {
                address.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AddressProvinceTVItemID)) };
                return;
            }

            if (address.MunicipalityTVItemID == 0)
            {
                address.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AddressMunicipalityTVItemID)) };
                return;
            }

            string CountryTVText = (from cl in db.TVItemLanguages.AsNoTracking()
                                    where cl.Language == LanguageRequest
                                    && cl.TVItemID == address.CountryTVItemID
                                    select cl.TVText).ToString();

            string ProvinceTVText = (from cl in db.TVItemLanguages.AsNoTracking()
                                    where cl.Language == LanguageRequest
                                    && cl.TVItemID == address.ProvinceTVItemID
                                    select cl.TVText).ToString();

            string MunicipalityTVText = (from cl in db.TVItemLanguages.AsNoTracking()
                                    where cl.Language == LanguageRequest
                                    && cl.TVItemID == address.MunicipalityTVItemID
                                    select cl.TVText).ToString();

            Enums enums = new Enums(LanguageRequest);
            if (LanguageRequest == LanguageEnum.fr)
            {
                address.AddressTVText = address.StreetNumber + " " + address.StreetName + ", " + MunicipalityTVText + "," + ProvinceTVText + "," + CountryTVText + ", " + enums.GetEnumText_StreetTypeEnum(address.StreetType) + "";
            }
            else
            {
                address.AddressTVText = address.StreetNumber + " " + address.StreetName + ", " + MunicipalityTVText + "," + ProvinceTVText + "," + CountryTVText + ", " + enums.GetEnumText_StreetTypeEnum(address.StreetType) + "";
            }
        }
        #endregion Functions private
    }
}
