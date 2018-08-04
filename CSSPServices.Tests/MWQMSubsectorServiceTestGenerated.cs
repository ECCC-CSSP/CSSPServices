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
    public partial class MWQMSubsectorServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MWQMSubsectorService mwqmSubsectorService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSubsectorServiceTest() : base()
        {
            //mwqmSubsectorService = new MWQMSubsectorService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MWQMSubsector_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    MWQMSubsector mwqmSubsector = GetFilledRandomMWQMSubsector("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = mwqmSubsectorService.GetMWQMSubsectorList().Count();

                    Assert.AreEqual(mwqmSubsectorService.GetMWQMSubsectorList().Count(), (from c in dbTestDB.MWQMSubsectors select c).Take(200).Count());

                    mwqmSubsectorService.Add(mwqmSubsector);
                    if (mwqmSubsector.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mwqmSubsectorService.GetMWQMSubsectorList().Where(c => c == mwqmSubsector).Any());
                    mwqmSubsectorService.Update(mwqmSubsector);
                    if (mwqmSubsector.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mwqmSubsectorService.GetMWQMSubsectorList().Count());
                    mwqmSubsectorService.Delete(mwqmSubsector);
                    if (mwqmSubsector.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mwqmSubsectorService.GetMWQMSubsectorList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // mwqmSubsector.MWQMSubsectorID   (Int32)
                    // -----------------------------------

                    mwqmSubsector = null;
                    mwqmSubsector = GetFilledRandomMWQMSubsector("");
                    mwqmSubsector.MWQMSubsectorID = 0;
                    mwqmSubsectorService.Update(mwqmSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMSubsectorMWQMSubsectorID"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSubsector = null;
                    mwqmSubsector = GetFilledRandomMWQMSubsector("");
                    mwqmSubsector.MWQMSubsectorID = 10000000;
                    mwqmSubsectorService.Update(mwqmSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMSubsector", "MWQMSubsectorMWQMSubsectorID", mwqmSubsector.MWQMSubsectorID.ToString()), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Subsector)]
                    // mwqmSubsector.MWQMSubsectorTVItemID   (Int32)
                    // -----------------------------------

                    mwqmSubsector = null;
                    mwqmSubsector = GetFilledRandomMWQMSubsector("");
                    mwqmSubsector.MWQMSubsectorTVItemID = 0;
                    mwqmSubsectorService.Add(mwqmSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSubsectorMWQMSubsectorTVItemID", mwqmSubsector.MWQMSubsectorTVItemID.ToString()), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSubsector = null;
                    mwqmSubsector = GetFilledRandomMWQMSubsector("");
                    mwqmSubsector.MWQMSubsectorTVItemID = 1;
                    mwqmSubsectorService.Add(mwqmSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSubsectorMWQMSubsectorTVItemID", "Subsector"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(20))]
                    // mwqmSubsector.SubsectorHistoricKey   (String)
                    // -----------------------------------

                    mwqmSubsector = null;
                    mwqmSubsector = GetFilledRandomMWQMSubsector("SubsectorHistoricKey");
                    Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                    Assert.AreEqual(1, mwqmSubsector.ValidationResults.Count());
                    Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "MWQMSubsectorSubsectorHistoricKey")).Any());
                    Assert.AreEqual(null, mwqmSubsector.SubsectorHistoricKey);
                    Assert.AreEqual(count, mwqmSubsectorService.GetMWQMSubsectorList().Count());

                    mwqmSubsector = null;
                    mwqmSubsector = GetFilledRandomMWQMSubsector("");
                    mwqmSubsector.SubsectorHistoricKey = GetRandomString("", 21);
                    Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "MWQMSubsectorSubsectorHistoricKey", "20"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSubsectorService.GetMWQMSubsectorList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(20))]
                    // mwqmSubsector.TideLocationSIDText   (String)
                    // -----------------------------------

                    mwqmSubsector = null;
                    mwqmSubsector = GetFilledRandomMWQMSubsector("");
                    mwqmSubsector.TideLocationSIDText = GetRandomString("", 21);
                    Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "MWQMSubsectorTideLocationSIDText", "20"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSubsectorService.GetMWQMSubsectorList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmSubsector.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mwqmSubsector = null;
                    mwqmSubsector = GetFilledRandomMWQMSubsector("");
                    mwqmSubsector.LastUpdateDate_UTC = new DateTime();
                    mwqmSubsectorService.Add(mwqmSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMSubsectorLastUpdateDate_UTC"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                    mwqmSubsector = null;
                    mwqmSubsector = GetFilledRandomMWQMSubsector("");
                    mwqmSubsector.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mwqmSubsectorService.Add(mwqmSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMSubsectorLastUpdateDate_UTC", "1980"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mwqmSubsector.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mwqmSubsector = null;
                    mwqmSubsector = GetFilledRandomMWQMSubsector("");
                    mwqmSubsector.LastUpdateContactTVItemID = 0;
                    mwqmSubsectorService.Add(mwqmSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSubsectorLastUpdateContactTVItemID", mwqmSubsector.LastUpdateContactTVItemID.ToString()), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSubsector = null;
                    mwqmSubsector = GetFilledRandomMWQMSubsector("");
                    mwqmSubsector.LastUpdateContactTVItemID = 1;
                    mwqmSubsectorService.Add(mwqmSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSubsectorLastUpdateContactTVItemID", "Contact"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmSubsector.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmSubsector.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetMWQMSubsectorWithMWQMSubsectorID(mwqmSubsector.MWQMSubsectorID)
        [TestMethod]
        public void GetMWQMSubsectorWithMWQMSubsectorID__mwqmSubsector_MWQMSubsectorID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMSubsector mwqmSubsector = (from c in dbTestDB.MWQMSubsectors select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmSubsector);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mwqmSubsectorService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            MWQMSubsector mwqmSubsectorRet = mwqmSubsectorService.GetMWQMSubsectorWithMWQMSubsectorID(mwqmSubsector.MWQMSubsectorID);
                            CheckMWQMSubsectorFields(new List<MWQMSubsector>() { mwqmSubsectorRet });
                            Assert.AreEqual(mwqmSubsector.MWQMSubsectorID, mwqmSubsectorRet.MWQMSubsectorID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            MWQMSubsectorWeb mwqmSubsectorWebRet = mwqmSubsectorService.GetMWQMSubsectorWebWithMWQMSubsectorID(mwqmSubsector.MWQMSubsectorID);
                            CheckMWQMSubsectorWebFields(new List<MWQMSubsectorWeb>() { mwqmSubsectorWebRet });
                            Assert.AreEqual(mwqmSubsector.MWQMSubsectorID, mwqmSubsectorWebRet.MWQMSubsectorID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            MWQMSubsectorReport mwqmSubsectorReportRet = mwqmSubsectorService.GetMWQMSubsectorReportWithMWQMSubsectorID(mwqmSubsector.MWQMSubsectorID);
                            CheckMWQMSubsectorReportFields(new List<MWQMSubsectorReport>() { mwqmSubsectorReportRet });
                            Assert.AreEqual(mwqmSubsector.MWQMSubsectorID, mwqmSubsectorReportRet.MWQMSubsectorID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSubsectorWithMWQMSubsectorID(mwqmSubsector.MWQMSubsectorID)

        #region Tests Generated for GetMWQMSubsectorList()
        [TestMethod]
        public void GetMWQMSubsectorList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMSubsector mwqmSubsector = (from c in dbTestDB.MWQMSubsectors select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmSubsector);

                    List<MWQMSubsector> mwqmSubsectorDirectQueryList = new List<MWQMSubsector>();
                    mwqmSubsectorDirectQueryList = (from c in dbTestDB.MWQMSubsectors select c).Take(200).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mwqmSubsectorService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MWQMSubsector> mwqmSubsectorList = new List<MWQMSubsector>();
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                            CheckMWQMSubsectorFields(mwqmSubsectorList);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList.Count, mwqmSubsectorList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MWQMSubsectorWeb> mwqmSubsectorWebList = new List<MWQMSubsectorWeb>();
                            mwqmSubsectorWebList = mwqmSubsectorService.GetMWQMSubsectorWebList().ToList();
                            CheckMWQMSubsectorWebFields(mwqmSubsectorWebList);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList.Count, mwqmSubsectorWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MWQMSubsectorReport> mwqmSubsectorReportList = new List<MWQMSubsectorReport>();
                            mwqmSubsectorReportList = mwqmSubsectorService.GetMWQMSubsectorReportList().ToList();
                            CheckMWQMSubsectorReportFields(mwqmSubsectorReportList);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList.Count, mwqmSubsectorReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSubsectorList()

        #region Tests Generated for GetMWQMSubsectorList() Skip Take
        [TestMethod]
        public void GetMWQMSubsectorList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSubsectorService.Query = mwqmSubsectorService.FillQuery(typeof(MWQMSubsector), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MWQMSubsector> mwqmSubsectorDirectQueryList = new List<MWQMSubsector>();
                        mwqmSubsectorDirectQueryList = (from c in dbTestDB.MWQMSubsectors select c).Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MWQMSubsector> mwqmSubsectorList = new List<MWQMSubsector>();
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                            CheckMWQMSubsectorFields(mwqmSubsectorList);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList[0].MWQMSubsectorID, mwqmSubsectorList[0].MWQMSubsectorID);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList.Count, mwqmSubsectorList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MWQMSubsectorWeb> mwqmSubsectorWebList = new List<MWQMSubsectorWeb>();
                            mwqmSubsectorWebList = mwqmSubsectorService.GetMWQMSubsectorWebList().ToList();
                            CheckMWQMSubsectorWebFields(mwqmSubsectorWebList);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList[0].MWQMSubsectorID, mwqmSubsectorWebList[0].MWQMSubsectorID);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList.Count, mwqmSubsectorWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MWQMSubsectorReport> mwqmSubsectorReportList = new List<MWQMSubsectorReport>();
                            mwqmSubsectorReportList = mwqmSubsectorService.GetMWQMSubsectorReportList().ToList();
                            CheckMWQMSubsectorReportFields(mwqmSubsectorReportList);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList[0].MWQMSubsectorID, mwqmSubsectorReportList[0].MWQMSubsectorID);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList.Count, mwqmSubsectorReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSubsectorList() Skip Take

        #region Tests Generated for GetMWQMSubsectorList() Skip Take Order
        [TestMethod]
        public void GetMWQMSubsectorList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSubsectorService.Query = mwqmSubsectorService.FillQuery(typeof(MWQMSubsector), culture.TwoLetterISOLanguageName, 1, 1,  "MWQMSubsectorID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MWQMSubsector> mwqmSubsectorDirectQueryList = new List<MWQMSubsector>();
                        mwqmSubsectorDirectQueryList = (from c in dbTestDB.MWQMSubsectors select c).Skip(1).Take(1).OrderBy(c => c.MWQMSubsectorID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MWQMSubsector> mwqmSubsectorList = new List<MWQMSubsector>();
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                            CheckMWQMSubsectorFields(mwqmSubsectorList);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList[0].MWQMSubsectorID, mwqmSubsectorList[0].MWQMSubsectorID);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList.Count, mwqmSubsectorList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MWQMSubsectorWeb> mwqmSubsectorWebList = new List<MWQMSubsectorWeb>();
                            mwqmSubsectorWebList = mwqmSubsectorService.GetMWQMSubsectorWebList().ToList();
                            CheckMWQMSubsectorWebFields(mwqmSubsectorWebList);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList[0].MWQMSubsectorID, mwqmSubsectorWebList[0].MWQMSubsectorID);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList.Count, mwqmSubsectorWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MWQMSubsectorReport> mwqmSubsectorReportList = new List<MWQMSubsectorReport>();
                            mwqmSubsectorReportList = mwqmSubsectorService.GetMWQMSubsectorReportList().ToList();
                            CheckMWQMSubsectorReportFields(mwqmSubsectorReportList);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList[0].MWQMSubsectorID, mwqmSubsectorReportList[0].MWQMSubsectorID);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList.Count, mwqmSubsectorReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSubsectorList() Skip Take Order

        #region Tests Generated for GetMWQMSubsectorList() Skip Take 2Order
        [TestMethod]
        public void GetMWQMSubsectorList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSubsectorService.Query = mwqmSubsectorService.FillQuery(typeof(MWQMSubsector), culture.TwoLetterISOLanguageName, 1, 1, "MWQMSubsectorID,MWQMSubsectorTVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MWQMSubsector> mwqmSubsectorDirectQueryList = new List<MWQMSubsector>();
                        mwqmSubsectorDirectQueryList = (from c in dbTestDB.MWQMSubsectors select c).Skip(1).Take(1).OrderBy(c => c.MWQMSubsectorID).ThenBy(c => c.MWQMSubsectorTVItemID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MWQMSubsector> mwqmSubsectorList = new List<MWQMSubsector>();
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                            CheckMWQMSubsectorFields(mwqmSubsectorList);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList[0].MWQMSubsectorID, mwqmSubsectorList[0].MWQMSubsectorID);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList.Count, mwqmSubsectorList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MWQMSubsectorWeb> mwqmSubsectorWebList = new List<MWQMSubsectorWeb>();
                            mwqmSubsectorWebList = mwqmSubsectorService.GetMWQMSubsectorWebList().ToList();
                            CheckMWQMSubsectorWebFields(mwqmSubsectorWebList);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList[0].MWQMSubsectorID, mwqmSubsectorWebList[0].MWQMSubsectorID);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList.Count, mwqmSubsectorWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MWQMSubsectorReport> mwqmSubsectorReportList = new List<MWQMSubsectorReport>();
                            mwqmSubsectorReportList = mwqmSubsectorService.GetMWQMSubsectorReportList().ToList();
                            CheckMWQMSubsectorReportFields(mwqmSubsectorReportList);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList[0].MWQMSubsectorID, mwqmSubsectorReportList[0].MWQMSubsectorID);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList.Count, mwqmSubsectorReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSubsectorList() Skip Take 2Order

        #region Tests Generated for GetMWQMSubsectorList() Skip Take Order Where
        [TestMethod]
        public void GetMWQMSubsectorList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSubsectorService.Query = mwqmSubsectorService.FillQuery(typeof(MWQMSubsector), culture.TwoLetterISOLanguageName, 0, 1, "MWQMSubsectorID", "MWQMSubsectorID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MWQMSubsector> mwqmSubsectorDirectQueryList = new List<MWQMSubsector>();
                        mwqmSubsectorDirectQueryList = (from c in dbTestDB.MWQMSubsectors select c).Where(c => c.MWQMSubsectorID == 4).Skip(0).Take(1).OrderBy(c => c.MWQMSubsectorID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MWQMSubsector> mwqmSubsectorList = new List<MWQMSubsector>();
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                            CheckMWQMSubsectorFields(mwqmSubsectorList);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList[0].MWQMSubsectorID, mwqmSubsectorList[0].MWQMSubsectorID);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList.Count, mwqmSubsectorList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MWQMSubsectorWeb> mwqmSubsectorWebList = new List<MWQMSubsectorWeb>();
                            mwqmSubsectorWebList = mwqmSubsectorService.GetMWQMSubsectorWebList().ToList();
                            CheckMWQMSubsectorWebFields(mwqmSubsectorWebList);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList[0].MWQMSubsectorID, mwqmSubsectorWebList[0].MWQMSubsectorID);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList.Count, mwqmSubsectorWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MWQMSubsectorReport> mwqmSubsectorReportList = new List<MWQMSubsectorReport>();
                            mwqmSubsectorReportList = mwqmSubsectorService.GetMWQMSubsectorReportList().ToList();
                            CheckMWQMSubsectorReportFields(mwqmSubsectorReportList);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList[0].MWQMSubsectorID, mwqmSubsectorReportList[0].MWQMSubsectorID);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList.Count, mwqmSubsectorReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSubsectorList() Skip Take Order Where

        #region Tests Generated for GetMWQMSubsectorList() Skip Take Order 2Where
        [TestMethod]
        public void GetMWQMSubsectorList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSubsectorService.Query = mwqmSubsectorService.FillQuery(typeof(MWQMSubsector), culture.TwoLetterISOLanguageName, 0, 1, "MWQMSubsectorID", "MWQMSubsectorID,GT,2|MWQMSubsectorID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MWQMSubsector> mwqmSubsectorDirectQueryList = new List<MWQMSubsector>();
                        mwqmSubsectorDirectQueryList = (from c in dbTestDB.MWQMSubsectors select c).Where(c => c.MWQMSubsectorID > 2 && c.MWQMSubsectorID < 5).Skip(0).Take(1).OrderBy(c => c.MWQMSubsectorID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MWQMSubsector> mwqmSubsectorList = new List<MWQMSubsector>();
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                            CheckMWQMSubsectorFields(mwqmSubsectorList);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList[0].MWQMSubsectorID, mwqmSubsectorList[0].MWQMSubsectorID);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList.Count, mwqmSubsectorList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MWQMSubsectorWeb> mwqmSubsectorWebList = new List<MWQMSubsectorWeb>();
                            mwqmSubsectorWebList = mwqmSubsectorService.GetMWQMSubsectorWebList().ToList();
                            CheckMWQMSubsectorWebFields(mwqmSubsectorWebList);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList[0].MWQMSubsectorID, mwqmSubsectorWebList[0].MWQMSubsectorID);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList.Count, mwqmSubsectorWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MWQMSubsectorReport> mwqmSubsectorReportList = new List<MWQMSubsectorReport>();
                            mwqmSubsectorReportList = mwqmSubsectorService.GetMWQMSubsectorReportList().ToList();
                            CheckMWQMSubsectorReportFields(mwqmSubsectorReportList);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList[0].MWQMSubsectorID, mwqmSubsectorReportList[0].MWQMSubsectorID);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList.Count, mwqmSubsectorReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSubsectorList() Skip Take Order 2Where

        #region Tests Generated for GetMWQMSubsectorList() 2Where
        [TestMethod]
        public void GetMWQMSubsectorList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSubsectorService.Query = mwqmSubsectorService.FillQuery(typeof(MWQMSubsector), culture.TwoLetterISOLanguageName, 0, 10000, "", "MWQMSubsectorID,GT,2|MWQMSubsectorID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MWQMSubsector> mwqmSubsectorDirectQueryList = new List<MWQMSubsector>();
                        mwqmSubsectorDirectQueryList = (from c in dbTestDB.MWQMSubsectors select c).Where(c => c.MWQMSubsectorID > 2 && c.MWQMSubsectorID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MWQMSubsector> mwqmSubsectorList = new List<MWQMSubsector>();
                            mwqmSubsectorList = mwqmSubsectorService.GetMWQMSubsectorList().ToList();
                            CheckMWQMSubsectorFields(mwqmSubsectorList);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList[0].MWQMSubsectorID, mwqmSubsectorList[0].MWQMSubsectorID);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList.Count, mwqmSubsectorList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MWQMSubsectorWeb> mwqmSubsectorWebList = new List<MWQMSubsectorWeb>();
                            mwqmSubsectorWebList = mwqmSubsectorService.GetMWQMSubsectorWebList().ToList();
                            CheckMWQMSubsectorWebFields(mwqmSubsectorWebList);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList[0].MWQMSubsectorID, mwqmSubsectorWebList[0].MWQMSubsectorID);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList.Count, mwqmSubsectorWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MWQMSubsectorReport> mwqmSubsectorReportList = new List<MWQMSubsectorReport>();
                            mwqmSubsectorReportList = mwqmSubsectorService.GetMWQMSubsectorReportList().ToList();
                            CheckMWQMSubsectorReportFields(mwqmSubsectorReportList);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList[0].MWQMSubsectorID, mwqmSubsectorReportList[0].MWQMSubsectorID);
                            Assert.AreEqual(mwqmSubsectorDirectQueryList.Count, mwqmSubsectorReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSubsectorList() 2Where

        #region Functions private
        private void CheckMWQMSubsectorFields(List<MWQMSubsector> mwqmSubsectorList)
        {
            Assert.IsNotNull(mwqmSubsectorList[0].MWQMSubsectorID);
            Assert.IsNotNull(mwqmSubsectorList[0].MWQMSubsectorTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorList[0].SubsectorHistoricKey));
            if (!string.IsNullOrWhiteSpace(mwqmSubsectorList[0].TideLocationSIDText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorList[0].TideLocationSIDText));
            }
            Assert.IsNotNull(mwqmSubsectorList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmSubsectorList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmSubsectorList[0].HasErrors);
        }
        private void CheckMWQMSubsectorWebFields(List<MWQMSubsectorWeb> mwqmSubsectorWebList)
        {
            Assert.IsNotNull(mwqmSubsectorWebList[0].SubsectorTVItemLanguage);
            Assert.IsNotNull(mwqmSubsectorWebList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(mwqmSubsectorWebList[0].MWQMSubsectorID);
            Assert.IsNotNull(mwqmSubsectorWebList[0].MWQMSubsectorTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorWebList[0].SubsectorHistoricKey));
            if (!string.IsNullOrWhiteSpace(mwqmSubsectorWebList[0].TideLocationSIDText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorWebList[0].TideLocationSIDText));
            }
            Assert.IsNotNull(mwqmSubsectorWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmSubsectorWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmSubsectorWebList[0].HasErrors);
        }
        private void CheckMWQMSubsectorReportFields(List<MWQMSubsectorReport> mwqmSubsectorReportList)
        {
            if (!string.IsNullOrWhiteSpace(mwqmSubsectorReportList[0].MWQMSubsectorReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorReportList[0].MWQMSubsectorReportTest));
            }
            Assert.IsNotNull(mwqmSubsectorReportList[0].SubsectorTVItemLanguage);
            Assert.IsNotNull(mwqmSubsectorReportList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(mwqmSubsectorReportList[0].MWQMSubsectorID);
            Assert.IsNotNull(mwqmSubsectorReportList[0].MWQMSubsectorTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorReportList[0].SubsectorHistoricKey));
            if (!string.IsNullOrWhiteSpace(mwqmSubsectorReportList[0].TideLocationSIDText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSubsectorReportList[0].TideLocationSIDText));
            }
            Assert.IsNotNull(mwqmSubsectorReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmSubsectorReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmSubsectorReportList[0].HasErrors);
        }
        private MWQMSubsector GetFilledRandomMWQMSubsector(string OmitPropName)
        {
            MWQMSubsector mwqmSubsector = new MWQMSubsector();

            if (OmitPropName != "MWQMSubsectorTVItemID") mwqmSubsector.MWQMSubsectorTVItemID = 11;
            if (OmitPropName != "SubsectorHistoricKey") mwqmSubsector.SubsectorHistoricKey = GetRandomString("", 5);
            if (OmitPropName != "TideLocationSIDText") mwqmSubsector.TideLocationSIDText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSubsector.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSubsector.LastUpdateContactTVItemID = 2;

            return mwqmSubsector;
        }
        #endregion Functions private
    }
}
