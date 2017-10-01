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
    public partial class SamplingPlanSubsectorServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private SamplingPlanSubsectorService samplingPlanSubsectorService { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorServiceTest() : base()
        {
            //samplingPlanSubsectorService = new SamplingPlanSubsectorService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private SamplingPlanSubsector GetFilledRandomSamplingPlanSubsector(string OmitPropName)
        {
            SamplingPlanSubsector samplingPlanSubsector = new SamplingPlanSubsector();

            // Need to implement (no items found, would need to add at least one in the TestDB) [SamplingPlanSubsector SamplingPlanID SamplingPlan SamplingPlanID]
            // Need to implement (no items found, would need to add at least one in the TestDB) [SamplingPlanSubsector SubsectorTVItemID TVItem TVItemID]
            //Error: property [SamplingPlanSubsectorWeb] and type [SamplingPlanSubsector] is  not implemented
            //Error: property [SamplingPlanSubsectorReport] and type [SamplingPlanSubsector] is  not implemented
            if (OmitPropName != "LastUpdateDate_UTC") samplingPlanSubsector.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") samplingPlanSubsector.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "HasErrors") samplingPlanSubsector.HasErrors = true;

            return samplingPlanSubsector;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void SamplingPlanSubsector_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(LanguageRequest, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    SamplingPlanSubsector samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = samplingPlanSubsectorService.GetRead().Count();

                    Assert.AreEqual(samplingPlanSubsectorService.GetRead().Count(), samplingPlanSubsectorService.GetEdit().Count());

                    samplingPlanSubsectorService.Add(samplingPlanSubsector);
                    if (samplingPlanSubsector.HasErrors)
                    {
                        Assert.AreEqual("", samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, samplingPlanSubsectorService.GetRead().Where(c => c == samplingPlanSubsector).Any());
                    samplingPlanSubsectorService.Update(samplingPlanSubsector);
                    if (samplingPlanSubsector.HasErrors)
                    {
                        Assert.AreEqual("", samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, samplingPlanSubsectorService.GetRead().Count());
                    samplingPlanSubsectorService.Delete(samplingPlanSubsector);
                    if (samplingPlanSubsector.HasErrors)
                    {
                        Assert.AreEqual("", samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, samplingPlanSubsectorService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // samplingPlanSubsector.SamplingPlanSubsectorID   (Int32)
                    // -----------------------------------

                    samplingPlanSubsector = null;
                    samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                    samplingPlanSubsector.SamplingPlanSubsectorID = 0;
                    samplingPlanSubsectorService.Update(samplingPlanSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SamplingPlanSubsectorSamplingPlanSubsectorID), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlanSubsector = null;
                    samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                    samplingPlanSubsector.SamplingPlanSubsectorID = 10000000;
                    samplingPlanSubsectorService.Update(samplingPlanSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.SamplingPlanSubsector, CSSPModelsRes.SamplingPlanSubsectorSamplingPlanSubsectorID, samplingPlanSubsector.SamplingPlanSubsectorID.ToString()), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "SamplingPlan", ExistPlurial = "s", ExistFieldID = "SamplingPlanID", AllowableTVtypeList = Error)]
                    // samplingPlanSubsector.SamplingPlanID   (Int32)
                    // -----------------------------------

                    samplingPlanSubsector = null;
                    samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                    samplingPlanSubsector.SamplingPlanID = 0;
                    samplingPlanSubsectorService.Add(samplingPlanSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.SamplingPlan, CSSPModelsRes.SamplingPlanSubsectorSamplingPlanID, samplingPlanSubsector.SamplingPlanID.ToString()), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Subsector)]
                    // samplingPlanSubsector.SubsectorTVItemID   (Int32)
                    // -----------------------------------

                    samplingPlanSubsector = null;
                    samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                    samplingPlanSubsector.SubsectorTVItemID = 0;
                    samplingPlanSubsectorService.Add(samplingPlanSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.SamplingPlanSubsectorSubsectorTVItemID, samplingPlanSubsector.SubsectorTVItemID.ToString()), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlanSubsector = null;
                    samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                    samplingPlanSubsector.SubsectorTVItemID = 1;
                    samplingPlanSubsectorService.Add(samplingPlanSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.SamplingPlanSubsectorSubsectorTVItemID, "Subsector"), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // samplingPlanSubsector.SamplingPlanSubsectorWeb   (SamplingPlanSubsectorWeb)
                    // -----------------------------------

                    //Error: Type not implemented [SamplingPlanSubsectorWeb]


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // samplingPlanSubsector.SamplingPlanSubsectorReport   (SamplingPlanSubsectorReport)
                    // -----------------------------------

                    //Error: Type not implemented [SamplingPlanSubsectorReport]


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // samplingPlanSubsector.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // samplingPlanSubsector.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    samplingPlanSubsector = null;
                    samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                    samplingPlanSubsector.LastUpdateContactTVItemID = 0;
                    samplingPlanSubsectorService.Add(samplingPlanSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.SamplingPlanSubsectorLastUpdateContactTVItemID, samplingPlanSubsector.LastUpdateContactTVItemID.ToString()), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlanSubsector = null;
                    samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                    samplingPlanSubsector.LastUpdateContactTVItemID = 1;
                    samplingPlanSubsectorService.Add(samplingPlanSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.SamplingPlanSubsectorLastUpdateContactTVItemID, "Contact"), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // samplingPlanSubsector.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // samplingPlanSubsector.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void SamplingPlanSubsector_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(LanguageRequest, dbTestDB, ContactID);
                    SamplingPlanSubsector samplingPlanSubsector = (from c in samplingPlanSubsectorService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(samplingPlanSubsector);

                    SamplingPlanSubsector samplingPlanSubsectorRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb })
                    {
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            samplingPlanSubsectorRet = samplingPlanSubsectorService.GetSamplingPlanSubsectorWithSamplingPlanSubsectorID(samplingPlanSubsector.SamplingPlanSubsectorID);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            samplingPlanSubsectorRet = samplingPlanSubsectorService.GetSamplingPlanSubsectorWithSamplingPlanSubsectorID(samplingPlanSubsector.SamplingPlanSubsectorID, EntityQueryDetailTypeEnum.EntityOnly);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            samplingPlanSubsectorRet = samplingPlanSubsectorService.GetSamplingPlanSubsectorWithSamplingPlanSubsectorID(samplingPlanSubsector.SamplingPlanSubsectorID, EntityQueryDetailTypeEnum.EntityWeb);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Entity fields
                        Assert.IsNotNull(samplingPlanSubsectorRet.SamplingPlanSubsectorID);
                        Assert.IsNotNull(samplingPlanSubsectorRet.SamplingPlanID);
                        Assert.IsNotNull(samplingPlanSubsectorRet.SubsectorTVItemID);
                        Assert.IsNotNull(samplingPlanSubsectorRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(samplingPlanSubsectorRet.LastUpdateContactTVItemID);

                        // Non entity fields
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            if (samplingPlanSubsectorRet.SamplingPlanSubsectorWeb != null)
                            {
                                Assert.IsNull(samplingPlanSubsectorRet.SamplingPlanSubsectorWeb);
                            }
                            if (samplingPlanSubsectorRet.SamplingPlanSubsectorReport != null)
                            {
                                Assert.IsNull(samplingPlanSubsectorRet.SamplingPlanSubsectorReport);
                            }
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            if (samplingPlanSubsectorRet.SamplingPlanSubsectorWeb != null)
                            {
                                Assert.IsNotNull(samplingPlanSubsectorRet.SamplingPlanSubsectorWeb);
                            }
                            if (samplingPlanSubsectorRet.SamplingPlanSubsectorReport != null)
                            {
                                Assert.IsNotNull(samplingPlanSubsectorRet.SamplingPlanSubsectorReport);
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of SamplingPlanSubsector
        #endregion Tests Get List of SamplingPlanSubsector

    }
}
