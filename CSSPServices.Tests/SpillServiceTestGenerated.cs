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
    public partial class SpillServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private SpillService spillService { get; set; }
        #endregion Properties

        #region Constructors
        public SpillServiceTest() : base()
        {
            //spillService = new SpillService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Spill GetFilledRandomSpill(string OmitPropName)
        {
            Spill spill = new Spill();

            if (OmitPropName != "MunicipalityTVItemID") spill.MunicipalityTVItemID = 35;
            if (OmitPropName != "InfrastructureTVItemID") spill.InfrastructureTVItemID = 37;
            if (OmitPropName != "StartDateTime_Local") spill.StartDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDateTime_Local") spill.EndDateTime_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "AverageFlow_m3_day") spill.AverageFlow_m3_day = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "LastUpdateDate_UTC") spill.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") spill.LastUpdateContactTVItemID = 2;

            return spill;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void Spill_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SpillService spillService = new SpillService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    Spill spill = GetFilledRandomSpill("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = spillService.GetRead().Count();

                    Assert.AreEqual(spillService.GetRead().Count(), spillService.GetEdit().Count());

                    spillService.Add(spill);
                    if (spill.HasErrors)
                    {
                        Assert.AreEqual("", spill.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, spillService.GetRead().Where(c => c == spill).Any());
                    spillService.Update(spill);
                    if (spill.HasErrors)
                    {
                        Assert.AreEqual("", spill.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, spillService.GetRead().Count());
                    spillService.Delete(spill);
                    if (spill.HasErrors)
                    {
                        Assert.AreEqual("", spill.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, spillService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // spill.SpillID   (Int32)
                    // -----------------------------------

                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.SpillID = 0;
                    spillService.Update(spill);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SpillSpillID), spill.ValidationResults.FirstOrDefault().ErrorMessage);

                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.SpillID = 10000000;
                    spillService.Update(spill);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Spill, CSSPModelsRes.SpillSpillID, spill.SpillID.ToString()), spill.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Municipality)]
                    // spill.MunicipalityTVItemID   (Int32)
                    // -----------------------------------

                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.MunicipalityTVItemID = 0;
                    spillService.Add(spill);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.SpillMunicipalityTVItemID, spill.MunicipalityTVItemID.ToString()), spill.ValidationResults.FirstOrDefault().ErrorMessage);

                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.MunicipalityTVItemID = 1;
                    spillService.Add(spill);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.SpillMunicipalityTVItemID, "Municipality"), spill.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Infrastructure)]
                    // spill.InfrastructureTVItemID   (Int32)
                    // -----------------------------------

                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.InfrastructureTVItemID = 0;
                    spillService.Add(spill);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.SpillInfrastructureTVItemID, spill.InfrastructureTVItemID.ToString()), spill.ValidationResults.FirstOrDefault().ErrorMessage);

                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.InfrastructureTVItemID = 1;
                    spillService.Add(spill);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.SpillInfrastructureTVItemID, "Infrastructure"), spill.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // spill.StartDateTime_Local   (DateTime)
                    // -----------------------------------

                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.StartDateTime_Local = new DateTime();
                    spillService.Add(spill);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SpillStartDateTime_Local), spill.ValidationResults.FirstOrDefault().ErrorMessage);
                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.StartDateTime_Local = new DateTime(1979, 1, 1);
                    spillService.Add(spill);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.SpillStartDateTime_Local, "1980"), spill.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // [CSSPBigger(OtherField = StartDateTime_Local)]
                    // spill.EndDateTime_Local   (DateTime)
                    // -----------------------------------

                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.EndDateTime_Local = new DateTime(1979, 1, 1);
                    spillService.Add(spill);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.SpillEndDateTime_Local, "1980"), spill.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000000)]
                    // spill.AverageFlow_m3_day   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [AverageFlow_m3_day]

                    //Error: Type not implemented [AverageFlow_m3_day]

                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.AverageFlow_m3_day = -1.0D;
                    Assert.AreEqual(false, spillService.Add(spill));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.SpillAverageFlow_m3_day, "0", "1000000"), spill.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, spillService.GetRead().Count());
                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.AverageFlow_m3_day = 1000001.0D;
                    Assert.AreEqual(false, spillService.Add(spill));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.SpillAverageFlow_m3_day, "0", "1000000"), spill.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, spillService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // spill.SpillWeb   (SpillWeb)
                    // -----------------------------------

                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.SpillWeb = null;
                    Assert.IsNull(spill.SpillWeb);

                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.SpillWeb = new SpillWeb();
                    Assert.IsNotNull(spill.SpillWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // spill.SpillReport   (SpillReport)
                    // -----------------------------------

                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.SpillReport = null;
                    Assert.IsNull(spill.SpillReport);

                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.SpillReport = new SpillReport();
                    Assert.IsNotNull(spill.SpillReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // spill.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.LastUpdateDate_UTC = new DateTime();
                    spillService.Add(spill);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SpillLastUpdateDate_UTC), spill.ValidationResults.FirstOrDefault().ErrorMessage);
                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    spillService.Add(spill);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.SpillLastUpdateDate_UTC, "1980"), spill.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // spill.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.LastUpdateContactTVItemID = 0;
                    spillService.Add(spill);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.SpillLastUpdateContactTVItemID, spill.LastUpdateContactTVItemID.ToString()), spill.ValidationResults.FirstOrDefault().ErrorMessage);

                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.LastUpdateContactTVItemID = 1;
                    spillService.Add(spill);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.SpillLastUpdateContactTVItemID, "Contact"), spill.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // spill.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // spill.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void Spill_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    GetParam getParam = new GetParam();
                    SpillService spillService = new SpillService(new GetParam(), dbTestDB, ContactID);
                    Spill spill = (from c in spillService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(spill);

                    Spill spillRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        getParam.EntityQueryDetailType = entityQueryDetailTypeEnum;

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            spillRet = spillService.GetSpillWithSpillID(spill.SpillID, getParam);
                            Assert.IsNull(spillRet);
                            continue;
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            spillRet = spillService.GetSpillWithSpillID(spill.SpillID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            spillRet = spillService.GetSpillWithSpillID(spill.SpillID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            spillRet = spillService.GetSpillWithSpillID(spill.SpillID, getParam);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Spill fields
                        Assert.IsNotNull(spillRet.SpillID);
                        Assert.IsNotNull(spillRet.MunicipalityTVItemID);
                        if (spillRet.InfrastructureTVItemID != null)
                        {
                            Assert.IsNotNull(spillRet.InfrastructureTVItemID);
                        }
                        Assert.IsNotNull(spillRet.StartDateTime_Local);
                        if (spillRet.EndDateTime_Local != null)
                        {
                            Assert.IsNotNull(spillRet.EndDateTime_Local);
                        }
                        Assert.IsNotNull(spillRet.AverageFlow_m3_day);
                        Assert.IsNotNull(spillRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(spillRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // SpillWeb and SpillReport fields should be null here
                            Assert.IsNull(spillRet.SpillWeb);
                            Assert.IsNull(spillRet.SpillReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // SpillWeb fields should not be null and SpillReport fields should be null here
                            if (spillRet.SpillWeb.MunicipalityTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(spillRet.SpillWeb.MunicipalityTVText));
                            }
                            if (spillRet.SpillWeb.InfrastructureTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(spillRet.SpillWeb.InfrastructureTVText));
                            }
                            if (spillRet.SpillWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(spillRet.SpillWeb.LastUpdateContactTVText));
                            }
                            Assert.IsNull(spillRet.SpillReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // SpillWeb and SpillReport fields should NOT be null here
                            if (spillRet.SpillWeb.MunicipalityTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(spillRet.SpillWeb.MunicipalityTVText));
                            }
                            if (spillRet.SpillWeb.InfrastructureTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(spillRet.SpillWeb.InfrastructureTVText));
                            }
                            if (spillRet.SpillWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(spillRet.SpillWeb.LastUpdateContactTVText));
                            }
                            if (spillRet.SpillReport.SpillReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(spillRet.SpillReport.SpillReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of Spill
        #endregion Tests Get List of Spill

    }
}
