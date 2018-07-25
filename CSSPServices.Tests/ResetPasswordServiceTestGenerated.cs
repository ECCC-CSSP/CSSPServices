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
    public partial class ResetPasswordServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private ResetPasswordService resetPasswordService { get; set; }
        #endregion Properties

        #region Constructors
        public ResetPasswordServiceTest() : base()
        {
            //resetPasswordService = new ResetPasswordService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void ResetPassword_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    ResetPassword resetPassword = GetFilledRandomResetPassword("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = resetPasswordService.GetRead().Count();

                    Assert.AreEqual(resetPasswordService.GetRead().Count(), resetPasswordService.GetEdit().Count());

                    resetPasswordService.Add(resetPassword);
                    if (resetPassword.HasErrors)
                    {
                        Assert.AreEqual("", resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, resetPasswordService.GetRead().Where(c => c == resetPassword).Any());
                    resetPasswordService.Update(resetPassword);
                    if (resetPassword.HasErrors)
                    {
                        Assert.AreEqual("", resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, resetPasswordService.GetRead().Count());
                    resetPasswordService.Delete(resetPassword);
                    if (resetPassword.HasErrors)
                    {
                        Assert.AreEqual("", resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, resetPasswordService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // resetPassword.ResetPasswordID   (Int32)
                    // -----------------------------------

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.ResetPasswordID = 0;
                    resetPasswordService.Update(resetPassword);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ResetPasswordResetPasswordID), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.ResetPasswordID = 10000000;
                    resetPasswordService.Update(resetPassword);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ResetPassword, CSSPModelsRes.ResetPasswordResetPasswordID, resetPassword.ResetPasswordID.ToString()), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(256))]
                    // resetPassword.Email   (String)
                    // -----------------------------------

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("Email");
                    Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
                    Assert.AreEqual(1, resetPassword.ValidationResults.Count());
                    Assert.IsTrue(resetPassword.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ResetPasswordEmail)).Any());
                    Assert.AreEqual(null, resetPassword.Email);
                    Assert.AreEqual(count, resetPasswordService.GetRead().Count());

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.Email = GetRandomString("", 257);
                    Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ResetPasswordEmail, "256"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, resetPasswordService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // resetPassword.ExpireDate_Local   (DateTime)
                    // -----------------------------------

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.ExpireDate_Local = new DateTime();
                    resetPasswordService.Add(resetPassword);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ResetPasswordExpireDate_Local), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.ExpireDate_Local = new DateTime(1979, 1, 1);
                    resetPasswordService.Add(resetPassword);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ResetPasswordExpireDate_Local, "1980"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(8))]
                    // resetPassword.Code   (String)
                    // -----------------------------------

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("Code");
                    Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
                    Assert.AreEqual(1, resetPassword.ValidationResults.Count());
                    Assert.IsTrue(resetPassword.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ResetPasswordCode)).Any());
                    Assert.AreEqual(null, resetPassword.Code);
                    Assert.AreEqual(count, resetPasswordService.GetRead().Count());

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.Code = GetRandomString("", 9);
                    Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ResetPasswordCode, "8"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, resetPasswordService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // resetPassword.ResetPasswordWeb   (ResetPasswordWeb)
                    // -----------------------------------

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.ResetPasswordWeb = null;
                    Assert.IsNull(resetPassword.ResetPasswordWeb);

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.ResetPasswordWeb = new ResetPasswordWeb();
                    Assert.IsNotNull(resetPassword.ResetPasswordWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // resetPassword.ResetPasswordReport   (ResetPasswordReport)
                    // -----------------------------------

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.ResetPasswordReport = null;
                    Assert.IsNull(resetPassword.ResetPasswordReport);

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.ResetPasswordReport = new ResetPasswordReport();
                    Assert.IsNotNull(resetPassword.ResetPasswordReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // resetPassword.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.LastUpdateDate_UTC = new DateTime();
                    resetPasswordService.Add(resetPassword);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ResetPasswordLastUpdateDate_UTC), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    resetPasswordService.Add(resetPassword);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ResetPasswordLastUpdateDate_UTC, "1980"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // resetPassword.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.LastUpdateContactTVItemID = 0;
                    resetPasswordService.Add(resetPassword);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ResetPasswordLastUpdateContactTVItemID, resetPassword.LastUpdateContactTVItemID.ToString()), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.LastUpdateContactTVItemID = 1;
                    resetPasswordService.Add(resetPassword);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ResetPasswordLastUpdateContactTVItemID, "Contact"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // resetPassword.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // resetPassword.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetResetPasswordWithResetPasswordID(resetPassword.ResetPasswordID)
        [TestMethod]
        public void GetResetPasswordWithResetPasswordID__resetPassword_ResetPasswordID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ResetPassword resetPassword = (from c in resetPasswordService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(resetPassword);

                    ResetPassword resetPasswordRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        resetPasswordService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            resetPasswordRet = resetPasswordService.GetResetPasswordWithResetPasswordID(resetPassword.ResetPasswordID);
                            Assert.IsNull(resetPasswordRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            resetPasswordRet = resetPasswordService.GetResetPasswordWithResetPasswordID(resetPassword.ResetPasswordID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            resetPasswordRet = resetPasswordService.GetResetPasswordWithResetPasswordID(resetPassword.ResetPasswordID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            resetPasswordRet = resetPasswordService.GetResetPasswordWithResetPasswordID(resetPassword.ResetPasswordID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckResetPasswordFields(new List<ResetPassword>() { resetPasswordRet }, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetResetPasswordWithResetPasswordID(resetPassword.ResetPasswordID)

        #region Tests Generated for GetResetPasswordList()
        [TestMethod]
        public void GetResetPasswordList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ResetPassword resetPassword = (from c in resetPasswordService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(resetPassword);

                    List<ResetPassword> resetPasswordList = new List<ResetPassword>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        resetPasswordService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                            Assert.AreEqual(0, resetPasswordList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckResetPasswordFields(resetPasswordList, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetResetPasswordList()

        #region Tests Generated for GetResetPasswordList() Skip Take
        [TestMethod]
        public void GetResetPasswordList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ResetPassword> resetPasswordList = new List<ResetPassword>();
                    List<ResetPassword> resetPasswordDirectQueryList = new List<ResetPassword>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        resetPasswordService.Query = resetPasswordService.FillQuery(typeof(ResetPassword), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        resetPasswordDirectQueryList = resetPasswordService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                            Assert.AreEqual(0, resetPasswordList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckResetPasswordFields(resetPasswordList, entityQueryDetailType);
                        Assert.AreEqual(resetPasswordDirectQueryList[0].ResetPasswordID, resetPasswordList[0].ResetPasswordID);
                        Assert.AreEqual(1, resetPasswordList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetResetPasswordList() Skip Take

        #region Tests Generated for GetResetPasswordList() Skip Take Order
        [TestMethod]
        public void GetResetPasswordList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ResetPassword> resetPasswordList = new List<ResetPassword>();
                    List<ResetPassword> resetPasswordDirectQueryList = new List<ResetPassword>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        resetPasswordService.Query = resetPasswordService.FillQuery(typeof(ResetPassword), culture.TwoLetterISOLanguageName, 1, 1,  "ResetPasswordID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        resetPasswordDirectQueryList = resetPasswordService.GetRead().Skip(1).Take(1).OrderBy(c => c.ResetPasswordID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                            Assert.AreEqual(0, resetPasswordList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckResetPasswordFields(resetPasswordList, entityQueryDetailType);
                        Assert.AreEqual(resetPasswordDirectQueryList[0].ResetPasswordID, resetPasswordList[0].ResetPasswordID);
                        Assert.AreEqual(1, resetPasswordList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetResetPasswordList() Skip Take Order

        #region Tests Generated for GetResetPasswordList() Skip Take 2Order
        [TestMethod]
        public void GetResetPasswordList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ResetPassword> resetPasswordList = new List<ResetPassword>();
                    List<ResetPassword> resetPasswordDirectQueryList = new List<ResetPassword>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        resetPasswordService.Query = resetPasswordService.FillQuery(typeof(ResetPassword), culture.TwoLetterISOLanguageName, 1, 1, "ResetPasswordID,Email", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        resetPasswordDirectQueryList = resetPasswordService.GetRead().Skip(1).Take(1).OrderBy(c => c.ResetPasswordID).ThenBy(c => c.Email).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                            Assert.AreEqual(0, resetPasswordList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckResetPasswordFields(resetPasswordList, entityQueryDetailType);
                        Assert.AreEqual(resetPasswordDirectQueryList[0].ResetPasswordID, resetPasswordList[0].ResetPasswordID);
                        Assert.AreEqual(1, resetPasswordList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetResetPasswordList() Skip Take 2Order

        #region Tests Generated for GetResetPasswordList() Skip Take Order Where
        [TestMethod]
        public void GetResetPasswordList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ResetPassword> resetPasswordList = new List<ResetPassword>();
                    List<ResetPassword> resetPasswordDirectQueryList = new List<ResetPassword>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        resetPasswordService.Query = resetPasswordService.FillQuery(typeof(ResetPassword), culture.TwoLetterISOLanguageName, 0, 1, "ResetPasswordID", "ResetPasswordID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        resetPasswordDirectQueryList = resetPasswordService.GetRead().Where(c => c.ResetPasswordID == 4).Skip(0).Take(1).OrderBy(c => c.ResetPasswordID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                            Assert.AreEqual(0, resetPasswordList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckResetPasswordFields(resetPasswordList, entityQueryDetailType);
                        Assert.AreEqual(resetPasswordDirectQueryList[0].ResetPasswordID, resetPasswordList[0].ResetPasswordID);
                        Assert.AreEqual(1, resetPasswordList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetResetPasswordList() Skip Take Order Where

        #region Tests Generated for GetResetPasswordList() Skip Take Order 2Where
        [TestMethod]
        public void GetResetPasswordList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ResetPassword> resetPasswordList = new List<ResetPassword>();
                    List<ResetPassword> resetPasswordDirectQueryList = new List<ResetPassword>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        resetPasswordService.Query = resetPasswordService.FillQuery(typeof(ResetPassword), culture.TwoLetterISOLanguageName, 0, 1, "ResetPasswordID", "ResetPasswordID,GT,2|ResetPasswordID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        resetPasswordDirectQueryList = resetPasswordService.GetRead().Where(c => c.ResetPasswordID > 2 && c.ResetPasswordID < 5).Skip(0).Take(1).OrderBy(c => c.ResetPasswordID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                            Assert.AreEqual(0, resetPasswordList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckResetPasswordFields(resetPasswordList, entityQueryDetailType);
                        Assert.AreEqual(resetPasswordDirectQueryList[0].ResetPasswordID, resetPasswordList[0].ResetPasswordID);
                        Assert.AreEqual(1, resetPasswordList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetResetPasswordList() Skip Take Order 2Where

        #region Tests Generated for GetResetPasswordList() 2Where
        [TestMethod]
        public void GetResetPasswordList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ResetPassword> resetPasswordList = new List<ResetPassword>();
                    List<ResetPassword> resetPasswordDirectQueryList = new List<ResetPassword>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ResetPasswordService resetPasswordService = new ResetPasswordService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        resetPasswordService.Query = resetPasswordService.FillQuery(typeof(ResetPassword), culture.TwoLetterISOLanguageName, 0, 10000, "", "ResetPasswordID,GT,2|ResetPasswordID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        resetPasswordDirectQueryList = resetPasswordService.GetRead().Where(c => c.ResetPasswordID > 2 && c.ResetPasswordID < 5).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                            Assert.AreEqual(0, resetPasswordList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            resetPasswordList = resetPasswordService.GetResetPasswordList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckResetPasswordFields(resetPasswordList, entityQueryDetailType);
                        Assert.AreEqual(resetPasswordDirectQueryList[0].ResetPasswordID, resetPasswordList[0].ResetPasswordID);
                        Assert.AreEqual(2, resetPasswordList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetResetPasswordList() 2Where

        #region Functions private
        private void CheckResetPasswordFields(List<ResetPassword> resetPasswordList, EntityQueryDetailTypeEnum entityQueryDetailType)
        {
            // ResetPassword fields
            Assert.IsNotNull(resetPasswordList[0].ResetPasswordID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(resetPasswordList[0].Email));
            Assert.IsNotNull(resetPasswordList[0].ExpireDate_Local);
            Assert.IsFalse(string.IsNullOrWhiteSpace(resetPasswordList[0].Code));
            Assert.IsNotNull(resetPasswordList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(resetPasswordList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // ResetPasswordWeb and ResetPasswordReport fields should be null here
                Assert.IsNull(resetPasswordList[0].ResetPasswordWeb);
                Assert.IsNull(resetPasswordList[0].ResetPasswordReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // ResetPasswordWeb fields should not be null and ResetPasswordReport fields should be null here
                if (!string.IsNullOrWhiteSpace(resetPasswordList[0].ResetPasswordWeb.LastUpdateContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(resetPasswordList[0].ResetPasswordWeb.LastUpdateContactTVText));
                }
                Assert.IsNull(resetPasswordList[0].ResetPasswordReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // ResetPasswordWeb and ResetPasswordReport fields should NOT be null here
                if (resetPasswordList[0].ResetPasswordWeb.LastUpdateContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(resetPasswordList[0].ResetPasswordWeb.LastUpdateContactTVText));
                }
                if (resetPasswordList[0].ResetPasswordReport.ResetPasswordReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(resetPasswordList[0].ResetPasswordReport.ResetPasswordReportTest));
                }
            }
        }
        private ResetPassword GetFilledRandomResetPassword(string OmitPropName)
        {
            ResetPassword resetPassword = new ResetPassword();

            if (OmitPropName != "Email") resetPassword.Email = GetRandomString("", 5);
            if (OmitPropName != "ExpireDate_Local") resetPassword.ExpireDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "Code") resetPassword.Code = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") resetPassword.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") resetPassword.LastUpdateContactTVItemID = 2;

            return resetPassword;
        }
        #endregion Functions private
    }
}
