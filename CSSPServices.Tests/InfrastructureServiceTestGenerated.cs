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
    public partial class InfrastructureServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private InfrastructureService infrastructureService { get; set; }
        #endregion Properties

        #region Constructors
        public InfrastructureServiceTest() : base()
        {
            //infrastructureService = new InfrastructureService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void Infrastructure_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    InfrastructureService infrastructureService = new InfrastructureService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    Infrastructure infrastructure = GetFilledRandomInfrastructure("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = infrastructureService.GetInfrastructureList().Count();

                    Assert.AreEqual(infrastructureService.GetInfrastructureList().Count(), (from c in dbTestDB.Infrastructures select c).Take(200).Count());

                    infrastructureService.Add(infrastructure);
                    if (infrastructure.HasErrors)
                    {
                        Assert.AreEqual("", infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, infrastructureService.GetInfrastructureList().Where(c => c == infrastructure).Any());
                    infrastructureService.Update(infrastructure);
                    if (infrastructure.HasErrors)
                    {
                        Assert.AreEqual("", infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, infrastructureService.GetInfrastructureList().Count());
                    infrastructureService.Delete(infrastructure);
                    if (infrastructure.HasErrors)
                    {
                        Assert.AreEqual("", infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // infrastructure.InfrastructureID   (Int32)
                    // -----------------------------------

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.InfrastructureID = 0;
                    infrastructureService.Update(infrastructure);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "InfrastructureInfrastructureID"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.InfrastructureID = 10000000;
                    infrastructureService.Update(infrastructure);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Infrastructure", "InfrastructureInfrastructureID", infrastructure.InfrastructureID.ToString()), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Infrastructure)]
                    // infrastructure.InfrastructureTVItemID   (Int32)
                    // -----------------------------------

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.InfrastructureTVItemID = 0;
                    infrastructureService.Add(infrastructure);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "InfrastructureInfrastructureTVItemID", infrastructure.InfrastructureTVItemID.ToString()), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.InfrastructureTVItemID = 1;
                    infrastructureService.Add(infrastructure);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "InfrastructureInfrastructureTVItemID", "Infrastructure"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100000)]
                    // infrastructure.PrismID   (Int32)
                    // -----------------------------------

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.PrismID = -1;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructurePrismID", "0", "100000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.PrismID = 100001;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructurePrismID", "0", "100000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100000)]
                    // infrastructure.TPID   (Int32)
                    // -----------------------------------

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.TPID = -1;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureTPID", "0", "100000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.TPID = 100001;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureTPID", "0", "100000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100000)]
                    // infrastructure.LSID   (Int32)
                    // -----------------------------------

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.LSID = -1;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureLSID", "0", "100000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.LSID = 100001;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureLSID", "0", "100000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100000)]
                    // infrastructure.SiteID   (Int32)
                    // -----------------------------------

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.SiteID = -1;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureSiteID", "0", "100000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.SiteID = 100001;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureSiteID", "0", "100000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100000)]
                    // infrastructure.Site   (Int32)
                    // -----------------------------------

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.Site = -1;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureSite", "0", "100000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.Site = 100001;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureSite", "0", "100000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // infrastructure.InfrastructureCategory   (String)
                    // -----------------------------------

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.InfrastructureCategory = GetRandomString("", 2);
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "InfrastructureInfrastructureCategory", "1", "1"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // infrastructure.InfrastructureType   (InfrastructureTypeEnum)
                    // -----------------------------------

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.InfrastructureType = (InfrastructureTypeEnum)1000000;
                    infrastructureService.Add(infrastructure);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "InfrastructureInfrastructureType"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // infrastructure.FacilityType   (FacilityTypeEnum)
                    // -----------------------------------

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.FacilityType = (FacilityTypeEnum)1000000;
                    infrastructureService.Add(infrastructure);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "InfrastructureFacilityType"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // infrastructure.IsMechanicallyAerated   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10)]
                    // infrastructure.NumberOfCells   (Int32)
                    // -----------------------------------

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.NumberOfCells = -1;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureNumberOfCells", "0", "10"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.NumberOfCells = 11;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureNumberOfCells", "0", "10"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10)]
                    // infrastructure.NumberOfAeratedCells   (Int32)
                    // -----------------------------------

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.NumberOfAeratedCells = -1;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureNumberOfAeratedCells", "0", "10"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.NumberOfAeratedCells = 11;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureNumberOfAeratedCells", "0", "10"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // infrastructure.AerationType   (AerationTypeEnum)
                    // -----------------------------------

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.AerationType = (AerationTypeEnum)1000000;
                    infrastructureService.Add(infrastructure);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "InfrastructureAerationType"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // infrastructure.PreliminaryTreatmentType   (PreliminaryTreatmentTypeEnum)
                    // -----------------------------------

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.PreliminaryTreatmentType = (PreliminaryTreatmentTypeEnum)1000000;
                    infrastructureService.Add(infrastructure);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "InfrastructurePreliminaryTreatmentType"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // infrastructure.PrimaryTreatmentType   (PrimaryTreatmentTypeEnum)
                    // -----------------------------------

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.PrimaryTreatmentType = (PrimaryTreatmentTypeEnum)1000000;
                    infrastructureService.Add(infrastructure);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "InfrastructurePrimaryTreatmentType"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // infrastructure.SecondaryTreatmentType   (SecondaryTreatmentTypeEnum)
                    // -----------------------------------

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.SecondaryTreatmentType = (SecondaryTreatmentTypeEnum)1000000;
                    infrastructureService.Add(infrastructure);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "InfrastructureSecondaryTreatmentType"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // infrastructure.TertiaryTreatmentType   (TertiaryTreatmentTypeEnum)
                    // -----------------------------------

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.TertiaryTreatmentType = (TertiaryTreatmentTypeEnum)1000000;
                    infrastructureService.Add(infrastructure);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "InfrastructureTertiaryTreatmentType"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // infrastructure.TreatmentType   (TreatmentTypeEnum)
                    // -----------------------------------

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.TreatmentType = (TreatmentTypeEnum)1000000;
                    infrastructureService.Add(infrastructure);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "InfrastructureTreatmentType"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // infrastructure.DisinfectionType   (DisinfectionTypeEnum)
                    // -----------------------------------

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.DisinfectionType = (DisinfectionTypeEnum)1000000;
                    infrastructureService.Add(infrastructure);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "InfrastructureDisinfectionType"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // infrastructure.CollectionSystemType   (CollectionSystemTypeEnum)
                    // -----------------------------------

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.CollectionSystemType = (CollectionSystemTypeEnum)1000000;
                    infrastructureService.Add(infrastructure);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "InfrastructureCollectionSystemType"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // infrastructure.AlarmSystemType   (AlarmSystemTypeEnum)
                    // -----------------------------------

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.AlarmSystemType = (AlarmSystemTypeEnum)1000000;
                    infrastructureService.Add(infrastructure);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "InfrastructureAlarmSystemType"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 1000000)]
                    // infrastructure.DesignFlow_m3_day   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [DesignFlow_m3_day]

                    //Error: Type not implemented [DesignFlow_m3_day]

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.DesignFlow_m3_day = -1.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureDesignFlow_m3_day", "0", "1000000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.DesignFlow_m3_day = 1000001.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureDesignFlow_m3_day", "0", "1000000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 1000000)]
                    // infrastructure.AverageFlow_m3_day   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [AverageFlow_m3_day]

                    //Error: Type not implemented [AverageFlow_m3_day]

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.AverageFlow_m3_day = -1.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureAverageFlow_m3_day", "0", "1000000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.AverageFlow_m3_day = 1000001.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureAverageFlow_m3_day", "0", "1000000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 1000000)]
                    // infrastructure.PeakFlow_m3_day   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [PeakFlow_m3_day]

                    //Error: Type not implemented [PeakFlow_m3_day]

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.PeakFlow_m3_day = -1.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructurePeakFlow_m3_day", "0", "1000000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.PeakFlow_m3_day = 1000001.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructurePeakFlow_m3_day", "0", "1000000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 1000000)]
                    // infrastructure.PopServed   (Int32)
                    // -----------------------------------

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.PopServed = -1;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructurePopServed", "0", "1000000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.PopServed = 1000001;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructurePopServed", "0", "1000000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // infrastructure.CanOverflow   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // infrastructure.PercFlowOfTotal   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [PercFlowOfTotal]

                    //Error: Type not implemented [PercFlowOfTotal]

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.PercFlowOfTotal = -1.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructurePercFlowOfTotal", "0", "100"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.PercFlowOfTotal = 101.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructurePercFlowOfTotal", "0", "100"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-10, 0)]
                    // infrastructure.TimeOffset_hour   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [TimeOffset_hour]

                    //Error: Type not implemented [TimeOffset_hour]

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.TimeOffset_hour = -11.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureTimeOffset_hour", "-10", "0"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.TimeOffset_hour = 1.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureTimeOffset_hour", "-10", "0"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // infrastructure.TempCatchAllRemoveLater   (String)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 1000)]
                    // infrastructure.AverageDepth_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [AverageDepth_m]

                    //Error: Type not implemented [AverageDepth_m]

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.AverageDepth_m = -1.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureAverageDepth_m", "0", "1000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.AverageDepth_m = 1001.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureAverageDepth_m", "0", "1000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(1, 1000)]
                    // infrastructure.NumberOfPorts   (Int32)
                    // -----------------------------------

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.NumberOfPorts = 0;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureNumberOfPorts", "1", "1000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.NumberOfPorts = 1001;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureNumberOfPorts", "1", "1000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10)]
                    // infrastructure.PortDiameter_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [PortDiameter_m]

                    //Error: Type not implemented [PortDiameter_m]

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.PortDiameter_m = -1.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructurePortDiameter_m", "0", "10"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.PortDiameter_m = 11.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructurePortDiameter_m", "0", "10"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10000)]
                    // infrastructure.PortSpacing_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [PortSpacing_m]

                    //Error: Type not implemented [PortSpacing_m]

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.PortSpacing_m = -1.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructurePortSpacing_m", "0", "10000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.PortSpacing_m = 10001.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructurePortSpacing_m", "0", "10000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 1000)]
                    // infrastructure.PortElevation_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [PortElevation_m]

                    //Error: Type not implemented [PortElevation_m]

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.PortElevation_m = -1.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructurePortElevation_m", "0", "1000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.PortElevation_m = 1001.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructurePortElevation_m", "0", "1000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-90, 90)]
                    // infrastructure.VerticalAngle_deg   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [VerticalAngle_deg]

                    //Error: Type not implemented [VerticalAngle_deg]

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.VerticalAngle_deg = -91.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureVerticalAngle_deg", "-90", "90"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.VerticalAngle_deg = 91.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureVerticalAngle_deg", "-90", "90"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-180, 180)]
                    // infrastructure.HorizontalAngle_deg   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [HorizontalAngle_deg]

                    //Error: Type not implemented [HorizontalAngle_deg]

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.HorizontalAngle_deg = -181.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureHorizontalAngle_deg", "-180", "180"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.HorizontalAngle_deg = 181.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureHorizontalAngle_deg", "-180", "180"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // infrastructure.DecayRate_per_day   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [DecayRate_per_day]

                    //Error: Type not implemented [DecayRate_per_day]

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.DecayRate_per_day = -1.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureDecayRate_per_day", "0", "100"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.DecayRate_per_day = 101.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureDecayRate_per_day", "0", "100"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10)]
                    // infrastructure.NearFieldVelocity_m_s   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [NearFieldVelocity_m_s]

                    //Error: Type not implemented [NearFieldVelocity_m_s]

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.NearFieldVelocity_m_s = -1.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureNearFieldVelocity_m_s", "0", "10"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.NearFieldVelocity_m_s = 11.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureNearFieldVelocity_m_s", "0", "10"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10)]
                    // infrastructure.FarFieldVelocity_m_s   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [FarFieldVelocity_m_s]

                    //Error: Type not implemented [FarFieldVelocity_m_s]

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.FarFieldVelocity_m_s = -1.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureFarFieldVelocity_m_s", "0", "10"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.FarFieldVelocity_m_s = 11.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureFarFieldVelocity_m_s", "0", "10"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 40)]
                    // infrastructure.ReceivingWaterSalinity_PSU   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [ReceivingWaterSalinity_PSU]

                    //Error: Type not implemented [ReceivingWaterSalinity_PSU]

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.ReceivingWaterSalinity_PSU = -1.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureReceivingWaterSalinity_PSU", "0", "40"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.ReceivingWaterSalinity_PSU = 41.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureReceivingWaterSalinity_PSU", "0", "40"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-10, 40)]
                    // infrastructure.ReceivingWaterTemperature_C   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [ReceivingWaterTemperature_C]

                    //Error: Type not implemented [ReceivingWaterTemperature_C]

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.ReceivingWaterTemperature_C = -11.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureReceivingWaterTemperature_C", "-10", "40"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.ReceivingWaterTemperature_C = 41.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureReceivingWaterTemperature_C", "-10", "40"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10000000)]
                    // infrastructure.ReceivingWater_MPN_per_100ml   (Int32)
                    // -----------------------------------

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.ReceivingWater_MPN_per_100ml = -1;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureReceivingWater_MPN_per_100ml", "0", "10000000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.ReceivingWater_MPN_per_100ml = 10000001;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureReceivingWater_MPN_per_100ml", "0", "10000000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 1000)]
                    // infrastructure.DistanceFromShore_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [DistanceFromShore_m]

                    //Error: Type not implemented [DistanceFromShore_m]

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.DistanceFromShore_m = -1.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureDistanceFromShore_m", "0", "1000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.DistanceFromShore_m = 1001.0D;
                    Assert.AreEqual(false, infrastructureService.Add(infrastructure));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "InfrastructureDistanceFromShore_m", "0", "1000"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, infrastructureService.GetInfrastructureList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Infrastructure)]
                    // infrastructure.SeeOtherTVItemID   (Int32)
                    // -----------------------------------

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.SeeOtherTVItemID = 0;
                    infrastructureService.Add(infrastructure);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "InfrastructureSeeOtherTVItemID", infrastructure.SeeOtherTVItemID.ToString()), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.SeeOtherTVItemID = 1;
                    infrastructureService.Add(infrastructure);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "InfrastructureSeeOtherTVItemID", "Infrastructure"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Address)]
                    // infrastructure.CivicAddressTVItemID   (Int32)
                    // -----------------------------------

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.CivicAddressTVItemID = 0;
                    infrastructureService.Add(infrastructure);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "InfrastructureCivicAddressTVItemID", infrastructure.CivicAddressTVItemID.ToString()), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.CivicAddressTVItemID = 1;
                    infrastructureService.Add(infrastructure);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "InfrastructureCivicAddressTVItemID", "Address"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // infrastructure.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.LastUpdateDate_UTC = new DateTime();
                    infrastructureService.Add(infrastructure);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "InfrastructureLastUpdateDate_UTC"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);
                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    infrastructureService.Add(infrastructure);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "InfrastructureLastUpdateDate_UTC", "1980"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // infrastructure.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.LastUpdateContactTVItemID = 0;
                    infrastructureService.Add(infrastructure);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "InfrastructureLastUpdateContactTVItemID", infrastructure.LastUpdateContactTVItemID.ToString()), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);

                    infrastructure = null;
                    infrastructure = GetFilledRandomInfrastructure("");
                    infrastructure.LastUpdateContactTVItemID = 1;
                    infrastructureService.Add(infrastructure);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "InfrastructureLastUpdateContactTVItemID", "Contact"), infrastructure.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // infrastructure.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // infrastructure.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetInfrastructureWithInfrastructureID(infrastructure.InfrastructureID)
        [TestMethod]
        public void GetInfrastructureWithInfrastructureID__infrastructure_InfrastructureID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    InfrastructureService infrastructureService = new InfrastructureService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    Infrastructure infrastructure = (from c in dbTestDB.Infrastructures select c).FirstOrDefault();
                    Assert.IsNotNull(infrastructure);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        infrastructureService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            Infrastructure infrastructureRet = infrastructureService.GetInfrastructureWithInfrastructureID(infrastructure.InfrastructureID);
                            CheckInfrastructureFields(new List<Infrastructure>() { infrastructureRet });
                            Assert.AreEqual(infrastructure.InfrastructureID, infrastructureRet.InfrastructureID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            InfrastructureWeb infrastructureWebRet = infrastructureService.GetInfrastructureWebWithInfrastructureID(infrastructure.InfrastructureID);
                            CheckInfrastructureWebFields(new List<InfrastructureWeb>() { infrastructureWebRet });
                            Assert.AreEqual(infrastructure.InfrastructureID, infrastructureWebRet.InfrastructureID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            InfrastructureReport infrastructureReportRet = infrastructureService.GetInfrastructureReportWithInfrastructureID(infrastructure.InfrastructureID);
                            CheckInfrastructureReportFields(new List<InfrastructureReport>() { infrastructureReportRet });
                            Assert.AreEqual(infrastructure.InfrastructureID, infrastructureReportRet.InfrastructureID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetInfrastructureWithInfrastructureID(infrastructure.InfrastructureID)

        #region Tests Generated for GetInfrastructureList()
        [TestMethod]
        public void GetInfrastructureList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    InfrastructureService infrastructureService = new InfrastructureService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    Infrastructure infrastructure = (from c in dbTestDB.Infrastructures select c).FirstOrDefault();
                    Assert.IsNotNull(infrastructure);

                    List<Infrastructure> infrastructureDirectQueryList = new List<Infrastructure>();
                    infrastructureDirectQueryList = (from c in dbTestDB.Infrastructures select c).Take(200).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        infrastructureService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<Infrastructure> infrastructureList = new List<Infrastructure>();
                            infrastructureList = infrastructureService.GetInfrastructureList().ToList();
                            CheckInfrastructureFields(infrastructureList);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructureList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<InfrastructureWeb> infrastructureWebList = new List<InfrastructureWeb>();
                            infrastructureWebList = infrastructureService.GetInfrastructureWebList().ToList();
                            CheckInfrastructureWebFields(infrastructureWebList);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructureWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<InfrastructureReport> infrastructureReportList = new List<InfrastructureReport>();
                            infrastructureReportList = infrastructureService.GetInfrastructureReportList().ToList();
                            CheckInfrastructureReportFields(infrastructureReportList);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructureReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetInfrastructureList()

        #region Tests Generated for GetInfrastructureList() Skip Take
        [TestMethod]
        public void GetInfrastructureList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        InfrastructureService infrastructureService = new InfrastructureService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureService.Query = infrastructureService.FillQuery(typeof(Infrastructure), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<Infrastructure> infrastructureDirectQueryList = new List<Infrastructure>();
                        infrastructureDirectQueryList = (from c in dbTestDB.Infrastructures select c).Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<Infrastructure> infrastructureList = new List<Infrastructure>();
                            infrastructureList = infrastructureService.GetInfrastructureList().ToList();
                            CheckInfrastructureFields(infrastructureList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructureList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructureList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<InfrastructureWeb> infrastructureWebList = new List<InfrastructureWeb>();
                            infrastructureWebList = infrastructureService.GetInfrastructureWebList().ToList();
                            CheckInfrastructureWebFields(infrastructureWebList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructureWebList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructureWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<InfrastructureReport> infrastructureReportList = new List<InfrastructureReport>();
                            infrastructureReportList = infrastructureService.GetInfrastructureReportList().ToList();
                            CheckInfrastructureReportFields(infrastructureReportList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructureReportList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructureReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetInfrastructureList() Skip Take

        #region Tests Generated for GetInfrastructureList() Skip Take Order
        [TestMethod]
        public void GetInfrastructureList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        InfrastructureService infrastructureService = new InfrastructureService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureService.Query = infrastructureService.FillQuery(typeof(Infrastructure), culture.TwoLetterISOLanguageName, 1, 1,  "InfrastructureID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<Infrastructure> infrastructureDirectQueryList = new List<Infrastructure>();
                        infrastructureDirectQueryList = (from c in dbTestDB.Infrastructures select c).Skip(1).Take(1).OrderBy(c => c.InfrastructureID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<Infrastructure> infrastructureList = new List<Infrastructure>();
                            infrastructureList = infrastructureService.GetInfrastructureList().ToList();
                            CheckInfrastructureFields(infrastructureList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructureList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructureList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<InfrastructureWeb> infrastructureWebList = new List<InfrastructureWeb>();
                            infrastructureWebList = infrastructureService.GetInfrastructureWebList().ToList();
                            CheckInfrastructureWebFields(infrastructureWebList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructureWebList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructureWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<InfrastructureReport> infrastructureReportList = new List<InfrastructureReport>();
                            infrastructureReportList = infrastructureService.GetInfrastructureReportList().ToList();
                            CheckInfrastructureReportFields(infrastructureReportList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructureReportList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructureReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetInfrastructureList() Skip Take Order

        #region Tests Generated for GetInfrastructureList() Skip Take 2Order
        [TestMethod]
        public void GetInfrastructureList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        InfrastructureService infrastructureService = new InfrastructureService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureService.Query = infrastructureService.FillQuery(typeof(Infrastructure), culture.TwoLetterISOLanguageName, 1, 1, "InfrastructureID,InfrastructureTVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<Infrastructure> infrastructureDirectQueryList = new List<Infrastructure>();
                        infrastructureDirectQueryList = (from c in dbTestDB.Infrastructures select c).Skip(1).Take(1).OrderBy(c => c.InfrastructureID).ThenBy(c => c.InfrastructureTVItemID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<Infrastructure> infrastructureList = new List<Infrastructure>();
                            infrastructureList = infrastructureService.GetInfrastructureList().ToList();
                            CheckInfrastructureFields(infrastructureList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructureList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructureList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<InfrastructureWeb> infrastructureWebList = new List<InfrastructureWeb>();
                            infrastructureWebList = infrastructureService.GetInfrastructureWebList().ToList();
                            CheckInfrastructureWebFields(infrastructureWebList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructureWebList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructureWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<InfrastructureReport> infrastructureReportList = new List<InfrastructureReport>();
                            infrastructureReportList = infrastructureService.GetInfrastructureReportList().ToList();
                            CheckInfrastructureReportFields(infrastructureReportList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructureReportList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructureReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetInfrastructureList() Skip Take 2Order

        #region Tests Generated for GetInfrastructureList() Skip Take Order Where
        [TestMethod]
        public void GetInfrastructureList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        InfrastructureService infrastructureService = new InfrastructureService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureService.Query = infrastructureService.FillQuery(typeof(Infrastructure), culture.TwoLetterISOLanguageName, 0, 1, "InfrastructureID", "InfrastructureID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<Infrastructure> infrastructureDirectQueryList = new List<Infrastructure>();
                        infrastructureDirectQueryList = (from c in dbTestDB.Infrastructures select c).Where(c => c.InfrastructureID == 4).Skip(0).Take(1).OrderBy(c => c.InfrastructureID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<Infrastructure> infrastructureList = new List<Infrastructure>();
                            infrastructureList = infrastructureService.GetInfrastructureList().ToList();
                            CheckInfrastructureFields(infrastructureList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructureList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructureList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<InfrastructureWeb> infrastructureWebList = new List<InfrastructureWeb>();
                            infrastructureWebList = infrastructureService.GetInfrastructureWebList().ToList();
                            CheckInfrastructureWebFields(infrastructureWebList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructureWebList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructureWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<InfrastructureReport> infrastructureReportList = new List<InfrastructureReport>();
                            infrastructureReportList = infrastructureService.GetInfrastructureReportList().ToList();
                            CheckInfrastructureReportFields(infrastructureReportList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructureReportList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructureReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetInfrastructureList() Skip Take Order Where

        #region Tests Generated for GetInfrastructureList() Skip Take Order 2Where
        [TestMethod]
        public void GetInfrastructureList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        InfrastructureService infrastructureService = new InfrastructureService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureService.Query = infrastructureService.FillQuery(typeof(Infrastructure), culture.TwoLetterISOLanguageName, 0, 1, "InfrastructureID", "InfrastructureID,GT,2|InfrastructureID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<Infrastructure> infrastructureDirectQueryList = new List<Infrastructure>();
                        infrastructureDirectQueryList = (from c in dbTestDB.Infrastructures select c).Where(c => c.InfrastructureID > 2 && c.InfrastructureID < 5).Skip(0).Take(1).OrderBy(c => c.InfrastructureID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<Infrastructure> infrastructureList = new List<Infrastructure>();
                            infrastructureList = infrastructureService.GetInfrastructureList().ToList();
                            CheckInfrastructureFields(infrastructureList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructureList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructureList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<InfrastructureWeb> infrastructureWebList = new List<InfrastructureWeb>();
                            infrastructureWebList = infrastructureService.GetInfrastructureWebList().ToList();
                            CheckInfrastructureWebFields(infrastructureWebList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructureWebList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructureWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<InfrastructureReport> infrastructureReportList = new List<InfrastructureReport>();
                            infrastructureReportList = infrastructureService.GetInfrastructureReportList().ToList();
                            CheckInfrastructureReportFields(infrastructureReportList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructureReportList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructureReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetInfrastructureList() Skip Take Order 2Where

        #region Tests Generated for GetInfrastructureList() 2Where
        [TestMethod]
        public void GetInfrastructureList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        InfrastructureService infrastructureService = new InfrastructureService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureService.Query = infrastructureService.FillQuery(typeof(Infrastructure), culture.TwoLetterISOLanguageName, 0, 10000, "", "InfrastructureID,GT,2|InfrastructureID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<Infrastructure> infrastructureDirectQueryList = new List<Infrastructure>();
                        infrastructureDirectQueryList = (from c in dbTestDB.Infrastructures select c).Where(c => c.InfrastructureID > 2 && c.InfrastructureID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<Infrastructure> infrastructureList = new List<Infrastructure>();
                            infrastructureList = infrastructureService.GetInfrastructureList().ToList();
                            CheckInfrastructureFields(infrastructureList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructureList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructureList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<InfrastructureWeb> infrastructureWebList = new List<InfrastructureWeb>();
                            infrastructureWebList = infrastructureService.GetInfrastructureWebList().ToList();
                            CheckInfrastructureWebFields(infrastructureWebList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructureWebList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructureWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<InfrastructureReport> infrastructureReportList = new List<InfrastructureReport>();
                            infrastructureReportList = infrastructureService.GetInfrastructureReportList().ToList();
                            CheckInfrastructureReportFields(infrastructureReportList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructureReportList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructureReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetInfrastructureList() 2Where

        #region Functions private
        private void CheckInfrastructureFields(List<Infrastructure> infrastructureList)
        {
            Assert.IsNotNull(infrastructureList[0].InfrastructureID);
            Assert.IsNotNull(infrastructureList[0].InfrastructureTVItemID);
            if (infrastructureList[0].PrismID != null)
            {
                Assert.IsNotNull(infrastructureList[0].PrismID);
            }
            if (infrastructureList[0].TPID != null)
            {
                Assert.IsNotNull(infrastructureList[0].TPID);
            }
            if (infrastructureList[0].LSID != null)
            {
                Assert.IsNotNull(infrastructureList[0].LSID);
            }
            if (infrastructureList[0].SiteID != null)
            {
                Assert.IsNotNull(infrastructureList[0].SiteID);
            }
            if (infrastructureList[0].Site != null)
            {
                Assert.IsNotNull(infrastructureList[0].Site);
            }
            if (!string.IsNullOrWhiteSpace(infrastructureList[0].InfrastructureCategory))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureList[0].InfrastructureCategory));
            }
            if (infrastructureList[0].InfrastructureType != null)
            {
                Assert.IsNotNull(infrastructureList[0].InfrastructureType);
            }
            if (infrastructureList[0].FacilityType != null)
            {
                Assert.IsNotNull(infrastructureList[0].FacilityType);
            }
            if (infrastructureList[0].IsMechanicallyAerated != null)
            {
                Assert.IsNotNull(infrastructureList[0].IsMechanicallyAerated);
            }
            if (infrastructureList[0].NumberOfCells != null)
            {
                Assert.IsNotNull(infrastructureList[0].NumberOfCells);
            }
            if (infrastructureList[0].NumberOfAeratedCells != null)
            {
                Assert.IsNotNull(infrastructureList[0].NumberOfAeratedCells);
            }
            if (infrastructureList[0].AerationType != null)
            {
                Assert.IsNotNull(infrastructureList[0].AerationType);
            }
            if (infrastructureList[0].PreliminaryTreatmentType != null)
            {
                Assert.IsNotNull(infrastructureList[0].PreliminaryTreatmentType);
            }
            if (infrastructureList[0].PrimaryTreatmentType != null)
            {
                Assert.IsNotNull(infrastructureList[0].PrimaryTreatmentType);
            }
            if (infrastructureList[0].SecondaryTreatmentType != null)
            {
                Assert.IsNotNull(infrastructureList[0].SecondaryTreatmentType);
            }
            if (infrastructureList[0].TertiaryTreatmentType != null)
            {
                Assert.IsNotNull(infrastructureList[0].TertiaryTreatmentType);
            }
            if (infrastructureList[0].TreatmentType != null)
            {
                Assert.IsNotNull(infrastructureList[0].TreatmentType);
            }
            if (infrastructureList[0].DisinfectionType != null)
            {
                Assert.IsNotNull(infrastructureList[0].DisinfectionType);
            }
            if (infrastructureList[0].CollectionSystemType != null)
            {
                Assert.IsNotNull(infrastructureList[0].CollectionSystemType);
            }
            if (infrastructureList[0].AlarmSystemType != null)
            {
                Assert.IsNotNull(infrastructureList[0].AlarmSystemType);
            }
            if (infrastructureList[0].DesignFlow_m3_day != null)
            {
                Assert.IsNotNull(infrastructureList[0].DesignFlow_m3_day);
            }
            if (infrastructureList[0].AverageFlow_m3_day != null)
            {
                Assert.IsNotNull(infrastructureList[0].AverageFlow_m3_day);
            }
            if (infrastructureList[0].PeakFlow_m3_day != null)
            {
                Assert.IsNotNull(infrastructureList[0].PeakFlow_m3_day);
            }
            if (infrastructureList[0].PopServed != null)
            {
                Assert.IsNotNull(infrastructureList[0].PopServed);
            }
            if (infrastructureList[0].CanOverflow != null)
            {
                Assert.IsNotNull(infrastructureList[0].CanOverflow);
            }
            if (infrastructureList[0].PercFlowOfTotal != null)
            {
                Assert.IsNotNull(infrastructureList[0].PercFlowOfTotal);
            }
            if (infrastructureList[0].TimeOffset_hour != null)
            {
                Assert.IsNotNull(infrastructureList[0].TimeOffset_hour);
            }
            if (!string.IsNullOrWhiteSpace(infrastructureList[0].TempCatchAllRemoveLater))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureList[0].TempCatchAllRemoveLater));
            }
            if (infrastructureList[0].AverageDepth_m != null)
            {
                Assert.IsNotNull(infrastructureList[0].AverageDepth_m);
            }
            if (infrastructureList[0].NumberOfPorts != null)
            {
                Assert.IsNotNull(infrastructureList[0].NumberOfPorts);
            }
            if (infrastructureList[0].PortDiameter_m != null)
            {
                Assert.IsNotNull(infrastructureList[0].PortDiameter_m);
            }
            if (infrastructureList[0].PortSpacing_m != null)
            {
                Assert.IsNotNull(infrastructureList[0].PortSpacing_m);
            }
            if (infrastructureList[0].PortElevation_m != null)
            {
                Assert.IsNotNull(infrastructureList[0].PortElevation_m);
            }
            if (infrastructureList[0].VerticalAngle_deg != null)
            {
                Assert.IsNotNull(infrastructureList[0].VerticalAngle_deg);
            }
            if (infrastructureList[0].HorizontalAngle_deg != null)
            {
                Assert.IsNotNull(infrastructureList[0].HorizontalAngle_deg);
            }
            if (infrastructureList[0].DecayRate_per_day != null)
            {
                Assert.IsNotNull(infrastructureList[0].DecayRate_per_day);
            }
            if (infrastructureList[0].NearFieldVelocity_m_s != null)
            {
                Assert.IsNotNull(infrastructureList[0].NearFieldVelocity_m_s);
            }
            if (infrastructureList[0].FarFieldVelocity_m_s != null)
            {
                Assert.IsNotNull(infrastructureList[0].FarFieldVelocity_m_s);
            }
            if (infrastructureList[0].ReceivingWaterSalinity_PSU != null)
            {
                Assert.IsNotNull(infrastructureList[0].ReceivingWaterSalinity_PSU);
            }
            if (infrastructureList[0].ReceivingWaterTemperature_C != null)
            {
                Assert.IsNotNull(infrastructureList[0].ReceivingWaterTemperature_C);
            }
            if (infrastructureList[0].ReceivingWater_MPN_per_100ml != null)
            {
                Assert.IsNotNull(infrastructureList[0].ReceivingWater_MPN_per_100ml);
            }
            if (infrastructureList[0].DistanceFromShore_m != null)
            {
                Assert.IsNotNull(infrastructureList[0].DistanceFromShore_m);
            }
            if (infrastructureList[0].SeeOtherTVItemID != null)
            {
                Assert.IsNotNull(infrastructureList[0].SeeOtherTVItemID);
            }
            if (infrastructureList[0].CivicAddressTVItemID != null)
            {
                Assert.IsNotNull(infrastructureList[0].CivicAddressTVItemID);
            }
            Assert.IsNotNull(infrastructureList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(infrastructureList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(infrastructureList[0].HasErrors);
        }
        private void CheckInfrastructureWebFields(List<InfrastructureWeb> infrastructureWebList)
        {
            Assert.IsNotNull(infrastructureWebList[0].InfrastructureTVItemLanguage);
            if (infrastructureWebList[0].SeeOtherTVItemLanguage != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].SeeOtherTVItemLanguage);
            }
            if (infrastructureWebList[0].CivicAddressTVItemLanguage != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].CivicAddressTVItemLanguage);
            }
            Assert.IsNotNull(infrastructureWebList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(infrastructureWebList[0].InfrastructureTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureWebList[0].InfrastructureTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructureWebList[0].FacilityTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureWebList[0].FacilityTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructureWebList[0].AerationTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureWebList[0].AerationTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructureWebList[0].PreliminaryTreatmentTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureWebList[0].PreliminaryTreatmentTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructureWebList[0].PrimaryTreatmentTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureWebList[0].PrimaryTreatmentTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructureWebList[0].SecondaryTreatmentTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureWebList[0].SecondaryTreatmentTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructureWebList[0].TertiaryTreatmentTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureWebList[0].TertiaryTreatmentTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructureWebList[0].TreatmentTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureWebList[0].TreatmentTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructureWebList[0].DisinfectionTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureWebList[0].DisinfectionTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructureWebList[0].CollectionSystemTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureWebList[0].CollectionSystemTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructureWebList[0].AlarmSystemTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureWebList[0].AlarmSystemTypeText));
            }
            Assert.IsNotNull(infrastructureWebList[0].InfrastructureID);
            Assert.IsNotNull(infrastructureWebList[0].InfrastructureTVItemID);
            if (infrastructureWebList[0].PrismID != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].PrismID);
            }
            if (infrastructureWebList[0].TPID != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].TPID);
            }
            if (infrastructureWebList[0].LSID != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].LSID);
            }
            if (infrastructureWebList[0].SiteID != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].SiteID);
            }
            if (infrastructureWebList[0].Site != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].Site);
            }
            if (!string.IsNullOrWhiteSpace(infrastructureWebList[0].InfrastructureCategory))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureWebList[0].InfrastructureCategory));
            }
            if (infrastructureWebList[0].InfrastructureType != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].InfrastructureType);
            }
            if (infrastructureWebList[0].FacilityType != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].FacilityType);
            }
            if (infrastructureWebList[0].IsMechanicallyAerated != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].IsMechanicallyAerated);
            }
            if (infrastructureWebList[0].NumberOfCells != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].NumberOfCells);
            }
            if (infrastructureWebList[0].NumberOfAeratedCells != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].NumberOfAeratedCells);
            }
            if (infrastructureWebList[0].AerationType != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].AerationType);
            }
            if (infrastructureWebList[0].PreliminaryTreatmentType != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].PreliminaryTreatmentType);
            }
            if (infrastructureWebList[0].PrimaryTreatmentType != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].PrimaryTreatmentType);
            }
            if (infrastructureWebList[0].SecondaryTreatmentType != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].SecondaryTreatmentType);
            }
            if (infrastructureWebList[0].TertiaryTreatmentType != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].TertiaryTreatmentType);
            }
            if (infrastructureWebList[0].TreatmentType != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].TreatmentType);
            }
            if (infrastructureWebList[0].DisinfectionType != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].DisinfectionType);
            }
            if (infrastructureWebList[0].CollectionSystemType != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].CollectionSystemType);
            }
            if (infrastructureWebList[0].AlarmSystemType != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].AlarmSystemType);
            }
            if (infrastructureWebList[0].DesignFlow_m3_day != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].DesignFlow_m3_day);
            }
            if (infrastructureWebList[0].AverageFlow_m3_day != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].AverageFlow_m3_day);
            }
            if (infrastructureWebList[0].PeakFlow_m3_day != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].PeakFlow_m3_day);
            }
            if (infrastructureWebList[0].PopServed != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].PopServed);
            }
            if (infrastructureWebList[0].CanOverflow != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].CanOverflow);
            }
            if (infrastructureWebList[0].PercFlowOfTotal != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].PercFlowOfTotal);
            }
            if (infrastructureWebList[0].TimeOffset_hour != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].TimeOffset_hour);
            }
            if (!string.IsNullOrWhiteSpace(infrastructureWebList[0].TempCatchAllRemoveLater))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureWebList[0].TempCatchAllRemoveLater));
            }
            if (infrastructureWebList[0].AverageDepth_m != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].AverageDepth_m);
            }
            if (infrastructureWebList[0].NumberOfPorts != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].NumberOfPorts);
            }
            if (infrastructureWebList[0].PortDiameter_m != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].PortDiameter_m);
            }
            if (infrastructureWebList[0].PortSpacing_m != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].PortSpacing_m);
            }
            if (infrastructureWebList[0].PortElevation_m != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].PortElevation_m);
            }
            if (infrastructureWebList[0].VerticalAngle_deg != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].VerticalAngle_deg);
            }
            if (infrastructureWebList[0].HorizontalAngle_deg != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].HorizontalAngle_deg);
            }
            if (infrastructureWebList[0].DecayRate_per_day != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].DecayRate_per_day);
            }
            if (infrastructureWebList[0].NearFieldVelocity_m_s != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].NearFieldVelocity_m_s);
            }
            if (infrastructureWebList[0].FarFieldVelocity_m_s != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].FarFieldVelocity_m_s);
            }
            if (infrastructureWebList[0].ReceivingWaterSalinity_PSU != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].ReceivingWaterSalinity_PSU);
            }
            if (infrastructureWebList[0].ReceivingWaterTemperature_C != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].ReceivingWaterTemperature_C);
            }
            if (infrastructureWebList[0].ReceivingWater_MPN_per_100ml != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].ReceivingWater_MPN_per_100ml);
            }
            if (infrastructureWebList[0].DistanceFromShore_m != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].DistanceFromShore_m);
            }
            if (infrastructureWebList[0].SeeOtherTVItemID != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].SeeOtherTVItemID);
            }
            if (infrastructureWebList[0].CivicAddressTVItemID != null)
            {
                Assert.IsNotNull(infrastructureWebList[0].CivicAddressTVItemID);
            }
            Assert.IsNotNull(infrastructureWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(infrastructureWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(infrastructureWebList[0].HasErrors);
        }
        private void CheckInfrastructureReportFields(List<InfrastructureReport> infrastructureReportList)
        {
            if (!string.IsNullOrWhiteSpace(infrastructureReportList[0].InfrastructureReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureReportList[0].InfrastructureReportTest));
            }
            Assert.IsNotNull(infrastructureReportList[0].InfrastructureTVItemLanguage);
            if (infrastructureReportList[0].SeeOtherTVItemLanguage != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].SeeOtherTVItemLanguage);
            }
            if (infrastructureReportList[0].CivicAddressTVItemLanguage != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].CivicAddressTVItemLanguage);
            }
            Assert.IsNotNull(infrastructureReportList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(infrastructureReportList[0].InfrastructureTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureReportList[0].InfrastructureTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructureReportList[0].FacilityTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureReportList[0].FacilityTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructureReportList[0].AerationTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureReportList[0].AerationTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructureReportList[0].PreliminaryTreatmentTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureReportList[0].PreliminaryTreatmentTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructureReportList[0].PrimaryTreatmentTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureReportList[0].PrimaryTreatmentTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructureReportList[0].SecondaryTreatmentTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureReportList[0].SecondaryTreatmentTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructureReportList[0].TertiaryTreatmentTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureReportList[0].TertiaryTreatmentTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructureReportList[0].TreatmentTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureReportList[0].TreatmentTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructureReportList[0].DisinfectionTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureReportList[0].DisinfectionTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructureReportList[0].CollectionSystemTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureReportList[0].CollectionSystemTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructureReportList[0].AlarmSystemTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureReportList[0].AlarmSystemTypeText));
            }
            Assert.IsNotNull(infrastructureReportList[0].InfrastructureID);
            Assert.IsNotNull(infrastructureReportList[0].InfrastructureTVItemID);
            if (infrastructureReportList[0].PrismID != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].PrismID);
            }
            if (infrastructureReportList[0].TPID != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].TPID);
            }
            if (infrastructureReportList[0].LSID != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].LSID);
            }
            if (infrastructureReportList[0].SiteID != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].SiteID);
            }
            if (infrastructureReportList[0].Site != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].Site);
            }
            if (!string.IsNullOrWhiteSpace(infrastructureReportList[0].InfrastructureCategory))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureReportList[0].InfrastructureCategory));
            }
            if (infrastructureReportList[0].InfrastructureType != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].InfrastructureType);
            }
            if (infrastructureReportList[0].FacilityType != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].FacilityType);
            }
            if (infrastructureReportList[0].IsMechanicallyAerated != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].IsMechanicallyAerated);
            }
            if (infrastructureReportList[0].NumberOfCells != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].NumberOfCells);
            }
            if (infrastructureReportList[0].NumberOfAeratedCells != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].NumberOfAeratedCells);
            }
            if (infrastructureReportList[0].AerationType != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].AerationType);
            }
            if (infrastructureReportList[0].PreliminaryTreatmentType != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].PreliminaryTreatmentType);
            }
            if (infrastructureReportList[0].PrimaryTreatmentType != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].PrimaryTreatmentType);
            }
            if (infrastructureReportList[0].SecondaryTreatmentType != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].SecondaryTreatmentType);
            }
            if (infrastructureReportList[0].TertiaryTreatmentType != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].TertiaryTreatmentType);
            }
            if (infrastructureReportList[0].TreatmentType != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].TreatmentType);
            }
            if (infrastructureReportList[0].DisinfectionType != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].DisinfectionType);
            }
            if (infrastructureReportList[0].CollectionSystemType != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].CollectionSystemType);
            }
            if (infrastructureReportList[0].AlarmSystemType != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].AlarmSystemType);
            }
            if (infrastructureReportList[0].DesignFlow_m3_day != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].DesignFlow_m3_day);
            }
            if (infrastructureReportList[0].AverageFlow_m3_day != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].AverageFlow_m3_day);
            }
            if (infrastructureReportList[0].PeakFlow_m3_day != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].PeakFlow_m3_day);
            }
            if (infrastructureReportList[0].PopServed != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].PopServed);
            }
            if (infrastructureReportList[0].CanOverflow != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].CanOverflow);
            }
            if (infrastructureReportList[0].PercFlowOfTotal != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].PercFlowOfTotal);
            }
            if (infrastructureReportList[0].TimeOffset_hour != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].TimeOffset_hour);
            }
            if (!string.IsNullOrWhiteSpace(infrastructureReportList[0].TempCatchAllRemoveLater))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureReportList[0].TempCatchAllRemoveLater));
            }
            if (infrastructureReportList[0].AverageDepth_m != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].AverageDepth_m);
            }
            if (infrastructureReportList[0].NumberOfPorts != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].NumberOfPorts);
            }
            if (infrastructureReportList[0].PortDiameter_m != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].PortDiameter_m);
            }
            if (infrastructureReportList[0].PortSpacing_m != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].PortSpacing_m);
            }
            if (infrastructureReportList[0].PortElevation_m != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].PortElevation_m);
            }
            if (infrastructureReportList[0].VerticalAngle_deg != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].VerticalAngle_deg);
            }
            if (infrastructureReportList[0].HorizontalAngle_deg != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].HorizontalAngle_deg);
            }
            if (infrastructureReportList[0].DecayRate_per_day != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].DecayRate_per_day);
            }
            if (infrastructureReportList[0].NearFieldVelocity_m_s != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].NearFieldVelocity_m_s);
            }
            if (infrastructureReportList[0].FarFieldVelocity_m_s != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].FarFieldVelocity_m_s);
            }
            if (infrastructureReportList[0].ReceivingWaterSalinity_PSU != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].ReceivingWaterSalinity_PSU);
            }
            if (infrastructureReportList[0].ReceivingWaterTemperature_C != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].ReceivingWaterTemperature_C);
            }
            if (infrastructureReportList[0].ReceivingWater_MPN_per_100ml != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].ReceivingWater_MPN_per_100ml);
            }
            if (infrastructureReportList[0].DistanceFromShore_m != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].DistanceFromShore_m);
            }
            if (infrastructureReportList[0].SeeOtherTVItemID != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].SeeOtherTVItemID);
            }
            if (infrastructureReportList[0].CivicAddressTVItemID != null)
            {
                Assert.IsNotNull(infrastructureReportList[0].CivicAddressTVItemID);
            }
            Assert.IsNotNull(infrastructureReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(infrastructureReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(infrastructureReportList[0].HasErrors);
        }
        private Infrastructure GetFilledRandomInfrastructure(string OmitPropName)
        {
            Infrastructure infrastructure = new Infrastructure();

            if (OmitPropName != "InfrastructureTVItemID") infrastructure.InfrastructureTVItemID = 37;
            if (OmitPropName != "PrismID") infrastructure.PrismID = GetRandomInt(0, 100000);
            if (OmitPropName != "TPID") infrastructure.TPID = GetRandomInt(0, 100000);
            if (OmitPropName != "LSID") infrastructure.LSID = GetRandomInt(0, 100000);
            if (OmitPropName != "SiteID") infrastructure.SiteID = GetRandomInt(0, 100000);
            if (OmitPropName != "Site") infrastructure.Site = GetRandomInt(0, 100000);
            if (OmitPropName != "InfrastructureCategory") infrastructure.InfrastructureCategory = GetRandomString("", 1);
            if (OmitPropName != "InfrastructureType") infrastructure.InfrastructureType = (InfrastructureTypeEnum)GetRandomEnumType(typeof(InfrastructureTypeEnum));
            if (OmitPropName != "FacilityType") infrastructure.FacilityType = (FacilityTypeEnum)GetRandomEnumType(typeof(FacilityTypeEnum));
            if (OmitPropName != "IsMechanicallyAerated") infrastructure.IsMechanicallyAerated = true;
            if (OmitPropName != "NumberOfCells") infrastructure.NumberOfCells = GetRandomInt(0, 10);
            if (OmitPropName != "NumberOfAeratedCells") infrastructure.NumberOfAeratedCells = GetRandomInt(0, 10);
            if (OmitPropName != "AerationType") infrastructure.AerationType = (AerationTypeEnum)GetRandomEnumType(typeof(AerationTypeEnum));
            if (OmitPropName != "PreliminaryTreatmentType") infrastructure.PreliminaryTreatmentType = (PreliminaryTreatmentTypeEnum)GetRandomEnumType(typeof(PreliminaryTreatmentTypeEnum));
            if (OmitPropName != "PrimaryTreatmentType") infrastructure.PrimaryTreatmentType = (PrimaryTreatmentTypeEnum)GetRandomEnumType(typeof(PrimaryTreatmentTypeEnum));
            if (OmitPropName != "SecondaryTreatmentType") infrastructure.SecondaryTreatmentType = (SecondaryTreatmentTypeEnum)GetRandomEnumType(typeof(SecondaryTreatmentTypeEnum));
            if (OmitPropName != "TertiaryTreatmentType") infrastructure.TertiaryTreatmentType = (TertiaryTreatmentTypeEnum)GetRandomEnumType(typeof(TertiaryTreatmentTypeEnum));
            if (OmitPropName != "TreatmentType") infrastructure.TreatmentType = (TreatmentTypeEnum)GetRandomEnumType(typeof(TreatmentTypeEnum));
            if (OmitPropName != "DisinfectionType") infrastructure.DisinfectionType = (DisinfectionTypeEnum)GetRandomEnumType(typeof(DisinfectionTypeEnum));
            if (OmitPropName != "CollectionSystemType") infrastructure.CollectionSystemType = (CollectionSystemTypeEnum)GetRandomEnumType(typeof(CollectionSystemTypeEnum));
            if (OmitPropName != "AlarmSystemType") infrastructure.AlarmSystemType = (AlarmSystemTypeEnum)GetRandomEnumType(typeof(AlarmSystemTypeEnum));
            if (OmitPropName != "DesignFlow_m3_day") infrastructure.DesignFlow_m3_day = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "AverageFlow_m3_day") infrastructure.AverageFlow_m3_day = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "PeakFlow_m3_day") infrastructure.PeakFlow_m3_day = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "PopServed") infrastructure.PopServed = GetRandomInt(0, 1000000);
            if (OmitPropName != "CanOverflow") infrastructure.CanOverflow = true;
            if (OmitPropName != "PercFlowOfTotal") infrastructure.PercFlowOfTotal = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "TimeOffset_hour") infrastructure.TimeOffset_hour = GetRandomDouble(-10.0D, 0.0D);
            if (OmitPropName != "TempCatchAllRemoveLater") infrastructure.TempCatchAllRemoveLater = GetRandomString("", 20);
            if (OmitPropName != "AverageDepth_m") infrastructure.AverageDepth_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "NumberOfPorts") infrastructure.NumberOfPorts = GetRandomInt(1, 1000);
            if (OmitPropName != "PortDiameter_m") infrastructure.PortDiameter_m = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "PortSpacing_m") infrastructure.PortSpacing_m = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "PortElevation_m") infrastructure.PortElevation_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "VerticalAngle_deg") infrastructure.VerticalAngle_deg = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "HorizontalAngle_deg") infrastructure.HorizontalAngle_deg = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "DecayRate_per_day") infrastructure.DecayRate_per_day = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "NearFieldVelocity_m_s") infrastructure.NearFieldVelocity_m_s = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "FarFieldVelocity_m_s") infrastructure.FarFieldVelocity_m_s = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "ReceivingWaterSalinity_PSU") infrastructure.ReceivingWaterSalinity_PSU = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "ReceivingWaterTemperature_C") infrastructure.ReceivingWaterTemperature_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "ReceivingWater_MPN_per_100ml") infrastructure.ReceivingWater_MPN_per_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "DistanceFromShore_m") infrastructure.DistanceFromShore_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "SeeOtherTVItemID") infrastructure.SeeOtherTVItemID = 37;
            if (OmitPropName != "CivicAddressTVItemID") infrastructure.CivicAddressTVItemID = 42;
            if (OmitPropName != "LastUpdateDate_UTC") infrastructure.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") infrastructure.LastUpdateContactTVItemID = 2;

            return infrastructure;
        }
        #endregion Functions private
    }
}
