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
    public partial class PolSourceObservationIssueServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private PolSourceObservationIssueService polSourceObservationIssueService { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationIssueServiceTest() : base()
        {
            //polSourceObservationIssueService = new PolSourceObservationIssueService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private PolSourceObservationIssue GetFilledRandomPolSourceObservationIssue(string OmitPropName)
        {
            PolSourceObservationIssue polSourceObservationIssue = new PolSourceObservationIssue();

            // Need to implement (no items found, would need to add at least one in the TestDB) [PolSourceObservationIssue PolSourceObservationID PolSourceObservation PolSourceObservationID]
            if (OmitPropName != "ObservationInfo") polSourceObservationIssue.ObservationInfo = GetRandomString("", 5);
            if (OmitPropName != "Ordinal") polSourceObservationIssue.Ordinal = GetRandomInt(0, 1000);
            //Error: property [PolSourceObservationIssueWeb] and type [PolSourceObservationIssue] is  not implemented
            //Error: property [PolSourceObservationIssueReport] and type [PolSourceObservationIssue] is  not implemented
            if (OmitPropName != "LastUpdateDate_UTC") polSourceObservationIssue.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") polSourceObservationIssue.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "HasErrors") polSourceObservationIssue.HasErrors = true;

            return polSourceObservationIssue;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void PolSourceObservationIssue_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(LanguageRequest, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    PolSourceObservationIssue polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = polSourceObservationIssueService.GetRead().Count();

                    Assert.AreEqual(polSourceObservationIssueService.GetRead().Count(), polSourceObservationIssueService.GetEdit().Count());

                    polSourceObservationIssueService.Add(polSourceObservationIssue);
                    if (polSourceObservationIssue.HasErrors)
                    {
                        Assert.AreEqual("", polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, polSourceObservationIssueService.GetRead().Where(c => c == polSourceObservationIssue).Any());
                    polSourceObservationIssueService.Update(polSourceObservationIssue);
                    if (polSourceObservationIssue.HasErrors)
                    {
                        Assert.AreEqual("", polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, polSourceObservationIssueService.GetRead().Count());
                    polSourceObservationIssueService.Delete(polSourceObservationIssue);
                    if (polSourceObservationIssue.HasErrors)
                    {
                        Assert.AreEqual("", polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // polSourceObservationIssue.PolSourceObservationIssueID   (Int32)
                    // -----------------------------------

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.PolSourceObservationIssueID = 0;
                    polSourceObservationIssueService.Update(polSourceObservationIssue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.PolSourceObservationIssuePolSourceObservationIssueID), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.PolSourceObservationIssueID = 10000000;
                    polSourceObservationIssueService.Update(polSourceObservationIssue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.PolSourceObservationIssue, CSSPModelsRes.PolSourceObservationIssuePolSourceObservationIssueID, polSourceObservationIssue.PolSourceObservationIssueID.ToString()), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "PolSourceObservation", ExistPlurial = "s", ExistFieldID = "PolSourceObservationID", AllowableTVtypeList = Error)]
                    // polSourceObservationIssue.PolSourceObservationID   (Int32)
                    // -----------------------------------

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.PolSourceObservationID = 0;
                    polSourceObservationIssueService.Add(polSourceObservationIssue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.PolSourceObservation, CSSPModelsRes.PolSourceObservationIssuePolSourceObservationID, polSourceObservationIssue.PolSourceObservationID.ToString()), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(250))]
                    // polSourceObservationIssue.ObservationInfo   (String)
                    // -----------------------------------

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("ObservationInfo");
                    Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
                    Assert.AreEqual(1, polSourceObservationIssue.ValidationResults.Count());
                    Assert.IsTrue(polSourceObservationIssue.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.PolSourceObservationIssueObservationInfo)).Any());
                    Assert.AreEqual(null, polSourceObservationIssue.ObservationInfo);
                    Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.ObservationInfo = GetRandomString("", 251);
                    Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.PolSourceObservationIssueObservationInfo, "250"), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000)]
                    // polSourceObservationIssue.Ordinal   (Int32)
                    // -----------------------------------

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.Ordinal = -1;
                    Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.PolSourceObservationIssueOrdinal, "0", "1000"), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());
                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.Ordinal = 1001;
                    Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.PolSourceObservationIssueOrdinal, "0", "1000"), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // polSourceObservationIssue.PolSourceObservationIssueWeb   (PolSourceObservationIssueWeb)
                    // -----------------------------------

                    //Error: Type not implemented [PolSourceObservationIssueWeb]


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // polSourceObservationIssue.PolSourceObservationIssueReport   (PolSourceObservationIssueReport)
                    // -----------------------------------

                    //Error: Type not implemented [PolSourceObservationIssueReport]


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // polSourceObservationIssue.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // polSourceObservationIssue.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.LastUpdateContactTVItemID = 0;
                    polSourceObservationIssueService.Add(polSourceObservationIssue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.PolSourceObservationIssueLastUpdateContactTVItemID, polSourceObservationIssue.LastUpdateContactTVItemID.ToString()), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.LastUpdateContactTVItemID = 1;
                    polSourceObservationIssueService.Add(polSourceObservationIssue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.PolSourceObservationIssueLastUpdateContactTVItemID, "Contact"), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // polSourceObservationIssue.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // polSourceObservationIssue.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void PolSourceObservationIssue_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(LanguageRequest, dbTestDB, ContactID);
                    PolSourceObservationIssue polSourceObservationIssue = (from c in polSourceObservationIssueService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(polSourceObservationIssue);

                    PolSourceObservationIssue polSourceObservationIssueRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb })
                    {
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            polSourceObservationIssueRet = polSourceObservationIssueService.GetPolSourceObservationIssueWithPolSourceObservationIssueID(polSourceObservationIssue.PolSourceObservationIssueID);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            polSourceObservationIssueRet = polSourceObservationIssueService.GetPolSourceObservationIssueWithPolSourceObservationIssueID(polSourceObservationIssue.PolSourceObservationIssueID, EntityQueryDetailTypeEnum.EntityOnly);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            polSourceObservationIssueRet = polSourceObservationIssueService.GetPolSourceObservationIssueWithPolSourceObservationIssueID(polSourceObservationIssue.PolSourceObservationIssueID, EntityQueryDetailTypeEnum.EntityWeb);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Entity fields
                        Assert.IsNotNull(polSourceObservationIssueRet.PolSourceObservationIssueID);
                        Assert.IsNotNull(polSourceObservationIssueRet.PolSourceObservationID);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationIssueRet.ObservationInfo));
                        Assert.IsNotNull(polSourceObservationIssueRet.Ordinal);
                        Assert.IsNotNull(polSourceObservationIssueRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(polSourceObservationIssueRet.LastUpdateContactTVItemID);

                        // Non entity fields
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            if (polSourceObservationIssueRet.PolSourceObservationIssueWeb != null)
                            {
                                Assert.IsNull(polSourceObservationIssueRet.PolSourceObservationIssueWeb);
                            }
                            if (polSourceObservationIssueRet.PolSourceObservationIssueReport != null)
                            {
                                Assert.IsNull(polSourceObservationIssueRet.PolSourceObservationIssueReport);
                            }
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            if (polSourceObservationIssueRet.PolSourceObservationIssueWeb != null)
                            {
                                Assert.IsNotNull(polSourceObservationIssueRet.PolSourceObservationIssueWeb);
                            }
                            if (polSourceObservationIssueRet.PolSourceObservationIssueReport != null)
                            {
                                Assert.IsNotNull(polSourceObservationIssueRet.PolSourceObservationIssueReport);
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of PolSourceObservationIssue
        #endregion Tests Get List of PolSourceObservationIssue

    }
}
