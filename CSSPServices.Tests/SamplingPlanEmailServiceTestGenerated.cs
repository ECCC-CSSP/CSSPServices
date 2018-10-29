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
    public partial class SamplingPlanEmailServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private SamplingPlanEmailService samplingPlanEmailService { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanEmailServiceTest() : base()
        {
            //samplingPlanEmailService = new SamplingPlanEmailService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void SamplingPlanEmail_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    SamplingPlanEmail samplingPlanEmail = GetFilledRandomSamplingPlanEmail("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = samplingPlanEmailService.GetSamplingPlanEmailList().Count();

                    Assert.AreEqual(count, (from c in dbTestDB.SamplingPlanEmails select c).Count());

                    samplingPlanEmailService.Add(samplingPlanEmail);
                    if (samplingPlanEmail.HasErrors)
                    {
                        Assert.AreEqual("", samplingPlanEmail.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, samplingPlanEmailService.GetSamplingPlanEmailList().Where(c => c == samplingPlanEmail).Any());
                    samplingPlanEmailService.Update(samplingPlanEmail);
                    if (samplingPlanEmail.HasErrors)
                    {
                        Assert.AreEqual("", samplingPlanEmail.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, samplingPlanEmailService.GetSamplingPlanEmailList().Count());
                    samplingPlanEmailService.Delete(samplingPlanEmail);
                    if (samplingPlanEmail.HasErrors)
                    {
                        Assert.AreEqual("", samplingPlanEmail.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, samplingPlanEmailService.GetSamplingPlanEmailList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // samplingPlanEmail.SamplingPlanEmailID   (Int32)
                    // -----------------------------------

                    samplingPlanEmail = null;
                    samplingPlanEmail = GetFilledRandomSamplingPlanEmail("");
                    samplingPlanEmail.SamplingPlanEmailID = 0;
                    samplingPlanEmailService.Update(samplingPlanEmail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanEmailSamplingPlanEmailID"), samplingPlanEmail.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlanEmail = null;
                    samplingPlanEmail = GetFilledRandomSamplingPlanEmail("");
                    samplingPlanEmail.SamplingPlanEmailID = 10000000;
                    samplingPlanEmailService.Update(samplingPlanEmail);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "SamplingPlanEmail", "SamplingPlanEmailSamplingPlanEmailID", samplingPlanEmail.SamplingPlanEmailID.ToString()), samplingPlanEmail.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "SamplingPlan", ExistPlurial = "s", ExistFieldID = "SamplingPlanID", AllowableTVtypeList = )]
                    // samplingPlanEmail.SamplingPlanID   (Int32)
                    // -----------------------------------

                    samplingPlanEmail = null;
                    samplingPlanEmail = GetFilledRandomSamplingPlanEmail("");
                    samplingPlanEmail.SamplingPlanID = 0;
                    samplingPlanEmailService.Add(samplingPlanEmail);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "SamplingPlan", "SamplingPlanEmailSamplingPlanID", samplingPlanEmail.SamplingPlanID.ToString()), samplingPlanEmail.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [DataType(DataType.EmailAddress)]
                    // [StringLength(150))]
                    // samplingPlanEmail.Email   (String)
                    // -----------------------------------

                    samplingPlanEmail = null;
                    samplingPlanEmail = GetFilledRandomSamplingPlanEmail("Email");
                    Assert.AreEqual(false, samplingPlanEmailService.Add(samplingPlanEmail));
                    Assert.AreEqual(1, samplingPlanEmail.ValidationResults.Count());
                    Assert.IsTrue(samplingPlanEmail.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "SamplingPlanEmailEmail")).Any());
                    Assert.AreEqual(null, samplingPlanEmail.Email);
                    Assert.AreEqual(count, samplingPlanEmailService.GetSamplingPlanEmailList().Count());

                    samplingPlanEmail = null;
                    samplingPlanEmail = GetFilledRandomSamplingPlanEmail("");
                    samplingPlanEmail.Email = GetRandomString("", 151);
                    Assert.AreEqual(false, samplingPlanEmailService.Add(samplingPlanEmail));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "SamplingPlanEmailEmail", "150"), samplingPlanEmail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, samplingPlanEmailService.GetSamplingPlanEmailList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // samplingPlanEmail.IsContractor   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // samplingPlanEmail.LabSheetHasValueOver500   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // samplingPlanEmail.LabSheetReceived   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // samplingPlanEmail.LabSheetAccepted   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // samplingPlanEmail.LabSheetRejected   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // samplingPlanEmail.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    samplingPlanEmail = null;
                    samplingPlanEmail = GetFilledRandomSamplingPlanEmail("");
                    samplingPlanEmail.LastUpdateDate_UTC = new DateTime();
                    samplingPlanEmailService.Add(samplingPlanEmail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanEmailLastUpdateDate_UTC"), samplingPlanEmail.ValidationResults.FirstOrDefault().ErrorMessage);
                    samplingPlanEmail = null;
                    samplingPlanEmail = GetFilledRandomSamplingPlanEmail("");
                    samplingPlanEmail.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    samplingPlanEmailService.Add(samplingPlanEmail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "SamplingPlanEmailLastUpdateDate_UTC", "1980"), samplingPlanEmail.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // samplingPlanEmail.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    samplingPlanEmail = null;
                    samplingPlanEmail = GetFilledRandomSamplingPlanEmail("");
                    samplingPlanEmail.LastUpdateContactTVItemID = 0;
                    samplingPlanEmailService.Add(samplingPlanEmail);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SamplingPlanEmailLastUpdateContactTVItemID", samplingPlanEmail.LastUpdateContactTVItemID.ToString()), samplingPlanEmail.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlanEmail = null;
                    samplingPlanEmail = GetFilledRandomSamplingPlanEmail("");
                    samplingPlanEmail.LastUpdateContactTVItemID = 1;
                    samplingPlanEmailService.Add(samplingPlanEmail);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "SamplingPlanEmailLastUpdateContactTVItemID", "Contact"), samplingPlanEmail.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // samplingPlanEmail.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // samplingPlanEmail.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetSamplingPlanEmailWithSamplingPlanEmailID(samplingPlanEmail.SamplingPlanEmailID)
        [TestMethod]
        public void GetSamplingPlanEmailWithSamplingPlanEmailID__samplingPlanEmail_SamplingPlanEmailID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    SamplingPlanEmail samplingPlanEmail = (from c in dbTestDB.SamplingPlanEmails select c).FirstOrDefault();
                    Assert.IsNotNull(samplingPlanEmail);

                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        samplingPlanEmailService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            SamplingPlanEmail samplingPlanEmailRet = samplingPlanEmailService.GetSamplingPlanEmailWithSamplingPlanEmailID(samplingPlanEmail.SamplingPlanEmailID);
                            CheckSamplingPlanEmailFields(new List<SamplingPlanEmail>() { samplingPlanEmailRet });
                            Assert.AreEqual(samplingPlanEmail.SamplingPlanEmailID, samplingPlanEmailRet.SamplingPlanEmailID);
                        }
                        else if (extra == "ExtraA")
                        {
                            SamplingPlanEmailExtraA samplingPlanEmailExtraARet = samplingPlanEmailService.GetSamplingPlanEmailExtraAWithSamplingPlanEmailID(samplingPlanEmail.SamplingPlanEmailID);
                            CheckSamplingPlanEmailExtraAFields(new List<SamplingPlanEmailExtraA>() { samplingPlanEmailExtraARet });
                            Assert.AreEqual(samplingPlanEmail.SamplingPlanEmailID, samplingPlanEmailExtraARet.SamplingPlanEmailID);
                        }
                        else if (extra == "ExtraB")
                        {
                            SamplingPlanEmailExtraB samplingPlanEmailExtraBRet = samplingPlanEmailService.GetSamplingPlanEmailExtraBWithSamplingPlanEmailID(samplingPlanEmail.SamplingPlanEmailID);
                            CheckSamplingPlanEmailExtraBFields(new List<SamplingPlanEmailExtraB>() { samplingPlanEmailExtraBRet });
                            Assert.AreEqual(samplingPlanEmail.SamplingPlanEmailID, samplingPlanEmailExtraBRet.SamplingPlanEmailID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanEmailWithSamplingPlanEmailID(samplingPlanEmail.SamplingPlanEmailID)

        #region Tests Generated for GetSamplingPlanEmailList()
        [TestMethod]
        public void GetSamplingPlanEmailList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    SamplingPlanEmail samplingPlanEmail = (from c in dbTestDB.SamplingPlanEmails select c).FirstOrDefault();
                    Assert.IsNotNull(samplingPlanEmail);

                    List<SamplingPlanEmail> samplingPlanEmailDirectQueryList = new List<SamplingPlanEmail>();
                    samplingPlanEmailDirectQueryList = (from c in dbTestDB.SamplingPlanEmails select c).Take(200).ToList();

                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        samplingPlanEmailService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<SamplingPlanEmail> samplingPlanEmailList = new List<SamplingPlanEmail>();
                            samplingPlanEmailList = samplingPlanEmailService.GetSamplingPlanEmailList().ToList();
                            CheckSamplingPlanEmailFields(samplingPlanEmailList);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<SamplingPlanEmailExtraA> samplingPlanEmailExtraAList = new List<SamplingPlanEmailExtraA>();
                            samplingPlanEmailExtraAList = samplingPlanEmailService.GetSamplingPlanEmailExtraAList().ToList();
                            CheckSamplingPlanEmailExtraAFields(samplingPlanEmailExtraAList);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList.Count, samplingPlanEmailExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<SamplingPlanEmailExtraB> samplingPlanEmailExtraBList = new List<SamplingPlanEmailExtraB>();
                            samplingPlanEmailExtraBList = samplingPlanEmailService.GetSamplingPlanEmailExtraBList().ToList();
                            CheckSamplingPlanEmailExtraBFields(samplingPlanEmailExtraBList);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList.Count, samplingPlanEmailExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanEmailList()

        #region Tests Generated for GetSamplingPlanEmailList() Skip Take
        [TestMethod]
        public void GetSamplingPlanEmailList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanEmailService.Query = samplingPlanEmailService.FillQuery(typeof(SamplingPlanEmail), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<SamplingPlanEmail> samplingPlanEmailDirectQueryList = new List<SamplingPlanEmail>();
                        samplingPlanEmailDirectQueryList = (from c in dbTestDB.SamplingPlanEmails select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<SamplingPlanEmail> samplingPlanEmailList = new List<SamplingPlanEmail>();
                            samplingPlanEmailList = samplingPlanEmailService.GetSamplingPlanEmailList().ToList();
                            CheckSamplingPlanEmailFields(samplingPlanEmailList);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList[0].SamplingPlanEmailID, samplingPlanEmailList[0].SamplingPlanEmailID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<SamplingPlanEmailExtraA> samplingPlanEmailExtraAList = new List<SamplingPlanEmailExtraA>();
                            samplingPlanEmailExtraAList = samplingPlanEmailService.GetSamplingPlanEmailExtraAList().ToList();
                            CheckSamplingPlanEmailExtraAFields(samplingPlanEmailExtraAList);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList[0].SamplingPlanEmailID, samplingPlanEmailExtraAList[0].SamplingPlanEmailID);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList.Count, samplingPlanEmailExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<SamplingPlanEmailExtraB> samplingPlanEmailExtraBList = new List<SamplingPlanEmailExtraB>();
                            samplingPlanEmailExtraBList = samplingPlanEmailService.GetSamplingPlanEmailExtraBList().ToList();
                            CheckSamplingPlanEmailExtraBFields(samplingPlanEmailExtraBList);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList[0].SamplingPlanEmailID, samplingPlanEmailExtraBList[0].SamplingPlanEmailID);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList.Count, samplingPlanEmailExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanEmailList() Skip Take

        #region Tests Generated for GetSamplingPlanEmailList() Skip Take Order
        [TestMethod]
        public void GetSamplingPlanEmailList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanEmailService.Query = samplingPlanEmailService.FillQuery(typeof(SamplingPlanEmail), culture.TwoLetterISOLanguageName, 1, 1,  "SamplingPlanEmailID", "");

                        List<SamplingPlanEmail> samplingPlanEmailDirectQueryList = new List<SamplingPlanEmail>();
                        samplingPlanEmailDirectQueryList = (from c in dbTestDB.SamplingPlanEmails select c).Skip(1).Take(1).OrderBy(c => c.SamplingPlanEmailID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<SamplingPlanEmail> samplingPlanEmailList = new List<SamplingPlanEmail>();
                            samplingPlanEmailList = samplingPlanEmailService.GetSamplingPlanEmailList().ToList();
                            CheckSamplingPlanEmailFields(samplingPlanEmailList);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList[0].SamplingPlanEmailID, samplingPlanEmailList[0].SamplingPlanEmailID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<SamplingPlanEmailExtraA> samplingPlanEmailExtraAList = new List<SamplingPlanEmailExtraA>();
                            samplingPlanEmailExtraAList = samplingPlanEmailService.GetSamplingPlanEmailExtraAList().ToList();
                            CheckSamplingPlanEmailExtraAFields(samplingPlanEmailExtraAList);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList[0].SamplingPlanEmailID, samplingPlanEmailExtraAList[0].SamplingPlanEmailID);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList.Count, samplingPlanEmailExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<SamplingPlanEmailExtraB> samplingPlanEmailExtraBList = new List<SamplingPlanEmailExtraB>();
                            samplingPlanEmailExtraBList = samplingPlanEmailService.GetSamplingPlanEmailExtraBList().ToList();
                            CheckSamplingPlanEmailExtraBFields(samplingPlanEmailExtraBList);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList[0].SamplingPlanEmailID, samplingPlanEmailExtraBList[0].SamplingPlanEmailID);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList.Count, samplingPlanEmailExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanEmailList() Skip Take Order

        #region Tests Generated for GetSamplingPlanEmailList() Skip Take 2Order
        [TestMethod]
        public void GetSamplingPlanEmailList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanEmailService.Query = samplingPlanEmailService.FillQuery(typeof(SamplingPlanEmail), culture.TwoLetterISOLanguageName, 1, 1, "SamplingPlanEmailID,SamplingPlanID", "");

                        List<SamplingPlanEmail> samplingPlanEmailDirectQueryList = new List<SamplingPlanEmail>();
                        samplingPlanEmailDirectQueryList = (from c in dbTestDB.SamplingPlanEmails select c).Skip(1).Take(1).OrderBy(c => c.SamplingPlanEmailID).ThenBy(c => c.SamplingPlanID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<SamplingPlanEmail> samplingPlanEmailList = new List<SamplingPlanEmail>();
                            samplingPlanEmailList = samplingPlanEmailService.GetSamplingPlanEmailList().ToList();
                            CheckSamplingPlanEmailFields(samplingPlanEmailList);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList[0].SamplingPlanEmailID, samplingPlanEmailList[0].SamplingPlanEmailID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<SamplingPlanEmailExtraA> samplingPlanEmailExtraAList = new List<SamplingPlanEmailExtraA>();
                            samplingPlanEmailExtraAList = samplingPlanEmailService.GetSamplingPlanEmailExtraAList().ToList();
                            CheckSamplingPlanEmailExtraAFields(samplingPlanEmailExtraAList);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList[0].SamplingPlanEmailID, samplingPlanEmailExtraAList[0].SamplingPlanEmailID);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList.Count, samplingPlanEmailExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<SamplingPlanEmailExtraB> samplingPlanEmailExtraBList = new List<SamplingPlanEmailExtraB>();
                            samplingPlanEmailExtraBList = samplingPlanEmailService.GetSamplingPlanEmailExtraBList().ToList();
                            CheckSamplingPlanEmailExtraBFields(samplingPlanEmailExtraBList);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList[0].SamplingPlanEmailID, samplingPlanEmailExtraBList[0].SamplingPlanEmailID);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList.Count, samplingPlanEmailExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanEmailList() Skip Take 2Order

        #region Tests Generated for GetSamplingPlanEmailList() Skip Take Order Where
        [TestMethod]
        public void GetSamplingPlanEmailList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanEmailService.Query = samplingPlanEmailService.FillQuery(typeof(SamplingPlanEmail), culture.TwoLetterISOLanguageName, 0, 1, "SamplingPlanEmailID", "SamplingPlanEmailID,EQ,4", "");

                        List<SamplingPlanEmail> samplingPlanEmailDirectQueryList = new List<SamplingPlanEmail>();
                        samplingPlanEmailDirectQueryList = (from c in dbTestDB.SamplingPlanEmails select c).Where(c => c.SamplingPlanEmailID == 4).Skip(0).Take(1).OrderBy(c => c.SamplingPlanEmailID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<SamplingPlanEmail> samplingPlanEmailList = new List<SamplingPlanEmail>();
                            samplingPlanEmailList = samplingPlanEmailService.GetSamplingPlanEmailList().ToList();
                            CheckSamplingPlanEmailFields(samplingPlanEmailList);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList[0].SamplingPlanEmailID, samplingPlanEmailList[0].SamplingPlanEmailID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<SamplingPlanEmailExtraA> samplingPlanEmailExtraAList = new List<SamplingPlanEmailExtraA>();
                            samplingPlanEmailExtraAList = samplingPlanEmailService.GetSamplingPlanEmailExtraAList().ToList();
                            CheckSamplingPlanEmailExtraAFields(samplingPlanEmailExtraAList);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList[0].SamplingPlanEmailID, samplingPlanEmailExtraAList[0].SamplingPlanEmailID);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList.Count, samplingPlanEmailExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<SamplingPlanEmailExtraB> samplingPlanEmailExtraBList = new List<SamplingPlanEmailExtraB>();
                            samplingPlanEmailExtraBList = samplingPlanEmailService.GetSamplingPlanEmailExtraBList().ToList();
                            CheckSamplingPlanEmailExtraBFields(samplingPlanEmailExtraBList);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList[0].SamplingPlanEmailID, samplingPlanEmailExtraBList[0].SamplingPlanEmailID);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList.Count, samplingPlanEmailExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanEmailList() Skip Take Order Where

        #region Tests Generated for GetSamplingPlanEmailList() Skip Take Order 2Where
        [TestMethod]
        public void GetSamplingPlanEmailList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanEmailService.Query = samplingPlanEmailService.FillQuery(typeof(SamplingPlanEmail), culture.TwoLetterISOLanguageName, 0, 1, "SamplingPlanEmailID", "SamplingPlanEmailID,GT,2|SamplingPlanEmailID,LT,5", "");

                        List<SamplingPlanEmail> samplingPlanEmailDirectQueryList = new List<SamplingPlanEmail>();
                        samplingPlanEmailDirectQueryList = (from c in dbTestDB.SamplingPlanEmails select c).Where(c => c.SamplingPlanEmailID > 2 && c.SamplingPlanEmailID < 5).Skip(0).Take(1).OrderBy(c => c.SamplingPlanEmailID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<SamplingPlanEmail> samplingPlanEmailList = new List<SamplingPlanEmail>();
                            samplingPlanEmailList = samplingPlanEmailService.GetSamplingPlanEmailList().ToList();
                            CheckSamplingPlanEmailFields(samplingPlanEmailList);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList[0].SamplingPlanEmailID, samplingPlanEmailList[0].SamplingPlanEmailID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<SamplingPlanEmailExtraA> samplingPlanEmailExtraAList = new List<SamplingPlanEmailExtraA>();
                            samplingPlanEmailExtraAList = samplingPlanEmailService.GetSamplingPlanEmailExtraAList().ToList();
                            CheckSamplingPlanEmailExtraAFields(samplingPlanEmailExtraAList);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList[0].SamplingPlanEmailID, samplingPlanEmailExtraAList[0].SamplingPlanEmailID);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList.Count, samplingPlanEmailExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<SamplingPlanEmailExtraB> samplingPlanEmailExtraBList = new List<SamplingPlanEmailExtraB>();
                            samplingPlanEmailExtraBList = samplingPlanEmailService.GetSamplingPlanEmailExtraBList().ToList();
                            CheckSamplingPlanEmailExtraBFields(samplingPlanEmailExtraBList);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList[0].SamplingPlanEmailID, samplingPlanEmailExtraBList[0].SamplingPlanEmailID);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList.Count, samplingPlanEmailExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanEmailList() Skip Take Order 2Where

        #region Tests Generated for GetSamplingPlanEmailList() 2Where
        [TestMethod]
        public void GetSamplingPlanEmailList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        SamplingPlanEmailService samplingPlanEmailService = new SamplingPlanEmailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanEmailService.Query = samplingPlanEmailService.FillQuery(typeof(SamplingPlanEmail), culture.TwoLetterISOLanguageName, 0, 10000, "", "SamplingPlanEmailID,GT,2|SamplingPlanEmailID,LT,5", "");

                        List<SamplingPlanEmail> samplingPlanEmailDirectQueryList = new List<SamplingPlanEmail>();
                        samplingPlanEmailDirectQueryList = (from c in dbTestDB.SamplingPlanEmails select c).Where(c => c.SamplingPlanEmailID > 2 && c.SamplingPlanEmailID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<SamplingPlanEmail> samplingPlanEmailList = new List<SamplingPlanEmail>();
                            samplingPlanEmailList = samplingPlanEmailService.GetSamplingPlanEmailList().ToList();
                            CheckSamplingPlanEmailFields(samplingPlanEmailList);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList[0].SamplingPlanEmailID, samplingPlanEmailList[0].SamplingPlanEmailID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<SamplingPlanEmailExtraA> samplingPlanEmailExtraAList = new List<SamplingPlanEmailExtraA>();
                            samplingPlanEmailExtraAList = samplingPlanEmailService.GetSamplingPlanEmailExtraAList().ToList();
                            CheckSamplingPlanEmailExtraAFields(samplingPlanEmailExtraAList);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList[0].SamplingPlanEmailID, samplingPlanEmailExtraAList[0].SamplingPlanEmailID);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList.Count, samplingPlanEmailExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<SamplingPlanEmailExtraB> samplingPlanEmailExtraBList = new List<SamplingPlanEmailExtraB>();
                            samplingPlanEmailExtraBList = samplingPlanEmailService.GetSamplingPlanEmailExtraBList().ToList();
                            CheckSamplingPlanEmailExtraBFields(samplingPlanEmailExtraBList);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList[0].SamplingPlanEmailID, samplingPlanEmailExtraBList[0].SamplingPlanEmailID);
                            Assert.AreEqual(samplingPlanEmailDirectQueryList.Count, samplingPlanEmailExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanEmailList() 2Where

        #region Functions private
        private void CheckSamplingPlanEmailFields(List<SamplingPlanEmail> samplingPlanEmailList)
        {
            Assert.IsNotNull(samplingPlanEmailList[0].SamplingPlanEmailID);
            Assert.IsNotNull(samplingPlanEmailList[0].SamplingPlanID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanEmailList[0].Email));
            Assert.IsNotNull(samplingPlanEmailList[0].IsContractor);
            Assert.IsNotNull(samplingPlanEmailList[0].LabSheetHasValueOver500);
            Assert.IsNotNull(samplingPlanEmailList[0].LabSheetReceived);
            Assert.IsNotNull(samplingPlanEmailList[0].LabSheetAccepted);
            Assert.IsNotNull(samplingPlanEmailList[0].LabSheetRejected);
            Assert.IsNotNull(samplingPlanEmailList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(samplingPlanEmailList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(samplingPlanEmailList[0].HasErrors);
        }
        private void CheckSamplingPlanEmailExtraAFields(List<SamplingPlanEmailExtraA> samplingPlanEmailExtraAList)
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanEmailExtraAList[0].LastUpdateContactText));
            Assert.IsNotNull(samplingPlanEmailExtraAList[0].SamplingPlanEmailID);
            Assert.IsNotNull(samplingPlanEmailExtraAList[0].SamplingPlanID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanEmailExtraAList[0].Email));
            Assert.IsNotNull(samplingPlanEmailExtraAList[0].IsContractor);
            Assert.IsNotNull(samplingPlanEmailExtraAList[0].LabSheetHasValueOver500);
            Assert.IsNotNull(samplingPlanEmailExtraAList[0].LabSheetReceived);
            Assert.IsNotNull(samplingPlanEmailExtraAList[0].LabSheetAccepted);
            Assert.IsNotNull(samplingPlanEmailExtraAList[0].LabSheetRejected);
            Assert.IsNotNull(samplingPlanEmailExtraAList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(samplingPlanEmailExtraAList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(samplingPlanEmailExtraAList[0].HasErrors);
        }
        private void CheckSamplingPlanEmailExtraBFields(List<SamplingPlanEmailExtraB> samplingPlanEmailExtraBList)
        {
            if (!string.IsNullOrWhiteSpace(samplingPlanEmailExtraBList[0].SamplingPlanEmailReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanEmailExtraBList[0].SamplingPlanEmailReportTest));
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanEmailExtraBList[0].LastUpdateContactText));
            Assert.IsNotNull(samplingPlanEmailExtraBList[0].SamplingPlanEmailID);
            Assert.IsNotNull(samplingPlanEmailExtraBList[0].SamplingPlanID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanEmailExtraBList[0].Email));
            Assert.IsNotNull(samplingPlanEmailExtraBList[0].IsContractor);
            Assert.IsNotNull(samplingPlanEmailExtraBList[0].LabSheetHasValueOver500);
            Assert.IsNotNull(samplingPlanEmailExtraBList[0].LabSheetReceived);
            Assert.IsNotNull(samplingPlanEmailExtraBList[0].LabSheetAccepted);
            Assert.IsNotNull(samplingPlanEmailExtraBList[0].LabSheetRejected);
            Assert.IsNotNull(samplingPlanEmailExtraBList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(samplingPlanEmailExtraBList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(samplingPlanEmailExtraBList[0].HasErrors);
        }
        private SamplingPlanEmail GetFilledRandomSamplingPlanEmail(string OmitPropName)
        {
            SamplingPlanEmail samplingPlanEmail = new SamplingPlanEmail();

            if (OmitPropName != "SamplingPlanID") samplingPlanEmail.SamplingPlanID = 1;
            if (OmitPropName != "Email") samplingPlanEmail.Email = GetRandomEmail();
            if (OmitPropName != "IsContractor") samplingPlanEmail.IsContractor = true;
            if (OmitPropName != "LabSheetHasValueOver500") samplingPlanEmail.LabSheetHasValueOver500 = true;
            if (OmitPropName != "LabSheetReceived") samplingPlanEmail.LabSheetReceived = true;
            if (OmitPropName != "LabSheetAccepted") samplingPlanEmail.LabSheetAccepted = true;
            if (OmitPropName != "LabSheetRejected") samplingPlanEmail.LabSheetRejected = true;
            if (OmitPropName != "LastUpdateDate_UTC") samplingPlanEmail.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") samplingPlanEmail.LastUpdateContactTVItemID = 2;

            return samplingPlanEmail;
        }
        #endregion Functions private
    }
}
