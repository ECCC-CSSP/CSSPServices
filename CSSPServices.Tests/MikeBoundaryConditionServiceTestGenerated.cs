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
    public partial class MikeBoundaryConditionServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MikeBoundaryConditionService mikeBoundaryConditionService { get; set; }
        #endregion Properties

        #region Constructors
        public MikeBoundaryConditionServiceTest() : base()
        {
            //mikeBoundaryConditionService = new MikeBoundaryConditionService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MikeBoundaryCondition_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    MikeBoundaryCondition mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = mikeBoundaryConditionService.GetMikeBoundaryConditionList().Count();

                    Assert.AreEqual(mikeBoundaryConditionService.GetMikeBoundaryConditionList().Count(), (from c in dbTestDB.MikeBoundaryConditions select c).Take(200).Count());

                    mikeBoundaryConditionService.Add(mikeBoundaryCondition);
                    if (mikeBoundaryCondition.HasErrors)
                    {
                        Assert.AreEqual("", mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mikeBoundaryConditionService.GetMikeBoundaryConditionList().Where(c => c == mikeBoundaryCondition).Any());
                    mikeBoundaryConditionService.Update(mikeBoundaryCondition);
                    if (mikeBoundaryCondition.HasErrors)
                    {
                        Assert.AreEqual("", mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mikeBoundaryConditionService.GetMikeBoundaryConditionList().Count());
                    mikeBoundaryConditionService.Delete(mikeBoundaryCondition);
                    if (mikeBoundaryCondition.HasErrors)
                    {
                        Assert.AreEqual("", mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mikeBoundaryConditionService.GetMikeBoundaryConditionList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // mikeBoundaryCondition.MikeBoundaryConditionID   (Int32)
                    // -----------------------------------

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.MikeBoundaryConditionID = 0;
                    mikeBoundaryConditionService.Update(mikeBoundaryCondition);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MikeBoundaryConditionMikeBoundaryConditionID"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.MikeBoundaryConditionID = 10000000;
                    mikeBoundaryConditionService.Update(mikeBoundaryCondition);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MikeBoundaryCondition", "MikeBoundaryConditionMikeBoundaryConditionID", mikeBoundaryCondition.MikeBoundaryConditionID.ToString()), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide)]
                    // mikeBoundaryCondition.MikeBoundaryConditionTVItemID   (Int32)
                    // -----------------------------------

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.MikeBoundaryConditionTVItemID = 0;
                    mikeBoundaryConditionService.Add(mikeBoundaryCondition);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MikeBoundaryConditionMikeBoundaryConditionTVItemID", mikeBoundaryCondition.MikeBoundaryConditionTVItemID.ToString()), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.MikeBoundaryConditionTVItemID = 1;
                    mikeBoundaryConditionService.Add(mikeBoundaryCondition);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MikeBoundaryConditionMikeBoundaryConditionTVItemID", "MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // mikeBoundaryCondition.MikeBoundaryConditionCode   (String)
                    // -----------------------------------

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("MikeBoundaryConditionCode");
                    Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
                    Assert.AreEqual(1, mikeBoundaryCondition.ValidationResults.Count());
                    Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "MikeBoundaryConditionMikeBoundaryConditionCode")).Any());
                    Assert.AreEqual(null, mikeBoundaryCondition.MikeBoundaryConditionCode);
                    Assert.AreEqual(count, mikeBoundaryConditionService.GetMikeBoundaryConditionList().Count());

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.MikeBoundaryConditionCode = GetRandomString("", 101);
                    Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "MikeBoundaryConditionMikeBoundaryConditionCode", "100"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeBoundaryConditionService.GetMikeBoundaryConditionList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // mikeBoundaryCondition.MikeBoundaryConditionName   (String)
                    // -----------------------------------

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("MikeBoundaryConditionName");
                    Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
                    Assert.AreEqual(1, mikeBoundaryCondition.ValidationResults.Count());
                    Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "MikeBoundaryConditionMikeBoundaryConditionName")).Any());
                    Assert.AreEqual(null, mikeBoundaryCondition.MikeBoundaryConditionName);
                    Assert.AreEqual(count, mikeBoundaryConditionService.GetMikeBoundaryConditionList().Count());

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.MikeBoundaryConditionName = GetRandomString("", 101);
                    Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "MikeBoundaryConditionMikeBoundaryConditionName", "100"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeBoundaryConditionService.GetMikeBoundaryConditionList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 100000)]
                    // mikeBoundaryCondition.MikeBoundaryConditionLength_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [MikeBoundaryConditionLength_m]

                    //Error: Type not implemented [MikeBoundaryConditionLength_m]

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.MikeBoundaryConditionLength_m = 0.0D;
                    Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeBoundaryConditionMikeBoundaryConditionLength_m", "1", "100000"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeBoundaryConditionService.GetMikeBoundaryConditionList().Count());
                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.MikeBoundaryConditionLength_m = 100001.0D;
                    Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeBoundaryConditionMikeBoundaryConditionLength_m", "1", "100000"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeBoundaryConditionService.GetMikeBoundaryConditionList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // mikeBoundaryCondition.MikeBoundaryConditionFormat   (String)
                    // -----------------------------------

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("MikeBoundaryConditionFormat");
                    Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
                    Assert.AreEqual(1, mikeBoundaryCondition.ValidationResults.Count());
                    Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "MikeBoundaryConditionMikeBoundaryConditionFormat")).Any());
                    Assert.AreEqual(null, mikeBoundaryCondition.MikeBoundaryConditionFormat);
                    Assert.AreEqual(count, mikeBoundaryConditionService.GetMikeBoundaryConditionList().Count());

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.MikeBoundaryConditionFormat = GetRandomString("", 101);
                    Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "MikeBoundaryConditionMikeBoundaryConditionFormat", "100"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeBoundaryConditionService.GetMikeBoundaryConditionList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocity   (MikeBoundaryConditionLevelOrVelocityEnum)
                    // -----------------------------------

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocity = (MikeBoundaryConditionLevelOrVelocityEnum)1000000;
                    mikeBoundaryConditionService.Add(mikeBoundaryCondition);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MikeBoundaryConditionMikeBoundaryConditionLevelOrVelocity"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mikeBoundaryCondition.WebTideDataSet   (WebTideDataSetEnum)
                    // -----------------------------------

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.WebTideDataSet = (WebTideDataSetEnum)1000000;
                    mikeBoundaryConditionService.Add(mikeBoundaryCondition);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MikeBoundaryConditionWebTideDataSet"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000)]
                    // mikeBoundaryCondition.NumberOfWebTideNodes   (Int32)
                    // -----------------------------------

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.NumberOfWebTideNodes = -1;
                    Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeBoundaryConditionNumberOfWebTideNodes", "0", "1000"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeBoundaryConditionService.GetMikeBoundaryConditionList().Count());
                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.NumberOfWebTideNodes = 1001;
                    Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeBoundaryConditionNumberOfWebTideNodes", "0", "1000"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeBoundaryConditionService.GetMikeBoundaryConditionList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // mikeBoundaryCondition.WebTideDataFromStartToEndDate   (String)
                    // -----------------------------------

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("WebTideDataFromStartToEndDate");
                    Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
                    Assert.AreEqual(1, mikeBoundaryCondition.ValidationResults.Count());
                    Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "MikeBoundaryConditionWebTideDataFromStartToEndDate")).Any());
                    Assert.AreEqual(null, mikeBoundaryCondition.WebTideDataFromStartToEndDate);
                    Assert.AreEqual(count, mikeBoundaryConditionService.GetMikeBoundaryConditionList().Count());


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mikeBoundaryCondition.TVType   (TVTypeEnum)
                    // -----------------------------------

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.TVType = (TVTypeEnum)1000000;
                    mikeBoundaryConditionService.Add(mikeBoundaryCondition);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MikeBoundaryConditionTVType"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mikeBoundaryCondition.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.LastUpdateDate_UTC = new DateTime();
                    mikeBoundaryConditionService.Add(mikeBoundaryCondition);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MikeBoundaryConditionLastUpdateDate_UTC"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);
                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mikeBoundaryConditionService.Add(mikeBoundaryCondition);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MikeBoundaryConditionLastUpdateDate_UTC", "1980"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mikeBoundaryCondition.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.LastUpdateContactTVItemID = 0;
                    mikeBoundaryConditionService.Add(mikeBoundaryCondition);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MikeBoundaryConditionLastUpdateContactTVItemID", mikeBoundaryCondition.LastUpdateContactTVItemID.ToString()), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);

                    mikeBoundaryCondition = null;
                    mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
                    mikeBoundaryCondition.LastUpdateContactTVItemID = 1;
                    mikeBoundaryConditionService.Add(mikeBoundaryCondition);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MikeBoundaryConditionLastUpdateContactTVItemID", "Contact"), mikeBoundaryCondition.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mikeBoundaryCondition.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mikeBoundaryCondition.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetMikeBoundaryConditionWithMikeBoundaryConditionID(mikeBoundaryCondition.MikeBoundaryConditionID)
        [TestMethod]
        public void GetMikeBoundaryConditionWithMikeBoundaryConditionID__mikeBoundaryCondition_MikeBoundaryConditionID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MikeBoundaryCondition mikeBoundaryCondition = (from c in dbTestDB.MikeBoundaryConditions select c).FirstOrDefault();
                    Assert.IsNotNull(mikeBoundaryCondition);

                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        mikeBoundaryConditionService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            MikeBoundaryCondition mikeBoundaryConditionRet = mikeBoundaryConditionService.GetMikeBoundaryConditionWithMikeBoundaryConditionID(mikeBoundaryCondition.MikeBoundaryConditionID);
                            CheckMikeBoundaryConditionFields(new List<MikeBoundaryCondition>() { mikeBoundaryConditionRet });
                            Assert.AreEqual(mikeBoundaryCondition.MikeBoundaryConditionID, mikeBoundaryConditionRet.MikeBoundaryConditionID);
                        }
                        else if (detail == "ExtraA")
                        {
                            MikeBoundaryConditionExtraA mikeBoundaryConditionExtraARet = mikeBoundaryConditionService.GetMikeBoundaryConditionExtraAWithMikeBoundaryConditionID(mikeBoundaryCondition.MikeBoundaryConditionID);
                            CheckMikeBoundaryConditionExtraAFields(new List<MikeBoundaryConditionExtraA>() { mikeBoundaryConditionExtraARet });
                            Assert.AreEqual(mikeBoundaryCondition.MikeBoundaryConditionID, mikeBoundaryConditionExtraARet.MikeBoundaryConditionID);
                        }
                        else if (detail == "ExtraB")
                        {
                            MikeBoundaryConditionExtraB mikeBoundaryConditionExtraBRet = mikeBoundaryConditionService.GetMikeBoundaryConditionExtraBWithMikeBoundaryConditionID(mikeBoundaryCondition.MikeBoundaryConditionID);
                            CheckMikeBoundaryConditionExtraBFields(new List<MikeBoundaryConditionExtraB>() { mikeBoundaryConditionExtraBRet });
                            Assert.AreEqual(mikeBoundaryCondition.MikeBoundaryConditionID, mikeBoundaryConditionExtraBRet.MikeBoundaryConditionID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeBoundaryConditionWithMikeBoundaryConditionID(mikeBoundaryCondition.MikeBoundaryConditionID)

        #region Tests Generated for GetMikeBoundaryConditionList()
        [TestMethod]
        public void GetMikeBoundaryConditionList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MikeBoundaryCondition mikeBoundaryCondition = (from c in dbTestDB.MikeBoundaryConditions select c).FirstOrDefault();
                    Assert.IsNotNull(mikeBoundaryCondition);

                    List<MikeBoundaryCondition> mikeBoundaryConditionDirectQueryList = new List<MikeBoundaryCondition>();
                    mikeBoundaryConditionDirectQueryList = (from c in dbTestDB.MikeBoundaryConditions select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        mikeBoundaryConditionService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MikeBoundaryCondition> mikeBoundaryConditionList = new List<MikeBoundaryCondition>();
                            mikeBoundaryConditionList = mikeBoundaryConditionService.GetMikeBoundaryConditionList().ToList();
                            CheckMikeBoundaryConditionFields(mikeBoundaryConditionList);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<MikeBoundaryConditionExtraA> mikeBoundaryConditionExtraAList = new List<MikeBoundaryConditionExtraA>();
                            mikeBoundaryConditionExtraAList = mikeBoundaryConditionService.GetMikeBoundaryConditionExtraAList().ToList();
                            CheckMikeBoundaryConditionExtraAFields(mikeBoundaryConditionExtraAList);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList.Count, mikeBoundaryConditionExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<MikeBoundaryConditionExtraB> mikeBoundaryConditionExtraBList = new List<MikeBoundaryConditionExtraB>();
                            mikeBoundaryConditionExtraBList = mikeBoundaryConditionService.GetMikeBoundaryConditionExtraBList().ToList();
                            CheckMikeBoundaryConditionExtraBFields(mikeBoundaryConditionExtraBList);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList.Count, mikeBoundaryConditionExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeBoundaryConditionList()

        #region Tests Generated for GetMikeBoundaryConditionList() Skip Take
        [TestMethod]
        public void GetMikeBoundaryConditionList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mikeBoundaryConditionService.Query = mikeBoundaryConditionService.FillQuery(typeof(MikeBoundaryCondition), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<MikeBoundaryCondition> mikeBoundaryConditionDirectQueryList = new List<MikeBoundaryCondition>();
                        mikeBoundaryConditionDirectQueryList = (from c in dbTestDB.MikeBoundaryConditions select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MikeBoundaryCondition> mikeBoundaryConditionList = new List<MikeBoundaryCondition>();
                            mikeBoundaryConditionList = mikeBoundaryConditionService.GetMikeBoundaryConditionList().ToList();
                            CheckMikeBoundaryConditionFields(mikeBoundaryConditionList);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList[0].MikeBoundaryConditionID, mikeBoundaryConditionList[0].MikeBoundaryConditionID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<MikeBoundaryConditionExtraA> mikeBoundaryConditionExtraAList = new List<MikeBoundaryConditionExtraA>();
                            mikeBoundaryConditionExtraAList = mikeBoundaryConditionService.GetMikeBoundaryConditionExtraAList().ToList();
                            CheckMikeBoundaryConditionExtraAFields(mikeBoundaryConditionExtraAList);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList[0].MikeBoundaryConditionID, mikeBoundaryConditionExtraAList[0].MikeBoundaryConditionID);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList.Count, mikeBoundaryConditionExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<MikeBoundaryConditionExtraB> mikeBoundaryConditionExtraBList = new List<MikeBoundaryConditionExtraB>();
                            mikeBoundaryConditionExtraBList = mikeBoundaryConditionService.GetMikeBoundaryConditionExtraBList().ToList();
                            CheckMikeBoundaryConditionExtraBFields(mikeBoundaryConditionExtraBList);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList[0].MikeBoundaryConditionID, mikeBoundaryConditionExtraBList[0].MikeBoundaryConditionID);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList.Count, mikeBoundaryConditionExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeBoundaryConditionList() Skip Take

        #region Tests Generated for GetMikeBoundaryConditionList() Skip Take Order
        [TestMethod]
        public void GetMikeBoundaryConditionList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mikeBoundaryConditionService.Query = mikeBoundaryConditionService.FillQuery(typeof(MikeBoundaryCondition), culture.TwoLetterISOLanguageName, 1, 1,  "MikeBoundaryConditionID", "");

                        List<MikeBoundaryCondition> mikeBoundaryConditionDirectQueryList = new List<MikeBoundaryCondition>();
                        mikeBoundaryConditionDirectQueryList = (from c in dbTestDB.MikeBoundaryConditions select c).Skip(1).Take(1).OrderBy(c => c.MikeBoundaryConditionID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MikeBoundaryCondition> mikeBoundaryConditionList = new List<MikeBoundaryCondition>();
                            mikeBoundaryConditionList = mikeBoundaryConditionService.GetMikeBoundaryConditionList().ToList();
                            CheckMikeBoundaryConditionFields(mikeBoundaryConditionList);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList[0].MikeBoundaryConditionID, mikeBoundaryConditionList[0].MikeBoundaryConditionID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<MikeBoundaryConditionExtraA> mikeBoundaryConditionExtraAList = new List<MikeBoundaryConditionExtraA>();
                            mikeBoundaryConditionExtraAList = mikeBoundaryConditionService.GetMikeBoundaryConditionExtraAList().ToList();
                            CheckMikeBoundaryConditionExtraAFields(mikeBoundaryConditionExtraAList);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList[0].MikeBoundaryConditionID, mikeBoundaryConditionExtraAList[0].MikeBoundaryConditionID);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList.Count, mikeBoundaryConditionExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<MikeBoundaryConditionExtraB> mikeBoundaryConditionExtraBList = new List<MikeBoundaryConditionExtraB>();
                            mikeBoundaryConditionExtraBList = mikeBoundaryConditionService.GetMikeBoundaryConditionExtraBList().ToList();
                            CheckMikeBoundaryConditionExtraBFields(mikeBoundaryConditionExtraBList);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList[0].MikeBoundaryConditionID, mikeBoundaryConditionExtraBList[0].MikeBoundaryConditionID);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList.Count, mikeBoundaryConditionExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeBoundaryConditionList() Skip Take Order

        #region Tests Generated for GetMikeBoundaryConditionList() Skip Take 2Order
        [TestMethod]
        public void GetMikeBoundaryConditionList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mikeBoundaryConditionService.Query = mikeBoundaryConditionService.FillQuery(typeof(MikeBoundaryCondition), culture.TwoLetterISOLanguageName, 1, 1, "MikeBoundaryConditionID,MikeBoundaryConditionTVItemID", "");

                        List<MikeBoundaryCondition> mikeBoundaryConditionDirectQueryList = new List<MikeBoundaryCondition>();
                        mikeBoundaryConditionDirectQueryList = (from c in dbTestDB.MikeBoundaryConditions select c).Skip(1).Take(1).OrderBy(c => c.MikeBoundaryConditionID).ThenBy(c => c.MikeBoundaryConditionTVItemID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MikeBoundaryCondition> mikeBoundaryConditionList = new List<MikeBoundaryCondition>();
                            mikeBoundaryConditionList = mikeBoundaryConditionService.GetMikeBoundaryConditionList().ToList();
                            CheckMikeBoundaryConditionFields(mikeBoundaryConditionList);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList[0].MikeBoundaryConditionID, mikeBoundaryConditionList[0].MikeBoundaryConditionID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<MikeBoundaryConditionExtraA> mikeBoundaryConditionExtraAList = new List<MikeBoundaryConditionExtraA>();
                            mikeBoundaryConditionExtraAList = mikeBoundaryConditionService.GetMikeBoundaryConditionExtraAList().ToList();
                            CheckMikeBoundaryConditionExtraAFields(mikeBoundaryConditionExtraAList);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList[0].MikeBoundaryConditionID, mikeBoundaryConditionExtraAList[0].MikeBoundaryConditionID);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList.Count, mikeBoundaryConditionExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<MikeBoundaryConditionExtraB> mikeBoundaryConditionExtraBList = new List<MikeBoundaryConditionExtraB>();
                            mikeBoundaryConditionExtraBList = mikeBoundaryConditionService.GetMikeBoundaryConditionExtraBList().ToList();
                            CheckMikeBoundaryConditionExtraBFields(mikeBoundaryConditionExtraBList);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList[0].MikeBoundaryConditionID, mikeBoundaryConditionExtraBList[0].MikeBoundaryConditionID);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList.Count, mikeBoundaryConditionExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeBoundaryConditionList() Skip Take 2Order

        #region Tests Generated for GetMikeBoundaryConditionList() Skip Take Order Where
        [TestMethod]
        public void GetMikeBoundaryConditionList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mikeBoundaryConditionService.Query = mikeBoundaryConditionService.FillQuery(typeof(MikeBoundaryCondition), culture.TwoLetterISOLanguageName, 0, 1, "MikeBoundaryConditionID", "MikeBoundaryConditionID,EQ,4", "");

                        List<MikeBoundaryCondition> mikeBoundaryConditionDirectQueryList = new List<MikeBoundaryCondition>();
                        mikeBoundaryConditionDirectQueryList = (from c in dbTestDB.MikeBoundaryConditions select c).Where(c => c.MikeBoundaryConditionID == 4).Skip(0).Take(1).OrderBy(c => c.MikeBoundaryConditionID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MikeBoundaryCondition> mikeBoundaryConditionList = new List<MikeBoundaryCondition>();
                            mikeBoundaryConditionList = mikeBoundaryConditionService.GetMikeBoundaryConditionList().ToList();
                            CheckMikeBoundaryConditionFields(mikeBoundaryConditionList);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList[0].MikeBoundaryConditionID, mikeBoundaryConditionList[0].MikeBoundaryConditionID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<MikeBoundaryConditionExtraA> mikeBoundaryConditionExtraAList = new List<MikeBoundaryConditionExtraA>();
                            mikeBoundaryConditionExtraAList = mikeBoundaryConditionService.GetMikeBoundaryConditionExtraAList().ToList();
                            CheckMikeBoundaryConditionExtraAFields(mikeBoundaryConditionExtraAList);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList[0].MikeBoundaryConditionID, mikeBoundaryConditionExtraAList[0].MikeBoundaryConditionID);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList.Count, mikeBoundaryConditionExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<MikeBoundaryConditionExtraB> mikeBoundaryConditionExtraBList = new List<MikeBoundaryConditionExtraB>();
                            mikeBoundaryConditionExtraBList = mikeBoundaryConditionService.GetMikeBoundaryConditionExtraBList().ToList();
                            CheckMikeBoundaryConditionExtraBFields(mikeBoundaryConditionExtraBList);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList[0].MikeBoundaryConditionID, mikeBoundaryConditionExtraBList[0].MikeBoundaryConditionID);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList.Count, mikeBoundaryConditionExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeBoundaryConditionList() Skip Take Order Where

        #region Tests Generated for GetMikeBoundaryConditionList() Skip Take Order 2Where
        [TestMethod]
        public void GetMikeBoundaryConditionList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mikeBoundaryConditionService.Query = mikeBoundaryConditionService.FillQuery(typeof(MikeBoundaryCondition), culture.TwoLetterISOLanguageName, 0, 1, "MikeBoundaryConditionID", "MikeBoundaryConditionID,GT,2|MikeBoundaryConditionID,LT,5", "");

                        List<MikeBoundaryCondition> mikeBoundaryConditionDirectQueryList = new List<MikeBoundaryCondition>();
                        mikeBoundaryConditionDirectQueryList = (from c in dbTestDB.MikeBoundaryConditions select c).Where(c => c.MikeBoundaryConditionID > 2 && c.MikeBoundaryConditionID < 5).Skip(0).Take(1).OrderBy(c => c.MikeBoundaryConditionID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MikeBoundaryCondition> mikeBoundaryConditionList = new List<MikeBoundaryCondition>();
                            mikeBoundaryConditionList = mikeBoundaryConditionService.GetMikeBoundaryConditionList().ToList();
                            CheckMikeBoundaryConditionFields(mikeBoundaryConditionList);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList[0].MikeBoundaryConditionID, mikeBoundaryConditionList[0].MikeBoundaryConditionID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<MikeBoundaryConditionExtraA> mikeBoundaryConditionExtraAList = new List<MikeBoundaryConditionExtraA>();
                            mikeBoundaryConditionExtraAList = mikeBoundaryConditionService.GetMikeBoundaryConditionExtraAList().ToList();
                            CheckMikeBoundaryConditionExtraAFields(mikeBoundaryConditionExtraAList);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList[0].MikeBoundaryConditionID, mikeBoundaryConditionExtraAList[0].MikeBoundaryConditionID);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList.Count, mikeBoundaryConditionExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<MikeBoundaryConditionExtraB> mikeBoundaryConditionExtraBList = new List<MikeBoundaryConditionExtraB>();
                            mikeBoundaryConditionExtraBList = mikeBoundaryConditionService.GetMikeBoundaryConditionExtraBList().ToList();
                            CheckMikeBoundaryConditionExtraBFields(mikeBoundaryConditionExtraBList);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList[0].MikeBoundaryConditionID, mikeBoundaryConditionExtraBList[0].MikeBoundaryConditionID);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList.Count, mikeBoundaryConditionExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeBoundaryConditionList() Skip Take Order 2Where

        #region Tests Generated for GetMikeBoundaryConditionList() 2Where
        [TestMethod]
        public void GetMikeBoundaryConditionList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mikeBoundaryConditionService.Query = mikeBoundaryConditionService.FillQuery(typeof(MikeBoundaryCondition), culture.TwoLetterISOLanguageName, 0, 10000, "", "MikeBoundaryConditionID,GT,2|MikeBoundaryConditionID,LT,5", "");

                        List<MikeBoundaryCondition> mikeBoundaryConditionDirectQueryList = new List<MikeBoundaryCondition>();
                        mikeBoundaryConditionDirectQueryList = (from c in dbTestDB.MikeBoundaryConditions select c).Where(c => c.MikeBoundaryConditionID > 2 && c.MikeBoundaryConditionID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MikeBoundaryCondition> mikeBoundaryConditionList = new List<MikeBoundaryCondition>();
                            mikeBoundaryConditionList = mikeBoundaryConditionService.GetMikeBoundaryConditionList().ToList();
                            CheckMikeBoundaryConditionFields(mikeBoundaryConditionList);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList[0].MikeBoundaryConditionID, mikeBoundaryConditionList[0].MikeBoundaryConditionID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<MikeBoundaryConditionExtraA> mikeBoundaryConditionExtraAList = new List<MikeBoundaryConditionExtraA>();
                            mikeBoundaryConditionExtraAList = mikeBoundaryConditionService.GetMikeBoundaryConditionExtraAList().ToList();
                            CheckMikeBoundaryConditionExtraAFields(mikeBoundaryConditionExtraAList);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList[0].MikeBoundaryConditionID, mikeBoundaryConditionExtraAList[0].MikeBoundaryConditionID);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList.Count, mikeBoundaryConditionExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<MikeBoundaryConditionExtraB> mikeBoundaryConditionExtraBList = new List<MikeBoundaryConditionExtraB>();
                            mikeBoundaryConditionExtraBList = mikeBoundaryConditionService.GetMikeBoundaryConditionExtraBList().ToList();
                            CheckMikeBoundaryConditionExtraBFields(mikeBoundaryConditionExtraBList);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList[0].MikeBoundaryConditionID, mikeBoundaryConditionExtraBList[0].MikeBoundaryConditionID);
                            Assert.AreEqual(mikeBoundaryConditionDirectQueryList.Count, mikeBoundaryConditionExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeBoundaryConditionList() 2Where

        #region Functions private
        private void CheckMikeBoundaryConditionFields(List<MikeBoundaryCondition> mikeBoundaryConditionList)
        {
            Assert.IsNotNull(mikeBoundaryConditionList[0].MikeBoundaryConditionID);
            Assert.IsNotNull(mikeBoundaryConditionList[0].MikeBoundaryConditionTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionList[0].MikeBoundaryConditionCode));
            Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionList[0].MikeBoundaryConditionName));
            Assert.IsNotNull(mikeBoundaryConditionList[0].MikeBoundaryConditionLength_m);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionList[0].MikeBoundaryConditionFormat));
            Assert.IsNotNull(mikeBoundaryConditionList[0].MikeBoundaryConditionLevelOrVelocity);
            Assert.IsNotNull(mikeBoundaryConditionList[0].WebTideDataSet);
            Assert.IsNotNull(mikeBoundaryConditionList[0].NumberOfWebTideNodes);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionList[0].WebTideDataFromStartToEndDate));
            Assert.IsNotNull(mikeBoundaryConditionList[0].TVType);
            Assert.IsNotNull(mikeBoundaryConditionList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mikeBoundaryConditionList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mikeBoundaryConditionList[0].HasErrors);
        }
        private void CheckMikeBoundaryConditionExtraAFields(List<MikeBoundaryConditionExtraA> mikeBoundaryConditionExtraAList)
        {
            Assert.IsNotNull(mikeBoundaryConditionExtraAList[0].MikeBoundaryConditionTVItemLanguage);
            Assert.IsNotNull(mikeBoundaryConditionExtraAList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(mikeBoundaryConditionExtraAList[0].MikeBoundaryConditionLevelOrVelocityText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionExtraAList[0].MikeBoundaryConditionLevelOrVelocityText));
            }
            if (!string.IsNullOrWhiteSpace(mikeBoundaryConditionExtraAList[0].WebTideDataSetText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionExtraAList[0].WebTideDataSetText));
            }
            if (!string.IsNullOrWhiteSpace(mikeBoundaryConditionExtraAList[0].TVTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionExtraAList[0].TVTypeText));
            }
            Assert.IsNotNull(mikeBoundaryConditionExtraAList[0].MikeBoundaryConditionID);
            Assert.IsNotNull(mikeBoundaryConditionExtraAList[0].MikeBoundaryConditionTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionExtraAList[0].MikeBoundaryConditionCode));
            Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionExtraAList[0].MikeBoundaryConditionName));
            Assert.IsNotNull(mikeBoundaryConditionExtraAList[0].MikeBoundaryConditionLength_m);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionExtraAList[0].MikeBoundaryConditionFormat));
            Assert.IsNotNull(mikeBoundaryConditionExtraAList[0].MikeBoundaryConditionLevelOrVelocity);
            Assert.IsNotNull(mikeBoundaryConditionExtraAList[0].WebTideDataSet);
            Assert.IsNotNull(mikeBoundaryConditionExtraAList[0].NumberOfWebTideNodes);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionExtraAList[0].WebTideDataFromStartToEndDate));
            Assert.IsNotNull(mikeBoundaryConditionExtraAList[0].TVType);
            Assert.IsNotNull(mikeBoundaryConditionExtraAList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mikeBoundaryConditionExtraAList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mikeBoundaryConditionExtraAList[0].HasErrors);
        }
        private void CheckMikeBoundaryConditionExtraBFields(List<MikeBoundaryConditionExtraB> mikeBoundaryConditionExtraBList)
        {
            if (!string.IsNullOrWhiteSpace(mikeBoundaryConditionExtraBList[0].MikeBoundaryConditionReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionExtraBList[0].MikeBoundaryConditionReportTest));
            }
            Assert.IsNotNull(mikeBoundaryConditionExtraBList[0].MikeBoundaryConditionTVItemLanguage);
            Assert.IsNotNull(mikeBoundaryConditionExtraBList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(mikeBoundaryConditionExtraBList[0].MikeBoundaryConditionLevelOrVelocityText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionExtraBList[0].MikeBoundaryConditionLevelOrVelocityText));
            }
            if (!string.IsNullOrWhiteSpace(mikeBoundaryConditionExtraBList[0].WebTideDataSetText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionExtraBList[0].WebTideDataSetText));
            }
            if (!string.IsNullOrWhiteSpace(mikeBoundaryConditionExtraBList[0].TVTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionExtraBList[0].TVTypeText));
            }
            Assert.IsNotNull(mikeBoundaryConditionExtraBList[0].MikeBoundaryConditionID);
            Assert.IsNotNull(mikeBoundaryConditionExtraBList[0].MikeBoundaryConditionTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionExtraBList[0].MikeBoundaryConditionCode));
            Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionExtraBList[0].MikeBoundaryConditionName));
            Assert.IsNotNull(mikeBoundaryConditionExtraBList[0].MikeBoundaryConditionLength_m);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionExtraBList[0].MikeBoundaryConditionFormat));
            Assert.IsNotNull(mikeBoundaryConditionExtraBList[0].MikeBoundaryConditionLevelOrVelocity);
            Assert.IsNotNull(mikeBoundaryConditionExtraBList[0].WebTideDataSet);
            Assert.IsNotNull(mikeBoundaryConditionExtraBList[0].NumberOfWebTideNodes);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mikeBoundaryConditionExtraBList[0].WebTideDataFromStartToEndDate));
            Assert.IsNotNull(mikeBoundaryConditionExtraBList[0].TVType);
            Assert.IsNotNull(mikeBoundaryConditionExtraBList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mikeBoundaryConditionExtraBList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mikeBoundaryConditionExtraBList[0].HasErrors);
        }
        private MikeBoundaryCondition GetFilledRandomMikeBoundaryCondition(string OmitPropName)
        {
            MikeBoundaryCondition mikeBoundaryCondition = new MikeBoundaryCondition();

            if (OmitPropName != "MikeBoundaryConditionTVItemID") mikeBoundaryCondition.MikeBoundaryConditionTVItemID = 51;
            if (OmitPropName != "MikeBoundaryConditionCode") mikeBoundaryCondition.MikeBoundaryConditionCode = GetRandomString("", 5);
            if (OmitPropName != "MikeBoundaryConditionName") mikeBoundaryCondition.MikeBoundaryConditionName = GetRandomString("", 5);
            if (OmitPropName != "MikeBoundaryConditionLength_m") mikeBoundaryCondition.MikeBoundaryConditionLength_m = GetRandomDouble(1.0D, 100000.0D);
            if (OmitPropName != "MikeBoundaryConditionFormat") mikeBoundaryCondition.MikeBoundaryConditionFormat = GetRandomString("", 5);
            if (OmitPropName != "MikeBoundaryConditionLevelOrVelocity") mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocity = (MikeBoundaryConditionLevelOrVelocityEnum)GetRandomEnumType(typeof(MikeBoundaryConditionLevelOrVelocityEnum));
            if (OmitPropName != "WebTideDataSet") mikeBoundaryCondition.WebTideDataSet = (WebTideDataSetEnum)GetRandomEnumType(typeof(WebTideDataSetEnum));
            if (OmitPropName != "NumberOfWebTideNodes") mikeBoundaryCondition.NumberOfWebTideNodes = GetRandomInt(0, 1000);
            if (OmitPropName != "WebTideDataFromStartToEndDate") mikeBoundaryCondition.WebTideDataFromStartToEndDate = GetRandomString("", 20);
            if (OmitPropName != "TVType") mikeBoundaryCondition.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "LastUpdateDate_UTC") mikeBoundaryCondition.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mikeBoundaryCondition.LastUpdateContactTVItemID = 2;

            return mikeBoundaryCondition;
        }
        #endregion Functions private
    }
}
