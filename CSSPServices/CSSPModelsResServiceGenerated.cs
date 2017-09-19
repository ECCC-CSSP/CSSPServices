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
    /// <summary>
    ///     <para>bonjour CSSPModelsRes</para>
    /// </summary>
    public partial class CSSPModelsResService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public CSSPModelsResService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            CSSPModelsRes cSSPModelsRes = validationContext.ObjectInstance as CSSPModelsRes;
            cSSPModelsRes.HasErrors = false;

                //Error: Type not implemented [ResourceManager] of type [ResourceManager]

                //Error: Type not implemented [ResourceManager] of type [ResourceManager]
                //Error: Type not implemented [Culture] of type [CultureInfo]

                //Error: Type not implemented [Culture] of type [CultureInfo]
            if (string.IsNullOrWhiteSpace(cSSPModelsRes._IsRequired))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsRes_IsRequired), new[] { "_IsRequired" });
            }

            //_IsRequired has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.Address))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAddress), new[] { "Address" });
            }

            //Address has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AddressAddressID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAddressAddressID), new[] { "AddressAddressID" });
            }

            //AddressAddressID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AddressAddressTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAddressAddressTVItemID), new[] { "AddressAddressTVItemID" });
            }

            //AddressAddressTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AddressAddressTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAddressAddressTVText), new[] { "AddressAddressTVText" });
            }

            //AddressAddressTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AddressAddressType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAddressAddressType), new[] { "AddressAddressType" });
            }

            //AddressAddressType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AddressAddressTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAddressAddressTypeText), new[] { "AddressAddressTypeText" });
            }

            //AddressAddressTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AddressCountryTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAddressCountryTVItemID), new[] { "AddressCountryTVItemID" });
            }

            //AddressCountryTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AddressCountryTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAddressCountryTVText), new[] { "AddressCountryTVText" });
            }

            //AddressCountryTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AddressGoogleAddressText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAddressGoogleAddressText), new[] { "AddressGoogleAddressText" });
            }

            //AddressGoogleAddressText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AddressHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAddressHasErrors), new[] { "AddressHasErrors" });
            }

            //AddressHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AddressLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAddressLastUpdateContactTVItemID), new[] { "AddressLastUpdateContactTVItemID" });
            }

            //AddressLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AddressLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAddressLastUpdateContactTVText), new[] { "AddressLastUpdateContactTVText" });
            }

            //AddressLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AddressLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAddressLastUpdateDate_UTC), new[] { "AddressLastUpdateDate_UTC" });
            }

            //AddressLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AddressMunicipalityTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAddressMunicipalityTVItemID), new[] { "AddressMunicipalityTVItemID" });
            }

            //AddressMunicipalityTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AddressMunicipalityTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAddressMunicipalityTVText), new[] { "AddressMunicipalityTVText" });
            }

            //AddressMunicipalityTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AddressParentTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAddressParentTVItemID), new[] { "AddressParentTVItemID" });
            }

            //AddressParentTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AddressPostalCode))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAddressPostalCode), new[] { "AddressPostalCode" });
            }

            //AddressPostalCode has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AddressProvinceTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAddressProvinceTVItemID), new[] { "AddressProvinceTVItemID" });
            }

            //AddressProvinceTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AddressProvinceTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAddressProvinceTVText), new[] { "AddressProvinceTVText" });
            }

            //AddressProvinceTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AddressStreetName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAddressStreetName), new[] { "AddressStreetName" });
            }

            //AddressStreetName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AddressStreetNumber))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAddressStreetNumber), new[] { "AddressStreetNumber" });
            }

            //AddressStreetNumber has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AddressStreetType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAddressStreetType), new[] { "AddressStreetType" });
            }

            //AddressStreetType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AddressStreetTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAddressStreetTypeText), new[] { "AddressStreetTypeText" });
            }

            //AddressStreetTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppErrLog))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppErrLog), new[] { "AppErrLog" });
            }

            //AppErrLog has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppErrLogAppErrLogID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppErrLogAppErrLogID), new[] { "AppErrLogAppErrLogID" });
            }

            //AppErrLogAppErrLogID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppErrLogDateTime_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppErrLogDateTime_UTC), new[] { "AppErrLogDateTime_UTC" });
            }

            //AppErrLogDateTime_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppErrLogHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppErrLogHasErrors), new[] { "AppErrLogHasErrors" });
            }

            //AppErrLogHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppErrLogLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppErrLogLastUpdateContactTVItemID), new[] { "AppErrLogLastUpdateContactTVItemID" });
            }

            //AppErrLogLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppErrLogLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppErrLogLastUpdateContactTVText), new[] { "AppErrLogLastUpdateContactTVText" });
            }

            //AppErrLogLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppErrLogLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppErrLogLastUpdateDate_UTC), new[] { "AppErrLogLastUpdateDate_UTC" });
            }

            //AppErrLogLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppErrLogLineNumber))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppErrLogLineNumber), new[] { "AppErrLogLineNumber" });
            }

            //AppErrLogLineNumber has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppErrLogMessage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppErrLogMessage), new[] { "AppErrLogMessage" });
            }

            //AppErrLogMessage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppErrLogSource))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppErrLogSource), new[] { "AppErrLogSource" });
            }

            //AppErrLogSource has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppErrLogTag))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppErrLogTag), new[] { "AppErrLogTag" });
            }

            //AppErrLogTag has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTask))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTask), new[] { "AppTask" });
            }

            //AppTask has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskAppTaskCommand))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskAppTaskCommand), new[] { "AppTaskAppTaskCommand" });
            }

            //AppTaskAppTaskCommand has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskAppTaskCommandText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskAppTaskCommandText), new[] { "AppTaskAppTaskCommandText" });
            }

            //AppTaskAppTaskCommandText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskAppTaskID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskAppTaskID), new[] { "AppTaskAppTaskID" });
            }

            //AppTaskAppTaskID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskAppTaskStatus))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskAppTaskStatus), new[] { "AppTaskAppTaskStatus" });
            }

            //AppTaskAppTaskStatus has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskAppTaskStatusText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskAppTaskStatusText), new[] { "AppTaskAppTaskStatusText" });
            }

            //AppTaskAppTaskStatusText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskEndDateTime_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskEndDateTime_UTC), new[] { "AppTaskEndDateTime_UTC" });
            }

            //AppTaskEndDateTime_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskEstimatedLength_second))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskEstimatedLength_second), new[] { "AppTaskEstimatedLength_second" });
            }

            //AppTaskEstimatedLength_second has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskHasErrors), new[] { "AppTaskHasErrors" });
            }

            //AppTaskHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskLanguage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskLanguage), new[] { "AppTaskLanguage" });
            }

            //AppTaskLanguage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskLanguageAppTaskID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskLanguageAppTaskID), new[] { "AppTaskLanguageAppTaskID" });
            }

            //AppTaskLanguageAppTaskID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskLanguageAppTaskLanguageID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskLanguageAppTaskLanguageID), new[] { "AppTaskLanguageAppTaskLanguageID" });
            }

            //AppTaskLanguageAppTaskLanguageID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskLanguageErrorText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskLanguageErrorText), new[] { "AppTaskLanguageErrorText" });
            }

            //AppTaskLanguageErrorText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskLanguageHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskLanguageHasErrors), new[] { "AppTaskLanguageHasErrors" });
            }

            //AppTaskLanguageHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskLanguageLanguage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskLanguageLanguage), new[] { "AppTaskLanguageLanguage" });
            }

            //AppTaskLanguageLanguage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskLanguageLanguageText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskLanguageLanguageText), new[] { "AppTaskLanguageLanguageText" });
            }

            //AppTaskLanguageLanguageText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskLanguageLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskLanguageLastUpdateContactTVItemID), new[] { "AppTaskLanguageLastUpdateContactTVItemID" });
            }

            //AppTaskLanguageLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskLanguageLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskLanguageLastUpdateContactTVText), new[] { "AppTaskLanguageLastUpdateContactTVText" });
            }

            //AppTaskLanguageLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskLanguageLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskLanguageLastUpdateDate_UTC), new[] { "AppTaskLanguageLastUpdateDate_UTC" });
            }

            //AppTaskLanguageLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskLanguageStatusText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskLanguageStatusText), new[] { "AppTaskLanguageStatusText" });
            }

            //AppTaskLanguageStatusText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskLanguageText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskLanguageText), new[] { "AppTaskLanguageText" });
            }

            //AppTaskLanguageText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskLanguageTranslationStatus))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskLanguageTranslationStatus), new[] { "AppTaskLanguageTranslationStatus" });
            }

            //AppTaskLanguageTranslationStatus has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskLanguageTranslationStatusText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskLanguageTranslationStatusText), new[] { "AppTaskLanguageTranslationStatusText" });
            }

            //AppTaskLanguageTranslationStatusText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskLastUpdateContactTVItemID), new[] { "AppTaskLastUpdateContactTVItemID" });
            }

            //AppTaskLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskLastUpdateContactTVText), new[] { "AppTaskLastUpdateContactTVText" });
            }

            //AppTaskLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskLastUpdateDate_UTC), new[] { "AppTaskLastUpdateDate_UTC" });
            }

            //AppTaskLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskParameter))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskParameter), new[] { "AppTaskParameter" });
            }

            //AppTaskParameter has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskParameterHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskParameterHasErrors), new[] { "AppTaskParameterHasErrors" });
            }

            //AppTaskParameterHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskParameterName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskParameterName), new[] { "AppTaskParameterName" });
            }

            //AppTaskParameterName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskParameters))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskParameters), new[] { "AppTaskParameters" });
            }

            //AppTaskParameters has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskParameterValue))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskParameterValue), new[] { "AppTaskParameterValue" });
            }

            //AppTaskParameterValue has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskPercentCompleted))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskPercentCompleted), new[] { "AppTaskPercentCompleted" });
            }

            //AppTaskPercentCompleted has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskRemainingTime_second))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskRemainingTime_second), new[] { "AppTaskRemainingTime_second" });
            }

            //AppTaskRemainingTime_second has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskStartDateTime_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskStartDateTime_UTC), new[] { "AppTaskStartDateTime_UTC" });
            }

            //AppTaskStartDateTime_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskTVItem2TVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskTVItem2TVText), new[] { "AppTaskTVItem2TVText" });
            }

            //AppTaskTVItem2TVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskTVItemID), new[] { "AppTaskTVItemID" });
            }

            //AppTaskTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskTVItemID2))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskTVItemID2), new[] { "AppTaskTVItemID2" });
            }

            //AppTaskTVItemID2 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.AppTaskTVItemTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResAppTaskTVItemTVText), new[] { "AppTaskTVItemTVText" });
            }

            //AppTaskTVItemTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModel))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModel), new[] { "BoxModel" });
            }

            //BoxModel has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelBoxModelID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelBoxModelID), new[] { "BoxModelBoxModelID" });
            }

            //BoxModelBoxModelID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelCalNumb))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelCalNumb), new[] { "BoxModelCalNumb" });
            }

            //BoxModelCalNumb has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelCalNumbBoxModelResultType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelCalNumbBoxModelResultType), new[] { "BoxModelCalNumbBoxModelResultType" });
            }

            //BoxModelCalNumbBoxModelResultType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelCalNumbBoxModelResultTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelCalNumbBoxModelResultTypeText), new[] { "BoxModelCalNumbBoxModelResultTypeText" });
            }

            //BoxModelCalNumbBoxModelResultTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelCalNumbCalLength_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelCalNumbCalLength_m), new[] { "BoxModelCalNumbCalLength_m" });
            }

            //BoxModelCalNumbCalLength_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelCalNumbCalRadius_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelCalNumbCalRadius_m), new[] { "BoxModelCalNumbCalRadius_m" });
            }

            //BoxModelCalNumbCalRadius_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelCalNumbCalSurface_m2))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelCalNumbCalSurface_m2), new[] { "BoxModelCalNumbCalSurface_m2" });
            }

            //BoxModelCalNumbCalSurface_m2 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelCalNumbCalVolume_m3))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelCalNumbCalVolume_m3), new[] { "BoxModelCalNumbCalVolume_m3" });
            }

            //BoxModelCalNumbCalVolume_m3 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelCalNumbCalWidth_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelCalNumbCalWidth_m), new[] { "BoxModelCalNumbCalWidth_m" });
            }

            //BoxModelCalNumbCalWidth_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelCalNumbError))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelCalNumbError), new[] { "BoxModelCalNumbError" });
            }

            //BoxModelCalNumbError has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelCalNumbFixLength))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelCalNumbFixLength), new[] { "BoxModelCalNumbFixLength" });
            }

            //BoxModelCalNumbFixLength has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelCalNumbFixWidth))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelCalNumbFixWidth), new[] { "BoxModelCalNumbFixWidth" });
            }

            //BoxModelCalNumbFixWidth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelCalNumbHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelCalNumbHasErrors), new[] { "BoxModelCalNumbHasErrors" });
            }

            //BoxModelCalNumbHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelConcentration_MPN_100ml))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelConcentration_MPN_100ml), new[] { "BoxModelConcentration_MPN_100ml" });
            }

            //BoxModelConcentration_MPN_100ml has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelDecayRate_per_day))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelDecayRate_per_day), new[] { "BoxModelDecayRate_per_day" });
            }

            //BoxModelDecayRate_per_day has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelDepth_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelDepth_m), new[] { "BoxModelDepth_m" });
            }

            //BoxModelDepth_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelDilution))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelDilution), new[] { "BoxModelDilution" });
            }

            //BoxModelDilution has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelFCPreDisinfection_MPN_100ml))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelFCPreDisinfection_MPN_100ml), new[] { "BoxModelFCPreDisinfection_MPN_100ml" });
            }

            //BoxModelFCPreDisinfection_MPN_100ml has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelFCUntreated_MPN_100ml))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelFCUntreated_MPN_100ml), new[] { "BoxModelFCUntreated_MPN_100ml" });
            }

            //BoxModelFCUntreated_MPN_100ml has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelFlow_m3_day))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelFlow_m3_day), new[] { "BoxModelFlow_m3_day" });
            }

            //BoxModelFlow_m3_day has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelFlowDuration_hour))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelFlowDuration_hour), new[] { "BoxModelFlowDuration_hour" });
            }

            //BoxModelFlowDuration_hour has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelHasErrors), new[] { "BoxModelHasErrors" });
            }

            //BoxModelHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelInfrastructureTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelInfrastructureTVItemID), new[] { "BoxModelInfrastructureTVItemID" });
            }

            //BoxModelInfrastructureTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelInfrastructureTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelInfrastructureTVText), new[] { "BoxModelInfrastructureTVText" });
            }

            //BoxModelInfrastructureTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelLanguage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelLanguage), new[] { "BoxModelLanguage" });
            }

            //BoxModelLanguage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelLanguageBoxModelID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelLanguageBoxModelID), new[] { "BoxModelLanguageBoxModelID" });
            }

            //BoxModelLanguageBoxModelID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelLanguageBoxModelLanguageID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelLanguageBoxModelLanguageID), new[] { "BoxModelLanguageBoxModelLanguageID" });
            }

            //BoxModelLanguageBoxModelLanguageID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelLanguageHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelLanguageHasErrors), new[] { "BoxModelLanguageHasErrors" });
            }

            //BoxModelLanguageHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelLanguageLanguage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelLanguageLanguage), new[] { "BoxModelLanguageLanguage" });
            }

            //BoxModelLanguageLanguage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelLanguageLanguageText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelLanguageLanguageText), new[] { "BoxModelLanguageLanguageText" });
            }

            //BoxModelLanguageLanguageText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelLanguageLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelLanguageLastUpdateContactTVItemID), new[] { "BoxModelLanguageLastUpdateContactTVItemID" });
            }

            //BoxModelLanguageLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelLanguageLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelLanguageLastUpdateContactTVText), new[] { "BoxModelLanguageLastUpdateContactTVText" });
            }

            //BoxModelLanguageLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelLanguageLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelLanguageLastUpdateDate_UTC), new[] { "BoxModelLanguageLastUpdateDate_UTC" });
            }

            //BoxModelLanguageLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelLanguageScenarioName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelLanguageScenarioName), new[] { "BoxModelLanguageScenarioName" });
            }

            //BoxModelLanguageScenarioName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelLanguageTranslationStatus))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelLanguageTranslationStatus), new[] { "BoxModelLanguageTranslationStatus" });
            }

            //BoxModelLanguageTranslationStatus has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelLanguageTranslationStatusText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelLanguageTranslationStatusText), new[] { "BoxModelLanguageTranslationStatusText" });
            }

            //BoxModelLanguageTranslationStatusText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelLastUpdateContactTVItemID), new[] { "BoxModelLastUpdateContactTVItemID" });
            }

            //BoxModelLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelLastUpdateContactTVText), new[] { "BoxModelLastUpdateContactTVText" });
            }

            //BoxModelLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelLastUpdateDate_UTC), new[] { "BoxModelLastUpdateDate_UTC" });
            }

            //BoxModelLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelResult))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelResult), new[] { "BoxModelResult" });
            }

            //BoxModelResult has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelResultBoxModelID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelResultBoxModelID), new[] { "BoxModelResultBoxModelID" });
            }

            //BoxModelResultBoxModelID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelResultBoxModelResultID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelResultBoxModelResultID), new[] { "BoxModelResultBoxModelResultID" });
            }

            //BoxModelResultBoxModelResultID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelResultBoxModelResultType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelResultBoxModelResultType), new[] { "BoxModelResultBoxModelResultType" });
            }

            //BoxModelResultBoxModelResultType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelResultBoxModelResultTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelResultBoxModelResultTypeText), new[] { "BoxModelResultBoxModelResultTypeText" });
            }

            //BoxModelResultBoxModelResultTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelResultCircleCenterLatitude))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelResultCircleCenterLatitude), new[] { "BoxModelResultCircleCenterLatitude" });
            }

            //BoxModelResultCircleCenterLatitude has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelResultCircleCenterLongitude))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelResultCircleCenterLongitude), new[] { "BoxModelResultCircleCenterLongitude" });
            }

            //BoxModelResultCircleCenterLongitude has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelResultFixLength))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelResultFixLength), new[] { "BoxModelResultFixLength" });
            }

            //BoxModelResultFixLength has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelResultFixWidth))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelResultFixWidth), new[] { "BoxModelResultFixWidth" });
            }

            //BoxModelResultFixWidth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelResultHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelResultHasErrors), new[] { "BoxModelResultHasErrors" });
            }

            //BoxModelResultHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelResultLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelResultLastUpdateContactTVItemID), new[] { "BoxModelResultLastUpdateContactTVItemID" });
            }

            //BoxModelResultLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelResultLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelResultLastUpdateContactTVText), new[] { "BoxModelResultLastUpdateContactTVText" });
            }

            //BoxModelResultLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelResultLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelResultLastUpdateDate_UTC), new[] { "BoxModelResultLastUpdateDate_UTC" });
            }

            //BoxModelResultLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelResultLeftSideDiameterLineAngle_deg))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelResultLeftSideDiameterLineAngle_deg), new[] { "BoxModelResultLeftSideDiameterLineAngle_deg" });
            }

            //BoxModelResultLeftSideDiameterLineAngle_deg has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelResultLeftSideLineAngle_deg))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelResultLeftSideLineAngle_deg), new[] { "BoxModelResultLeftSideLineAngle_deg" });
            }

            //BoxModelResultLeftSideLineAngle_deg has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelResultLeftSideLineStartLatitude))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelResultLeftSideLineStartLatitude), new[] { "BoxModelResultLeftSideLineStartLatitude" });
            }

            //BoxModelResultLeftSideLineStartLatitude has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelResultLeftSideLineStartLongitude))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelResultLeftSideLineStartLongitude), new[] { "BoxModelResultLeftSideLineStartLongitude" });
            }

            //BoxModelResultLeftSideLineStartLongitude has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelResultRadius_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelResultRadius_m), new[] { "BoxModelResultRadius_m" });
            }

            //BoxModelResultRadius_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelResultRectLength_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelResultRectLength_m), new[] { "BoxModelResultRectLength_m" });
            }

            //BoxModelResultRectLength_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelResultRectWidth_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelResultRectWidth_m), new[] { "BoxModelResultRectWidth_m" });
            }

            //BoxModelResultRectWidth_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelResultSurface_m2))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelResultSurface_m2), new[] { "BoxModelResultSurface_m2" });
            }

            //BoxModelResultSurface_m2 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelResultVolume_m3))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelResultVolume_m3), new[] { "BoxModelResultVolume_m3" });
            }

            //BoxModelResultVolume_m3 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelT90_hour))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelT90_hour), new[] { "BoxModelT90_hour" });
            }

            //BoxModelT90_hour has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.BoxModelTemperature_C))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResBoxModelTemperature_C), new[] { "BoxModelTemperature_C" });
            }

            //BoxModelTemperature_C has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CalDecay))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCalDecay), new[] { "CalDecay" });
            }

            //CalDecay has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CalDecayDecay))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCalDecayDecay), new[] { "CalDecayDecay" });
            }

            //CalDecayDecay has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CalDecayError))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCalDecayError), new[] { "CalDecayError" });
            }

            //CalDecayError has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CalDecayHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCalDecayHasErrors), new[] { "CalDecayHasErrors" });
            }

            //CalDecayHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateDataValue))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateDataValue), new[] { "ClimateDataValue" });
            }

            //ClimateDataValue has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateDataValueClimateDataValueID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateDataValueClimateDataValueID), new[] { "ClimateDataValueClimateDataValueID" });
            }

            //ClimateDataValueClimateDataValueID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateDataValueClimateSiteID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateDataValueClimateSiteID), new[] { "ClimateDataValueClimateSiteID" });
            }

            //ClimateDataValueClimateSiteID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateDataValueCoolDegDays_C))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateDataValueCoolDegDays_C), new[] { "ClimateDataValueCoolDegDays_C" });
            }

            //ClimateDataValueCoolDegDays_C has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateDataValueDateTime_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateDataValueDateTime_Local), new[] { "ClimateDataValueDateTime_Local" });
            }

            //ClimateDataValueDateTime_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateDataValueDirMaxGust_0North))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateDataValueDirMaxGust_0North), new[] { "ClimateDataValueDirMaxGust_0North" });
            }

            //ClimateDataValueDirMaxGust_0North has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateDataValueHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateDataValueHasErrors), new[] { "ClimateDataValueHasErrors" });
            }

            //ClimateDataValueHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateDataValueHeatDegDays_C))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateDataValueHeatDegDays_C), new[] { "ClimateDataValueHeatDegDays_C" });
            }

            //ClimateDataValueHeatDegDays_C has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateDataValueHourlyValues))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateDataValueHourlyValues), new[] { "ClimateDataValueHourlyValues" });
            }

            //ClimateDataValueHourlyValues has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateDataValueKeep))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateDataValueKeep), new[] { "ClimateDataValueKeep" });
            }

            //ClimateDataValueKeep has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateDataValueLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateDataValueLastUpdateContactTVItemID), new[] { "ClimateDataValueLastUpdateContactTVItemID" });
            }

            //ClimateDataValueLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateDataValueLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateDataValueLastUpdateContactTVText), new[] { "ClimateDataValueLastUpdateContactTVText" });
            }

            //ClimateDataValueLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateDataValueLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateDataValueLastUpdateDate_UTC), new[] { "ClimateDataValueLastUpdateDate_UTC" });
            }

            //ClimateDataValueLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateDataValueMaxTemp_C))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateDataValueMaxTemp_C), new[] { "ClimateDataValueMaxTemp_C" });
            }

            //ClimateDataValueMaxTemp_C has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateDataValueMinTemp_C))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateDataValueMinTemp_C), new[] { "ClimateDataValueMinTemp_C" });
            }

            //ClimateDataValueMinTemp_C has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateDataValueRainfall_mm))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateDataValueRainfall_mm), new[] { "ClimateDataValueRainfall_mm" });
            }

            //ClimateDataValueRainfall_mm has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateDataValueRainfallEntered_mm))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateDataValueRainfallEntered_mm), new[] { "ClimateDataValueRainfallEntered_mm" });
            }

            //ClimateDataValueRainfallEntered_mm has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateDataValueSnow_cm))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateDataValueSnow_cm), new[] { "ClimateDataValueSnow_cm" });
            }

            //ClimateDataValueSnow_cm has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateDataValueSnowOnGround_cm))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateDataValueSnowOnGround_cm), new[] { "ClimateDataValueSnowOnGround_cm" });
            }

            //ClimateDataValueSnowOnGround_cm has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateDataValueSpdMaxGust_kmh))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateDataValueSpdMaxGust_kmh), new[] { "ClimateDataValueSpdMaxGust_kmh" });
            }

            //ClimateDataValueSpdMaxGust_kmh has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateDataValueStorageDataType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateDataValueStorageDataType), new[] { "ClimateDataValueStorageDataType" });
            }

            //ClimateDataValueStorageDataType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateDataValueStorageDataTypeEnumText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateDataValueStorageDataTypeEnumText), new[] { "ClimateDataValueStorageDataTypeEnumText" });
            }

            //ClimateDataValueStorageDataTypeEnumText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateDataValueTotalPrecip_mm_cm))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateDataValueTotalPrecip_mm_cm), new[] { "ClimateDataValueTotalPrecip_mm_cm" });
            }

            //ClimateDataValueTotalPrecip_mm_cm has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateSite))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateSite), new[] { "ClimateSite" });
            }

            //ClimateSite has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateSiteClimateID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateSiteClimateID), new[] { "ClimateSiteClimateID" });
            }

            //ClimateSiteClimateID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateSiteClimateSiteID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateSiteClimateSiteID), new[] { "ClimateSiteClimateSiteID" });
            }

            //ClimateSiteClimateSiteID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateSiteClimateSiteName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateSiteClimateSiteName), new[] { "ClimateSiteClimateSiteName" });
            }

            //ClimateSiteClimateSiteName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateSiteClimateSiteTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateSiteClimateSiteTVItemID), new[] { "ClimateSiteClimateSiteTVItemID" });
            }

            //ClimateSiteClimateSiteTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateSiteClimateSiteTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateSiteClimateSiteTVText), new[] { "ClimateSiteClimateSiteTVText" });
            }

            //ClimateSiteClimateSiteTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateSiteDailyEndDate_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateSiteDailyEndDate_Local), new[] { "ClimateSiteDailyEndDate_Local" });
            }

            //ClimateSiteDailyEndDate_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateSiteDailyNow))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateSiteDailyNow), new[] { "ClimateSiteDailyNow" });
            }

            //ClimateSiteDailyNow has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateSiteDailyStartDate_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateSiteDailyStartDate_Local), new[] { "ClimateSiteDailyStartDate_Local" });
            }

            //ClimateSiteDailyStartDate_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateSiteECDBID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateSiteECDBID), new[] { "ClimateSiteECDBID" });
            }

            //ClimateSiteECDBID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateSiteElevation_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateSiteElevation_m), new[] { "ClimateSiteElevation_m" });
            }

            //ClimateSiteElevation_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateSiteFile_desc))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateSiteFile_desc), new[] { "ClimateSiteFile_desc" });
            }

            //ClimateSiteFile_desc has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateSiteHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateSiteHasErrors), new[] { "ClimateSiteHasErrors" });
            }

            //ClimateSiteHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateSiteHourlyEndDate_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateSiteHourlyEndDate_Local), new[] { "ClimateSiteHourlyEndDate_Local" });
            }

            //ClimateSiteHourlyEndDate_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateSiteHourlyNow))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateSiteHourlyNow), new[] { "ClimateSiteHourlyNow" });
            }

            //ClimateSiteHourlyNow has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateSiteHourlyStartDate_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateSiteHourlyStartDate_Local), new[] { "ClimateSiteHourlyStartDate_Local" });
            }

            //ClimateSiteHourlyStartDate_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateSiteIsProvincial))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateSiteIsProvincial), new[] { "ClimateSiteIsProvincial" });
            }

            //ClimateSiteIsProvincial has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateSiteLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateSiteLastUpdateContactTVItemID), new[] { "ClimateSiteLastUpdateContactTVItemID" });
            }

            //ClimateSiteLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateSiteLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateSiteLastUpdateContactTVText), new[] { "ClimateSiteLastUpdateContactTVText" });
            }

            //ClimateSiteLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateSiteLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateSiteLastUpdateDate_UTC), new[] { "ClimateSiteLastUpdateDate_UTC" });
            }

            //ClimateSiteLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateSiteMonthlyEndDate_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateSiteMonthlyEndDate_Local), new[] { "ClimateSiteMonthlyEndDate_Local" });
            }

            //ClimateSiteMonthlyEndDate_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateSiteMonthlyNow))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateSiteMonthlyNow), new[] { "ClimateSiteMonthlyNow" });
            }

            //ClimateSiteMonthlyNow has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateSiteMonthlyStartDate_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateSiteMonthlyStartDate_Local), new[] { "ClimateSiteMonthlyStartDate_Local" });
            }

            //ClimateSiteMonthlyStartDate_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateSiteProvince))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateSiteProvince), new[] { "ClimateSiteProvince" });
            }

            //ClimateSiteProvince has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateSiteProvSiteID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateSiteProvSiteID), new[] { "ClimateSiteProvSiteID" });
            }

            //ClimateSiteProvSiteID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateSiteTCID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateSiteTCID), new[] { "ClimateSiteTCID" });
            }

            //ClimateSiteTCID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateSiteTimeOffset_hour))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateSiteTimeOffset_hour), new[] { "ClimateSiteTimeOffset_hour" });
            }

            //ClimateSiteTimeOffset_hour has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ClimateSiteWMOID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResClimateSiteWMOID), new[] { "ClimateSiteWMOID" });
            }

            //ClimateSiteWMOID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.Contact))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContact), new[] { "Contact" });
            }

            //Contact has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactContactID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactContactID), new[] { "ContactContactID" });
            }

            //ContactContactID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactContactTitle))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactContactTitle), new[] { "ContactContactTitle" });
            }

            //ContactContactTitle has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactContactTitleText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactContactTitleText), new[] { "ContactContactTitleText" });
            }

            //ContactContactTitleText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactContactTVItemID), new[] { "ContactContactTVItemID" });
            }

            //ContactContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactContactTVText), new[] { "ContactContactTVText" });
            }

            //ContactContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactDisabled))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactDisabled), new[] { "ContactDisabled" });
            }

            //ContactDisabled has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactEmailValidated))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactEmailValidated), new[] { "ContactEmailValidated" });
            }

            //ContactEmailValidated has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactFirstName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactFirstName), new[] { "ContactFirstName" });
            }

            //ContactFirstName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactHasErrors), new[] { "ContactHasErrors" });
            }

            //ContactHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactId))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactId), new[] { "ContactId" });
            }

            //ContactId has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactInitial))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactInitial), new[] { "ContactInitial" });
            }

            //ContactInitial has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactIsAdmin))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactIsAdmin), new[] { "ContactIsAdmin" });
            }

            //ContactIsAdmin has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactIsNew))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactIsNew), new[] { "ContactIsNew" });
            }

            //ContactIsNew has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactLastName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactLastName), new[] { "ContactLastName" });
            }

            //ContactLastName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactLastUpdateContactTVItemID), new[] { "ContactLastUpdateContactTVItemID" });
            }

            //ContactLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactLastUpdateContactTVText), new[] { "ContactLastUpdateContactTVText" });
            }

            //ContactLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactLastUpdateDate_UTC), new[] { "ContactLastUpdateDate_UTC" });
            }

            //ContactLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactLogin))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactLogin), new[] { "ContactLogin" });
            }

            //ContactLogin has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactLoginConfirmPassword))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactLoginConfirmPassword), new[] { "ContactLoginConfirmPassword" });
            }

            //ContactLoginConfirmPassword has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactLoginContactID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactLoginContactID), new[] { "ContactLoginContactID" });
            }

            //ContactLoginContactID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactLoginContactLoginID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactLoginContactLoginID), new[] { "ContactLoginContactLoginID" });
            }

            //ContactLoginContactLoginID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactLoginEmail))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactLoginEmail), new[] { "ContactLoginEmail" });
            }

            //ContactLoginEmail has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactLoginHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactLoginHasErrors), new[] { "ContactLoginHasErrors" });
            }

            //ContactLoginHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactLoginLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactLoginLastUpdateContactTVItemID), new[] { "ContactLoginLastUpdateContactTVItemID" });
            }

            //ContactLoginLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactLoginLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactLoginLastUpdateContactTVText), new[] { "ContactLoginLastUpdateContactTVText" });
            }

            //ContactLoginLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactLoginLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactLoginLastUpdateDate_UTC), new[] { "ContactLoginLastUpdateDate_UTC" });
            }

            //ContactLoginLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactLoginLoginEmail))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactLoginLoginEmail), new[] { "ContactLoginLoginEmail" });
            }

            //ContactLoginLoginEmail has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactLoginPassword))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactLoginPassword), new[] { "ContactLoginPassword" });
            }

            //ContactLoginPassword has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactLoginPasswordHash))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactLoginPasswordHash), new[] { "ContactLoginPasswordHash" });
            }

            //ContactLoginPasswordHash has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactLoginPasswordSalt))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactLoginPasswordSalt), new[] { "ContactLoginPasswordSalt" });
            }

            //ContactLoginPasswordSalt has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactOK))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactOK), new[] { "ContactOK" });
            }

            //ContactOK has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactOKContactID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactOKContactID), new[] { "ContactOKContactID" });
            }

            //ContactOKContactID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactOKContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactOKContactTVItemID), new[] { "ContactOKContactTVItemID" });
            }

            //ContactOKContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactOKError))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactOKError), new[] { "ContactOKError" });
            }

            //ContactOKError has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactOKHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactOKHasErrors), new[] { "ContactOKHasErrors" });
            }

            //ContactOKHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactParentTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactParentTVItemID), new[] { "ContactParentTVItemID" });
            }

            //ContactParentTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactPreference))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactPreference), new[] { "ContactPreference" });
            }

            //ContactPreference has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactPreferenceContactID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactPreferenceContactID), new[] { "ContactPreferenceContactID" });
            }

            //ContactPreferenceContactID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactPreferenceContactPreferenceID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactPreferenceContactPreferenceID), new[] { "ContactPreferenceContactPreferenceID" });
            }

            //ContactPreferenceContactPreferenceID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactPreferenceHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactPreferenceHasErrors), new[] { "ContactPreferenceHasErrors" });
            }

            //ContactPreferenceHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactPreferenceLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactPreferenceLastUpdateContactTVItemID), new[] { "ContactPreferenceLastUpdateContactTVItemID" });
            }

            //ContactPreferenceLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactPreferenceLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactPreferenceLastUpdateContactTVText), new[] { "ContactPreferenceLastUpdateContactTVText" });
            }

            //ContactPreferenceLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactPreferenceLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactPreferenceLastUpdateDate_UTC), new[] { "ContactPreferenceLastUpdateDate_UTC" });
            }

            //ContactPreferenceLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactPreferenceMarkerSize))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactPreferenceMarkerSize), new[] { "ContactPreferenceMarkerSize" });
            }

            //ContactPreferenceMarkerSize has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactPreferenceTVType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactPreferenceTVType), new[] { "ContactPreferenceTVType" });
            }

            //ContactPreferenceTVType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactPreferenceTVTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactPreferenceTVTypeText), new[] { "ContactPreferenceTVTypeText" });
            }

            //ContactPreferenceTVTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactSamplingPlanner_ProvincesTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactSamplingPlanner_ProvincesTVItemID), new[] { "ContactSamplingPlanner_ProvincesTVItemID" });
            }

            //ContactSamplingPlanner_ProvincesTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactSearch))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactSearch), new[] { "ContactSearch" });
            }

            //ContactSearch has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactSearchContactID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactSearchContactID), new[] { "ContactSearchContactID" });
            }

            //ContactSearchContactID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactSearchContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactSearchContactTVItemID), new[] { "ContactSearchContactTVItemID" });
            }

            //ContactSearchContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactSearchFullName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactSearchFullName), new[] { "ContactSearchFullName" });
            }

            //ContactSearchFullName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactSearchHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactSearchHasErrors), new[] { "ContactSearchHasErrors" });
            }

            //ContactSearchHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactShortcut))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactShortcut), new[] { "ContactShortcut" });
            }

            //ContactShortcut has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactShortcutContactID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactShortcutContactID), new[] { "ContactShortcutContactID" });
            }

            //ContactShortcutContactID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactShortcutContactShortcutID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactShortcutContactShortcutID), new[] { "ContactShortcutContactShortcutID" });
            }

            //ContactShortcutContactShortcutID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactShortcutHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactShortcutHasErrors), new[] { "ContactShortcutHasErrors" });
            }

            //ContactShortcutHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactShortcutLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactShortcutLastUpdateContactTVItemID), new[] { "ContactShortcutLastUpdateContactTVItemID" });
            }

            //ContactShortcutLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactShortcutLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactShortcutLastUpdateContactTVText), new[] { "ContactShortcutLastUpdateContactTVText" });
            }

            //ContactShortcutLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactShortcutLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactShortcutLastUpdateDate_UTC), new[] { "ContactShortcutLastUpdateDate_UTC" });
            }

            //ContactShortcutLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactShortcutShortCutAddress))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactShortcutShortCutAddress), new[] { "ContactShortcutShortCutAddress" });
            }

            //ContactShortcutShortCutAddress has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactShortcutShortCutText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactShortcutShortCutText), new[] { "ContactShortcutShortCutText" });
            }

            //ContactShortcutShortCutText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContactWebName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContactWebName), new[] { "ContactWebName" });
            }

            //ContactWebName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContourPolygon))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContourPolygon), new[] { "ContourPolygon" });
            }

            //ContourPolygon has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContourPolygonContourNodeList))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContourPolygonContourNodeList), new[] { "ContourPolygonContourNodeList" });
            }

            //ContourPolygonContourNodeList has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContourPolygonContourValue))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContourPolygonContourValue), new[] { "ContourPolygonContourValue" });
            }

            //ContourPolygonContourValue has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContourPolygonDepth))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContourPolygonDepth), new[] { "ContourPolygonDepth" });
            }

            //ContourPolygonDepth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContourPolygonHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContourPolygonHasErrors), new[] { "ContourPolygonHasErrors" });
            }

            //ContourPolygonHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ContourPolygonLayer))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResContourPolygonLayer), new[] { "ContourPolygonLayer" });
            }

            //ContourPolygonLayer has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.Coord))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCoord), new[] { "Coord" });
            }

            //Coord has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CoordHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCoordHasErrors), new[] { "CoordHasErrors" });
            }

            //CoordHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CoordLat))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCoordLat), new[] { "CoordLat" });
            }

            //CoordLat has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CoordLng))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCoordLng), new[] { "CoordLng" });
            }

            //CoordLng has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CoordOrdinal))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCoordOrdinal), new[] { "CoordOrdinal" });
            }

            //CoordOrdinal has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CSSPMPNTable))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCSSPMPNTable), new[] { "CSSPMPNTable" });
            }

            //CSSPMPNTable has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CSSPMPNTableHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCSSPMPNTableHasErrors), new[] { "CSSPMPNTableHasErrors" });
            }

            //CSSPMPNTableHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CSSPMPNTableMPN))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCSSPMPNTableMPN), new[] { "CSSPMPNTableMPN" });
            }

            //CSSPMPNTableMPN has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CSSPMPNTableTube0_1))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCSSPMPNTableTube0_1), new[] { "CSSPMPNTableTube0_1" });
            }

            //CSSPMPNTableTube0_1 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CSSPMPNTableTube1_0))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCSSPMPNTableTube1_0), new[] { "CSSPMPNTableTube1_0" });
            }

            //CSSPMPNTableTube1_0 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CSSPMPNTableTube10))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCSSPMPNTableTube10), new[] { "CSSPMPNTableTube10" });
            }

            //CSSPMPNTableTube10 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CSSPWQInputApp))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCSSPWQInputApp), new[] { "CSSPWQInputApp" });
            }

            //CSSPWQInputApp has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CSSPWQInputAppAccessCode))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCSSPWQInputAppAccessCode), new[] { "CSSPWQInputAppAccessCode" });
            }

            //CSSPWQInputAppAccessCode has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CSSPWQInputAppActiveYear))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCSSPWQInputAppActiveYear), new[] { "CSSPWQInputAppActiveYear" });
            }

            //CSSPWQInputAppActiveYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CSSPWQInputAppApprovalCode))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCSSPWQInputAppApprovalCode), new[] { "CSSPWQInputAppApprovalCode" });
            }

            //CSSPWQInputAppApprovalCode has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CSSPWQInputAppApprovalDate))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCSSPWQInputAppApprovalDate), new[] { "CSSPWQInputAppApprovalDate" });
            }

            //CSSPWQInputAppApprovalDate has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CSSPWQInputAppDailyDuplicatePrecisionCriteria))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCSSPWQInputAppDailyDuplicatePrecisionCriteria), new[] { "CSSPWQInputAppDailyDuplicatePrecisionCriteria" });
            }

            //CSSPWQInputAppDailyDuplicatePrecisionCriteria has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CSSPWQInputAppHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCSSPWQInputAppHasErrors), new[] { "CSSPWQInputAppHasErrors" });
            }

            //CSSPWQInputAppHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CSSPWQInputAppIncludeLaboratoryQAQC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCSSPWQInputAppIncludeLaboratoryQAQC), new[] { "CSSPWQInputAppIncludeLaboratoryQAQC" });
            }

            //CSSPWQInputAppIncludeLaboratoryQAQC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CSSPWQInputAppIntertechDuplicatePrecisionCriteria))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCSSPWQInputAppIntertechDuplicatePrecisionCriteria), new[] { "CSSPWQInputAppIntertechDuplicatePrecisionCriteria" });
            }

            //CSSPWQInputAppIntertechDuplicatePrecisionCriteria has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CSSPWQInputParam))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCSSPWQInputParam), new[] { "CSSPWQInputParam" });
            }

            //CSSPWQInputParam has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CSSPWQInputParamCSSPWQInputType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCSSPWQInputParamCSSPWQInputType), new[] { "CSSPWQInputParamCSSPWQInputType" });
            }

            //CSSPWQInputParamCSSPWQInputType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CSSPWQInputParamCSSPWQInputTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCSSPWQInputParamCSSPWQInputTypeText), new[] { "CSSPWQInputParamCSSPWQInputTypeText" });
            }

            //CSSPWQInputParamCSSPWQInputTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CSSPWQInputParamDailyDuplicateMWQMSiteList))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCSSPWQInputParamDailyDuplicateMWQMSiteList), new[] { "CSSPWQInputParamDailyDuplicateMWQMSiteList" });
            }

            //CSSPWQInputParamDailyDuplicateMWQMSiteList has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CSSPWQInputParamDailyDuplicateMWQMSiteTVItemIDList))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCSSPWQInputParamDailyDuplicateMWQMSiteTVItemIDList), new[] { "CSSPWQInputParamDailyDuplicateMWQMSiteTVItemIDList" });
            }

            //CSSPWQInputParamDailyDuplicateMWQMSiteTVItemIDList has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CSSPWQInputParamHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCSSPWQInputParamHasErrors), new[] { "CSSPWQInputParamHasErrors" });
            }

            //CSSPWQInputParamHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CSSPWQInputParamInfrastructureList))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCSSPWQInputParamInfrastructureList), new[] { "CSSPWQInputParamInfrastructureList" });
            }

            //CSSPWQInputParamInfrastructureList has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CSSPWQInputParamInfrastructureTVItemIDList))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCSSPWQInputParamInfrastructureTVItemIDList), new[] { "CSSPWQInputParamInfrastructureTVItemIDList" });
            }

            //CSSPWQInputParamInfrastructureTVItemIDList has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CSSPWQInputParamMWQMSiteList))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCSSPWQInputParamMWQMSiteList), new[] { "CSSPWQInputParamMWQMSiteList" });
            }

            //CSSPWQInputParamMWQMSiteList has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CSSPWQInputParamMWQMSiteTVItemIDList))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCSSPWQInputParamMWQMSiteTVItemIDList), new[] { "CSSPWQInputParamMWQMSiteTVItemIDList" });
            }

            //CSSPWQInputParamMWQMSiteTVItemIDList has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CSSPWQInputParamName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCSSPWQInputParamName), new[] { "CSSPWQInputParamName" });
            }

            //CSSPWQInputParamName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CSSPWQInputParamsidList))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCSSPWQInputParamsidList), new[] { "CSSPWQInputParamsidList" });
            }

            //CSSPWQInputParamsidList has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.CSSPWQInputParamTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResCSSPWQInputParamTVItemID), new[] { "CSSPWQInputParamTVItemID" });
            }

            //CSSPWQInputParamTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.DataPathOfTide))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResDataPathOfTide), new[] { "DataPathOfTide" });
            }

            //DataPathOfTide has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.DataPathOfTideHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResDataPathOfTideHasErrors), new[] { "DataPathOfTideHasErrors" });
            }

            //DataPathOfTideHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.DataPathOfTideText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResDataPathOfTideText), new[] { "DataPathOfTideText" });
            }

            //DataPathOfTideText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.DataPathOfTideWebTideDataSet))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResDataPathOfTideWebTideDataSet), new[] { "DataPathOfTideWebTideDataSet" });
            }

            //DataPathOfTideWebTideDataSet has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.DataPathOfTideWebTideDataSetText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResDataPathOfTideWebTideDataSetText), new[] { "DataPathOfTideWebTideDataSetText" });
            }

            //DataPathOfTideWebTideDataSetText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.DBTable))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResDBTable), new[] { "DBTable" });
            }

            //DBTable has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.DBTableHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResDBTableHasErrors), new[] { "DBTableHasErrors" });
            }

            //DBTableHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.DBTablePlurial))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResDBTablePlurial), new[] { "DBTablePlurial" });
            }

            //DBTablePlurial has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.DBTableTableName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResDBTableTableName), new[] { "DBTableTableName" });
            }

            //DBTableTableName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.DocTemplate))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResDocTemplate), new[] { "DocTemplate" });
            }

            //DocTemplate has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.DocTemplateDocTemplateID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResDocTemplateDocTemplateID), new[] { "DocTemplateDocTemplateID" });
            }

            //DocTemplateDocTemplateID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.DocTemplateFileName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResDocTemplateFileName), new[] { "DocTemplateFileName" });
            }

            //DocTemplateFileName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.DocTemplateHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResDocTemplateHasErrors), new[] { "DocTemplateHasErrors" });
            }

            //DocTemplateHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.DocTemplateLanguage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResDocTemplateLanguage), new[] { "DocTemplateLanguage" });
            }

            //DocTemplateLanguage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.DocTemplateLanguageText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResDocTemplateLanguageText), new[] { "DocTemplateLanguageText" });
            }

            //DocTemplateLanguageText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.DocTemplateLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResDocTemplateLastUpdateContactTVItemID), new[] { "DocTemplateLastUpdateContactTVItemID" });
            }

            //DocTemplateLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.DocTemplateLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResDocTemplateLastUpdateContactTVText), new[] { "DocTemplateLastUpdateContactTVText" });
            }

            //DocTemplateLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.DocTemplateLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResDocTemplateLastUpdateDate_UTC), new[] { "DocTemplateLastUpdateDate_UTC" });
            }

            //DocTemplateLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.DocTemplateTVFileTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResDocTemplateTVFileTVItemID), new[] { "DocTemplateTVFileTVItemID" });
            }

            //DocTemplateTVFileTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.DocTemplateTVType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResDocTemplateTVType), new[] { "DocTemplateTVType" });
            }

            //DocTemplateTVType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.DocTemplateTVTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResDocTemplateTVTypeText), new[] { "DocTemplateTVTypeText" });
            }

            //DocTemplateTVTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.Element))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResElement), new[] { "Element" });
            }

            //Element has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ElementHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResElementHasErrors), new[] { "ElementHasErrors" });
            }

            //ElementHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ElementID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResElementID), new[] { "ElementID" });
            }

            //ElementID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ElementLayer))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResElementLayer), new[] { "ElementLayer" });
            }

            //ElementLayer has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ElementLayerElement))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResElementLayerElement), new[] { "ElementLayerElement" });
            }

            //ElementLayerElement has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ElementLayerHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResElementLayerHasErrors), new[] { "ElementLayerHasErrors" });
            }

            //ElementLayerHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ElementLayerLayer))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResElementLayerLayer), new[] { "ElementLayerLayer" });
            }

            //ElementLayerLayer has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ElementLayerZMax))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResElementLayerZMax), new[] { "ElementLayerZMax" });
            }

            //ElementLayerZMax has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ElementLayerZMin))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResElementLayerZMin), new[] { "ElementLayerZMin" });
            }

            //ElementLayerZMin has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ElementNodeList))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResElementNodeList), new[] { "ElementNodeList" });
            }

            //ElementNodeList has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ElementNumbOfNodes))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResElementNumbOfNodes), new[] { "ElementNumbOfNodes" });
            }

            //ElementNumbOfNodes has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ElementType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResElementType), new[] { "ElementType" });
            }

            //ElementType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ElementValue))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResElementValue), new[] { "ElementValue" });
            }

            //ElementValue has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ElementXNode0))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResElementXNode0), new[] { "ElementXNode0" });
            }

            //ElementXNode0 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ElementYNode0))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResElementYNode0), new[] { "ElementYNode0" });
            }

            //ElementYNode0 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ElementZNode0))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResElementZNode0), new[] { "ElementZNode0" });
            }

            //ElementZNode0 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.Email))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmail), new[] { "Email" });
            }

            //Email has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionList))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionList), new[] { "EmailDistributionList" });
            }

            //EmailDistributionList has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListContact))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListContact), new[] { "EmailDistributionListContact" });
            }

            //EmailDistributionListContact has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListContactCMPRainfallSeasonal))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListContactCMPRainfallSeasonal), new[] { "EmailDistributionListContactCMPRainfallSeasonal" });
            }

            //EmailDistributionListContactCMPRainfallSeasonal has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListContactCMPWastewater))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListContactCMPWastewater), new[] { "EmailDistributionListContactCMPWastewater" });
            }

            //EmailDistributionListContactCMPWastewater has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListContactEmail))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListContactEmail), new[] { "EmailDistributionListContactEmail" });
            }

            //EmailDistributionListContactEmail has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListContactEmailDistributionListContactID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListContactEmailDistributionListContactID), new[] { "EmailDistributionListContactEmailDistributionListContactID" });
            }

            //EmailDistributionListContactEmailDistributionListContactID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListContactEmailDistributionListID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListContactEmailDistributionListID), new[] { "EmailDistributionListContactEmailDistributionListID" });
            }

            //EmailDistributionListContactEmailDistributionListID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListContactEmergencyWastewater))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListContactEmergencyWastewater), new[] { "EmailDistributionListContactEmergencyWastewater" });
            }

            //EmailDistributionListContactEmergencyWastewater has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListContactEmergencyWeather))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListContactEmergencyWeather), new[] { "EmailDistributionListContactEmergencyWeather" });
            }

            //EmailDistributionListContactEmergencyWeather has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListContactHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListContactHasErrors), new[] { "EmailDistributionListContactHasErrors" });
            }

            //EmailDistributionListContactHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListContactIsCC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListContactIsCC), new[] { "EmailDistributionListContactIsCC" });
            }

            //EmailDistributionListContactIsCC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListContactLanguage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListContactLanguage), new[] { "EmailDistributionListContactLanguage" });
            }

            //EmailDistributionListContactLanguage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListContactLanguageAgency))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListContactLanguageAgency), new[] { "EmailDistributionListContactLanguageAgency" });
            }

            //EmailDistributionListContactLanguageAgency has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListContactLanguageEmailDistributionListContactID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListContactLanguageEmailDistributionListContactID), new[] { "EmailDistributionListContactLanguageEmailDistributionListContactID" });
            }

            //EmailDistributionListContactLanguageEmailDistributionListContactID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListContactLanguageEmailDistributionListContactLanguageID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListContactLanguageEmailDistributionListContactLanguageID), new[] { "EmailDistributionListContactLanguageEmailDistributionListContactLanguageID" });
            }

            //EmailDistributionListContactLanguageEmailDistributionListContactLanguageID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListContactLanguageHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListContactLanguageHasErrors), new[] { "EmailDistributionListContactLanguageHasErrors" });
            }

            //EmailDistributionListContactLanguageHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListContactLanguageLanguage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListContactLanguageLanguage), new[] { "EmailDistributionListContactLanguageLanguage" });
            }

            //EmailDistributionListContactLanguageLanguage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListContactLanguageLanguageText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListContactLanguageLanguageText), new[] { "EmailDistributionListContactLanguageLanguageText" });
            }

            //EmailDistributionListContactLanguageLanguageText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListContactLanguageLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListContactLanguageLastUpdateContactTVItemID), new[] { "EmailDistributionListContactLanguageLastUpdateContactTVItemID" });
            }

            //EmailDistributionListContactLanguageLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListContactLanguageLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListContactLanguageLastUpdateContactTVText), new[] { "EmailDistributionListContactLanguageLastUpdateContactTVText" });
            }

            //EmailDistributionListContactLanguageLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListContactLanguageLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListContactLanguageLastUpdateDate_UTC), new[] { "EmailDistributionListContactLanguageLastUpdateDate_UTC" });
            }

            //EmailDistributionListContactLanguageLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListContactLanguageTranslationStatus))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListContactLanguageTranslationStatus), new[] { "EmailDistributionListContactLanguageTranslationStatus" });
            }

            //EmailDistributionListContactLanguageTranslationStatus has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListContactLanguageTranslationStatusText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListContactLanguageTranslationStatusText), new[] { "EmailDistributionListContactLanguageTranslationStatusText" });
            }

            //EmailDistributionListContactLanguageTranslationStatusText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListContactLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListContactLastUpdateContactTVItemID), new[] { "EmailDistributionListContactLastUpdateContactTVItemID" });
            }

            //EmailDistributionListContactLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListContactLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListContactLastUpdateContactTVText), new[] { "EmailDistributionListContactLastUpdateContactTVText" });
            }

            //EmailDistributionListContactLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListContactLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListContactLastUpdateDate_UTC), new[] { "EmailDistributionListContactLastUpdateDate_UTC" });
            }

            //EmailDistributionListContactLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListContactName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListContactName), new[] { "EmailDistributionListContactName" });
            }

            //EmailDistributionListContactName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListContactReopeningAllTypes))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListContactReopeningAllTypes), new[] { "EmailDistributionListContactReopeningAllTypes" });
            }

            //EmailDistributionListContactReopeningAllTypes has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListCountryTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListCountryTVItemID), new[] { "EmailDistributionListCountryTVItemID" });
            }

            //EmailDistributionListCountryTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListCountryTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListCountryTVText), new[] { "EmailDistributionListCountryTVText" });
            }

            //EmailDistributionListCountryTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListEmailDistributionListID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListEmailDistributionListID), new[] { "EmailDistributionListEmailDistributionListID" });
            }

            //EmailDistributionListEmailDistributionListID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListHasErrors), new[] { "EmailDistributionListHasErrors" });
            }

            //EmailDistributionListHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListLanguage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListLanguage), new[] { "EmailDistributionListLanguage" });
            }

            //EmailDistributionListLanguage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListLanguageEmailDistributionListID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListLanguageEmailDistributionListID), new[] { "EmailDistributionListLanguageEmailDistributionListID" });
            }

            //EmailDistributionListLanguageEmailDistributionListID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListLanguageEmailDistributionListLanguageID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListLanguageEmailDistributionListLanguageID), new[] { "EmailDistributionListLanguageEmailDistributionListLanguageID" });
            }

            //EmailDistributionListLanguageEmailDistributionListLanguageID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListLanguageHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListLanguageHasErrors), new[] { "EmailDistributionListLanguageHasErrors" });
            }

            //EmailDistributionListLanguageHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListLanguageLanguage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListLanguageLanguage), new[] { "EmailDistributionListLanguageLanguage" });
            }

            //EmailDistributionListLanguageLanguage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListLanguageLanguageText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListLanguageLanguageText), new[] { "EmailDistributionListLanguageLanguageText" });
            }

            //EmailDistributionListLanguageLanguageText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListLanguageLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListLanguageLastUpdateContactTVItemID), new[] { "EmailDistributionListLanguageLastUpdateContactTVItemID" });
            }

            //EmailDistributionListLanguageLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListLanguageLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListLanguageLastUpdateContactTVText), new[] { "EmailDistributionListLanguageLastUpdateContactTVText" });
            }

            //EmailDistributionListLanguageLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListLanguageLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListLanguageLastUpdateDate_UTC), new[] { "EmailDistributionListLanguageLastUpdateDate_UTC" });
            }

            //EmailDistributionListLanguageLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListLanguageRegionName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListLanguageRegionName), new[] { "EmailDistributionListLanguageRegionName" });
            }

            //EmailDistributionListLanguageRegionName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListLanguageTranslationStatus))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListLanguageTranslationStatus), new[] { "EmailDistributionListLanguageTranslationStatus" });
            }

            //EmailDistributionListLanguageTranslationStatus has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListLanguageTranslationStatusText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListLanguageTranslationStatusText), new[] { "EmailDistributionListLanguageTranslationStatusText" });
            }

            //EmailDistributionListLanguageTranslationStatusText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListLastUpdateContactTVItemID), new[] { "EmailDistributionListLastUpdateContactTVItemID" });
            }

            //EmailDistributionListLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListLastUpdateContactTVText), new[] { "EmailDistributionListLastUpdateContactTVText" });
            }

            //EmailDistributionListLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListLastUpdateDate_UTC), new[] { "EmailDistributionListLastUpdateDate_UTC" });
            }

            //EmailDistributionListLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailDistributionListOrdinal))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailDistributionListOrdinal), new[] { "EmailDistributionListOrdinal" });
            }

            //EmailDistributionListOrdinal has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailEmailAddress))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailEmailAddress), new[] { "EmailEmailAddress" });
            }

            //EmailEmailAddress has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailEmailID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailEmailID), new[] { "EmailEmailID" });
            }

            //EmailEmailID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailEmailTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailEmailTVItemID), new[] { "EmailEmailTVItemID" });
            }

            //EmailEmailTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailEmailTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailEmailTVText), new[] { "EmailEmailTVText" });
            }

            //EmailEmailTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailEmailType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailEmailType), new[] { "EmailEmailType" });
            }

            //EmailEmailType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailEmailTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailEmailTypeText), new[] { "EmailEmailTypeText" });
            }

            //EmailEmailTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailHasErrors), new[] { "EmailHasErrors" });
            }

            //EmailHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailLastUpdateContactTVItemID), new[] { "EmailLastUpdateContactTVItemID" });
            }

            //EmailLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailLastUpdateContactTVText), new[] { "EmailLastUpdateContactTVText" });
            }

            //EmailLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.EmailLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResEmailLastUpdateDate_UTC), new[] { "EmailLastUpdateDate_UTC" });
            }

            //EmailLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.FileItem))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResFileItem), new[] { "FileItem" });
            }

            //FileItem has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.FileItemHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResFileItemHasErrors), new[] { "FileItemHasErrors" });
            }

            //FileItemHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.FileItemList))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResFileItemList), new[] { "FileItemList" });
            }

            //FileItemList has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.FileItemListFileName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResFileItemListFileName), new[] { "FileItemListFileName" });
            }

            //FileItemListFileName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.FileItemListHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResFileItemListHasErrors), new[] { "FileItemListHasErrors" });
            }

            //FileItemListHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.FileItemListText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResFileItemListText), new[] { "FileItemListText" });
            }

            //FileItemListText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.FileItemName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResFileItemName), new[] { "FileItemName" });
            }

            //FileItemName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.FileItemTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResFileItemTVItemID), new[] { "FileItemTVItemID" });
            }

            //FileItemTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.FilePurposeAndText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResFilePurposeAndText), new[] { "FilePurposeAndText" });
            }

            //FilePurposeAndText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.FilePurposeAndTextFilePurpose))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResFilePurposeAndTextFilePurpose), new[] { "FilePurposeAndTextFilePurpose" });
            }

            //FilePurposeAndTextFilePurpose has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.FilePurposeAndTextFilePurposeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResFilePurposeAndTextFilePurposeText), new[] { "FilePurposeAndTextFilePurposeText" });
            }

            //FilePurposeAndTextFilePurposeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.FilePurposeAndTextHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResFilePurposeAndTextHasErrors), new[] { "FilePurposeAndTextHasErrors" });
            }

            //FilePurposeAndTextHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricDataValue))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricDataValue), new[] { "HydrometricDataValue" });
            }

            //HydrometricDataValue has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricDataValueDateTime_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricDataValueDateTime_Local), new[] { "HydrometricDataValueDateTime_Local" });
            }

            //HydrometricDataValueDateTime_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricDataValueFlow_m3_s))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricDataValueFlow_m3_s), new[] { "HydrometricDataValueFlow_m3_s" });
            }

            //HydrometricDataValueFlow_m3_s has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricDataValueHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricDataValueHasErrors), new[] { "HydrometricDataValueHasErrors" });
            }

            //HydrometricDataValueHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricDataValueHourlyValues))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricDataValueHourlyValues), new[] { "HydrometricDataValueHourlyValues" });
            }

            //HydrometricDataValueHourlyValues has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricDataValueHydrometricDataValueID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricDataValueHydrometricDataValueID), new[] { "HydrometricDataValueHydrometricDataValueID" });
            }

            //HydrometricDataValueHydrometricDataValueID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricDataValueHydrometricSiteID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricDataValueHydrometricSiteID), new[] { "HydrometricDataValueHydrometricSiteID" });
            }

            //HydrometricDataValueHydrometricSiteID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricDataValueKeep))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricDataValueKeep), new[] { "HydrometricDataValueKeep" });
            }

            //HydrometricDataValueKeep has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricDataValueLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricDataValueLastUpdateContactTVItemID), new[] { "HydrometricDataValueLastUpdateContactTVItemID" });
            }

            //HydrometricDataValueLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricDataValueLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricDataValueLastUpdateContactTVText), new[] { "HydrometricDataValueLastUpdateContactTVText" });
            }

            //HydrometricDataValueLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricDataValueLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricDataValueLastUpdateDate_UTC), new[] { "HydrometricDataValueLastUpdateDate_UTC" });
            }

            //HydrometricDataValueLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricDataValueStorageDataType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricDataValueStorageDataType), new[] { "HydrometricDataValueStorageDataType" });
            }

            //HydrometricDataValueStorageDataType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricDataValueStorageDataTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricDataValueStorageDataTypeText), new[] { "HydrometricDataValueStorageDataTypeText" });
            }

            //HydrometricDataValueStorageDataTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricSite))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricSite), new[] { "HydrometricSite" });
            }

            //HydrometricSite has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricSiteDescription))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricSiteDescription), new[] { "HydrometricSiteDescription" });
            }

            //HydrometricSiteDescription has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricSiteDrainageArea_km2))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricSiteDrainageArea_km2), new[] { "HydrometricSiteDrainageArea_km2" });
            }

            //HydrometricSiteDrainageArea_km2 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricSiteElevation_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricSiteElevation_m), new[] { "HydrometricSiteElevation_m" });
            }

            //HydrometricSiteElevation_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricSiteEndDate_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricSiteEndDate_Local), new[] { "HydrometricSiteEndDate_Local" });
            }

            //HydrometricSiteEndDate_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricSiteFedSiteNumber))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricSiteFedSiteNumber), new[] { "HydrometricSiteFedSiteNumber" });
            }

            //HydrometricSiteFedSiteNumber has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricSiteHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricSiteHasErrors), new[] { "HydrometricSiteHasErrors" });
            }

            //HydrometricSiteHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricSiteHasRatingCurve))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricSiteHasRatingCurve), new[] { "HydrometricSiteHasRatingCurve" });
            }

            //HydrometricSiteHasRatingCurve has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricSiteHydrometricSiteID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricSiteHydrometricSiteID), new[] { "HydrometricSiteHydrometricSiteID" });
            }

            //HydrometricSiteHydrometricSiteID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricSiteHydrometricSiteName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricSiteHydrometricSiteName), new[] { "HydrometricSiteHydrometricSiteName" });
            }

            //HydrometricSiteHydrometricSiteName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricSiteHydrometricSiteTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricSiteHydrometricSiteTVItemID), new[] { "HydrometricSiteHydrometricSiteTVItemID" });
            }

            //HydrometricSiteHydrometricSiteTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricSiteHydrometricTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricSiteHydrometricTVText), new[] { "HydrometricSiteHydrometricTVText" });
            }

            //HydrometricSiteHydrometricTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricSiteIsActive))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricSiteIsActive), new[] { "HydrometricSiteIsActive" });
            }

            //HydrometricSiteIsActive has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricSiteIsNatural))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricSiteIsNatural), new[] { "HydrometricSiteIsNatural" });
            }

            //HydrometricSiteIsNatural has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricSiteLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricSiteLastUpdateContactTVItemID), new[] { "HydrometricSiteLastUpdateContactTVItemID" });
            }

            //HydrometricSiteLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricSiteLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricSiteLastUpdateContactTVText), new[] { "HydrometricSiteLastUpdateContactTVText" });
            }

            //HydrometricSiteLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricSiteLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricSiteLastUpdateDate_UTC), new[] { "HydrometricSiteLastUpdateDate_UTC" });
            }

            //HydrometricSiteLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricSiteProvince))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricSiteProvince), new[] { "HydrometricSiteProvince" });
            }

            //HydrometricSiteProvince has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricSiteQuebecSiteNumber))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricSiteQuebecSiteNumber), new[] { "HydrometricSiteQuebecSiteNumber" });
            }

            //HydrometricSiteQuebecSiteNumber has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricSiteRealTime))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricSiteRealTime), new[] { "HydrometricSiteRealTime" });
            }

            //HydrometricSiteRealTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricSiteRHBN))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricSiteRHBN), new[] { "HydrometricSiteRHBN" });
            }

            //HydrometricSiteRHBN has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricSiteSediment))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricSiteSediment), new[] { "HydrometricSiteSediment" });
            }

            //HydrometricSiteSediment has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricSiteStartDate_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricSiteStartDate_Local), new[] { "HydrometricSiteStartDate_Local" });
            }

            //HydrometricSiteStartDate_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.HydrometricSiteTimeOffset_hour))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResHydrometricSiteTimeOffset_hour), new[] { "HydrometricSiteTimeOffset_hour" });
            }

            //HydrometricSiteTimeOffset_hour has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.Infrastructure))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructure), new[] { "Infrastructure" });
            }

            //Infrastructure has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureAerationType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureAerationType), new[] { "InfrastructureAerationType" });
            }

            //InfrastructureAerationType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureAerationTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureAerationTypeText), new[] { "InfrastructureAerationTypeText" });
            }

            //InfrastructureAerationTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureAlarmSystemType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureAlarmSystemType), new[] { "InfrastructureAlarmSystemType" });
            }

            //InfrastructureAlarmSystemType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureAlarmSystemTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureAlarmSystemTypeText), new[] { "InfrastructureAlarmSystemTypeText" });
            }

            //InfrastructureAlarmSystemTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureAverageDepth_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureAverageDepth_m), new[] { "InfrastructureAverageDepth_m" });
            }

            //InfrastructureAverageDepth_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureAverageFlow_m3_day))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureAverageFlow_m3_day), new[] { "InfrastructureAverageFlow_m3_day" });
            }

            //InfrastructureAverageFlow_m3_day has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureCanOverflow))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureCanOverflow), new[] { "InfrastructureCanOverflow" });
            }

            //InfrastructureCanOverflow has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureCivicAddressTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureCivicAddressTVItemID), new[] { "InfrastructureCivicAddressTVItemID" });
            }

            //InfrastructureCivicAddressTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureCivicAddressTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureCivicAddressTVText), new[] { "InfrastructureCivicAddressTVText" });
            }

            //InfrastructureCivicAddressTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureCollectionSystemType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureCollectionSystemType), new[] { "InfrastructureCollectionSystemType" });
            }

            //InfrastructureCollectionSystemType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureCollectionSystemTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureCollectionSystemTypeText), new[] { "InfrastructureCollectionSystemTypeText" });
            }

            //InfrastructureCollectionSystemTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureDecayRate_per_day))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureDecayRate_per_day), new[] { "InfrastructureDecayRate_per_day" });
            }

            //InfrastructureDecayRate_per_day has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureDesignFlow_m3_day))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureDesignFlow_m3_day), new[] { "InfrastructureDesignFlow_m3_day" });
            }

            //InfrastructureDesignFlow_m3_day has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureDisinfectionType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureDisinfectionType), new[] { "InfrastructureDisinfectionType" });
            }

            //InfrastructureDisinfectionType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureDisinfectionTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureDisinfectionTypeText), new[] { "InfrastructureDisinfectionTypeText" });
            }

            //InfrastructureDisinfectionTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureDistanceFromShore_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureDistanceFromShore_m), new[] { "InfrastructureDistanceFromShore_m" });
            }

            //InfrastructureDistanceFromShore_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureFacilityType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureFacilityType), new[] { "InfrastructureFacilityType" });
            }

            //InfrastructureFacilityType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureFacilityTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureFacilityTypeText), new[] { "InfrastructureFacilityTypeText" });
            }

            //InfrastructureFacilityTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureFarFieldVelocity_m_s))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureFarFieldVelocity_m_s), new[] { "InfrastructureFarFieldVelocity_m_s" });
            }

            //InfrastructureFarFieldVelocity_m_s has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureHasErrors), new[] { "InfrastructureHasErrors" });
            }

            //InfrastructureHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureHorizontalAngle_deg))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureHorizontalAngle_deg), new[] { "InfrastructureHorizontalAngle_deg" });
            }

            //InfrastructureHorizontalAngle_deg has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureInfrastructureCategory))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureInfrastructureCategory), new[] { "InfrastructureInfrastructureCategory" });
            }

            //InfrastructureInfrastructureCategory has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureInfrastructureID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureInfrastructureID), new[] { "InfrastructureInfrastructureID" });
            }

            //InfrastructureInfrastructureID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureInfrastructureTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureInfrastructureTVItemID), new[] { "InfrastructureInfrastructureTVItemID" });
            }

            //InfrastructureInfrastructureTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureInfrastructureTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureInfrastructureTVText), new[] { "InfrastructureInfrastructureTVText" });
            }

            //InfrastructureInfrastructureTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureInfrastructureType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureInfrastructureType), new[] { "InfrastructureInfrastructureType" });
            }

            //InfrastructureInfrastructureType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureInfrastructureTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureInfrastructureTypeText), new[] { "InfrastructureInfrastructureTypeText" });
            }

            //InfrastructureInfrastructureTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureIsMechanicallyAerated))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureIsMechanicallyAerated), new[] { "InfrastructureIsMechanicallyAerated" });
            }

            //InfrastructureIsMechanicallyAerated has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureLanguage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureLanguage), new[] { "InfrastructureLanguage" });
            }

            //InfrastructureLanguage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureLanguageComment))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureLanguageComment), new[] { "InfrastructureLanguageComment" });
            }

            //InfrastructureLanguageComment has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureLanguageHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureLanguageHasErrors), new[] { "InfrastructureLanguageHasErrors" });
            }

            //InfrastructureLanguageHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureLanguageInfrastructureID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureLanguageInfrastructureID), new[] { "InfrastructureLanguageInfrastructureID" });
            }

            //InfrastructureLanguageInfrastructureID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureLanguageInfrastructureLanguageID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureLanguageInfrastructureLanguageID), new[] { "InfrastructureLanguageInfrastructureLanguageID" });
            }

            //InfrastructureLanguageInfrastructureLanguageID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureLanguageLanguage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureLanguageLanguage), new[] { "InfrastructureLanguageLanguage" });
            }

            //InfrastructureLanguageLanguage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureLanguageLanguageText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureLanguageLanguageText), new[] { "InfrastructureLanguageLanguageText" });
            }

            //InfrastructureLanguageLanguageText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureLanguageLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureLanguageLastUpdateContactTVItemID), new[] { "InfrastructureLanguageLastUpdateContactTVItemID" });
            }

            //InfrastructureLanguageLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureLanguageLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureLanguageLastUpdateContactTVText), new[] { "InfrastructureLanguageLastUpdateContactTVText" });
            }

            //InfrastructureLanguageLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureLanguageLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureLanguageLastUpdateDate_UTC), new[] { "InfrastructureLanguageLastUpdateDate_UTC" });
            }

            //InfrastructureLanguageLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureLanguageTranslationStatus))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureLanguageTranslationStatus), new[] { "InfrastructureLanguageTranslationStatus" });
            }

            //InfrastructureLanguageTranslationStatus has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureLanguageTranslationStatusText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureLanguageTranslationStatusText), new[] { "InfrastructureLanguageTranslationStatusText" });
            }

            //InfrastructureLanguageTranslationStatusText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureLastUpdateContactTVItemID), new[] { "InfrastructureLastUpdateContactTVItemID" });
            }

            //InfrastructureLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureLastUpdateContactTVText), new[] { "InfrastructureLastUpdateContactTVText" });
            }

            //InfrastructureLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureLastUpdateDate_UTC), new[] { "InfrastructureLastUpdateDate_UTC" });
            }

            //InfrastructureLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureLSID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureLSID), new[] { "InfrastructureLSID" });
            }

            //InfrastructureLSID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureNearFieldVelocity_m_s))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureNearFieldVelocity_m_s), new[] { "InfrastructureNearFieldVelocity_m_s" });
            }

            //InfrastructureNearFieldVelocity_m_s has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureNumberOfAeratedCells))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureNumberOfAeratedCells), new[] { "InfrastructureNumberOfAeratedCells" });
            }

            //InfrastructureNumberOfAeratedCells has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureNumberOfCells))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureNumberOfCells), new[] { "InfrastructureNumberOfCells" });
            }

            //InfrastructureNumberOfCells has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureNumberOfPorts))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureNumberOfPorts), new[] { "InfrastructureNumberOfPorts" });
            }

            //InfrastructureNumberOfPorts has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructurePeakFlow_m3_day))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructurePeakFlow_m3_day), new[] { "InfrastructurePeakFlow_m3_day" });
            }

            //InfrastructurePeakFlow_m3_day has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructurePercFlowOfTotal))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructurePercFlowOfTotal), new[] { "InfrastructurePercFlowOfTotal" });
            }

            //InfrastructurePercFlowOfTotal has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructurePopServed))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructurePopServed), new[] { "InfrastructurePopServed" });
            }

            //InfrastructurePopServed has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructurePortDiameter_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructurePortDiameter_m), new[] { "InfrastructurePortDiameter_m" });
            }

            //InfrastructurePortDiameter_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructurePortElevation_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructurePortElevation_m), new[] { "InfrastructurePortElevation_m" });
            }

            //InfrastructurePortElevation_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructurePortSpacing_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructurePortSpacing_m), new[] { "InfrastructurePortSpacing_m" });
            }

            //InfrastructurePortSpacing_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructurePreliminaryTreatmentType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructurePreliminaryTreatmentType), new[] { "InfrastructurePreliminaryTreatmentType" });
            }

            //InfrastructurePreliminaryTreatmentType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructurePreliminaryTreatmentTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructurePreliminaryTreatmentTypeText), new[] { "InfrastructurePreliminaryTreatmentTypeText" });
            }

            //InfrastructurePreliminaryTreatmentTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructurePrimaryTreatmentType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructurePrimaryTreatmentType), new[] { "InfrastructurePrimaryTreatmentType" });
            }

            //InfrastructurePrimaryTreatmentType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructurePrimaryTreatmentTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructurePrimaryTreatmentTypeText), new[] { "InfrastructurePrimaryTreatmentTypeText" });
            }

            //InfrastructurePrimaryTreatmentTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructurePrismID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructurePrismID), new[] { "InfrastructurePrismID" });
            }

            //InfrastructurePrismID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureReceivingWater_MPN_per_100ml))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureReceivingWater_MPN_per_100ml), new[] { "InfrastructureReceivingWater_MPN_per_100ml" });
            }

            //InfrastructureReceivingWater_MPN_per_100ml has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureReceivingWaterSalinity_PSU))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureReceivingWaterSalinity_PSU), new[] { "InfrastructureReceivingWaterSalinity_PSU" });
            }

            //InfrastructureReceivingWaterSalinity_PSU has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureReceivingWaterTemperature_C))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureReceivingWaterTemperature_C), new[] { "InfrastructureReceivingWaterTemperature_C" });
            }

            //InfrastructureReceivingWaterTemperature_C has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureSecondaryTreatmentType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureSecondaryTreatmentType), new[] { "InfrastructureSecondaryTreatmentType" });
            }

            //InfrastructureSecondaryTreatmentType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureSecondaryTreatmentTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureSecondaryTreatmentTypeText), new[] { "InfrastructureSecondaryTreatmentTypeText" });
            }

            //InfrastructureSecondaryTreatmentTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureSeeOtherTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureSeeOtherTVItemID), new[] { "InfrastructureSeeOtherTVItemID" });
            }

            //InfrastructureSeeOtherTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureSeeOtherTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureSeeOtherTVText), new[] { "InfrastructureSeeOtherTVText" });
            }

            //InfrastructureSeeOtherTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureSite))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureSite), new[] { "InfrastructureSite" });
            }

            //InfrastructureSite has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureSiteID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureSiteID), new[] { "InfrastructureSiteID" });
            }

            //InfrastructureSiteID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureTempCatchAllRemoveLater))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureTempCatchAllRemoveLater), new[] { "InfrastructureTempCatchAllRemoveLater" });
            }

            //InfrastructureTempCatchAllRemoveLater has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureTertiaryTreatmentType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureTertiaryTreatmentType), new[] { "InfrastructureTertiaryTreatmentType" });
            }

            //InfrastructureTertiaryTreatmentType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureTertiaryTreatmentTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureTertiaryTreatmentTypeText), new[] { "InfrastructureTertiaryTreatmentTypeText" });
            }

            //InfrastructureTertiaryTreatmentTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureTimeOffset_hour))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureTimeOffset_hour), new[] { "InfrastructureTimeOffset_hour" });
            }

            //InfrastructureTimeOffset_hour has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureTPID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureTPID), new[] { "InfrastructureTPID" });
            }

            //InfrastructureTPID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureTreatmentType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureTreatmentType), new[] { "InfrastructureTreatmentType" });
            }

            //InfrastructureTreatmentType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureTreatmentTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureTreatmentTypeText), new[] { "InfrastructureTreatmentTypeText" });
            }

            //InfrastructureTreatmentTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InfrastructureVerticalAngle_deg))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInfrastructureVerticalAngle_deg), new[] { "InfrastructureVerticalAngle_deg" });
            }

            //InfrastructureVerticalAngle_deg has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InputSummary))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInputSummary), new[] { "InputSummary" });
            }

            //InputSummary has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InputSummaryError))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInputSummaryError), new[] { "InputSummaryError" });
            }

            //InputSummaryError has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InputSummaryHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInputSummaryHasErrors), new[] { "InputSummaryHasErrors" });
            }

            //InputSummaryHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.InputSummarySummary))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResInputSummarySummary), new[] { "InputSummarySummary" });
            }

            //InputSummarySummary has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheet))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheet), new[] { "LabSheet" });
            }

            //LabSheet has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1Measurement))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1Measurement), new[] { "LabSheetA1Measurement" });
            }

            //LabSheetA1Measurement has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1MeasurementHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1MeasurementHasErrors), new[] { "LabSheetA1MeasurementHasErrors" });
            }

            //LabSheetA1MeasurementHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1MeasurementMPN))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1MeasurementMPN), new[] { "LabSheetA1MeasurementMPN" });
            }

            //LabSheetA1MeasurementMPN has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1MeasurementProcessedBy))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1MeasurementProcessedBy), new[] { "LabSheetA1MeasurementProcessedBy" });
            }

            //LabSheetA1MeasurementProcessedBy has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1MeasurementSalinity))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1MeasurementSalinity), new[] { "LabSheetA1MeasurementSalinity" });
            }

            //LabSheetA1MeasurementSalinity has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1MeasurementSampleType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1MeasurementSampleType), new[] { "LabSheetA1MeasurementSampleType" });
            }

            //LabSheetA1MeasurementSampleType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1MeasurementSampleTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1MeasurementSampleTypeText), new[] { "LabSheetA1MeasurementSampleTypeText" });
            }

            //LabSheetA1MeasurementSampleTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1MeasurementSite))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1MeasurementSite), new[] { "LabSheetA1MeasurementSite" });
            }

            //LabSheetA1MeasurementSite has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1MeasurementSiteComment))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1MeasurementSiteComment), new[] { "LabSheetA1MeasurementSiteComment" });
            }

            //LabSheetA1MeasurementSiteComment has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1MeasurementTemperature))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1MeasurementTemperature), new[] { "LabSheetA1MeasurementTemperature" });
            }

            //LabSheetA1MeasurementTemperature has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1MeasurementTime))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1MeasurementTime), new[] { "LabSheetA1MeasurementTime" });
            }

            //LabSheetA1MeasurementTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1MeasurementTube0_1))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1MeasurementTube0_1), new[] { "LabSheetA1MeasurementTube0_1" });
            }

            //LabSheetA1MeasurementTube0_1 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1MeasurementTube1_0))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1MeasurementTube1_0), new[] { "LabSheetA1MeasurementTube1_0" });
            }

            //LabSheetA1MeasurementTube1_0 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1MeasurementTube10))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1MeasurementTube10), new[] { "LabSheetA1MeasurementTube10" });
            }

            //LabSheetA1MeasurementTube10 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1MeasurementTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1MeasurementTVItemID), new[] { "LabSheetA1MeasurementTVItemID" });
            }

            //LabSheetA1MeasurementTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1Sheet))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1Sheet), new[] { "LabSheetA1Sheet" });
            }

            //LabSheetA1Sheet has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetApprovalDay))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetApprovalDay), new[] { "LabSheetA1SheetApprovalDay" });
            }

            //LabSheetA1SheetApprovalDay has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetApprovalMonth))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetApprovalMonth), new[] { "LabSheetA1SheetApprovalMonth" });
            }

            //LabSheetA1SheetApprovalMonth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetApprovalYear))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetApprovalYear), new[] { "LabSheetA1SheetApprovalYear" });
            }

            //LabSheetA1SheetApprovalYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetApprovedBySupervisorInitials))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetApprovedBySupervisorInitials), new[] { "LabSheetA1SheetApprovedBySupervisorInitials" });
            }

            //LabSheetA1SheetApprovedBySupervisorInitials has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetBath1Blank44_5))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetBath1Blank44_5), new[] { "LabSheetA1SheetBath1Blank44_5" });
            }

            //LabSheetA1SheetBath1Blank44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetBath1Negative44_5))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetBath1Negative44_5), new[] { "LabSheetA1SheetBath1Negative44_5" });
            }

            //LabSheetA1SheetBath1Negative44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetBath1NonTarget44_5))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetBath1NonTarget44_5), new[] { "LabSheetA1SheetBath1NonTarget44_5" });
            }

            //LabSheetA1SheetBath1NonTarget44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetBath1Positive44_5))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetBath1Positive44_5), new[] { "LabSheetA1SheetBath1Positive44_5" });
            }

            //LabSheetA1SheetBath1Positive44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetBath2Blank44_5))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetBath2Blank44_5), new[] { "LabSheetA1SheetBath2Blank44_5" });
            }

            //LabSheetA1SheetBath2Blank44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetBath2Negative44_5))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetBath2Negative44_5), new[] { "LabSheetA1SheetBath2Negative44_5" });
            }

            //LabSheetA1SheetBath2Negative44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetBath2NonTarget44_5))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetBath2NonTarget44_5), new[] { "LabSheetA1SheetBath2NonTarget44_5" });
            }

            //LabSheetA1SheetBath2NonTarget44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetBath2Positive44_5))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetBath2Positive44_5), new[] { "LabSheetA1SheetBath2Positive44_5" });
            }

            //LabSheetA1SheetBath2Positive44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetBath3Blank44_5))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetBath3Blank44_5), new[] { "LabSheetA1SheetBath3Blank44_5" });
            }

            //LabSheetA1SheetBath3Blank44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetBath3Negative44_5))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetBath3Negative44_5), new[] { "LabSheetA1SheetBath3Negative44_5" });
            }

            //LabSheetA1SheetBath3Negative44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetBath3NonTarget44_5))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetBath3NonTarget44_5), new[] { "LabSheetA1SheetBath3NonTarget44_5" });
            }

            //LabSheetA1SheetBath3NonTarget44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetBath3Positive44_5))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetBath3Positive44_5), new[] { "LabSheetA1SheetBath3Positive44_5" });
            }

            //LabSheetA1SheetBath3Positive44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetBlank35))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetBlank35), new[] { "LabSheetA1SheetBlank35" });
            }

            //LabSheetA1SheetBlank35 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetControlLot))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetControlLot), new[] { "LabSheetA1SheetControlLot" });
            }

            //LabSheetA1SheetControlLot has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetDailyDuplicateAcceptableOrUnacceptable))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetDailyDuplicateAcceptableOrUnacceptable), new[] { "LabSheetA1SheetDailyDuplicateAcceptableOrUnacceptable" });
            }

            //LabSheetA1SheetDailyDuplicateAcceptableOrUnacceptable has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetDailyDuplicatePrecisionCriteria))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetDailyDuplicatePrecisionCriteria), new[] { "LabSheetA1SheetDailyDuplicatePrecisionCriteria" });
            }

            //LabSheetA1SheetDailyDuplicatePrecisionCriteria has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetDailyDuplicateRLog))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetDailyDuplicateRLog), new[] { "LabSheetA1SheetDailyDuplicateRLog" });
            }

            //LabSheetA1SheetDailyDuplicateRLog has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetError))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetError), new[] { "LabSheetA1SheetError" });
            }

            //LabSheetA1SheetError has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetHasErrors), new[] { "LabSheetA1SheetHasErrors" });
            }

            //LabSheetA1SheetHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetIncludeLaboratoryQAQC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetIncludeLaboratoryQAQC), new[] { "LabSheetA1SheetIncludeLaboratoryQAQC" });
            }

            //LabSheetA1SheetIncludeLaboratoryQAQC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetIncubationBath1EndTime))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetIncubationBath1EndTime), new[] { "LabSheetA1SheetIncubationBath1EndTime" });
            }

            //LabSheetA1SheetIncubationBath1EndTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetIncubationBath1StartTime))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetIncubationBath1StartTime), new[] { "LabSheetA1SheetIncubationBath1StartTime" });
            }

            //LabSheetA1SheetIncubationBath1StartTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetIncubationBath1TimeCalculated))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetIncubationBath1TimeCalculated), new[] { "LabSheetA1SheetIncubationBath1TimeCalculated" });
            }

            //LabSheetA1SheetIncubationBath1TimeCalculated has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetIncubationBath2EndTime))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetIncubationBath2EndTime), new[] { "LabSheetA1SheetIncubationBath2EndTime" });
            }

            //LabSheetA1SheetIncubationBath2EndTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetIncubationBath2StartTime))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetIncubationBath2StartTime), new[] { "LabSheetA1SheetIncubationBath2StartTime" });
            }

            //LabSheetA1SheetIncubationBath2StartTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetIncubationBath2TimeCalculated))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetIncubationBath2TimeCalculated), new[] { "LabSheetA1SheetIncubationBath2TimeCalculated" });
            }

            //LabSheetA1SheetIncubationBath2TimeCalculated has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetIncubationBath3EndTime))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetIncubationBath3EndTime), new[] { "LabSheetA1SheetIncubationBath3EndTime" });
            }

            //LabSheetA1SheetIncubationBath3EndTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetIncubationBath3StartTime))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetIncubationBath3StartTime), new[] { "LabSheetA1SheetIncubationBath3StartTime" });
            }

            //LabSheetA1SheetIncubationBath3StartTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetIncubationBath3TimeCalculated))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetIncubationBath3TimeCalculated), new[] { "LabSheetA1SheetIncubationBath3TimeCalculated" });
            }

            //LabSheetA1SheetIncubationBath3TimeCalculated has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetIncubationStartSameDay))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetIncubationStartSameDay), new[] { "LabSheetA1SheetIncubationStartSameDay" });
            }

            //LabSheetA1SheetIncubationStartSameDay has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetIntertechDuplicateAcceptableOrUnacceptable))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetIntertechDuplicateAcceptableOrUnacceptable), new[] { "LabSheetA1SheetIntertechDuplicateAcceptableOrUnacceptable" });
            }

            //LabSheetA1SheetIntertechDuplicateAcceptableOrUnacceptable has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetIntertechDuplicatePrecisionCriteria))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetIntertechDuplicatePrecisionCriteria), new[] { "LabSheetA1SheetIntertechDuplicatePrecisionCriteria" });
            }

            //LabSheetA1SheetIntertechDuplicatePrecisionCriteria has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetIntertechDuplicateRLog))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetIntertechDuplicateRLog), new[] { "LabSheetA1SheetIntertechDuplicateRLog" });
            }

            //LabSheetA1SheetIntertechDuplicateRLog has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetIntertechReadAcceptableOrUnacceptable))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetIntertechReadAcceptableOrUnacceptable), new[] { "LabSheetA1SheetIntertechReadAcceptableOrUnacceptable" });
            }

            //LabSheetA1SheetIntertechReadAcceptableOrUnacceptable has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetLabSheetA1MeasurementList))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetLabSheetA1MeasurementList), new[] { "LabSheetA1SheetLabSheetA1MeasurementList" });
            }

            //LabSheetA1SheetLabSheetA1MeasurementList has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetLabSheetType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetLabSheetType), new[] { "LabSheetA1SheetLabSheetType" });
            }

            //LabSheetA1SheetLabSheetType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetLabSheetTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetLabSheetTypeText), new[] { "LabSheetA1SheetLabSheetTypeText" });
            }

            //LabSheetA1SheetLabSheetTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetLog))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetLog), new[] { "LabSheetA1SheetLog" });
            }

            //LabSheetA1SheetLog has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetLot35))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetLot35), new[] { "LabSheetA1SheetLot35" });
            }

            //LabSheetA1SheetLot35 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetLot44_5))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetLot44_5), new[] { "LabSheetA1SheetLot44_5" });
            }

            //LabSheetA1SheetLot44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetNegative35))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetNegative35), new[] { "LabSheetA1SheetNegative35" });
            }

            //LabSheetA1SheetNegative35 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetNonTarget35))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetNonTarget35), new[] { "LabSheetA1SheetNonTarget35" });
            }

            //LabSheetA1SheetNonTarget35 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetPositive35))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetPositive35), new[] { "LabSheetA1SheetPositive35" });
            }

            //LabSheetA1SheetPositive35 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetResultsReadBy))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetResultsReadBy), new[] { "LabSheetA1SheetResultsReadBy" });
            }

            //LabSheetA1SheetResultsReadBy has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetResultsReadDay))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetResultsReadDay), new[] { "LabSheetA1SheetResultsReadDay" });
            }

            //LabSheetA1SheetResultsReadDay has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetResultsReadMonth))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetResultsReadMonth), new[] { "LabSheetA1SheetResultsReadMonth" });
            }

            //LabSheetA1SheetResultsReadMonth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetResultsReadYear))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetResultsReadYear), new[] { "LabSheetA1SheetResultsReadYear" });
            }

            //LabSheetA1SheetResultsReadYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetResultsRecordedBy))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetResultsRecordedBy), new[] { "LabSheetA1SheetResultsRecordedBy" });
            }

            //LabSheetA1SheetResultsRecordedBy has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetResultsRecordedDay))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetResultsRecordedDay), new[] { "LabSheetA1SheetResultsRecordedDay" });
            }

            //LabSheetA1SheetResultsRecordedDay has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetResultsRecordedMonth))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetResultsRecordedMonth), new[] { "LabSheetA1SheetResultsRecordedMonth" });
            }

            //LabSheetA1SheetResultsRecordedMonth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetResultsRecordedYear))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetResultsRecordedYear), new[] { "LabSheetA1SheetResultsRecordedYear" });
            }

            //LabSheetA1SheetResultsRecordedYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetRunComment))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetRunComment), new[] { "LabSheetA1SheetRunComment" });
            }

            //LabSheetA1SheetRunComment has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetRunDay))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetRunDay), new[] { "LabSheetA1SheetRunDay" });
            }

            //LabSheetA1SheetRunDay has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetRunMonth))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetRunMonth), new[] { "LabSheetA1SheetRunMonth" });
            }

            //LabSheetA1SheetRunMonth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetRunNumber))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetRunNumber), new[] { "LabSheetA1SheetRunNumber" });
            }

            //LabSheetA1SheetRunNumber has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetRunWeatherComment))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetRunWeatherComment), new[] { "LabSheetA1SheetRunWeatherComment" });
            }

            //LabSheetA1SheetRunWeatherComment has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetRunYear))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetRunYear), new[] { "LabSheetA1SheetRunYear" });
            }

            //LabSheetA1SheetRunYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetSalinitiesReadBy))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetSalinitiesReadBy), new[] { "LabSheetA1SheetSalinitiesReadBy" });
            }

            //LabSheetA1SheetSalinitiesReadBy has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetSalinitiesReadDay))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetSalinitiesReadDay), new[] { "LabSheetA1SheetSalinitiesReadDay" });
            }

            //LabSheetA1SheetSalinitiesReadDay has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetSalinitiesReadMonth))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetSalinitiesReadMonth), new[] { "LabSheetA1SheetSalinitiesReadMonth" });
            }

            //LabSheetA1SheetSalinitiesReadMonth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetSalinitiesReadYear))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetSalinitiesReadYear), new[] { "LabSheetA1SheetSalinitiesReadYear" });
            }

            //LabSheetA1SheetSalinitiesReadYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetSampleBottleLotNumber))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetSampleBottleLotNumber), new[] { "LabSheetA1SheetSampleBottleLotNumber" });
            }

            //LabSheetA1SheetSampleBottleLotNumber has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetSampleCrewInitials))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetSampleCrewInitials), new[] { "LabSheetA1SheetSampleCrewInitials" });
            }

            //LabSheetA1SheetSampleCrewInitials has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetSampleType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetSampleType), new[] { "LabSheetA1SheetSampleType" });
            }

            //LabSheetA1SheetSampleType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetSampleTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetSampleTypeText), new[] { "LabSheetA1SheetSampleTypeText" });
            }

            //LabSheetA1SheetSampleTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetSamplingPlanType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetSamplingPlanType), new[] { "LabSheetA1SheetSamplingPlanType" });
            }

            //LabSheetA1SheetSamplingPlanType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetSamplingPlanTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetSamplingPlanTypeText), new[] { "LabSheetA1SheetSamplingPlanTypeText" });
            }

            //LabSheetA1SheetSamplingPlanTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetSubsectorLocation))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetSubsectorLocation), new[] { "LabSheetA1SheetSubsectorLocation" });
            }

            //LabSheetA1SheetSubsectorLocation has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetSubsectorName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetSubsectorName), new[] { "LabSheetA1SheetSubsectorName" });
            }

            //LabSheetA1SheetSubsectorName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetSubsectorTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetSubsectorTVItemID), new[] { "LabSheetA1SheetSubsectorTVItemID" });
            }

            //LabSheetA1SheetSubsectorTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetTCAverage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetTCAverage), new[] { "LabSheetA1SheetTCAverage" });
            }

            //LabSheetA1SheetTCAverage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetTCField1))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetTCField1), new[] { "LabSheetA1SheetTCField1" });
            }

            //LabSheetA1SheetTCField1 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetTCField2))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetTCField2), new[] { "LabSheetA1SheetTCField2" });
            }

            //LabSheetA1SheetTCField2 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetTCFirst))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetTCFirst), new[] { "LabSheetA1SheetTCFirst" });
            }

            //LabSheetA1SheetTCFirst has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetTCHas2Coolers))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetTCHas2Coolers), new[] { "LabSheetA1SheetTCHas2Coolers" });
            }

            //LabSheetA1SheetTCHas2Coolers has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetTCLab1))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetTCLab1), new[] { "LabSheetA1SheetTCLab1" });
            }

            //LabSheetA1SheetTCLab1 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetTCLab2))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetTCLab2), new[] { "LabSheetA1SheetTCLab2" });
            }

            //LabSheetA1SheetTCLab2 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetTides))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetTides), new[] { "LabSheetA1SheetTides" });
            }

            //LabSheetA1SheetTides has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetVersion))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetVersion), new[] { "LabSheetA1SheetVersion" });
            }

            //LabSheetA1SheetVersion has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetWaterBath1))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetWaterBath1), new[] { "LabSheetA1SheetWaterBath1" });
            }

            //LabSheetA1SheetWaterBath1 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetWaterBath2))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetWaterBath2), new[] { "LabSheetA1SheetWaterBath2" });
            }

            //LabSheetA1SheetWaterBath2 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetWaterBath3))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetWaterBath3), new[] { "LabSheetA1SheetWaterBath3" });
            }

            //LabSheetA1SheetWaterBath3 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetA1SheetWaterBathCount))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetA1SheetWaterBathCount), new[] { "LabSheetA1SheetWaterBathCount" });
            }

            //LabSheetA1SheetWaterBathCount has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetAcceptedOrRejectedByContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetAcceptedOrRejectedByContactTVItemID), new[] { "LabSheetAcceptedOrRejectedByContactTVItemID" });
            }

            //LabSheetAcceptedOrRejectedByContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetAcceptedOrRejectedByContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetAcceptedOrRejectedByContactTVText), new[] { "LabSheetAcceptedOrRejectedByContactTVText" });
            }

            //LabSheetAcceptedOrRejectedByContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetAcceptedOrRejectedDateTime))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetAcceptedOrRejectedDateTime), new[] { "LabSheetAcceptedOrRejectedDateTime" });
            }

            //LabSheetAcceptedOrRejectedDateTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetAndA1Sheet))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetAndA1Sheet), new[] { "LabSheetAndA1Sheet" });
            }

            //LabSheetAndA1Sheet has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetAndA1SheetHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetAndA1SheetHasErrors), new[] { "LabSheetAndA1SheetHasErrors" });
            }

            //LabSheetAndA1SheetHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetAndA1SheetLabSheet))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetAndA1SheetLabSheet), new[] { "LabSheetAndA1SheetLabSheet" });
            }

            //LabSheetAndA1SheetLabSheet has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetAndA1SheetLabSheetA1Sheet))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetAndA1SheetLabSheetA1Sheet), new[] { "LabSheetAndA1SheetLabSheetA1Sheet" });
            }

            //LabSheetAndA1SheetLabSheetA1Sheet has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDay))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDay), new[] { "LabSheetDay" });
            }

            //LabSheetDay has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetail))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetail), new[] { "LabSheetDetail" });
            }

            //LabSheetDetail has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailBath1Blank44_5))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailBath1Blank44_5), new[] { "LabSheetDetailBath1Blank44_5" });
            }

            //LabSheetDetailBath1Blank44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailBath1Negative44_5))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailBath1Negative44_5), new[] { "LabSheetDetailBath1Negative44_5" });
            }

            //LabSheetDetailBath1Negative44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailBath1NonTarget44_5))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailBath1NonTarget44_5), new[] { "LabSheetDetailBath1NonTarget44_5" });
            }

            //LabSheetDetailBath1NonTarget44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailBath1Positive44_5))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailBath1Positive44_5), new[] { "LabSheetDetailBath1Positive44_5" });
            }

            //LabSheetDetailBath1Positive44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailBath2Blank44_5))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailBath2Blank44_5), new[] { "LabSheetDetailBath2Blank44_5" });
            }

            //LabSheetDetailBath2Blank44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailBath2Negative44_5))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailBath2Negative44_5), new[] { "LabSheetDetailBath2Negative44_5" });
            }

            //LabSheetDetailBath2Negative44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailBath2NonTarget44_5))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailBath2NonTarget44_5), new[] { "LabSheetDetailBath2NonTarget44_5" });
            }

            //LabSheetDetailBath2NonTarget44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailBath2Positive44_5))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailBath2Positive44_5), new[] { "LabSheetDetailBath2Positive44_5" });
            }

            //LabSheetDetailBath2Positive44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailBath3Blank44_5))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailBath3Blank44_5), new[] { "LabSheetDetailBath3Blank44_5" });
            }

            //LabSheetDetailBath3Blank44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailBath3Negative44_5))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailBath3Negative44_5), new[] { "LabSheetDetailBath3Negative44_5" });
            }

            //LabSheetDetailBath3Negative44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailBath3NonTarget44_5))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailBath3NonTarget44_5), new[] { "LabSheetDetailBath3NonTarget44_5" });
            }

            //LabSheetDetailBath3NonTarget44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailBath3Positive44_5))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailBath3Positive44_5), new[] { "LabSheetDetailBath3Positive44_5" });
            }

            //LabSheetDetailBath3Positive44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailBlank35))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailBlank35), new[] { "LabSheetDetailBlank35" });
            }

            //LabSheetDetailBlank35 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailControlLot))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailControlLot), new[] { "LabSheetDetailControlLot" });
            }

            //LabSheetDetailControlLot has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailDailyDuplicateAcceptable))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailDailyDuplicateAcceptable), new[] { "LabSheetDetailDailyDuplicateAcceptable" });
            }

            //LabSheetDetailDailyDuplicateAcceptable has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailDailyDuplicatePrecisionCriteria))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailDailyDuplicatePrecisionCriteria), new[] { "LabSheetDetailDailyDuplicatePrecisionCriteria" });
            }

            //LabSheetDetailDailyDuplicatePrecisionCriteria has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailDailyDuplicateRLog))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailDailyDuplicateRLog), new[] { "LabSheetDetailDailyDuplicateRLog" });
            }

            //LabSheetDetailDailyDuplicateRLog has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailHasErrors), new[] { "LabSheetDetailHasErrors" });
            }

            //LabSheetDetailHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailIncubationBath1EndTime))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailIncubationBath1EndTime), new[] { "LabSheetDetailIncubationBath1EndTime" });
            }

            //LabSheetDetailIncubationBath1EndTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailIncubationBath1StartTime))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailIncubationBath1StartTime), new[] { "LabSheetDetailIncubationBath1StartTime" });
            }

            //LabSheetDetailIncubationBath1StartTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailIncubationBath1TimeCalculated_minutes))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailIncubationBath1TimeCalculated_minutes), new[] { "LabSheetDetailIncubationBath1TimeCalculated_minutes" });
            }

            //LabSheetDetailIncubationBath1TimeCalculated_minutes has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailIncubationBath2EndTime))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailIncubationBath2EndTime), new[] { "LabSheetDetailIncubationBath2EndTime" });
            }

            //LabSheetDetailIncubationBath2EndTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailIncubationBath2StartTime))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailIncubationBath2StartTime), new[] { "LabSheetDetailIncubationBath2StartTime" });
            }

            //LabSheetDetailIncubationBath2StartTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailIncubationBath2TimeCalculated_minutes))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailIncubationBath2TimeCalculated_minutes), new[] { "LabSheetDetailIncubationBath2TimeCalculated_minutes" });
            }

            //LabSheetDetailIncubationBath2TimeCalculated_minutes has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailIncubationBath3EndTime))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailIncubationBath3EndTime), new[] { "LabSheetDetailIncubationBath3EndTime" });
            }

            //LabSheetDetailIncubationBath3EndTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailIncubationBath3StartTime))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailIncubationBath3StartTime), new[] { "LabSheetDetailIncubationBath3StartTime" });
            }

            //LabSheetDetailIncubationBath3StartTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailIncubationBath3TimeCalculated_minutes))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailIncubationBath3TimeCalculated_minutes), new[] { "LabSheetDetailIncubationBath3TimeCalculated_minutes" });
            }

            //LabSheetDetailIncubationBath3TimeCalculated_minutes has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailIntertechDuplicateAcceptable))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailIntertechDuplicateAcceptable), new[] { "LabSheetDetailIntertechDuplicateAcceptable" });
            }

            //LabSheetDetailIntertechDuplicateAcceptable has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailIntertechDuplicatePrecisionCriteria))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailIntertechDuplicatePrecisionCriteria), new[] { "LabSheetDetailIntertechDuplicatePrecisionCriteria" });
            }

            //LabSheetDetailIntertechDuplicatePrecisionCriteria has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailIntertechDuplicateRLog))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailIntertechDuplicateRLog), new[] { "LabSheetDetailIntertechDuplicateRLog" });
            }

            //LabSheetDetailIntertechDuplicateRLog has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailIntertechReadAcceptable))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailIntertechReadAcceptable), new[] { "LabSheetDetailIntertechReadAcceptable" });
            }

            //LabSheetDetailIntertechReadAcceptable has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailLabSheetDetailID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailLabSheetDetailID), new[] { "LabSheetDetailLabSheetDetailID" });
            }

            //LabSheetDetailLabSheetDetailID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailLabSheetID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailLabSheetID), new[] { "LabSheetDetailLabSheetID" });
            }

            //LabSheetDetailLabSheetID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailLastUpdateContactTVItemID), new[] { "LabSheetDetailLastUpdateContactTVItemID" });
            }

            //LabSheetDetailLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailLastUpdateContactTVText), new[] { "LabSheetDetailLastUpdateContactTVText" });
            }

            //LabSheetDetailLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailLastUpdateDate_UTC), new[] { "LabSheetDetailLastUpdateDate_UTC" });
            }

            //LabSheetDetailLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailLot35))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailLot35), new[] { "LabSheetDetailLot35" });
            }

            //LabSheetDetailLot35 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailLot44_5))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailLot44_5), new[] { "LabSheetDetailLot44_5" });
            }

            //LabSheetDetailLot44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailNegative35))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailNegative35), new[] { "LabSheetDetailNegative35" });
            }

            //LabSheetDetailNegative35 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailNonTarget35))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailNonTarget35), new[] { "LabSheetDetailNonTarget35" });
            }

            //LabSheetDetailNonTarget35 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailPositive35))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailPositive35), new[] { "LabSheetDetailPositive35" });
            }

            //LabSheetDetailPositive35 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailResultsReadBy))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailResultsReadBy), new[] { "LabSheetDetailResultsReadBy" });
            }

            //LabSheetDetailResultsReadBy has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailResultsReadDate))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailResultsReadDate), new[] { "LabSheetDetailResultsReadDate" });
            }

            //LabSheetDetailResultsReadDate has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailResultsRecordedBy))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailResultsRecordedBy), new[] { "LabSheetDetailResultsRecordedBy" });
            }

            //LabSheetDetailResultsRecordedBy has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailResultsRecordedDate))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailResultsRecordedDate), new[] { "LabSheetDetailResultsRecordedDate" });
            }

            //LabSheetDetailResultsRecordedDate has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailRunComment))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailRunComment), new[] { "LabSheetDetailRunComment" });
            }

            //LabSheetDetailRunComment has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailRunDate))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailRunDate), new[] { "LabSheetDetailRunDate" });
            }

            //LabSheetDetailRunDate has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailRunWeatherComment))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailRunWeatherComment), new[] { "LabSheetDetailRunWeatherComment" });
            }

            //LabSheetDetailRunWeatherComment has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailSalinitiesReadBy))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailSalinitiesReadBy), new[] { "LabSheetDetailSalinitiesReadBy" });
            }

            //LabSheetDetailSalinitiesReadBy has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailSalinitiesReadDate))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailSalinitiesReadDate), new[] { "LabSheetDetailSalinitiesReadDate" });
            }

            //LabSheetDetailSalinitiesReadDate has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailSampleBottleLotNumber))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailSampleBottleLotNumber), new[] { "LabSheetDetailSampleBottleLotNumber" });
            }

            //LabSheetDetailSampleBottleLotNumber has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailSampleCrewInitials))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailSampleCrewInitials), new[] { "LabSheetDetailSampleCrewInitials" });
            }

            //LabSheetDetailSampleCrewInitials has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailSamplingPlanID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailSamplingPlanID), new[] { "LabSheetDetailSamplingPlanID" });
            }

            //LabSheetDetailSamplingPlanID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailSubsectorTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailSubsectorTVItemID), new[] { "LabSheetDetailSubsectorTVItemID" });
            }

            //LabSheetDetailSubsectorTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailSubsectorTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailSubsectorTVText), new[] { "LabSheetDetailSubsectorTVText" });
            }

            //LabSheetDetailSubsectorTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailTCAverage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailTCAverage), new[] { "LabSheetDetailTCAverage" });
            }

            //LabSheetDetailTCAverage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailTCField1))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailTCField1), new[] { "LabSheetDetailTCField1" });
            }

            //LabSheetDetailTCField1 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailTCField2))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailTCField2), new[] { "LabSheetDetailTCField2" });
            }

            //LabSheetDetailTCField2 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailTCFirst))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailTCFirst), new[] { "LabSheetDetailTCFirst" });
            }

            //LabSheetDetailTCFirst has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailTCLab1))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailTCLab1), new[] { "LabSheetDetailTCLab1" });
            }

            //LabSheetDetailTCLab1 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailTCLab2))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailTCLab2), new[] { "LabSheetDetailTCLab2" });
            }

            //LabSheetDetailTCLab2 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailTides))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailTides), new[] { "LabSheetDetailTides" });
            }

            //LabSheetDetailTides has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailVersion))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailVersion), new[] { "LabSheetDetailVersion" });
            }

            //LabSheetDetailVersion has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailWaterBath1))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailWaterBath1), new[] { "LabSheetDetailWaterBath1" });
            }

            //LabSheetDetailWaterBath1 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailWaterBath2))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailWaterBath2), new[] { "LabSheetDetailWaterBath2" });
            }

            //LabSheetDetailWaterBath2 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailWaterBath3))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailWaterBath3), new[] { "LabSheetDetailWaterBath3" });
            }

            //LabSheetDetailWaterBath3 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailWaterBathCount))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailWaterBathCount), new[] { "LabSheetDetailWaterBathCount" });
            }

            //LabSheetDetailWaterBathCount has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetDetailWeather))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetDetailWeather), new[] { "LabSheetDetailWeather" });
            }

            //LabSheetDetailWeather has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetFileContent))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetFileContent), new[] { "LabSheetFileContent" });
            }

            //LabSheetFileContent has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetFileLastModifiedDate_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetFileLastModifiedDate_Local), new[] { "LabSheetFileLastModifiedDate_Local" });
            }

            //LabSheetFileLastModifiedDate_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetFileName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetFileName), new[] { "LabSheetFileName" });
            }

            //LabSheetFileName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetHasErrors), new[] { "LabSheetHasErrors" });
            }

            //LabSheetHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetLabSheetID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetLabSheetID), new[] { "LabSheetLabSheetID" });
            }

            //LabSheetLabSheetID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetLabSheetStatus))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetLabSheetStatus), new[] { "LabSheetLabSheetStatus" });
            }

            //LabSheetLabSheetStatus has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetLabSheetStatusText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetLabSheetStatusText), new[] { "LabSheetLabSheetStatusText" });
            }

            //LabSheetLabSheetStatusText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetLabSheetType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetLabSheetType), new[] { "LabSheetLabSheetType" });
            }

            //LabSheetLabSheetType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetLabSheetTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetLabSheetTypeText), new[] { "LabSheetLabSheetTypeText" });
            }

            //LabSheetLabSheetTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetLastUpdateContactTVItemID), new[] { "LabSheetLastUpdateContactTVItemID" });
            }

            //LabSheetLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetLastUpdateContactTVText), new[] { "LabSheetLastUpdateContactTVText" });
            }

            //LabSheetLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetLastUpdateDate_UTC), new[] { "LabSheetLastUpdateDate_UTC" });
            }

            //LabSheetLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetMonth))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetMonth), new[] { "LabSheetMonth" });
            }

            //LabSheetMonth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetMWQMRunTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetMWQMRunTVItemID), new[] { "LabSheetMWQMRunTVItemID" });
            }

            //LabSheetMWQMRunTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetMWQMRunTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetMWQMRunTVText), new[] { "LabSheetMWQMRunTVText" });
            }

            //LabSheetMWQMRunTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetOtherServerLabSheetID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetOtherServerLabSheetID), new[] { "LabSheetOtherServerLabSheetID" });
            }

            //LabSheetOtherServerLabSheetID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetRejectReason))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetRejectReason), new[] { "LabSheetRejectReason" });
            }

            //LabSheetRejectReason has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetRunNumber))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetRunNumber), new[] { "LabSheetRunNumber" });
            }

            //LabSheetRunNumber has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetSampleType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetSampleType), new[] { "LabSheetSampleType" });
            }

            //LabSheetSampleType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetSampleTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetSampleTypeText), new[] { "LabSheetSampleTypeText" });
            }

            //LabSheetSampleTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetSamplingPlanID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetSamplingPlanID), new[] { "LabSheetSamplingPlanID" });
            }

            //LabSheetSamplingPlanID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetSamplingPlanName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetSamplingPlanName), new[] { "LabSheetSamplingPlanName" });
            }

            //LabSheetSamplingPlanName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetSamplingPlanType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetSamplingPlanType), new[] { "LabSheetSamplingPlanType" });
            }

            //LabSheetSamplingPlanType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetSamplingPlanTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetSamplingPlanTypeText), new[] { "LabSheetSamplingPlanTypeText" });
            }

            //LabSheetSamplingPlanTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetSubsectorTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetSubsectorTVItemID), new[] { "LabSheetSubsectorTVItemID" });
            }

            //LabSheetSubsectorTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetSubsectorTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetSubsectorTVText), new[] { "LabSheetSubsectorTVText" });
            }

            //LabSheetSubsectorTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetTubeMPNDetail))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetTubeMPNDetail), new[] { "LabSheetTubeMPNDetail" });
            }

            //LabSheetTubeMPNDetail has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetTubeMPNDetailHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetTubeMPNDetailHasErrors), new[] { "LabSheetTubeMPNDetailHasErrors" });
            }

            //LabSheetTubeMPNDetailHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetTubeMPNDetailLabSheetDetailID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetTubeMPNDetailLabSheetDetailID), new[] { "LabSheetTubeMPNDetailLabSheetDetailID" });
            }

            //LabSheetTubeMPNDetailLabSheetDetailID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetTubeMPNDetailLabSheetTubeMPNDetailID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetTubeMPNDetailLabSheetTubeMPNDetailID), new[] { "LabSheetTubeMPNDetailLabSheetTubeMPNDetailID" });
            }

            //LabSheetTubeMPNDetailLabSheetTubeMPNDetailID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetTubeMPNDetailLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetTubeMPNDetailLastUpdateContactTVItemID), new[] { "LabSheetTubeMPNDetailLastUpdateContactTVItemID" });
            }

            //LabSheetTubeMPNDetailLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetTubeMPNDetailLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetTubeMPNDetailLastUpdateContactTVText), new[] { "LabSheetTubeMPNDetailLastUpdateContactTVText" });
            }

            //LabSheetTubeMPNDetailLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetTubeMPNDetailLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetTubeMPNDetailLastUpdateDate_UTC), new[] { "LabSheetTubeMPNDetailLastUpdateDate_UTC" });
            }

            //LabSheetTubeMPNDetailLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetTubeMPNDetailMPN))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetTubeMPNDetailMPN), new[] { "LabSheetTubeMPNDetailMPN" });
            }

            //LabSheetTubeMPNDetailMPN has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetTubeMPNDetailMWQMSiteTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetTubeMPNDetailMWQMSiteTVItemID), new[] { "LabSheetTubeMPNDetailMWQMSiteTVItemID" });
            }

            //LabSheetTubeMPNDetailMWQMSiteTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetTubeMPNDetailMWQMSiteTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetTubeMPNDetailMWQMSiteTVText), new[] { "LabSheetTubeMPNDetailMWQMSiteTVText" });
            }

            //LabSheetTubeMPNDetailMWQMSiteTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetTubeMPNDetailOrdinal))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetTubeMPNDetailOrdinal), new[] { "LabSheetTubeMPNDetailOrdinal" });
            }

            //LabSheetTubeMPNDetailOrdinal has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetTubeMPNDetailProcessedBy))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetTubeMPNDetailProcessedBy), new[] { "LabSheetTubeMPNDetailProcessedBy" });
            }

            //LabSheetTubeMPNDetailProcessedBy has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetTubeMPNDetailSalinity))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetTubeMPNDetailSalinity), new[] { "LabSheetTubeMPNDetailSalinity" });
            }

            //LabSheetTubeMPNDetailSalinity has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetTubeMPNDetailSampleDateTime))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetTubeMPNDetailSampleDateTime), new[] { "LabSheetTubeMPNDetailSampleDateTime" });
            }

            //LabSheetTubeMPNDetailSampleDateTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetTubeMPNDetailSampleType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetTubeMPNDetailSampleType), new[] { "LabSheetTubeMPNDetailSampleType" });
            }

            //LabSheetTubeMPNDetailSampleType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetTubeMPNDetailSampleTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetTubeMPNDetailSampleTypeText), new[] { "LabSheetTubeMPNDetailSampleTypeText" });
            }

            //LabSheetTubeMPNDetailSampleTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetTubeMPNDetailSiteComment))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetTubeMPNDetailSiteComment), new[] { "LabSheetTubeMPNDetailSiteComment" });
            }

            //LabSheetTubeMPNDetailSiteComment has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetTubeMPNDetailTemperature))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetTubeMPNDetailTemperature), new[] { "LabSheetTubeMPNDetailTemperature" });
            }

            //LabSheetTubeMPNDetailTemperature has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetTubeMPNDetailTube0_1))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetTubeMPNDetailTube0_1), new[] { "LabSheetTubeMPNDetailTube0_1" });
            }

            //LabSheetTubeMPNDetailTube0_1 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetTubeMPNDetailTube1_0))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetTubeMPNDetailTube1_0), new[] { "LabSheetTubeMPNDetailTube1_0" });
            }

            //LabSheetTubeMPNDetailTube1_0 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetTubeMPNDetailTube10))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetTubeMPNDetailTube10), new[] { "LabSheetTubeMPNDetailTube10" });
            }

            //LabSheetTubeMPNDetailTube10 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LabSheetYear))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLabSheetYear), new[] { "LabSheetYear" });
            }

            //LabSheetYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LastUpdateAndContact))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLastUpdateAndContact), new[] { "LastUpdateAndContact" });
            }

            //LastUpdateAndContact has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LastUpdateAndContactError))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLastUpdateAndContactError), new[] { "LastUpdateAndContactError" });
            }

            //LastUpdateAndContactError has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LastUpdateAndContactHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLastUpdateAndContactHasErrors), new[] { "LastUpdateAndContactHasErrors" });
            }

            //LastUpdateAndContactHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LastUpdateAndContactLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLastUpdateAndContactLastUpdateContactTVItemID), new[] { "LastUpdateAndContactLastUpdateContactTVItemID" });
            }

            //LastUpdateAndContactLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LastUpdateAndContactLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLastUpdateAndContactLastUpdateDate_UTC), new[] { "LastUpdateAndContactLastUpdateDate_UTC" });
            }

            //LastUpdateAndContactLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LastUpdateAndTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLastUpdateAndTVText), new[] { "LastUpdateAndTVText" });
            }

            //LastUpdateAndTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LastUpdateAndTVTextError))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLastUpdateAndTVTextError), new[] { "LastUpdateAndTVTextError" });
            }

            //LastUpdateAndTVTextError has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LastUpdateAndTVTextHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLastUpdateAndTVTextHasErrors), new[] { "LastUpdateAndTVTextHasErrors" });
            }

            //LastUpdateAndTVTextHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LastUpdateAndTVTextLastUpdateDate_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLastUpdateAndTVTextLastUpdateDate_Local), new[] { "LastUpdateAndTVTextLastUpdateDate_Local" });
            }

            //LastUpdateAndTVTextLastUpdateDate_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LastUpdateAndTVTextLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLastUpdateAndTVTextLastUpdateDate_UTC), new[] { "LastUpdateAndTVTextLastUpdateDate_UTC" });
            }

            //LastUpdateAndTVTextLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LastUpdateAndTVTextTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLastUpdateAndTVTextTVText), new[] { "LastUpdateAndTVTextTVText" });
            }

            //LastUpdateAndTVTextTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LatLng))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLatLng), new[] { "LatLng" });
            }

            //LatLng has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LatLngHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLatLngHasErrors), new[] { "LatLngHasErrors" });
            }

            //LatLngHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LatLngLat))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLatLngLat), new[] { "LatLngLat" });
            }

            //LatLngLat has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LatLngLng))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLatLngLng), new[] { "LatLngLng" });
            }

            //LatLngLng has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.Log))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLog), new[] { "Log" });
            }

            //Log has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LogHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLogHasErrors), new[] { "LogHasErrors" });
            }

            //LogHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LogID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLogID), new[] { "LogID" });
            }

            //LogID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.Login))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLogin), new[] { "Login" });
            }

            //Login has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LoginConfirmPassword))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLoginConfirmPassword), new[] { "LoginConfirmPassword" });
            }

            //LoginConfirmPassword has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LogInformation))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLogInformation), new[] { "LogInformation" });
            }

            //LogInformation has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LoginHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLoginHasErrors), new[] { "LoginHasErrors" });
            }

            //LoginHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LoginLoginEmail))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLoginLoginEmail), new[] { "LoginLoginEmail" });
            }

            //LoginLoginEmail has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LoginPassword))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLoginPassword), new[] { "LoginPassword" });
            }

            //LoginPassword has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LogLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLogLastUpdateContactTVItemID), new[] { "LogLastUpdateContactTVItemID" });
            }

            //LogLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LogLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLogLastUpdateContactTVText), new[] { "LogLastUpdateContactTVText" });
            }

            //LogLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LogLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLogLastUpdateDate_UTC), new[] { "LogLastUpdateDate_UTC" });
            }

            //LogLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LogLogCommand))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLogLogCommand), new[] { "LogLogCommand" });
            }

            //LogLogCommand has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LogLogCommandText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLogLogCommandText), new[] { "LogLogCommandText" });
            }

            //LogLogCommandText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LogLogID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLogLogID), new[] { "LogLogID" });
            }

            //LogLogID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.LogTableName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResLogTableName), new[] { "LogTableName" });
            }

            //LogTableName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapInfo))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapInfo), new[] { "MapInfo" });
            }

            //MapInfo has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapInfoHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapInfoHasErrors), new[] { "MapInfoHasErrors" });
            }

            //MapInfoHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapInfoLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapInfoLastUpdateContactTVItemID), new[] { "MapInfoLastUpdateContactTVItemID" });
            }

            //MapInfoLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapInfoLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapInfoLastUpdateContactTVText), new[] { "MapInfoLastUpdateContactTVText" });
            }

            //MapInfoLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapInfoLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapInfoLastUpdateDate_UTC), new[] { "MapInfoLastUpdateDate_UTC" });
            }

            //MapInfoLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapInfoLatMax))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapInfoLatMax), new[] { "MapInfoLatMax" });
            }

            //MapInfoLatMax has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapInfoLatMin))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapInfoLatMin), new[] { "MapInfoLatMin" });
            }

            //MapInfoLatMin has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapInfoLngMax))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapInfoLngMax), new[] { "MapInfoLngMax" });
            }

            //MapInfoLngMax has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapInfoLngMin))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapInfoLngMin), new[] { "MapInfoLngMin" });
            }

            //MapInfoLngMin has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapInfoMapInfoDrawType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapInfoMapInfoDrawType), new[] { "MapInfoMapInfoDrawType" });
            }

            //MapInfoMapInfoDrawType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapInfoMapInfoDrawTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapInfoMapInfoDrawTypeText), new[] { "MapInfoMapInfoDrawTypeText" });
            }

            //MapInfoMapInfoDrawTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapInfoMapInfoID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapInfoMapInfoID), new[] { "MapInfoMapInfoID" });
            }

            //MapInfoMapInfoID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapInfoPoint))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapInfoPoint), new[] { "MapInfoPoint" });
            }

            //MapInfoPoint has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapInfoPointHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapInfoPointHasErrors), new[] { "MapInfoPointHasErrors" });
            }

            //MapInfoPointHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapInfoPointLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapInfoPointLastUpdateContactTVItemID), new[] { "MapInfoPointLastUpdateContactTVItemID" });
            }

            //MapInfoPointLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapInfoPointLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapInfoPointLastUpdateContactTVText), new[] { "MapInfoPointLastUpdateContactTVText" });
            }

            //MapInfoPointLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapInfoPointLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapInfoPointLastUpdateDate_UTC), new[] { "MapInfoPointLastUpdateDate_UTC" });
            }

            //MapInfoPointLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapInfoPointLat))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapInfoPointLat), new[] { "MapInfoPointLat" });
            }

            //MapInfoPointLat has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapInfoPointLng))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapInfoPointLng), new[] { "MapInfoPointLng" });
            }

            //MapInfoPointLng has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapInfoPointMapInfoID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapInfoPointMapInfoID), new[] { "MapInfoPointMapInfoID" });
            }

            //MapInfoPointMapInfoID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapInfoPointMapInfoPointID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapInfoPointMapInfoPointID), new[] { "MapInfoPointMapInfoPointID" });
            }

            //MapInfoPointMapInfoPointID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapInfoPointOrdinal))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapInfoPointOrdinal), new[] { "MapInfoPointOrdinal" });
            }

            //MapInfoPointOrdinal has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapInfoTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapInfoTVItemID), new[] { "MapInfoTVItemID" });
            }

            //MapInfoTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapInfoTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapInfoTVText), new[] { "MapInfoTVText" });
            }

            //MapInfoTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapInfoTVType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapInfoTVType), new[] { "MapInfoTVType" });
            }

            //MapInfoTVType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapInfoTVTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapInfoTVTypeText), new[] { "MapInfoTVTypeText" });
            }

            //MapInfoTVTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapObj))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapObj), new[] { "MapObj" });
            }

            //MapObj has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapObjCoordList))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapObjCoordList), new[] { "MapObjCoordList" });
            }

            //MapObjCoordList has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapObjHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapObjHasErrors), new[] { "MapObjHasErrors" });
            }

            //MapObjHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapObjMapInfoDrawType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapObjMapInfoDrawType), new[] { "MapObjMapInfoDrawType" });
            }

            //MapObjMapInfoDrawType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapObjMapInfoDrawTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapObjMapInfoDrawTypeText), new[] { "MapObjMapInfoDrawTypeText" });
            }

            //MapObjMapInfoDrawTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MapObjMapInfoID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMapObjMapInfoID), new[] { "MapObjMapInfoID" });
            }

            //MapObjMapInfoID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeBoundaryCondition))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeBoundaryCondition), new[] { "MikeBoundaryCondition" });
            }

            //MikeBoundaryCondition has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeBoundaryConditionHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeBoundaryConditionHasErrors), new[] { "MikeBoundaryConditionHasErrors" });
            }

            //MikeBoundaryConditionHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeBoundaryConditionLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeBoundaryConditionLastUpdateContactTVItemID), new[] { "MikeBoundaryConditionLastUpdateContactTVItemID" });
            }

            //MikeBoundaryConditionLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeBoundaryConditionLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeBoundaryConditionLastUpdateContactTVText), new[] { "MikeBoundaryConditionLastUpdateContactTVText" });
            }

            //MikeBoundaryConditionLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeBoundaryConditionLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeBoundaryConditionLastUpdateDate_UTC), new[] { "MikeBoundaryConditionLastUpdateDate_UTC" });
            }

            //MikeBoundaryConditionLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionCode))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeBoundaryConditionMikeBoundaryConditionCode), new[] { "MikeBoundaryConditionMikeBoundaryConditionCode" });
            }

            //MikeBoundaryConditionMikeBoundaryConditionCode has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionFormat))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeBoundaryConditionMikeBoundaryConditionFormat), new[] { "MikeBoundaryConditionMikeBoundaryConditionFormat" });
            }

            //MikeBoundaryConditionMikeBoundaryConditionFormat has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeBoundaryConditionMikeBoundaryConditionID), new[] { "MikeBoundaryConditionMikeBoundaryConditionID" });
            }

            //MikeBoundaryConditionMikeBoundaryConditionID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionLength_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeBoundaryConditionMikeBoundaryConditionLength_m), new[] { "MikeBoundaryConditionMikeBoundaryConditionLength_m" });
            }

            //MikeBoundaryConditionMikeBoundaryConditionLength_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionLevelOrVelocity))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeBoundaryConditionMikeBoundaryConditionLevelOrVelocity), new[] { "MikeBoundaryConditionMikeBoundaryConditionLevelOrVelocity" });
            }

            //MikeBoundaryConditionMikeBoundaryConditionLevelOrVelocity has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionLevelOrVelocityText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeBoundaryConditionMikeBoundaryConditionLevelOrVelocityText), new[] { "MikeBoundaryConditionMikeBoundaryConditionLevelOrVelocityText" });
            }

            //MikeBoundaryConditionMikeBoundaryConditionLevelOrVelocityText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeBoundaryConditionMikeBoundaryConditionName), new[] { "MikeBoundaryConditionMikeBoundaryConditionName" });
            }

            //MikeBoundaryConditionMikeBoundaryConditionName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeBoundaryConditionMikeBoundaryConditionTVItemID), new[] { "MikeBoundaryConditionMikeBoundaryConditionTVItemID" });
            }

            //MikeBoundaryConditionMikeBoundaryConditionTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeBoundaryConditionMikeBoundaryConditionTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeBoundaryConditionMikeBoundaryConditionTVText), new[] { "MikeBoundaryConditionMikeBoundaryConditionTVText" });
            }

            //MikeBoundaryConditionMikeBoundaryConditionTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeBoundaryConditionNumberOfWebTideNodes))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeBoundaryConditionNumberOfWebTideNodes), new[] { "MikeBoundaryConditionNumberOfWebTideNodes" });
            }

            //MikeBoundaryConditionNumberOfWebTideNodes has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeBoundaryConditionTVType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeBoundaryConditionTVType), new[] { "MikeBoundaryConditionTVType" });
            }

            //MikeBoundaryConditionTVType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeBoundaryConditionTVTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeBoundaryConditionTVTypeText), new[] { "MikeBoundaryConditionTVTypeText" });
            }

            //MikeBoundaryConditionTVTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeBoundaryConditionWebTideDataFromStartToEndDate))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeBoundaryConditionWebTideDataFromStartToEndDate), new[] { "MikeBoundaryConditionWebTideDataFromStartToEndDate" });
            }

            //MikeBoundaryConditionWebTideDataFromStartToEndDate has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeBoundaryConditionWebTideDataSet))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeBoundaryConditionWebTideDataSet), new[] { "MikeBoundaryConditionWebTideDataSet" });
            }

            //MikeBoundaryConditionWebTideDataSet has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeBoundaryConditionWebTideDataSetText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeBoundaryConditionWebTideDataSetText), new[] { "MikeBoundaryConditionWebTideDataSetText" });
            }

            //MikeBoundaryConditionWebTideDataSetText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenario))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenario), new[] { "MikeScenario" });
            }

            //MikeScenario has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioAmbientSalinity_PSU))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioAmbientSalinity_PSU), new[] { "MikeScenarioAmbientSalinity_PSU" });
            }

            //MikeScenarioAmbientSalinity_PSU has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioAmbientTemperature_C))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioAmbientTemperature_C), new[] { "MikeScenarioAmbientTemperature_C" });
            }

            //MikeScenarioAmbientTemperature_C has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioDecayFactor_per_day))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioDecayFactor_per_day), new[] { "MikeScenarioDecayFactor_per_day" });
            }

            //MikeScenarioDecayFactor_per_day has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioDecayFactorAmplitude))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioDecayFactorAmplitude), new[] { "MikeScenarioDecayFactorAmplitude" });
            }

            //MikeScenarioDecayFactorAmplitude has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioDecayIsConstant))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioDecayIsConstant), new[] { "MikeScenarioDecayIsConstant" });
            }

            //MikeScenarioDecayIsConstant has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioErrorInfo))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioErrorInfo), new[] { "MikeScenarioErrorInfo" });
            }

            //MikeScenarioErrorInfo has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioEstimatedHydroFileSize))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioEstimatedHydroFileSize), new[] { "MikeScenarioEstimatedHydroFileSize" });
            }

            //MikeScenarioEstimatedHydroFileSize has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioEstimatedTransFileSize))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioEstimatedTransFileSize), new[] { "MikeScenarioEstimatedTransFileSize" });
            }

            //MikeScenarioEstimatedTransFileSize has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioHasErrors), new[] { "MikeScenarioHasErrors" });
            }

            //MikeScenarioHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioLastUpdateContactTVItemID), new[] { "MikeScenarioLastUpdateContactTVItemID" });
            }

            //MikeScenarioLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioLastUpdateContactTVText), new[] { "MikeScenarioLastUpdateContactTVText" });
            }

            //MikeScenarioLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioLastUpdateDate_UTC), new[] { "MikeScenarioLastUpdateDate_UTC" });
            }

            //MikeScenarioLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioManningNumber))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioManningNumber), new[] { "MikeScenarioManningNumber" });
            }

            //MikeScenarioManningNumber has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioMikeScenarioEndDateTime_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioMikeScenarioEndDateTime_Local), new[] { "MikeScenarioMikeScenarioEndDateTime_Local" });
            }

            //MikeScenarioMikeScenarioEndDateTime_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioMikeScenarioExecutionTime_min))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioMikeScenarioExecutionTime_min), new[] { "MikeScenarioMikeScenarioExecutionTime_min" });
            }

            //MikeScenarioMikeScenarioExecutionTime_min has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioMikeScenarioID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioMikeScenarioID), new[] { "MikeScenarioMikeScenarioID" });
            }

            //MikeScenarioMikeScenarioID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioMikeScenarioStartDateTime_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioMikeScenarioStartDateTime_Local), new[] { "MikeScenarioMikeScenarioStartDateTime_Local" });
            }

            //MikeScenarioMikeScenarioStartDateTime_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioMikeScenarioStartExecutionDateTime_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioMikeScenarioStartExecutionDateTime_Local), new[] { "MikeScenarioMikeScenarioStartExecutionDateTime_Local" });
            }

            //MikeScenarioMikeScenarioStartExecutionDateTime_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioMikeScenarioTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioMikeScenarioTVItemID), new[] { "MikeScenarioMikeScenarioTVItemID" });
            }

            //MikeScenarioMikeScenarioTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioMikeScenarioTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioMikeScenarioTVText), new[] { "MikeScenarioMikeScenarioTVText" });
            }

            //MikeScenarioMikeScenarioTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioNumberOfElements))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioNumberOfElements), new[] { "MikeScenarioNumberOfElements" });
            }

            //MikeScenarioNumberOfElements has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioNumberOfHydroOutputParameters))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioNumberOfHydroOutputParameters), new[] { "MikeScenarioNumberOfHydroOutputParameters" });
            }

            //MikeScenarioNumberOfHydroOutputParameters has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioNumberOfSigmaLayers))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioNumberOfSigmaLayers), new[] { "MikeScenarioNumberOfSigmaLayers" });
            }

            //MikeScenarioNumberOfSigmaLayers has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioNumberOfTimeSteps))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioNumberOfTimeSteps), new[] { "MikeScenarioNumberOfTimeSteps" });
            }

            //MikeScenarioNumberOfTimeSteps has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioNumberOfTransOutputParameters))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioNumberOfTransOutputParameters), new[] { "MikeScenarioNumberOfTransOutputParameters" });
            }

            //MikeScenarioNumberOfTransOutputParameters has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioNumberOfZLayers))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioNumberOfZLayers), new[] { "MikeScenarioNumberOfZLayers" });
            }

            //MikeScenarioNumberOfZLayers has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioParentMikeScenarioID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioParentMikeScenarioID), new[] { "MikeScenarioParentMikeScenarioID" });
            }

            //MikeScenarioParentMikeScenarioID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioResultFrequency_min))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioResultFrequency_min), new[] { "MikeScenarioResultFrequency_min" });
            }

            //MikeScenarioResultFrequency_min has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioScenarioStatus))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioScenarioStatus), new[] { "MikeScenarioScenarioStatus" });
            }

            //MikeScenarioScenarioStatus has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioScenarioStatusText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioScenarioStatusText), new[] { "MikeScenarioScenarioStatusText" });
            }

            //MikeScenarioScenarioStatusText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioWindDirection_deg))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioWindDirection_deg), new[] { "MikeScenarioWindDirection_deg" });
            }

            //MikeScenarioWindDirection_deg has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeScenarioWindSpeed_km_h))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeScenarioWindSpeed_km_h), new[] { "MikeScenarioWindSpeed_km_h" });
            }

            //MikeScenarioWindSpeed_km_h has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSource))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSource), new[] { "MikeSource" });
            }

            //MikeSource has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSourceHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSourceHasErrors), new[] { "MikeSourceHasErrors" });
            }

            //MikeSourceHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSourceInclude))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSourceInclude), new[] { "MikeSourceInclude" });
            }

            //MikeSourceInclude has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSourceIsContinuous))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSourceIsContinuous), new[] { "MikeSourceIsContinuous" });
            }

            //MikeSourceIsContinuous has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSourceIsRiver))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSourceIsRiver), new[] { "MikeSourceIsRiver" });
            }

            //MikeSourceIsRiver has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSourceLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSourceLastUpdateContactTVItemID), new[] { "MikeSourceLastUpdateContactTVItemID" });
            }

            //MikeSourceLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSourceLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSourceLastUpdateContactTVText), new[] { "MikeSourceLastUpdateContactTVText" });
            }

            //MikeSourceLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSourceLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSourceLastUpdateDate_UTC), new[] { "MikeSourceLastUpdateDate_UTC" });
            }

            //MikeSourceLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSourceMikeSourceID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSourceMikeSourceID), new[] { "MikeSourceMikeSourceID" });
            }

            //MikeSourceMikeSourceID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSourceMikeSourceTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSourceMikeSourceTVItemID), new[] { "MikeSourceMikeSourceTVItemID" });
            }

            //MikeSourceMikeSourceTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSourceMikeSourceTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSourceMikeSourceTVText), new[] { "MikeSourceMikeSourceTVText" });
            }

            //MikeSourceMikeSourceTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSourceSourceNumberString))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSourceSourceNumberString), new[] { "MikeSourceSourceNumberString" });
            }

            //MikeSourceSourceNumberString has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSourceStartEnd))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSourceStartEnd), new[] { "MikeSourceStartEnd" });
            }

            //MikeSourceStartEnd has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSourceStartEndEndDateAndTime_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSourceStartEndEndDateAndTime_Local), new[] { "MikeSourceStartEndEndDateAndTime_Local" });
            }

            //MikeSourceStartEndEndDateAndTime_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSourceStartEndHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSourceStartEndHasErrors), new[] { "MikeSourceStartEndHasErrors" });
            }

            //MikeSourceStartEndHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSourceStartEndLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSourceStartEndLastUpdateContactTVItemID), new[] { "MikeSourceStartEndLastUpdateContactTVItemID" });
            }

            //MikeSourceStartEndLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSourceStartEndLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSourceStartEndLastUpdateContactTVText), new[] { "MikeSourceStartEndLastUpdateContactTVText" });
            }

            //MikeSourceStartEndLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSourceStartEndLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSourceStartEndLastUpdateDate_UTC), new[] { "MikeSourceStartEndLastUpdateDate_UTC" });
            }

            //MikeSourceStartEndLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSourceStartEndMikeSourceID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSourceStartEndMikeSourceID), new[] { "MikeSourceStartEndMikeSourceID" });
            }

            //MikeSourceStartEndMikeSourceID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSourceStartEndMikeSourceStartEndID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSourceStartEndMikeSourceStartEndID), new[] { "MikeSourceStartEndMikeSourceStartEndID" });
            }

            //MikeSourceStartEndMikeSourceStartEndID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSourceStartEndSourceFlowEnd_m3_day))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSourceStartEndSourceFlowEnd_m3_day), new[] { "MikeSourceStartEndSourceFlowEnd_m3_day" });
            }

            //MikeSourceStartEndSourceFlowEnd_m3_day has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSourceStartEndSourceFlowStart_m3_day))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSourceStartEndSourceFlowStart_m3_day), new[] { "MikeSourceStartEndSourceFlowStart_m3_day" });
            }

            //MikeSourceStartEndSourceFlowStart_m3_day has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSourceStartEndSourcePollutionEnd_MPN_100ml))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSourceStartEndSourcePollutionEnd_MPN_100ml), new[] { "MikeSourceStartEndSourcePollutionEnd_MPN_100ml" });
            }

            //MikeSourceStartEndSourcePollutionEnd_MPN_100ml has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSourceStartEndSourcePollutionStart_MPN_100ml))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSourceStartEndSourcePollutionStart_MPN_100ml), new[] { "MikeSourceStartEndSourcePollutionStart_MPN_100ml" });
            }

            //MikeSourceStartEndSourcePollutionStart_MPN_100ml has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSourceStartEndSourceSalinityEnd_PSU))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSourceStartEndSourceSalinityEnd_PSU), new[] { "MikeSourceStartEndSourceSalinityEnd_PSU" });
            }

            //MikeSourceStartEndSourceSalinityEnd_PSU has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSourceStartEndSourceSalinityStart_PSU))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSourceStartEndSourceSalinityStart_PSU), new[] { "MikeSourceStartEndSourceSalinityStart_PSU" });
            }

            //MikeSourceStartEndSourceSalinityStart_PSU has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSourceStartEndSourceTemperatureEnd_C))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSourceStartEndSourceTemperatureEnd_C), new[] { "MikeSourceStartEndSourceTemperatureEnd_C" });
            }

            //MikeSourceStartEndSourceTemperatureEnd_C has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSourceStartEndSourceTemperatureStart_C))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSourceStartEndSourceTemperatureStart_C), new[] { "MikeSourceStartEndSourceTemperatureStart_C" });
            }

            //MikeSourceStartEndSourceTemperatureStart_C has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MikeSourceStartEndStartDateAndTime_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMikeSourceStartEndStartDateAndTime_Local), new[] { "MikeSourceStartEndStartDateAndTime_Local" });
            }

            //MikeSourceStartEndStartDateAndTime_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMAnalysisReportParameter))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMAnalysisReportParameter), new[] { "MWQMAnalysisReportParameter" });
            }

            //MWQMAnalysisReportParameter has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMAnalysisReportParameterAnalysisCalculationType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMAnalysisReportParameterAnalysisCalculationType), new[] { "MWQMAnalysisReportParameterAnalysisCalculationType" });
            }

            //MWQMAnalysisReportParameterAnalysisCalculationType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMAnalysisReportParameterAnalysisName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMAnalysisReportParameterAnalysisName), new[] { "MWQMAnalysisReportParameterAnalysisName" });
            }

            //MWQMAnalysisReportParameterAnalysisName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMAnalysisReportParameterAnalysisReportYear))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMAnalysisReportParameterAnalysisReportYear), new[] { "MWQMAnalysisReportParameterAnalysisReportYear" });
            }

            //MWQMAnalysisReportParameterAnalysisReportYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMAnalysisReportParameterDryLimit24h))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMAnalysisReportParameterDryLimit24h), new[] { "MWQMAnalysisReportParameterDryLimit24h" });
            }

            //MWQMAnalysisReportParameterDryLimit24h has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMAnalysisReportParameterDryLimit48h))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMAnalysisReportParameterDryLimit48h), new[] { "MWQMAnalysisReportParameterDryLimit48h" });
            }

            //MWQMAnalysisReportParameterDryLimit48h has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMAnalysisReportParameterDryLimit72h))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMAnalysisReportParameterDryLimit72h), new[] { "MWQMAnalysisReportParameterDryLimit72h" });
            }

            //MWQMAnalysisReportParameterDryLimit72h has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMAnalysisReportParameterDryLimit96h))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMAnalysisReportParameterDryLimit96h), new[] { "MWQMAnalysisReportParameterDryLimit96h" });
            }

            //MWQMAnalysisReportParameterDryLimit96h has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMAnalysisReportParameterEndDate))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMAnalysisReportParameterEndDate), new[] { "MWQMAnalysisReportParameterEndDate" });
            }

            //MWQMAnalysisReportParameterEndDate has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMAnalysisReportParameterFullYear))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMAnalysisReportParameterFullYear), new[] { "MWQMAnalysisReportParameterFullYear" });
            }

            //MWQMAnalysisReportParameterFullYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMAnalysisReportParameterHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMAnalysisReportParameterHasErrors), new[] { "MWQMAnalysisReportParameterHasErrors" });
            }

            //MWQMAnalysisReportParameterHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMAnalysisReportParameterLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMAnalysisReportParameterLastUpdateContactTVItemID), new[] { "MWQMAnalysisReportParameterLastUpdateContactTVItemID" });
            }

            //MWQMAnalysisReportParameterLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMAnalysisReportParameterLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMAnalysisReportParameterLastUpdateContactTVText), new[] { "MWQMAnalysisReportParameterLastUpdateContactTVText" });
            }

            //MWQMAnalysisReportParameterLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMAnalysisReportParameterLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMAnalysisReportParameterLastUpdateDate_UTC), new[] { "MWQMAnalysisReportParameterLastUpdateDate_UTC" });
            }

            //MWQMAnalysisReportParameterLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMAnalysisReportParameterMidRangeNumberOfDays))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMAnalysisReportParameterMidRangeNumberOfDays), new[] { "MWQMAnalysisReportParameterMidRangeNumberOfDays" });
            }

            //MWQMAnalysisReportParameterMidRangeNumberOfDays has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMAnalysisReportParameterMWQMAnalysisReportParameterID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMAnalysisReportParameterMWQMAnalysisReportParameterID), new[] { "MWQMAnalysisReportParameterMWQMAnalysisReportParameterID" });
            }

            //MWQMAnalysisReportParameterMWQMAnalysisReportParameterID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMAnalysisReportParameterNumberOfRuns))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMAnalysisReportParameterNumberOfRuns), new[] { "MWQMAnalysisReportParameterNumberOfRuns" });
            }

            //MWQMAnalysisReportParameterNumberOfRuns has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMAnalysisReportParameterRunsToOmit))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMAnalysisReportParameterRunsToOmit), new[] { "MWQMAnalysisReportParameterRunsToOmit" });
            }

            //MWQMAnalysisReportParameterRunsToOmit has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMAnalysisReportParameterSalinityHighlightDeviationFromAverage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMAnalysisReportParameterSalinityHighlightDeviationFromAverage), new[] { "MWQMAnalysisReportParameterSalinityHighlightDeviationFromAverage" });
            }

            //MWQMAnalysisReportParameterSalinityHighlightDeviationFromAverage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMAnalysisReportParameterShortRangeNumberOfDays))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMAnalysisReportParameterShortRangeNumberOfDays), new[] { "MWQMAnalysisReportParameterShortRangeNumberOfDays" });
            }

            //MWQMAnalysisReportParameterShortRangeNumberOfDays has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMAnalysisReportParameterStartDate))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMAnalysisReportParameterStartDate), new[] { "MWQMAnalysisReportParameterStartDate" });
            }

            //MWQMAnalysisReportParameterStartDate has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMAnalysisReportParameterSubsectorTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMAnalysisReportParameterSubsectorTVItemID), new[] { "MWQMAnalysisReportParameterSubsectorTVItemID" });
            }

            //MWQMAnalysisReportParameterSubsectorTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMAnalysisReportParameterWetLimit24h))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMAnalysisReportParameterWetLimit24h), new[] { "MWQMAnalysisReportParameterWetLimit24h" });
            }

            //MWQMAnalysisReportParameterWetLimit24h has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMAnalysisReportParameterWetLimit48h))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMAnalysisReportParameterWetLimit48h), new[] { "MWQMAnalysisReportParameterWetLimit48h" });
            }

            //MWQMAnalysisReportParameterWetLimit48h has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMAnalysisReportParameterWetLimit72h))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMAnalysisReportParameterWetLimit72h), new[] { "MWQMAnalysisReportParameterWetLimit72h" });
            }

            //MWQMAnalysisReportParameterWetLimit72h has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMAnalysisReportParameterWetLimit96h))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMAnalysisReportParameterWetLimit96h), new[] { "MWQMAnalysisReportParameterWetLimit96h" });
            }

            //MWQMAnalysisReportParameterWetLimit96h has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMLookupMPN))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMLookupMPN), new[] { "MWQMLookupMPN" });
            }

            //MWQMLookupMPN has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMLookupMPNHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMLookupMPNHasErrors), new[] { "MWQMLookupMPNHasErrors" });
            }

            //MWQMLookupMPNHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMLookupMPNLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMLookupMPNLastUpdateContactTVItemID), new[] { "MWQMLookupMPNLastUpdateContactTVItemID" });
            }

            //MWQMLookupMPNLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMLookupMPNLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMLookupMPNLastUpdateContactTVText), new[] { "MWQMLookupMPNLastUpdateContactTVText" });
            }

            //MWQMLookupMPNLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMLookupMPNLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMLookupMPNLastUpdateDate_UTC), new[] { "MWQMLookupMPNLastUpdateDate_UTC" });
            }

            //MWQMLookupMPNLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMLookupMPNMPN_100ml))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMLookupMPNMPN_100ml), new[] { "MWQMLookupMPNMPN_100ml" });
            }

            //MWQMLookupMPNMPN_100ml has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMLookupMPNMWQMLookupMPNID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMLookupMPNMWQMLookupMPNID), new[] { "MWQMLookupMPNMWQMLookupMPNID" });
            }

            //MWQMLookupMPNMWQMLookupMPNID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMLookupMPNTubes01))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMLookupMPNTubes01), new[] { "MWQMLookupMPNTubes01" });
            }

            //MWQMLookupMPNTubes01 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMLookupMPNTubes1))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMLookupMPNTubes1), new[] { "MWQMLookupMPNTubes1" });
            }

            //MWQMLookupMPNTubes1 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMLookupMPNTubes10))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMLookupMPNTubes10), new[] { "MWQMLookupMPNTubes10" });
            }

            //MWQMLookupMPNTubes10 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRun))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRun), new[] { "MWQMRun" });
            }

            //MWQMRun has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunAnalyzeMethod))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunAnalyzeMethod), new[] { "MWQMRunAnalyzeMethod" });
            }

            //MWQMRunAnalyzeMethod has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunAnalyzeMethodText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunAnalyzeMethodText), new[] { "MWQMRunAnalyzeMethodText" });
            }

            //MWQMRunAnalyzeMethodText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunDateTime_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunDateTime_Local), new[] { "MWQMRunDateTime_Local" });
            }

            //MWQMRunDateTime_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunEndDateTime_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunEndDateTime_Local), new[] { "MWQMRunEndDateTime_Local" });
            }

            //MWQMRunEndDateTime_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunHasErrors), new[] { "MWQMRunHasErrors" });
            }

            //MWQMRunHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunLabAnalyzeBath1IncubationStartDateTime_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunLabAnalyzeBath1IncubationStartDateTime_Local), new[] { "MWQMRunLabAnalyzeBath1IncubationStartDateTime_Local" });
            }

            //MWQMRunLabAnalyzeBath1IncubationStartDateTime_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunLabAnalyzeBath2IncubationStartDateTime_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunLabAnalyzeBath2IncubationStartDateTime_Local), new[] { "MWQMRunLabAnalyzeBath2IncubationStartDateTime_Local" });
            }

            //MWQMRunLabAnalyzeBath2IncubationStartDateTime_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunLabAnalyzeBath3IncubationStartDateTime_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunLabAnalyzeBath3IncubationStartDateTime_Local), new[] { "MWQMRunLabAnalyzeBath3IncubationStartDateTime_Local" });
            }

            //MWQMRunLabAnalyzeBath3IncubationStartDateTime_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunLaboratory))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunLaboratory), new[] { "MWQMRunLaboratory" });
            }

            //MWQMRunLaboratory has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunLaboratoryText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunLaboratoryText), new[] { "MWQMRunLaboratoryText" });
            }

            //MWQMRunLaboratoryText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunLabReceivedDateTime_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunLabReceivedDateTime_Local), new[] { "MWQMRunLabReceivedDateTime_Local" });
            }

            //MWQMRunLabReceivedDateTime_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunLabRunSampleApprovalDateTime_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunLabRunSampleApprovalDateTime_Local), new[] { "MWQMRunLabRunSampleApprovalDateTime_Local" });
            }

            //MWQMRunLabRunSampleApprovalDateTime_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunLabSampleApprovalContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunLabSampleApprovalContactTVItemID), new[] { "MWQMRunLabSampleApprovalContactTVItemID" });
            }

            //MWQMRunLabSampleApprovalContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunLabSampleApprovalContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunLabSampleApprovalContactTVText), new[] { "MWQMRunLabSampleApprovalContactTVText" });
            }

            //MWQMRunLabSampleApprovalContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunLanguage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunLanguage), new[] { "MWQMRunLanguage" });
            }

            //MWQMRunLanguage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunLanguageHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunLanguageHasErrors), new[] { "MWQMRunLanguageHasErrors" });
            }

            //MWQMRunLanguageHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunLanguageLanguage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunLanguageLanguage), new[] { "MWQMRunLanguageLanguage" });
            }

            //MWQMRunLanguageLanguage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunLanguageLanguageText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunLanguageLanguageText), new[] { "MWQMRunLanguageLanguageText" });
            }

            //MWQMRunLanguageLanguageText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunLanguageLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunLanguageLastUpdateContactTVItemID), new[] { "MWQMRunLanguageLastUpdateContactTVItemID" });
            }

            //MWQMRunLanguageLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunLanguageLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunLanguageLastUpdateContactTVText), new[] { "MWQMRunLanguageLastUpdateContactTVText" });
            }

            //MWQMRunLanguageLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunLanguageLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunLanguageLastUpdateDate_UTC), new[] { "MWQMRunLanguageLastUpdateDate_UTC" });
            }

            //MWQMRunLanguageLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunLanguageMWQMRunID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunLanguageMWQMRunID), new[] { "MWQMRunLanguageMWQMRunID" });
            }

            //MWQMRunLanguageMWQMRunID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunLanguageMWQMRunLanguageID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunLanguageMWQMRunLanguageID), new[] { "MWQMRunLanguageMWQMRunLanguageID" });
            }

            //MWQMRunLanguageMWQMRunLanguageID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunLanguageRunComment))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunLanguageRunComment), new[] { "MWQMRunLanguageRunComment" });
            }

            //MWQMRunLanguageRunComment has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunLanguageRunWeatherComment))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunLanguageRunWeatherComment), new[] { "MWQMRunLanguageRunWeatherComment" });
            }

            //MWQMRunLanguageRunWeatherComment has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunLanguageTranslationStatusRunComment))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunLanguageTranslationStatusRunComment), new[] { "MWQMRunLanguageTranslationStatusRunComment" });
            }

            //MWQMRunLanguageTranslationStatusRunComment has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunLanguageTranslationStatusRunCommentText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunLanguageTranslationStatusRunCommentText), new[] { "MWQMRunLanguageTranslationStatusRunCommentText" });
            }

            //MWQMRunLanguageTranslationStatusRunCommentText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunLanguageTranslationStatusRunWeatherComment))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunLanguageTranslationStatusRunWeatherComment), new[] { "MWQMRunLanguageTranslationStatusRunWeatherComment" });
            }

            //MWQMRunLanguageTranslationStatusRunWeatherComment has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunLanguageTranslationStatusRunWeatherCommentText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunLanguageTranslationStatusRunWeatherCommentText), new[] { "MWQMRunLanguageTranslationStatusRunWeatherCommentText" });
            }

            //MWQMRunLanguageTranslationStatusRunWeatherCommentText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunLastUpdateContactTVItemID), new[] { "MWQMRunLastUpdateContactTVItemID" });
            }

            //MWQMRunLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunLastUpdateContactTVText), new[] { "MWQMRunLastUpdateContactTVText" });
            }

            //MWQMRunLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunLastUpdateDate_UTC), new[] { "MWQMRunLastUpdateDate_UTC" });
            }

            //MWQMRunLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunMWQMRunID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunMWQMRunID), new[] { "MWQMRunMWQMRunID" });
            }

            //MWQMRunMWQMRunID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunMWQMRunTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunMWQMRunTVItemID), new[] { "MWQMRunMWQMRunTVItemID" });
            }

            //MWQMRunMWQMRunTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunMWQMRunTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunMWQMRunTVText), new[] { "MWQMRunMWQMRunTVText" });
            }

            //MWQMRunMWQMRunTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunRainDay0_mm))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunRainDay0_mm), new[] { "MWQMRunRainDay0_mm" });
            }

            //MWQMRunRainDay0_mm has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunRainDay1_mm))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunRainDay1_mm), new[] { "MWQMRunRainDay1_mm" });
            }

            //MWQMRunRainDay1_mm has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunRainDay10_mm))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunRainDay10_mm), new[] { "MWQMRunRainDay10_mm" });
            }

            //MWQMRunRainDay10_mm has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunRainDay2_mm))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunRainDay2_mm), new[] { "MWQMRunRainDay2_mm" });
            }

            //MWQMRunRainDay2_mm has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunRainDay3_mm))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunRainDay3_mm), new[] { "MWQMRunRainDay3_mm" });
            }

            //MWQMRunRainDay3_mm has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunRainDay4_mm))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunRainDay4_mm), new[] { "MWQMRunRainDay4_mm" });
            }

            //MWQMRunRainDay4_mm has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunRainDay5_mm))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunRainDay5_mm), new[] { "MWQMRunRainDay5_mm" });
            }

            //MWQMRunRainDay5_mm has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunRainDay6_mm))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunRainDay6_mm), new[] { "MWQMRunRainDay6_mm" });
            }

            //MWQMRunRainDay6_mm has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunRainDay7_mm))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunRainDay7_mm), new[] { "MWQMRunRainDay7_mm" });
            }

            //MWQMRunRainDay7_mm has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunRainDay8_mm))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunRainDay8_mm), new[] { "MWQMRunRainDay8_mm" });
            }

            //MWQMRunRainDay8_mm has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunRainDay9_mm))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunRainDay9_mm), new[] { "MWQMRunRainDay9_mm" });
            }

            //MWQMRunRainDay9_mm has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunRemoveFromStat))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunRemoveFromStat), new[] { "MWQMRunRemoveFromStat" });
            }

            //MWQMRunRemoveFromStat has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunRunNumber))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunRunNumber), new[] { "MWQMRunRunNumber" });
            }

            //MWQMRunRunNumber has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunRunSampleType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunRunSampleType), new[] { "MWQMRunRunSampleType" });
            }

            //MWQMRunRunSampleType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunRunSampleTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunRunSampleTypeText), new[] { "MWQMRunRunSampleTypeText" });
            }

            //MWQMRunRunSampleTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunSampleCrewInitials))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunSampleCrewInitials), new[] { "MWQMRunSampleCrewInitials" });
            }

            //MWQMRunSampleCrewInitials has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunSampleMatrix))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunSampleMatrix), new[] { "MWQMRunSampleMatrix" });
            }

            //MWQMRunSampleMatrix has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunSampleMatrixText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunSampleMatrixText), new[] { "MWQMRunSampleMatrixText" });
            }

            //MWQMRunSampleMatrixText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunSampleStatus))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunSampleStatus), new[] { "MWQMRunSampleStatus" });
            }

            //MWQMRunSampleStatus has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunSampleStatusText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunSampleStatusText), new[] { "MWQMRunSampleStatusText" });
            }

            //MWQMRunSampleStatusText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunSeaStateAtEnd_BeaufortScale))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunSeaStateAtEnd_BeaufortScale), new[] { "MWQMRunSeaStateAtEnd_BeaufortScale" });
            }

            //MWQMRunSeaStateAtEnd_BeaufortScale has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunSeaStateAtEnd_BeaufortScaleText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunSeaStateAtEnd_BeaufortScaleText), new[] { "MWQMRunSeaStateAtEnd_BeaufortScaleText" });
            }

            //MWQMRunSeaStateAtEnd_BeaufortScaleText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunSeaStateAtStart_BeaufortScale))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunSeaStateAtStart_BeaufortScale), new[] { "MWQMRunSeaStateAtStart_BeaufortScale" });
            }

            //MWQMRunSeaStateAtStart_BeaufortScale has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunSeaStateAtStart_BeaufortScaleText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunSeaStateAtStart_BeaufortScaleText), new[] { "MWQMRunSeaStateAtStart_BeaufortScaleText" });
            }

            //MWQMRunSeaStateAtStart_BeaufortScaleText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunStartDateTime_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunStartDateTime_Local), new[] { "MWQMRunStartDateTime_Local" });
            }

            //MWQMRunStartDateTime_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunSubsectorTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunSubsectorTVItemID), new[] { "MWQMRunSubsectorTVItemID" });
            }

            //MWQMRunSubsectorTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunSubsectorTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunSubsectorTVText), new[] { "MWQMRunSubsectorTVText" });
            }

            //MWQMRunSubsectorTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunTemperatureControl1_C))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunTemperatureControl1_C), new[] { "MWQMRunTemperatureControl1_C" });
            }

            //MWQMRunTemperatureControl1_C has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunTemperatureControl2_C))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunTemperatureControl2_C), new[] { "MWQMRunTemperatureControl2_C" });
            }

            //MWQMRunTemperatureControl2_C has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunTide_End))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunTide_End), new[] { "MWQMRunTide_End" });
            }

            //MWQMRunTide_End has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunTide_EndText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunTide_EndText), new[] { "MWQMRunTide_EndText" });
            }

            //MWQMRunTide_EndText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunTide_Start))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunTide_Start), new[] { "MWQMRunTide_Start" });
            }

            //MWQMRunTide_Start has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunTide_StartText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunTide_StartText), new[] { "MWQMRunTide_StartText" });
            }

            //MWQMRunTide_StartText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunWaterLevelAtBrook_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunWaterLevelAtBrook_m), new[] { "MWQMRunWaterLevelAtBrook_m" });
            }

            //MWQMRunWaterLevelAtBrook_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunWaveHightAtEnd_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunWaveHightAtEnd_m), new[] { "MWQMRunWaveHightAtEnd_m" });
            }

            //MWQMRunWaveHightAtEnd_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMRunWaveHightAtStart_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMRunWaveHightAtStart_m), new[] { "MWQMRunWaveHightAtStart_m" });
            }

            //MWQMRunWaveHightAtStart_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSample))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSample), new[] { "MWQMSample" });
            }

            //MWQMSample has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleDepth_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleDepth_m), new[] { "MWQMSampleDepth_m" });
            }

            //MWQMSampleDepth_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleDuplicateItem))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleDuplicateItem), new[] { "MWQMSampleDuplicateItem" });
            }

            //MWQMSampleDuplicateItem has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleDuplicateItemDuplicateSite))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleDuplicateItemDuplicateSite), new[] { "MWQMSampleDuplicateItemDuplicateSite" });
            }

            //MWQMSampleDuplicateItemDuplicateSite has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleDuplicateItemHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleDuplicateItemHasErrors), new[] { "MWQMSampleDuplicateItemHasErrors" });
            }

            //MWQMSampleDuplicateItemHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleDuplicateItemParentSite))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleDuplicateItemParentSite), new[] { "MWQMSampleDuplicateItemParentSite" });
            }

            //MWQMSampleDuplicateItemParentSite has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleFecCol_MPN_100ml))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleFecCol_MPN_100ml), new[] { "MWQMSampleFecCol_MPN_100ml" });
            }

            //MWQMSampleFecCol_MPN_100ml has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleHasErrors), new[] { "MWQMSampleHasErrors" });
            }

            //MWQMSampleHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleLanguage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleLanguage), new[] { "MWQMSampleLanguage" });
            }

            //MWQMSampleLanguage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleLanguageHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleLanguageHasErrors), new[] { "MWQMSampleLanguageHasErrors" });
            }

            //MWQMSampleLanguageHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleLanguageLanguage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleLanguageLanguage), new[] { "MWQMSampleLanguageLanguage" });
            }

            //MWQMSampleLanguageLanguage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleLanguageLanguageText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleLanguageLanguageText), new[] { "MWQMSampleLanguageLanguageText" });
            }

            //MWQMSampleLanguageLanguageText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleLanguageLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleLanguageLastUpdateContactTVItemID), new[] { "MWQMSampleLanguageLastUpdateContactTVItemID" });
            }

            //MWQMSampleLanguageLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleLanguageLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleLanguageLastUpdateContactTVText), new[] { "MWQMSampleLanguageLastUpdateContactTVText" });
            }

            //MWQMSampleLanguageLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleLanguageLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleLanguageLastUpdateDate_UTC), new[] { "MWQMSampleLanguageLastUpdateDate_UTC" });
            }

            //MWQMSampleLanguageLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleLanguageMWQMSampleID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleLanguageMWQMSampleID), new[] { "MWQMSampleLanguageMWQMSampleID" });
            }

            //MWQMSampleLanguageMWQMSampleID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleLanguageMWQMSampleLanguageID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleLanguageMWQMSampleLanguageID), new[] { "MWQMSampleLanguageMWQMSampleLanguageID" });
            }

            //MWQMSampleLanguageMWQMSampleLanguageID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleLanguageMWQMSampleNote))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleLanguageMWQMSampleNote), new[] { "MWQMSampleLanguageMWQMSampleNote" });
            }

            //MWQMSampleLanguageMWQMSampleNote has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleLanguageTranslationStatus))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleLanguageTranslationStatus), new[] { "MWQMSampleLanguageTranslationStatus" });
            }

            //MWQMSampleLanguageTranslationStatus has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleLanguageTranslationStatusText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleLanguageTranslationStatusText), new[] { "MWQMSampleLanguageTranslationStatusText" });
            }

            //MWQMSampleLanguageTranslationStatusText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleLastUpdateContactTVItemID), new[] { "MWQMSampleLastUpdateContactTVItemID" });
            }

            //MWQMSampleLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleLastUpdateContactTVText), new[] { "MWQMSampleLastUpdateContactTVText" });
            }

            //MWQMSampleLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleLastUpdateDate_UTC), new[] { "MWQMSampleLastUpdateDate_UTC" });
            }

            //MWQMSampleLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleMWQMRunTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleMWQMRunTVItemID), new[] { "MWQMSampleMWQMRunTVItemID" });
            }

            //MWQMSampleMWQMRunTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleMWQMRunTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleMWQMRunTVText), new[] { "MWQMSampleMWQMRunTVText" });
            }

            //MWQMSampleMWQMRunTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleMWQMSampleID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleMWQMSampleID), new[] { "MWQMSampleMWQMSampleID" });
            }

            //MWQMSampleMWQMSampleID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleMWQMSiteTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleMWQMSiteTVItemID), new[] { "MWQMSampleMWQMSiteTVItemID" });
            }

            //MWQMSampleMWQMSiteTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleMWQMSiteTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleMWQMSiteTVText), new[] { "MWQMSampleMWQMSiteTVText" });
            }

            //MWQMSampleMWQMSiteTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSamplePH))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSamplePH), new[] { "MWQMSamplePH" });
            }

            //MWQMSamplePH has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleProcessedBy))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleProcessedBy), new[] { "MWQMSampleProcessedBy" });
            }

            //MWQMSampleProcessedBy has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleSalinity_PPT))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleSalinity_PPT), new[] { "MWQMSampleSalinity_PPT" });
            }

            //MWQMSampleSalinity_PPT has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleSampleDateTime_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleSampleDateTime_Local), new[] { "MWQMSampleSampleDateTime_Local" });
            }

            //MWQMSampleSampleDateTime_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleSampleType_old))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleSampleType_old), new[] { "MWQMSampleSampleType_old" });
            }

            //MWQMSampleSampleType_old has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleSampleType_oldText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleSampleType_oldText), new[] { "MWQMSampleSampleType_oldText" });
            }

            //MWQMSampleSampleType_oldText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleSampleTypesText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleSampleTypesText), new[] { "MWQMSampleSampleTypesText" });
            }

            //MWQMSampleSampleTypesText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleTube_0_1))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleTube_0_1), new[] { "MWQMSampleTube_0_1" });
            }

            //MWQMSampleTube_0_1 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleTube_1_0))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleTube_1_0), new[] { "MWQMSampleTube_1_0" });
            }

            //MWQMSampleTube_1_0 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleTube_10))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleTube_10), new[] { "MWQMSampleTube_10" });
            }

            //MWQMSampleTube_10 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSampleWaterTemp_C))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSampleWaterTemp_C), new[] { "MWQMSampleWaterTemp_C" });
            }

            //MWQMSampleWaterTemp_C has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSite))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSite), new[] { "MWQMSite" });
            }

            //MWQMSite has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteHasErrors), new[] { "MWQMSiteHasErrors" });
            }

            //MWQMSiteHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteLastUpdateContactTVItemID), new[] { "MWQMSiteLastUpdateContactTVItemID" });
            }

            //MWQMSiteLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteLastUpdateContactTVText), new[] { "MWQMSiteLastUpdateContactTVText" });
            }

            //MWQMSiteLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteLastUpdateDate_UTC), new[] { "MWQMSiteLastUpdateDate_UTC" });
            }

            //MWQMSiteLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteMWQMSiteDescription))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteMWQMSiteDescription), new[] { "MWQMSiteMWQMSiteDescription" });
            }

            //MWQMSiteMWQMSiteDescription has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteMWQMSiteID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteMWQMSiteID), new[] { "MWQMSiteMWQMSiteID" });
            }

            //MWQMSiteMWQMSiteID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteMWQMSiteLatestClassification))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteMWQMSiteLatestClassification), new[] { "MWQMSiteMWQMSiteLatestClassification" });
            }

            //MWQMSiteMWQMSiteLatestClassification has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteMWQMSiteLatestClassificationText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteMWQMSiteLatestClassificationText), new[] { "MWQMSiteMWQMSiteLatestClassificationText" });
            }

            //MWQMSiteMWQMSiteLatestClassificationText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteMWQMSiteNumber))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteMWQMSiteNumber), new[] { "MWQMSiteMWQMSiteNumber" });
            }

            //MWQMSiteMWQMSiteNumber has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteMWQMSiteTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteMWQMSiteTVItemID), new[] { "MWQMSiteMWQMSiteTVItemID" });
            }

            //MWQMSiteMWQMSiteTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteMWQMSiteTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteMWQMSiteTVText), new[] { "MWQMSiteMWQMSiteTVText" });
            }

            //MWQMSiteMWQMSiteTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteOrdinal))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteOrdinal), new[] { "MWQMSiteOrdinal" });
            }

            //MWQMSiteOrdinal has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteSampleFC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteSampleFC), new[] { "MWQMSiteSampleFC" });
            }

            //MWQMSiteSampleFC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteSampleFCDepth))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteSampleFCDepth), new[] { "MWQMSiteSampleFCDepth" });
            }

            //MWQMSiteSampleFCDepth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteSampleFCDO))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteSampleFCDO), new[] { "MWQMSiteSampleFCDO" });
            }

            //MWQMSiteSampleFCDO has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteSampleFCError))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteSampleFCError), new[] { "MWQMSiteSampleFCError" });
            }

            //MWQMSiteSampleFCError has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteSampleFCFC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteSampleFCFC), new[] { "MWQMSiteSampleFCFC" });
            }

            //MWQMSiteSampleFCFC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteSampleFCGeoMean))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteSampleFCGeoMean), new[] { "MWQMSiteSampleFCGeoMean" });
            }

            //MWQMSiteSampleFCGeoMean has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteSampleFCHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteSampleFCHasErrors), new[] { "MWQMSiteSampleFCHasErrors" });
            }

            //MWQMSiteSampleFCHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteSampleFCMaxFC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteSampleFCMaxFC), new[] { "MWQMSiteSampleFCMaxFC" });
            }

            //MWQMSiteSampleFCMaxFC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteSampleFCMedian))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteSampleFCMedian), new[] { "MWQMSiteSampleFCMedian" });
            }

            //MWQMSiteSampleFCMedian has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteSampleFCMinFC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteSampleFCMinFC), new[] { "MWQMSiteSampleFCMinFC" });
            }

            //MWQMSiteSampleFCMinFC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteSampleFCP90))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteSampleFCP90), new[] { "MWQMSiteSampleFCP90" });
            }

            //MWQMSiteSampleFCP90 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteSampleFCPercOver260))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteSampleFCPercOver260), new[] { "MWQMSiteSampleFCPercOver260" });
            }

            //MWQMSiteSampleFCPercOver260 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteSampleFCPercOver43))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteSampleFCPercOver43), new[] { "MWQMSiteSampleFCPercOver43" });
            }

            //MWQMSiteSampleFCPercOver43 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteSampleFCPH))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteSampleFCPH), new[] { "MWQMSiteSampleFCPH" });
            }

            //MWQMSiteSampleFCPH has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteSampleFCSal))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteSampleFCSal), new[] { "MWQMSiteSampleFCSal" });
            }

            //MWQMSiteSampleFCSal has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteSampleFCSampCount))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteSampleFCSampCount), new[] { "MWQMSiteSampleFCSampCount" });
            }

            //MWQMSiteSampleFCSampCount has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteSampleFCSampleDate))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteSampleFCSampleDate), new[] { "MWQMSiteSampleFCSampleDate" });
            }

            //MWQMSiteSampleFCSampleDate has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteSampleFCTemp))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteSampleFCTemp), new[] { "MWQMSiteSampleFCTemp" });
            }

            //MWQMSiteSampleFCTemp has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteStartEndDate))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteStartEndDate), new[] { "MWQMSiteStartEndDate" });
            }

            //MWQMSiteStartEndDate has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteStartEndDateEndDate))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteStartEndDateEndDate), new[] { "MWQMSiteStartEndDateEndDate" });
            }

            //MWQMSiteStartEndDateEndDate has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteStartEndDateHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteStartEndDateHasErrors), new[] { "MWQMSiteStartEndDateHasErrors" });
            }

            //MWQMSiteStartEndDateHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteStartEndDateLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteStartEndDateLastUpdateContactTVItemID), new[] { "MWQMSiteStartEndDateLastUpdateContactTVItemID" });
            }

            //MWQMSiteStartEndDateLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteStartEndDateLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteStartEndDateLastUpdateContactTVText), new[] { "MWQMSiteStartEndDateLastUpdateContactTVText" });
            }

            //MWQMSiteStartEndDateLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteStartEndDateLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteStartEndDateLastUpdateDate_UTC), new[] { "MWQMSiteStartEndDateLastUpdateDate_UTC" });
            }

            //MWQMSiteStartEndDateLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteStartEndDateMWQMSiteStartEndDateID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteStartEndDateMWQMSiteStartEndDateID), new[] { "MWQMSiteStartEndDateMWQMSiteStartEndDateID" });
            }

            //MWQMSiteStartEndDateMWQMSiteStartEndDateID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteStartEndDateMWQMSiteTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteStartEndDateMWQMSiteTVItemID), new[] { "MWQMSiteStartEndDateMWQMSiteTVItemID" });
            }

            //MWQMSiteStartEndDateMWQMSiteTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteStartEndDateMWQMSiteTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteStartEndDateMWQMSiteTVText), new[] { "MWQMSiteStartEndDateMWQMSiteTVText" });
            }

            //MWQMSiteStartEndDateMWQMSiteTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSiteStartEndDateStartDate))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSiteStartEndDateStartDate), new[] { "MWQMSiteStartEndDateStartDate" });
            }

            //MWQMSiteStartEndDateStartDate has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSubsector))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSubsector), new[] { "MWQMSubsector" });
            }

            //MWQMSubsector has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSubsectorHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSubsectorHasErrors), new[] { "MWQMSubsectorHasErrors" });
            }

            //MWQMSubsectorHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSubsectorLanguage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSubsectorLanguage), new[] { "MWQMSubsectorLanguage" });
            }

            //MWQMSubsectorLanguage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSubsectorLanguageHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSubsectorLanguageHasErrors), new[] { "MWQMSubsectorLanguageHasErrors" });
            }

            //MWQMSubsectorLanguageHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSubsectorLanguageLanguage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSubsectorLanguageLanguage), new[] { "MWQMSubsectorLanguageLanguage" });
            }

            //MWQMSubsectorLanguageLanguage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSubsectorLanguageLanguageText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSubsectorLanguageLanguageText), new[] { "MWQMSubsectorLanguageLanguageText" });
            }

            //MWQMSubsectorLanguageLanguageText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSubsectorLanguageLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSubsectorLanguageLastUpdateContactTVItemID), new[] { "MWQMSubsectorLanguageLastUpdateContactTVItemID" });
            }

            //MWQMSubsectorLanguageLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSubsectorLanguageLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSubsectorLanguageLastUpdateContactTVText), new[] { "MWQMSubsectorLanguageLastUpdateContactTVText" });
            }

            //MWQMSubsectorLanguageLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSubsectorLanguageLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSubsectorLanguageLastUpdateDate_UTC), new[] { "MWQMSubsectorLanguageLastUpdateDate_UTC" });
            }

            //MWQMSubsectorLanguageLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSubsectorLanguageLogBook))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSubsectorLanguageLogBook), new[] { "MWQMSubsectorLanguageLogBook" });
            }

            //MWQMSubsectorLanguageLogBook has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSubsectorLanguageMWQMSubsectorID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSubsectorLanguageMWQMSubsectorID), new[] { "MWQMSubsectorLanguageMWQMSubsectorID" });
            }

            //MWQMSubsectorLanguageMWQMSubsectorID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSubsectorLanguageMWQMSubsectorLanguageID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSubsectorLanguageMWQMSubsectorLanguageID), new[] { "MWQMSubsectorLanguageMWQMSubsectorLanguageID" });
            }

            //MWQMSubsectorLanguageMWQMSubsectorLanguageID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSubsectorLanguageSubsectorDesc))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSubsectorLanguageSubsectorDesc), new[] { "MWQMSubsectorLanguageSubsectorDesc" });
            }

            //MWQMSubsectorLanguageSubsectorDesc has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSubsectorLanguageTranslationStatusLogBook))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSubsectorLanguageTranslationStatusLogBook), new[] { "MWQMSubsectorLanguageTranslationStatusLogBook" });
            }

            //MWQMSubsectorLanguageTranslationStatusLogBook has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSubsectorLanguageTranslationStatusLogBookText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSubsectorLanguageTranslationStatusLogBookText), new[] { "MWQMSubsectorLanguageTranslationStatusLogBookText" });
            }

            //MWQMSubsectorLanguageTranslationStatusLogBookText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSubsectorLanguageTranslationStatusSubsectorDesc))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSubsectorLanguageTranslationStatusSubsectorDesc), new[] { "MWQMSubsectorLanguageTranslationStatusSubsectorDesc" });
            }

            //MWQMSubsectorLanguageTranslationStatusSubsectorDesc has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSubsectorLanguageTranslationStatusSubsectorDescText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSubsectorLanguageTranslationStatusSubsectorDescText), new[] { "MWQMSubsectorLanguageTranslationStatusSubsectorDescText" });
            }

            //MWQMSubsectorLanguageTranslationStatusSubsectorDescText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSubsectorLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSubsectorLastUpdateContactTVItemID), new[] { "MWQMSubsectorLastUpdateContactTVItemID" });
            }

            //MWQMSubsectorLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSubsectorLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSubsectorLastUpdateContactTVText), new[] { "MWQMSubsectorLastUpdateContactTVText" });
            }

            //MWQMSubsectorLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSubsectorLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSubsectorLastUpdateDate_UTC), new[] { "MWQMSubsectorLastUpdateDate_UTC" });
            }

            //MWQMSubsectorLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSubsectorMWQMSubsectorID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSubsectorMWQMSubsectorID), new[] { "MWQMSubsectorMWQMSubsectorID" });
            }

            //MWQMSubsectorMWQMSubsectorID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSubsectorMWQMSubsectorTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSubsectorMWQMSubsectorTVItemID), new[] { "MWQMSubsectorMWQMSubsectorTVItemID" });
            }

            //MWQMSubsectorMWQMSubsectorTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSubsectorSubsectorHistoricKey))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSubsectorSubsectorHistoricKey), new[] { "MWQMSubsectorSubsectorHistoricKey" });
            }

            //MWQMSubsectorSubsectorHistoricKey has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSubsectorSubsectorTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSubsectorSubsectorTVText), new[] { "MWQMSubsectorSubsectorTVText" });
            }

            //MWQMSubsectorSubsectorTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.MWQMSubsectorTideLocationSIDText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResMWQMSubsectorTideLocationSIDText), new[] { "MWQMSubsectorTideLocationSIDText" });
            }

            //MWQMSubsectorTideLocationSIDText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.NewContact))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResNewContact), new[] { "NewContact" });
            }

            //NewContact has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.NewContactContactTitle))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResNewContactContactTitle), new[] { "NewContactContactTitle" });
            }

            //NewContactContactTitle has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.NewContactContactTitleText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResNewContactContactTitleText), new[] { "NewContactContactTitleText" });
            }

            //NewContactContactTitleText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.NewContactFirstName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResNewContactFirstName), new[] { "NewContactFirstName" });
            }

            //NewContactFirstName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.NewContactHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResNewContactHasErrors), new[] { "NewContactHasErrors" });
            }

            //NewContactHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.NewContactInitial))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResNewContactInitial), new[] { "NewContactInitial" });
            }

            //NewContactInitial has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.NewContactLastName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResNewContactLastName), new[] { "NewContactLastName" });
            }

            //NewContactLastName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.NewContactLoginEmail))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResNewContactLoginEmail), new[] { "NewContactLoginEmail" });
            }

            //NewContactLoginEmail has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.Node))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResNode), new[] { "Node" });
            }

            //Node has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.NodeCode))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResNodeCode), new[] { "NodeCode" });
            }

            //NodeCode has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.NodeConnectNodeList))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResNodeConnectNodeList), new[] { "NodeConnectNodeList" });
            }

            //NodeConnectNodeList has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.NodeElementList))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResNodeElementList), new[] { "NodeElementList" });
            }

            //NodeElementList has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.NodeHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResNodeHasErrors), new[] { "NodeHasErrors" });
            }

            //NodeHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.NodeID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResNodeID), new[] { "NodeID" });
            }

            //NodeID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.NodeLayer))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResNodeLayer), new[] { "NodeLayer" });
            }

            //NodeLayer has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.NodeLayerHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResNodeLayerHasErrors), new[] { "NodeLayerHasErrors" });
            }

            //NodeLayerHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.NodeLayerLayer))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResNodeLayerLayer), new[] { "NodeLayerLayer" });
            }

            //NodeLayerLayer has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.NodeLayerNode))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResNodeLayerNode), new[] { "NodeLayerNode" });
            }

            //NodeLayerNode has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.NodeLayerZ))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResNodeLayerZ), new[] { "NodeLayerZ" });
            }

            //NodeLayerZ has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.NodeValue))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResNodeValue), new[] { "NodeValue" });
            }

            //NodeValue has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.NodeX))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResNodeX), new[] { "NodeX" });
            }

            //NodeX has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.NodeY))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResNodeY), new[] { "NodeY" });
            }

            //NodeY has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.NodeZ))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResNodeZ), new[] { "NodeZ" });
            }

            //NodeZ has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.OtherFilesToUpload))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResOtherFilesToUpload), new[] { "OtherFilesToUpload" });
            }

            //OtherFilesToUpload has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.OtherFilesToUploadError))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResOtherFilesToUploadError), new[] { "OtherFilesToUploadError" });
            }

            //OtherFilesToUploadError has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.OtherFilesToUploadHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResOtherFilesToUploadHasErrors), new[] { "OtherFilesToUploadHasErrors" });
            }

            //OtherFilesToUploadHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.OtherFilesToUploadMikeScenarioID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResOtherFilesToUploadMikeScenarioID), new[] { "OtherFilesToUploadMikeScenarioID" });
            }

            //OtherFilesToUploadMikeScenarioID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.OtherFilesToUploadTVFileList))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResOtherFilesToUploadTVFileList), new[] { "OtherFilesToUploadTVFileList" });
            }

            //OtherFilesToUploadTVFileList has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceInactiveReasonEnumTextAndID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceInactiveReasonEnumTextAndID), new[] { "PolSourceInactiveReasonEnumTextAndID" });
            }

            //PolSourceInactiveReasonEnumTextAndID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceInactiveReasonEnumTextAndIDHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceInactiveReasonEnumTextAndIDHasErrors), new[] { "PolSourceInactiveReasonEnumTextAndIDHasErrors" });
            }

            //PolSourceInactiveReasonEnumTextAndIDHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceInactiveReasonEnumTextAndIDID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceInactiveReasonEnumTextAndIDID), new[] { "PolSourceInactiveReasonEnumTextAndIDID" });
            }

            //PolSourceInactiveReasonEnumTextAndIDID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceInactiveReasonEnumTextAndIDText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceInactiveReasonEnumTextAndIDText), new[] { "PolSourceInactiveReasonEnumTextAndIDText" });
            }

            //PolSourceInactiveReasonEnumTextAndIDText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObservation))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObservation), new[] { "PolSourceObservation" });
            }

            //PolSourceObservation has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObservationContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObservationContactTVItemID), new[] { "PolSourceObservationContactTVItemID" });
            }

            //PolSourceObservationContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObservationContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObservationContactTVText), new[] { "PolSourceObservationContactTVText" });
            }

            //PolSourceObservationContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObservationHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObservationHasErrors), new[] { "PolSourceObservationHasErrors" });
            }

            //PolSourceObservationHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObservationIssue))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObservationIssue), new[] { "PolSourceObservationIssue" });
            }

            //PolSourceObservationIssue has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObservationIssueHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObservationIssueHasErrors), new[] { "PolSourceObservationIssueHasErrors" });
            }

            //PolSourceObservationIssueHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObservationIssueLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObservationIssueLastUpdateContactTVItemID), new[] { "PolSourceObservationIssueLastUpdateContactTVItemID" });
            }

            //PolSourceObservationIssueLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObservationIssueLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObservationIssueLastUpdateContactTVText), new[] { "PolSourceObservationIssueLastUpdateContactTVText" });
            }

            //PolSourceObservationIssueLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObservationIssueLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObservationIssueLastUpdateDate_UTC), new[] { "PolSourceObservationIssueLastUpdateDate_UTC" });
            }

            //PolSourceObservationIssueLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObservationIssueObservationInfo))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObservationIssueObservationInfo), new[] { "PolSourceObservationIssueObservationInfo" });
            }

            //PolSourceObservationIssueObservationInfo has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObservationIssueOrdinal))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObservationIssueOrdinal), new[] { "PolSourceObservationIssueOrdinal" });
            }

            //PolSourceObservationIssueOrdinal has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObservationIssuePolSourceObservationID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObservationIssuePolSourceObservationID), new[] { "PolSourceObservationIssuePolSourceObservationID" });
            }

            //PolSourceObservationIssuePolSourceObservationID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObservationIssuePolSourceObservationIssueID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObservationIssuePolSourceObservationIssueID), new[] { "PolSourceObservationIssuePolSourceObservationIssueID" });
            }

            //PolSourceObservationIssuePolSourceObservationIssueID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObservationLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObservationLastUpdateContactTVItemID), new[] { "PolSourceObservationLastUpdateContactTVItemID" });
            }

            //PolSourceObservationLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObservationLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObservationLastUpdateContactTVText), new[] { "PolSourceObservationLastUpdateContactTVText" });
            }

            //PolSourceObservationLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObservationLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObservationLastUpdateDate_UTC), new[] { "PolSourceObservationLastUpdateDate_UTC" });
            }

            //PolSourceObservationLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObservationObservation_ToBeDeleted))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObservationObservation_ToBeDeleted), new[] { "PolSourceObservationObservation_ToBeDeleted" });
            }

            //PolSourceObservationObservation_ToBeDeleted has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObservationObservationDate_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObservationObservationDate_Local), new[] { "PolSourceObservationObservationDate_Local" });
            }

            //PolSourceObservationObservationDate_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObservationPolSourceObservationID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObservationPolSourceObservationID), new[] { "PolSourceObservationPolSourceObservationID" });
            }

            //PolSourceObservationPolSourceObservationID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObservationPolSourceSiteID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObservationPolSourceSiteID), new[] { "PolSourceObservationPolSourceSiteID" });
            }

            //PolSourceObservationPolSourceSiteID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObservationPolSourceSiteTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObservationPolSourceSiteTVText), new[] { "PolSourceObservationPolSourceSiteTVText" });
            }

            //PolSourceObservationPolSourceSiteTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObsInfoChild))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObsInfoChild), new[] { "PolSourceObsInfoChild" });
            }

            //PolSourceObsInfoChild has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObsInfoChildHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObsInfoChildHasErrors), new[] { "PolSourceObsInfoChildHasErrors" });
            }

            //PolSourceObsInfoChildHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObsInfoChildPolSourceObsInfo))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObsInfoChildPolSourceObsInfo), new[] { "PolSourceObsInfoChildPolSourceObsInfo" });
            }

            //PolSourceObsInfoChildPolSourceObsInfo has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObsInfoChildPolSourceObsInfoChildStart))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObsInfoChildPolSourceObsInfoChildStart), new[] { "PolSourceObsInfoChildPolSourceObsInfoChildStart" });
            }

            //PolSourceObsInfoChildPolSourceObsInfoChildStart has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObsInfoChildPolSourceObsInfoChildStartText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObsInfoChildPolSourceObsInfoChildStartText), new[] { "PolSourceObsInfoChildPolSourceObsInfoChildStartText" });
            }

            //PolSourceObsInfoChildPolSourceObsInfoChildStartText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObsInfoChildPolSourceObsInfoText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObsInfoChildPolSourceObsInfoText), new[] { "PolSourceObsInfoChildPolSourceObsInfoText" });
            }

            //PolSourceObsInfoChildPolSourceObsInfoText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObsInfoEnumTextAndID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObsInfoEnumTextAndID), new[] { "PolSourceObsInfoEnumTextAndID" });
            }

            //PolSourceObsInfoEnumTextAndID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObsInfoEnumTextAndIDHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObsInfoEnumTextAndIDHasErrors), new[] { "PolSourceObsInfoEnumTextAndIDHasErrors" });
            }

            //PolSourceObsInfoEnumTextAndIDHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObsInfoEnumTextAndIDID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObsInfoEnumTextAndIDID), new[] { "PolSourceObsInfoEnumTextAndIDID" });
            }

            //PolSourceObsInfoEnumTextAndIDID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceObsInfoEnumTextAndIDText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceObsInfoEnumTextAndIDText), new[] { "PolSourceObsInfoEnumTextAndIDText" });
            }

            //PolSourceObsInfoEnumTextAndIDText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceSite))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceSite), new[] { "PolSourceSite" });
            }

            //PolSourceSite has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceSiteCivicAddressTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceSiteCivicAddressTVItemID), new[] { "PolSourceSiteCivicAddressTVItemID" });
            }

            //PolSourceSiteCivicAddressTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceSiteHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceSiteHasErrors), new[] { "PolSourceSiteHasErrors" });
            }

            //PolSourceSiteHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceSiteInactiveReason))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceSiteInactiveReason), new[] { "PolSourceSiteInactiveReason" });
            }

            //PolSourceSiteInactiveReason has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceSiteInactiveReasonText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceSiteInactiveReasonText), new[] { "PolSourceSiteInactiveReasonText" });
            }

            //PolSourceSiteInactiveReasonText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceSiteIsPointSource))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceSiteIsPointSource), new[] { "PolSourceSiteIsPointSource" });
            }

            //PolSourceSiteIsPointSource has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceSiteLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceSiteLastUpdateContactTVItemID), new[] { "PolSourceSiteLastUpdateContactTVItemID" });
            }

            //PolSourceSiteLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceSiteLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceSiteLastUpdateContactTVText), new[] { "PolSourceSiteLastUpdateContactTVText" });
            }

            //PolSourceSiteLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceSiteLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceSiteLastUpdateDate_UTC), new[] { "PolSourceSiteLastUpdateDate_UTC" });
            }

            //PolSourceSiteLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceSiteOldsiteid))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceSiteOldsiteid), new[] { "PolSourceSiteOldsiteid" });
            }

            //PolSourceSiteOldsiteid has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceSitePolSourceSiteID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceSitePolSourceSiteID), new[] { "PolSourceSitePolSourceSiteID" });
            }

            //PolSourceSitePolSourceSiteID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceSitePolSourceSiteTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceSitePolSourceSiteTVItemID), new[] { "PolSourceSitePolSourceSiteTVItemID" });
            }

            //PolSourceSitePolSourceSiteTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceSitePolSourceSiteTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceSitePolSourceSiteTVText), new[] { "PolSourceSitePolSourceSiteTVText" });
            }

            //PolSourceSitePolSourceSiteTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceSiteSite))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceSiteSite), new[] { "PolSourceSiteSite" });
            }

            //PolSourceSiteSite has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceSiteSiteID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceSiteSiteID), new[] { "PolSourceSiteSiteID" });
            }

            //PolSourceSiteSiteID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolSourceSiteTemp_Locator_CanDelete))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolSourceSiteTemp_Locator_CanDelete), new[] { "PolSourceSiteTemp_Locator_CanDelete" });
            }

            //PolSourceSiteTemp_Locator_CanDelete has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolyPoint))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolyPoint), new[] { "PolyPoint" });
            }

            //PolyPoint has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolyPointHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolyPointHasErrors), new[] { "PolyPointHasErrors" });
            }

            //PolyPointHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolyPointXCoord))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolyPointXCoord), new[] { "PolyPointXCoord" });
            }

            //PolyPointXCoord has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolyPointYCoord))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolyPointYCoord), new[] { "PolyPointYCoord" });
            }

            //PolyPointYCoord has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.PolyPointZ))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResPolyPointZ), new[] { "PolyPointZ" });
            }

            //PolyPointZ has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RainExceedance))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRainExceedance), new[] { "RainExceedance" });
            }

            //RainExceedance has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RainExceedanceClimateSiteTVItemIDs))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRainExceedanceClimateSiteTVItemIDs), new[] { "RainExceedanceClimateSiteTVItemIDs" });
            }

            //RainExceedanceClimateSiteTVItemIDs has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RainExceedanceDaysPriorToStart))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRainExceedanceDaysPriorToStart), new[] { "RainExceedanceDaysPriorToStart" });
            }

            //RainExceedanceDaysPriorToStart has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RainExceedanceEmailDistributionListIDs))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRainExceedanceEmailDistributionListIDs), new[] { "RainExceedanceEmailDistributionListIDs" });
            }

            //RainExceedanceEmailDistributionListIDs has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RainExceedanceEndDate_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRainExceedanceEndDate_Local), new[] { "RainExceedanceEndDate_Local" });
            }

            //RainExceedanceEndDate_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RainExceedanceHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRainExceedanceHasErrors), new[] { "RainExceedanceHasErrors" });
            }

            //RainExceedanceHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RainExceedanceLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRainExceedanceLastUpdateContactTVItemID), new[] { "RainExceedanceLastUpdateContactTVItemID" });
            }

            //RainExceedanceLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RainExceedanceLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRainExceedanceLastUpdateContactTVText), new[] { "RainExceedanceLastUpdateContactTVText" });
            }

            //RainExceedanceLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RainExceedanceLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRainExceedanceLastUpdateDate_UTC), new[] { "RainExceedanceLastUpdateDate_UTC" });
            }

            //RainExceedanceLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RainExceedanceProvinceTVItemIDs))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRainExceedanceProvinceTVItemIDs), new[] { "RainExceedanceProvinceTVItemIDs" });
            }

            //RainExceedanceProvinceTVItemIDs has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RainExceedanceRainExceedanceID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRainExceedanceRainExceedanceID), new[] { "RainExceedanceRainExceedanceID" });
            }

            //RainExceedanceRainExceedanceID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RainExceedanceRainExtreme_mm))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRainExceedanceRainExtreme_mm), new[] { "RainExceedanceRainExtreme_mm" });
            }

            //RainExceedanceRainExtreme_mm has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RainExceedanceRainMaximum_mm))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRainExceedanceRainMaximum_mm), new[] { "RainExceedanceRainMaximum_mm" });
            }

            //RainExceedanceRainMaximum_mm has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RainExceedanceRepeatEveryYear))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRainExceedanceRepeatEveryYear), new[] { "RainExceedanceRepeatEveryYear" });
            }

            //RainExceedanceRepeatEveryYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RainExceedanceStartDate_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRainExceedanceStartDate_Local), new[] { "RainExceedanceStartDate_Local" });
            }

            //RainExceedanceStartDate_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RainExceedanceSubsectorTVItemIDs))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRainExceedanceSubsectorTVItemIDs), new[] { "RainExceedanceSubsectorTVItemIDs" });
            }

            //RainExceedanceSubsectorTVItemIDs has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RainExceedanceYearRound))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRainExceedanceYearRound), new[] { "RainExceedanceYearRound" });
            }

            //RainExceedanceYearRound has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RatingCurve))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRatingCurve), new[] { "RatingCurve" });
            }

            //RatingCurve has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RatingCurveHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRatingCurveHasErrors), new[] { "RatingCurveHasErrors" });
            }

            //RatingCurveHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RatingCurveHydrometricSiteID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRatingCurveHydrometricSiteID), new[] { "RatingCurveHydrometricSiteID" });
            }

            //RatingCurveHydrometricSiteID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RatingCurveLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRatingCurveLastUpdateContactTVItemID), new[] { "RatingCurveLastUpdateContactTVItemID" });
            }

            //RatingCurveLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RatingCurveLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRatingCurveLastUpdateContactTVText), new[] { "RatingCurveLastUpdateContactTVText" });
            }

            //RatingCurveLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RatingCurveLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRatingCurveLastUpdateDate_UTC), new[] { "RatingCurveLastUpdateDate_UTC" });
            }

            //RatingCurveLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RatingCurveRatingCurveID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRatingCurveRatingCurveID), new[] { "RatingCurveRatingCurveID" });
            }

            //RatingCurveRatingCurveID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RatingCurveRatingCurveNumber))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRatingCurveRatingCurveNumber), new[] { "RatingCurveRatingCurveNumber" });
            }

            //RatingCurveRatingCurveNumber has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RatingCurveValue))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRatingCurveValue), new[] { "RatingCurveValue" });
            }

            //RatingCurveValue has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RatingCurveValueDischargeValue_m3_s))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRatingCurveValueDischargeValue_m3_s), new[] { "RatingCurveValueDischargeValue_m3_s" });
            }

            //RatingCurveValueDischargeValue_m3_s has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RatingCurveValueHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRatingCurveValueHasErrors), new[] { "RatingCurveValueHasErrors" });
            }

            //RatingCurveValueHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RatingCurveValueLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRatingCurveValueLastUpdateContactTVItemID), new[] { "RatingCurveValueLastUpdateContactTVItemID" });
            }

            //RatingCurveValueLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RatingCurveValueLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRatingCurveValueLastUpdateContactTVText), new[] { "RatingCurveValueLastUpdateContactTVText" });
            }

            //RatingCurveValueLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RatingCurveValueLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRatingCurveValueLastUpdateDate_UTC), new[] { "RatingCurveValueLastUpdateDate_UTC" });
            }

            //RatingCurveValueLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RatingCurveValueRatingCurveID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRatingCurveValueRatingCurveID), new[] { "RatingCurveValueRatingCurveID" });
            }

            //RatingCurveValueRatingCurveID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RatingCurveValueRatingCurveValueID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRatingCurveValueRatingCurveValueID), new[] { "RatingCurveValueRatingCurveValueID" });
            }

            //RatingCurveValueRatingCurveValueID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RatingCurveValueStageValue_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRatingCurveValueStageValue_m), new[] { "RatingCurveValueStageValue_m" });
            }

            //RatingCurveValueStageValue_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.Register))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRegister), new[] { "Register" });
            }

            //Register has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RegisterConfirmPassword))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRegisterConfirmPassword), new[] { "RegisterConfirmPassword" });
            }

            //RegisterConfirmPassword has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RegisterFirstName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRegisterFirstName), new[] { "RegisterFirstName" });
            }

            //RegisterFirstName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RegisterHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRegisterHasErrors), new[] { "RegisterHasErrors" });
            }

            //RegisterHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RegisterInitial))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRegisterInitial), new[] { "RegisterInitial" });
            }

            //RegisterInitial has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RegisterLastName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRegisterLastName), new[] { "RegisterLastName" });
            }

            //RegisterLastName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RegisterLoginEmail))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRegisterLoginEmail), new[] { "RegisterLoginEmail" });
            }

            //RegisterLoginEmail has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RegisterPassword))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRegisterPassword), new[] { "RegisterPassword" });
            }

            //RegisterPassword has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RegisterWebName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRegisterWebName), new[] { "RegisterWebName" });
            }

            //RegisterWebName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ResetPassword))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResResetPassword), new[] { "ResetPassword" });
            }

            //ResetPassword has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ResetPasswordCode))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResResetPasswordCode), new[] { "ResetPasswordCode" });
            }

            //ResetPasswordCode has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ResetPasswordConfirmPassword))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResResetPasswordConfirmPassword), new[] { "ResetPasswordConfirmPassword" });
            }

            //ResetPasswordConfirmPassword has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ResetPasswordEmail))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResResetPasswordEmail), new[] { "ResetPasswordEmail" });
            }

            //ResetPasswordEmail has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ResetPasswordExpireDate_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResResetPasswordExpireDate_Local), new[] { "ResetPasswordExpireDate_Local" });
            }

            //ResetPasswordExpireDate_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ResetPasswordHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResResetPasswordHasErrors), new[] { "ResetPasswordHasErrors" });
            }

            //ResetPasswordHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ResetPasswordLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResResetPasswordLastUpdateContactTVItemID), new[] { "ResetPasswordLastUpdateContactTVItemID" });
            }

            //ResetPasswordLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ResetPasswordLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResResetPasswordLastUpdateContactTVText), new[] { "ResetPasswordLastUpdateContactTVText" });
            }

            //ResetPasswordLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ResetPasswordLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResResetPasswordLastUpdateDate_UTC), new[] { "ResetPasswordLastUpdateDate_UTC" });
            }

            //ResetPasswordLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ResetPasswordPassword))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResResetPasswordPassword), new[] { "ResetPasswordPassword" });
            }

            //ResetPasswordPassword has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.ResetPasswordResetPasswordID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResResetPasswordResetPasswordID), new[] { "ResetPasswordResetPasswordID" });
            }

            //ResetPasswordResetPasswordID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RTBStringPos))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRTBStringPos), new[] { "RTBStringPos" });
            }

            //RTBStringPos has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RTBStringPosEndPos))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRTBStringPosEndPos), new[] { "RTBStringPosEndPos" });
            }

            //RTBStringPosEndPos has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RTBStringPosHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRTBStringPosHasErrors), new[] { "RTBStringPosHasErrors" });
            }

            //RTBStringPosHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RTBStringPosStartPos))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRTBStringPosStartPos), new[] { "RTBStringPosStartPos" });
            }

            //RTBStringPosStartPos has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RTBStringPosTagText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRTBStringPosTagText), new[] { "RTBStringPosTagText" });
            }

            //RTBStringPosTagText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.RTBStringPosText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResRTBStringPosText), new[] { "RTBStringPosText" });
            }

            //RTBStringPosText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlan))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlan), new[] { "SamplingPlan" });
            }

            //SamplingPlan has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanAccessCode))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanAccessCode), new[] { "SamplingPlanAccessCode" });
            }

            //SamplingPlanAccessCode has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanAndFilesLabSheetCount))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanAndFilesLabSheetCount), new[] { "SamplingPlanAndFilesLabSheetCount" });
            }

            //SamplingPlanAndFilesLabSheetCount has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanAndFilesLabSheetCountHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanAndFilesLabSheetCountHasErrors), new[] { "SamplingPlanAndFilesLabSheetCountHasErrors" });
            }

            //SamplingPlanAndFilesLabSheetCountHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanAndFilesLabSheetCountLabSheetHistoryCount))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanAndFilesLabSheetCountLabSheetHistoryCount), new[] { "SamplingPlanAndFilesLabSheetCountLabSheetHistoryCount" });
            }

            //SamplingPlanAndFilesLabSheetCountLabSheetHistoryCount has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanAndFilesLabSheetCountLabSheetTransferredCount))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanAndFilesLabSheetCountLabSheetTransferredCount), new[] { "SamplingPlanAndFilesLabSheetCountLabSheetTransferredCount" });
            }

            //SamplingPlanAndFilesLabSheetCountLabSheetTransferredCount has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanAndFilesLabSheetCountSamplingPlan))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanAndFilesLabSheetCountSamplingPlan), new[] { "SamplingPlanAndFilesLabSheetCountSamplingPlan" });
            }

            //SamplingPlanAndFilesLabSheetCountSamplingPlan has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanAndFilesLabSheetCountTVFileSamplingPlanFileTXT))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanAndFilesLabSheetCountTVFileSamplingPlanFileTXT), new[] { "SamplingPlanAndFilesLabSheetCountTVFileSamplingPlanFileTXT" });
            }

            //SamplingPlanAndFilesLabSheetCountTVFileSamplingPlanFileTXT has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanApprovalCode))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanApprovalCode), new[] { "SamplingPlanApprovalCode" });
            }

            //SamplingPlanApprovalCode has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanCreatorTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanCreatorTVItemID), new[] { "SamplingPlanCreatorTVItemID" });
            }

            //SamplingPlanCreatorTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanCreatorTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanCreatorTVText), new[] { "SamplingPlanCreatorTVText" });
            }

            //SamplingPlanCreatorTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanDailyDuplicatePrecisionCriteria))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanDailyDuplicatePrecisionCriteria), new[] { "SamplingPlanDailyDuplicatePrecisionCriteria" });
            }

            //SamplingPlanDailyDuplicatePrecisionCriteria has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanForGroupName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanForGroupName), new[] { "SamplingPlanForGroupName" });
            }

            //SamplingPlanForGroupName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanHasErrors), new[] { "SamplingPlanHasErrors" });
            }

            //SamplingPlanHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanIncludeLaboratoryQAQC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanIncludeLaboratoryQAQC), new[] { "SamplingPlanIncludeLaboratoryQAQC" });
            }

            //SamplingPlanIncludeLaboratoryQAQC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanIntertechDuplicatePrecisionCriteria))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanIntertechDuplicatePrecisionCriteria), new[] { "SamplingPlanIntertechDuplicatePrecisionCriteria" });
            }

            //SamplingPlanIntertechDuplicatePrecisionCriteria has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanLabSheetType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanLabSheetType), new[] { "SamplingPlanLabSheetType" });
            }

            //SamplingPlanLabSheetType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanLabSheetTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanLabSheetTypeText), new[] { "SamplingPlanLabSheetTypeText" });
            }

            //SamplingPlanLabSheetTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanLastUpdateContactTVItemID), new[] { "SamplingPlanLastUpdateContactTVItemID" });
            }

            //SamplingPlanLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanLastUpdateContactTVText), new[] { "SamplingPlanLastUpdateContactTVText" });
            }

            //SamplingPlanLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanLastUpdateDate_UTC), new[] { "SamplingPlanLastUpdateDate_UTC" });
            }

            //SamplingPlanLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanProvinceTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanProvinceTVItemID), new[] { "SamplingPlanProvinceTVItemID" });
            }

            //SamplingPlanProvinceTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanProvinceTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanProvinceTVText), new[] { "SamplingPlanProvinceTVText" });
            }

            //SamplingPlanProvinceTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanSampleType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanSampleType), new[] { "SamplingPlanSampleType" });
            }

            //SamplingPlanSampleType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanSampleTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanSampleTypeText), new[] { "SamplingPlanSampleTypeText" });
            }

            //SamplingPlanSampleTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanSamplingPlanFileTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanSamplingPlanFileTVItemID), new[] { "SamplingPlanSamplingPlanFileTVItemID" });
            }

            //SamplingPlanSamplingPlanFileTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanSamplingPlanFileTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanSamplingPlanFileTVText), new[] { "SamplingPlanSamplingPlanFileTVText" });
            }

            //SamplingPlanSamplingPlanFileTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanSamplingPlanID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanSamplingPlanID), new[] { "SamplingPlanSamplingPlanID" });
            }

            //SamplingPlanSamplingPlanID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanSamplingPlanName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanSamplingPlanName), new[] { "SamplingPlanSamplingPlanName" });
            }

            //SamplingPlanSamplingPlanName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanSamplingPlanType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanSamplingPlanType), new[] { "SamplingPlanSamplingPlanType" });
            }

            //SamplingPlanSamplingPlanType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanSamplingPlanTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanSamplingPlanTypeText), new[] { "SamplingPlanSamplingPlanTypeText" });
            }

            //SamplingPlanSamplingPlanTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanSubsector))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanSubsector), new[] { "SamplingPlanSubsector" });
            }

            //SamplingPlanSubsector has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanSubsectorHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanSubsectorHasErrors), new[] { "SamplingPlanSubsectorHasErrors" });
            }

            //SamplingPlanSubsectorHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanSubsectorLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanSubsectorLastUpdateContactTVItemID), new[] { "SamplingPlanSubsectorLastUpdateContactTVItemID" });
            }

            //SamplingPlanSubsectorLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanSubsectorLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanSubsectorLastUpdateContactTVText), new[] { "SamplingPlanSubsectorLastUpdateContactTVText" });
            }

            //SamplingPlanSubsectorLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanSubsectorLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanSubsectorLastUpdateDate_UTC), new[] { "SamplingPlanSubsectorLastUpdateDate_UTC" });
            }

            //SamplingPlanSubsectorLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanSubsectorSamplingPlanID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanSubsectorSamplingPlanID), new[] { "SamplingPlanSubsectorSamplingPlanID" });
            }

            //SamplingPlanSubsectorSamplingPlanID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanSubsectorSamplingPlanSubsectorID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanSubsectorSamplingPlanSubsectorID), new[] { "SamplingPlanSubsectorSamplingPlanSubsectorID" });
            }

            //SamplingPlanSubsectorSamplingPlanSubsectorID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanSubsectorSite))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanSubsectorSite), new[] { "SamplingPlanSubsectorSite" });
            }

            //SamplingPlanSubsectorSite has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanSubsectorSiteHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanSubsectorSiteHasErrors), new[] { "SamplingPlanSubsectorSiteHasErrors" });
            }

            //SamplingPlanSubsectorSiteHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanSubsectorSiteIsDuplicate))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanSubsectorSiteIsDuplicate), new[] { "SamplingPlanSubsectorSiteIsDuplicate" });
            }

            //SamplingPlanSubsectorSiteIsDuplicate has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanSubsectorSiteLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanSubsectorSiteLastUpdateContactTVItemID), new[] { "SamplingPlanSubsectorSiteLastUpdateContactTVItemID" });
            }

            //SamplingPlanSubsectorSiteLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanSubsectorSiteLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanSubsectorSiteLastUpdateContactTVText), new[] { "SamplingPlanSubsectorSiteLastUpdateContactTVText" });
            }

            //SamplingPlanSubsectorSiteLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanSubsectorSiteLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanSubsectorSiteLastUpdateDate_UTC), new[] { "SamplingPlanSubsectorSiteLastUpdateDate_UTC" });
            }

            //SamplingPlanSubsectorSiteLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanSubsectorSiteMWQMSiteTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanSubsectorSiteMWQMSiteTVItemID), new[] { "SamplingPlanSubsectorSiteMWQMSiteTVItemID" });
            }

            //SamplingPlanSubsectorSiteMWQMSiteTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanSubsectorSiteMWQMSiteTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanSubsectorSiteMWQMSiteTVText), new[] { "SamplingPlanSubsectorSiteMWQMSiteTVText" });
            }

            //SamplingPlanSubsectorSiteMWQMSiteTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanSubsectorSiteSamplingPlanSubsectorID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanSubsectorSiteSamplingPlanSubsectorID), new[] { "SamplingPlanSubsectorSiteSamplingPlanSubsectorID" });
            }

            //SamplingPlanSubsectorSiteSamplingPlanSubsectorID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanSubsectorSiteSamplingPlanSubsectorSiteID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanSubsectorSiteSamplingPlanSubsectorSiteID), new[] { "SamplingPlanSubsectorSiteSamplingPlanSubsectorSiteID" });
            }

            //SamplingPlanSubsectorSiteSamplingPlanSubsectorSiteID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanSubsectorSubsectorTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanSubsectorSubsectorTVItemID), new[] { "SamplingPlanSubsectorSubsectorTVItemID" });
            }

            //SamplingPlanSubsectorSubsectorTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanSubsectorSubsectorTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanSubsectorSubsectorTVText), new[] { "SamplingPlanSubsectorSubsectorTVText" });
            }

            //SamplingPlanSubsectorSubsectorTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SamplingPlanYear))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSamplingPlanYear), new[] { "SamplingPlanYear" });
            }

            //SamplingPlanYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.Search))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSearch), new[] { "Search" });
            }

            //Search has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SearchHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSearchHasErrors), new[] { "SearchHasErrors" });
            }

            //SearchHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.Searchid))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSearchid), new[] { "Searchid" });
            }

            //Searchid has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SearchTagAndTerms))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSearchTagAndTerms), new[] { "SearchTagAndTerms" });
            }

            //SearchTagAndTerms has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SearchTagAndTermsHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSearchTagAndTermsHasErrors), new[] { "SearchTagAndTermsHasErrors" });
            }

            //SearchTagAndTermsHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SearchTagAndTermsSearchTag))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSearchTagAndTermsSearchTag), new[] { "SearchTagAndTermsSearchTag" });
            }

            //SearchTagAndTermsSearchTag has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SearchTagAndTermsSearchTagText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSearchTagAndTermsSearchTagText), new[] { "SearchTagAndTermsSearchTagText" });
            }

            //SearchTagAndTermsSearchTagText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SearchTagAndTermsSearchTermList))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSearchTagAndTermsSearchTermList), new[] { "SearchTagAndTermsSearchTermList" });
            }

            //SearchTagAndTermsSearchTermList has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.Searchvalue))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSearchvalue), new[] { "Searchvalue" });
            }

            //Searchvalue has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.Spill))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSpill), new[] { "Spill" });
            }

            //Spill has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SpillAverageFlow_m3_day))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSpillAverageFlow_m3_day), new[] { "SpillAverageFlow_m3_day" });
            }

            //SpillAverageFlow_m3_day has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SpillEndDateTime_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSpillEndDateTime_Local), new[] { "SpillEndDateTime_Local" });
            }

            //SpillEndDateTime_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SpillHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSpillHasErrors), new[] { "SpillHasErrors" });
            }

            //SpillHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SpillInfrastructureTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSpillInfrastructureTVItemID), new[] { "SpillInfrastructureTVItemID" });
            }

            //SpillInfrastructureTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SpillInfrastructureTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSpillInfrastructureTVText), new[] { "SpillInfrastructureTVText" });
            }

            //SpillInfrastructureTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SpillLanguage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSpillLanguage), new[] { "SpillLanguage" });
            }

            //SpillLanguage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SpillLanguageHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSpillLanguageHasErrors), new[] { "SpillLanguageHasErrors" });
            }

            //SpillLanguageHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SpillLanguageLanguage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSpillLanguageLanguage), new[] { "SpillLanguageLanguage" });
            }

            //SpillLanguageLanguage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SpillLanguageLanguageText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSpillLanguageLanguageText), new[] { "SpillLanguageLanguageText" });
            }

            //SpillLanguageLanguageText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SpillLanguageLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSpillLanguageLastUpdateContactTVItemID), new[] { "SpillLanguageLastUpdateContactTVItemID" });
            }

            //SpillLanguageLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SpillLanguageLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSpillLanguageLastUpdateContactTVText), new[] { "SpillLanguageLastUpdateContactTVText" });
            }

            //SpillLanguageLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SpillLanguageLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSpillLanguageLastUpdateDate_UTC), new[] { "SpillLanguageLastUpdateDate_UTC" });
            }

            //SpillLanguageLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SpillLanguageSpillComment))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSpillLanguageSpillComment), new[] { "SpillLanguageSpillComment" });
            }

            //SpillLanguageSpillComment has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SpillLanguageSpillID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSpillLanguageSpillID), new[] { "SpillLanguageSpillID" });
            }

            //SpillLanguageSpillID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SpillLanguageSpillLanguageID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSpillLanguageSpillLanguageID), new[] { "SpillLanguageSpillLanguageID" });
            }

            //SpillLanguageSpillLanguageID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SpillLanguageTranslationStatus))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSpillLanguageTranslationStatus), new[] { "SpillLanguageTranslationStatus" });
            }

            //SpillLanguageTranslationStatus has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SpillLanguageTranslationStatusText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSpillLanguageTranslationStatusText), new[] { "SpillLanguageTranslationStatusText" });
            }

            //SpillLanguageTranslationStatusText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SpillLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSpillLastUpdateContactTVItemID), new[] { "SpillLastUpdateContactTVItemID" });
            }

            //SpillLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SpillLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSpillLastUpdateContactTVText), new[] { "SpillLastUpdateContactTVText" });
            }

            //SpillLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SpillLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSpillLastUpdateDate_UTC), new[] { "SpillLastUpdateDate_UTC" });
            }

            //SpillLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SpillMunicipalityTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSpillMunicipalityTVItemID), new[] { "SpillMunicipalityTVItemID" });
            }

            //SpillMunicipalityTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SpillMunicipalityTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSpillMunicipalityTVText), new[] { "SpillMunicipalityTVText" });
            }

            //SpillMunicipalityTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SpillSpillID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSpillSpillID), new[] { "SpillSpillID" });
            }

            //SpillSpillID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SpillStartDateTime_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSpillStartDateTime_Local), new[] { "SpillStartDateTime_Local" });
            }

            //SpillStartDateTime_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SubsectorMWQMSampleYear))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSubsectorMWQMSampleYear), new[] { "SubsectorMWQMSampleYear" });
            }

            //SubsectorMWQMSampleYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SubsectorMWQMSampleYearEarliestDate))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSubsectorMWQMSampleYearEarliestDate), new[] { "SubsectorMWQMSampleYearEarliestDate" });
            }

            //SubsectorMWQMSampleYearEarliestDate has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SubsectorMWQMSampleYearHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSubsectorMWQMSampleYearHasErrors), new[] { "SubsectorMWQMSampleYearHasErrors" });
            }

            //SubsectorMWQMSampleYearHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SubsectorMWQMSampleYearLatestDate))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSubsectorMWQMSampleYearLatestDate), new[] { "SubsectorMWQMSampleYearLatestDate" });
            }

            //SubsectorMWQMSampleYearLatestDate has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SubsectorMWQMSampleYearSubsectorTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSubsectorMWQMSampleYearSubsectorTVItemID), new[] { "SubsectorMWQMSampleYearSubsectorTVItemID" });
            }

            //SubsectorMWQMSampleYearSubsectorTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.SubsectorMWQMSampleYearYear))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResSubsectorMWQMSampleYearYear), new[] { "SubsectorMWQMSampleYearYear" });
            }

            //SubsectorMWQMSampleYearYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.Tel))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTel), new[] { "Tel" });
            }

            //Tel has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TelHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTelHasErrors), new[] { "TelHasErrors" });
            }

            //TelHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TelLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTelLastUpdateContactTVItemID), new[] { "TelLastUpdateContactTVItemID" });
            }

            //TelLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TelLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTelLastUpdateContactTVText), new[] { "TelLastUpdateContactTVText" });
            }

            //TelLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TelLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTelLastUpdateDate_UTC), new[] { "TelLastUpdateDate_UTC" });
            }

            //TelLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TelTelID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTelTelID), new[] { "TelTelID" });
            }

            //TelTelID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TelTelNumber))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTelTelNumber), new[] { "TelTelNumber" });
            }

            //TelTelNumber has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TelTelTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTelTelTVItemID), new[] { "TelTelTVItemID" });
            }

            //TelTelTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TelTelTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTelTelTVText), new[] { "TelTelTVText" });
            }

            //TelTelTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TelTelType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTelTelType), new[] { "TelTelType" });
            }

            //TelTelType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TelTelTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTelTelTypeText), new[] { "TelTelTypeText" });
            }

            //TelTelTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideDataValue))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideDataValue), new[] { "TideDataValue" });
            }

            //TideDataValue has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideDataValueDateTime_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideDataValueDateTime_Local), new[] { "TideDataValueDateTime_Local" });
            }

            //TideDataValueDateTime_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideDataValueDepth_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideDataValueDepth_m), new[] { "TideDataValueDepth_m" });
            }

            //TideDataValueDepth_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideDataValueHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideDataValueHasErrors), new[] { "TideDataValueHasErrors" });
            }

            //TideDataValueHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideDataValueKeep))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideDataValueKeep), new[] { "TideDataValueKeep" });
            }

            //TideDataValueKeep has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideDataValueLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideDataValueLastUpdateContactTVItemID), new[] { "TideDataValueLastUpdateContactTVItemID" });
            }

            //TideDataValueLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideDataValueLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideDataValueLastUpdateContactTVText), new[] { "TideDataValueLastUpdateContactTVText" });
            }

            //TideDataValueLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideDataValueLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideDataValueLastUpdateDate_UTC), new[] { "TideDataValueLastUpdateDate_UTC" });
            }

            //TideDataValueLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideDataValueStorageDataType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideDataValueStorageDataType), new[] { "TideDataValueStorageDataType" });
            }

            //TideDataValueStorageDataType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideDataValueStorageDataTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideDataValueStorageDataTypeText), new[] { "TideDataValueStorageDataTypeText" });
            }

            //TideDataValueStorageDataTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideDataValueTideDataType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideDataValueTideDataType), new[] { "TideDataValueTideDataType" });
            }

            //TideDataValueTideDataType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideDataValueTideDataTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideDataValueTideDataTypeText), new[] { "TideDataValueTideDataTypeText" });
            }

            //TideDataValueTideDataTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideDataValueTideDataValueID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideDataValueTideDataValueID), new[] { "TideDataValueTideDataValueID" });
            }

            //TideDataValueTideDataValueID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideDataValueTideEnd))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideDataValueTideEnd), new[] { "TideDataValueTideEnd" });
            }

            //TideDataValueTideEnd has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideDataValueTideEndText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideDataValueTideEndText), new[] { "TideDataValueTideEndText" });
            }

            //TideDataValueTideEndText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideDataValueTideSiteTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideDataValueTideSiteTVItemID), new[] { "TideDataValueTideSiteTVItemID" });
            }

            //TideDataValueTideSiteTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideDataValueTideSiteTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideDataValueTideSiteTVText), new[] { "TideDataValueTideSiteTVText" });
            }

            //TideDataValueTideSiteTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideDataValueTideStart))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideDataValueTideStart), new[] { "TideDataValueTideStart" });
            }

            //TideDataValueTideStart has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideDataValueTideStartText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideDataValueTideStartText), new[] { "TideDataValueTideStartText" });
            }

            //TideDataValueTideStartText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideDataValueUVelocity_m_s))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideDataValueUVelocity_m_s), new[] { "TideDataValueUVelocity_m_s" });
            }

            //TideDataValueUVelocity_m_s has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideDataValueVVelocity_m_s))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideDataValueVVelocity_m_s), new[] { "TideDataValueVVelocity_m_s" });
            }

            //TideDataValueVVelocity_m_s has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideLocation))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideLocation), new[] { "TideLocation" });
            }

            //TideLocation has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideLocationHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideLocationHasErrors), new[] { "TideLocationHasErrors" });
            }

            //TideLocationHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideLocationLat))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideLocationLat), new[] { "TideLocationLat" });
            }

            //TideLocationLat has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideLocationLng))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideLocationLng), new[] { "TideLocationLng" });
            }

            //TideLocationLng has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideLocationName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideLocationName), new[] { "TideLocationName" });
            }

            //TideLocationName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideLocationProv))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideLocationProv), new[] { "TideLocationProv" });
            }

            //TideLocationProv has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideLocationsid))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideLocationsid), new[] { "TideLocationsid" });
            }

            //TideLocationsid has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideLocationTideLocationID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideLocationTideLocationID), new[] { "TideLocationTideLocationID" });
            }

            //TideLocationTideLocationID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideLocationZone))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideLocationZone), new[] { "TideLocationZone" });
            }

            //TideLocationZone has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideSite))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideSite), new[] { "TideSite" });
            }

            //TideSite has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideSiteHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideSiteHasErrors), new[] { "TideSiteHasErrors" });
            }

            //TideSiteHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideSiteLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideSiteLastUpdateContactTVItemID), new[] { "TideSiteLastUpdateContactTVItemID" });
            }

            //TideSiteLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideSiteLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideSiteLastUpdateContactTVText), new[] { "TideSiteLastUpdateContactTVText" });
            }

            //TideSiteLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideSiteLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideSiteLastUpdateDate_UTC), new[] { "TideSiteLastUpdateDate_UTC" });
            }

            //TideSiteLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideSiteTideSiteID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideSiteTideSiteID), new[] { "TideSiteTideSiteID" });
            }

            //TideSiteTideSiteID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideSiteTideSiteTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideSiteTideSiteTVItemID), new[] { "TideSiteTideSiteTVItemID" });
            }

            //TideSiteTideSiteTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideSiteTideSiteTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideSiteTideSiteTVText), new[] { "TideSiteTideSiteTVText" });
            }

            //TideSiteTideSiteTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideSiteWebTideDatum_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideSiteWebTideDatum_m), new[] { "TideSiteWebTideDatum_m" });
            }

            //TideSiteWebTideDatum_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TideSiteWebTideModel))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTideSiteWebTideModel), new[] { "TideSiteWebTideModel" });
            }

            //TideSiteWebTideModel has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFile))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFile), new[] { "TVFile" });
            }

            //TVFile has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileClientFilePath))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileClientFilePath), new[] { "TVFileClientFilePath" });
            }

            //TVFileClientFilePath has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileFileCreatedDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileFileCreatedDate_UTC), new[] { "TVFileFileCreatedDate_UTC" });
            }

            //TVFileFileCreatedDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileFileInfo))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileFileInfo), new[] { "TVFileFileInfo" });
            }

            //TVFileFileInfo has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileFilePurpose))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileFilePurpose), new[] { "TVFileFilePurpose" });
            }

            //TVFileFilePurpose has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileFilePurposeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileFilePurposeText), new[] { "TVFileFilePurposeText" });
            }

            //TVFileFilePurposeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileFileSize_kb))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileFileSize_kb), new[] { "TVFileFileSize_kb" });
            }

            //TVFileFileSize_kb has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileFileType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileFileType), new[] { "TVFileFileType" });
            }

            //TVFileFileType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileFileTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileFileTypeText), new[] { "TVFileFileTypeText" });
            }

            //TVFileFileTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileFromWater))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileFromWater), new[] { "TVFileFromWater" });
            }

            //TVFileFromWater has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileHasErrors), new[] { "TVFileHasErrors" });
            }

            //TVFileHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileLanguage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileLanguage), new[] { "TVFileLanguage" });
            }

            //TVFileLanguage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileLanguageFileDescription))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileLanguageFileDescription), new[] { "TVFileLanguageFileDescription" });
            }

            //TVFileLanguageFileDescription has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileLanguageHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileLanguageHasErrors), new[] { "TVFileLanguageHasErrors" });
            }

            //TVFileLanguageHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileLanguageLanguage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileLanguageLanguage), new[] { "TVFileLanguageLanguage" });
            }

            //TVFileLanguageLanguage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileLanguageLanguageText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileLanguageLanguageText), new[] { "TVFileLanguageLanguageText" });
            }

            //TVFileLanguageLanguageText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileLanguageLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileLanguageLastUpdateContactTVItemID), new[] { "TVFileLanguageLastUpdateContactTVItemID" });
            }

            //TVFileLanguageLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileLanguageLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileLanguageLastUpdateContactTVText), new[] { "TVFileLanguageLastUpdateContactTVText" });
            }

            //TVFileLanguageLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileLanguageLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileLanguageLastUpdateDate_UTC), new[] { "TVFileLanguageLastUpdateDate_UTC" });
            }

            //TVFileLanguageLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileLanguageText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileLanguageText), new[] { "TVFileLanguageText" });
            }

            //TVFileLanguageText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileLanguageTranslationStatus))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileLanguageTranslationStatus), new[] { "TVFileLanguageTranslationStatus" });
            }

            //TVFileLanguageTranslationStatus has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileLanguageTranslationStatusText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileLanguageTranslationStatusText), new[] { "TVFileLanguageTranslationStatusText" });
            }

            //TVFileLanguageTranslationStatusText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileLanguageTVFileID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileLanguageTVFileID), new[] { "TVFileLanguageTVFileID" });
            }

            //TVFileLanguageTVFileID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileLanguageTVFileLanguageID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileLanguageTVFileLanguageID), new[] { "TVFileLanguageTVFileLanguageID" });
            }

            //TVFileLanguageTVFileLanguageID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileLastUpdateContactTVItemID), new[] { "TVFileLastUpdateContactTVItemID" });
            }

            //TVFileLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileLastUpdateContactTVText), new[] { "TVFileLastUpdateContactTVText" });
            }

            //TVFileLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileLastUpdateDate_UTC), new[] { "TVFileLastUpdateDate_UTC" });
            }

            //TVFileLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileServerFileName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileServerFileName), new[] { "TVFileServerFileName" });
            }

            //TVFileServerFileName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileServerFilePath))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileServerFilePath), new[] { "TVFileServerFilePath" });
            }

            //TVFileServerFilePath has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileTemplateTVType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileTemplateTVType), new[] { "TVFileTemplateTVType" });
            }

            //TVFileTemplateTVType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileTemplateTVTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileTemplateTVTypeText), new[] { "TVFileTemplateTVTypeText" });
            }

            //TVFileTemplateTVTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileTVFileID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileTVFileID), new[] { "TVFileTVFileID" });
            }

            //TVFileTVFileID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileTVFileTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileTVFileTVItemID), new[] { "TVFileTVFileTVItemID" });
            }

            //TVFileTVFileTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFileTVFileTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFileTVFileTVText), new[] { "TVFileTVFileTVText" });
            }

            //TVFileTVFileTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFullText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFullText), new[] { "TVFullText" });
            }

            //TVFullText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFullTextFullText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFullTextFullText), new[] { "TVFullTextFullText" });
            }

            //TVFullTextFullText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFullTextHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFullTextHasErrors), new[] { "TVFullTextHasErrors" });
            }

            //TVFullTextHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVFullTextTVPath))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVFullTextTVPath), new[] { "TVFullTextTVPath" });
            }

            //TVFullTextTVPath has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItem))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItem), new[] { "TVItem" });
            }

            //TVItem has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemHasErrors), new[] { "TVItemHasErrors" });
            }

            //TVItemHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemInfrastructureTypeTVItemLink))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemInfrastructureTypeTVItemLink), new[] { "TVItemInfrastructureTypeTVItemLink" });
            }

            //TVItemInfrastructureTypeTVItemLink has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemInfrastructureTypeTVItemLinkFlowTo))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemInfrastructureTypeTVItemLinkFlowTo), new[] { "TVItemInfrastructureTypeTVItemLinkFlowTo" });
            }

            //TVItemInfrastructureTypeTVItemLinkFlowTo has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemInfrastructureTypeTVItemLinkHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemInfrastructureTypeTVItemLinkHasErrors), new[] { "TVItemInfrastructureTypeTVItemLinkHasErrors" });
            }

            //TVItemInfrastructureTypeTVItemLinkHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemInfrastructureTypeTVItemLinkInfrastructureType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemInfrastructureTypeTVItemLinkInfrastructureType), new[] { "TVItemInfrastructureTypeTVItemLinkInfrastructureType" });
            }

            //TVItemInfrastructureTypeTVItemLinkInfrastructureType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemInfrastructureTypeTVItemLinkInfrastructureTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemInfrastructureTypeTVItemLinkInfrastructureTypeText), new[] { "TVItemInfrastructureTypeTVItemLinkInfrastructureTypeText" });
            }

            //TVItemInfrastructureTypeTVItemLinkInfrastructureTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemInfrastructureTypeTVItemLinkSeeOtherTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemInfrastructureTypeTVItemLinkSeeOtherTVItemID), new[] { "TVItemInfrastructureTypeTVItemLinkSeeOtherTVItemID" });
            }

            //TVItemInfrastructureTypeTVItemLinkSeeOtherTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemInfrastructureTypeTVItemLinkTVItem))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemInfrastructureTypeTVItemLinkTVItem), new[] { "TVItemInfrastructureTypeTVItemLinkTVItem" });
            }

            //TVItemInfrastructureTypeTVItemLinkTVItem has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemInfrastructureTypeTVItemLinkTVItemLinkList))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemInfrastructureTypeTVItemLinkTVItemLinkList), new[] { "TVItemInfrastructureTypeTVItemLinkTVItemLinkList" });
            }

            //TVItemInfrastructureTypeTVItemLinkTVItemLinkList has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemIsActive))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemIsActive), new[] { "TVItemIsActive" });
            }

            //TVItemIsActive has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLanguage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLanguage), new[] { "TVItemLanguage" });
            }

            //TVItemLanguage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLanguageHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLanguageHasErrors), new[] { "TVItemLanguageHasErrors" });
            }

            //TVItemLanguageHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLanguageLanguage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLanguageLanguage), new[] { "TVItemLanguageLanguage" });
            }

            //TVItemLanguageLanguage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLanguageLanguageText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLanguageLanguageText), new[] { "TVItemLanguageLanguageText" });
            }

            //TVItemLanguageLanguageText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLanguageLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLanguageLastUpdateContactTVItemID), new[] { "TVItemLanguageLastUpdateContactTVItemID" });
            }

            //TVItemLanguageLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLanguageLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLanguageLastUpdateContactTVText), new[] { "TVItemLanguageLastUpdateContactTVText" });
            }

            //TVItemLanguageLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLanguageLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLanguageLastUpdateDate_UTC), new[] { "TVItemLanguageLastUpdateDate_UTC" });
            }

            //TVItemLanguageLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLanguageTranslationStatus))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLanguageTranslationStatus), new[] { "TVItemLanguageTranslationStatus" });
            }

            //TVItemLanguageTranslationStatus has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLanguageTranslationStatusText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLanguageTranslationStatusText), new[] { "TVItemLanguageTranslationStatusText" });
            }

            //TVItemLanguageTranslationStatusText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLanguageTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLanguageTVItemID), new[] { "TVItemLanguageTVItemID" });
            }

            //TVItemLanguageTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLanguageTVItemLanguageID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLanguageTVItemLanguageID), new[] { "TVItemLanguageTVItemLanguageID" });
            }

            //TVItemLanguageTVItemLanguageID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLanguageTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLanguageTVText), new[] { "TVItemLanguageTVText" });
            }

            //TVItemLanguageTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLastUpdateContactTVItemID), new[] { "TVItemLastUpdateContactTVItemID" });
            }

            //TVItemLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLastUpdateContactTVText), new[] { "TVItemLastUpdateContactTVText" });
            }

            //TVItemLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLastUpdateDate_UTC), new[] { "TVItemLastUpdateDate_UTC" });
            }

            //TVItemLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLink))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLink), new[] { "TVItemLink" });
            }

            //TVItemLink has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLinkEndDateTime_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLinkEndDateTime_Local), new[] { "TVItemLinkEndDateTime_Local" });
            }

            //TVItemLinkEndDateTime_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLinkFromTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLinkFromTVItemID), new[] { "TVItemLinkFromTVItemID" });
            }

            //TVItemLinkFromTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLinkFromTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLinkFromTVText), new[] { "TVItemLinkFromTVText" });
            }

            //TVItemLinkFromTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLinkFromTVType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLinkFromTVType), new[] { "TVItemLinkFromTVType" });
            }

            //TVItemLinkFromTVType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLinkFromTVTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLinkFromTVTypeText), new[] { "TVItemLinkFromTVTypeText" });
            }

            //TVItemLinkFromTVTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLinkHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLinkHasErrors), new[] { "TVItemLinkHasErrors" });
            }

            //TVItemLinkHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLinkLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLinkLastUpdateContactTVItemID), new[] { "TVItemLinkLastUpdateContactTVItemID" });
            }

            //TVItemLinkLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLinkLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLinkLastUpdateContactTVText), new[] { "TVItemLinkLastUpdateContactTVText" });
            }

            //TVItemLinkLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLinkLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLinkLastUpdateDate_UTC), new[] { "TVItemLinkLastUpdateDate_UTC" });
            }

            //TVItemLinkLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLinkOrdinal))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLinkOrdinal), new[] { "TVItemLinkOrdinal" });
            }

            //TVItemLinkOrdinal has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLinkParentTVItemLinkID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLinkParentTVItemLinkID), new[] { "TVItemLinkParentTVItemLinkID" });
            }

            //TVItemLinkParentTVItemLinkID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLinkStartDateTime_Local))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLinkStartDateTime_Local), new[] { "TVItemLinkStartDateTime_Local" });
            }

            //TVItemLinkStartDateTime_Local has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLinkToTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLinkToTVItemID), new[] { "TVItemLinkToTVItemID" });
            }

            //TVItemLinkToTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLinkToTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLinkToTVText), new[] { "TVItemLinkToTVText" });
            }

            //TVItemLinkToTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLinkToTVType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLinkToTVType), new[] { "TVItemLinkToTVType" });
            }

            //TVItemLinkToTVType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLinkToTVTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLinkToTVTypeText), new[] { "TVItemLinkToTVTypeText" });
            }

            //TVItemLinkToTVTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLinkTVItemLinkID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLinkTVItemLinkID), new[] { "TVItemLinkTVItemLinkID" });
            }

            //TVItemLinkTVItemLinkID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLinkTVLevel))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLinkTVLevel), new[] { "TVItemLinkTVLevel" });
            }

            //TVItemLinkTVLevel has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemLinkTVPath))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemLinkTVPath), new[] { "TVItemLinkTVPath" });
            }

            //TVItemLinkTVPath has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemParentID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemParentID), new[] { "TVItemParentID" });
            }

            //TVItemParentID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemStat))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemStat), new[] { "TVItemStat" });
            }

            //TVItemStat has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemStatChildCount))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemStatChildCount), new[] { "TVItemStatChildCount" });
            }

            //TVItemStatChildCount has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemStatHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemStatHasErrors), new[] { "TVItemStatHasErrors" });
            }

            //TVItemStatHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemStatLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemStatLastUpdateContactTVItemID), new[] { "TVItemStatLastUpdateContactTVItemID" });
            }

            //TVItemStatLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemStatLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemStatLastUpdateContactTVText), new[] { "TVItemStatLastUpdateContactTVText" });
            }

            //TVItemStatLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemStatLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemStatLastUpdateDate_UTC), new[] { "TVItemStatLastUpdateDate_UTC" });
            }

            //TVItemStatLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemStatTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemStatTVItemID), new[] { "TVItemStatTVItemID" });
            }

            //TVItemStatTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemStatTVItemStatID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemStatTVItemStatID), new[] { "TVItemStatTVItemStatID" });
            }

            //TVItemStatTVItemStatID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemStatTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemStatTVText), new[] { "TVItemStatTVText" });
            }

            //TVItemStatTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemStatTVType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemStatTVType), new[] { "TVItemStatTVType" });
            }

            //TVItemStatTVType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemStatTVTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemStatTVTypeText), new[] { "TVItemStatTVTypeText" });
            }

            //TVItemStatTVTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemSubsectorAndMWQMSite))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemSubsectorAndMWQMSite), new[] { "TVItemSubsectorAndMWQMSite" });
            }

            //TVItemSubsectorAndMWQMSite has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemSubsectorAndMWQMSiteHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemSubsectorAndMWQMSiteHasErrors), new[] { "TVItemSubsectorAndMWQMSiteHasErrors" });
            }

            //TVItemSubsectorAndMWQMSiteHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemSubsectorAndMWQMSiteTVItemMWQMSiteDuplicate))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemSubsectorAndMWQMSiteTVItemMWQMSiteDuplicate), new[] { "TVItemSubsectorAndMWQMSiteTVItemMWQMSiteDuplicate" });
            }

            //TVItemSubsectorAndMWQMSiteTVItemMWQMSiteDuplicate has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemSubsectorAndMWQMSiteTVItemMWQMSiteList))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemSubsectorAndMWQMSiteTVItemMWQMSiteList), new[] { "TVItemSubsectorAndMWQMSiteTVItemMWQMSiteList" });
            }

            //TVItemSubsectorAndMWQMSiteTVItemMWQMSiteList has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemSubsectorAndMWQMSiteTVItemSubsector))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemSubsectorAndMWQMSiteTVItemSubsector), new[] { "TVItemSubsectorAndMWQMSiteTVItemSubsector" });
            }

            //TVItemSubsectorAndMWQMSiteTVItemSubsector has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemTVAuth))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemTVAuth), new[] { "TVItemTVAuth" });
            }

            //TVItemTVAuth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemTVAuthError))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemTVAuthError), new[] { "TVItemTVAuthError" });
            }

            //TVItemTVAuthError has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemTVAuthHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemTVAuthHasErrors), new[] { "TVItemTVAuthHasErrors" });
            }

            //TVItemTVAuthHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemTVAuthTVAuth))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemTVAuthTVAuth), new[] { "TVItemTVAuthTVAuth" });
            }

            //TVItemTVAuthTVAuth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemTVAuthTVAuthText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemTVAuthTVAuthText), new[] { "TVItemTVAuthTVAuthText" });
            }

            //TVItemTVAuthTVAuthText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemTVAuthTVItemID1))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemTVAuthTVItemID1), new[] { "TVItemTVAuthTVItemID1" });
            }

            //TVItemTVAuthTVItemID1 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemTVAuthTVItemUserAuthID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemTVAuthTVItemUserAuthID), new[] { "TVItemTVAuthTVItemUserAuthID" });
            }

            //TVItemTVAuthTVItemUserAuthID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemTVAuthTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemTVAuthTVText), new[] { "TVItemTVAuthTVText" });
            }

            //TVItemTVAuthTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemTVAuthTVTypeStr))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemTVAuthTVTypeStr), new[] { "TVItemTVAuthTVTypeStr" });
            }

            //TVItemTVAuthTVTypeStr has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemTVItemID), new[] { "TVItemTVItemID" });
            }

            //TVItemTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemTVLevel))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemTVLevel), new[] { "TVItemTVLevel" });
            }

            //TVItemTVLevel has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemTVPath))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemTVPath), new[] { "TVItemTVPath" });
            }

            //TVItemTVPath has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemTVText), new[] { "TVItemTVText" });
            }

            //TVItemTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemTVType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemTVType), new[] { "TVItemTVType" });
            }

            //TVItemTVType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemTVTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemTVTypeText), new[] { "TVItemTVTypeText" });
            }

            //TVItemTVTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemUserAuthorization))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemUserAuthorization), new[] { "TVItemUserAuthorization" });
            }

            //TVItemUserAuthorization has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemUserAuthorizationContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemUserAuthorizationContactTVItemID), new[] { "TVItemUserAuthorizationContactTVItemID" });
            }

            //TVItemUserAuthorizationContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemUserAuthorizationContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemUserAuthorizationContactTVText), new[] { "TVItemUserAuthorizationContactTVText" });
            }

            //TVItemUserAuthorizationContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemUserAuthorizationHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemUserAuthorizationHasErrors), new[] { "TVItemUserAuthorizationHasErrors" });
            }

            //TVItemUserAuthorizationHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemUserAuthorizationLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemUserAuthorizationLastUpdateContactTVItemID), new[] { "TVItemUserAuthorizationLastUpdateContactTVItemID" });
            }

            //TVItemUserAuthorizationLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemUserAuthorizationLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemUserAuthorizationLastUpdateContactTVText), new[] { "TVItemUserAuthorizationLastUpdateContactTVText" });
            }

            //TVItemUserAuthorizationLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemUserAuthorizationLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemUserAuthorizationLastUpdateDate_UTC), new[] { "TVItemUserAuthorizationLastUpdateDate_UTC" });
            }

            //TVItemUserAuthorizationLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemUserAuthorizationTVAuth))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemUserAuthorizationTVAuth), new[] { "TVItemUserAuthorizationTVAuth" });
            }

            //TVItemUserAuthorizationTVAuth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemUserAuthorizationTVAuthText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemUserAuthorizationTVAuthText), new[] { "TVItemUserAuthorizationTVAuthText" });
            }

            //TVItemUserAuthorizationTVAuthText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemUserAuthorizationTVItemID1))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemUserAuthorizationTVItemID1), new[] { "TVItemUserAuthorizationTVItemID1" });
            }

            //TVItemUserAuthorizationTVItemID1 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemUserAuthorizationTVItemID2))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemUserAuthorizationTVItemID2), new[] { "TVItemUserAuthorizationTVItemID2" });
            }

            //TVItemUserAuthorizationTVItemID2 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemUserAuthorizationTVItemID3))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemUserAuthorizationTVItemID3), new[] { "TVItemUserAuthorizationTVItemID3" });
            }

            //TVItemUserAuthorizationTVItemID3 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemUserAuthorizationTVItemID4))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemUserAuthorizationTVItemID4), new[] { "TVItemUserAuthorizationTVItemID4" });
            }

            //TVItemUserAuthorizationTVItemID4 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemUserAuthorizationTVItemUserAuthorizationID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemUserAuthorizationTVItemUserAuthorizationID), new[] { "TVItemUserAuthorizationTVItemUserAuthorizationID" });
            }

            //TVItemUserAuthorizationTVItemUserAuthorizationID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemUserAuthorizationTVText1))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemUserAuthorizationTVText1), new[] { "TVItemUserAuthorizationTVText1" });
            }

            //TVItemUserAuthorizationTVText1 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemUserAuthorizationTVText2))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemUserAuthorizationTVText2), new[] { "TVItemUserAuthorizationTVText2" });
            }

            //TVItemUserAuthorizationTVText2 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemUserAuthorizationTVText3))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemUserAuthorizationTVText3), new[] { "TVItemUserAuthorizationTVText3" });
            }

            //TVItemUserAuthorizationTVText3 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVItemUserAuthorizationTVText4))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVItemUserAuthorizationTVText4), new[] { "TVItemUserAuthorizationTVText4" });
            }

            //TVItemUserAuthorizationTVText4 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVLocation))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVLocation), new[] { "TVLocation" });
            }

            //TVLocation has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVLocationError))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVLocationError), new[] { "TVLocationError" });
            }

            //TVLocationError has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVLocationHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVLocationHasErrors), new[] { "TVLocationHasErrors" });
            }

            //TVLocationHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVLocationMapObjList))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVLocationMapObjList), new[] { "TVLocationMapObjList" });
            }

            //TVLocationMapObjList has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVLocationSubTVType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVLocationSubTVType), new[] { "TVLocationSubTVType" });
            }

            //TVLocationSubTVType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVLocationSubTVTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVLocationSubTVTypeText), new[] { "TVLocationSubTVTypeText" });
            }

            //TVLocationSubTVTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVLocationTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVLocationTVItemID), new[] { "TVLocationTVItemID" });
            }

            //TVLocationTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVLocationTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVLocationTVText), new[] { "TVLocationTVText" });
            }

            //TVLocationTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVLocationTVType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVLocationTVType), new[] { "TVLocationTVType" });
            }

            //TVLocationTVType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVLocationTVTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVLocationTVTypeText), new[] { "TVLocationTVTypeText" });
            }

            //TVLocationTVTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVTextLanguage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVTextLanguage), new[] { "TVTextLanguage" });
            }

            //TVTextLanguage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVTextLanguageHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVTextLanguageHasErrors), new[] { "TVTextLanguageHasErrors" });
            }

            //TVTextLanguageHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVTextLanguageLanguage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVTextLanguageLanguage), new[] { "TVTextLanguageLanguage" });
            }

            //TVTextLanguageLanguage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVTextLanguageLanguageText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVTextLanguageLanguageText), new[] { "TVTextLanguageLanguageText" });
            }

            //TVTextLanguageLanguageText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVTextLanguageTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVTextLanguageTVText), new[] { "TVTextLanguageTVText" });
            }

            //TVTextLanguageTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVTypeNamesAndPath))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVTypeNamesAndPath), new[] { "TVTypeNamesAndPath" });
            }

            //TVTypeNamesAndPath has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVTypeNamesAndPathHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVTypeNamesAndPathHasErrors), new[] { "TVTypeNamesAndPathHasErrors" });
            }

            //TVTypeNamesAndPathHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVTypeNamesAndPathIndex))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVTypeNamesAndPathIndex), new[] { "TVTypeNamesAndPathIndex" });
            }

            //TVTypeNamesAndPathIndex has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVTypeNamesAndPathTVPath))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVTypeNamesAndPathTVPath), new[] { "TVTypeNamesAndPathTVPath" });
            }

            //TVTypeNamesAndPathTVPath has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVTypeNamesAndPathTVTypeName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVTypeNamesAndPathTVTypeName), new[] { "TVTypeNamesAndPathTVTypeName" });
            }

            //TVTypeNamesAndPathTVTypeName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVTypeUserAuthorization))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVTypeUserAuthorization), new[] { "TVTypeUserAuthorization" });
            }

            //TVTypeUserAuthorization has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVTypeUserAuthorizationContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVTypeUserAuthorizationContactTVItemID), new[] { "TVTypeUserAuthorizationContactTVItemID" });
            }

            //TVTypeUserAuthorizationContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVTypeUserAuthorizationContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVTypeUserAuthorizationContactTVText), new[] { "TVTypeUserAuthorizationContactTVText" });
            }

            //TVTypeUserAuthorizationContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVTypeUserAuthorizationHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVTypeUserAuthorizationHasErrors), new[] { "TVTypeUserAuthorizationHasErrors" });
            }

            //TVTypeUserAuthorizationHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVTypeUserAuthorizationLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVTypeUserAuthorizationLastUpdateContactTVItemID), new[] { "TVTypeUserAuthorizationLastUpdateContactTVItemID" });
            }

            //TVTypeUserAuthorizationLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVTypeUserAuthorizationLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVTypeUserAuthorizationLastUpdateContactTVText), new[] { "TVTypeUserAuthorizationLastUpdateContactTVText" });
            }

            //TVTypeUserAuthorizationLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVTypeUserAuthorizationLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVTypeUserAuthorizationLastUpdateDate_UTC), new[] { "TVTypeUserAuthorizationLastUpdateDate_UTC" });
            }

            //TVTypeUserAuthorizationLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVTypeUserAuthorizationTVAuth))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVTypeUserAuthorizationTVAuth), new[] { "TVTypeUserAuthorizationTVAuth" });
            }

            //TVTypeUserAuthorizationTVAuth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVTypeUserAuthorizationTVAuthText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVTypeUserAuthorizationTVAuthText), new[] { "TVTypeUserAuthorizationTVAuthText" });
            }

            //TVTypeUserAuthorizationTVAuthText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVTypeUserAuthorizationTVType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVTypeUserAuthorizationTVType), new[] { "TVTypeUserAuthorizationTVType" });
            }

            //TVTypeUserAuthorizationTVType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVTypeUserAuthorizationTVTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVTypeUserAuthorizationTVTypeText), new[] { "TVTypeUserAuthorizationTVTypeText" });
            }

            //TVTypeUserAuthorizationTVTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.TVTypeUserAuthorizationTVTypeUserAuthorizationID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResTVTypeUserAuthorizationTVTypeUserAuthorizationID), new[] { "TVTypeUserAuthorizationTVTypeUserAuthorizationID" });
            }

            //TVTypeUserAuthorizationTVTypeUserAuthorizationID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.URLNumberOfSamples))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResURLNumberOfSamples), new[] { "URLNumberOfSamples" });
            }

            //URLNumberOfSamples has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.URLNumberOfSamplesHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResURLNumberOfSamplesHasErrors), new[] { "URLNumberOfSamplesHasErrors" });
            }

            //URLNumberOfSamplesHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.URLNumberOfSamplesNumberOfSamples))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResURLNumberOfSamplesNumberOfSamples), new[] { "URLNumberOfSamplesNumberOfSamples" });
            }

            //URLNumberOfSamplesNumberOfSamples has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.URLNumberOfSamplesurl))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResURLNumberOfSamplesurl), new[] { "URLNumberOfSamplesurl" });
            }

            //URLNumberOfSamplesurl has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.UseOfSite))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResUseOfSite), new[] { "UseOfSite" });
            }

            //UseOfSite has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.UseOfSiteEndYear))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResUseOfSiteEndYear), new[] { "UseOfSiteEndYear" });
            }

            //UseOfSiteEndYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.UseOfSiteHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResUseOfSiteHasErrors), new[] { "UseOfSiteHasErrors" });
            }

            //UseOfSiteHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.UseOfSiteLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResUseOfSiteLastUpdateContactTVItemID), new[] { "UseOfSiteLastUpdateContactTVItemID" });
            }

            //UseOfSiteLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.UseOfSiteLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResUseOfSiteLastUpdateContactTVText), new[] { "UseOfSiteLastUpdateContactTVText" });
            }

            //UseOfSiteLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.UseOfSiteLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResUseOfSiteLastUpdateDate_UTC), new[] { "UseOfSiteLastUpdateDate_UTC" });
            }

            //UseOfSiteLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.UseOfSiteOrdinal))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResUseOfSiteOrdinal), new[] { "UseOfSiteOrdinal" });
            }

            //UseOfSiteOrdinal has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.UseOfSiteParam1))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResUseOfSiteParam1), new[] { "UseOfSiteParam1" });
            }

            //UseOfSiteParam1 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.UseOfSiteParam2))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResUseOfSiteParam2), new[] { "UseOfSiteParam2" });
            }

            //UseOfSiteParam2 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.UseOfSiteParam3))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResUseOfSiteParam3), new[] { "UseOfSiteParam3" });
            }

            //UseOfSiteParam3 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.UseOfSiteParam4))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResUseOfSiteParam4), new[] { "UseOfSiteParam4" });
            }

            //UseOfSiteParam4 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.UseOfSiteSiteTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResUseOfSiteSiteTVItemID), new[] { "UseOfSiteSiteTVItemID" });
            }

            //UseOfSiteSiteTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.UseOfSiteSiteTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResUseOfSiteSiteTVText), new[] { "UseOfSiteSiteTVText" });
            }

            //UseOfSiteSiteTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.UseOfSiteSiteType))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResUseOfSiteSiteType), new[] { "UseOfSiteSiteType" });
            }

            //UseOfSiteSiteType has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.UseOfSiteSiteTypeText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResUseOfSiteSiteTypeText), new[] { "UseOfSiteSiteTypeText" });
            }

            //UseOfSiteSiteTypeText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.UseOfSiteStartYear))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResUseOfSiteStartYear), new[] { "UseOfSiteStartYear" });
            }

            //UseOfSiteStartYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.UseOfSiteSubsectorTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResUseOfSiteSubsectorTVItemID), new[] { "UseOfSiteSubsectorTVItemID" });
            }

            //UseOfSiteSubsectorTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.UseOfSiteSubsectorTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResUseOfSiteSubsectorTVText), new[] { "UseOfSiteSubsectorTVText" });
            }

            //UseOfSiteSubsectorTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.UseOfSiteUseEquation))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResUseOfSiteUseEquation), new[] { "UseOfSiteUseEquation" });
            }

            //UseOfSiteUseEquation has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.UseOfSiteUseOfSiteID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResUseOfSiteUseOfSiteID), new[] { "UseOfSiteUseOfSiteID" });
            }

            //UseOfSiteUseOfSiteID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.UseOfSiteUseWeight))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResUseOfSiteUseWeight), new[] { "UseOfSiteUseWeight" });
            }

            //UseOfSiteUseWeight has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.UseOfSiteWeight_perc))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResUseOfSiteWeight_perc), new[] { "UseOfSiteWeight_perc" });
            }

            //UseOfSiteWeight_perc has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.Vector))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVector), new[] { "Vector" });
            }

            //Vector has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VectorEndNode))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVectorEndNode), new[] { "VectorEndNode" });
            }

            //VectorEndNode has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VectorHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVectorHasErrors), new[] { "VectorHasErrors" });
            }

            //VectorHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VectorStartNode))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVectorStartNode), new[] { "VectorStartNode" });
            }

            //VectorStartNode has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPAmbient))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPAmbient), new[] { "VPAmbient" });
            }

            //VPAmbient has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPAmbientAmbientSalinity_PSU))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPAmbientAmbientSalinity_PSU), new[] { "VPAmbientAmbientSalinity_PSU" });
            }

            //VPAmbientAmbientSalinity_PSU has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPAmbientAmbientTemperature_C))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPAmbientAmbientTemperature_C), new[] { "VPAmbientAmbientTemperature_C" });
            }

            //VPAmbientAmbientTemperature_C has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPAmbientBackgroundConcentration_MPN_100ml))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPAmbientBackgroundConcentration_MPN_100ml), new[] { "VPAmbientBackgroundConcentration_MPN_100ml" });
            }

            //VPAmbientBackgroundConcentration_MPN_100ml has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPAmbientCurrentDirection_deg))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPAmbientCurrentDirection_deg), new[] { "VPAmbientCurrentDirection_deg" });
            }

            //VPAmbientCurrentDirection_deg has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPAmbientCurrentSpeed_m_s))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPAmbientCurrentSpeed_m_s), new[] { "VPAmbientCurrentSpeed_m_s" });
            }

            //VPAmbientCurrentSpeed_m_s has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPAmbientFarFieldCurrentDirection_deg))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPAmbientFarFieldCurrentDirection_deg), new[] { "VPAmbientFarFieldCurrentDirection_deg" });
            }

            //VPAmbientFarFieldCurrentDirection_deg has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPAmbientFarFieldCurrentSpeed_m_s))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPAmbientFarFieldCurrentSpeed_m_s), new[] { "VPAmbientFarFieldCurrentSpeed_m_s" });
            }

            //VPAmbientFarFieldCurrentSpeed_m_s has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPAmbientFarFieldDiffusionCoefficient))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPAmbientFarFieldDiffusionCoefficient), new[] { "VPAmbientFarFieldDiffusionCoefficient" });
            }

            //VPAmbientFarFieldDiffusionCoefficient has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPAmbientHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPAmbientHasErrors), new[] { "VPAmbientHasErrors" });
            }

            //VPAmbientHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPAmbientLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPAmbientLastUpdateContactTVItemID), new[] { "VPAmbientLastUpdateContactTVItemID" });
            }

            //VPAmbientLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPAmbientLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPAmbientLastUpdateContactTVText), new[] { "VPAmbientLastUpdateContactTVText" });
            }

            //VPAmbientLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPAmbientLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPAmbientLastUpdateDate_UTC), new[] { "VPAmbientLastUpdateDate_UTC" });
            }

            //VPAmbientLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPAmbientMeasurementDepth_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPAmbientMeasurementDepth_m), new[] { "VPAmbientMeasurementDepth_m" });
            }

            //VPAmbientMeasurementDepth_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPAmbientPollutantDecayRate_per_day))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPAmbientPollutantDecayRate_per_day), new[] { "VPAmbientPollutantDecayRate_per_day" });
            }

            //VPAmbientPollutantDecayRate_per_day has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPAmbientRow))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPAmbientRow), new[] { "VPAmbientRow" });
            }

            //VPAmbientRow has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPAmbientVPAmbientID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPAmbientVPAmbientID), new[] { "VPAmbientVPAmbientID" });
            }

            //VPAmbientVPAmbientID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPAmbientVPScenarioID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPAmbientVPScenarioID), new[] { "VPAmbientVPScenarioID" });
            }

            //VPAmbientVPScenarioID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPFull))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPFull), new[] { "VPFull" });
            }

            //VPFull has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPFullHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPFullHasErrors), new[] { "VPFullHasErrors" });
            }

            //VPFullHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPFullVPAmbientList))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPFullVPAmbientList), new[] { "VPFullVPAmbientList" });
            }

            //VPFullVPAmbientList has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPFullVPResultList))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPFullVPResultList), new[] { "VPFullVPResultList" });
            }

            //VPFullVPResultList has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPFullVPScenario))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPFullVPScenario), new[] { "VPFullVPScenario" });
            }

            //VPFullVPScenario has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPResult))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPResult), new[] { "VPResult" });
            }

            //VPResult has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPResultConcentration_MPN_100ml))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPResultConcentration_MPN_100ml), new[] { "VPResultConcentration_MPN_100ml" });
            }

            //VPResultConcentration_MPN_100ml has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPResultDilution))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPResultDilution), new[] { "VPResultDilution" });
            }

            //VPResultDilution has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPResultDispersionDistance_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPResultDispersionDistance_m), new[] { "VPResultDispersionDistance_m" });
            }

            //VPResultDispersionDistance_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPResultFarFieldWidth_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPResultFarFieldWidth_m), new[] { "VPResultFarFieldWidth_m" });
            }

            //VPResultFarFieldWidth_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPResultHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPResultHasErrors), new[] { "VPResultHasErrors" });
            }

            //VPResultHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPResultLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPResultLastUpdateContactTVItemID), new[] { "VPResultLastUpdateContactTVItemID" });
            }

            //VPResultLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPResultLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPResultLastUpdateContactTVText), new[] { "VPResultLastUpdateContactTVText" });
            }

            //VPResultLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPResultLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPResultLastUpdateDate_UTC), new[] { "VPResultLastUpdateDate_UTC" });
            }

            //VPResultLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPResultOrdinal))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPResultOrdinal), new[] { "VPResultOrdinal" });
            }

            //VPResultOrdinal has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPResultTravelTime_hour))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPResultTravelTime_hour), new[] { "VPResultTravelTime_hour" });
            }

            //VPResultTravelTime_hour has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPResultVPResultID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPResultVPResultID), new[] { "VPResultVPResultID" });
            }

            //VPResultVPResultID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPResultVPScenarioID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPResultVPScenarioID), new[] { "VPResultVPScenarioID" });
            }

            //VPResultVPScenarioID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPResValues))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPResValues), new[] { "VPResValues" });
            }

            //VPResValues has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPResValuesConc))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPResValuesConc), new[] { "VPResValuesConc" });
            }

            //VPResValuesConc has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPResValuesDecay))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPResValuesDecay), new[] { "VPResValuesDecay" });
            }

            //VPResValuesDecay has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPResValuesDilu))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPResValuesDilu), new[] { "VPResValuesDilu" });
            }

            //VPResValuesDilu has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPResValuesDistance))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPResValuesDistance), new[] { "VPResValuesDistance" });
            }

            //VPResValuesDistance has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPResValuesFarfieldWidth))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPResValuesFarfieldWidth), new[] { "VPResValuesFarfieldWidth" });
            }

            //VPResValuesFarfieldWidth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPResValuesHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPResValuesHasErrors), new[] { "VPResValuesHasErrors" });
            }

            //VPResValuesHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPResValuesTheTime))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPResValuesTheTime), new[] { "VPResValuesTheTime" });
            }

            //VPResValuesTheTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenario))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenario), new[] { "VPScenario" });
            }

            //VPScenario has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioAcuteMixZone_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioAcuteMixZone_m), new[] { "VPScenarioAcuteMixZone_m" });
            }

            //VPScenarioAcuteMixZone_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioChronicMixZone_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioChronicMixZone_m), new[] { "VPScenarioChronicMixZone_m" });
            }

            //VPScenarioChronicMixZone_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioEffluentConcentration_MPN_100ml))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioEffluentConcentration_MPN_100ml), new[] { "VPScenarioEffluentConcentration_MPN_100ml" });
            }

            //VPScenarioEffluentConcentration_MPN_100ml has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioEffluentFlow_m3_s))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioEffluentFlow_m3_s), new[] { "VPScenarioEffluentFlow_m3_s" });
            }

            //VPScenarioEffluentFlow_m3_s has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioEffluentSalinity_PSU))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioEffluentSalinity_PSU), new[] { "VPScenarioEffluentSalinity_PSU" });
            }

            //VPScenarioEffluentSalinity_PSU has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioEffluentTemperature_C))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioEffluentTemperature_C), new[] { "VPScenarioEffluentTemperature_C" });
            }

            //VPScenarioEffluentTemperature_C has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioEffluentVelocity_m_s))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioEffluentVelocity_m_s), new[] { "VPScenarioEffluentVelocity_m_s" });
            }

            //VPScenarioEffluentVelocity_m_s has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioFroudeNumber))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioFroudeNumber), new[] { "VPScenarioFroudeNumber" });
            }

            //VPScenarioFroudeNumber has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioHasErrors), new[] { "VPScenarioHasErrors" });
            }

            //VPScenarioHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioHorizontalAngle_deg))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioHorizontalAngle_deg), new[] { "VPScenarioHorizontalAngle_deg" });
            }

            //VPScenarioHorizontalAngle_deg has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioIDAndRawResults))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioIDAndRawResults), new[] { "VPScenarioIDAndRawResults" });
            }

            //VPScenarioIDAndRawResults has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioIDAndRawResultsHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioIDAndRawResultsHasErrors), new[] { "VPScenarioIDAndRawResultsHasErrors" });
            }

            //VPScenarioIDAndRawResultsHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioIDAndRawResultsRawResults))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioIDAndRawResultsRawResults), new[] { "VPScenarioIDAndRawResultsRawResults" });
            }

            //VPScenarioIDAndRawResultsRawResults has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioIDAndRawResultsVPScenarioID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioIDAndRawResultsVPScenarioID), new[] { "VPScenarioIDAndRawResultsVPScenarioID" });
            }

            //VPScenarioIDAndRawResultsVPScenarioID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioInfrastructureTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioInfrastructureTVItemID), new[] { "VPScenarioInfrastructureTVItemID" });
            }

            //VPScenarioInfrastructureTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioLanguage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioLanguage), new[] { "VPScenarioLanguage" });
            }

            //VPScenarioLanguage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioLanguageHasErrors))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioLanguageHasErrors), new[] { "VPScenarioLanguageHasErrors" });
            }

            //VPScenarioLanguageHasErrors has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioLanguageLanguage))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioLanguageLanguage), new[] { "VPScenarioLanguageLanguage" });
            }

            //VPScenarioLanguageLanguage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioLanguageLanguageText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioLanguageLanguageText), new[] { "VPScenarioLanguageLanguageText" });
            }

            //VPScenarioLanguageLanguageText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioLanguageLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioLanguageLastUpdateContactTVItemID), new[] { "VPScenarioLanguageLastUpdateContactTVItemID" });
            }

            //VPScenarioLanguageLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioLanguageLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioLanguageLastUpdateContactTVText), new[] { "VPScenarioLanguageLastUpdateContactTVText" });
            }

            //VPScenarioLanguageLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioLanguageLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioLanguageLastUpdateDate_UTC), new[] { "VPScenarioLanguageLastUpdateDate_UTC" });
            }

            //VPScenarioLanguageLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioLanguageTranslationStatus))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioLanguageTranslationStatus), new[] { "VPScenarioLanguageTranslationStatus" });
            }

            //VPScenarioLanguageTranslationStatus has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioLanguageTranslationStatusText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioLanguageTranslationStatusText), new[] { "VPScenarioLanguageTranslationStatusText" });
            }

            //VPScenarioLanguageTranslationStatusText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioLanguageVPScenarioID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioLanguageVPScenarioID), new[] { "VPScenarioLanguageVPScenarioID" });
            }

            //VPScenarioLanguageVPScenarioID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioLanguageVPScenarioLanguageID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioLanguageVPScenarioLanguageID), new[] { "VPScenarioLanguageVPScenarioLanguageID" });
            }

            //VPScenarioLanguageVPScenarioLanguageID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioLanguageVPScenarioName))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioLanguageVPScenarioName), new[] { "VPScenarioLanguageVPScenarioName" });
            }

            //VPScenarioLanguageVPScenarioName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioLastUpdateContactTVItemID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioLastUpdateContactTVItemID), new[] { "VPScenarioLastUpdateContactTVItemID" });
            }

            //VPScenarioLastUpdateContactTVItemID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioLastUpdateContactTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioLastUpdateContactTVText), new[] { "VPScenarioLastUpdateContactTVText" });
            }

            //VPScenarioLastUpdateContactTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioLastUpdateDate_UTC))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioLastUpdateDate_UTC), new[] { "VPScenarioLastUpdateDate_UTC" });
            }

            //VPScenarioLastUpdateDate_UTC has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioNumberOfPorts))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioNumberOfPorts), new[] { "VPScenarioNumberOfPorts" });
            }

            //VPScenarioNumberOfPorts has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioPortDepth_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioPortDepth_m), new[] { "VPScenarioPortDepth_m" });
            }

            //VPScenarioPortDepth_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioPortDiameter_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioPortDiameter_m), new[] { "VPScenarioPortDiameter_m" });
            }

            //VPScenarioPortDiameter_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioPortElevation_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioPortElevation_m), new[] { "VPScenarioPortElevation_m" });
            }

            //VPScenarioPortElevation_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioPortSpacing_m))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioPortSpacing_m), new[] { "VPScenarioPortSpacing_m" });
            }

            //VPScenarioPortSpacing_m has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioRawResults))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioRawResults), new[] { "VPScenarioRawResults" });
            }

            //VPScenarioRawResults has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioSubsectorTVText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioSubsectorTVText), new[] { "VPScenarioSubsectorTVText" });
            }

            //VPScenarioSubsectorTVText has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioUseAsBestEstimate))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioUseAsBestEstimate), new[] { "VPScenarioUseAsBestEstimate" });
            }

            //VPScenarioUseAsBestEstimate has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioVerticalAngle_deg))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioVerticalAngle_deg), new[] { "VPScenarioVerticalAngle_deg" });
            }

            //VPScenarioVerticalAngle_deg has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioVPScenarioID))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioVPScenarioID), new[] { "VPScenarioVPScenarioID" });
            }

            //VPScenarioVPScenarioID has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioVPScenarioStatus))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioVPScenarioStatus), new[] { "VPScenarioVPScenarioStatus" });
            }

            //VPScenarioVPScenarioStatus has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(cSSPModelsRes.VPScenarioVPScenarioStatusText))
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.CSSPModelsResVPScenarioVPScenarioStatusText), new[] { "VPScenarioVPScenarioStatusText" });
            }

            //VPScenarioVPScenarioStatusText has no StringLength Attribute

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                cSSPModelsRes.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(CSSPModelsRes cSSPModelsRes)
        {
            cSSPModelsRes.ValidationResults = Validate(new ValidationContext(cSSPModelsRes), ActionDBTypeEnum.Create);
            if (cSSPModelsRes.ValidationResults.Count() > 0) return false;

            db.CSSPModelsRess.Add(cSSPModelsRes);

            if (!TryToSave(cSSPModelsRes)) return false;

            return true;
        }
        public bool Delete(CSSPModelsRes cSSPModelsRes)
        {
            cSSPModelsRes.ValidationResults = Validate(new ValidationContext(cSSPModelsRes), ActionDBTypeEnum.Delete);
            if (cSSPModelsRes.ValidationResults.Count() > 0) return false;

            db.CSSPModelsRess.Remove(cSSPModelsRes);

            if (!TryToSave(cSSPModelsRes)) return false;

            return true;
        }
        public bool Update(CSSPModelsRes cSSPModelsRes)
        {
            cSSPModelsRes.ValidationResults = Validate(new ValidationContext(cSSPModelsRes), ActionDBTypeEnum.Update);
            if (cSSPModelsRes.ValidationResults.Count() > 0) return false;

            db.CSSPModelsRess.Update(cSSPModelsRes);

            if (!TryToSave(cSSPModelsRes)) return false;

            return true;
        }
        public IQueryable<CSSPModelsRes> GetRead()
        {
            return db.CSSPModelsRess.AsNoTracking();
        }
        public IQueryable<CSSPModelsRes> GetEdit()
        {
            return db.CSSPModelsRess;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<CSSPModelsRes> FillCSSPModelsRes(IQueryable<CSSPModelsRes> cSSPModelsResQuery)
        {
            List<CSSPModelsRes> CSSPModelsResList = (from c in cSSPModelsResQuery
                                         select new CSSPModelsRes
                                         {
                                             ResourceManager = c.ResourceManager,
                                             Culture = c.Culture,
                                             _IsRequired = c._IsRequired,
                                             Address = c.Address,
                                             AddressAddressID = c.AddressAddressID,
                                             AddressAddressTVItemID = c.AddressAddressTVItemID,
                                             AddressAddressTVText = c.AddressAddressTVText,
                                             AddressAddressType = c.AddressAddressType,
                                             AddressAddressTypeText = c.AddressAddressTypeText,
                                             AddressCountryTVItemID = c.AddressCountryTVItemID,
                                             AddressCountryTVText = c.AddressCountryTVText,
                                             AddressGoogleAddressText = c.AddressGoogleAddressText,
                                             AddressHasErrors = c.AddressHasErrors,
                                             AddressLastUpdateContactTVItemID = c.AddressLastUpdateContactTVItemID,
                                             AddressLastUpdateContactTVText = c.AddressLastUpdateContactTVText,
                                             AddressLastUpdateDate_UTC = c.AddressLastUpdateDate_UTC,
                                             AddressMunicipalityTVItemID = c.AddressMunicipalityTVItemID,
                                             AddressMunicipalityTVText = c.AddressMunicipalityTVText,
                                             AddressParentTVItemID = c.AddressParentTVItemID,
                                             AddressPostalCode = c.AddressPostalCode,
                                             AddressProvinceTVItemID = c.AddressProvinceTVItemID,
                                             AddressProvinceTVText = c.AddressProvinceTVText,
                                             AddressStreetName = c.AddressStreetName,
                                             AddressStreetNumber = c.AddressStreetNumber,
                                             AddressStreetType = c.AddressStreetType,
                                             AddressStreetTypeText = c.AddressStreetTypeText,
                                             AppErrLog = c.AppErrLog,
                                             AppErrLogAppErrLogID = c.AppErrLogAppErrLogID,
                                             AppErrLogDateTime_UTC = c.AppErrLogDateTime_UTC,
                                             AppErrLogHasErrors = c.AppErrLogHasErrors,
                                             AppErrLogLastUpdateContactTVItemID = c.AppErrLogLastUpdateContactTVItemID,
                                             AppErrLogLastUpdateContactTVText = c.AppErrLogLastUpdateContactTVText,
                                             AppErrLogLastUpdateDate_UTC = c.AppErrLogLastUpdateDate_UTC,
                                             AppErrLogLineNumber = c.AppErrLogLineNumber,
                                             AppErrLogMessage = c.AppErrLogMessage,
                                             AppErrLogSource = c.AppErrLogSource,
                                             AppErrLogTag = c.AppErrLogTag,
                                             AppTask = c.AppTask,
                                             AppTaskAppTaskCommand = c.AppTaskAppTaskCommand,
                                             AppTaskAppTaskCommandText = c.AppTaskAppTaskCommandText,
                                             AppTaskAppTaskID = c.AppTaskAppTaskID,
                                             AppTaskAppTaskStatus = c.AppTaskAppTaskStatus,
                                             AppTaskAppTaskStatusText = c.AppTaskAppTaskStatusText,
                                             AppTaskEndDateTime_UTC = c.AppTaskEndDateTime_UTC,
                                             AppTaskEstimatedLength_second = c.AppTaskEstimatedLength_second,
                                             AppTaskHasErrors = c.AppTaskHasErrors,
                                             AppTaskLanguage = c.AppTaskLanguage,
                                             AppTaskLanguageAppTaskID = c.AppTaskLanguageAppTaskID,
                                             AppTaskLanguageAppTaskLanguageID = c.AppTaskLanguageAppTaskLanguageID,
                                             AppTaskLanguageErrorText = c.AppTaskLanguageErrorText,
                                             AppTaskLanguageHasErrors = c.AppTaskLanguageHasErrors,
                                             AppTaskLanguageLanguage = c.AppTaskLanguageLanguage,
                                             AppTaskLanguageLanguageText = c.AppTaskLanguageLanguageText,
                                             AppTaskLanguageLastUpdateContactTVItemID = c.AppTaskLanguageLastUpdateContactTVItemID,
                                             AppTaskLanguageLastUpdateContactTVText = c.AppTaskLanguageLastUpdateContactTVText,
                                             AppTaskLanguageLastUpdateDate_UTC = c.AppTaskLanguageLastUpdateDate_UTC,
                                             AppTaskLanguageStatusText = c.AppTaskLanguageStatusText,
                                             AppTaskLanguageText = c.AppTaskLanguageText,
                                             AppTaskLanguageTranslationStatus = c.AppTaskLanguageTranslationStatus,
                                             AppTaskLanguageTranslationStatusText = c.AppTaskLanguageTranslationStatusText,
                                             AppTaskLastUpdateContactTVItemID = c.AppTaskLastUpdateContactTVItemID,
                                             AppTaskLastUpdateContactTVText = c.AppTaskLastUpdateContactTVText,
                                             AppTaskLastUpdateDate_UTC = c.AppTaskLastUpdateDate_UTC,
                                             AppTaskParameter = c.AppTaskParameter,
                                             AppTaskParameterHasErrors = c.AppTaskParameterHasErrors,
                                             AppTaskParameterName = c.AppTaskParameterName,
                                             AppTaskParameters = c.AppTaskParameters,
                                             AppTaskParameterValue = c.AppTaskParameterValue,
                                             AppTaskPercentCompleted = c.AppTaskPercentCompleted,
                                             AppTaskRemainingTime_second = c.AppTaskRemainingTime_second,
                                             AppTaskStartDateTime_UTC = c.AppTaskStartDateTime_UTC,
                                             AppTaskTVItem2TVText = c.AppTaskTVItem2TVText,
                                             AppTaskTVItemID = c.AppTaskTVItemID,
                                             AppTaskTVItemID2 = c.AppTaskTVItemID2,
                                             AppTaskTVItemTVText = c.AppTaskTVItemTVText,
                                             BoxModel = c.BoxModel,
                                             BoxModelBoxModelID = c.BoxModelBoxModelID,
                                             BoxModelCalNumb = c.BoxModelCalNumb,
                                             BoxModelCalNumbBoxModelResultType = c.BoxModelCalNumbBoxModelResultType,
                                             BoxModelCalNumbBoxModelResultTypeText = c.BoxModelCalNumbBoxModelResultTypeText,
                                             BoxModelCalNumbCalLength_m = c.BoxModelCalNumbCalLength_m,
                                             BoxModelCalNumbCalRadius_m = c.BoxModelCalNumbCalRadius_m,
                                             BoxModelCalNumbCalSurface_m2 = c.BoxModelCalNumbCalSurface_m2,
                                             BoxModelCalNumbCalVolume_m3 = c.BoxModelCalNumbCalVolume_m3,
                                             BoxModelCalNumbCalWidth_m = c.BoxModelCalNumbCalWidth_m,
                                             BoxModelCalNumbError = c.BoxModelCalNumbError,
                                             BoxModelCalNumbFixLength = c.BoxModelCalNumbFixLength,
                                             BoxModelCalNumbFixWidth = c.BoxModelCalNumbFixWidth,
                                             BoxModelCalNumbHasErrors = c.BoxModelCalNumbHasErrors,
                                             BoxModelConcentration_MPN_100ml = c.BoxModelConcentration_MPN_100ml,
                                             BoxModelDecayRate_per_day = c.BoxModelDecayRate_per_day,
                                             BoxModelDepth_m = c.BoxModelDepth_m,
                                             BoxModelDilution = c.BoxModelDilution,
                                             BoxModelFCPreDisinfection_MPN_100ml = c.BoxModelFCPreDisinfection_MPN_100ml,
                                             BoxModelFCUntreated_MPN_100ml = c.BoxModelFCUntreated_MPN_100ml,
                                             BoxModelFlow_m3_day = c.BoxModelFlow_m3_day,
                                             BoxModelFlowDuration_hour = c.BoxModelFlowDuration_hour,
                                             BoxModelHasErrors = c.BoxModelHasErrors,
                                             BoxModelInfrastructureTVItemID = c.BoxModelInfrastructureTVItemID,
                                             BoxModelInfrastructureTVText = c.BoxModelInfrastructureTVText,
                                             BoxModelLanguage = c.BoxModelLanguage,
                                             BoxModelLanguageBoxModelID = c.BoxModelLanguageBoxModelID,
                                             BoxModelLanguageBoxModelLanguageID = c.BoxModelLanguageBoxModelLanguageID,
                                             BoxModelLanguageHasErrors = c.BoxModelLanguageHasErrors,
                                             BoxModelLanguageLanguage = c.BoxModelLanguageLanguage,
                                             BoxModelLanguageLanguageText = c.BoxModelLanguageLanguageText,
                                             BoxModelLanguageLastUpdateContactTVItemID = c.BoxModelLanguageLastUpdateContactTVItemID,
                                             BoxModelLanguageLastUpdateContactTVText = c.BoxModelLanguageLastUpdateContactTVText,
                                             BoxModelLanguageLastUpdateDate_UTC = c.BoxModelLanguageLastUpdateDate_UTC,
                                             BoxModelLanguageScenarioName = c.BoxModelLanguageScenarioName,
                                             BoxModelLanguageTranslationStatus = c.BoxModelLanguageTranslationStatus,
                                             BoxModelLanguageTranslationStatusText = c.BoxModelLanguageTranslationStatusText,
                                             BoxModelLastUpdateContactTVItemID = c.BoxModelLastUpdateContactTVItemID,
                                             BoxModelLastUpdateContactTVText = c.BoxModelLastUpdateContactTVText,
                                             BoxModelLastUpdateDate_UTC = c.BoxModelLastUpdateDate_UTC,
                                             BoxModelResult = c.BoxModelResult,
                                             BoxModelResultBoxModelID = c.BoxModelResultBoxModelID,
                                             BoxModelResultBoxModelResultID = c.BoxModelResultBoxModelResultID,
                                             BoxModelResultBoxModelResultType = c.BoxModelResultBoxModelResultType,
                                             BoxModelResultBoxModelResultTypeText = c.BoxModelResultBoxModelResultTypeText,
                                             BoxModelResultCircleCenterLatitude = c.BoxModelResultCircleCenterLatitude,
                                             BoxModelResultCircleCenterLongitude = c.BoxModelResultCircleCenterLongitude,
                                             BoxModelResultFixLength = c.BoxModelResultFixLength,
                                             BoxModelResultFixWidth = c.BoxModelResultFixWidth,
                                             BoxModelResultHasErrors = c.BoxModelResultHasErrors,
                                             BoxModelResultLastUpdateContactTVItemID = c.BoxModelResultLastUpdateContactTVItemID,
                                             BoxModelResultLastUpdateContactTVText = c.BoxModelResultLastUpdateContactTVText,
                                             BoxModelResultLastUpdateDate_UTC = c.BoxModelResultLastUpdateDate_UTC,
                                             BoxModelResultLeftSideDiameterLineAngle_deg = c.BoxModelResultLeftSideDiameterLineAngle_deg,
                                             BoxModelResultLeftSideLineAngle_deg = c.BoxModelResultLeftSideLineAngle_deg,
                                             BoxModelResultLeftSideLineStartLatitude = c.BoxModelResultLeftSideLineStartLatitude,
                                             BoxModelResultLeftSideLineStartLongitude = c.BoxModelResultLeftSideLineStartLongitude,
                                             BoxModelResultRadius_m = c.BoxModelResultRadius_m,
                                             BoxModelResultRectLength_m = c.BoxModelResultRectLength_m,
                                             BoxModelResultRectWidth_m = c.BoxModelResultRectWidth_m,
                                             BoxModelResultSurface_m2 = c.BoxModelResultSurface_m2,
                                             BoxModelResultVolume_m3 = c.BoxModelResultVolume_m3,
                                             BoxModelT90_hour = c.BoxModelT90_hour,
                                             BoxModelTemperature_C = c.BoxModelTemperature_C,
                                             CalDecay = c.CalDecay,
                                             CalDecayDecay = c.CalDecayDecay,
                                             CalDecayError = c.CalDecayError,
                                             CalDecayHasErrors = c.CalDecayHasErrors,
                                             ClimateDataValue = c.ClimateDataValue,
                                             ClimateDataValueClimateDataValueID = c.ClimateDataValueClimateDataValueID,
                                             ClimateDataValueClimateSiteID = c.ClimateDataValueClimateSiteID,
                                             ClimateDataValueCoolDegDays_C = c.ClimateDataValueCoolDegDays_C,
                                             ClimateDataValueDateTime_Local = c.ClimateDataValueDateTime_Local,
                                             ClimateDataValueDirMaxGust_0North = c.ClimateDataValueDirMaxGust_0North,
                                             ClimateDataValueHasErrors = c.ClimateDataValueHasErrors,
                                             ClimateDataValueHeatDegDays_C = c.ClimateDataValueHeatDegDays_C,
                                             ClimateDataValueHourlyValues = c.ClimateDataValueHourlyValues,
                                             ClimateDataValueKeep = c.ClimateDataValueKeep,
                                             ClimateDataValueLastUpdateContactTVItemID = c.ClimateDataValueLastUpdateContactTVItemID,
                                             ClimateDataValueLastUpdateContactTVText = c.ClimateDataValueLastUpdateContactTVText,
                                             ClimateDataValueLastUpdateDate_UTC = c.ClimateDataValueLastUpdateDate_UTC,
                                             ClimateDataValueMaxTemp_C = c.ClimateDataValueMaxTemp_C,
                                             ClimateDataValueMinTemp_C = c.ClimateDataValueMinTemp_C,
                                             ClimateDataValueRainfall_mm = c.ClimateDataValueRainfall_mm,
                                             ClimateDataValueRainfallEntered_mm = c.ClimateDataValueRainfallEntered_mm,
                                             ClimateDataValueSnow_cm = c.ClimateDataValueSnow_cm,
                                             ClimateDataValueSnowOnGround_cm = c.ClimateDataValueSnowOnGround_cm,
                                             ClimateDataValueSpdMaxGust_kmh = c.ClimateDataValueSpdMaxGust_kmh,
                                             ClimateDataValueStorageDataType = c.ClimateDataValueStorageDataType,
                                             ClimateDataValueStorageDataTypeEnumText = c.ClimateDataValueStorageDataTypeEnumText,
                                             ClimateDataValueTotalPrecip_mm_cm = c.ClimateDataValueTotalPrecip_mm_cm,
                                             ClimateSite = c.ClimateSite,
                                             ClimateSiteClimateID = c.ClimateSiteClimateID,
                                             ClimateSiteClimateSiteID = c.ClimateSiteClimateSiteID,
                                             ClimateSiteClimateSiteName = c.ClimateSiteClimateSiteName,
                                             ClimateSiteClimateSiteTVItemID = c.ClimateSiteClimateSiteTVItemID,
                                             ClimateSiteClimateSiteTVText = c.ClimateSiteClimateSiteTVText,
                                             ClimateSiteDailyEndDate_Local = c.ClimateSiteDailyEndDate_Local,
                                             ClimateSiteDailyNow = c.ClimateSiteDailyNow,
                                             ClimateSiteDailyStartDate_Local = c.ClimateSiteDailyStartDate_Local,
                                             ClimateSiteECDBID = c.ClimateSiteECDBID,
                                             ClimateSiteElevation_m = c.ClimateSiteElevation_m,
                                             ClimateSiteFile_desc = c.ClimateSiteFile_desc,
                                             ClimateSiteHasErrors = c.ClimateSiteHasErrors,
                                             ClimateSiteHourlyEndDate_Local = c.ClimateSiteHourlyEndDate_Local,
                                             ClimateSiteHourlyNow = c.ClimateSiteHourlyNow,
                                             ClimateSiteHourlyStartDate_Local = c.ClimateSiteHourlyStartDate_Local,
                                             ClimateSiteIsProvincial = c.ClimateSiteIsProvincial,
                                             ClimateSiteLastUpdateContactTVItemID = c.ClimateSiteLastUpdateContactTVItemID,
                                             ClimateSiteLastUpdateContactTVText = c.ClimateSiteLastUpdateContactTVText,
                                             ClimateSiteLastUpdateDate_UTC = c.ClimateSiteLastUpdateDate_UTC,
                                             ClimateSiteMonthlyEndDate_Local = c.ClimateSiteMonthlyEndDate_Local,
                                             ClimateSiteMonthlyNow = c.ClimateSiteMonthlyNow,
                                             ClimateSiteMonthlyStartDate_Local = c.ClimateSiteMonthlyStartDate_Local,
                                             ClimateSiteProvince = c.ClimateSiteProvince,
                                             ClimateSiteProvSiteID = c.ClimateSiteProvSiteID,
                                             ClimateSiteTCID = c.ClimateSiteTCID,
                                             ClimateSiteTimeOffset_hour = c.ClimateSiteTimeOffset_hour,
                                             ClimateSiteWMOID = c.ClimateSiteWMOID,
                                             Contact = c.Contact,
                                             ContactContactID = c.ContactContactID,
                                             ContactContactTitle = c.ContactContactTitle,
                                             ContactContactTitleText = c.ContactContactTitleText,
                                             ContactContactTVItemID = c.ContactContactTVItemID,
                                             ContactContactTVText = c.ContactContactTVText,
                                             ContactDisabled = c.ContactDisabled,
                                             ContactEmailValidated = c.ContactEmailValidated,
                                             ContactFirstName = c.ContactFirstName,
                                             ContactHasErrors = c.ContactHasErrors,
                                             ContactId = c.ContactId,
                                             ContactInitial = c.ContactInitial,
                                             ContactIsAdmin = c.ContactIsAdmin,
                                             ContactIsNew = c.ContactIsNew,
                                             ContactLastName = c.ContactLastName,
                                             ContactLastUpdateContactTVItemID = c.ContactLastUpdateContactTVItemID,
                                             ContactLastUpdateContactTVText = c.ContactLastUpdateContactTVText,
                                             ContactLastUpdateDate_UTC = c.ContactLastUpdateDate_UTC,
                                             ContactLogin = c.ContactLogin,
                                             ContactLoginConfirmPassword = c.ContactLoginConfirmPassword,
                                             ContactLoginContactID = c.ContactLoginContactID,
                                             ContactLoginContactLoginID = c.ContactLoginContactLoginID,
                                             ContactLoginEmail = c.ContactLoginEmail,
                                             ContactLoginHasErrors = c.ContactLoginHasErrors,
                                             ContactLoginLastUpdateContactTVItemID = c.ContactLoginLastUpdateContactTVItemID,
                                             ContactLoginLastUpdateContactTVText = c.ContactLoginLastUpdateContactTVText,
                                             ContactLoginLastUpdateDate_UTC = c.ContactLoginLastUpdateDate_UTC,
                                             ContactLoginLoginEmail = c.ContactLoginLoginEmail,
                                             ContactLoginPassword = c.ContactLoginPassword,
                                             ContactLoginPasswordHash = c.ContactLoginPasswordHash,
                                             ContactLoginPasswordSalt = c.ContactLoginPasswordSalt,
                                             ContactOK = c.ContactOK,
                                             ContactOKContactID = c.ContactOKContactID,
                                             ContactOKContactTVItemID = c.ContactOKContactTVItemID,
                                             ContactOKError = c.ContactOKError,
                                             ContactOKHasErrors = c.ContactOKHasErrors,
                                             ContactParentTVItemID = c.ContactParentTVItemID,
                                             ContactPreference = c.ContactPreference,
                                             ContactPreferenceContactID = c.ContactPreferenceContactID,
                                             ContactPreferenceContactPreferenceID = c.ContactPreferenceContactPreferenceID,
                                             ContactPreferenceHasErrors = c.ContactPreferenceHasErrors,
                                             ContactPreferenceLastUpdateContactTVItemID = c.ContactPreferenceLastUpdateContactTVItemID,
                                             ContactPreferenceLastUpdateContactTVText = c.ContactPreferenceLastUpdateContactTVText,
                                             ContactPreferenceLastUpdateDate_UTC = c.ContactPreferenceLastUpdateDate_UTC,
                                             ContactPreferenceMarkerSize = c.ContactPreferenceMarkerSize,
                                             ContactPreferenceTVType = c.ContactPreferenceTVType,
                                             ContactPreferenceTVTypeText = c.ContactPreferenceTVTypeText,
                                             ContactSamplingPlanner_ProvincesTVItemID = c.ContactSamplingPlanner_ProvincesTVItemID,
                                             ContactSearch = c.ContactSearch,
                                             ContactSearchContactID = c.ContactSearchContactID,
                                             ContactSearchContactTVItemID = c.ContactSearchContactTVItemID,
                                             ContactSearchFullName = c.ContactSearchFullName,
                                             ContactSearchHasErrors = c.ContactSearchHasErrors,
                                             ContactShortcut = c.ContactShortcut,
                                             ContactShortcutContactID = c.ContactShortcutContactID,
                                             ContactShortcutContactShortcutID = c.ContactShortcutContactShortcutID,
                                             ContactShortcutHasErrors = c.ContactShortcutHasErrors,
                                             ContactShortcutLastUpdateContactTVItemID = c.ContactShortcutLastUpdateContactTVItemID,
                                             ContactShortcutLastUpdateContactTVText = c.ContactShortcutLastUpdateContactTVText,
                                             ContactShortcutLastUpdateDate_UTC = c.ContactShortcutLastUpdateDate_UTC,
                                             ContactShortcutShortCutAddress = c.ContactShortcutShortCutAddress,
                                             ContactShortcutShortCutText = c.ContactShortcutShortCutText,
                                             ContactWebName = c.ContactWebName,
                                             ContourPolygon = c.ContourPolygon,
                                             ContourPolygonContourNodeList = c.ContourPolygonContourNodeList,
                                             ContourPolygonContourValue = c.ContourPolygonContourValue,
                                             ContourPolygonDepth = c.ContourPolygonDepth,
                                             ContourPolygonHasErrors = c.ContourPolygonHasErrors,
                                             ContourPolygonLayer = c.ContourPolygonLayer,
                                             Coord = c.Coord,
                                             CoordHasErrors = c.CoordHasErrors,
                                             CoordLat = c.CoordLat,
                                             CoordLng = c.CoordLng,
                                             CoordOrdinal = c.CoordOrdinal,
                                             CSSPMPNTable = c.CSSPMPNTable,
                                             CSSPMPNTableHasErrors = c.CSSPMPNTableHasErrors,
                                             CSSPMPNTableMPN = c.CSSPMPNTableMPN,
                                             CSSPMPNTableTube0_1 = c.CSSPMPNTableTube0_1,
                                             CSSPMPNTableTube1_0 = c.CSSPMPNTableTube1_0,
                                             CSSPMPNTableTube10 = c.CSSPMPNTableTube10,
                                             CSSPWQInputApp = c.CSSPWQInputApp,
                                             CSSPWQInputAppAccessCode = c.CSSPWQInputAppAccessCode,
                                             CSSPWQInputAppActiveYear = c.CSSPWQInputAppActiveYear,
                                             CSSPWQInputAppApprovalCode = c.CSSPWQInputAppApprovalCode,
                                             CSSPWQInputAppApprovalDate = c.CSSPWQInputAppApprovalDate,
                                             CSSPWQInputAppDailyDuplicatePrecisionCriteria = c.CSSPWQInputAppDailyDuplicatePrecisionCriteria,
                                             CSSPWQInputAppHasErrors = c.CSSPWQInputAppHasErrors,
                                             CSSPWQInputAppIncludeLaboratoryQAQC = c.CSSPWQInputAppIncludeLaboratoryQAQC,
                                             CSSPWQInputAppIntertechDuplicatePrecisionCriteria = c.CSSPWQInputAppIntertechDuplicatePrecisionCriteria,
                                             CSSPWQInputParam = c.CSSPWQInputParam,
                                             CSSPWQInputParamCSSPWQInputType = c.CSSPWQInputParamCSSPWQInputType,
                                             CSSPWQInputParamCSSPWQInputTypeText = c.CSSPWQInputParamCSSPWQInputTypeText,
                                             CSSPWQInputParamDailyDuplicateMWQMSiteList = c.CSSPWQInputParamDailyDuplicateMWQMSiteList,
                                             CSSPWQInputParamDailyDuplicateMWQMSiteTVItemIDList = c.CSSPWQInputParamDailyDuplicateMWQMSiteTVItemIDList,
                                             CSSPWQInputParamHasErrors = c.CSSPWQInputParamHasErrors,
                                             CSSPWQInputParamInfrastructureList = c.CSSPWQInputParamInfrastructureList,
                                             CSSPWQInputParamInfrastructureTVItemIDList = c.CSSPWQInputParamInfrastructureTVItemIDList,
                                             CSSPWQInputParamMWQMSiteList = c.CSSPWQInputParamMWQMSiteList,
                                             CSSPWQInputParamMWQMSiteTVItemIDList = c.CSSPWQInputParamMWQMSiteTVItemIDList,
                                             CSSPWQInputParamName = c.CSSPWQInputParamName,
                                             CSSPWQInputParamsidList = c.CSSPWQInputParamsidList,
                                             CSSPWQInputParamTVItemID = c.CSSPWQInputParamTVItemID,
                                             DataPathOfTide = c.DataPathOfTide,
                                             DataPathOfTideHasErrors = c.DataPathOfTideHasErrors,
                                             DataPathOfTideText = c.DataPathOfTideText,
                                             DataPathOfTideWebTideDataSet = c.DataPathOfTideWebTideDataSet,
                                             DataPathOfTideWebTideDataSetText = c.DataPathOfTideWebTideDataSetText,
                                             DBTable = c.DBTable,
                                             DBTableHasErrors = c.DBTableHasErrors,
                                             DBTablePlurial = c.DBTablePlurial,
                                             DBTableTableName = c.DBTableTableName,
                                             DocTemplate = c.DocTemplate,
                                             DocTemplateDocTemplateID = c.DocTemplateDocTemplateID,
                                             DocTemplateFileName = c.DocTemplateFileName,
                                             DocTemplateHasErrors = c.DocTemplateHasErrors,
                                             DocTemplateLanguage = c.DocTemplateLanguage,
                                             DocTemplateLanguageText = c.DocTemplateLanguageText,
                                             DocTemplateLastUpdateContactTVItemID = c.DocTemplateLastUpdateContactTVItemID,
                                             DocTemplateLastUpdateContactTVText = c.DocTemplateLastUpdateContactTVText,
                                             DocTemplateLastUpdateDate_UTC = c.DocTemplateLastUpdateDate_UTC,
                                             DocTemplateTVFileTVItemID = c.DocTemplateTVFileTVItemID,
                                             DocTemplateTVType = c.DocTemplateTVType,
                                             DocTemplateTVTypeText = c.DocTemplateTVTypeText,
                                             Element = c.Element,
                                             ElementHasErrors = c.ElementHasErrors,
                                             ElementID = c.ElementID,
                                             ElementLayer = c.ElementLayer,
                                             ElementLayerElement = c.ElementLayerElement,
                                             ElementLayerHasErrors = c.ElementLayerHasErrors,
                                             ElementLayerLayer = c.ElementLayerLayer,
                                             ElementLayerZMax = c.ElementLayerZMax,
                                             ElementLayerZMin = c.ElementLayerZMin,
                                             ElementNodeList = c.ElementNodeList,
                                             ElementNumbOfNodes = c.ElementNumbOfNodes,
                                             ElementType = c.ElementType,
                                             ElementValue = c.ElementValue,
                                             ElementXNode0 = c.ElementXNode0,
                                             ElementYNode0 = c.ElementYNode0,
                                             ElementZNode0 = c.ElementZNode0,
                                             Email = c.Email,
                                             EmailDistributionList = c.EmailDistributionList,
                                             EmailDistributionListContact = c.EmailDistributionListContact,
                                             EmailDistributionListContactCMPRainfallSeasonal = c.EmailDistributionListContactCMPRainfallSeasonal,
                                             EmailDistributionListContactCMPWastewater = c.EmailDistributionListContactCMPWastewater,
                                             EmailDistributionListContactEmail = c.EmailDistributionListContactEmail,
                                             EmailDistributionListContactEmailDistributionListContactID = c.EmailDistributionListContactEmailDistributionListContactID,
                                             EmailDistributionListContactEmailDistributionListID = c.EmailDistributionListContactEmailDistributionListID,
                                             EmailDistributionListContactEmergencyWastewater = c.EmailDistributionListContactEmergencyWastewater,
                                             EmailDistributionListContactEmergencyWeather = c.EmailDistributionListContactEmergencyWeather,
                                             EmailDistributionListContactHasErrors = c.EmailDistributionListContactHasErrors,
                                             EmailDistributionListContactIsCC = c.EmailDistributionListContactIsCC,
                                             EmailDistributionListContactLanguage = c.EmailDistributionListContactLanguage,
                                             EmailDistributionListContactLanguageAgency = c.EmailDistributionListContactLanguageAgency,
                                             EmailDistributionListContactLanguageEmailDistributionListContactID = c.EmailDistributionListContactLanguageEmailDistributionListContactID,
                                             EmailDistributionListContactLanguageEmailDistributionListContactLanguageID = c.EmailDistributionListContactLanguageEmailDistributionListContactLanguageID,
                                             EmailDistributionListContactLanguageHasErrors = c.EmailDistributionListContactLanguageHasErrors,
                                             EmailDistributionListContactLanguageLanguage = c.EmailDistributionListContactLanguageLanguage,
                                             EmailDistributionListContactLanguageLanguageText = c.EmailDistributionListContactLanguageLanguageText,
                                             EmailDistributionListContactLanguageLastUpdateContactTVItemID = c.EmailDistributionListContactLanguageLastUpdateContactTVItemID,
                                             EmailDistributionListContactLanguageLastUpdateContactTVText = c.EmailDistributionListContactLanguageLastUpdateContactTVText,
                                             EmailDistributionListContactLanguageLastUpdateDate_UTC = c.EmailDistributionListContactLanguageLastUpdateDate_UTC,
                                             EmailDistributionListContactLanguageTranslationStatus = c.EmailDistributionListContactLanguageTranslationStatus,
                                             EmailDistributionListContactLanguageTranslationStatusText = c.EmailDistributionListContactLanguageTranslationStatusText,
                                             EmailDistributionListContactLastUpdateContactTVItemID = c.EmailDistributionListContactLastUpdateContactTVItemID,
                                             EmailDistributionListContactLastUpdateContactTVText = c.EmailDistributionListContactLastUpdateContactTVText,
                                             EmailDistributionListContactLastUpdateDate_UTC = c.EmailDistributionListContactLastUpdateDate_UTC,
                                             EmailDistributionListContactName = c.EmailDistributionListContactName,
                                             EmailDistributionListContactReopeningAllTypes = c.EmailDistributionListContactReopeningAllTypes,
                                             EmailDistributionListCountryTVItemID = c.EmailDistributionListCountryTVItemID,
                                             EmailDistributionListCountryTVText = c.EmailDistributionListCountryTVText,
                                             EmailDistributionListEmailDistributionListID = c.EmailDistributionListEmailDistributionListID,
                                             EmailDistributionListHasErrors = c.EmailDistributionListHasErrors,
                                             EmailDistributionListLanguage = c.EmailDistributionListLanguage,
                                             EmailDistributionListLanguageEmailDistributionListID = c.EmailDistributionListLanguageEmailDistributionListID,
                                             EmailDistributionListLanguageEmailDistributionListLanguageID = c.EmailDistributionListLanguageEmailDistributionListLanguageID,
                                             EmailDistributionListLanguageHasErrors = c.EmailDistributionListLanguageHasErrors,
                                             EmailDistributionListLanguageLanguage = c.EmailDistributionListLanguageLanguage,
                                             EmailDistributionListLanguageLanguageText = c.EmailDistributionListLanguageLanguageText,
                                             EmailDistributionListLanguageLastUpdateContactTVItemID = c.EmailDistributionListLanguageLastUpdateContactTVItemID,
                                             EmailDistributionListLanguageLastUpdateContactTVText = c.EmailDistributionListLanguageLastUpdateContactTVText,
                                             EmailDistributionListLanguageLastUpdateDate_UTC = c.EmailDistributionListLanguageLastUpdateDate_UTC,
                                             EmailDistributionListLanguageRegionName = c.EmailDistributionListLanguageRegionName,
                                             EmailDistributionListLanguageTranslationStatus = c.EmailDistributionListLanguageTranslationStatus,
                                             EmailDistributionListLanguageTranslationStatusText = c.EmailDistributionListLanguageTranslationStatusText,
                                             EmailDistributionListLastUpdateContactTVItemID = c.EmailDistributionListLastUpdateContactTVItemID,
                                             EmailDistributionListLastUpdateContactTVText = c.EmailDistributionListLastUpdateContactTVText,
                                             EmailDistributionListLastUpdateDate_UTC = c.EmailDistributionListLastUpdateDate_UTC,
                                             EmailDistributionListOrdinal = c.EmailDistributionListOrdinal,
                                             EmailEmailAddress = c.EmailEmailAddress,
                                             EmailEmailID = c.EmailEmailID,
                                             EmailEmailTVItemID = c.EmailEmailTVItemID,
                                             EmailEmailTVText = c.EmailEmailTVText,
                                             EmailEmailType = c.EmailEmailType,
                                             EmailEmailTypeText = c.EmailEmailTypeText,
                                             EmailHasErrors = c.EmailHasErrors,
                                             EmailLastUpdateContactTVItemID = c.EmailLastUpdateContactTVItemID,
                                             EmailLastUpdateContactTVText = c.EmailLastUpdateContactTVText,
                                             EmailLastUpdateDate_UTC = c.EmailLastUpdateDate_UTC,
                                             FileItem = c.FileItem,
                                             FileItemHasErrors = c.FileItemHasErrors,
                                             FileItemList = c.FileItemList,
                                             FileItemListFileName = c.FileItemListFileName,
                                             FileItemListHasErrors = c.FileItemListHasErrors,
                                             FileItemListText = c.FileItemListText,
                                             FileItemName = c.FileItemName,
                                             FileItemTVItemID = c.FileItemTVItemID,
                                             FilePurposeAndText = c.FilePurposeAndText,
                                             FilePurposeAndTextFilePurpose = c.FilePurposeAndTextFilePurpose,
                                             FilePurposeAndTextFilePurposeText = c.FilePurposeAndTextFilePurposeText,
                                             FilePurposeAndTextHasErrors = c.FilePurposeAndTextHasErrors,
                                             HydrometricDataValue = c.HydrometricDataValue,
                                             HydrometricDataValueDateTime_Local = c.HydrometricDataValueDateTime_Local,
                                             HydrometricDataValueFlow_m3_s = c.HydrometricDataValueFlow_m3_s,
                                             HydrometricDataValueHasErrors = c.HydrometricDataValueHasErrors,
                                             HydrometricDataValueHourlyValues = c.HydrometricDataValueHourlyValues,
                                             HydrometricDataValueHydrometricDataValueID = c.HydrometricDataValueHydrometricDataValueID,
                                             HydrometricDataValueHydrometricSiteID = c.HydrometricDataValueHydrometricSiteID,
                                             HydrometricDataValueKeep = c.HydrometricDataValueKeep,
                                             HydrometricDataValueLastUpdateContactTVItemID = c.HydrometricDataValueLastUpdateContactTVItemID,
                                             HydrometricDataValueLastUpdateContactTVText = c.HydrometricDataValueLastUpdateContactTVText,
                                             HydrometricDataValueLastUpdateDate_UTC = c.HydrometricDataValueLastUpdateDate_UTC,
                                             HydrometricDataValueStorageDataType = c.HydrometricDataValueStorageDataType,
                                             HydrometricDataValueStorageDataTypeText = c.HydrometricDataValueStorageDataTypeText,
                                             HydrometricSite = c.HydrometricSite,
                                             HydrometricSiteDescription = c.HydrometricSiteDescription,
                                             HydrometricSiteDrainageArea_km2 = c.HydrometricSiteDrainageArea_km2,
                                             HydrometricSiteElevation_m = c.HydrometricSiteElevation_m,
                                             HydrometricSiteEndDate_Local = c.HydrometricSiteEndDate_Local,
                                             HydrometricSiteFedSiteNumber = c.HydrometricSiteFedSiteNumber,
                                             HydrometricSiteHasErrors = c.HydrometricSiteHasErrors,
                                             HydrometricSiteHasRatingCurve = c.HydrometricSiteHasRatingCurve,
                                             HydrometricSiteHydrometricSiteID = c.HydrometricSiteHydrometricSiteID,
                                             HydrometricSiteHydrometricSiteName = c.HydrometricSiteHydrometricSiteName,
                                             HydrometricSiteHydrometricSiteTVItemID = c.HydrometricSiteHydrometricSiteTVItemID,
                                             HydrometricSiteHydrometricTVText = c.HydrometricSiteHydrometricTVText,
                                             HydrometricSiteIsActive = c.HydrometricSiteIsActive,
                                             HydrometricSiteIsNatural = c.HydrometricSiteIsNatural,
                                             HydrometricSiteLastUpdateContactTVItemID = c.HydrometricSiteLastUpdateContactTVItemID,
                                             HydrometricSiteLastUpdateContactTVText = c.HydrometricSiteLastUpdateContactTVText,
                                             HydrometricSiteLastUpdateDate_UTC = c.HydrometricSiteLastUpdateDate_UTC,
                                             HydrometricSiteProvince = c.HydrometricSiteProvince,
                                             HydrometricSiteQuebecSiteNumber = c.HydrometricSiteQuebecSiteNumber,
                                             HydrometricSiteRealTime = c.HydrometricSiteRealTime,
                                             HydrometricSiteRHBN = c.HydrometricSiteRHBN,
                                             HydrometricSiteSediment = c.HydrometricSiteSediment,
                                             HydrometricSiteStartDate_Local = c.HydrometricSiteStartDate_Local,
                                             HydrometricSiteTimeOffset_hour = c.HydrometricSiteTimeOffset_hour,
                                             Infrastructure = c.Infrastructure,
                                             InfrastructureAerationType = c.InfrastructureAerationType,
                                             InfrastructureAerationTypeText = c.InfrastructureAerationTypeText,
                                             InfrastructureAlarmSystemType = c.InfrastructureAlarmSystemType,
                                             InfrastructureAlarmSystemTypeText = c.InfrastructureAlarmSystemTypeText,
                                             InfrastructureAverageDepth_m = c.InfrastructureAverageDepth_m,
                                             InfrastructureAverageFlow_m3_day = c.InfrastructureAverageFlow_m3_day,
                                             InfrastructureCanOverflow = c.InfrastructureCanOverflow,
                                             InfrastructureCivicAddressTVItemID = c.InfrastructureCivicAddressTVItemID,
                                             InfrastructureCivicAddressTVText = c.InfrastructureCivicAddressTVText,
                                             InfrastructureCollectionSystemType = c.InfrastructureCollectionSystemType,
                                             InfrastructureCollectionSystemTypeText = c.InfrastructureCollectionSystemTypeText,
                                             InfrastructureDecayRate_per_day = c.InfrastructureDecayRate_per_day,
                                             InfrastructureDesignFlow_m3_day = c.InfrastructureDesignFlow_m3_day,
                                             InfrastructureDisinfectionType = c.InfrastructureDisinfectionType,
                                             InfrastructureDisinfectionTypeText = c.InfrastructureDisinfectionTypeText,
                                             InfrastructureDistanceFromShore_m = c.InfrastructureDistanceFromShore_m,
                                             InfrastructureFacilityType = c.InfrastructureFacilityType,
                                             InfrastructureFacilityTypeText = c.InfrastructureFacilityTypeText,
                                             InfrastructureFarFieldVelocity_m_s = c.InfrastructureFarFieldVelocity_m_s,
                                             InfrastructureHasErrors = c.InfrastructureHasErrors,
                                             InfrastructureHorizontalAngle_deg = c.InfrastructureHorizontalAngle_deg,
                                             InfrastructureInfrastructureCategory = c.InfrastructureInfrastructureCategory,
                                             InfrastructureInfrastructureID = c.InfrastructureInfrastructureID,
                                             InfrastructureInfrastructureTVItemID = c.InfrastructureInfrastructureTVItemID,
                                             InfrastructureInfrastructureTVText = c.InfrastructureInfrastructureTVText,
                                             InfrastructureInfrastructureType = c.InfrastructureInfrastructureType,
                                             InfrastructureInfrastructureTypeText = c.InfrastructureInfrastructureTypeText,
                                             InfrastructureIsMechanicallyAerated = c.InfrastructureIsMechanicallyAerated,
                                             InfrastructureLanguage = c.InfrastructureLanguage,
                                             InfrastructureLanguageComment = c.InfrastructureLanguageComment,
                                             InfrastructureLanguageHasErrors = c.InfrastructureLanguageHasErrors,
                                             InfrastructureLanguageInfrastructureID = c.InfrastructureLanguageInfrastructureID,
                                             InfrastructureLanguageInfrastructureLanguageID = c.InfrastructureLanguageInfrastructureLanguageID,
                                             InfrastructureLanguageLanguage = c.InfrastructureLanguageLanguage,
                                             InfrastructureLanguageLanguageText = c.InfrastructureLanguageLanguageText,
                                             InfrastructureLanguageLastUpdateContactTVItemID = c.InfrastructureLanguageLastUpdateContactTVItemID,
                                             InfrastructureLanguageLastUpdateContactTVText = c.InfrastructureLanguageLastUpdateContactTVText,
                                             InfrastructureLanguageLastUpdateDate_UTC = c.InfrastructureLanguageLastUpdateDate_UTC,
                                             InfrastructureLanguageTranslationStatus = c.InfrastructureLanguageTranslationStatus,
                                             InfrastructureLanguageTranslationStatusText = c.InfrastructureLanguageTranslationStatusText,
                                             InfrastructureLastUpdateContactTVItemID = c.InfrastructureLastUpdateContactTVItemID,
                                             InfrastructureLastUpdateContactTVText = c.InfrastructureLastUpdateContactTVText,
                                             InfrastructureLastUpdateDate_UTC = c.InfrastructureLastUpdateDate_UTC,
                                             InfrastructureLSID = c.InfrastructureLSID,
                                             InfrastructureNearFieldVelocity_m_s = c.InfrastructureNearFieldVelocity_m_s,
                                             InfrastructureNumberOfAeratedCells = c.InfrastructureNumberOfAeratedCells,
                                             InfrastructureNumberOfCells = c.InfrastructureNumberOfCells,
                                             InfrastructureNumberOfPorts = c.InfrastructureNumberOfPorts,
                                             InfrastructurePeakFlow_m3_day = c.InfrastructurePeakFlow_m3_day,
                                             InfrastructurePercFlowOfTotal = c.InfrastructurePercFlowOfTotal,
                                             InfrastructurePopServed = c.InfrastructurePopServed,
                                             InfrastructurePortDiameter_m = c.InfrastructurePortDiameter_m,
                                             InfrastructurePortElevation_m = c.InfrastructurePortElevation_m,
                                             InfrastructurePortSpacing_m = c.InfrastructurePortSpacing_m,
                                             InfrastructurePreliminaryTreatmentType = c.InfrastructurePreliminaryTreatmentType,
                                             InfrastructurePreliminaryTreatmentTypeText = c.InfrastructurePreliminaryTreatmentTypeText,
                                             InfrastructurePrimaryTreatmentType = c.InfrastructurePrimaryTreatmentType,
                                             InfrastructurePrimaryTreatmentTypeText = c.InfrastructurePrimaryTreatmentTypeText,
                                             InfrastructurePrismID = c.InfrastructurePrismID,
                                             InfrastructureReceivingWater_MPN_per_100ml = c.InfrastructureReceivingWater_MPN_per_100ml,
                                             InfrastructureReceivingWaterSalinity_PSU = c.InfrastructureReceivingWaterSalinity_PSU,
                                             InfrastructureReceivingWaterTemperature_C = c.InfrastructureReceivingWaterTemperature_C,
                                             InfrastructureSecondaryTreatmentType = c.InfrastructureSecondaryTreatmentType,
                                             InfrastructureSecondaryTreatmentTypeText = c.InfrastructureSecondaryTreatmentTypeText,
                                             InfrastructureSeeOtherTVItemID = c.InfrastructureSeeOtherTVItemID,
                                             InfrastructureSeeOtherTVText = c.InfrastructureSeeOtherTVText,
                                             InfrastructureSite = c.InfrastructureSite,
                                             InfrastructureSiteID = c.InfrastructureSiteID,
                                             InfrastructureTempCatchAllRemoveLater = c.InfrastructureTempCatchAllRemoveLater,
                                             InfrastructureTertiaryTreatmentType = c.InfrastructureTertiaryTreatmentType,
                                             InfrastructureTertiaryTreatmentTypeText = c.InfrastructureTertiaryTreatmentTypeText,
                                             InfrastructureTimeOffset_hour = c.InfrastructureTimeOffset_hour,
                                             InfrastructureTPID = c.InfrastructureTPID,
                                             InfrastructureTreatmentType = c.InfrastructureTreatmentType,
                                             InfrastructureTreatmentTypeText = c.InfrastructureTreatmentTypeText,
                                             InfrastructureVerticalAngle_deg = c.InfrastructureVerticalAngle_deg,
                                             InputSummary = c.InputSummary,
                                             InputSummaryError = c.InputSummaryError,
                                             InputSummaryHasErrors = c.InputSummaryHasErrors,
                                             InputSummarySummary = c.InputSummarySummary,
                                             LabSheet = c.LabSheet,
                                             LabSheetA1Measurement = c.LabSheetA1Measurement,
                                             LabSheetA1MeasurementHasErrors = c.LabSheetA1MeasurementHasErrors,
                                             LabSheetA1MeasurementMPN = c.LabSheetA1MeasurementMPN,
                                             LabSheetA1MeasurementProcessedBy = c.LabSheetA1MeasurementProcessedBy,
                                             LabSheetA1MeasurementSalinity = c.LabSheetA1MeasurementSalinity,
                                             LabSheetA1MeasurementSampleType = c.LabSheetA1MeasurementSampleType,
                                             LabSheetA1MeasurementSampleTypeText = c.LabSheetA1MeasurementSampleTypeText,
                                             LabSheetA1MeasurementSite = c.LabSheetA1MeasurementSite,
                                             LabSheetA1MeasurementSiteComment = c.LabSheetA1MeasurementSiteComment,
                                             LabSheetA1MeasurementTemperature = c.LabSheetA1MeasurementTemperature,
                                             LabSheetA1MeasurementTime = c.LabSheetA1MeasurementTime,
                                             LabSheetA1MeasurementTube0_1 = c.LabSheetA1MeasurementTube0_1,
                                             LabSheetA1MeasurementTube1_0 = c.LabSheetA1MeasurementTube1_0,
                                             LabSheetA1MeasurementTube10 = c.LabSheetA1MeasurementTube10,
                                             LabSheetA1MeasurementTVItemID = c.LabSheetA1MeasurementTVItemID,
                                             LabSheetA1Sheet = c.LabSheetA1Sheet,
                                             LabSheetA1SheetApprovalDay = c.LabSheetA1SheetApprovalDay,
                                             LabSheetA1SheetApprovalMonth = c.LabSheetA1SheetApprovalMonth,
                                             LabSheetA1SheetApprovalYear = c.LabSheetA1SheetApprovalYear,
                                             LabSheetA1SheetApprovedBySupervisorInitials = c.LabSheetA1SheetApprovedBySupervisorInitials,
                                             LabSheetA1SheetBath1Blank44_5 = c.LabSheetA1SheetBath1Blank44_5,
                                             LabSheetA1SheetBath1Negative44_5 = c.LabSheetA1SheetBath1Negative44_5,
                                             LabSheetA1SheetBath1NonTarget44_5 = c.LabSheetA1SheetBath1NonTarget44_5,
                                             LabSheetA1SheetBath1Positive44_5 = c.LabSheetA1SheetBath1Positive44_5,
                                             LabSheetA1SheetBath2Blank44_5 = c.LabSheetA1SheetBath2Blank44_5,
                                             LabSheetA1SheetBath2Negative44_5 = c.LabSheetA1SheetBath2Negative44_5,
                                             LabSheetA1SheetBath2NonTarget44_5 = c.LabSheetA1SheetBath2NonTarget44_5,
                                             LabSheetA1SheetBath2Positive44_5 = c.LabSheetA1SheetBath2Positive44_5,
                                             LabSheetA1SheetBath3Blank44_5 = c.LabSheetA1SheetBath3Blank44_5,
                                             LabSheetA1SheetBath3Negative44_5 = c.LabSheetA1SheetBath3Negative44_5,
                                             LabSheetA1SheetBath3NonTarget44_5 = c.LabSheetA1SheetBath3NonTarget44_5,
                                             LabSheetA1SheetBath3Positive44_5 = c.LabSheetA1SheetBath3Positive44_5,
                                             LabSheetA1SheetBlank35 = c.LabSheetA1SheetBlank35,
                                             LabSheetA1SheetControlLot = c.LabSheetA1SheetControlLot,
                                             LabSheetA1SheetDailyDuplicateAcceptableOrUnacceptable = c.LabSheetA1SheetDailyDuplicateAcceptableOrUnacceptable,
                                             LabSheetA1SheetDailyDuplicatePrecisionCriteria = c.LabSheetA1SheetDailyDuplicatePrecisionCriteria,
                                             LabSheetA1SheetDailyDuplicateRLog = c.LabSheetA1SheetDailyDuplicateRLog,
                                             LabSheetA1SheetError = c.LabSheetA1SheetError,
                                             LabSheetA1SheetHasErrors = c.LabSheetA1SheetHasErrors,
                                             LabSheetA1SheetIncludeLaboratoryQAQC = c.LabSheetA1SheetIncludeLaboratoryQAQC,
                                             LabSheetA1SheetIncubationBath1EndTime = c.LabSheetA1SheetIncubationBath1EndTime,
                                             LabSheetA1SheetIncubationBath1StartTime = c.LabSheetA1SheetIncubationBath1StartTime,
                                             LabSheetA1SheetIncubationBath1TimeCalculated = c.LabSheetA1SheetIncubationBath1TimeCalculated,
                                             LabSheetA1SheetIncubationBath2EndTime = c.LabSheetA1SheetIncubationBath2EndTime,
                                             LabSheetA1SheetIncubationBath2StartTime = c.LabSheetA1SheetIncubationBath2StartTime,
                                             LabSheetA1SheetIncubationBath2TimeCalculated = c.LabSheetA1SheetIncubationBath2TimeCalculated,
                                             LabSheetA1SheetIncubationBath3EndTime = c.LabSheetA1SheetIncubationBath3EndTime,
                                             LabSheetA1SheetIncubationBath3StartTime = c.LabSheetA1SheetIncubationBath3StartTime,
                                             LabSheetA1SheetIncubationBath3TimeCalculated = c.LabSheetA1SheetIncubationBath3TimeCalculated,
                                             LabSheetA1SheetIncubationStartSameDay = c.LabSheetA1SheetIncubationStartSameDay,
                                             LabSheetA1SheetIntertechDuplicateAcceptableOrUnacceptable = c.LabSheetA1SheetIntertechDuplicateAcceptableOrUnacceptable,
                                             LabSheetA1SheetIntertechDuplicatePrecisionCriteria = c.LabSheetA1SheetIntertechDuplicatePrecisionCriteria,
                                             LabSheetA1SheetIntertechDuplicateRLog = c.LabSheetA1SheetIntertechDuplicateRLog,
                                             LabSheetA1SheetIntertechReadAcceptableOrUnacceptable = c.LabSheetA1SheetIntertechReadAcceptableOrUnacceptable,
                                             LabSheetA1SheetLabSheetA1MeasurementList = c.LabSheetA1SheetLabSheetA1MeasurementList,
                                             LabSheetA1SheetLabSheetType = c.LabSheetA1SheetLabSheetType,
                                             LabSheetA1SheetLabSheetTypeText = c.LabSheetA1SheetLabSheetTypeText,
                                             LabSheetA1SheetLog = c.LabSheetA1SheetLog,
                                             LabSheetA1SheetLot35 = c.LabSheetA1SheetLot35,
                                             LabSheetA1SheetLot44_5 = c.LabSheetA1SheetLot44_5,
                                             LabSheetA1SheetNegative35 = c.LabSheetA1SheetNegative35,
                                             LabSheetA1SheetNonTarget35 = c.LabSheetA1SheetNonTarget35,
                                             LabSheetA1SheetPositive35 = c.LabSheetA1SheetPositive35,
                                             LabSheetA1SheetResultsReadBy = c.LabSheetA1SheetResultsReadBy,
                                             LabSheetA1SheetResultsReadDay = c.LabSheetA1SheetResultsReadDay,
                                             LabSheetA1SheetResultsReadMonth = c.LabSheetA1SheetResultsReadMonth,
                                             LabSheetA1SheetResultsReadYear = c.LabSheetA1SheetResultsReadYear,
                                             LabSheetA1SheetResultsRecordedBy = c.LabSheetA1SheetResultsRecordedBy,
                                             LabSheetA1SheetResultsRecordedDay = c.LabSheetA1SheetResultsRecordedDay,
                                             LabSheetA1SheetResultsRecordedMonth = c.LabSheetA1SheetResultsRecordedMonth,
                                             LabSheetA1SheetResultsRecordedYear = c.LabSheetA1SheetResultsRecordedYear,
                                             LabSheetA1SheetRunComment = c.LabSheetA1SheetRunComment,
                                             LabSheetA1SheetRunDay = c.LabSheetA1SheetRunDay,
                                             LabSheetA1SheetRunMonth = c.LabSheetA1SheetRunMonth,
                                             LabSheetA1SheetRunNumber = c.LabSheetA1SheetRunNumber,
                                             LabSheetA1SheetRunWeatherComment = c.LabSheetA1SheetRunWeatherComment,
                                             LabSheetA1SheetRunYear = c.LabSheetA1SheetRunYear,
                                             LabSheetA1SheetSalinitiesReadBy = c.LabSheetA1SheetSalinitiesReadBy,
                                             LabSheetA1SheetSalinitiesReadDay = c.LabSheetA1SheetSalinitiesReadDay,
                                             LabSheetA1SheetSalinitiesReadMonth = c.LabSheetA1SheetSalinitiesReadMonth,
                                             LabSheetA1SheetSalinitiesReadYear = c.LabSheetA1SheetSalinitiesReadYear,
                                             LabSheetA1SheetSampleBottleLotNumber = c.LabSheetA1SheetSampleBottleLotNumber,
                                             LabSheetA1SheetSampleCrewInitials = c.LabSheetA1SheetSampleCrewInitials,
                                             LabSheetA1SheetSampleType = c.LabSheetA1SheetSampleType,
                                             LabSheetA1SheetSampleTypeText = c.LabSheetA1SheetSampleTypeText,
                                             LabSheetA1SheetSamplingPlanType = c.LabSheetA1SheetSamplingPlanType,
                                             LabSheetA1SheetSamplingPlanTypeText = c.LabSheetA1SheetSamplingPlanTypeText,
                                             LabSheetA1SheetSubsectorLocation = c.LabSheetA1SheetSubsectorLocation,
                                             LabSheetA1SheetSubsectorName = c.LabSheetA1SheetSubsectorName,
                                             LabSheetA1SheetSubsectorTVItemID = c.LabSheetA1SheetSubsectorTVItemID,
                                             LabSheetA1SheetTCAverage = c.LabSheetA1SheetTCAverage,
                                             LabSheetA1SheetTCField1 = c.LabSheetA1SheetTCField1,
                                             LabSheetA1SheetTCField2 = c.LabSheetA1SheetTCField2,
                                             LabSheetA1SheetTCFirst = c.LabSheetA1SheetTCFirst,
                                             LabSheetA1SheetTCHas2Coolers = c.LabSheetA1SheetTCHas2Coolers,
                                             LabSheetA1SheetTCLab1 = c.LabSheetA1SheetTCLab1,
                                             LabSheetA1SheetTCLab2 = c.LabSheetA1SheetTCLab2,
                                             LabSheetA1SheetTides = c.LabSheetA1SheetTides,
                                             LabSheetA1SheetVersion = c.LabSheetA1SheetVersion,
                                             LabSheetA1SheetWaterBath1 = c.LabSheetA1SheetWaterBath1,
                                             LabSheetA1SheetWaterBath2 = c.LabSheetA1SheetWaterBath2,
                                             LabSheetA1SheetWaterBath3 = c.LabSheetA1SheetWaterBath3,
                                             LabSheetA1SheetWaterBathCount = c.LabSheetA1SheetWaterBathCount,
                                             LabSheetAcceptedOrRejectedByContactTVItemID = c.LabSheetAcceptedOrRejectedByContactTVItemID,
                                             LabSheetAcceptedOrRejectedByContactTVText = c.LabSheetAcceptedOrRejectedByContactTVText,
                                             LabSheetAcceptedOrRejectedDateTime = c.LabSheetAcceptedOrRejectedDateTime,
                                             LabSheetAndA1Sheet = c.LabSheetAndA1Sheet,
                                             LabSheetAndA1SheetHasErrors = c.LabSheetAndA1SheetHasErrors,
                                             LabSheetAndA1SheetLabSheet = c.LabSheetAndA1SheetLabSheet,
                                             LabSheetAndA1SheetLabSheetA1Sheet = c.LabSheetAndA1SheetLabSheetA1Sheet,
                                             LabSheetDay = c.LabSheetDay,
                                             LabSheetDetail = c.LabSheetDetail,
                                             LabSheetDetailBath1Blank44_5 = c.LabSheetDetailBath1Blank44_5,
                                             LabSheetDetailBath1Negative44_5 = c.LabSheetDetailBath1Negative44_5,
                                             LabSheetDetailBath1NonTarget44_5 = c.LabSheetDetailBath1NonTarget44_5,
                                             LabSheetDetailBath1Positive44_5 = c.LabSheetDetailBath1Positive44_5,
                                             LabSheetDetailBath2Blank44_5 = c.LabSheetDetailBath2Blank44_5,
                                             LabSheetDetailBath2Negative44_5 = c.LabSheetDetailBath2Negative44_5,
                                             LabSheetDetailBath2NonTarget44_5 = c.LabSheetDetailBath2NonTarget44_5,
                                             LabSheetDetailBath2Positive44_5 = c.LabSheetDetailBath2Positive44_5,
                                             LabSheetDetailBath3Blank44_5 = c.LabSheetDetailBath3Blank44_5,
                                             LabSheetDetailBath3Negative44_5 = c.LabSheetDetailBath3Negative44_5,
                                             LabSheetDetailBath3NonTarget44_5 = c.LabSheetDetailBath3NonTarget44_5,
                                             LabSheetDetailBath3Positive44_5 = c.LabSheetDetailBath3Positive44_5,
                                             LabSheetDetailBlank35 = c.LabSheetDetailBlank35,
                                             LabSheetDetailControlLot = c.LabSheetDetailControlLot,
                                             LabSheetDetailDailyDuplicateAcceptable = c.LabSheetDetailDailyDuplicateAcceptable,
                                             LabSheetDetailDailyDuplicatePrecisionCriteria = c.LabSheetDetailDailyDuplicatePrecisionCriteria,
                                             LabSheetDetailDailyDuplicateRLog = c.LabSheetDetailDailyDuplicateRLog,
                                             LabSheetDetailHasErrors = c.LabSheetDetailHasErrors,
                                             LabSheetDetailIncubationBath1EndTime = c.LabSheetDetailIncubationBath1EndTime,
                                             LabSheetDetailIncubationBath1StartTime = c.LabSheetDetailIncubationBath1StartTime,
                                             LabSheetDetailIncubationBath1TimeCalculated_minutes = c.LabSheetDetailIncubationBath1TimeCalculated_minutes,
                                             LabSheetDetailIncubationBath2EndTime = c.LabSheetDetailIncubationBath2EndTime,
                                             LabSheetDetailIncubationBath2StartTime = c.LabSheetDetailIncubationBath2StartTime,
                                             LabSheetDetailIncubationBath2TimeCalculated_minutes = c.LabSheetDetailIncubationBath2TimeCalculated_minutes,
                                             LabSheetDetailIncubationBath3EndTime = c.LabSheetDetailIncubationBath3EndTime,
                                             LabSheetDetailIncubationBath3StartTime = c.LabSheetDetailIncubationBath3StartTime,
                                             LabSheetDetailIncubationBath3TimeCalculated_minutes = c.LabSheetDetailIncubationBath3TimeCalculated_minutes,
                                             LabSheetDetailIntertechDuplicateAcceptable = c.LabSheetDetailIntertechDuplicateAcceptable,
                                             LabSheetDetailIntertechDuplicatePrecisionCriteria = c.LabSheetDetailIntertechDuplicatePrecisionCriteria,
                                             LabSheetDetailIntertechDuplicateRLog = c.LabSheetDetailIntertechDuplicateRLog,
                                             LabSheetDetailIntertechReadAcceptable = c.LabSheetDetailIntertechReadAcceptable,
                                             LabSheetDetailLabSheetDetailID = c.LabSheetDetailLabSheetDetailID,
                                             LabSheetDetailLabSheetID = c.LabSheetDetailLabSheetID,
                                             LabSheetDetailLastUpdateContactTVItemID = c.LabSheetDetailLastUpdateContactTVItemID,
                                             LabSheetDetailLastUpdateContactTVText = c.LabSheetDetailLastUpdateContactTVText,
                                             LabSheetDetailLastUpdateDate_UTC = c.LabSheetDetailLastUpdateDate_UTC,
                                             LabSheetDetailLot35 = c.LabSheetDetailLot35,
                                             LabSheetDetailLot44_5 = c.LabSheetDetailLot44_5,
                                             LabSheetDetailNegative35 = c.LabSheetDetailNegative35,
                                             LabSheetDetailNonTarget35 = c.LabSheetDetailNonTarget35,
                                             LabSheetDetailPositive35 = c.LabSheetDetailPositive35,
                                             LabSheetDetailResultsReadBy = c.LabSheetDetailResultsReadBy,
                                             LabSheetDetailResultsReadDate = c.LabSheetDetailResultsReadDate,
                                             LabSheetDetailResultsRecordedBy = c.LabSheetDetailResultsRecordedBy,
                                             LabSheetDetailResultsRecordedDate = c.LabSheetDetailResultsRecordedDate,
                                             LabSheetDetailRunComment = c.LabSheetDetailRunComment,
                                             LabSheetDetailRunDate = c.LabSheetDetailRunDate,
                                             LabSheetDetailRunWeatherComment = c.LabSheetDetailRunWeatherComment,
                                             LabSheetDetailSalinitiesReadBy = c.LabSheetDetailSalinitiesReadBy,
                                             LabSheetDetailSalinitiesReadDate = c.LabSheetDetailSalinitiesReadDate,
                                             LabSheetDetailSampleBottleLotNumber = c.LabSheetDetailSampleBottleLotNumber,
                                             LabSheetDetailSampleCrewInitials = c.LabSheetDetailSampleCrewInitials,
                                             LabSheetDetailSamplingPlanID = c.LabSheetDetailSamplingPlanID,
                                             LabSheetDetailSubsectorTVItemID = c.LabSheetDetailSubsectorTVItemID,
                                             LabSheetDetailSubsectorTVText = c.LabSheetDetailSubsectorTVText,
                                             LabSheetDetailTCAverage = c.LabSheetDetailTCAverage,
                                             LabSheetDetailTCField1 = c.LabSheetDetailTCField1,
                                             LabSheetDetailTCField2 = c.LabSheetDetailTCField2,
                                             LabSheetDetailTCFirst = c.LabSheetDetailTCFirst,
                                             LabSheetDetailTCLab1 = c.LabSheetDetailTCLab1,
                                             LabSheetDetailTCLab2 = c.LabSheetDetailTCLab2,
                                             LabSheetDetailTides = c.LabSheetDetailTides,
                                             LabSheetDetailVersion = c.LabSheetDetailVersion,
                                             LabSheetDetailWaterBath1 = c.LabSheetDetailWaterBath1,
                                             LabSheetDetailWaterBath2 = c.LabSheetDetailWaterBath2,
                                             LabSheetDetailWaterBath3 = c.LabSheetDetailWaterBath3,
                                             LabSheetDetailWaterBathCount = c.LabSheetDetailWaterBathCount,
                                             LabSheetDetailWeather = c.LabSheetDetailWeather,
                                             LabSheetFileContent = c.LabSheetFileContent,
                                             LabSheetFileLastModifiedDate_Local = c.LabSheetFileLastModifiedDate_Local,
                                             LabSheetFileName = c.LabSheetFileName,
                                             LabSheetHasErrors = c.LabSheetHasErrors,
                                             LabSheetLabSheetID = c.LabSheetLabSheetID,
                                             LabSheetLabSheetStatus = c.LabSheetLabSheetStatus,
                                             LabSheetLabSheetStatusText = c.LabSheetLabSheetStatusText,
                                             LabSheetLabSheetType = c.LabSheetLabSheetType,
                                             LabSheetLabSheetTypeText = c.LabSheetLabSheetTypeText,
                                             LabSheetLastUpdateContactTVItemID = c.LabSheetLastUpdateContactTVItemID,
                                             LabSheetLastUpdateContactTVText = c.LabSheetLastUpdateContactTVText,
                                             LabSheetLastUpdateDate_UTC = c.LabSheetLastUpdateDate_UTC,
                                             LabSheetMonth = c.LabSheetMonth,
                                             LabSheetMWQMRunTVItemID = c.LabSheetMWQMRunTVItemID,
                                             LabSheetMWQMRunTVText = c.LabSheetMWQMRunTVText,
                                             LabSheetOtherServerLabSheetID = c.LabSheetOtherServerLabSheetID,
                                             LabSheetRejectReason = c.LabSheetRejectReason,
                                             LabSheetRunNumber = c.LabSheetRunNumber,
                                             LabSheetSampleType = c.LabSheetSampleType,
                                             LabSheetSampleTypeText = c.LabSheetSampleTypeText,
                                             LabSheetSamplingPlanID = c.LabSheetSamplingPlanID,
                                             LabSheetSamplingPlanName = c.LabSheetSamplingPlanName,
                                             LabSheetSamplingPlanType = c.LabSheetSamplingPlanType,
                                             LabSheetSamplingPlanTypeText = c.LabSheetSamplingPlanTypeText,
                                             LabSheetSubsectorTVItemID = c.LabSheetSubsectorTVItemID,
                                             LabSheetSubsectorTVText = c.LabSheetSubsectorTVText,
                                             LabSheetTubeMPNDetail = c.LabSheetTubeMPNDetail,
                                             LabSheetTubeMPNDetailHasErrors = c.LabSheetTubeMPNDetailHasErrors,
                                             LabSheetTubeMPNDetailLabSheetDetailID = c.LabSheetTubeMPNDetailLabSheetDetailID,
                                             LabSheetTubeMPNDetailLabSheetTubeMPNDetailID = c.LabSheetTubeMPNDetailLabSheetTubeMPNDetailID,
                                             LabSheetTubeMPNDetailLastUpdateContactTVItemID = c.LabSheetTubeMPNDetailLastUpdateContactTVItemID,
                                             LabSheetTubeMPNDetailLastUpdateContactTVText = c.LabSheetTubeMPNDetailLastUpdateContactTVText,
                                             LabSheetTubeMPNDetailLastUpdateDate_UTC = c.LabSheetTubeMPNDetailLastUpdateDate_UTC,
                                             LabSheetTubeMPNDetailMPN = c.LabSheetTubeMPNDetailMPN,
                                             LabSheetTubeMPNDetailMWQMSiteTVItemID = c.LabSheetTubeMPNDetailMWQMSiteTVItemID,
                                             LabSheetTubeMPNDetailMWQMSiteTVText = c.LabSheetTubeMPNDetailMWQMSiteTVText,
                                             LabSheetTubeMPNDetailOrdinal = c.LabSheetTubeMPNDetailOrdinal,
                                             LabSheetTubeMPNDetailProcessedBy = c.LabSheetTubeMPNDetailProcessedBy,
                                             LabSheetTubeMPNDetailSalinity = c.LabSheetTubeMPNDetailSalinity,
                                             LabSheetTubeMPNDetailSampleDateTime = c.LabSheetTubeMPNDetailSampleDateTime,
                                             LabSheetTubeMPNDetailSampleType = c.LabSheetTubeMPNDetailSampleType,
                                             LabSheetTubeMPNDetailSampleTypeText = c.LabSheetTubeMPNDetailSampleTypeText,
                                             LabSheetTubeMPNDetailSiteComment = c.LabSheetTubeMPNDetailSiteComment,
                                             LabSheetTubeMPNDetailTemperature = c.LabSheetTubeMPNDetailTemperature,
                                             LabSheetTubeMPNDetailTube0_1 = c.LabSheetTubeMPNDetailTube0_1,
                                             LabSheetTubeMPNDetailTube1_0 = c.LabSheetTubeMPNDetailTube1_0,
                                             LabSheetTubeMPNDetailTube10 = c.LabSheetTubeMPNDetailTube10,
                                             LabSheetYear = c.LabSheetYear,
                                             LastUpdateAndContact = c.LastUpdateAndContact,
                                             LastUpdateAndContactError = c.LastUpdateAndContactError,
                                             LastUpdateAndContactHasErrors = c.LastUpdateAndContactHasErrors,
                                             LastUpdateAndContactLastUpdateContactTVItemID = c.LastUpdateAndContactLastUpdateContactTVItemID,
                                             LastUpdateAndContactLastUpdateDate_UTC = c.LastUpdateAndContactLastUpdateDate_UTC,
                                             LastUpdateAndTVText = c.LastUpdateAndTVText,
                                             LastUpdateAndTVTextError = c.LastUpdateAndTVTextError,
                                             LastUpdateAndTVTextHasErrors = c.LastUpdateAndTVTextHasErrors,
                                             LastUpdateAndTVTextLastUpdateDate_Local = c.LastUpdateAndTVTextLastUpdateDate_Local,
                                             LastUpdateAndTVTextLastUpdateDate_UTC = c.LastUpdateAndTVTextLastUpdateDate_UTC,
                                             LastUpdateAndTVTextTVText = c.LastUpdateAndTVTextTVText,
                                             LatLng = c.LatLng,
                                             LatLngHasErrors = c.LatLngHasErrors,
                                             LatLngLat = c.LatLngLat,
                                             LatLngLng = c.LatLngLng,
                                             Log = c.Log,
                                             LogHasErrors = c.LogHasErrors,
                                             LogID = c.LogID,
                                             Login = c.Login,
                                             LoginConfirmPassword = c.LoginConfirmPassword,
                                             LogInformation = c.LogInformation,
                                             LoginHasErrors = c.LoginHasErrors,
                                             LoginLoginEmail = c.LoginLoginEmail,
                                             LoginPassword = c.LoginPassword,
                                             LogLastUpdateContactTVItemID = c.LogLastUpdateContactTVItemID,
                                             LogLastUpdateContactTVText = c.LogLastUpdateContactTVText,
                                             LogLastUpdateDate_UTC = c.LogLastUpdateDate_UTC,
                                             LogLogCommand = c.LogLogCommand,
                                             LogLogCommandText = c.LogLogCommandText,
                                             LogLogID = c.LogLogID,
                                             LogTableName = c.LogTableName,
                                             MapInfo = c.MapInfo,
                                             MapInfoHasErrors = c.MapInfoHasErrors,
                                             MapInfoLastUpdateContactTVItemID = c.MapInfoLastUpdateContactTVItemID,
                                             MapInfoLastUpdateContactTVText = c.MapInfoLastUpdateContactTVText,
                                             MapInfoLastUpdateDate_UTC = c.MapInfoLastUpdateDate_UTC,
                                             MapInfoLatMax = c.MapInfoLatMax,
                                             MapInfoLatMin = c.MapInfoLatMin,
                                             MapInfoLngMax = c.MapInfoLngMax,
                                             MapInfoLngMin = c.MapInfoLngMin,
                                             MapInfoMapInfoDrawType = c.MapInfoMapInfoDrawType,
                                             MapInfoMapInfoDrawTypeText = c.MapInfoMapInfoDrawTypeText,
                                             MapInfoMapInfoID = c.MapInfoMapInfoID,
                                             MapInfoPoint = c.MapInfoPoint,
                                             MapInfoPointHasErrors = c.MapInfoPointHasErrors,
                                             MapInfoPointLastUpdateContactTVItemID = c.MapInfoPointLastUpdateContactTVItemID,
                                             MapInfoPointLastUpdateContactTVText = c.MapInfoPointLastUpdateContactTVText,
                                             MapInfoPointLastUpdateDate_UTC = c.MapInfoPointLastUpdateDate_UTC,
                                             MapInfoPointLat = c.MapInfoPointLat,
                                             MapInfoPointLng = c.MapInfoPointLng,
                                             MapInfoPointMapInfoID = c.MapInfoPointMapInfoID,
                                             MapInfoPointMapInfoPointID = c.MapInfoPointMapInfoPointID,
                                             MapInfoPointOrdinal = c.MapInfoPointOrdinal,
                                             MapInfoTVItemID = c.MapInfoTVItemID,
                                             MapInfoTVText = c.MapInfoTVText,
                                             MapInfoTVType = c.MapInfoTVType,
                                             MapInfoTVTypeText = c.MapInfoTVTypeText,
                                             MapObj = c.MapObj,
                                             MapObjCoordList = c.MapObjCoordList,
                                             MapObjHasErrors = c.MapObjHasErrors,
                                             MapObjMapInfoDrawType = c.MapObjMapInfoDrawType,
                                             MapObjMapInfoDrawTypeText = c.MapObjMapInfoDrawTypeText,
                                             MapObjMapInfoID = c.MapObjMapInfoID,
                                             MikeBoundaryCondition = c.MikeBoundaryCondition,
                                             MikeBoundaryConditionHasErrors = c.MikeBoundaryConditionHasErrors,
                                             MikeBoundaryConditionLastUpdateContactTVItemID = c.MikeBoundaryConditionLastUpdateContactTVItemID,
                                             MikeBoundaryConditionLastUpdateContactTVText = c.MikeBoundaryConditionLastUpdateContactTVText,
                                             MikeBoundaryConditionLastUpdateDate_UTC = c.MikeBoundaryConditionLastUpdateDate_UTC,
                                             MikeBoundaryConditionMikeBoundaryConditionCode = c.MikeBoundaryConditionMikeBoundaryConditionCode,
                                             MikeBoundaryConditionMikeBoundaryConditionFormat = c.MikeBoundaryConditionMikeBoundaryConditionFormat,
                                             MikeBoundaryConditionMikeBoundaryConditionID = c.MikeBoundaryConditionMikeBoundaryConditionID,
                                             MikeBoundaryConditionMikeBoundaryConditionLength_m = c.MikeBoundaryConditionMikeBoundaryConditionLength_m,
                                             MikeBoundaryConditionMikeBoundaryConditionLevelOrVelocity = c.MikeBoundaryConditionMikeBoundaryConditionLevelOrVelocity,
                                             MikeBoundaryConditionMikeBoundaryConditionLevelOrVelocityText = c.MikeBoundaryConditionMikeBoundaryConditionLevelOrVelocityText,
                                             MikeBoundaryConditionMikeBoundaryConditionName = c.MikeBoundaryConditionMikeBoundaryConditionName,
                                             MikeBoundaryConditionMikeBoundaryConditionTVItemID = c.MikeBoundaryConditionMikeBoundaryConditionTVItemID,
                                             MikeBoundaryConditionMikeBoundaryConditionTVText = c.MikeBoundaryConditionMikeBoundaryConditionTVText,
                                             MikeBoundaryConditionNumberOfWebTideNodes = c.MikeBoundaryConditionNumberOfWebTideNodes,
                                             MikeBoundaryConditionTVType = c.MikeBoundaryConditionTVType,
                                             MikeBoundaryConditionTVTypeText = c.MikeBoundaryConditionTVTypeText,
                                             MikeBoundaryConditionWebTideDataFromStartToEndDate = c.MikeBoundaryConditionWebTideDataFromStartToEndDate,
                                             MikeBoundaryConditionWebTideDataSet = c.MikeBoundaryConditionWebTideDataSet,
                                             MikeBoundaryConditionWebTideDataSetText = c.MikeBoundaryConditionWebTideDataSetText,
                                             MikeScenario = c.MikeScenario,
                                             MikeScenarioAmbientSalinity_PSU = c.MikeScenarioAmbientSalinity_PSU,
                                             MikeScenarioAmbientTemperature_C = c.MikeScenarioAmbientTemperature_C,
                                             MikeScenarioDecayFactor_per_day = c.MikeScenarioDecayFactor_per_day,
                                             MikeScenarioDecayFactorAmplitude = c.MikeScenarioDecayFactorAmplitude,
                                             MikeScenarioDecayIsConstant = c.MikeScenarioDecayIsConstant,
                                             MikeScenarioErrorInfo = c.MikeScenarioErrorInfo,
                                             MikeScenarioEstimatedHydroFileSize = c.MikeScenarioEstimatedHydroFileSize,
                                             MikeScenarioEstimatedTransFileSize = c.MikeScenarioEstimatedTransFileSize,
                                             MikeScenarioHasErrors = c.MikeScenarioHasErrors,
                                             MikeScenarioLastUpdateContactTVItemID = c.MikeScenarioLastUpdateContactTVItemID,
                                             MikeScenarioLastUpdateContactTVText = c.MikeScenarioLastUpdateContactTVText,
                                             MikeScenarioLastUpdateDate_UTC = c.MikeScenarioLastUpdateDate_UTC,
                                             MikeScenarioManningNumber = c.MikeScenarioManningNumber,
                                             MikeScenarioMikeScenarioEndDateTime_Local = c.MikeScenarioMikeScenarioEndDateTime_Local,
                                             MikeScenarioMikeScenarioExecutionTime_min = c.MikeScenarioMikeScenarioExecutionTime_min,
                                             MikeScenarioMikeScenarioID = c.MikeScenarioMikeScenarioID,
                                             MikeScenarioMikeScenarioStartDateTime_Local = c.MikeScenarioMikeScenarioStartDateTime_Local,
                                             MikeScenarioMikeScenarioStartExecutionDateTime_Local = c.MikeScenarioMikeScenarioStartExecutionDateTime_Local,
                                             MikeScenarioMikeScenarioTVItemID = c.MikeScenarioMikeScenarioTVItemID,
                                             MikeScenarioMikeScenarioTVText = c.MikeScenarioMikeScenarioTVText,
                                             MikeScenarioNumberOfElements = c.MikeScenarioNumberOfElements,
                                             MikeScenarioNumberOfHydroOutputParameters = c.MikeScenarioNumberOfHydroOutputParameters,
                                             MikeScenarioNumberOfSigmaLayers = c.MikeScenarioNumberOfSigmaLayers,
                                             MikeScenarioNumberOfTimeSteps = c.MikeScenarioNumberOfTimeSteps,
                                             MikeScenarioNumberOfTransOutputParameters = c.MikeScenarioNumberOfTransOutputParameters,
                                             MikeScenarioNumberOfZLayers = c.MikeScenarioNumberOfZLayers,
                                             MikeScenarioParentMikeScenarioID = c.MikeScenarioParentMikeScenarioID,
                                             MikeScenarioResultFrequency_min = c.MikeScenarioResultFrequency_min,
                                             MikeScenarioScenarioStatus = c.MikeScenarioScenarioStatus,
                                             MikeScenarioScenarioStatusText = c.MikeScenarioScenarioStatusText,
                                             MikeScenarioWindDirection_deg = c.MikeScenarioWindDirection_deg,
                                             MikeScenarioWindSpeed_km_h = c.MikeScenarioWindSpeed_km_h,
                                             MikeSource = c.MikeSource,
                                             MikeSourceHasErrors = c.MikeSourceHasErrors,
                                             MikeSourceInclude = c.MikeSourceInclude,
                                             MikeSourceIsContinuous = c.MikeSourceIsContinuous,
                                             MikeSourceIsRiver = c.MikeSourceIsRiver,
                                             MikeSourceLastUpdateContactTVItemID = c.MikeSourceLastUpdateContactTVItemID,
                                             MikeSourceLastUpdateContactTVText = c.MikeSourceLastUpdateContactTVText,
                                             MikeSourceLastUpdateDate_UTC = c.MikeSourceLastUpdateDate_UTC,
                                             MikeSourceMikeSourceID = c.MikeSourceMikeSourceID,
                                             MikeSourceMikeSourceTVItemID = c.MikeSourceMikeSourceTVItemID,
                                             MikeSourceMikeSourceTVText = c.MikeSourceMikeSourceTVText,
                                             MikeSourceSourceNumberString = c.MikeSourceSourceNumberString,
                                             MikeSourceStartEnd = c.MikeSourceStartEnd,
                                             MikeSourceStartEndEndDateAndTime_Local = c.MikeSourceStartEndEndDateAndTime_Local,
                                             MikeSourceStartEndHasErrors = c.MikeSourceStartEndHasErrors,
                                             MikeSourceStartEndLastUpdateContactTVItemID = c.MikeSourceStartEndLastUpdateContactTVItemID,
                                             MikeSourceStartEndLastUpdateContactTVText = c.MikeSourceStartEndLastUpdateContactTVText,
                                             MikeSourceStartEndLastUpdateDate_UTC = c.MikeSourceStartEndLastUpdateDate_UTC,
                                             MikeSourceStartEndMikeSourceID = c.MikeSourceStartEndMikeSourceID,
                                             MikeSourceStartEndMikeSourceStartEndID = c.MikeSourceStartEndMikeSourceStartEndID,
                                             MikeSourceStartEndSourceFlowEnd_m3_day = c.MikeSourceStartEndSourceFlowEnd_m3_day,
                                             MikeSourceStartEndSourceFlowStart_m3_day = c.MikeSourceStartEndSourceFlowStart_m3_day,
                                             MikeSourceStartEndSourcePollutionEnd_MPN_100ml = c.MikeSourceStartEndSourcePollutionEnd_MPN_100ml,
                                             MikeSourceStartEndSourcePollutionStart_MPN_100ml = c.MikeSourceStartEndSourcePollutionStart_MPN_100ml,
                                             MikeSourceStartEndSourceSalinityEnd_PSU = c.MikeSourceStartEndSourceSalinityEnd_PSU,
                                             MikeSourceStartEndSourceSalinityStart_PSU = c.MikeSourceStartEndSourceSalinityStart_PSU,
                                             MikeSourceStartEndSourceTemperatureEnd_C = c.MikeSourceStartEndSourceTemperatureEnd_C,
                                             MikeSourceStartEndSourceTemperatureStart_C = c.MikeSourceStartEndSourceTemperatureStart_C,
                                             MikeSourceStartEndStartDateAndTime_Local = c.MikeSourceStartEndStartDateAndTime_Local,
                                             MWQMAnalysisReportParameter = c.MWQMAnalysisReportParameter,
                                             MWQMAnalysisReportParameterAnalysisCalculationType = c.MWQMAnalysisReportParameterAnalysisCalculationType,
                                             MWQMAnalysisReportParameterAnalysisName = c.MWQMAnalysisReportParameterAnalysisName,
                                             MWQMAnalysisReportParameterAnalysisReportYear = c.MWQMAnalysisReportParameterAnalysisReportYear,
                                             MWQMAnalysisReportParameterDryLimit24h = c.MWQMAnalysisReportParameterDryLimit24h,
                                             MWQMAnalysisReportParameterDryLimit48h = c.MWQMAnalysisReportParameterDryLimit48h,
                                             MWQMAnalysisReportParameterDryLimit72h = c.MWQMAnalysisReportParameterDryLimit72h,
                                             MWQMAnalysisReportParameterDryLimit96h = c.MWQMAnalysisReportParameterDryLimit96h,
                                             MWQMAnalysisReportParameterEndDate = c.MWQMAnalysisReportParameterEndDate,
                                             MWQMAnalysisReportParameterFullYear = c.MWQMAnalysisReportParameterFullYear,
                                             MWQMAnalysisReportParameterHasErrors = c.MWQMAnalysisReportParameterHasErrors,
                                             MWQMAnalysisReportParameterLastUpdateContactTVItemID = c.MWQMAnalysisReportParameterLastUpdateContactTVItemID,
                                             MWQMAnalysisReportParameterLastUpdateContactTVText = c.MWQMAnalysisReportParameterLastUpdateContactTVText,
                                             MWQMAnalysisReportParameterLastUpdateDate_UTC = c.MWQMAnalysisReportParameterLastUpdateDate_UTC,
                                             MWQMAnalysisReportParameterMidRangeNumberOfDays = c.MWQMAnalysisReportParameterMidRangeNumberOfDays,
                                             MWQMAnalysisReportParameterMWQMAnalysisReportParameterID = c.MWQMAnalysisReportParameterMWQMAnalysisReportParameterID,
                                             MWQMAnalysisReportParameterNumberOfRuns = c.MWQMAnalysisReportParameterNumberOfRuns,
                                             MWQMAnalysisReportParameterRunsToOmit = c.MWQMAnalysisReportParameterRunsToOmit,
                                             MWQMAnalysisReportParameterSalinityHighlightDeviationFromAverage = c.MWQMAnalysisReportParameterSalinityHighlightDeviationFromAverage,
                                             MWQMAnalysisReportParameterShortRangeNumberOfDays = c.MWQMAnalysisReportParameterShortRangeNumberOfDays,
                                             MWQMAnalysisReportParameterStartDate = c.MWQMAnalysisReportParameterStartDate,
                                             MWQMAnalysisReportParameterSubsectorTVItemID = c.MWQMAnalysisReportParameterSubsectorTVItemID,
                                             MWQMAnalysisReportParameterWetLimit24h = c.MWQMAnalysisReportParameterWetLimit24h,
                                             MWQMAnalysisReportParameterWetLimit48h = c.MWQMAnalysisReportParameterWetLimit48h,
                                             MWQMAnalysisReportParameterWetLimit72h = c.MWQMAnalysisReportParameterWetLimit72h,
                                             MWQMAnalysisReportParameterWetLimit96h = c.MWQMAnalysisReportParameterWetLimit96h,
                                             MWQMLookupMPN = c.MWQMLookupMPN,
                                             MWQMLookupMPNHasErrors = c.MWQMLookupMPNHasErrors,
                                             MWQMLookupMPNLastUpdateContactTVItemID = c.MWQMLookupMPNLastUpdateContactTVItemID,
                                             MWQMLookupMPNLastUpdateContactTVText = c.MWQMLookupMPNLastUpdateContactTVText,
                                             MWQMLookupMPNLastUpdateDate_UTC = c.MWQMLookupMPNLastUpdateDate_UTC,
                                             MWQMLookupMPNMPN_100ml = c.MWQMLookupMPNMPN_100ml,
                                             MWQMLookupMPNMWQMLookupMPNID = c.MWQMLookupMPNMWQMLookupMPNID,
                                             MWQMLookupMPNTubes01 = c.MWQMLookupMPNTubes01,
                                             MWQMLookupMPNTubes1 = c.MWQMLookupMPNTubes1,
                                             MWQMLookupMPNTubes10 = c.MWQMLookupMPNTubes10,
                                             MWQMRun = c.MWQMRun,
                                             MWQMRunAnalyzeMethod = c.MWQMRunAnalyzeMethod,
                                             MWQMRunAnalyzeMethodText = c.MWQMRunAnalyzeMethodText,
                                             MWQMRunDateTime_Local = c.MWQMRunDateTime_Local,
                                             MWQMRunEndDateTime_Local = c.MWQMRunEndDateTime_Local,
                                             MWQMRunHasErrors = c.MWQMRunHasErrors,
                                             MWQMRunLabAnalyzeBath1IncubationStartDateTime_Local = c.MWQMRunLabAnalyzeBath1IncubationStartDateTime_Local,
                                             MWQMRunLabAnalyzeBath2IncubationStartDateTime_Local = c.MWQMRunLabAnalyzeBath2IncubationStartDateTime_Local,
                                             MWQMRunLabAnalyzeBath3IncubationStartDateTime_Local = c.MWQMRunLabAnalyzeBath3IncubationStartDateTime_Local,
                                             MWQMRunLaboratory = c.MWQMRunLaboratory,
                                             MWQMRunLaboratoryText = c.MWQMRunLaboratoryText,
                                             MWQMRunLabReceivedDateTime_Local = c.MWQMRunLabReceivedDateTime_Local,
                                             MWQMRunLabRunSampleApprovalDateTime_Local = c.MWQMRunLabRunSampleApprovalDateTime_Local,
                                             MWQMRunLabSampleApprovalContactTVItemID = c.MWQMRunLabSampleApprovalContactTVItemID,
                                             MWQMRunLabSampleApprovalContactTVText = c.MWQMRunLabSampleApprovalContactTVText,
                                             MWQMRunLanguage = c.MWQMRunLanguage,
                                             MWQMRunLanguageHasErrors = c.MWQMRunLanguageHasErrors,
                                             MWQMRunLanguageLanguage = c.MWQMRunLanguageLanguage,
                                             MWQMRunLanguageLanguageText = c.MWQMRunLanguageLanguageText,
                                             MWQMRunLanguageLastUpdateContactTVItemID = c.MWQMRunLanguageLastUpdateContactTVItemID,
                                             MWQMRunLanguageLastUpdateContactTVText = c.MWQMRunLanguageLastUpdateContactTVText,
                                             MWQMRunLanguageLastUpdateDate_UTC = c.MWQMRunLanguageLastUpdateDate_UTC,
                                             MWQMRunLanguageMWQMRunID = c.MWQMRunLanguageMWQMRunID,
                                             MWQMRunLanguageMWQMRunLanguageID = c.MWQMRunLanguageMWQMRunLanguageID,
                                             MWQMRunLanguageRunComment = c.MWQMRunLanguageRunComment,
                                             MWQMRunLanguageRunWeatherComment = c.MWQMRunLanguageRunWeatherComment,
                                             MWQMRunLanguageTranslationStatusRunComment = c.MWQMRunLanguageTranslationStatusRunComment,
                                             MWQMRunLanguageTranslationStatusRunCommentText = c.MWQMRunLanguageTranslationStatusRunCommentText,
                                             MWQMRunLanguageTranslationStatusRunWeatherComment = c.MWQMRunLanguageTranslationStatusRunWeatherComment,
                                             MWQMRunLanguageTranslationStatusRunWeatherCommentText = c.MWQMRunLanguageTranslationStatusRunWeatherCommentText,
                                             MWQMRunLastUpdateContactTVItemID = c.MWQMRunLastUpdateContactTVItemID,
                                             MWQMRunLastUpdateContactTVText = c.MWQMRunLastUpdateContactTVText,
                                             MWQMRunLastUpdateDate_UTC = c.MWQMRunLastUpdateDate_UTC,
                                             MWQMRunMWQMRunID = c.MWQMRunMWQMRunID,
                                             MWQMRunMWQMRunTVItemID = c.MWQMRunMWQMRunTVItemID,
                                             MWQMRunMWQMRunTVText = c.MWQMRunMWQMRunTVText,
                                             MWQMRunRainDay0_mm = c.MWQMRunRainDay0_mm,
                                             MWQMRunRainDay1_mm = c.MWQMRunRainDay1_mm,
                                             MWQMRunRainDay10_mm = c.MWQMRunRainDay10_mm,
                                             MWQMRunRainDay2_mm = c.MWQMRunRainDay2_mm,
                                             MWQMRunRainDay3_mm = c.MWQMRunRainDay3_mm,
                                             MWQMRunRainDay4_mm = c.MWQMRunRainDay4_mm,
                                             MWQMRunRainDay5_mm = c.MWQMRunRainDay5_mm,
                                             MWQMRunRainDay6_mm = c.MWQMRunRainDay6_mm,
                                             MWQMRunRainDay7_mm = c.MWQMRunRainDay7_mm,
                                             MWQMRunRainDay8_mm = c.MWQMRunRainDay8_mm,
                                             MWQMRunRainDay9_mm = c.MWQMRunRainDay9_mm,
                                             MWQMRunRemoveFromStat = c.MWQMRunRemoveFromStat,
                                             MWQMRunRunNumber = c.MWQMRunRunNumber,
                                             MWQMRunRunSampleType = c.MWQMRunRunSampleType,
                                             MWQMRunRunSampleTypeText = c.MWQMRunRunSampleTypeText,
                                             MWQMRunSampleCrewInitials = c.MWQMRunSampleCrewInitials,
                                             MWQMRunSampleMatrix = c.MWQMRunSampleMatrix,
                                             MWQMRunSampleMatrixText = c.MWQMRunSampleMatrixText,
                                             MWQMRunSampleStatus = c.MWQMRunSampleStatus,
                                             MWQMRunSampleStatusText = c.MWQMRunSampleStatusText,
                                             MWQMRunSeaStateAtEnd_BeaufortScale = c.MWQMRunSeaStateAtEnd_BeaufortScale,
                                             MWQMRunSeaStateAtEnd_BeaufortScaleText = c.MWQMRunSeaStateAtEnd_BeaufortScaleText,
                                             MWQMRunSeaStateAtStart_BeaufortScale = c.MWQMRunSeaStateAtStart_BeaufortScale,
                                             MWQMRunSeaStateAtStart_BeaufortScaleText = c.MWQMRunSeaStateAtStart_BeaufortScaleText,
                                             MWQMRunStartDateTime_Local = c.MWQMRunStartDateTime_Local,
                                             MWQMRunSubsectorTVItemID = c.MWQMRunSubsectorTVItemID,
                                             MWQMRunSubsectorTVText = c.MWQMRunSubsectorTVText,
                                             MWQMRunTemperatureControl1_C = c.MWQMRunTemperatureControl1_C,
                                             MWQMRunTemperatureControl2_C = c.MWQMRunTemperatureControl2_C,
                                             MWQMRunTide_End = c.MWQMRunTide_End,
                                             MWQMRunTide_EndText = c.MWQMRunTide_EndText,
                                             MWQMRunTide_Start = c.MWQMRunTide_Start,
                                             MWQMRunTide_StartText = c.MWQMRunTide_StartText,
                                             MWQMRunWaterLevelAtBrook_m = c.MWQMRunWaterLevelAtBrook_m,
                                             MWQMRunWaveHightAtEnd_m = c.MWQMRunWaveHightAtEnd_m,
                                             MWQMRunWaveHightAtStart_m = c.MWQMRunWaveHightAtStart_m,
                                             MWQMSample = c.MWQMSample,
                                             MWQMSampleDepth_m = c.MWQMSampleDepth_m,
                                             MWQMSampleDuplicateItem = c.MWQMSampleDuplicateItem,
                                             MWQMSampleDuplicateItemDuplicateSite = c.MWQMSampleDuplicateItemDuplicateSite,
                                             MWQMSampleDuplicateItemHasErrors = c.MWQMSampleDuplicateItemHasErrors,
                                             MWQMSampleDuplicateItemParentSite = c.MWQMSampleDuplicateItemParentSite,
                                             MWQMSampleFecCol_MPN_100ml = c.MWQMSampleFecCol_MPN_100ml,
                                             MWQMSampleHasErrors = c.MWQMSampleHasErrors,
                                             MWQMSampleLanguage = c.MWQMSampleLanguage,
                                             MWQMSampleLanguageHasErrors = c.MWQMSampleLanguageHasErrors,
                                             MWQMSampleLanguageLanguage = c.MWQMSampleLanguageLanguage,
                                             MWQMSampleLanguageLanguageText = c.MWQMSampleLanguageLanguageText,
                                             MWQMSampleLanguageLastUpdateContactTVItemID = c.MWQMSampleLanguageLastUpdateContactTVItemID,
                                             MWQMSampleLanguageLastUpdateContactTVText = c.MWQMSampleLanguageLastUpdateContactTVText,
                                             MWQMSampleLanguageLastUpdateDate_UTC = c.MWQMSampleLanguageLastUpdateDate_UTC,
                                             MWQMSampleLanguageMWQMSampleID = c.MWQMSampleLanguageMWQMSampleID,
                                             MWQMSampleLanguageMWQMSampleLanguageID = c.MWQMSampleLanguageMWQMSampleLanguageID,
                                             MWQMSampleLanguageMWQMSampleNote = c.MWQMSampleLanguageMWQMSampleNote,
                                             MWQMSampleLanguageTranslationStatus = c.MWQMSampleLanguageTranslationStatus,
                                             MWQMSampleLanguageTranslationStatusText = c.MWQMSampleLanguageTranslationStatusText,
                                             MWQMSampleLastUpdateContactTVItemID = c.MWQMSampleLastUpdateContactTVItemID,
                                             MWQMSampleLastUpdateContactTVText = c.MWQMSampleLastUpdateContactTVText,
                                             MWQMSampleLastUpdateDate_UTC = c.MWQMSampleLastUpdateDate_UTC,
                                             MWQMSampleMWQMRunTVItemID = c.MWQMSampleMWQMRunTVItemID,
                                             MWQMSampleMWQMRunTVText = c.MWQMSampleMWQMRunTVText,
                                             MWQMSampleMWQMSampleID = c.MWQMSampleMWQMSampleID,
                                             MWQMSampleMWQMSiteTVItemID = c.MWQMSampleMWQMSiteTVItemID,
                                             MWQMSampleMWQMSiteTVText = c.MWQMSampleMWQMSiteTVText,
                                             MWQMSamplePH = c.MWQMSamplePH,
                                             MWQMSampleProcessedBy = c.MWQMSampleProcessedBy,
                                             MWQMSampleSalinity_PPT = c.MWQMSampleSalinity_PPT,
                                             MWQMSampleSampleDateTime_Local = c.MWQMSampleSampleDateTime_Local,
                                             MWQMSampleSampleType_old = c.MWQMSampleSampleType_old,
                                             MWQMSampleSampleType_oldText = c.MWQMSampleSampleType_oldText,
                                             MWQMSampleSampleTypesText = c.MWQMSampleSampleTypesText,
                                             MWQMSampleTube_0_1 = c.MWQMSampleTube_0_1,
                                             MWQMSampleTube_1_0 = c.MWQMSampleTube_1_0,
                                             MWQMSampleTube_10 = c.MWQMSampleTube_10,
                                             MWQMSampleWaterTemp_C = c.MWQMSampleWaterTemp_C,
                                             MWQMSite = c.MWQMSite,
                                             MWQMSiteHasErrors = c.MWQMSiteHasErrors,
                                             MWQMSiteLastUpdateContactTVItemID = c.MWQMSiteLastUpdateContactTVItemID,
                                             MWQMSiteLastUpdateContactTVText = c.MWQMSiteLastUpdateContactTVText,
                                             MWQMSiteLastUpdateDate_UTC = c.MWQMSiteLastUpdateDate_UTC,
                                             MWQMSiteMWQMSiteDescription = c.MWQMSiteMWQMSiteDescription,
                                             MWQMSiteMWQMSiteID = c.MWQMSiteMWQMSiteID,
                                             MWQMSiteMWQMSiteLatestClassification = c.MWQMSiteMWQMSiteLatestClassification,
                                             MWQMSiteMWQMSiteLatestClassificationText = c.MWQMSiteMWQMSiteLatestClassificationText,
                                             MWQMSiteMWQMSiteNumber = c.MWQMSiteMWQMSiteNumber,
                                             MWQMSiteMWQMSiteTVItemID = c.MWQMSiteMWQMSiteTVItemID,
                                             MWQMSiteMWQMSiteTVText = c.MWQMSiteMWQMSiteTVText,
                                             MWQMSiteOrdinal = c.MWQMSiteOrdinal,
                                             MWQMSiteSampleFC = c.MWQMSiteSampleFC,
                                             MWQMSiteSampleFCDepth = c.MWQMSiteSampleFCDepth,
                                             MWQMSiteSampleFCDO = c.MWQMSiteSampleFCDO,
                                             MWQMSiteSampleFCError = c.MWQMSiteSampleFCError,
                                             MWQMSiteSampleFCFC = c.MWQMSiteSampleFCFC,
                                             MWQMSiteSampleFCGeoMean = c.MWQMSiteSampleFCGeoMean,
                                             MWQMSiteSampleFCHasErrors = c.MWQMSiteSampleFCHasErrors,
                                             MWQMSiteSampleFCMaxFC = c.MWQMSiteSampleFCMaxFC,
                                             MWQMSiteSampleFCMedian = c.MWQMSiteSampleFCMedian,
                                             MWQMSiteSampleFCMinFC = c.MWQMSiteSampleFCMinFC,
                                             MWQMSiteSampleFCP90 = c.MWQMSiteSampleFCP90,
                                             MWQMSiteSampleFCPercOver260 = c.MWQMSiteSampleFCPercOver260,
                                             MWQMSiteSampleFCPercOver43 = c.MWQMSiteSampleFCPercOver43,
                                             MWQMSiteSampleFCPH = c.MWQMSiteSampleFCPH,
                                             MWQMSiteSampleFCSal = c.MWQMSiteSampleFCSal,
                                             MWQMSiteSampleFCSampCount = c.MWQMSiteSampleFCSampCount,
                                             MWQMSiteSampleFCSampleDate = c.MWQMSiteSampleFCSampleDate,
                                             MWQMSiteSampleFCTemp = c.MWQMSiteSampleFCTemp,
                                             MWQMSiteStartEndDate = c.MWQMSiteStartEndDate,
                                             MWQMSiteStartEndDateEndDate = c.MWQMSiteStartEndDateEndDate,
                                             MWQMSiteStartEndDateHasErrors = c.MWQMSiteStartEndDateHasErrors,
                                             MWQMSiteStartEndDateLastUpdateContactTVItemID = c.MWQMSiteStartEndDateLastUpdateContactTVItemID,
                                             MWQMSiteStartEndDateLastUpdateContactTVText = c.MWQMSiteStartEndDateLastUpdateContactTVText,
                                             MWQMSiteStartEndDateLastUpdateDate_UTC = c.MWQMSiteStartEndDateLastUpdateDate_UTC,
                                             MWQMSiteStartEndDateMWQMSiteStartEndDateID = c.MWQMSiteStartEndDateMWQMSiteStartEndDateID,
                                             MWQMSiteStartEndDateMWQMSiteTVItemID = c.MWQMSiteStartEndDateMWQMSiteTVItemID,
                                             MWQMSiteStartEndDateMWQMSiteTVText = c.MWQMSiteStartEndDateMWQMSiteTVText,
                                             MWQMSiteStartEndDateStartDate = c.MWQMSiteStartEndDateStartDate,
                                             MWQMSubsector = c.MWQMSubsector,
                                             MWQMSubsectorHasErrors = c.MWQMSubsectorHasErrors,
                                             MWQMSubsectorLanguage = c.MWQMSubsectorLanguage,
                                             MWQMSubsectorLanguageHasErrors = c.MWQMSubsectorLanguageHasErrors,
                                             MWQMSubsectorLanguageLanguage = c.MWQMSubsectorLanguageLanguage,
                                             MWQMSubsectorLanguageLanguageText = c.MWQMSubsectorLanguageLanguageText,
                                             MWQMSubsectorLanguageLastUpdateContactTVItemID = c.MWQMSubsectorLanguageLastUpdateContactTVItemID,
                                             MWQMSubsectorLanguageLastUpdateContactTVText = c.MWQMSubsectorLanguageLastUpdateContactTVText,
                                             MWQMSubsectorLanguageLastUpdateDate_UTC = c.MWQMSubsectorLanguageLastUpdateDate_UTC,
                                             MWQMSubsectorLanguageLogBook = c.MWQMSubsectorLanguageLogBook,
                                             MWQMSubsectorLanguageMWQMSubsectorID = c.MWQMSubsectorLanguageMWQMSubsectorID,
                                             MWQMSubsectorLanguageMWQMSubsectorLanguageID = c.MWQMSubsectorLanguageMWQMSubsectorLanguageID,
                                             MWQMSubsectorLanguageSubsectorDesc = c.MWQMSubsectorLanguageSubsectorDesc,
                                             MWQMSubsectorLanguageTranslationStatusLogBook = c.MWQMSubsectorLanguageTranslationStatusLogBook,
                                             MWQMSubsectorLanguageTranslationStatusLogBookText = c.MWQMSubsectorLanguageTranslationStatusLogBookText,
                                             MWQMSubsectorLanguageTranslationStatusSubsectorDesc = c.MWQMSubsectorLanguageTranslationStatusSubsectorDesc,
                                             MWQMSubsectorLanguageTranslationStatusSubsectorDescText = c.MWQMSubsectorLanguageTranslationStatusSubsectorDescText,
                                             MWQMSubsectorLastUpdateContactTVItemID = c.MWQMSubsectorLastUpdateContactTVItemID,
                                             MWQMSubsectorLastUpdateContactTVText = c.MWQMSubsectorLastUpdateContactTVText,
                                             MWQMSubsectorLastUpdateDate_UTC = c.MWQMSubsectorLastUpdateDate_UTC,
                                             MWQMSubsectorMWQMSubsectorID = c.MWQMSubsectorMWQMSubsectorID,
                                             MWQMSubsectorMWQMSubsectorTVItemID = c.MWQMSubsectorMWQMSubsectorTVItemID,
                                             MWQMSubsectorSubsectorHistoricKey = c.MWQMSubsectorSubsectorHistoricKey,
                                             MWQMSubsectorSubsectorTVText = c.MWQMSubsectorSubsectorTVText,
                                             MWQMSubsectorTideLocationSIDText = c.MWQMSubsectorTideLocationSIDText,
                                             NewContact = c.NewContact,
                                             NewContactContactTitle = c.NewContactContactTitle,
                                             NewContactContactTitleText = c.NewContactContactTitleText,
                                             NewContactFirstName = c.NewContactFirstName,
                                             NewContactHasErrors = c.NewContactHasErrors,
                                             NewContactInitial = c.NewContactInitial,
                                             NewContactLastName = c.NewContactLastName,
                                             NewContactLoginEmail = c.NewContactLoginEmail,
                                             Node = c.Node,
                                             NodeCode = c.NodeCode,
                                             NodeConnectNodeList = c.NodeConnectNodeList,
                                             NodeElementList = c.NodeElementList,
                                             NodeHasErrors = c.NodeHasErrors,
                                             NodeID = c.NodeID,
                                             NodeLayer = c.NodeLayer,
                                             NodeLayerHasErrors = c.NodeLayerHasErrors,
                                             NodeLayerLayer = c.NodeLayerLayer,
                                             NodeLayerNode = c.NodeLayerNode,
                                             NodeLayerZ = c.NodeLayerZ,
                                             NodeValue = c.NodeValue,
                                             NodeX = c.NodeX,
                                             NodeY = c.NodeY,
                                             NodeZ = c.NodeZ,
                                             OtherFilesToUpload = c.OtherFilesToUpload,
                                             OtherFilesToUploadError = c.OtherFilesToUploadError,
                                             OtherFilesToUploadHasErrors = c.OtherFilesToUploadHasErrors,
                                             OtherFilesToUploadMikeScenarioID = c.OtherFilesToUploadMikeScenarioID,
                                             OtherFilesToUploadTVFileList = c.OtherFilesToUploadTVFileList,
                                             PolSourceInactiveReasonEnumTextAndID = c.PolSourceInactiveReasonEnumTextAndID,
                                             PolSourceInactiveReasonEnumTextAndIDHasErrors = c.PolSourceInactiveReasonEnumTextAndIDHasErrors,
                                             PolSourceInactiveReasonEnumTextAndIDID = c.PolSourceInactiveReasonEnumTextAndIDID,
                                             PolSourceInactiveReasonEnumTextAndIDText = c.PolSourceInactiveReasonEnumTextAndIDText,
                                             PolSourceObservation = c.PolSourceObservation,
                                             PolSourceObservationContactTVItemID = c.PolSourceObservationContactTVItemID,
                                             PolSourceObservationContactTVText = c.PolSourceObservationContactTVText,
                                             PolSourceObservationHasErrors = c.PolSourceObservationHasErrors,
                                             PolSourceObservationIssue = c.PolSourceObservationIssue,
                                             PolSourceObservationIssueHasErrors = c.PolSourceObservationIssueHasErrors,
                                             PolSourceObservationIssueLastUpdateContactTVItemID = c.PolSourceObservationIssueLastUpdateContactTVItemID,
                                             PolSourceObservationIssueLastUpdateContactTVText = c.PolSourceObservationIssueLastUpdateContactTVText,
                                             PolSourceObservationIssueLastUpdateDate_UTC = c.PolSourceObservationIssueLastUpdateDate_UTC,
                                             PolSourceObservationIssueObservationInfo = c.PolSourceObservationIssueObservationInfo,
                                             PolSourceObservationIssueOrdinal = c.PolSourceObservationIssueOrdinal,
                                             PolSourceObservationIssuePolSourceObservationID = c.PolSourceObservationIssuePolSourceObservationID,
                                             PolSourceObservationIssuePolSourceObservationIssueID = c.PolSourceObservationIssuePolSourceObservationIssueID,
                                             PolSourceObservationLastUpdateContactTVItemID = c.PolSourceObservationLastUpdateContactTVItemID,
                                             PolSourceObservationLastUpdateContactTVText = c.PolSourceObservationLastUpdateContactTVText,
                                             PolSourceObservationLastUpdateDate_UTC = c.PolSourceObservationLastUpdateDate_UTC,
                                             PolSourceObservationObservation_ToBeDeleted = c.PolSourceObservationObservation_ToBeDeleted,
                                             PolSourceObservationObservationDate_Local = c.PolSourceObservationObservationDate_Local,
                                             PolSourceObservationPolSourceObservationID = c.PolSourceObservationPolSourceObservationID,
                                             PolSourceObservationPolSourceSiteID = c.PolSourceObservationPolSourceSiteID,
                                             PolSourceObservationPolSourceSiteTVText = c.PolSourceObservationPolSourceSiteTVText,
                                             PolSourceObsInfoChild = c.PolSourceObsInfoChild,
                                             PolSourceObsInfoChildHasErrors = c.PolSourceObsInfoChildHasErrors,
                                             PolSourceObsInfoChildPolSourceObsInfo = c.PolSourceObsInfoChildPolSourceObsInfo,
                                             PolSourceObsInfoChildPolSourceObsInfoChildStart = c.PolSourceObsInfoChildPolSourceObsInfoChildStart,
                                             PolSourceObsInfoChildPolSourceObsInfoChildStartText = c.PolSourceObsInfoChildPolSourceObsInfoChildStartText,
                                             PolSourceObsInfoChildPolSourceObsInfoText = c.PolSourceObsInfoChildPolSourceObsInfoText,
                                             PolSourceObsInfoEnumTextAndID = c.PolSourceObsInfoEnumTextAndID,
                                             PolSourceObsInfoEnumTextAndIDHasErrors = c.PolSourceObsInfoEnumTextAndIDHasErrors,
                                             PolSourceObsInfoEnumTextAndIDID = c.PolSourceObsInfoEnumTextAndIDID,
                                             PolSourceObsInfoEnumTextAndIDText = c.PolSourceObsInfoEnumTextAndIDText,
                                             PolSourceSite = c.PolSourceSite,
                                             PolSourceSiteCivicAddressTVItemID = c.PolSourceSiteCivicAddressTVItemID,
                                             PolSourceSiteHasErrors = c.PolSourceSiteHasErrors,
                                             PolSourceSiteInactiveReason = c.PolSourceSiteInactiveReason,
                                             PolSourceSiteInactiveReasonText = c.PolSourceSiteInactiveReasonText,
                                             PolSourceSiteIsPointSource = c.PolSourceSiteIsPointSource,
                                             PolSourceSiteLastUpdateContactTVItemID = c.PolSourceSiteLastUpdateContactTVItemID,
                                             PolSourceSiteLastUpdateContactTVText = c.PolSourceSiteLastUpdateContactTVText,
                                             PolSourceSiteLastUpdateDate_UTC = c.PolSourceSiteLastUpdateDate_UTC,
                                             PolSourceSiteOldsiteid = c.PolSourceSiteOldsiteid,
                                             PolSourceSitePolSourceSiteID = c.PolSourceSitePolSourceSiteID,
                                             PolSourceSitePolSourceSiteTVItemID = c.PolSourceSitePolSourceSiteTVItemID,
                                             PolSourceSitePolSourceSiteTVText = c.PolSourceSitePolSourceSiteTVText,
                                             PolSourceSiteSite = c.PolSourceSiteSite,
                                             PolSourceSiteSiteID = c.PolSourceSiteSiteID,
                                             PolSourceSiteTemp_Locator_CanDelete = c.PolSourceSiteTemp_Locator_CanDelete,
                                             PolyPoint = c.PolyPoint,
                                             PolyPointHasErrors = c.PolyPointHasErrors,
                                             PolyPointXCoord = c.PolyPointXCoord,
                                             PolyPointYCoord = c.PolyPointYCoord,
                                             PolyPointZ = c.PolyPointZ,
                                             RainExceedance = c.RainExceedance,
                                             RainExceedanceClimateSiteTVItemIDs = c.RainExceedanceClimateSiteTVItemIDs,
                                             RainExceedanceDaysPriorToStart = c.RainExceedanceDaysPriorToStart,
                                             RainExceedanceEmailDistributionListIDs = c.RainExceedanceEmailDistributionListIDs,
                                             RainExceedanceEndDate_Local = c.RainExceedanceEndDate_Local,
                                             RainExceedanceHasErrors = c.RainExceedanceHasErrors,
                                             RainExceedanceLastUpdateContactTVItemID = c.RainExceedanceLastUpdateContactTVItemID,
                                             RainExceedanceLastUpdateContactTVText = c.RainExceedanceLastUpdateContactTVText,
                                             RainExceedanceLastUpdateDate_UTC = c.RainExceedanceLastUpdateDate_UTC,
                                             RainExceedanceProvinceTVItemIDs = c.RainExceedanceProvinceTVItemIDs,
                                             RainExceedanceRainExceedanceID = c.RainExceedanceRainExceedanceID,
                                             RainExceedanceRainExtreme_mm = c.RainExceedanceRainExtreme_mm,
                                             RainExceedanceRainMaximum_mm = c.RainExceedanceRainMaximum_mm,
                                             RainExceedanceRepeatEveryYear = c.RainExceedanceRepeatEveryYear,
                                             RainExceedanceStartDate_Local = c.RainExceedanceStartDate_Local,
                                             RainExceedanceSubsectorTVItemIDs = c.RainExceedanceSubsectorTVItemIDs,
                                             RainExceedanceYearRound = c.RainExceedanceYearRound,
                                             RatingCurve = c.RatingCurve,
                                             RatingCurveHasErrors = c.RatingCurveHasErrors,
                                             RatingCurveHydrometricSiteID = c.RatingCurveHydrometricSiteID,
                                             RatingCurveLastUpdateContactTVItemID = c.RatingCurveLastUpdateContactTVItemID,
                                             RatingCurveLastUpdateContactTVText = c.RatingCurveLastUpdateContactTVText,
                                             RatingCurveLastUpdateDate_UTC = c.RatingCurveLastUpdateDate_UTC,
                                             RatingCurveRatingCurveID = c.RatingCurveRatingCurveID,
                                             RatingCurveRatingCurveNumber = c.RatingCurveRatingCurveNumber,
                                             RatingCurveValue = c.RatingCurveValue,
                                             RatingCurveValueDischargeValue_m3_s = c.RatingCurveValueDischargeValue_m3_s,
                                             RatingCurveValueHasErrors = c.RatingCurveValueHasErrors,
                                             RatingCurveValueLastUpdateContactTVItemID = c.RatingCurveValueLastUpdateContactTVItemID,
                                             RatingCurveValueLastUpdateContactTVText = c.RatingCurveValueLastUpdateContactTVText,
                                             RatingCurveValueLastUpdateDate_UTC = c.RatingCurveValueLastUpdateDate_UTC,
                                             RatingCurveValueRatingCurveID = c.RatingCurveValueRatingCurveID,
                                             RatingCurveValueRatingCurveValueID = c.RatingCurveValueRatingCurveValueID,
                                             RatingCurveValueStageValue_m = c.RatingCurveValueStageValue_m,
                                             Register = c.Register,
                                             RegisterConfirmPassword = c.RegisterConfirmPassword,
                                             RegisterFirstName = c.RegisterFirstName,
                                             RegisterHasErrors = c.RegisterHasErrors,
                                             RegisterInitial = c.RegisterInitial,
                                             RegisterLastName = c.RegisterLastName,
                                             RegisterLoginEmail = c.RegisterLoginEmail,
                                             RegisterPassword = c.RegisterPassword,
                                             RegisterWebName = c.RegisterWebName,
                                             ResetPassword = c.ResetPassword,
                                             ResetPasswordCode = c.ResetPasswordCode,
                                             ResetPasswordConfirmPassword = c.ResetPasswordConfirmPassword,
                                             ResetPasswordEmail = c.ResetPasswordEmail,
                                             ResetPasswordExpireDate_Local = c.ResetPasswordExpireDate_Local,
                                             ResetPasswordHasErrors = c.ResetPasswordHasErrors,
                                             ResetPasswordLastUpdateContactTVItemID = c.ResetPasswordLastUpdateContactTVItemID,
                                             ResetPasswordLastUpdateContactTVText = c.ResetPasswordLastUpdateContactTVText,
                                             ResetPasswordLastUpdateDate_UTC = c.ResetPasswordLastUpdateDate_UTC,
                                             ResetPasswordPassword = c.ResetPasswordPassword,
                                             ResetPasswordResetPasswordID = c.ResetPasswordResetPasswordID,
                                             RTBStringPos = c.RTBStringPos,
                                             RTBStringPosEndPos = c.RTBStringPosEndPos,
                                             RTBStringPosHasErrors = c.RTBStringPosHasErrors,
                                             RTBStringPosStartPos = c.RTBStringPosStartPos,
                                             RTBStringPosTagText = c.RTBStringPosTagText,
                                             RTBStringPosText = c.RTBStringPosText,
                                             SamplingPlan = c.SamplingPlan,
                                             SamplingPlanAccessCode = c.SamplingPlanAccessCode,
                                             SamplingPlanAndFilesLabSheetCount = c.SamplingPlanAndFilesLabSheetCount,
                                             SamplingPlanAndFilesLabSheetCountHasErrors = c.SamplingPlanAndFilesLabSheetCountHasErrors,
                                             SamplingPlanAndFilesLabSheetCountLabSheetHistoryCount = c.SamplingPlanAndFilesLabSheetCountLabSheetHistoryCount,
                                             SamplingPlanAndFilesLabSheetCountLabSheetTransferredCount = c.SamplingPlanAndFilesLabSheetCountLabSheetTransferredCount,
                                             SamplingPlanAndFilesLabSheetCountSamplingPlan = c.SamplingPlanAndFilesLabSheetCountSamplingPlan,
                                             SamplingPlanAndFilesLabSheetCountTVFileSamplingPlanFileTXT = c.SamplingPlanAndFilesLabSheetCountTVFileSamplingPlanFileTXT,
                                             SamplingPlanApprovalCode = c.SamplingPlanApprovalCode,
                                             SamplingPlanCreatorTVItemID = c.SamplingPlanCreatorTVItemID,
                                             SamplingPlanCreatorTVText = c.SamplingPlanCreatorTVText,
                                             SamplingPlanDailyDuplicatePrecisionCriteria = c.SamplingPlanDailyDuplicatePrecisionCriteria,
                                             SamplingPlanForGroupName = c.SamplingPlanForGroupName,
                                             SamplingPlanHasErrors = c.SamplingPlanHasErrors,
                                             SamplingPlanIncludeLaboratoryQAQC = c.SamplingPlanIncludeLaboratoryQAQC,
                                             SamplingPlanIntertechDuplicatePrecisionCriteria = c.SamplingPlanIntertechDuplicatePrecisionCriteria,
                                             SamplingPlanLabSheetType = c.SamplingPlanLabSheetType,
                                             SamplingPlanLabSheetTypeText = c.SamplingPlanLabSheetTypeText,
                                             SamplingPlanLastUpdateContactTVItemID = c.SamplingPlanLastUpdateContactTVItemID,
                                             SamplingPlanLastUpdateContactTVText = c.SamplingPlanLastUpdateContactTVText,
                                             SamplingPlanLastUpdateDate_UTC = c.SamplingPlanLastUpdateDate_UTC,
                                             SamplingPlanProvinceTVItemID = c.SamplingPlanProvinceTVItemID,
                                             SamplingPlanProvinceTVText = c.SamplingPlanProvinceTVText,
                                             SamplingPlanSampleType = c.SamplingPlanSampleType,
                                             SamplingPlanSampleTypeText = c.SamplingPlanSampleTypeText,
                                             SamplingPlanSamplingPlanFileTVItemID = c.SamplingPlanSamplingPlanFileTVItemID,
                                             SamplingPlanSamplingPlanFileTVText = c.SamplingPlanSamplingPlanFileTVText,
                                             SamplingPlanSamplingPlanID = c.SamplingPlanSamplingPlanID,
                                             SamplingPlanSamplingPlanName = c.SamplingPlanSamplingPlanName,
                                             SamplingPlanSamplingPlanType = c.SamplingPlanSamplingPlanType,
                                             SamplingPlanSamplingPlanTypeText = c.SamplingPlanSamplingPlanTypeText,
                                             SamplingPlanSubsector = c.SamplingPlanSubsector,
                                             SamplingPlanSubsectorHasErrors = c.SamplingPlanSubsectorHasErrors,
                                             SamplingPlanSubsectorLastUpdateContactTVItemID = c.SamplingPlanSubsectorLastUpdateContactTVItemID,
                                             SamplingPlanSubsectorLastUpdateContactTVText = c.SamplingPlanSubsectorLastUpdateContactTVText,
                                             SamplingPlanSubsectorLastUpdateDate_UTC = c.SamplingPlanSubsectorLastUpdateDate_UTC,
                                             SamplingPlanSubsectorSamplingPlanID = c.SamplingPlanSubsectorSamplingPlanID,
                                             SamplingPlanSubsectorSamplingPlanSubsectorID = c.SamplingPlanSubsectorSamplingPlanSubsectorID,
                                             SamplingPlanSubsectorSite = c.SamplingPlanSubsectorSite,
                                             SamplingPlanSubsectorSiteHasErrors = c.SamplingPlanSubsectorSiteHasErrors,
                                             SamplingPlanSubsectorSiteIsDuplicate = c.SamplingPlanSubsectorSiteIsDuplicate,
                                             SamplingPlanSubsectorSiteLastUpdateContactTVItemID = c.SamplingPlanSubsectorSiteLastUpdateContactTVItemID,
                                             SamplingPlanSubsectorSiteLastUpdateContactTVText = c.SamplingPlanSubsectorSiteLastUpdateContactTVText,
                                             SamplingPlanSubsectorSiteLastUpdateDate_UTC = c.SamplingPlanSubsectorSiteLastUpdateDate_UTC,
                                             SamplingPlanSubsectorSiteMWQMSiteTVItemID = c.SamplingPlanSubsectorSiteMWQMSiteTVItemID,
                                             SamplingPlanSubsectorSiteMWQMSiteTVText = c.SamplingPlanSubsectorSiteMWQMSiteTVText,
                                             SamplingPlanSubsectorSiteSamplingPlanSubsectorID = c.SamplingPlanSubsectorSiteSamplingPlanSubsectorID,
                                             SamplingPlanSubsectorSiteSamplingPlanSubsectorSiteID = c.SamplingPlanSubsectorSiteSamplingPlanSubsectorSiteID,
                                             SamplingPlanSubsectorSubsectorTVItemID = c.SamplingPlanSubsectorSubsectorTVItemID,
                                             SamplingPlanSubsectorSubsectorTVText = c.SamplingPlanSubsectorSubsectorTVText,
                                             SamplingPlanYear = c.SamplingPlanYear,
                                             Search = c.Search,
                                             SearchHasErrors = c.SearchHasErrors,
                                             Searchid = c.Searchid,
                                             SearchTagAndTerms = c.SearchTagAndTerms,
                                             SearchTagAndTermsHasErrors = c.SearchTagAndTermsHasErrors,
                                             SearchTagAndTermsSearchTag = c.SearchTagAndTermsSearchTag,
                                             SearchTagAndTermsSearchTagText = c.SearchTagAndTermsSearchTagText,
                                             SearchTagAndTermsSearchTermList = c.SearchTagAndTermsSearchTermList,
                                             Searchvalue = c.Searchvalue,
                                             Spill = c.Spill,
                                             SpillAverageFlow_m3_day = c.SpillAverageFlow_m3_day,
                                             SpillEndDateTime_Local = c.SpillEndDateTime_Local,
                                             SpillHasErrors = c.SpillHasErrors,
                                             SpillInfrastructureTVItemID = c.SpillInfrastructureTVItemID,
                                             SpillInfrastructureTVText = c.SpillInfrastructureTVText,
                                             SpillLanguage = c.SpillLanguage,
                                             SpillLanguageHasErrors = c.SpillLanguageHasErrors,
                                             SpillLanguageLanguage = c.SpillLanguageLanguage,
                                             SpillLanguageLanguageText = c.SpillLanguageLanguageText,
                                             SpillLanguageLastUpdateContactTVItemID = c.SpillLanguageLastUpdateContactTVItemID,
                                             SpillLanguageLastUpdateContactTVText = c.SpillLanguageLastUpdateContactTVText,
                                             SpillLanguageLastUpdateDate_UTC = c.SpillLanguageLastUpdateDate_UTC,
                                             SpillLanguageSpillComment = c.SpillLanguageSpillComment,
                                             SpillLanguageSpillID = c.SpillLanguageSpillID,
                                             SpillLanguageSpillLanguageID = c.SpillLanguageSpillLanguageID,
                                             SpillLanguageTranslationStatus = c.SpillLanguageTranslationStatus,
                                             SpillLanguageTranslationStatusText = c.SpillLanguageTranslationStatusText,
                                             SpillLastUpdateContactTVItemID = c.SpillLastUpdateContactTVItemID,
                                             SpillLastUpdateContactTVText = c.SpillLastUpdateContactTVText,
                                             SpillLastUpdateDate_UTC = c.SpillLastUpdateDate_UTC,
                                             SpillMunicipalityTVItemID = c.SpillMunicipalityTVItemID,
                                             SpillMunicipalityTVText = c.SpillMunicipalityTVText,
                                             SpillSpillID = c.SpillSpillID,
                                             SpillStartDateTime_Local = c.SpillStartDateTime_Local,
                                             SubsectorMWQMSampleYear = c.SubsectorMWQMSampleYear,
                                             SubsectorMWQMSampleYearEarliestDate = c.SubsectorMWQMSampleYearEarliestDate,
                                             SubsectorMWQMSampleYearHasErrors = c.SubsectorMWQMSampleYearHasErrors,
                                             SubsectorMWQMSampleYearLatestDate = c.SubsectorMWQMSampleYearLatestDate,
                                             SubsectorMWQMSampleYearSubsectorTVItemID = c.SubsectorMWQMSampleYearSubsectorTVItemID,
                                             SubsectorMWQMSampleYearYear = c.SubsectorMWQMSampleYearYear,
                                             Tel = c.Tel,
                                             TelHasErrors = c.TelHasErrors,
                                             TelLastUpdateContactTVItemID = c.TelLastUpdateContactTVItemID,
                                             TelLastUpdateContactTVText = c.TelLastUpdateContactTVText,
                                             TelLastUpdateDate_UTC = c.TelLastUpdateDate_UTC,
                                             TelTelID = c.TelTelID,
                                             TelTelNumber = c.TelTelNumber,
                                             TelTelTVItemID = c.TelTelTVItemID,
                                             TelTelTVText = c.TelTelTVText,
                                             TelTelType = c.TelTelType,
                                             TelTelTypeText = c.TelTelTypeText,
                                             TideDataValue = c.TideDataValue,
                                             TideDataValueDateTime_Local = c.TideDataValueDateTime_Local,
                                             TideDataValueDepth_m = c.TideDataValueDepth_m,
                                             TideDataValueHasErrors = c.TideDataValueHasErrors,
                                             TideDataValueKeep = c.TideDataValueKeep,
                                             TideDataValueLastUpdateContactTVItemID = c.TideDataValueLastUpdateContactTVItemID,
                                             TideDataValueLastUpdateContactTVText = c.TideDataValueLastUpdateContactTVText,
                                             TideDataValueLastUpdateDate_UTC = c.TideDataValueLastUpdateDate_UTC,
                                             TideDataValueStorageDataType = c.TideDataValueStorageDataType,
                                             TideDataValueStorageDataTypeText = c.TideDataValueStorageDataTypeText,
                                             TideDataValueTideDataType = c.TideDataValueTideDataType,
                                             TideDataValueTideDataTypeText = c.TideDataValueTideDataTypeText,
                                             TideDataValueTideDataValueID = c.TideDataValueTideDataValueID,
                                             TideDataValueTideEnd = c.TideDataValueTideEnd,
                                             TideDataValueTideEndText = c.TideDataValueTideEndText,
                                             TideDataValueTideSiteTVItemID = c.TideDataValueTideSiteTVItemID,
                                             TideDataValueTideSiteTVText = c.TideDataValueTideSiteTVText,
                                             TideDataValueTideStart = c.TideDataValueTideStart,
                                             TideDataValueTideStartText = c.TideDataValueTideStartText,
                                             TideDataValueUVelocity_m_s = c.TideDataValueUVelocity_m_s,
                                             TideDataValueVVelocity_m_s = c.TideDataValueVVelocity_m_s,
                                             TideLocation = c.TideLocation,
                                             TideLocationHasErrors = c.TideLocationHasErrors,
                                             TideLocationLat = c.TideLocationLat,
                                             TideLocationLng = c.TideLocationLng,
                                             TideLocationName = c.TideLocationName,
                                             TideLocationProv = c.TideLocationProv,
                                             TideLocationsid = c.TideLocationsid,
                                             TideLocationTideLocationID = c.TideLocationTideLocationID,
                                             TideLocationZone = c.TideLocationZone,
                                             TideSite = c.TideSite,
                                             TideSiteHasErrors = c.TideSiteHasErrors,
                                             TideSiteLastUpdateContactTVItemID = c.TideSiteLastUpdateContactTVItemID,
                                             TideSiteLastUpdateContactTVText = c.TideSiteLastUpdateContactTVText,
                                             TideSiteLastUpdateDate_UTC = c.TideSiteLastUpdateDate_UTC,
                                             TideSiteTideSiteID = c.TideSiteTideSiteID,
                                             TideSiteTideSiteTVItemID = c.TideSiteTideSiteTVItemID,
                                             TideSiteTideSiteTVText = c.TideSiteTideSiteTVText,
                                             TideSiteWebTideDatum_m = c.TideSiteWebTideDatum_m,
                                             TideSiteWebTideModel = c.TideSiteWebTideModel,
                                             TVFile = c.TVFile,
                                             TVFileClientFilePath = c.TVFileClientFilePath,
                                             TVFileFileCreatedDate_UTC = c.TVFileFileCreatedDate_UTC,
                                             TVFileFileInfo = c.TVFileFileInfo,
                                             TVFileFilePurpose = c.TVFileFilePurpose,
                                             TVFileFilePurposeText = c.TVFileFilePurposeText,
                                             TVFileFileSize_kb = c.TVFileFileSize_kb,
                                             TVFileFileType = c.TVFileFileType,
                                             TVFileFileTypeText = c.TVFileFileTypeText,
                                             TVFileFromWater = c.TVFileFromWater,
                                             TVFileHasErrors = c.TVFileHasErrors,
                                             TVFileLanguage = c.TVFileLanguage,
                                             TVFileLanguageFileDescription = c.TVFileLanguageFileDescription,
                                             TVFileLanguageHasErrors = c.TVFileLanguageHasErrors,
                                             TVFileLanguageLanguage = c.TVFileLanguageLanguage,
                                             TVFileLanguageLanguageText = c.TVFileLanguageLanguageText,
                                             TVFileLanguageLastUpdateContactTVItemID = c.TVFileLanguageLastUpdateContactTVItemID,
                                             TVFileLanguageLastUpdateContactTVText = c.TVFileLanguageLastUpdateContactTVText,
                                             TVFileLanguageLastUpdateDate_UTC = c.TVFileLanguageLastUpdateDate_UTC,
                                             TVFileLanguageText = c.TVFileLanguageText,
                                             TVFileLanguageTranslationStatus = c.TVFileLanguageTranslationStatus,
                                             TVFileLanguageTranslationStatusText = c.TVFileLanguageTranslationStatusText,
                                             TVFileLanguageTVFileID = c.TVFileLanguageTVFileID,
                                             TVFileLanguageTVFileLanguageID = c.TVFileLanguageTVFileLanguageID,
                                             TVFileLastUpdateContactTVItemID = c.TVFileLastUpdateContactTVItemID,
                                             TVFileLastUpdateContactTVText = c.TVFileLastUpdateContactTVText,
                                             TVFileLastUpdateDate_UTC = c.TVFileLastUpdateDate_UTC,
                                             TVFileServerFileName = c.TVFileServerFileName,
                                             TVFileServerFilePath = c.TVFileServerFilePath,
                                             TVFileTemplateTVType = c.TVFileTemplateTVType,
                                             TVFileTemplateTVTypeText = c.TVFileTemplateTVTypeText,
                                             TVFileTVFileID = c.TVFileTVFileID,
                                             TVFileTVFileTVItemID = c.TVFileTVFileTVItemID,
                                             TVFileTVFileTVText = c.TVFileTVFileTVText,
                                             TVFullText = c.TVFullText,
                                             TVFullTextFullText = c.TVFullTextFullText,
                                             TVFullTextHasErrors = c.TVFullTextHasErrors,
                                             TVFullTextTVPath = c.TVFullTextTVPath,
                                             TVItem = c.TVItem,
                                             TVItemHasErrors = c.TVItemHasErrors,
                                             TVItemInfrastructureTypeTVItemLink = c.TVItemInfrastructureTypeTVItemLink,
                                             TVItemInfrastructureTypeTVItemLinkFlowTo = c.TVItemInfrastructureTypeTVItemLinkFlowTo,
                                             TVItemInfrastructureTypeTVItemLinkHasErrors = c.TVItemInfrastructureTypeTVItemLinkHasErrors,
                                             TVItemInfrastructureTypeTVItemLinkInfrastructureType = c.TVItemInfrastructureTypeTVItemLinkInfrastructureType,
                                             TVItemInfrastructureTypeTVItemLinkInfrastructureTypeText = c.TVItemInfrastructureTypeTVItemLinkInfrastructureTypeText,
                                             TVItemInfrastructureTypeTVItemLinkSeeOtherTVItemID = c.TVItemInfrastructureTypeTVItemLinkSeeOtherTVItemID,
                                             TVItemInfrastructureTypeTVItemLinkTVItem = c.TVItemInfrastructureTypeTVItemLinkTVItem,
                                             TVItemInfrastructureTypeTVItemLinkTVItemLinkList = c.TVItemInfrastructureTypeTVItemLinkTVItemLinkList,
                                             TVItemIsActive = c.TVItemIsActive,
                                             TVItemLanguage = c.TVItemLanguage,
                                             TVItemLanguageHasErrors = c.TVItemLanguageHasErrors,
                                             TVItemLanguageLanguage = c.TVItemLanguageLanguage,
                                             TVItemLanguageLanguageText = c.TVItemLanguageLanguageText,
                                             TVItemLanguageLastUpdateContactTVItemID = c.TVItemLanguageLastUpdateContactTVItemID,
                                             TVItemLanguageLastUpdateContactTVText = c.TVItemLanguageLastUpdateContactTVText,
                                             TVItemLanguageLastUpdateDate_UTC = c.TVItemLanguageLastUpdateDate_UTC,
                                             TVItemLanguageTranslationStatus = c.TVItemLanguageTranslationStatus,
                                             TVItemLanguageTranslationStatusText = c.TVItemLanguageTranslationStatusText,
                                             TVItemLanguageTVItemID = c.TVItemLanguageTVItemID,
                                             TVItemLanguageTVItemLanguageID = c.TVItemLanguageTVItemLanguageID,
                                             TVItemLanguageTVText = c.TVItemLanguageTVText,
                                             TVItemLastUpdateContactTVItemID = c.TVItemLastUpdateContactTVItemID,
                                             TVItemLastUpdateContactTVText = c.TVItemLastUpdateContactTVText,
                                             TVItemLastUpdateDate_UTC = c.TVItemLastUpdateDate_UTC,
                                             TVItemLink = c.TVItemLink,
                                             TVItemLinkEndDateTime_Local = c.TVItemLinkEndDateTime_Local,
                                             TVItemLinkFromTVItemID = c.TVItemLinkFromTVItemID,
                                             TVItemLinkFromTVText = c.TVItemLinkFromTVText,
                                             TVItemLinkFromTVType = c.TVItemLinkFromTVType,
                                             TVItemLinkFromTVTypeText = c.TVItemLinkFromTVTypeText,
                                             TVItemLinkHasErrors = c.TVItemLinkHasErrors,
                                             TVItemLinkLastUpdateContactTVItemID = c.TVItemLinkLastUpdateContactTVItemID,
                                             TVItemLinkLastUpdateContactTVText = c.TVItemLinkLastUpdateContactTVText,
                                             TVItemLinkLastUpdateDate_UTC = c.TVItemLinkLastUpdateDate_UTC,
                                             TVItemLinkOrdinal = c.TVItemLinkOrdinal,
                                             TVItemLinkParentTVItemLinkID = c.TVItemLinkParentTVItemLinkID,
                                             TVItemLinkStartDateTime_Local = c.TVItemLinkStartDateTime_Local,
                                             TVItemLinkToTVItemID = c.TVItemLinkToTVItemID,
                                             TVItemLinkToTVText = c.TVItemLinkToTVText,
                                             TVItemLinkToTVType = c.TVItemLinkToTVType,
                                             TVItemLinkToTVTypeText = c.TVItemLinkToTVTypeText,
                                             TVItemLinkTVItemLinkID = c.TVItemLinkTVItemLinkID,
                                             TVItemLinkTVLevel = c.TVItemLinkTVLevel,
                                             TVItemLinkTVPath = c.TVItemLinkTVPath,
                                             TVItemParentID = c.TVItemParentID,
                                             TVItemStat = c.TVItemStat,
                                             TVItemStatChildCount = c.TVItemStatChildCount,
                                             TVItemStatHasErrors = c.TVItemStatHasErrors,
                                             TVItemStatLastUpdateContactTVItemID = c.TVItemStatLastUpdateContactTVItemID,
                                             TVItemStatLastUpdateContactTVText = c.TVItemStatLastUpdateContactTVText,
                                             TVItemStatLastUpdateDate_UTC = c.TVItemStatLastUpdateDate_UTC,
                                             TVItemStatTVItemID = c.TVItemStatTVItemID,
                                             TVItemStatTVItemStatID = c.TVItemStatTVItemStatID,
                                             TVItemStatTVText = c.TVItemStatTVText,
                                             TVItemStatTVType = c.TVItemStatTVType,
                                             TVItemStatTVTypeText = c.TVItemStatTVTypeText,
                                             TVItemSubsectorAndMWQMSite = c.TVItemSubsectorAndMWQMSite,
                                             TVItemSubsectorAndMWQMSiteHasErrors = c.TVItemSubsectorAndMWQMSiteHasErrors,
                                             TVItemSubsectorAndMWQMSiteTVItemMWQMSiteDuplicate = c.TVItemSubsectorAndMWQMSiteTVItemMWQMSiteDuplicate,
                                             TVItemSubsectorAndMWQMSiteTVItemMWQMSiteList = c.TVItemSubsectorAndMWQMSiteTVItemMWQMSiteList,
                                             TVItemSubsectorAndMWQMSiteTVItemSubsector = c.TVItemSubsectorAndMWQMSiteTVItemSubsector,
                                             TVItemTVAuth = c.TVItemTVAuth,
                                             TVItemTVAuthError = c.TVItemTVAuthError,
                                             TVItemTVAuthHasErrors = c.TVItemTVAuthHasErrors,
                                             TVItemTVAuthTVAuth = c.TVItemTVAuthTVAuth,
                                             TVItemTVAuthTVAuthText = c.TVItemTVAuthTVAuthText,
                                             TVItemTVAuthTVItemID1 = c.TVItemTVAuthTVItemID1,
                                             TVItemTVAuthTVItemUserAuthID = c.TVItemTVAuthTVItemUserAuthID,
                                             TVItemTVAuthTVText = c.TVItemTVAuthTVText,
                                             TVItemTVAuthTVTypeStr = c.TVItemTVAuthTVTypeStr,
                                             TVItemTVItemID = c.TVItemTVItemID,
                                             TVItemTVLevel = c.TVItemTVLevel,
                                             TVItemTVPath = c.TVItemTVPath,
                                             TVItemTVText = c.TVItemTVText,
                                             TVItemTVType = c.TVItemTVType,
                                             TVItemTVTypeText = c.TVItemTVTypeText,
                                             TVItemUserAuthorization = c.TVItemUserAuthorization,
                                             TVItemUserAuthorizationContactTVItemID = c.TVItemUserAuthorizationContactTVItemID,
                                             TVItemUserAuthorizationContactTVText = c.TVItemUserAuthorizationContactTVText,
                                             TVItemUserAuthorizationHasErrors = c.TVItemUserAuthorizationHasErrors,
                                             TVItemUserAuthorizationLastUpdateContactTVItemID = c.TVItemUserAuthorizationLastUpdateContactTVItemID,
                                             TVItemUserAuthorizationLastUpdateContactTVText = c.TVItemUserAuthorizationLastUpdateContactTVText,
                                             TVItemUserAuthorizationLastUpdateDate_UTC = c.TVItemUserAuthorizationLastUpdateDate_UTC,
                                             TVItemUserAuthorizationTVAuth = c.TVItemUserAuthorizationTVAuth,
                                             TVItemUserAuthorizationTVAuthText = c.TVItemUserAuthorizationTVAuthText,
                                             TVItemUserAuthorizationTVItemID1 = c.TVItemUserAuthorizationTVItemID1,
                                             TVItemUserAuthorizationTVItemID2 = c.TVItemUserAuthorizationTVItemID2,
                                             TVItemUserAuthorizationTVItemID3 = c.TVItemUserAuthorizationTVItemID3,
                                             TVItemUserAuthorizationTVItemID4 = c.TVItemUserAuthorizationTVItemID4,
                                             TVItemUserAuthorizationTVItemUserAuthorizationID = c.TVItemUserAuthorizationTVItemUserAuthorizationID,
                                             TVItemUserAuthorizationTVText1 = c.TVItemUserAuthorizationTVText1,
                                             TVItemUserAuthorizationTVText2 = c.TVItemUserAuthorizationTVText2,
                                             TVItemUserAuthorizationTVText3 = c.TVItemUserAuthorizationTVText3,
                                             TVItemUserAuthorizationTVText4 = c.TVItemUserAuthorizationTVText4,
                                             TVLocation = c.TVLocation,
                                             TVLocationError = c.TVLocationError,
                                             TVLocationHasErrors = c.TVLocationHasErrors,
                                             TVLocationMapObjList = c.TVLocationMapObjList,
                                             TVLocationSubTVType = c.TVLocationSubTVType,
                                             TVLocationSubTVTypeText = c.TVLocationSubTVTypeText,
                                             TVLocationTVItemID = c.TVLocationTVItemID,
                                             TVLocationTVText = c.TVLocationTVText,
                                             TVLocationTVType = c.TVLocationTVType,
                                             TVLocationTVTypeText = c.TVLocationTVTypeText,
                                             TVTextLanguage = c.TVTextLanguage,
                                             TVTextLanguageHasErrors = c.TVTextLanguageHasErrors,
                                             TVTextLanguageLanguage = c.TVTextLanguageLanguage,
                                             TVTextLanguageLanguageText = c.TVTextLanguageLanguageText,
                                             TVTextLanguageTVText = c.TVTextLanguageTVText,
                                             TVTypeNamesAndPath = c.TVTypeNamesAndPath,
                                             TVTypeNamesAndPathHasErrors = c.TVTypeNamesAndPathHasErrors,
                                             TVTypeNamesAndPathIndex = c.TVTypeNamesAndPathIndex,
                                             TVTypeNamesAndPathTVPath = c.TVTypeNamesAndPathTVPath,
                                             TVTypeNamesAndPathTVTypeName = c.TVTypeNamesAndPathTVTypeName,
                                             TVTypeUserAuthorization = c.TVTypeUserAuthorization,
                                             TVTypeUserAuthorizationContactTVItemID = c.TVTypeUserAuthorizationContactTVItemID,
                                             TVTypeUserAuthorizationContactTVText = c.TVTypeUserAuthorizationContactTVText,
                                             TVTypeUserAuthorizationHasErrors = c.TVTypeUserAuthorizationHasErrors,
                                             TVTypeUserAuthorizationLastUpdateContactTVItemID = c.TVTypeUserAuthorizationLastUpdateContactTVItemID,
                                             TVTypeUserAuthorizationLastUpdateContactTVText = c.TVTypeUserAuthorizationLastUpdateContactTVText,
                                             TVTypeUserAuthorizationLastUpdateDate_UTC = c.TVTypeUserAuthorizationLastUpdateDate_UTC,
                                             TVTypeUserAuthorizationTVAuth = c.TVTypeUserAuthorizationTVAuth,
                                             TVTypeUserAuthorizationTVAuthText = c.TVTypeUserAuthorizationTVAuthText,
                                             TVTypeUserAuthorizationTVType = c.TVTypeUserAuthorizationTVType,
                                             TVTypeUserAuthorizationTVTypeText = c.TVTypeUserAuthorizationTVTypeText,
                                             TVTypeUserAuthorizationTVTypeUserAuthorizationID = c.TVTypeUserAuthorizationTVTypeUserAuthorizationID,
                                             URLNumberOfSamples = c.URLNumberOfSamples,
                                             URLNumberOfSamplesHasErrors = c.URLNumberOfSamplesHasErrors,
                                             URLNumberOfSamplesNumberOfSamples = c.URLNumberOfSamplesNumberOfSamples,
                                             URLNumberOfSamplesurl = c.URLNumberOfSamplesurl,
                                             UseOfSite = c.UseOfSite,
                                             UseOfSiteEndYear = c.UseOfSiteEndYear,
                                             UseOfSiteHasErrors = c.UseOfSiteHasErrors,
                                             UseOfSiteLastUpdateContactTVItemID = c.UseOfSiteLastUpdateContactTVItemID,
                                             UseOfSiteLastUpdateContactTVText = c.UseOfSiteLastUpdateContactTVText,
                                             UseOfSiteLastUpdateDate_UTC = c.UseOfSiteLastUpdateDate_UTC,
                                             UseOfSiteOrdinal = c.UseOfSiteOrdinal,
                                             UseOfSiteParam1 = c.UseOfSiteParam1,
                                             UseOfSiteParam2 = c.UseOfSiteParam2,
                                             UseOfSiteParam3 = c.UseOfSiteParam3,
                                             UseOfSiteParam4 = c.UseOfSiteParam4,
                                             UseOfSiteSiteTVItemID = c.UseOfSiteSiteTVItemID,
                                             UseOfSiteSiteTVText = c.UseOfSiteSiteTVText,
                                             UseOfSiteSiteType = c.UseOfSiteSiteType,
                                             UseOfSiteSiteTypeText = c.UseOfSiteSiteTypeText,
                                             UseOfSiteStartYear = c.UseOfSiteStartYear,
                                             UseOfSiteSubsectorTVItemID = c.UseOfSiteSubsectorTVItemID,
                                             UseOfSiteSubsectorTVText = c.UseOfSiteSubsectorTVText,
                                             UseOfSiteUseEquation = c.UseOfSiteUseEquation,
                                             UseOfSiteUseOfSiteID = c.UseOfSiteUseOfSiteID,
                                             UseOfSiteUseWeight = c.UseOfSiteUseWeight,
                                             UseOfSiteWeight_perc = c.UseOfSiteWeight_perc,
                                             Vector = c.Vector,
                                             VectorEndNode = c.VectorEndNode,
                                             VectorHasErrors = c.VectorHasErrors,
                                             VectorStartNode = c.VectorStartNode,
                                             VPAmbient = c.VPAmbient,
                                             VPAmbientAmbientSalinity_PSU = c.VPAmbientAmbientSalinity_PSU,
                                             VPAmbientAmbientTemperature_C = c.VPAmbientAmbientTemperature_C,
                                             VPAmbientBackgroundConcentration_MPN_100ml = c.VPAmbientBackgroundConcentration_MPN_100ml,
                                             VPAmbientCurrentDirection_deg = c.VPAmbientCurrentDirection_deg,
                                             VPAmbientCurrentSpeed_m_s = c.VPAmbientCurrentSpeed_m_s,
                                             VPAmbientFarFieldCurrentDirection_deg = c.VPAmbientFarFieldCurrentDirection_deg,
                                             VPAmbientFarFieldCurrentSpeed_m_s = c.VPAmbientFarFieldCurrentSpeed_m_s,
                                             VPAmbientFarFieldDiffusionCoefficient = c.VPAmbientFarFieldDiffusionCoefficient,
                                             VPAmbientHasErrors = c.VPAmbientHasErrors,
                                             VPAmbientLastUpdateContactTVItemID = c.VPAmbientLastUpdateContactTVItemID,
                                             VPAmbientLastUpdateContactTVText = c.VPAmbientLastUpdateContactTVText,
                                             VPAmbientLastUpdateDate_UTC = c.VPAmbientLastUpdateDate_UTC,
                                             VPAmbientMeasurementDepth_m = c.VPAmbientMeasurementDepth_m,
                                             VPAmbientPollutantDecayRate_per_day = c.VPAmbientPollutantDecayRate_per_day,
                                             VPAmbientRow = c.VPAmbientRow,
                                             VPAmbientVPAmbientID = c.VPAmbientVPAmbientID,
                                             VPAmbientVPScenarioID = c.VPAmbientVPScenarioID,
                                             VPFull = c.VPFull,
                                             VPFullHasErrors = c.VPFullHasErrors,
                                             VPFullVPAmbientList = c.VPFullVPAmbientList,
                                             VPFullVPResultList = c.VPFullVPResultList,
                                             VPFullVPScenario = c.VPFullVPScenario,
                                             VPResult = c.VPResult,
                                             VPResultConcentration_MPN_100ml = c.VPResultConcentration_MPN_100ml,
                                             VPResultDilution = c.VPResultDilution,
                                             VPResultDispersionDistance_m = c.VPResultDispersionDistance_m,
                                             VPResultFarFieldWidth_m = c.VPResultFarFieldWidth_m,
                                             VPResultHasErrors = c.VPResultHasErrors,
                                             VPResultLastUpdateContactTVItemID = c.VPResultLastUpdateContactTVItemID,
                                             VPResultLastUpdateContactTVText = c.VPResultLastUpdateContactTVText,
                                             VPResultLastUpdateDate_UTC = c.VPResultLastUpdateDate_UTC,
                                             VPResultOrdinal = c.VPResultOrdinal,
                                             VPResultTravelTime_hour = c.VPResultTravelTime_hour,
                                             VPResultVPResultID = c.VPResultVPResultID,
                                             VPResultVPScenarioID = c.VPResultVPScenarioID,
                                             VPResValues = c.VPResValues,
                                             VPResValuesConc = c.VPResValuesConc,
                                             VPResValuesDecay = c.VPResValuesDecay,
                                             VPResValuesDilu = c.VPResValuesDilu,
                                             VPResValuesDistance = c.VPResValuesDistance,
                                             VPResValuesFarfieldWidth = c.VPResValuesFarfieldWidth,
                                             VPResValuesHasErrors = c.VPResValuesHasErrors,
                                             VPResValuesTheTime = c.VPResValuesTheTime,
                                             VPScenario = c.VPScenario,
                                             VPScenarioAcuteMixZone_m = c.VPScenarioAcuteMixZone_m,
                                             VPScenarioChronicMixZone_m = c.VPScenarioChronicMixZone_m,
                                             VPScenarioEffluentConcentration_MPN_100ml = c.VPScenarioEffluentConcentration_MPN_100ml,
                                             VPScenarioEffluentFlow_m3_s = c.VPScenarioEffluentFlow_m3_s,
                                             VPScenarioEffluentSalinity_PSU = c.VPScenarioEffluentSalinity_PSU,
                                             VPScenarioEffluentTemperature_C = c.VPScenarioEffluentTemperature_C,
                                             VPScenarioEffluentVelocity_m_s = c.VPScenarioEffluentVelocity_m_s,
                                             VPScenarioFroudeNumber = c.VPScenarioFroudeNumber,
                                             VPScenarioHasErrors = c.VPScenarioHasErrors,
                                             VPScenarioHorizontalAngle_deg = c.VPScenarioHorizontalAngle_deg,
                                             VPScenarioIDAndRawResults = c.VPScenarioIDAndRawResults,
                                             VPScenarioIDAndRawResultsHasErrors = c.VPScenarioIDAndRawResultsHasErrors,
                                             VPScenarioIDAndRawResultsRawResults = c.VPScenarioIDAndRawResultsRawResults,
                                             VPScenarioIDAndRawResultsVPScenarioID = c.VPScenarioIDAndRawResultsVPScenarioID,
                                             VPScenarioInfrastructureTVItemID = c.VPScenarioInfrastructureTVItemID,
                                             VPScenarioLanguage = c.VPScenarioLanguage,
                                             VPScenarioLanguageHasErrors = c.VPScenarioLanguageHasErrors,
                                             VPScenarioLanguageLanguage = c.VPScenarioLanguageLanguage,
                                             VPScenarioLanguageLanguageText = c.VPScenarioLanguageLanguageText,
                                             VPScenarioLanguageLastUpdateContactTVItemID = c.VPScenarioLanguageLastUpdateContactTVItemID,
                                             VPScenarioLanguageLastUpdateContactTVText = c.VPScenarioLanguageLastUpdateContactTVText,
                                             VPScenarioLanguageLastUpdateDate_UTC = c.VPScenarioLanguageLastUpdateDate_UTC,
                                             VPScenarioLanguageTranslationStatus = c.VPScenarioLanguageTranslationStatus,
                                             VPScenarioLanguageTranslationStatusText = c.VPScenarioLanguageTranslationStatusText,
                                             VPScenarioLanguageVPScenarioID = c.VPScenarioLanguageVPScenarioID,
                                             VPScenarioLanguageVPScenarioLanguageID = c.VPScenarioLanguageVPScenarioLanguageID,
                                             VPScenarioLanguageVPScenarioName = c.VPScenarioLanguageVPScenarioName,
                                             VPScenarioLastUpdateContactTVItemID = c.VPScenarioLastUpdateContactTVItemID,
                                             VPScenarioLastUpdateContactTVText = c.VPScenarioLastUpdateContactTVText,
                                             VPScenarioLastUpdateDate_UTC = c.VPScenarioLastUpdateDate_UTC,
                                             VPScenarioNumberOfPorts = c.VPScenarioNumberOfPorts,
                                             VPScenarioPortDepth_m = c.VPScenarioPortDepth_m,
                                             VPScenarioPortDiameter_m = c.VPScenarioPortDiameter_m,
                                             VPScenarioPortElevation_m = c.VPScenarioPortElevation_m,
                                             VPScenarioPortSpacing_m = c.VPScenarioPortSpacing_m,
                                             VPScenarioRawResults = c.VPScenarioRawResults,
                                             VPScenarioSubsectorTVText = c.VPScenarioSubsectorTVText,
                                             VPScenarioUseAsBestEstimate = c.VPScenarioUseAsBestEstimate,
                                             VPScenarioVerticalAngle_deg = c.VPScenarioVerticalAngle_deg,
                                             VPScenarioVPScenarioID = c.VPScenarioVPScenarioID,
                                             VPScenarioVPScenarioStatus = c.VPScenarioVPScenarioStatus,
                                             VPScenarioVPScenarioStatusText = c.VPScenarioVPScenarioStatusText,
                                             ValidationResults = null,
                                         }).ToList();

            return CSSPModelsResList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
        private bool TryToSave(CSSPModelsRes cSSPModelsRes)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                cSSPModelsRes.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated

    }
}
