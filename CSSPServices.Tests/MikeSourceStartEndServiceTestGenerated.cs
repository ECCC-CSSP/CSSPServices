using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using CSSPModels;
using CSSPServices;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;
using System.Security.Principal;
using System.Globalization;
using CSSPServices.Resources;
using CSSPModels.Resources;
using CSSPEnums.Resources;

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class MikeSourceStartEndServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MikeSourceStartEndService mikeSourceStartEndService { get; set; }
        #endregion Properties

        #region Constructors
        public MikeSourceStartEndServiceTest() : base()
        {
            //mikeSourceStartEndService = new MikeSourceStartEndService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MikeSourceStartEnd_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    MikeSourceStartEnd mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = mikeSourceStartEndService.GetRead().Count();

                    Assert.AreEqual(mikeSourceStartEndService.GetRead().Count(), mikeSourceStartEndService.GetEdit().Count());

                    mikeSourceStartEndService.Add(mikeSourceStartEnd);
                    if (mikeSourceStartEnd.HasErrors)
                    {
                        Assert.AreEqual("", mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mikeSourceStartEndService.GetRead().Where(c => c == mikeSourceStartEnd).Any());
                    mikeSourceStartEndService.Update(mikeSourceStartEnd);
                    if (mikeSourceStartEnd.HasErrors)
                    {
                        Assert.AreEqual("", mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mikeSourceStartEndService.GetRead().Count());
                    mikeSourceStartEndService.Delete(mikeSourceStartEnd);
                    if (mikeSourceStartEnd.HasErrors)
                    {
                        Assert.AreEqual("", mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // mikeSourceStartEnd.MikeSourceStartEndID   (Int32)
                    // -----------------------------------

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.MikeSourceStartEndID = 0;
                    mikeSourceStartEndService.Update(mikeSourceStartEnd);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeSourceStartEndMikeSourceStartEndID), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.MikeSourceStartEndID = 10000000;
                    mikeSourceStartEndService.Update(mikeSourceStartEnd);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MikeSourceStartEnd, CSSPModelsRes.MikeSourceStartEndMikeSourceStartEndID, mikeSourceStartEnd.MikeSourceStartEndID.ToString()), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "MikeSource", ExistPlurial = "s", ExistFieldID = "MikeSourceID", AllowableTVtypeList = )]
                    // mikeSourceStartEnd.MikeSourceID   (Int32)
                    // -----------------------------------

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.MikeSourceID = 0;
                    mikeSourceStartEndService.Add(mikeSourceStartEnd);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MikeSource, CSSPModelsRes.MikeSourceStartEndMikeSourceID, mikeSourceStartEnd.MikeSourceID.ToString()), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mikeSourceStartEnd.StartDateAndTime_Local   (DateTime)
                    // -----------------------------------

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.StartDateAndTime_Local = new DateTime();
                    mikeSourceStartEndService.Add(mikeSourceStartEnd);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeSourceStartEndStartDateAndTime_Local), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.StartDateAndTime_Local = new DateTime(1979, 1, 1);
                    mikeSourceStartEndService.Add(mikeSourceStartEnd);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MikeSourceStartEndStartDateAndTime_Local, "1980"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // [CSSPBigger(OtherField = StartDateAndTime_Local)]
                    // mikeSourceStartEnd.EndDateAndTime_Local   (DateTime)
                    // -----------------------------------

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.EndDateAndTime_Local = new DateTime();
                    mikeSourceStartEndService.Add(mikeSourceStartEnd);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeSourceStartEndEndDateAndTime_Local), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.EndDateAndTime_Local = new DateTime(1979, 1, 1);
                    mikeSourceStartEndService.Add(mikeSourceStartEnd);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MikeSourceStartEndEndDateAndTime_Local, "1980"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000000)]
                    // mikeSourceStartEnd.SourceFlowStart_m3_day   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [SourceFlowStart_m3_day]

                    //Error: Type not implemented [SourceFlowStart_m3_day]

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourceFlowStart_m3_day = -1.0D;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceFlowStart_m3_day, "0", "1000000"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourceFlowStart_m3_day = 1000001.0D;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceFlowStart_m3_day, "0", "1000000"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000000)]
                    // mikeSourceStartEnd.SourceFlowEnd_m3_day   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [SourceFlowEnd_m3_day]

                    //Error: Type not implemented [SourceFlowEnd_m3_day]

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourceFlowEnd_m3_day = -1.0D;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceFlowEnd_m3_day, "0", "1000000"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourceFlowEnd_m3_day = 1000001.0D;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceFlowEnd_m3_day, "0", "1000000"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000000)]
                    // mikeSourceStartEnd.SourcePollutionStart_MPN_100ml   (Int32)
                    // -----------------------------------

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = -1;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourcePollutionStart_MPN_100ml, "0", "10000000"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = 10000001;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourcePollutionStart_MPN_100ml, "0", "10000000"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000000)]
                    // mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml   (Int32)
                    // -----------------------------------

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = -1;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourcePollutionEnd_MPN_100ml, "0", "10000000"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = 10000001;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourcePollutionEnd_MPN_100ml, "0", "10000000"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(-10, 40)]
                    // mikeSourceStartEnd.SourceTemperatureStart_C   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [SourceTemperatureStart_C]

                    //Error: Type not implemented [SourceTemperatureStart_C]

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourceTemperatureStart_C = -11.0D;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceTemperatureStart_C, "-10", "40"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourceTemperatureStart_C = 41.0D;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceTemperatureStart_C, "-10", "40"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(-10, 40)]
                    // mikeSourceStartEnd.SourceTemperatureEnd_C   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [SourceTemperatureEnd_C]

                    //Error: Type not implemented [SourceTemperatureEnd_C]

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourceTemperatureEnd_C = -11.0D;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceTemperatureEnd_C, "-10", "40"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourceTemperatureEnd_C = 41.0D;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceTemperatureEnd_C, "-10", "40"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 40)]
                    // mikeSourceStartEnd.SourceSalinityStart_PSU   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [SourceSalinityStart_PSU]

                    //Error: Type not implemented [SourceSalinityStart_PSU]

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourceSalinityStart_PSU = -1.0D;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceSalinityStart_PSU, "0", "40"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourceSalinityStart_PSU = 41.0D;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceSalinityStart_PSU, "0", "40"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 40)]
                    // mikeSourceStartEnd.SourceSalinityEnd_PSU   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [SourceSalinityEnd_PSU]

                    //Error: Type not implemented [SourceSalinityEnd_PSU]

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourceSalinityEnd_PSU = -1.0D;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceSalinityEnd_PSU, "0", "40"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());
                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.SourceSalinityEnd_PSU = 41.0D;
                    Assert.AreEqual(false, mikeSourceStartEndService.Add(mikeSourceStartEnd));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceSalinityEnd_PSU, "0", "40"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeSourceStartEndService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mikeSourceStartEnd.MikeSourceStartEndWeb   (MikeSourceStartEndWeb)
                    // -----------------------------------

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.MikeSourceStartEndWeb = null;
                    Assert.IsNull(mikeSourceStartEnd.MikeSourceStartEndWeb);

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.MikeSourceStartEndWeb = new MikeSourceStartEndWeb();
                    Assert.IsNotNull(mikeSourceStartEnd.MikeSourceStartEndWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mikeSourceStartEnd.MikeSourceStartEndReport   (MikeSourceStartEndReport)
                    // -----------------------------------

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.MikeSourceStartEndReport = null;
                    Assert.IsNull(mikeSourceStartEnd.MikeSourceStartEndReport);

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.MikeSourceStartEndReport = new MikeSourceStartEndReport();
                    Assert.IsNotNull(mikeSourceStartEnd.MikeSourceStartEndReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mikeSourceStartEnd.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.LastUpdateDate_UTC = new DateTime();
                    mikeSourceStartEndService.Add(mikeSourceStartEnd);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeSourceStartEndLastUpdateDate_UTC), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);
                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mikeSourceStartEndService.Add(mikeSourceStartEnd);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MikeSourceStartEndLastUpdateDate_UTC, "1980"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mikeSourceStartEnd.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.LastUpdateContactTVItemID = 0;
                    mikeSourceStartEndService.Add(mikeSourceStartEnd);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MikeSourceStartEndLastUpdateContactTVItemID, mikeSourceStartEnd.LastUpdateContactTVItemID.ToString()), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);

                    mikeSourceStartEnd = null;
                    mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
                    mikeSourceStartEnd.LastUpdateContactTVItemID = 1;
                    mikeSourceStartEndService.Add(mikeSourceStartEnd);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MikeSourceStartEndLastUpdateContactTVItemID, "Contact"), mikeSourceStartEnd.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mikeSourceStartEnd.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mikeSourceStartEnd.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetMikeSourceStartEndWithMikeSourceStartEndID(mikeSourceStartEnd.MikeSourceStartEndID)
        [TestMethod]
        public void GetMikeSourceStartEndWithMikeSourceStartEndID__mikeSourceStartEnd_MikeSourceStartEndID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MikeSourceStartEnd mikeSourceStartEnd = (from c in mikeSourceStartEndService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mikeSourceStartEnd);

                    MikeSourceStartEnd mikeSourceStartEndRet = null;
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mikeSourceStartEndService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            mikeSourceStartEndRet = mikeSourceStartEndService.GetMikeSourceStartEndWithMikeSourceStartEndID(mikeSourceStartEnd.MikeSourceStartEndID);
                            Assert.IsNull(mikeSourceStartEndRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mikeSourceStartEndRet = mikeSourceStartEndService.GetMikeSourceStartEndWithMikeSourceStartEndID(mikeSourceStartEnd.MikeSourceStartEndID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mikeSourceStartEndRet = mikeSourceStartEndService.GetMikeSourceStartEndWithMikeSourceStartEndID(mikeSourceStartEnd.MikeSourceStartEndID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mikeSourceStartEndRet = mikeSourceStartEndService.GetMikeSourceStartEndWithMikeSourceStartEndID(mikeSourceStartEnd.MikeSourceStartEndID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMikeSourceStartEndFields(new List<MikeSourceStartEnd>() { mikeSourceStartEndRet }, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeSourceStartEndWithMikeSourceStartEndID(mikeSourceStartEnd.MikeSourceStartEndID)

        #region Tests Generated for GetMikeSourceStartEndList()
        [TestMethod]
        public void GetMikeSourceStartEndList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MikeSourceStartEnd mikeSourceStartEnd = (from c in mikeSourceStartEndService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mikeSourceStartEnd);

                    List<MikeSourceStartEnd> mikeSourceStartEndList = new List<MikeSourceStartEnd>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mikeSourceStartEndService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            mikeSourceStartEndList = mikeSourceStartEndService.GetMikeSourceStartEndList().ToList();
                            Assert.AreEqual(0, mikeSourceStartEndList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mikeSourceStartEndList = mikeSourceStartEndService.GetMikeSourceStartEndList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mikeSourceStartEndList = mikeSourceStartEndService.GetMikeSourceStartEndList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mikeSourceStartEndList = mikeSourceStartEndService.GetMikeSourceStartEndList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMikeSourceStartEndFields(mikeSourceStartEndList, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeSourceStartEndList()

        #region Tests Generated for GetMikeSourceStartEndList() Skip Take
        [TestMethod]
        public void GetMikeSourceStartEndList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MikeSourceStartEnd> mikeSourceStartEndList = new List<MikeSourceStartEnd>();
                    List<MikeSourceStartEnd> mikeSourceStartEndDirectQueryList = new List<MikeSourceStartEnd>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mikeSourceStartEndService.Query = mikeSourceStartEndService.FillQuery(typeof(MikeSourceStartEnd), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mikeSourceStartEndDirectQueryList = mikeSourceStartEndService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mikeSourceStartEndList = mikeSourceStartEndService.GetMikeSourceStartEndList().ToList();
                            Assert.AreEqual(0, mikeSourceStartEndList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mikeSourceStartEndList = mikeSourceStartEndService.GetMikeSourceStartEndList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mikeSourceStartEndList = mikeSourceStartEndService.GetMikeSourceStartEndList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mikeSourceStartEndList = mikeSourceStartEndService.GetMikeSourceStartEndList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMikeSourceStartEndFields(mikeSourceStartEndList, entityQueryDetailType);
                        Assert.AreEqual(mikeSourceStartEndDirectQueryList[0].MikeSourceStartEndID, mikeSourceStartEndList[0].MikeSourceStartEndID);
                        Assert.AreEqual(1, mikeSourceStartEndList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeSourceStartEndList() Skip Take

        #region Tests Generated for GetMikeSourceStartEndList() Skip Take Order
        [TestMethod]
        public void GetMikeSourceStartEndList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MikeSourceStartEnd> mikeSourceStartEndList = new List<MikeSourceStartEnd>();
                    List<MikeSourceStartEnd> mikeSourceStartEndDirectQueryList = new List<MikeSourceStartEnd>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mikeSourceStartEndService.Query = mikeSourceStartEndService.FillQuery(typeof(MikeSourceStartEnd), culture.TwoLetterISOLanguageName, 1, 1,  "MikeSourceStartEndID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mikeSourceStartEndDirectQueryList = mikeSourceStartEndService.GetRead().Skip(1).Take(1).OrderBy(c => c.MikeSourceStartEndID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mikeSourceStartEndList = mikeSourceStartEndService.GetMikeSourceStartEndList().ToList();
                            Assert.AreEqual(0, mikeSourceStartEndList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mikeSourceStartEndList = mikeSourceStartEndService.GetMikeSourceStartEndList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mikeSourceStartEndList = mikeSourceStartEndService.GetMikeSourceStartEndList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mikeSourceStartEndList = mikeSourceStartEndService.GetMikeSourceStartEndList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMikeSourceStartEndFields(mikeSourceStartEndList, entityQueryDetailType);
                        Assert.AreEqual(mikeSourceStartEndDirectQueryList[0].MikeSourceStartEndID, mikeSourceStartEndList[0].MikeSourceStartEndID);
                        Assert.AreEqual(1, mikeSourceStartEndList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeSourceStartEndList() Skip Take Order

        #region Tests Generated for GetMikeSourceStartEndList() Skip Take 2Order
        [TestMethod]
        public void GetMikeSourceStartEndList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MikeSourceStartEnd> mikeSourceStartEndList = new List<MikeSourceStartEnd>();
                    List<MikeSourceStartEnd> mikeSourceStartEndDirectQueryList = new List<MikeSourceStartEnd>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mikeSourceStartEndService.Query = mikeSourceStartEndService.FillQuery(typeof(MikeSourceStartEnd), culture.TwoLetterISOLanguageName, 1, 1, "MikeSourceStartEndID,MikeSourceID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mikeSourceStartEndDirectQueryList = mikeSourceStartEndService.GetRead().Skip(1).Take(1).OrderBy(c => c.MikeSourceStartEndID).ThenBy(c => c.MikeSourceID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mikeSourceStartEndList = mikeSourceStartEndService.GetMikeSourceStartEndList().ToList();
                            Assert.AreEqual(0, mikeSourceStartEndList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mikeSourceStartEndList = mikeSourceStartEndService.GetMikeSourceStartEndList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mikeSourceStartEndList = mikeSourceStartEndService.GetMikeSourceStartEndList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mikeSourceStartEndList = mikeSourceStartEndService.GetMikeSourceStartEndList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMikeSourceStartEndFields(mikeSourceStartEndList, entityQueryDetailType);
                        Assert.AreEqual(mikeSourceStartEndDirectQueryList[0].MikeSourceStartEndID, mikeSourceStartEndList[0].MikeSourceStartEndID);
                        Assert.AreEqual(1, mikeSourceStartEndList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeSourceStartEndList() Skip Take 2Order

        #region Tests Generated for GetMikeSourceStartEndList() Skip Take Order Where
        [TestMethod]
        public void GetMikeSourceStartEndList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MikeSourceStartEnd> mikeSourceStartEndList = new List<MikeSourceStartEnd>();
                    List<MikeSourceStartEnd> mikeSourceStartEndDirectQueryList = new List<MikeSourceStartEnd>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mikeSourceStartEndService.Query = mikeSourceStartEndService.FillQuery(typeof(MikeSourceStartEnd), culture.TwoLetterISOLanguageName, 0, 1, "MikeSourceStartEndID", "MikeSourceStartEndID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mikeSourceStartEndDirectQueryList = mikeSourceStartEndService.GetRead().Where(c => c.MikeSourceStartEndID == 4).Skip(0).Take(1).OrderBy(c => c.MikeSourceStartEndID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mikeSourceStartEndList = mikeSourceStartEndService.GetMikeSourceStartEndList().ToList();
                            Assert.AreEqual(0, mikeSourceStartEndList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mikeSourceStartEndList = mikeSourceStartEndService.GetMikeSourceStartEndList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mikeSourceStartEndList = mikeSourceStartEndService.GetMikeSourceStartEndList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mikeSourceStartEndList = mikeSourceStartEndService.GetMikeSourceStartEndList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMikeSourceStartEndFields(mikeSourceStartEndList, entityQueryDetailType);
                        Assert.AreEqual(mikeSourceStartEndDirectQueryList[0].MikeSourceStartEndID, mikeSourceStartEndList[0].MikeSourceStartEndID);
                        Assert.AreEqual(1, mikeSourceStartEndList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeSourceStartEndList() Skip Take Order Where

        #region Tests Generated for GetMikeSourceStartEndList() Skip Take Order 2Where
        [TestMethod]
        public void GetMikeSourceStartEndList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MikeSourceStartEnd> mikeSourceStartEndList = new List<MikeSourceStartEnd>();
                    List<MikeSourceStartEnd> mikeSourceStartEndDirectQueryList = new List<MikeSourceStartEnd>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mikeSourceStartEndService.Query = mikeSourceStartEndService.FillQuery(typeof(MikeSourceStartEnd), culture.TwoLetterISOLanguageName, 0, 1, "MikeSourceStartEndID", "MikeSourceStartEndID,GT,2|MikeSourceStartEndID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mikeSourceStartEndDirectQueryList = mikeSourceStartEndService.GetRead().Where(c => c.MikeSourceStartEndID > 2 && c.MikeSourceStartEndID < 5).Skip(0).Take(1).OrderBy(c => c.MikeSourceStartEndID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mikeSourceStartEndList = mikeSourceStartEndService.GetMikeSourceStartEndList().ToList();
                            Assert.AreEqual(0, mikeSourceStartEndList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mikeSourceStartEndList = mikeSourceStartEndService.GetMikeSourceStartEndList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mikeSourceStartEndList = mikeSourceStartEndService.GetMikeSourceStartEndList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mikeSourceStartEndList = mikeSourceStartEndService.GetMikeSourceStartEndList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMikeSourceStartEndFields(mikeSourceStartEndList, entityQueryDetailType);
                        Assert.AreEqual(mikeSourceStartEndDirectQueryList[0].MikeSourceStartEndID, mikeSourceStartEndList[0].MikeSourceStartEndID);
                        Assert.AreEqual(1, mikeSourceStartEndList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeSourceStartEndList() Skip Take Order 2Where

        #region Tests Generated for GetMikeSourceStartEndList() 2Where
        [TestMethod]
        public void GetMikeSourceStartEndList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MikeSourceStartEnd> mikeSourceStartEndList = new List<MikeSourceStartEnd>();
                    List<MikeSourceStartEnd> mikeSourceStartEndDirectQueryList = new List<MikeSourceStartEnd>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mikeSourceStartEndService.Query = mikeSourceStartEndService.FillQuery(typeof(MikeSourceStartEnd), culture.TwoLetterISOLanguageName, 0, 10000, "", "MikeSourceStartEndID,GT,2|MikeSourceStartEndID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mikeSourceStartEndDirectQueryList = mikeSourceStartEndService.GetRead().Where(c => c.MikeSourceStartEndID > 2 && c.MikeSourceStartEndID < 5).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mikeSourceStartEndList = mikeSourceStartEndService.GetMikeSourceStartEndList().ToList();
                            Assert.AreEqual(0, mikeSourceStartEndList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mikeSourceStartEndList = mikeSourceStartEndService.GetMikeSourceStartEndList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mikeSourceStartEndList = mikeSourceStartEndService.GetMikeSourceStartEndList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mikeSourceStartEndList = mikeSourceStartEndService.GetMikeSourceStartEndList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMikeSourceStartEndFields(mikeSourceStartEndList, entityQueryDetailType);
                        Assert.AreEqual(mikeSourceStartEndDirectQueryList[0].MikeSourceStartEndID, mikeSourceStartEndList[0].MikeSourceStartEndID);
                        Assert.AreEqual(2, mikeSourceStartEndList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeSourceStartEndList() 2Where

        #region Functions private
        private void CheckMikeSourceStartEndFields(List<MikeSourceStartEnd> mikeSourceStartEndList, EntityQueryDetailTypeEnum? entityQueryDetailType)
        {
            // MikeSourceStartEnd fields
            Assert.IsNotNull(mikeSourceStartEndList[0].MikeSourceStartEndID);
            Assert.IsNotNull(mikeSourceStartEndList[0].MikeSourceID);
            Assert.IsNotNull(mikeSourceStartEndList[0].StartDateAndTime_Local);
            Assert.IsNotNull(mikeSourceStartEndList[0].EndDateAndTime_Local);
            Assert.IsNotNull(mikeSourceStartEndList[0].SourceFlowStart_m3_day);
            Assert.IsNotNull(mikeSourceStartEndList[0].SourceFlowEnd_m3_day);
            Assert.IsNotNull(mikeSourceStartEndList[0].SourcePollutionStart_MPN_100ml);
            Assert.IsNotNull(mikeSourceStartEndList[0].SourcePollutionEnd_MPN_100ml);
            Assert.IsNotNull(mikeSourceStartEndList[0].SourceTemperatureStart_C);
            Assert.IsNotNull(mikeSourceStartEndList[0].SourceTemperatureEnd_C);
            Assert.IsNotNull(mikeSourceStartEndList[0].SourceSalinityStart_PSU);
            Assert.IsNotNull(mikeSourceStartEndList[0].SourceSalinityEnd_PSU);
            Assert.IsNotNull(mikeSourceStartEndList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mikeSourceStartEndList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // MikeSourceStartEndWeb and MikeSourceStartEndReport fields should be null here
                Assert.IsNull(mikeSourceStartEndList[0].MikeSourceStartEndWeb);
                Assert.IsNull(mikeSourceStartEndList[0].MikeSourceStartEndReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // MikeSourceStartEndWeb fields should not be null and MikeSourceStartEndReport fields should be null here
                Assert.IsNotNull(mikeSourceStartEndList[0].MikeSourceStartEndWeb.LastUpdateContactTVItemLanguage);
                Assert.IsNull(mikeSourceStartEndList[0].MikeSourceStartEndReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // MikeSourceStartEndWeb and MikeSourceStartEndReport fields should NOT be null here
                Assert.IsNotNull(mikeSourceStartEndList[0].MikeSourceStartEndWeb.LastUpdateContactTVItemLanguage);
                if (mikeSourceStartEndList[0].MikeSourceStartEndReport.MikeSourceStartEndReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mikeSourceStartEndList[0].MikeSourceStartEndReport.MikeSourceStartEndReportTest));
                }
            }
        }
        private MikeSourceStartEnd GetFilledRandomMikeSourceStartEnd(string OmitPropName)
        {
            MikeSourceStartEnd mikeSourceStartEnd = new MikeSourceStartEnd();

            if (OmitPropName != "MikeSourceID") mikeSourceStartEnd.MikeSourceID = 1;
            if (OmitPropName != "StartDateAndTime_Local") mikeSourceStartEnd.StartDateAndTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDateAndTime_Local") mikeSourceStartEnd.EndDateAndTime_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "SourceFlowStart_m3_day") mikeSourceStartEnd.SourceFlowStart_m3_day = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "SourceFlowEnd_m3_day") mikeSourceStartEnd.SourceFlowEnd_m3_day = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "SourcePollutionStart_MPN_100ml") mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "SourcePollutionEnd_MPN_100ml") mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "SourceTemperatureStart_C") mikeSourceStartEnd.SourceTemperatureStart_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "SourceTemperatureEnd_C") mikeSourceStartEnd.SourceTemperatureEnd_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "SourceSalinityStart_PSU") mikeSourceStartEnd.SourceSalinityStart_PSU = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "SourceSalinityEnd_PSU") mikeSourceStartEnd.SourceSalinityEnd_PSU = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "LastUpdateDate_UTC") mikeSourceStartEnd.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mikeSourceStartEnd.LastUpdateContactTVItemID = 2;

            return mikeSourceStartEnd;
        }
        #endregion Functions private
    }
}
