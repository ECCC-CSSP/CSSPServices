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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    InfrastructureService infrastructureService = new InfrastructureService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    Infrastructure infrastructure = (from c in dbTestDB.Infrastructures select c).FirstOrDefault();
                    Assert.IsNotNull(infrastructure);

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        infrastructureService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            Infrastructure infrastructureRet = infrastructureService.GetInfrastructureWithInfrastructureID(infrastructure.InfrastructureID);
                            CheckInfrastructureFields(new List<Infrastructure>() { infrastructureRet });
                            Assert.AreEqual(infrastructure.InfrastructureID, infrastructureRet.InfrastructureID);
                        }
                        else if (detail == "A")
                        {
                            Infrastructure_A infrastructure_ARet = infrastructureService.GetInfrastructure_AWithInfrastructureID(infrastructure.InfrastructureID);
                            CheckInfrastructure_AFields(new List<Infrastructure_A>() { infrastructure_ARet });
                            Assert.AreEqual(infrastructure.InfrastructureID, infrastructure_ARet.InfrastructureID);
                        }
                        else if (detail == "B")
                        {
                            Infrastructure_B infrastructure_BRet = infrastructureService.GetInfrastructure_BWithInfrastructureID(infrastructure.InfrastructureID);
                            CheckInfrastructure_BFields(new List<Infrastructure_B>() { infrastructure_BRet });
                            Assert.AreEqual(infrastructure.InfrastructureID, infrastructure_BRet.InfrastructureID);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    InfrastructureService infrastructureService = new InfrastructureService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    Infrastructure infrastructure = (from c in dbTestDB.Infrastructures select c).FirstOrDefault();
                    Assert.IsNotNull(infrastructure);

                    List<Infrastructure> infrastructureDirectQueryList = new List<Infrastructure>();
                    infrastructureDirectQueryList = (from c in dbTestDB.Infrastructures select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        infrastructureService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Infrastructure> infrastructureList = new List<Infrastructure>();
                            infrastructureList = infrastructureService.GetInfrastructureList().ToList();
                            CheckInfrastructureFields(infrastructureList);
                        }
                        else if (detail == "A")
                        {
                            List<Infrastructure_A> infrastructure_AList = new List<Infrastructure_A>();
                            infrastructure_AList = infrastructureService.GetInfrastructure_AList().ToList();
                            CheckInfrastructure_AFields(infrastructure_AList);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructure_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<Infrastructure_B> infrastructure_BList = new List<Infrastructure_B>();
                            infrastructure_BList = infrastructureService.GetInfrastructure_BList().ToList();
                            CheckInfrastructure_BFields(infrastructure_BList);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructure_BList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        InfrastructureService infrastructureService = new InfrastructureService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureService.Query = infrastructureService.FillQuery(typeof(Infrastructure), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<Infrastructure> infrastructureDirectQueryList = new List<Infrastructure>();
                        infrastructureDirectQueryList = (from c in dbTestDB.Infrastructures select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Infrastructure> infrastructureList = new List<Infrastructure>();
                            infrastructureList = infrastructureService.GetInfrastructureList().ToList();
                            CheckInfrastructureFields(infrastructureList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructureList[0].InfrastructureID);
                        }
                        else if (detail == "A")
                        {
                            List<Infrastructure_A> infrastructure_AList = new List<Infrastructure_A>();
                            infrastructure_AList = infrastructureService.GetInfrastructure_AList().ToList();
                            CheckInfrastructure_AFields(infrastructure_AList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructure_AList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructure_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<Infrastructure_B> infrastructure_BList = new List<Infrastructure_B>();
                            infrastructure_BList = infrastructureService.GetInfrastructure_BList().ToList();
                            CheckInfrastructure_BFields(infrastructure_BList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructure_BList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructure_BList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        InfrastructureService infrastructureService = new InfrastructureService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureService.Query = infrastructureService.FillQuery(typeof(Infrastructure), culture.TwoLetterISOLanguageName, 1, 1,  "InfrastructureID", "");

                        List<Infrastructure> infrastructureDirectQueryList = new List<Infrastructure>();
                        infrastructureDirectQueryList = (from c in dbTestDB.Infrastructures select c).Skip(1).Take(1).OrderBy(c => c.InfrastructureID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Infrastructure> infrastructureList = new List<Infrastructure>();
                            infrastructureList = infrastructureService.GetInfrastructureList().ToList();
                            CheckInfrastructureFields(infrastructureList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructureList[0].InfrastructureID);
                        }
                        else if (detail == "A")
                        {
                            List<Infrastructure_A> infrastructure_AList = new List<Infrastructure_A>();
                            infrastructure_AList = infrastructureService.GetInfrastructure_AList().ToList();
                            CheckInfrastructure_AFields(infrastructure_AList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructure_AList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructure_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<Infrastructure_B> infrastructure_BList = new List<Infrastructure_B>();
                            infrastructure_BList = infrastructureService.GetInfrastructure_BList().ToList();
                            CheckInfrastructure_BFields(infrastructure_BList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructure_BList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructure_BList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        InfrastructureService infrastructureService = new InfrastructureService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureService.Query = infrastructureService.FillQuery(typeof(Infrastructure), culture.TwoLetterISOLanguageName, 1, 1, "InfrastructureID,InfrastructureTVItemID", "");

                        List<Infrastructure> infrastructureDirectQueryList = new List<Infrastructure>();
                        infrastructureDirectQueryList = (from c in dbTestDB.Infrastructures select c).Skip(1).Take(1).OrderBy(c => c.InfrastructureID).ThenBy(c => c.InfrastructureTVItemID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Infrastructure> infrastructureList = new List<Infrastructure>();
                            infrastructureList = infrastructureService.GetInfrastructureList().ToList();
                            CheckInfrastructureFields(infrastructureList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructureList[0].InfrastructureID);
                        }
                        else if (detail == "A")
                        {
                            List<Infrastructure_A> infrastructure_AList = new List<Infrastructure_A>();
                            infrastructure_AList = infrastructureService.GetInfrastructure_AList().ToList();
                            CheckInfrastructure_AFields(infrastructure_AList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructure_AList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructure_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<Infrastructure_B> infrastructure_BList = new List<Infrastructure_B>();
                            infrastructure_BList = infrastructureService.GetInfrastructure_BList().ToList();
                            CheckInfrastructure_BFields(infrastructure_BList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructure_BList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructure_BList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        InfrastructureService infrastructureService = new InfrastructureService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureService.Query = infrastructureService.FillQuery(typeof(Infrastructure), culture.TwoLetterISOLanguageName, 0, 1, "InfrastructureID", "InfrastructureID,EQ,4", "");

                        List<Infrastructure> infrastructureDirectQueryList = new List<Infrastructure>();
                        infrastructureDirectQueryList = (from c in dbTestDB.Infrastructures select c).Where(c => c.InfrastructureID == 4).Skip(0).Take(1).OrderBy(c => c.InfrastructureID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Infrastructure> infrastructureList = new List<Infrastructure>();
                            infrastructureList = infrastructureService.GetInfrastructureList().ToList();
                            CheckInfrastructureFields(infrastructureList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructureList[0].InfrastructureID);
                        }
                        else if (detail == "A")
                        {
                            List<Infrastructure_A> infrastructure_AList = new List<Infrastructure_A>();
                            infrastructure_AList = infrastructureService.GetInfrastructure_AList().ToList();
                            CheckInfrastructure_AFields(infrastructure_AList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructure_AList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructure_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<Infrastructure_B> infrastructure_BList = new List<Infrastructure_B>();
                            infrastructure_BList = infrastructureService.GetInfrastructure_BList().ToList();
                            CheckInfrastructure_BFields(infrastructure_BList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructure_BList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructure_BList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        InfrastructureService infrastructureService = new InfrastructureService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureService.Query = infrastructureService.FillQuery(typeof(Infrastructure), culture.TwoLetterISOLanguageName, 0, 1, "InfrastructureID", "InfrastructureID,GT,2|InfrastructureID,LT,5", "");

                        List<Infrastructure> infrastructureDirectQueryList = new List<Infrastructure>();
                        infrastructureDirectQueryList = (from c in dbTestDB.Infrastructures select c).Where(c => c.InfrastructureID > 2 && c.InfrastructureID < 5).Skip(0).Take(1).OrderBy(c => c.InfrastructureID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Infrastructure> infrastructureList = new List<Infrastructure>();
                            infrastructureList = infrastructureService.GetInfrastructureList().ToList();
                            CheckInfrastructureFields(infrastructureList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructureList[0].InfrastructureID);
                        }
                        else if (detail == "A")
                        {
                            List<Infrastructure_A> infrastructure_AList = new List<Infrastructure_A>();
                            infrastructure_AList = infrastructureService.GetInfrastructure_AList().ToList();
                            CheckInfrastructure_AFields(infrastructure_AList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructure_AList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructure_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<Infrastructure_B> infrastructure_BList = new List<Infrastructure_B>();
                            infrastructure_BList = infrastructureService.GetInfrastructure_BList().ToList();
                            CheckInfrastructure_BFields(infrastructure_BList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructure_BList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructure_BList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        InfrastructureService infrastructureService = new InfrastructureService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureService.Query = infrastructureService.FillQuery(typeof(Infrastructure), culture.TwoLetterISOLanguageName, 0, 10000, "", "InfrastructureID,GT,2|InfrastructureID,LT,5", "");

                        List<Infrastructure> infrastructureDirectQueryList = new List<Infrastructure>();
                        infrastructureDirectQueryList = (from c in dbTestDB.Infrastructures select c).Where(c => c.InfrastructureID > 2 && c.InfrastructureID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Infrastructure> infrastructureList = new List<Infrastructure>();
                            infrastructureList = infrastructureService.GetInfrastructureList().ToList();
                            CheckInfrastructureFields(infrastructureList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructureList[0].InfrastructureID);
                        }
                        else if (detail == "A")
                        {
                            List<Infrastructure_A> infrastructure_AList = new List<Infrastructure_A>();
                            infrastructure_AList = infrastructureService.GetInfrastructure_AList().ToList();
                            CheckInfrastructure_AFields(infrastructure_AList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructure_AList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructure_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<Infrastructure_B> infrastructure_BList = new List<Infrastructure_B>();
                            infrastructure_BList = infrastructureService.GetInfrastructure_BList().ToList();
                            CheckInfrastructure_BFields(infrastructure_BList);
                            Assert.AreEqual(infrastructureDirectQueryList[0].InfrastructureID, infrastructure_BList[0].InfrastructureID);
                            Assert.AreEqual(infrastructureDirectQueryList.Count, infrastructure_BList.Count);
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
        private void CheckInfrastructure_AFields(List<Infrastructure_A> infrastructure_AList)
        {
            Assert.IsNotNull(infrastructure_AList[0].InfrastructureTVItemLanguage);
            if (infrastructure_AList[0].SeeOtherTVItemLanguage != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].SeeOtherTVItemLanguage);
            }
            if (infrastructure_AList[0].CivicAddressTVItemLanguage != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].CivicAddressTVItemLanguage);
            }
            Assert.IsNotNull(infrastructure_AList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(infrastructure_AList[0].InfrastructureTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructure_AList[0].InfrastructureTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructure_AList[0].FacilityTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructure_AList[0].FacilityTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructure_AList[0].AerationTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructure_AList[0].AerationTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructure_AList[0].PreliminaryTreatmentTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructure_AList[0].PreliminaryTreatmentTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructure_AList[0].PrimaryTreatmentTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructure_AList[0].PrimaryTreatmentTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructure_AList[0].SecondaryTreatmentTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructure_AList[0].SecondaryTreatmentTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructure_AList[0].TertiaryTreatmentTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructure_AList[0].TertiaryTreatmentTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructure_AList[0].TreatmentTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructure_AList[0].TreatmentTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructure_AList[0].DisinfectionTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructure_AList[0].DisinfectionTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructure_AList[0].CollectionSystemTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructure_AList[0].CollectionSystemTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructure_AList[0].AlarmSystemTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructure_AList[0].AlarmSystemTypeText));
            }
            Assert.IsNotNull(infrastructure_AList[0].InfrastructureID);
            Assert.IsNotNull(infrastructure_AList[0].InfrastructureTVItemID);
            if (infrastructure_AList[0].PrismID != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].PrismID);
            }
            if (infrastructure_AList[0].TPID != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].TPID);
            }
            if (infrastructure_AList[0].LSID != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].LSID);
            }
            if (infrastructure_AList[0].SiteID != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].SiteID);
            }
            if (infrastructure_AList[0].Site != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].Site);
            }
            if (!string.IsNullOrWhiteSpace(infrastructure_AList[0].InfrastructureCategory))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructure_AList[0].InfrastructureCategory));
            }
            if (infrastructure_AList[0].InfrastructureType != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].InfrastructureType);
            }
            if (infrastructure_AList[0].FacilityType != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].FacilityType);
            }
            if (infrastructure_AList[0].IsMechanicallyAerated != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].IsMechanicallyAerated);
            }
            if (infrastructure_AList[0].NumberOfCells != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].NumberOfCells);
            }
            if (infrastructure_AList[0].NumberOfAeratedCells != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].NumberOfAeratedCells);
            }
            if (infrastructure_AList[0].AerationType != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].AerationType);
            }
            if (infrastructure_AList[0].PreliminaryTreatmentType != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].PreliminaryTreatmentType);
            }
            if (infrastructure_AList[0].PrimaryTreatmentType != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].PrimaryTreatmentType);
            }
            if (infrastructure_AList[0].SecondaryTreatmentType != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].SecondaryTreatmentType);
            }
            if (infrastructure_AList[0].TertiaryTreatmentType != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].TertiaryTreatmentType);
            }
            if (infrastructure_AList[0].TreatmentType != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].TreatmentType);
            }
            if (infrastructure_AList[0].DisinfectionType != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].DisinfectionType);
            }
            if (infrastructure_AList[0].CollectionSystemType != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].CollectionSystemType);
            }
            if (infrastructure_AList[0].AlarmSystemType != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].AlarmSystemType);
            }
            if (infrastructure_AList[0].DesignFlow_m3_day != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].DesignFlow_m3_day);
            }
            if (infrastructure_AList[0].AverageFlow_m3_day != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].AverageFlow_m3_day);
            }
            if (infrastructure_AList[0].PeakFlow_m3_day != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].PeakFlow_m3_day);
            }
            if (infrastructure_AList[0].PopServed != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].PopServed);
            }
            if (infrastructure_AList[0].CanOverflow != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].CanOverflow);
            }
            if (infrastructure_AList[0].PercFlowOfTotal != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].PercFlowOfTotal);
            }
            if (infrastructure_AList[0].TimeOffset_hour != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].TimeOffset_hour);
            }
            if (!string.IsNullOrWhiteSpace(infrastructure_AList[0].TempCatchAllRemoveLater))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructure_AList[0].TempCatchAllRemoveLater));
            }
            if (infrastructure_AList[0].AverageDepth_m != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].AverageDepth_m);
            }
            if (infrastructure_AList[0].NumberOfPorts != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].NumberOfPorts);
            }
            if (infrastructure_AList[0].PortDiameter_m != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].PortDiameter_m);
            }
            if (infrastructure_AList[0].PortSpacing_m != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].PortSpacing_m);
            }
            if (infrastructure_AList[0].PortElevation_m != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].PortElevation_m);
            }
            if (infrastructure_AList[0].VerticalAngle_deg != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].VerticalAngle_deg);
            }
            if (infrastructure_AList[0].HorizontalAngle_deg != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].HorizontalAngle_deg);
            }
            if (infrastructure_AList[0].DecayRate_per_day != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].DecayRate_per_day);
            }
            if (infrastructure_AList[0].NearFieldVelocity_m_s != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].NearFieldVelocity_m_s);
            }
            if (infrastructure_AList[0].FarFieldVelocity_m_s != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].FarFieldVelocity_m_s);
            }
            if (infrastructure_AList[0].ReceivingWaterSalinity_PSU != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].ReceivingWaterSalinity_PSU);
            }
            if (infrastructure_AList[0].ReceivingWaterTemperature_C != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].ReceivingWaterTemperature_C);
            }
            if (infrastructure_AList[0].ReceivingWater_MPN_per_100ml != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].ReceivingWater_MPN_per_100ml);
            }
            if (infrastructure_AList[0].DistanceFromShore_m != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].DistanceFromShore_m);
            }
            if (infrastructure_AList[0].SeeOtherTVItemID != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].SeeOtherTVItemID);
            }
            if (infrastructure_AList[0].CivicAddressTVItemID != null)
            {
                Assert.IsNotNull(infrastructure_AList[0].CivicAddressTVItemID);
            }
            Assert.IsNotNull(infrastructure_AList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(infrastructure_AList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(infrastructure_AList[0].HasErrors);
        }
        private void CheckInfrastructure_BFields(List<Infrastructure_B> infrastructure_BList)
        {
            if (!string.IsNullOrWhiteSpace(infrastructure_BList[0].InfrastructureReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructure_BList[0].InfrastructureReportTest));
            }
            Assert.IsNotNull(infrastructure_BList[0].InfrastructureTVItemLanguage);
            if (infrastructure_BList[0].SeeOtherTVItemLanguage != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].SeeOtherTVItemLanguage);
            }
            if (infrastructure_BList[0].CivicAddressTVItemLanguage != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].CivicAddressTVItemLanguage);
            }
            Assert.IsNotNull(infrastructure_BList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(infrastructure_BList[0].InfrastructureTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructure_BList[0].InfrastructureTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructure_BList[0].FacilityTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructure_BList[0].FacilityTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructure_BList[0].AerationTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructure_BList[0].AerationTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructure_BList[0].PreliminaryTreatmentTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructure_BList[0].PreliminaryTreatmentTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructure_BList[0].PrimaryTreatmentTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructure_BList[0].PrimaryTreatmentTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructure_BList[0].SecondaryTreatmentTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructure_BList[0].SecondaryTreatmentTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructure_BList[0].TertiaryTreatmentTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructure_BList[0].TertiaryTreatmentTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructure_BList[0].TreatmentTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructure_BList[0].TreatmentTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructure_BList[0].DisinfectionTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructure_BList[0].DisinfectionTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructure_BList[0].CollectionSystemTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructure_BList[0].CollectionSystemTypeText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructure_BList[0].AlarmSystemTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructure_BList[0].AlarmSystemTypeText));
            }
            Assert.IsNotNull(infrastructure_BList[0].InfrastructureID);
            Assert.IsNotNull(infrastructure_BList[0].InfrastructureTVItemID);
            if (infrastructure_BList[0].PrismID != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].PrismID);
            }
            if (infrastructure_BList[0].TPID != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].TPID);
            }
            if (infrastructure_BList[0].LSID != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].LSID);
            }
            if (infrastructure_BList[0].SiteID != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].SiteID);
            }
            if (infrastructure_BList[0].Site != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].Site);
            }
            if (!string.IsNullOrWhiteSpace(infrastructure_BList[0].InfrastructureCategory))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructure_BList[0].InfrastructureCategory));
            }
            if (infrastructure_BList[0].InfrastructureType != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].InfrastructureType);
            }
            if (infrastructure_BList[0].FacilityType != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].FacilityType);
            }
            if (infrastructure_BList[0].IsMechanicallyAerated != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].IsMechanicallyAerated);
            }
            if (infrastructure_BList[0].NumberOfCells != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].NumberOfCells);
            }
            if (infrastructure_BList[0].NumberOfAeratedCells != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].NumberOfAeratedCells);
            }
            if (infrastructure_BList[0].AerationType != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].AerationType);
            }
            if (infrastructure_BList[0].PreliminaryTreatmentType != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].PreliminaryTreatmentType);
            }
            if (infrastructure_BList[0].PrimaryTreatmentType != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].PrimaryTreatmentType);
            }
            if (infrastructure_BList[0].SecondaryTreatmentType != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].SecondaryTreatmentType);
            }
            if (infrastructure_BList[0].TertiaryTreatmentType != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].TertiaryTreatmentType);
            }
            if (infrastructure_BList[0].TreatmentType != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].TreatmentType);
            }
            if (infrastructure_BList[0].DisinfectionType != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].DisinfectionType);
            }
            if (infrastructure_BList[0].CollectionSystemType != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].CollectionSystemType);
            }
            if (infrastructure_BList[0].AlarmSystemType != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].AlarmSystemType);
            }
            if (infrastructure_BList[0].DesignFlow_m3_day != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].DesignFlow_m3_day);
            }
            if (infrastructure_BList[0].AverageFlow_m3_day != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].AverageFlow_m3_day);
            }
            if (infrastructure_BList[0].PeakFlow_m3_day != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].PeakFlow_m3_day);
            }
            if (infrastructure_BList[0].PopServed != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].PopServed);
            }
            if (infrastructure_BList[0].CanOverflow != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].CanOverflow);
            }
            if (infrastructure_BList[0].PercFlowOfTotal != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].PercFlowOfTotal);
            }
            if (infrastructure_BList[0].TimeOffset_hour != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].TimeOffset_hour);
            }
            if (!string.IsNullOrWhiteSpace(infrastructure_BList[0].TempCatchAllRemoveLater))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructure_BList[0].TempCatchAllRemoveLater));
            }
            if (infrastructure_BList[0].AverageDepth_m != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].AverageDepth_m);
            }
            if (infrastructure_BList[0].NumberOfPorts != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].NumberOfPorts);
            }
            if (infrastructure_BList[0].PortDiameter_m != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].PortDiameter_m);
            }
            if (infrastructure_BList[0].PortSpacing_m != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].PortSpacing_m);
            }
            if (infrastructure_BList[0].PortElevation_m != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].PortElevation_m);
            }
            if (infrastructure_BList[0].VerticalAngle_deg != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].VerticalAngle_deg);
            }
            if (infrastructure_BList[0].HorizontalAngle_deg != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].HorizontalAngle_deg);
            }
            if (infrastructure_BList[0].DecayRate_per_day != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].DecayRate_per_day);
            }
            if (infrastructure_BList[0].NearFieldVelocity_m_s != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].NearFieldVelocity_m_s);
            }
            if (infrastructure_BList[0].FarFieldVelocity_m_s != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].FarFieldVelocity_m_s);
            }
            if (infrastructure_BList[0].ReceivingWaterSalinity_PSU != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].ReceivingWaterSalinity_PSU);
            }
            if (infrastructure_BList[0].ReceivingWaterTemperature_C != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].ReceivingWaterTemperature_C);
            }
            if (infrastructure_BList[0].ReceivingWater_MPN_per_100ml != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].ReceivingWater_MPN_per_100ml);
            }
            if (infrastructure_BList[0].DistanceFromShore_m != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].DistanceFromShore_m);
            }
            if (infrastructure_BList[0].SeeOtherTVItemID != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].SeeOtherTVItemID);
            }
            if (infrastructure_BList[0].CivicAddressTVItemID != null)
            {
                Assert.IsNotNull(infrastructure_BList[0].CivicAddressTVItemID);
            }
            Assert.IsNotNull(infrastructure_BList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(infrastructure_BList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(infrastructure_BList[0].HasErrors);
        }
        private Infrastructure GetFilledRandomInfrastructure(string OmitPropName)
        {
            Infrastructure infrastructure = new Infrastructure();

            if (OmitPropName != "InfrastructureTVItemID") infrastructure.InfrastructureTVItemID = 40;
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
            if (OmitPropName != "SeeOtherTVItemID") infrastructure.SeeOtherTVItemID = 40;
            if (OmitPropName != "CivicAddressTVItemID") infrastructure.CivicAddressTVItemID = 45;
            if (OmitPropName != "LastUpdateDate_UTC") infrastructure.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") infrastructure.LastUpdateContactTVItemID = 2;

            return infrastructure;
        }
        #endregion Functions private
    }
}
