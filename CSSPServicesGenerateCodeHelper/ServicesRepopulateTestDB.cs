﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using CSSPModels;
using CSSPEnums;
using CSSPModelsGenerateCodeHelper;
using System.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using CSSPServices;

namespace CSSPServicesGenerateCodeHelper
{
    public partial class ServicesGenerateCodeHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        // constructor was done in the ServicesGenerateCodeHelper.cs file
        #endregion Constructors

        #region Events
        #endregion Events

        #region Functions public
        public void RepopulateTestDB()
        {
            List<Table> tableCSSPWebToolsDBList = new List<Table>();
            List<Table> tableTestDBList = new List<Table>();

            if (!LoadDBInfo(tableCSSPWebToolsDBList, servicesFiles.CSSPWebToolsDBConnectionString))
            {
                return;
            }

            if (!LoadDBInfo(tableTestDBList, servicesFiles.TestDBConnectionString))
            {
                return;
            }

            if (!CompareDBs(tableCSSPWebToolsDBList, tableTestDBList)) return;

            StatusPermanentEvent(new StatusEventArgs("Done comparing ... everything ok"));

            if (!CleanTestDB(tableTestDBList, servicesFiles.TestDBConnectionString)) return;

            StatusPermanentEvent(new StatusEventArgs("Done Cleaning TestDB ... everything ok"));

            if (!FillTestDB(tableTestDBList)) return;

            StatusPermanentEvent(new StatusEventArgs("Done Filling TestDB ... everything ok"));

            StatusTempEvent(new StatusEventArgs("Done ..."));
        }
        #endregion Functions public

        #region Functions private
        private bool CleanTestDB(List<Table> tableTestDBList, string TestDBConnectionString)
        {
            if (!SetTestDBDeleteOrderedList(tableTestDBList)) return false;

            try
            {
                using (SqlConnection cnn = new SqlConnection(TestDBConnectionString))
                {
                    if (!cnn.ConnectionString.Contains("TestDB"))
                    {
                        ErrorEvent(new ErrorEventArgs("Only use this command for the TestDB as it remove all the information from the DB and Reseed all tables"));
                        return false;
                    }

                    cnn.Open();

                    foreach (Table table in tableTestDBList.OrderBy(c => c.ordinalToDelete))
                    {
                        StatusTempEvent(new StatusEventArgs("Deleting Table  [" + table.TableName + "]"));
                        Application.DoEvents();
                        string queryString = "";

                        if (table.TableName == "TVItems")
                        {
                            for (int i = 10; i >= 0; i--)
                            {
                                queryString = "DELETE FROM " + table.TableName + " WHERE TVLevel = " + i;

                                using (SqlCommand cmd = new SqlCommand(queryString, cnn))
                                {
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            queryString = "DELETE FROM " + table.TableName;

                            using (SqlCommand cmd = new SqlCommand(queryString, cnn))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }

                        if (table.TableName == "AspNetRoles" || table.TableName == "AspNetUserLogins" || table.TableName == "AspNetUserRoles" || table.TableName == "AspNetUsers")
                        {
                            continue;
                        }

                        queryString = "DBCC CHECKIDENT('" + table.TableName + "', RESEED, 0)";

                        using (SqlCommand cmd = new SqlCommand(queryString, cnn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                return false;
            }

            return true;
        }
        private bool CompareDBs(List<Table> tableCSSPWebToolsDBList, List<Table> tableTestDBList)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Table tableCSSP in tableCSSPWebToolsDBList)
            {
                StatusTempEvent(new StatusEventArgs(tableCSSP.TableName));
                Application.DoEvents();

                if (tableCSSP.TableName == "sysdiagrams") continue;

                Table tableTest = (from c in tableTestDBList
                                   where c.TableName == tableCSSP.TableName
                                   select c).FirstOrDefault();

                if (tableTest == null)
                {
                    sb.AppendLine(tableCSSP.TableName + " does not exist in TestDB");
                    continue;
                }

                foreach (Col col in tableCSSP.colList)
                {
                    StatusTempEvent(new StatusEventArgs(tableCSSP.TableName + "    " + col.FieldName));
                    Application.DoEvents();

                    Col colTest = (from c in tableTest.colList
                                   where c.FieldName == col.FieldName
                                   select c).FirstOrDefault();

                    if (colTest == null)
                    {
                        sb.AppendLine(tableCSSP.TableName + "\t" + col.FieldName + " does not exist in TestDB");
                    }

                    if (col.AllowNull != colTest.AllowNull)
                    {
                        sb.AppendLine(tableCSSP.TableName + "\t" + col.FieldName + " Allow Null does not match in TestDB");
                    }

                    if (col.DataType != colTest.DataType)
                    {
                        sb.AppendLine(tableCSSP.TableName + "\t" + col.FieldName + " Data Type does not match in TestDB");
                    }

                    if (col.StringLength != colTest.StringLength)
                    {
                        sb.AppendLine(tableCSSP.TableName + "\t" + col.FieldName + " String Length does not match in TestDB");
                    }
                }
            }

            if (sb.ToString().Length > 0)
            {

                StatusPermanentEvent(new StatusEventArgs(sb.ToString()));
                return false;
            }

            return true;
        }
        private bool FillTestDB(List<Table> tableTestDBList)
        {
            #region TVItem Root
            // TVItem Root TVItemID = 1
            TVItem tvItemRoot = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 1).FirstOrDefault();
            if (!AddObject("TVItem", tvItemRoot)) return false;
            if (!AddMapInfo(tvItemRoot, 1)) return false ;

            // TVItemLanguage EN Root TVItemID = 1
            TVItemLanguage tvItemLanguageENRoot = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 1 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENRoot.TVItemID = tvItemRoot.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENRoot)) return false;

            // TVItemLanguage FR Root TVItemID = 1
            TVItemLanguage tvItemLanguageFRRoot = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 1 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRRoot.TVItemID = tvItemRoot.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRRoot)) return false;
            #endregion  TVItem Root
            #region TVItem Contact Charles
            // TVItem Charles G. LeBlanc TVItemID = 2
            TVItem tvItemContactCharles = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 2).FirstOrDefault();
            tvItemContactCharles.ParentID = tvItemRoot.TVItemID;
            if (!AddObject("TVItem", tvItemContactCharles)) return false;
            if (!CorrectTVPath(tvItemContactCharles, tvItemRoot)) return false;

            // TVItemLanguage EN Charles G. LeBlanc  TVItemID = 2
            TVItemLanguage tvItemLanguageENContactCharles = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 2 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENContactCharles.TVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENContactCharles)) return false;

            // TVItemLanguage FR Charles G. LeBlanc TVItemID = 2
            TVItemLanguage tvItemLanguageFRContactCharles = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 2 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRContactCharles.TVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRContactCharles)) return false;
            #endregion TVItem Contact Charles
            #region Contact and ContactLogin Charles
            // Contact Charles G. LeBlanc
            Contact contactCharles = dbCSSPWebToolsDBRead.Contacts.AsNoTracking().Where(c => c.ContactTVItemID == 2).FirstOrDefault();
            if (!AddObject("Contact", contactCharles)) return false;

            byte[] PasswordHash;
            byte[] PasswordSalt;

            Register register = new Register();
            register.LoginEmail = contactCharles.LoginEmail;
            register.FirstName = contactCharles.FirstName;
            register.Initial = contactCharles.Initial;
            register.LastName = contactCharles.LastName;
            register.WebName = contactCharles.WebName;
            register.Password = "aaaaaa2!";
            register.ConfirmPassword = register.Password;

            ContactService contactService = new ContactService(LanguageEnum.en, 2, DatabaseTypeEnum.MemoryTestDB);
            contactService.CreatePasswordHashAndSalt(register, out PasswordHash, out PasswordSalt);

            ContactLogin contactLoginCharles = new ContactLogin();
            contactLoginCharles.ContactID = contactCharles.ContactID;
            contactLoginCharles.LoginEmail = contactCharles.LoginEmail;
            contactLoginCharles.PasswordHash = PasswordHash;
            contactLoginCharles.PasswordSalt = PasswordSalt;
            contactLoginCharles.LastUpdateDate_UTC = DateTime.UtcNow;
            contactLoginCharles.LastUpdateContactTVItemID = contactCharles.ContactTVItemID;

            // ContactLogin Charles G. LeBlanc
            if (!AddObject("ContactLogin", contactLoginCharles)) return false;
            #endregion Contact and ContactLogin Charles
            #region Contact and ContactLogin Test User 1
            // TVItem Test User 1 TVItemID = 3
            TVItem tvItemContactTestUser1 = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 3).FirstOrDefault();
            tvItemContactTestUser1.ParentID = tvItemRoot.TVItemID;
            if (!AddObject("TVItem", tvItemContactTestUser1)) return false;
            if (!CorrectTVPath(tvItemContactTestUser1, tvItemRoot)) return false;

            // TVItemLanguage EN Test User 1  TVItemID = 3
            TVItemLanguage tvItemLanguageENContactTestUser1 = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 3 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENContactTestUser1.TVItemID = tvItemContactTestUser1.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENContactTestUser1)) return false;

            // TVItemLanguage FR Test User 1 TVItemID = 3
            TVItemLanguage tvItemLanguageFRContactTestUser1 = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 3 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRContactTestUser1.TVItemID = tvItemContactTestUser1.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRContactTestUser1)) return false;

            // Contact Test User 1
            Contact contactTestUser1 = dbCSSPWebToolsDBRead.Contacts.AsNoTracking().Where(c => c.ContactTVItemID == 3).FirstOrDefault();
            if (!AddObject("Contact", contactTestUser1)) return false;

            register = new Register();
            register.LoginEmail = contactTestUser1.LoginEmail;
            register.FirstName = contactTestUser1.FirstName;
            register.Initial = contactTestUser1.Initial;
            register.LastName = contactTestUser1.LastName;
            register.WebName = contactTestUser1.WebName;
            register.Password = "aaaaaa2!";
            register.ConfirmPassword = register.Password;

            contactService.CreatePasswordHashAndSalt(register, out PasswordHash, out PasswordSalt);

            ContactLogin contactLoginTestUser1 = new ContactLogin();
            contactLoginTestUser1.ContactID = contactTestUser1.ContactID;
            contactLoginTestUser1.LoginEmail = contactTestUser1.LoginEmail;
            contactLoginTestUser1.PasswordHash = PasswordHash;
            contactLoginTestUser1.PasswordSalt = PasswordSalt;
            contactLoginTestUser1.LastUpdateDate_UTC = DateTime.UtcNow;
            contactLoginTestUser1.LastUpdateContactTVItemID = contactTestUser1.ContactTVItemID;

            // ContactLogin Test User 1
            if (!AddObject("ContactLogin", contactLoginTestUser1)) return false;
            #endregion Contact and ContactLogin Test User 1
            #region Contact and ContactLogin Test User 2

            // TVItem Test User 2 TVItemID = 4
            TVItem tvItemContactTestUser2 = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 4).FirstOrDefault();
            tvItemContactTestUser2.ParentID = tvItemRoot.TVItemID;
            if (!AddObject("TVItem", tvItemContactTestUser2)) return false;
            if (!CorrectTVPath(tvItemContactTestUser2, tvItemRoot)) return false;

            // TVItemLanguage EN Test User 2  TVItemID = 4
            TVItemLanguage tvItemLanguageENContactTestUser2 = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 4 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENContactTestUser2.TVItemID = tvItemContactTestUser2.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENContactTestUser2)) return false;

            // TVItemLanguage FR Test User 2 TVItemID = 4
            TVItemLanguage tvItemLanguageFRContactTestUser2 = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 4 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRContactTestUser2.TVItemID = tvItemContactTestUser2.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRContactTestUser2)) return false;

            // Contact Test User 2
            Contact contactTestUser2 = dbCSSPWebToolsDBRead.Contacts.AsNoTracking().Where(c => c.ContactTVItemID == 4).FirstOrDefault();
            if (!AddObject("Contact", contactTestUser2)) return false;

            register = new Register();
            register.LoginEmail = contactTestUser2.LoginEmail;
            register.FirstName = contactTestUser2.FirstName;
            register.Initial = contactTestUser2.Initial;
            register.LastName = contactTestUser2.LastName;
            register.WebName = contactTestUser2.WebName;
            register.Password = "aaaaaa2!";
            register.ConfirmPassword = register.Password;

            contactService.CreatePasswordHashAndSalt(register, out PasswordHash, out PasswordSalt);

            ContactLogin contactLoginTestUser2 = new ContactLogin();
            contactLoginTestUser2.ContactID = contactTestUser2.ContactID;
            contactLoginTestUser2.LoginEmail = contactTestUser2.LoginEmail;
            contactLoginTestUser2.PasswordHash = PasswordHash;
            contactLoginTestUser2.PasswordSalt = PasswordSalt;
            contactLoginTestUser2.LastUpdateDate_UTC = DateTime.Now;
            contactLoginTestUser2.LastUpdateContactTVItemID = contactTestUser2.ContactTVItemID;

            // ContactLogin Test User 1
            if (!AddObject("ContactLogin", contactLoginTestUser2)) return false;
            #endregion Contact and ContactLogin Test User 2
            #region TVItem Country Canada
            // TVItem Canada TVItemID = 5
            TVItem tvItemCanada = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 5).FirstOrDefault();
            tvItemCanada.ParentID = tvItemRoot.TVItemID;
            if (!AddObject("TVItem", tvItemCanada)) return false;
            if (!CorrectTVPath(tvItemCanada, tvItemRoot)) return false;
            if (!AddMapInfo(tvItemCanada, 5)) return false;

            // TVItemLanguage EN Canada TVItemID = 5
            TVItemLanguage tvItemLanguageENCanada = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 5 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENCanada.TVItemID = tvItemCanada.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENCanada)) return false;

            // TVItemLanguage FR Canada TVItemID = 5
            TVItemLanguage tvItemLanguageFRCanada = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 5 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRCanada.TVItemID = tvItemCanada.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRCanada)) return false;
            #endregion TVItem Country Canada
            #region TVItem Province NB
            // TVItem Province NB TVItemID = 7
            TVItem tvItemNB = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 7).FirstOrDefault();
            tvItemNB.ParentID = tvItemCanada.TVItemID;
            if (!AddObject("TVItem", tvItemNB)) return false;
            if (!CorrectTVPath(tvItemNB, tvItemCanada)) return false;
            if (!AddMapInfo(tvItemNB, 7)) return false;

            // TVItemLanguage EN NB TVItemID = 7
            TVItemLanguage tvItemLanguageENNB = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 7 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENNB.TVItemID = tvItemNB.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENNB)) return false;

            // TVItemLanguage FR NB TVItemID = 7
            TVItemLanguage tvItemLanguageFRNB = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 7 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRNB.TVItemID = tvItemNB.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRNB)) return false;
            #endregion TVItem Province NB
            #region TVItem ClimateSite Bouctouche CDA
            // TVItem ClimateSite Bouctouche CDA TVItemID = 229528
            TVItem tvItemNBClimateSiteBouctoucheCDA = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 229528).FirstOrDefault();
            tvItemNBClimateSiteBouctoucheCDA.ParentID = tvItemNB.TVItemID;
            if (!AddObject("TVItem", tvItemNBClimateSiteBouctoucheCDA)) return false;
            if (!CorrectTVPath(tvItemNBClimateSiteBouctoucheCDA, tvItemNB)) return false;
            if (!AddMapInfo(tvItemNBClimateSiteBouctoucheCDA, 229528)) return false;

            // TVItemLanguage EN Climate Site Bouctouche CDA NB TVItemID = 229528
            TVItemLanguage tvItemLanguageENNBClimateSiteBouctoucheCDA = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 229528 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENNBClimateSiteBouctoucheCDA.TVItemID = tvItemNBClimateSiteBouctoucheCDA.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENNBClimateSiteBouctoucheCDA)) return false;

            // TVItemLanguage FR Climate Site Bouctouche CDA NB TVItemID = 229528
            TVItemLanguage tvItemLanguageFRNBClimateSiteBouctoucheCDA = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 229528 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRNBClimateSiteBouctoucheCDA.TVItemID = tvItemNBClimateSiteBouctoucheCDA.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRNBClimateSiteBouctoucheCDA)) return false;
            #endregion TVItem ClimateSite Bouctouche CDA
            #region ClimateSite Bouctouche CDA

            // NB Climate Site Bouctouche CDA where ClimateSiteTVItemID = 229528
            ClimateSite climateSite = dbCSSPWebToolsDBRead.ClimateSites.AsNoTracking().Where(c => c.ClimateSiteTVItemID == 229528).FirstOrDefault();
            int ClimateSiteID = climateSite.ClimateSiteID;
            climateSite.ClimateSiteTVItemID = tvItemNBClimateSiteBouctoucheCDA.TVItemID;
            if (!AddObject("ClimateSite", climateSite)) return false;

            // NB Climate Data Value Bouctouche CDA where ClimateSiteTVItemID = 229528
            List<ClimateDataValue> climateDataValueList = dbCSSPWebToolsDBRead.ClimateDataValues.AsNoTracking().Where(c => c.ClimateSiteID == ClimateSiteID && c.TotalPrecip_mm_cm != -999.0f).Take(5).ToList();
            foreach (ClimateDataValue climateDataValue in climateDataValueList)
            {
                climateDataValue.ClimateSiteID = climateSite.ClimateSiteID;
                if (!AddObject("ClimateDataValue", climateDataValue)) return false;
            }
            #endregion ClimateSite Bouctouche CDA
            #region TVItem HydrometricSite Big Tracadie 01BL003 
            // TVItem HydrometricSite Big Tracadie 01BL003 TVItemID = 55401
            TVItem tvItemNBHydrometricSiteBigTracadie = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 55401).FirstOrDefault();
            tvItemNBHydrometricSiteBigTracadie.ParentID = tvItemNB.TVItemID;
            if (!AddObject("TVItem", tvItemNBHydrometricSiteBigTracadie)) return false;
            if (!CorrectTVPath(tvItemNBHydrometricSiteBigTracadie, tvItemNB)) return false;
            if (!AddMapInfo(tvItemNBHydrometricSiteBigTracadie, 55401)) return false;

            // TVItemLanguage EN Hydrometric site Big Tracadie NB TVItemID = 55401
            TVItemLanguage tvItemLanguageENNBHydrometricSiteBigTracadie = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 55401 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENNBHydrometricSiteBigTracadie.TVItemID = tvItemNBHydrometricSiteBigTracadie.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENNBHydrometricSiteBigTracadie)) return false;

            // TVItemLanguage FR Hydrometric site Big Tracadie NB TVItemID = 55401
            TVItemLanguage tvItemLanguageFRNBHydrometricSiteBigTracadie = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 55401 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRNBHydrometricSiteBigTracadie.TVItemID = tvItemNBHydrometricSiteBigTracadie.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRNBHydrometricSiteBigTracadie)) return false;
            #endregion TVItem HydrometricSite Big Tracadie 01BL003 
            #region HydrometricSite Big Tracadie 01BL003 

            // NB Hydrometric site Big Tracadie where HydrometricSiteTVItemID = 55401
            HydrometricSite hydrometricSite = dbCSSPWebToolsDBRead.HydrometricSites.AsNoTracking().Where(c => c.HydrometricSiteTVItemID == 55401).FirstOrDefault();
            int HydrometricSiteID = hydrometricSite.HydrometricSiteID;
            hydrometricSite.HydrometricSiteTVItemID = tvItemNBHydrometricSiteBigTracadie.TVItemID;
            if (!AddObject("HydrometricSite", hydrometricSite)) return false;

            // NB Hydrometric site Big Tracadie where HydrometricSiteTVItemID = 55401
            List<HydrometricDataValue> hydrometricDataValueList = dbCSSPWebToolsDBRead.HydrometricDataValues.AsNoTracking().Where(c => c.HydrometricSiteID == HydrometricSiteID).Take(5).ToList();
            foreach (HydrometricDataValue hydrometricDataValue in hydrometricDataValueList)
            {
                hydrometricDataValue.HydrometricSiteID = hydrometricSite.HydrometricSiteID;
                if (!AddObject("HydrometricDataValue", hydrometricDataValue)) return false;
            }
            #endregion HydrometricSite Big Tracadie 01BL003 
            #region RatingCurve Big Tracadie 01BL003 

            // NB Hydrometric site Big Tracadie where HydrometricSiteTVItemID = 55401
            RatingCurve ratingCurve = dbCSSPWebToolsDBRead.RatingCurves.AsNoTracking().Where(c => c.HydrometricSiteID == HydrometricSiteID).FirstOrDefault();
            int RatingCurveID = ratingCurve.RatingCurveID;
            ratingCurve.HydrometricSiteID = hydrometricSite.HydrometricSiteID;
            if (!AddObject("RatingCurve", ratingCurve)) return false;
            #endregion RatingCurve Big Tracadie 01BL003 
            #region RatingCurveValue Big Tracadie 01BL003 

            // NB Hydrometric site Big Tracadie where HydrometricSiteTVItemID = 55401
            List<RatingCurveValue> ratingCurveValueList = dbCSSPWebToolsDBRead.RatingCurveValues.AsNoTracking().Where(c => c.RatingCurveID == RatingCurveID).ToList();
            foreach (RatingCurveValue ratingCurveValue in ratingCurveValueList)
            {
                ratingCurveValue.RatingCurveID = ratingCurve.RatingCurveID;
                if (!AddObject("RatingCurveValue", ratingCurveValue)) return false;
            }
            #endregion RatingCurve Big Tracadie 01BL003 
            #region TVItem Area NB-06 
            // TVItem Area NB-06 TVItemID = 629
            TVItem tvItemNB_06 = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 629).FirstOrDefault();
            tvItemNB_06.ParentID = tvItemNB.TVItemID;
            if (!AddObject("TVItem", tvItemNB_06)) return false;
            if (!CorrectTVPath(tvItemNB_06, tvItemNB)) return false;
            if (!AddMapInfo(tvItemNB_06, 629)) return false;

            // TVItemLanguage EN NB-06 TVItemID = 629
            TVItemLanguage tvItemLanguageENNB_06 = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 629 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENNB_06.TVItemID = tvItemNB_06.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENNB_06)) return false;

            // TVItemLanguage FR NB_06 TVItemID = 629
            TVItemLanguage tvItemLanguageFRNB_06 = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 629 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRNB_06.TVItemID = tvItemNB_06.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRNB_06)) return false;
            #endregion TVItem Area NB-06 
            #region TVItem Sector NB-06-020 
            // TVItem Sector NB-06_020 TVItemID = 633
            TVItem tvItemNB_06_020 = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 633).FirstOrDefault();
            tvItemNB_06_020.ParentID = tvItemNB_06.TVItemID;
            if (!AddObject("TVItem", tvItemNB_06_020)) return false;
            if (!CorrectTVPath(tvItemNB_06_020, tvItemNB_06)) return false;
            if (!AddMapInfo(tvItemNB_06_020, 633)) return false;

            // TVItemLanguage EN NB-06_020 TVItemID = 633
            TVItemLanguage tvItemLanguageENNB_06_020 = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 633 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENNB_06_020.TVItemID = tvItemNB_06.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENNB_06_020)) return false;

            // TVItemLanguage FR NB_06_020 TVItemID = 633
            TVItemLanguage tvItemLanguageFRNB_06_020 = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 633 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRNB_06_020.TVItemID = tvItemNB_06.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020)) return false;
            #endregion TVItem Sector NB-06-020 
            #region TVItem Subsector NB-06_020_001 
            // TVItem Subsector NB-06_020_001 TVItemID = 634
            TVItem tvItemNB_06_020_001 = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 634).FirstOrDefault();
            tvItemNB_06_020_001.ParentID = tvItemNB_06_020.TVItemID;
            if (!AddObject("TVItem", tvItemNB_06_020_001)) return false;
            if (!CorrectTVPath(tvItemNB_06_020_001, tvItemNB_06_020)) return false;
            if (!AddMapInfo(tvItemNB_06_020_001, 634)) return false;

            // TVItemLanguage EN NB-06_020_001 TVItemID = 634
            TVItemLanguage tvItemLanguageENNB_06_020_001 = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 634 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENNB_06_020_001.TVItemID = tvItemNB_06_020.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENNB_06_020_001)) return false;

            // TVItemLanguage FR NB_06_020 TVItemID = 634
            TVItemLanguage tvItemLanguageFRNB_06_020_001 = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 634 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRNB_06_020_001.TVItemID = tvItemNB_06_020.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020_001)) return false;
            #endregion TVItem Subsector NB-06_020_001 
            #region TVItem Subsector NB-06_020_002 

            // TVItem Subsector NB-06_020_002 TVItemID = 635
            TVItem tvItemNB_06_020_002 = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 635).FirstOrDefault();
            tvItemNB_06_020_002.ParentID = tvItemNB_06_020.TVItemID;
            if (!AddObject("TVItem", tvItemNB_06_020_002)) return false;
            if (!CorrectTVPath(tvItemNB_06_020_002, tvItemNB_06_020)) return false;
            if (!AddMapInfo(tvItemNB_06_020_002, 635)) return false;

            // TVItemLanguage EN NB-06_020_001 TVItemID = 635
            TVItemLanguage tvItemLanguageENNB_06_020_002 = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 635 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENNB_06_020_002.TVItemID = tvItemNB_06_020.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENNB_06_020_002)) return false;

            // TVItemLanguage FR NB_06_020 TVItemID = 635
            TVItemLanguage tvItemLanguageFRNB_06_020_002 = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 635 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRNB_06_020_002.TVItemID = tvItemNB_06_020.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020_002)) return false;
            #endregion TVItem Subsector NB-06_020_001 
            #region TVItem Municipality Bouctouche
            // TVItem Municipality Bouctouche TVItemID = 27764
            TVItem tvItemBouctouche = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 27764).FirstOrDefault();
            tvItemBouctouche.ParentID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("TVItem", tvItemBouctouche)) return false;
            if (!CorrectTVPath(tvItemBouctouche, tvItemNB_06_020_002)) return false;
            if (!AddMapInfo(tvItemBouctouche, 27764)) return false;

            // TVItemLanguage EN Bouctouche TVItemID = 27764
            TVItemLanguage tvItemLanguageENBouctouche = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 27764 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENBouctouche.TVItemID = tvItemBouctouche.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENBouctouche)) return false;

            // TVItemLanguage FR Bouctouche TVItemID = 27764
            TVItemLanguage tvItemLanguageFRBouctouche = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 27764 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRBouctouche.TVItemID = tvItemBouctouche.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRBouctouche)) return false;
            #endregion TVItem Municipality Bouctouche
            #region TVItem Municipality Ste Marie de Kent 

            // TVItem Municipality Ste Marie de Kent TVItemID = 44855
            TVItem tvItemSteMarieDeKent = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 44855).FirstOrDefault();
            tvItemSteMarieDeKent.ParentID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("TVItem", tvItemSteMarieDeKent)) return false;
            if (!CorrectTVPath(tvItemSteMarieDeKent, tvItemNB_06_020_002)) return false;
            if (!AddMapInfo(tvItemSteMarieDeKent, 44855)) return false;

            // TVItemLanguage EN Ste Marie de Kent TVItemID = 44855
            TVItemLanguage tvItemLanguageENSteMarieDeKent = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 44855 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENSteMarieDeKent.TVItemID = tvItemSteMarieDeKent.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENSteMarieDeKent)) return false;

            // TVItemLanguage FR Ste Marie de Kent TVItemID = 44855
            TVItemLanguage tvItemLanguageFRSteMarieDeKent = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 44855 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRSteMarieDeKent.TVItemID = tvItemSteMarieDeKent.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRSteMarieDeKent)) return false;
            #endregion TVItem Municipality Ste Marie de Kent 
            #region TVItem Municipality Bouctouche WWTP 

            // TVItem Municipality Bouctouche WWTP TVItemID = 28689
            TVItem tvItemBouctoucheWWTP = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 28689).FirstOrDefault();
            tvItemBouctoucheWWTP.ParentID = tvItemBouctouche.TVItemID;
            if (!AddObject("TVItem", tvItemBouctoucheWWTP)) return false;
            if (!CorrectTVPath(tvItemBouctoucheWWTP, tvItemBouctouche)) return false;
            if (!AddMapInfo(tvItemBouctoucheWWTP, 28689)) return false;

            // TVItemLanguage EN Bouctouche WWTP TVItemID = 28689
            TVItemLanguage tvItemLanguageENBouctoucheWWTP = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28689 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENBouctoucheWWTP.TVItemID = tvItemBouctoucheWWTP.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENBouctoucheWWTP)) return false;

            // TVItemLanguage FR Bouctouche WWTP TVItemID = 28689
            TVItemLanguage tvItemLanguageFRBouctoucheWWTP = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28689 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRBouctoucheWWTP.TVItemID = tvItemBouctoucheWWTP.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRBouctoucheWWTP)) return false;
            #endregion TVItem Municipality Bouctouche WWTP 
            #region TVItem TVFile Bouctouche WWTP 

            // TVItem TVFile Bouctouche WWTP TVItemID = 28689
            TVItem TempBouctWWTP = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 28689).FirstOrDefault();
            TVItem tvItemBouctoucheWWTPTVFile = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVPath.StartsWith(TempBouctWWTP.TVPath + "p") && c.TVType == TVTypeEnum.File).FirstOrDefault();
            int TempTVItemID = tvItemBouctoucheWWTPTVFile.TVItemID;
            tvItemBouctoucheWWTPTVFile.ParentID = tvItemBouctoucheWWTP.TVItemID;
            if (!AddObject("TVItem", tvItemBouctoucheWWTPTVFile)) return false;
            if (!CorrectTVPath(tvItemBouctoucheWWTPTVFile, tvItemBouctoucheWWTP)) return false;
            if (!AddMapInfo(tvItemBouctoucheWWTPTVFile, TempTVItemID)) return false;

            // TVItemLanguage EN TVItem for Image for Bouctouche WWTP TVItemID = 28689
            TVItemLanguage tvItemBouctoucheWWTPTVFileImageEN = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == TempTVItemID && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemBouctoucheWWTPTVFileImageEN.TVItemID = tvItemBouctoucheWWTPTVFile.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemBouctoucheWWTPTVFileImageEN)) return false;

            // TVItemLanguage FR TVItem for Image for Bouctouche WWTP TVItemID = 28689
            TVItemLanguage tvItemBouctoucheWWTPTVFileImageFR = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == TempTVItemID && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemBouctoucheWWTPTVFileImageFR.TVItemID = tvItemBouctoucheWWTPTVFile.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemBouctoucheWWTPTVFileImageFR)) return false;
            #endregion TVItem TVFile Bouctouche WWTP 
            #region TVFile Bouctouche WWTP 

            // TVFile Bouctouche WWTP TVItemID = 28689
            TVFile tvFileBouctoucheWWTP = dbCSSPWebToolsDBRead.TVFiles.AsNoTracking().Where(c => c.TVFileTVItemID == TempTVItemID).FirstOrDefault();
            int TVFileID = tvFileBouctoucheWWTP.TVFileID;
            tvFileBouctoucheWWTP.TVFileTVItemID = tvItemBouctoucheWWTPTVFile.TVItemID;
            if (!AddObject("TVFile", tvFileBouctoucheWWTP)) return false;

            // TVFileLanguage EN Bouctouche WWTP TVItemID = 28689
            TVFileLanguage tvFileLanguageENBouctoucheWWTP = dbCSSPWebToolsDBRead.TVFileLanguages.AsNoTracking().Where(c => c.TVFileID == TVFileID && c.Language == LanguageEnum.en).FirstOrDefault();
            tvFileLanguageENBouctoucheWWTP.TVFileID = tvFileBouctoucheWWTP.TVFileID;
            if (!AddObject("TVFileLanguage", tvFileLanguageENBouctoucheWWTP)) return false;

            // TVFileLanguage FR Bouctouche WWTP TVItemID = 28689
            TVFileLanguage tvFileLanguageFRBouctoucheWWTP = dbCSSPWebToolsDBRead.TVFileLanguages.AsNoTracking().Where(c => c.TVFileID == TVFileID && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvFileLanguageFRBouctoucheWWTP.TVFileID = tvFileBouctoucheWWTP.TVFileID;
            if (!AddObject("TVFileLanguage", tvFileLanguageFRBouctoucheWWTP)) return false;
            #endregion TVFile Bouctouche WWTP 
            #region Infrastructure Bouctouche WWTP

            // Infrastructure Bouctouche WWTP TVItemID = 28689
            Infrastructure infrastructureBouctoucheWWTP = dbCSSPWebToolsDBRead.Infrastructures.AsNoTracking().Where(c => c.InfrastructureTVItemID == 28689).FirstOrDefault();
            int InfrastructureID = infrastructureBouctoucheWWTP.InfrastructureID;
            infrastructureBouctoucheWWTP.InfrastructureTVItemID = tvItemBouctoucheWWTP.TVItemID;
            if (!AddObject("Infrastructure", infrastructureBouctoucheWWTP)) return false;

            // InfrastructureLanguage EN Bouctouche WWTP TVItemID = 28689
            InfrastructureLanguage infrastructureLanguageENBouctoucheWWTP = dbCSSPWebToolsDBRead.InfrastructureLanguages.AsNoTracking().Where(c => c.InfrastructureID == InfrastructureID && c.Language == LanguageEnum.en).FirstOrDefault();
            infrastructureLanguageENBouctoucheWWTP.InfrastructureID = infrastructureBouctoucheWWTP.InfrastructureID;
            if (!AddObject("InfrastructureLanguage", infrastructureLanguageENBouctoucheWWTP)) return false;

            // InfrastructureLanguage FR Bouctouche WWTP TVItemID = 28689
            InfrastructureLanguage infrastructureLanguageFRBouctoucheWWTP = dbCSSPWebToolsDBRead.InfrastructureLanguages.AsNoTracking().Where(c => c.InfrastructureID == InfrastructureID && c.Language == LanguageEnum.fr).FirstOrDefault();
            infrastructureLanguageFRBouctoucheWWTP.InfrastructureID = infrastructureBouctoucheWWTP.InfrastructureID;
            if (!AddObject("InfrastructureLanguage", infrastructureLanguageFRBouctoucheWWTP)) return false;
            #endregion Infrastructure Bouctouche WWTP
            #region BoxModel Bouctouche WWTP

            // BoxModel Bouctouche WWTP TVItemID = 28689
            BoxModel boxModel = dbCSSPWebToolsDBRead.BoxModels.AsNoTracking().Where(c => c.InfrastructureTVItemID == 28689).FirstOrDefault();
            int BoxModelID = boxModel.BoxModelID;
            boxModel.InfrastructureTVItemID = tvItemBouctoucheWWTP.TVItemID;
            if (!AddObject("BoxModel", boxModel)) return false;

            // BoxModelLanguage EN Bouctouche WWTP TVItemID = 28689
            BoxModelLanguage boxModelLanguageEN = dbCSSPWebToolsDBRead.BoxModelLanguages.AsNoTracking().Where(c => c.BoxModelID == BoxModelID && c.Language == LanguageEnum.en).FirstOrDefault();
            boxModelLanguageEN.BoxModelID = boxModel.BoxModelID;
            if (!AddObject("BoxModelLanguage", boxModelLanguageEN)) return false;

            // BoxModelLanguage FR Bouctouche WWTP TVItemID = 28689
            BoxModelLanguage boxModelLanguageFR = dbCSSPWebToolsDBRead.BoxModelLanguages.AsNoTracking().Where(c => c.BoxModelID == BoxModelID && c.Language == LanguageEnum.fr).FirstOrDefault();
            boxModelLanguageFR.BoxModelID = boxModel.BoxModelID;
            if (!AddObject("BoxModelLanguage", boxModelLanguageFR)) return false;
            #endregion BoxModel Bouctouche WWTP
            #region BoxModelResult Bouctouche WWTP

            // BoxModelResult Bouctouche WWTP TVItemID = 28689
            for (int i = 1; i < 6; i++)
            {
                BoxModelResult boxModelResult = dbCSSPWebToolsDBRead.BoxModelResults.AsNoTracking().Where(c => c.BoxModelID == BoxModelID && c.BoxModelResultType == (BoxModelResultTypeEnum)i).FirstOrDefault();
                boxModelResult.BoxModelID = boxModel.BoxModelID;
                if (!AddObject("BoxModelResult", boxModelResult)) return false;
            }
            #endregion BoxModelResult Bouctouche WWTP
            #region VPScenario Bouctouche WWTP 

            // VPScenario Bouctouche WWTP TVItemID = 28689
            VPScenario VPScenario = dbCSSPWebToolsDBRead.VPScenarios.AsNoTracking().Where(c => c.InfrastructureTVItemID == 28689).FirstOrDefault();
            int VPScenarioID = VPScenario.VPScenarioID;
            VPScenario.InfrastructureTVItemID = tvItemBouctoucheWWTP.TVItemID;
            if (!AddObject("VPScenario", VPScenario)) return false;

            // VPScenarioLanguage EN Bouctouche WWTP TVItemID = 28689
            VPScenarioLanguage VPScenarioLanguageEN = dbCSSPWebToolsDBRead.VPScenarioLanguages.AsNoTracking().Where(c => c.VPScenarioID == VPScenarioID && c.Language == LanguageEnum.en).FirstOrDefault();
            VPScenarioLanguageEN.VPScenarioID = VPScenario.VPScenarioID;
            if (!AddObject("VPScenarioLanguage", VPScenarioLanguageEN)) return false;

            // VPScenarioLanguage FR Bouctouche WWTP TVItemID = 28689
            VPScenarioLanguage VPScenarioLanguageFR = dbCSSPWebToolsDBRead.VPScenarioLanguages.AsNoTracking().Where(c => c.VPScenarioID == VPScenarioID && c.Language == LanguageEnum.fr).FirstOrDefault();
            VPScenarioLanguageFR.VPScenarioID = VPScenario.VPScenarioID;
            if (!AddObject("VPScenarioLanguage", VPScenarioLanguageFR)) return false;

            // VPAmbient Bouctouche WWTP TVItemID = 28689
            List<VPAmbient> VPAmbientList = dbCSSPWebToolsDBRead.VPAmbients.AsNoTracking().Where(c => c.VPScenarioID == VPScenarioID).ToList();
            foreach (VPAmbient vpAmbient in VPAmbientList)
            {
                vpAmbient.VPScenarioID = VPScenario.VPScenarioID;
                if (!AddObject("VPAmbient", vpAmbient)) return false;
            }

            // VPAmbient Bouctouche WWTP TVItemID = 28689
            List<VPResult> VPResultList = dbCSSPWebToolsDBRead.VPResults.AsNoTracking().Where(c => c.VPScenarioID == VPScenarioID).ToList();
            foreach (VPResult vpResult in VPResultList)
            {
                vpResult.VPScenarioID = VPScenario.VPScenarioID;
                if (!AddObject("VPResult", vpResult)) return false;
            }
            #endregion VPScenario Bouctouche WWTP 
            #region TVItem Municipality Bouctouche LS 2 Rue Acadie

            // TVItem Municipality Bouctouche LS 2 Rue Acadie TVItemID = 28695
            TVItem tvItemBouctoucheLS2RueAcadie = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 28695).FirstOrDefault();
            tvItemBouctoucheLS2RueAcadie.ParentID = tvItemBouctouche.TVItemID;
            if (!AddObject("TVItem", tvItemBouctoucheLS2RueAcadie)) return false;
            if (!CorrectTVPath(tvItemBouctoucheLS2RueAcadie, tvItemBouctouche)) return false;
            if (!AddMapInfo(tvItemBouctoucheLS2RueAcadie, 28695)) return false;

            // TVItemLanguage EN Bouctouche LS 2 Rue Acadie TVItemID = 28695
            TVItemLanguage tvItemLanguageENBouctoucheLS2RueAcadie = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28695 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENBouctoucheLS2RueAcadie.TVItemID = tvItemBouctoucheLS2RueAcadie.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENBouctoucheLS2RueAcadie)) return false;

            // TVItemLanguage FR Bouctouche LS 2 Rue Acadie TVItemID = 28695
            TVItemLanguage tvItemLanguageFRBouctoucheLS2RueAcadie = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28695 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRBouctoucheLS2RueAcadie.TVItemID = tvItemBouctoucheLS2RueAcadie.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRBouctoucheLS2RueAcadie)) return false;
            #endregion TVItem Municipality Bouctouche LS 2 Rue Acadie
            #region TVItem Subsector NB-06_020_002 MWQM Site 0001

            // TVItem Subsector NB-06_020_002 MWQM Site 0001 TVItemID = 7460
            TVItem tvItemNB_06_020_002Site0001 = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 7460).FirstOrDefault();
            int MWQMSiteID0001 = tvItemNB_06_020_002Site0001.TVItemID;
            tvItemNB_06_020_002Site0001.ParentID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("TVItem", tvItemNB_06_020_002Site0001)) return false;
            if (!CorrectTVPath(tvItemNB_06_020_002Site0001, tvItemNB_06_020_002)) return false;
            if (!AddMapInfo(tvItemNB_06_020_002Site0001, 7460)) return false;

            // TVItemLanguage EN NB-06_020_001 TVItemID = 7460
            TVItemLanguage tvItemLanguageENNB_06_020_002Site0001 = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 7460 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENNB_06_020_002Site0001.TVItemID = tvItemNB_06_020_002Site0001.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENNB_06_020_002Site0001)) return false;

            // TVItemLanguage FR NB_06_020 TVItemID = 7460
            TVItemLanguage tvItemLanguageFRNB_06_020_002Site0001 = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 7460 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRNB_06_020_002Site0001.TVItemID = tvItemNB_06_020_002Site0001.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020_002Site0001)) return false;
            #endregion TVItem Subsector NB-06_020_002 MWQM Site 0001
            #region TVItem Subsector NB-06_020_002 MWQM Site 0002

            // TVItem Subsector NB-06_020_002 MWQM Site 0001 TVItemID = 7462
            TVItem tvItemNB_06_020_002Site0002 = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 7462).FirstOrDefault();
            int MWQMSiteID0002 = tvItemNB_06_020_002Site0002.TVItemID;
            tvItemNB_06_020_002Site0002.ParentID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("TVItem", tvItemNB_06_020_002Site0002)) return false;
            if (!CorrectTVPath(tvItemNB_06_020_002Site0002, tvItemNB_06_020_002)) return false;
            if (!AddMapInfo(tvItemNB_06_020_002Site0002, 7462)) return false;

            // TVItemLanguage EN NB-06_020_001 TVItemID = 7462
            TVItemLanguage tvItemLanguageENNB_06_020_002Site0002 = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 7462 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENNB_06_020_002Site0002.TVItemID = tvItemNB_06_020_002Site0002.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENNB_06_020_002Site0002)) return false;

            // TVItemLanguage FR NB_06_020 TVItemID = 7462
            TVItemLanguage tvItemLanguageFRNB_06_020_002Site0002 = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 7462 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRNB_06_020_002Site0002.TVItemID = tvItemNB_06_020_002Site0002.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020_002Site0002)) return false;
            #endregion TVItem Subsector NB-06_020_002 MWQM Site 0002
            #region TVItem Subsector NB-06_020_002 Pol Source Site 000023

            // TVItem Subsector NB-06_020_002 Pol Source Site 000023 TVItemID = 202466
            TVItem tvItemNB_06_020_002PolSite000023 = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 202466).FirstOrDefault();
            tvItemNB_06_020_002PolSite000023.ParentID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("TVItem", tvItemNB_06_020_002PolSite000023)) return false;
            if (!CorrectTVPath(tvItemNB_06_020_002PolSite000023, tvItemNB_06_020_002)) return false;
            if (!AddMapInfo(tvItemNB_06_020_002PolSite000023, 202466)) return false;

            // TVItemLanguage EN Subsector NB-06_020_002 Pol Source Site 000023 TVItemID = 202466
            TVItemLanguage tvItemLanguageENNB_06_020_002PolSite000023 = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 202466 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENNB_06_020_002PolSite000023.TVItemID = tvItemNB_06_020_002PolSite000023.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENNB_06_020_002PolSite000023)) return false;

            // TVItemLanguage FR Subsector NB-06_020_002 Pol Source Site 000023 TVItemID = 202466
            TVItemLanguage tvItemLanguageFRNB_06_020_002PolSite000023 = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 202466 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRNB_06_020_002PolSite000023.TVItemID = tvItemNB_06_020_002PolSite000023.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020_002PolSite000023)) return false;
            #endregion TVItem Subsector NB-06_020_002 Pol Source Site 000023
            #region PolSourceSite, PolSourceObservation, PolSourceObservationIssue Subsector NB-06_020_002 Pol Source Site 000023

            // PolSourceSite with PolSourceSiteTVItemID = 202466
            PolSourceSite polSourceSitePolSite000023 = dbCSSPWebToolsDBRead.PolSourceSites.AsNoTracking().Where(c => c.PolSourceSiteTVItemID == 202466).FirstOrDefault();
            int PolSourceSiteID = polSourceSitePolSite000023.PolSourceSiteID;
            polSourceSitePolSite000023.PolSourceSiteTVItemID = tvItemNB_06_020_002PolSite000023.TVItemID;
            if (!AddObject("PolSourceSite", polSourceSitePolSite000023)) return false;

            // PolSourceObservation with PolSourceSiteTVItemID = 202466
            PolSourceObservation polSourceSitePolSite000023Obs = dbCSSPWebToolsDBRead.PolSourceObservations.AsNoTracking().Where(c => c.PolSourceSiteID == PolSourceSiteID).FirstOrDefault();
            int PolSourceObservationID = polSourceSitePolSite000023Obs.PolSourceObservationID;
            polSourceSitePolSite000023Obs.ContactTVItemID = contactCharles.ContactTVItemID;
            polSourceSitePolSite000023Obs.PolSourceSiteID = polSourceSitePolSite000023.PolSourceSiteID;
            if (!AddObject("PolSourceObservation", polSourceSitePolSite000023Obs)) return false;

            // PolSourceObservationIssue with PolSourceSiteTVItemID = 202466
            PolSourceObservationIssue polSourceSitePolSite000023ObsIssue = dbCSSPWebToolsDBRead.PolSourceObservationIssues.AsNoTracking().Where(c => c.PolSourceObservationID == PolSourceObservationID).FirstOrDefault();
            int PolSourceObservationIssueID = polSourceSitePolSite000023ObsIssue.PolSourceObservationIssueID;
            polSourceSitePolSite000023ObsIssue.PolSourceObservationID = polSourceSitePolSite000023Obs.PolSourceSiteID;
            if (!AddObject("PolSourceObservationIssue", polSourceSitePolSite000023ObsIssue)) return false;
            #endregion PolSourceSite, PolSourceObservation, PolSourceObservationIssue Subsector NB-06_020_002 Pol Source Site 000023
            #region PolSourceSite, PolSourceObservation, PolSourceObservationIssue Subsector NB-06_020_002 Pol Source Site 000024

            // TVItem Subsector NB-06_020_002 Pol Source Site 000024 TVItemID = 202467
            TVItem tvItemNB_06_020_002PolSite000024 = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 202467).FirstOrDefault();
            tvItemNB_06_020_002PolSite000024.ParentID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("TVItem", tvItemNB_06_020_002PolSite000024)) return false;
            if (!CorrectTVPath(tvItemNB_06_020_002PolSite000024, tvItemNB_06_020_002)) return false;
            if (!AddMapInfo(tvItemNB_06_020_002PolSite000024, 202467)) return false;

            // TVItemLanguage EN NB-06_020_001 TVItemID = 202467
            TVItemLanguage tvItemLanguageENNB_06_020_00PolSite000024 = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 202467 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENNB_06_020_00PolSite000024.TVItemID = tvItemNB_06_020_002PolSite000024.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENNB_06_020_00PolSite000024)) return false;

            // TVItemLanguage FR NB_06_020 TVItemID = 202467
            TVItemLanguage tvItemLanguageFRNB_06_020_002PolSite000024 = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 202467 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRNB_06_020_002PolSite000024.TVItemID = tvItemNB_06_020_002PolSite000024.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020_002PolSite000024)) return false;
            #endregion PolSourceSite, PolSourceObservation, PolSourceObservationIssue Subsector NB-06_020_002 Pol Source Site 000024
            #region TVItem SamplingPlan, SamplingPlanSubsector, SamplingPlanSubsectorSite

            // NB TVItem Sampling Plan with SamplingPlanID = 42 and TVFileTVItemID = 322276
            TVItem tvItemNBSamplingPlanFileTVItem = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 322276).FirstOrDefault();
            tvItemNBSamplingPlanFileTVItem.ParentID = tvItemNB.TVItemID;
            if (!AddObject("TVItem", tvItemNBSamplingPlanFileTVItem)) return false;
            if (!CorrectTVPath(tvItemNBSamplingPlanFileTVItem, tvItemNB)) return false;
            if (!AddMapInfo(tvItemNBSamplingPlanFileTVItem, 322276)) return false;

            // NB EN TVItem Sampling Plan with SamplingPlanID = 42 and TVFileTVItemID = 322276
            TVItemLanguage tvItemLanguageENNBSamplingPlanFileTVItem = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 322276 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENNBSamplingPlanFileTVItem.TVItemID = tvItemNBSamplingPlanFileTVItem.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENNBSamplingPlanFileTVItem)) return false;

            // NB FR TVItem Sampling Plan with SamplingPlanID = 42 and TVFileTVItemID = 322276
            TVItemLanguage tvItemLanguageFRNBSamplingPlanFileTVItem = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 322276 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRNBSamplingPlanFileTVItem.TVItemID = tvItemNBSamplingPlanFileTVItem.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRNBSamplingPlanFileTVItem)) return false;

            // NB TVFile Sampling Plan with SamplingPlanID = 42 and TVFileTVItemID = 322276
            TVFile tvFile = dbCSSPWebToolsDBRead.TVFiles.AsNoTracking().Where(c => c.TVFileTVItemID == 322276).FirstOrDefault();
            //int TVFileID = tvFile.TVFileID;
            tvFile.TVFileTVItemID = tvItemNBSamplingPlanFileTVItem.TVItemID;
            if (!AddObject("TVFile", tvFile)) return false;

            // NB Sampling Plan with SamplingPlanID = 42
            SamplingPlan samplingPlan = dbCSSPWebToolsDBRead.SamplingPlans.AsNoTracking().Where(c => c.SamplingPlanID == 42).FirstOrDefault();
            int SamplingPlanID = samplingPlan.SamplingPlanID;
            samplingPlan.CreatorTVItemID = tvItemContactCharles.TVItemID;
            samplingPlan.SamplingPlanFileTVItemID = tvFile.TVFileTVItemID;
            if (!AddObject("SamplingPlan", samplingPlan)) return false;

            // NB Sampling Plan with SamplingPlanID = 42 with SubsectorTVItemID = 635 (Bouctouche harbour)
            SamplingPlanSubsector samplingPlanSubsector = dbCSSPWebToolsDBRead.SamplingPlanSubsectors.AsNoTracking().Where(c => c.SamplingPlanID == 42 && c.SubsectorTVItemID == 635).FirstOrDefault();
            int SamplingPlanSubsectorID = samplingPlanSubsector.SamplingPlanSubsectorID;
            samplingPlanSubsector.SamplingPlanID = samplingPlan.SamplingPlanID;
            samplingPlanSubsector.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("SamplingPlanSubsector", samplingPlanSubsector)) return false;

            // NB Sampling Plan with SamplingPlanID = 42 with SubsectorTVItemID = 635 (Bouctouche harbour)
            SamplingPlanSubsectorSite samplingPlanSubsectorSite0001 = dbCSSPWebToolsDBRead.SamplingPlanSubsectorSites.AsNoTracking().Where(c => c.SamplingPlanSubsectorID == SamplingPlanSubsectorID && c.MWQMSiteTVItemID == 7460).FirstOrDefault();
            samplingPlanSubsectorSite0001.SamplingPlanSubsectorID = samplingPlanSubsector.SamplingPlanSubsectorID;
            samplingPlanSubsectorSite0001.MWQMSiteTVItemID = tvItemNB_06_020_002Site0001.TVItemID;
            if (!AddObject("SamplingPlanSubsectorSite", samplingPlanSubsectorSite0001)) return false;

            // NB Sampling Plan with SamplingPlanID = 42 with SubsectorTVItemID = 635 (Bouctouche harbour)
            SamplingPlanSubsectorSite samplingPlanSubsectorSite0002 = dbCSSPWebToolsDBRead.SamplingPlanSubsectorSites.AsNoTracking().Where(c => c.SamplingPlanSubsectorID == SamplingPlanSubsectorID && c.MWQMSiteTVItemID == 7462).FirstOrDefault();
            samplingPlanSubsectorSite0002.SamplingPlanSubsectorID = samplingPlanSubsector.SamplingPlanSubsectorID;
            samplingPlanSubsectorSite0002.MWQMSiteTVItemID = tvItemNB_06_020_002Site0002.TVItemID;
            if (!AddObject("SamplingPlanSubsectorSite", samplingPlanSubsectorSite0002)) return false;
            #endregion TVItem SamplingPlan, SamplingPlanSubsector, SamplingPlanSubsectorSite
            #region TVItem MWQMRun with Subsector NB-06_020_002 and MWQMSite 0001

            // TVItem MWQMRun with Subsector NB-06_020_002 TVItemID = 635 MWQMSite 0001 TVItemID = 7460 MWQMRunTVItemID = 324152
            TVItem tvItemRun = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 324152).FirstOrDefault();
            tvItemRun.ParentID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("TVItem", tvItemRun)) return false;
            if (!CorrectTVPath(tvItemRun, tvItemNB_06_020_002)) return false;
            if (!AddMapInfo(tvItemRun, 324152)) return false;

            // TVItemLanguage EN MWQMRun with MWQMRunTVItemID = 324152
            TVItemLanguage tvItemLanguageENMWQMRun = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 324152 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENMWQMRun.TVItemID = tvItemRun.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENMWQMRun)) return false;

            // TVItemLanguage FR NB_06_020 TVItemID = 324152
            TVItemLanguage tvItemLanguageFRMWQMRun = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 324152 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRMWQMRun.TVItemID = tvItemRun.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRMWQMRun)) return false;

            // TVItem MWQMRun with Subsector NB-06_020_002 TVItemID = 635 MWQMSite 0001 TVItemID = 7460 MWQMRunTVItemID = 324152
            MWQMRun mwqmRun = dbCSSPWebToolsDBRead.MWQMRuns.AsNoTracking().Where(c => c.MWQMRunTVItemID == 324152).FirstOrDefault();
            int MWQMRunID = mwqmRun.MWQMRunID;
            mwqmRun.MWQMRunTVItemID = tvItemRun.TVItemID;
            mwqmRun.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
            mwqmRun.LabSampleApprovalContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("MWQMRun", mwqmRun)) return false;

            // MWQMRunLanguage EN MWQMRun with MWQMRunTVItemID = 324152
            MWQMRunLanguage MWQMRunLanguageEN = dbCSSPWebToolsDBRead.MWQMRunLanguages.AsNoTracking().Where(c => c.MWQMRunID == MWQMRunID && c.Language == LanguageEnum.en).FirstOrDefault();
            MWQMRunLanguageEN.MWQMRunID = mwqmRun.MWQMRunID;
            if (!AddObject("MWQMRunLanguage", MWQMRunLanguageEN)) return false;

            // MWQMRunLanguage FR MWQMRun with MWQMRunTVItemID = 324152
            MWQMRunLanguage MWQMRunLanguageFR = dbCSSPWebToolsDBRead.MWQMRunLanguages.AsNoTracking().Where(c => c.MWQMRunID == MWQMRunID && c.Language == LanguageEnum.en).FirstOrDefault();
            MWQMRunLanguageFR.MWQMRunID = mwqmRun.MWQMRunID;
            if (!AddObject("MWQMRunLanguage", MWQMRunLanguageFR)) return false;
            #endregion TVItem MWQMRun with Subsector NB-06_020_002 and MWQMSite 0001
            #region UseOfSite

            // NB UseOfSite with SubsectorTVItemID = 635 ClimateSiteTVItemID = 229528
            UseOfSite useOfSite = dbCSSPWebToolsDBRead.UseOfSites.AsNoTracking().Where(c => c.SubsectorTVItemID == 635 && c.SiteTVItemID == 229528).FirstOrDefault();
            useOfSite.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
            useOfSite.SiteTVItemID = tvItemNBClimateSiteBouctoucheCDA.TVItemID;
            if (!AddObject("UseOfSite", useOfSite)) return false;
            #endregion UseOfSite
            #region MWQMSamples

            // NB MWQMSamples with MWQMSiteTVItemID = 7460 and MWQMRunTVItemID = 324152
            MWQMSample mwqmSample = dbCSSPWebToolsDBRead.MWQMSamples.AsNoTracking().Where(c => c.MWQMSiteTVItemID == 7460 && c.MWQMRunTVItemID == 324152).FirstOrDefault();
            int MWQMSampleID = mwqmSample.MWQMSampleID;
            mwqmSample.MWQMSiteTVItemID = tvItemNB_06_020_002Site0001.TVItemID;
            mwqmSample.MWQMRunTVItemID = tvItemRun.TVItemID;
            if (!AddObject("MWQMSample", mwqmSample)) return false;

            // NB MWQMSampleLanguages EN with MWQMSiteTVItemID = 7460 and MWQMRunTVItemID = 324152
            MWQMSampleLanguage mwqmSampleLanguageEN = dbCSSPWebToolsDBRead.MWQMSampleLanguages.AsNoTracking().Where(c => c.MWQMSampleID == MWQMSampleID && c.Language == LanguageEnum.en).FirstOrDefault();
            mwqmSampleLanguageEN.MWQMSampleID = mwqmSample.MWQMSampleID;
            if (!AddObject("MWQMSampleLanguage", mwqmSampleLanguageEN)) return false;

            // NB MWQMSampleLanguages FR with MWQMSiteTVItemID = 7460 and MWQMRunTVItemID = 324152
            MWQMSampleLanguage mwqmSampleLanguageFR = dbCSSPWebToolsDBRead.MWQMSampleLanguages.AsNoTracking().Where(c => c.MWQMSampleID == MWQMSampleID && c.Language == LanguageEnum.fr).FirstOrDefault();
            mwqmSampleLanguageFR.MWQMSampleID = mwqmSample.MWQMSampleID;
            if (!AddObject("MWQMSampleLanguage", mwqmSampleLanguageFR)) return false;
            #endregion MWQMSamples
            #region MWQMSite, MWQMSiteStartEndDate

            // NB MWQMSite with MWQMSiteTVItemID = 7460
            MWQMSite mwqmSite0001 = dbCSSPWebToolsDBRead.MWQMSites.AsNoTracking().Where(c => c.MWQMSiteTVItemID == 7460).FirstOrDefault();
            mwqmSite0001.MWQMSiteTVItemID = tvItemNB_06_020_002Site0001.TVItemID;
            if (!AddObject("MWQMSite", mwqmSite0001)) return false;

            // MWQMSiteStartEndDate with MWQMSiteTVItemID = 7460
            MWQMSiteStartEndDate mwqmSiteStartEndDate0001 = dbCSSPWebToolsDBRead.MWQMSiteStartEndDates.AsNoTracking().Where(c => c.MWQMSiteTVItemID == MWQMSiteID0001).FirstOrDefault();
            mwqmSiteStartEndDate0001.MWQMSiteTVItemID = tvItemNB_06_020_002Site0001.TVItemID;
            if (!AddObject("MWQMSiteStartEndDate", mwqmSiteStartEndDate0001)) return false;

            // NB MWQMSite with MWQMSiteTVItemID = 7462
            MWQMSite mwqmSite0002 = dbCSSPWebToolsDBRead.MWQMSites.AsNoTracking().Where(c => c.MWQMSiteTVItemID == 7462).FirstOrDefault();
            mwqmSite0002.MWQMSiteTVItemID = tvItemNB_06_020_002Site0002.TVItemID;
            if (!AddObject("MWQMSite", mwqmSite0002)) return false;

            // MWQMSiteStartEndDate with MWQMSiteTVItemID = 7462
            MWQMSiteStartEndDate mwqmSiteStartEndDate0002 = dbCSSPWebToolsDBRead.MWQMSiteStartEndDates.AsNoTracking().Where(c => c.MWQMSiteTVItemID == MWQMSiteID0001).FirstOrDefault();
            mwqmSiteStartEndDate0002.MWQMSiteTVItemID = tvItemNB_06_020_002Site0002.TVItemID;
            if (!AddObject("MWQMSiteStartEndDate", mwqmSiteStartEndDate0002)) return false;
            #endregion MWQMSite, MWQMSiteStartEndDate
            #region MikeScenario, MikeBoundaryCondition, MikeSource, MikeSourceStartEnd

            // TVItem MikeScenario with MikeScenairoTVItemID = 28475 under Bouctouche
            TVItem tvItemMikeScenario = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 28475).FirstOrDefault();
            int MikeScenarioTVItemID = tvItemMikeScenario.TVItemID;
            tvItemMikeScenario.ParentID = tvItemBouctouche.TVItemID;
            if (!AddObject("TVItem", tvItemMikeScenario)) return false;
            if (!CorrectTVPath(tvItemMikeScenario, tvItemBouctouche)) return false;
            if (!AddMapInfo(tvItemMikeScenario, 28475)) return false;

            // TVItem MikeScenario with MikeScenairoTVItemID = 28475 under Bouctouche
            TVItemLanguage tvItemLanguageENMikeScenario = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28475 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENMikeScenario.TVItemID = tvItemMikeScenario.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENMikeScenario)) return false;

            // TVItem MikeScenario with MikeScenairoTVItemID = 28475 under Bouctouche
            TVItemLanguage tvItemLanguageFRMikeScenario = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28475 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRMikeScenario.TVItemID = tvItemMikeScenario.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRMikeScenario)) return false;

            // MikeScenario with MikeScenairoTVItemID = 28475 under Bouctouche
            MikeScenario mikeScenario = dbCSSPWebToolsDBRead.MikeScenarios.AsNoTracking().Where(c => c.MikeScenarioTVItemID == 28475).FirstOrDefault();
            int MikeScenarioID = mikeScenario.MikeScenarioID;
            mikeScenario.MikeScenarioTVItemID = tvItemMikeScenario.TVItemID;
            if (!AddObject("MikeScenario", mikeScenario)) return false;

            // TVItem MikeBoundaryCondition with MikeBoundaryConditionTVItemID = 92456 under Bouctouche
            TVItem tvItemMikeBoundaryCondition = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 92456).FirstOrDefault();
            tvItemMikeBoundaryCondition.ParentID = tvItemMikeScenario.TVItemID;
            if (!AddObject("TVItem", tvItemMikeBoundaryCondition)) return false;
            if (!CorrectTVPath(tvItemMikeBoundaryCondition, tvItemMikeScenario)) return false;
            if (!AddMapInfo(tvItemMikeBoundaryCondition, 92456)) return false;

            // TVItem MikeBoundaryCondition with MikeBoundaryConditionTVItemID = 92456 under Bouctouche
            TVItemLanguage tvItemLanguageENMikeBoundaryCondition = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 92456 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENMikeBoundaryCondition.TVItemID = tvItemMikeBoundaryCondition.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENMikeBoundaryCondition)) return false;

            // TVItem MikeBoundaryCondition with MikeBoundaryConditionTVItemID = 92456 under Bouctouche
            TVItemLanguage tvItemLanguageFRMikeBoundaryCondition = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 92456 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRMikeBoundaryCondition.TVItemID = tvItemMikeBoundaryCondition.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRMikeBoundaryCondition)) return false;

            // MikeBoundaryCondition with MikeBoundaryConditionTVItemID = 92456 under Bouctouche
            MikeBoundaryCondition mikeBoundaryCondition = dbCSSPWebToolsDBRead.MikeBoundaryConditions.AsNoTracking().Where(c => c.MikeBoundaryConditionTVItemID == 92456).FirstOrDefault();
            mikeBoundaryCondition.MikeBoundaryConditionTVItemID = tvItemMikeBoundaryCondition.TVItemID;
            if (!AddObject("MikeBoundaryCondition", mikeBoundaryCondition)) return false;

            // TVItem MikeSource with MikeSourceTVItemID = 28476 under Bouctouche WWTP
            TVItem tvItemMikeSource = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 28476).FirstOrDefault();
            tvItemMikeSource.ParentID = tvItemMikeScenario.TVItemID;
            if (!AddObject("TVItem", tvItemMikeSource)) return false;
            if (!CorrectTVPath(tvItemMikeSource, tvItemMikeScenario)) return false;
            if (!AddMapInfo(tvItemMikeSource, 28476)) return false;

            // TVItem MikeSource with MikeSourceTVItemID = 28476 under Bouctouche
            TVItemLanguage tvItemLanguageENMikeSource = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28476 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENMikeSource.TVItemID = tvItemMikeSource.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENMikeSource)) return false;

            // TVItem MikeSource with MikeSourceTVItemID = 28476 under Bouctouche
            TVItemLanguage tvItemLanguageFRMikeSource = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28476 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRMikeSource.TVItemID = tvItemMikeSource.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRMikeSource)) return false;

            // MikeSource with MikeSourceTVItemID = 28476 under Bouctouche
            MikeSource mikeSource = dbCSSPWebToolsDBRead.MikeSources.AsNoTracking().Where(c => c.MikeSourceTVItemID == 28476).FirstOrDefault();
            int MikeSourceID = mikeSource.MikeSourceID;
            mikeSource.MikeSourceTVItemID = tvItemMikeSource.TVItemID;
            if (!AddObject("MikeSource", mikeSource)) return false;

            // MikeSourceStartEnd with MikeSourceTVItemID = 28476 under Bouctouche
            MikeSourceStartEnd mikeSourceStartEnd = dbCSSPWebToolsDBRead.MikeSourceStartEnds.AsNoTracking().Where(c => c.MikeSourceID == MikeSourceID).FirstOrDefault();
            mikeSourceStartEnd.MikeSourceID = mikeSource.MikeSourceID;
            if (!AddObject("MikeSourceStartEnd", mikeSourceStartEnd)) return false;
            #endregion MikeScenario, MikeBoundaryCondition, MikeSource, MikeSourceStartEnd
            #region LabSheet, LabSheetDetail, LabSheetTubeMPNDetail

            // LabSheet with SubsectorTVItemID = 635 and MWQMRunTVItemID = 324152 under Bouctouche harbour subsector
            LabSheet labSheet = dbCSSPWebToolsDBRead.LabSheets.AsNoTracking().Where(c => c.SubsectorTVItemID == 635 && c.MWQMRunTVItemID == 324152).FirstOrDefault();
            int LabSheetID = labSheet.LabSheetID;
            labSheet.MWQMRunTVItemID = tvItemRun.TVItemID;
            labSheet.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
            labSheet.AcceptedOrRejectedByContactTVItemID = tvItemContactCharles.TVItemID;
            labSheet.SamplingPlanID = samplingPlan.SamplingPlanID;
            if (!AddObject("LabSheet", labSheet)) return false;

            // LabSheetDetail with SubsectorTVItemID = 635 and MWQMRunTVItemID = 324152 under Bouctouche harbour subsector
            LabSheetDetail labSheetDetail = dbCSSPWebToolsDBRead.LabSheetDetails.AsNoTracking().Where(c => c.LabSheetID == LabSheetID).FirstOrDefault();
            int LabSheetDetailID = labSheetDetail.LabSheetDetailID;
            labSheetDetail.LabSheetID = labSheet.LabSheetID;
            labSheetDetail.SamplingPlanID = samplingPlan.SamplingPlanID;
            labSheetDetail.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("LabSheetDetail", labSheetDetail)) return false;

            // LabSheetTubeMPNDetail with SubsectorTVItemID = 635 and MWQMRunTVItemID = 324152 and MWQMSiteTVItemID = 7460 under Bouctouche harbour subsector
            LabSheetTubeMPNDetail labSheetTubeMPNDetail = dbCSSPWebToolsDBRead.LabSheetTubeMPNDetails.AsNoTracking().Where(c => c.LabSheetDetailID == LabSheetDetailID && c.MWQMSiteTVItemID == 7460).FirstOrDefault();
            labSheetTubeMPNDetail.LabSheetDetailID = labSheetDetail.LabSheetDetailID;
            labSheetTubeMPNDetail.MWQMSiteTVItemID = tvItemNB_06_020_002Site0001.TVItemID;
            if (!AddObject("LabSheetTubeMPNDetail", labSheetTubeMPNDetail)) return false;
            #endregion LabSheet, LabSheetDetail, LabSheetTubeMPNDetail
            #region TVItem Address and Address

            // TVItem Address 730 Chemin de la Pointe, Richibouctou, NB E4W, Canada TVItemID = 232655
            TVItem tvItemAddress = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 232655).FirstOrDefault();
            tvItemAddress.ParentID = tvItemRoot.TVItemID;
            if (!AddObject("TVItem", tvItemAddress)) return false;
            if (!CorrectTVPath(tvItemAddress, tvItemRoot)) return false;
            if (!AddMapInfo(tvItemAddress, 232655)) return false;

            // TVItem Address 730 Chemin de la Pointe, Richibouctou, NB E4W, Canada TVItemID = 232655
            TVItemLanguage tvItemLanguageENAddress = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 232655 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENAddress.TVItemID = tvItemAddress.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENAddress)) return false;

            // TVItem Address 730 Chemin de la Pointe, Richibouctou, NB E4W, Canada TVItemID = 232655
            TVItemLanguage tvItemLanguageFRAddress = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 232655 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRAddress.TVItemID = tvItemAddress.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRAddress)) return false;

            // Address 730 Chemin de la Pointe, Richibouctou, NB E4W, Canada TVItemID = 232655
            Address address = dbCSSPWebToolsDBRead.Addresses.AsNoTracking().Where(c => c.AddressTVItemID == 232655).FirstOrDefault();
            address.AddressTVItemID = tvItemAddress.TVItemID;
            address.CountryTVItemID = tvItemCanada.TVItemID;
            address.ProvinceTVItemID = tvItemNB.TVItemID;
            address.MunicipalityTVItemID = tvItemBouctouche.TVItemID;
            if (!AddObject("Address", address)) return false;
            #endregion TVItem Address and Address
            #region TVItem Email and Email

            // Email Charles.LeBlanc@ec.gc.ca TVItemID = 110249
            TVItem tvItemEmail = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 110249).FirstOrDefault();
            tvItemEmail.ParentID = tvItemRoot.TVItemID;
            if (!AddObject("TVItem", tvItemEmail)) return false;
            if (!CorrectTVPath(tvItemEmail, tvItemRoot)) return false;
            if (!AddMapInfo(tvItemEmail, 110249)) return false;

            // Email Charles.LeBlanc@ec.gc.ca TVItemID = 110249
            TVItemLanguage tvItemLanguageENEmail = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 110249 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENEmail.TVItemID = tvItemEmail.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENEmail)) return false;

            // Email Charles.LeBlanc@ec.gc.ca TVItemID = 110249
            TVItemLanguage tvItemLanguageFREmail = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 110249 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFREmail.TVItemID = tvItemEmail.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFREmail)) return false;

            // Email Charles.LeBlanc@ec.gc.ca TVItemID = 110249
            Email email = dbCSSPWebToolsDBRead.Emails.AsNoTracking().Where(c => c.EmailTVItemID == 110249).FirstOrDefault();
            email.EmailTVItemID = tvItemEmail.TVItemID;
            if (!AddObject("Email", email)) return false;
            #endregion TVItem Email and Email
            #region TVItem Tel and Tel

            // Tel Charles.LeBlanc@ec.gc.ca TVItemID = 108984
            TVItem tvItemTel = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 108984).FirstOrDefault();
            tvItemTel.ParentID = tvItemRoot.TVItemID;
            if (!AddObject("TVItem", tvItemTel)) return false;
            if (!CorrectTVPath(tvItemTel, tvItemRoot)) return false;
            if (!AddMapInfo(tvItemTel, 108984)) return false;

            // Tel Charles.LeBlanc@ec.gc.ca TVItemID = 108984
            TVItemLanguage tvItemLanguageENTel = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 108984 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENTel.TVItemID = tvItemTel.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENTel)) return false;

            // Tel Charles.LeBlanc@ec.gc.ca TVItemID = 108984
            TVItemLanguage tvItemLanguageFRTel = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 108984 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRTel.TVItemID = tvItemTel.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRTel)) return false;

            // Tel Charles.LeBlanc@ec.gc.ca TVItemID = 108984
            Tel tel = dbCSSPWebToolsDBRead.Tels.AsNoTracking().Where(c => c.TelTVItemID == 108984).FirstOrDefault();
            tel.TelTVItemID = tvItemTel.TVItemID;
            if (!AddObject("Tel", tel)) return false;
            #endregion TVItem Tel and Tel
            #region TVItemLink

            TVItemLink tvItemLinkMunicContact = dbCSSPWebToolsDBRead.TVItemLinks.AsNoTracking().Where(c => c.FromTVItemID == 27764 && c.ToTVItemID == 305006).FirstOrDefault();
            tvItemLinkMunicContact.FromTVItemID = tvItemBouctouche.TVItemID;
            tvItemLinkMunicContact.ToTVItemID = tvItemContactCharles.TVItemID;
            tvItemLinkMunicContact.TVPath = "p" + tvItemBouctouche.TVItemID.ToString() + "p" + tvItemContactCharles.TVItemID.ToString();
            if (!AddObject("TVItemLink", tvItemLinkMunicContact)) return false;

            TVItemLink tvItemLinkContactTel = dbCSSPWebToolsDBRead.TVItemLinks.AsNoTracking().Where(c => c.FromTVItemID == 305006 && c.ToTVItemID == 305007).FirstOrDefault();
            tvItemLinkContactTel.FromTVItemID = tvItemContactCharles.TVItemID;
            tvItemLinkContactTel.ToTVItemID = tvItemTel.TVItemID;
            tvItemLinkContactTel.TVPath = "p" + tvItemContactCharles.TVItemID.ToString() + "p" + tvItemTel.TVItemID.ToString();
            if (!AddObject("TVItemLink", tvItemLinkContactTel)) return false;

            TVItemLink tvItemLinkContactEmail = dbCSSPWebToolsDBRead.TVItemLinks.AsNoTracking().Where(c => c.FromTVItemID == 305006 && c.ToTVItemID == 305007).FirstOrDefault();
            tvItemLinkContactEmail.FromTVItemID = tvItemContactCharles.TVItemID;
            tvItemLinkContactEmail.ToTVItemID = tvItemEmail.TVItemID;
            tvItemLinkContactEmail.TVPath = "p" + tvItemContactCharles.TVItemID.ToString() + "p" + tvItemEmail.TVItemID.ToString();
            if (!AddObject("TVItemLink", tvItemLinkContactEmail)) return false;
            #endregion TVItemLink

            return true;
        }
        private bool AddMapInfo(TVItem NewTVItem, int OldTVItemID)
        {
            List<MapInfo> mapInfoList = (from c in dbCSSPWebToolsDBRead.MapInfos.AsNoTracking()
                                         where c.TVItemID == OldTVItemID
                                         select c).ToList();
            int MapInfoID = 0;
            foreach (MapInfo mapInfo in mapInfoList)
            {
                MapInfoID = mapInfo.MapInfoID;

                mapInfo.TVItemID = NewTVItem.TVItemID;

                mapInfo.MapInfoID = 0;
                dbTestDBWrite.MapInfos.Add(mapInfo);
                try
                {
                    dbTestDBWrite.SaveChanges();
                }
                catch (Exception ex)
                {
                    ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                    return false;
                }

                List<MapInfoPoint> mapInfoPointList = (from c in dbCSSPWebToolsDBRead.MapInfoPoints.AsNoTracking()
                                                       where c.MapInfoID == MapInfoID
                                                       select c).ToList();

                foreach (MapInfoPoint mapInfoPoint in mapInfoPointList)
                {
                    mapInfoPoint.MapInfoPointID = 0;
                    mapInfoPoint.MapInfoID = mapInfo.MapInfoID;
                    mapInfo.MapInfoPoints.Add(mapInfoPoint);
                }

                try
                {
                    dbTestDBWrite.SaveChanges();
                }
                catch (Exception ex)
                {
                    ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                    return false;
                }
            }
            return true;
        }
        private bool AddObject(string TypeName, object objTarget)
        {
            switch (TypeName)
            {
                case "Address":
                    {
                        ((Address)objTarget).AddressID = 0;
                        ((Address)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.Addresses.Add((Address)objTarget);
                    }
                    break;
                case "BoxModel":
                    {
                        ((BoxModel)objTarget).BoxModelID = 0;
                        ((BoxModel)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.BoxModels.Add((BoxModel)objTarget);
                    }
                    break;
                case "BoxModelLanguage":
                    {
                        ((BoxModelLanguage)objTarget).BoxModelLanguageID = 0;
                        ((BoxModelLanguage)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.BoxModelLanguages.Add((BoxModelLanguage)objTarget);
                    }
                    break;
                case "BoxModelResult":
                    {
                        ((BoxModelResult)objTarget).BoxModelResultID = 0;
                        ((BoxModelResult)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.BoxModelResults.Add((BoxModelResult)objTarget);
                    }
                    break;
                case "ClimateDataValue":
                    {
                        ((ClimateDataValue)objTarget).ClimateDataValueID = 0;
                        ((ClimateDataValue)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.ClimateDataValues.Add((ClimateDataValue)objTarget);
                    }
                    break;
                case "ClimateSite":
                    {
                        ((ClimateSite)objTarget).ClimateSiteID = 0;
                        ((ClimateSite)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.ClimateSites.Add((ClimateSite)objTarget);
                    }
                    break;
                case "Contact":
                    {
                        ((Contact)objTarget).ContactID = 0;
                        ((Contact)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.Contacts.Add((Contact)objTarget);
                    }
                    break;
                case "ContactLogin":
                    {
                        ((ContactLogin)objTarget).ContactLoginID = 0;
                        ((ContactLogin)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.ContactLogins.Add((ContactLogin)objTarget);
                    }
                    break;
                case "Email":
                    {
                        ((Email)objTarget).EmailID = 0;
                        ((Email)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.Emails.Add((Email)objTarget);
                    }
                    break;
                case "HydrometricDataValue":
                    {
                        ((HydrometricDataValue)objTarget).HydrometricDataValueID = 0;
                        ((HydrometricDataValue)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.HydrometricDataValues.Add((HydrometricDataValue)objTarget);
                    }
                    break;
                case "HydrometricSite":
                    {
                        ((HydrometricSite)objTarget).HydrometricSiteID = 0;
                        ((HydrometricSite)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.HydrometricSites.Add((HydrometricSite)objTarget);
                    }
                    break;
                case "Infrastructure":
                    {
                        ((Infrastructure)objTarget).InfrastructureID = 0;
                        ((Infrastructure)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.Infrastructures.Add((Infrastructure)objTarget);
                    }
                    break;
                case "InfrastructureLanguage":
                    {
                        ((InfrastructureLanguage)objTarget).InfrastructureLanguageID = 0;
                        ((InfrastructureLanguage)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.InfrastructureLanguages.Add((InfrastructureLanguage)objTarget);
                    }
                    break;
                case "LabSheet":
                    {
                        ((LabSheet)objTarget).LabSheetID = 0;
                        ((LabSheet)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.LabSheets.Add((LabSheet)objTarget);
                    }
                    break;
                case "LabSheetDetail":
                    {
                        ((LabSheetDetail)objTarget).LabSheetDetailID = 0;
                        ((LabSheetDetail)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.LabSheetDetails.Add((LabSheetDetail)objTarget);
                    }
                    break;
                case "LabSheetTubeMPNDetail":
                    {
                        ((LabSheetTubeMPNDetail)objTarget).LabSheetTubeMPNDetailID = 0;
                        ((LabSheetTubeMPNDetail)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.LabSheetTubeMPNDetails.Add((LabSheetTubeMPNDetail)objTarget);
                    }
                    break;
                case "MWQMRun":
                    {
                        ((MWQMRun)objTarget).MWQMRunID = 0;
                        ((MWQMRun)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.MWQMRuns.Add((MWQMRun)objTarget);
                    }
                    break;
                case "MikeBoundaryCondition":
                    {
                        ((MikeBoundaryCondition)objTarget).MikeBoundaryConditionID = 0;
                        ((MikeBoundaryCondition)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.MikeBoundaryConditions.Add((MikeBoundaryCondition)objTarget);
                    }
                    break;
                case "MikeScenario":
                    {
                        ((MikeScenario)objTarget).MikeScenarioID = 0;
                        ((MikeScenario)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.MikeScenarios.Add((MikeScenario)objTarget);
                    }
                    break;
                case "MikeSource":
                    {
                        ((MikeSource)objTarget).MikeSourceID = 0;
                        ((MikeSource)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.MikeSources.Add((MikeSource)objTarget);
                    }
                    break;
                case "MikeSourceStartEnd":
                    {
                        ((MikeSourceStartEnd)objTarget).MikeSourceStartEndID = 0;
                        ((MikeSourceStartEnd)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.MikeSourceStartEnds.Add((MikeSourceStartEnd)objTarget);
                    }
                    break;
                case "MWQMRunLanguage":
                    {
                        ((MWQMRunLanguage)objTarget).MWQMRunLanguageID = 0;
                        ((MWQMRunLanguage)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.MWQMRunLanguages.Add((MWQMRunLanguage)objTarget);
                    }
                    break;
                case "MWQMSample":
                    {
                        ((MWQMSample)objTarget).MWQMSampleID = 0;
                        ((MWQMSample)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.MWQMSamples.Add((MWQMSample)objTarget);
                    }
                    break;
                case "MWQMSampleLanguage":
                    {
                        ((MWQMSampleLanguage)objTarget).MWQMSampleLanguageID = 0;
                        ((MWQMSampleLanguage)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.MWQMSampleLanguages.Add((MWQMSampleLanguage)objTarget);
                    }
                    break;
                case "MWQMSite":
                    {
                        ((MWQMSite)objTarget).MWQMSiteID = 0;
                        ((MWQMSite)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.MWQMSites.Add((MWQMSite)objTarget);
                    }
                    break;
                case "MWQMSiteStartEndDate":
                    {
                        ((MWQMSiteStartEndDate)objTarget).MWQMSiteStartEndDateID = 0;
                        ((MWQMSiteStartEndDate)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.MWQMSiteStartEndDates.Add((MWQMSiteStartEndDate)objTarget);
                    }
                    break;
                case "PolSourceSite":
                    {
                        ((PolSourceSite)objTarget).PolSourceSiteID = 0;
                        ((PolSourceSite)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.PolSourceSites.Add((PolSourceSite)objTarget);
                    }
                    break;
                case "PolSourceObservation":
                    {
                        ((PolSourceObservation)objTarget).PolSourceObservationID = 0;
                        ((PolSourceObservation)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.PolSourceObservations.Add((PolSourceObservation)objTarget);
                    }
                    break;
                case "PolSourceObservationIssue":
                    {
                        ((PolSourceObservationIssue)objTarget).PolSourceObservationIssueID = 0;
                        ((PolSourceObservationIssue)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.PolSourceObservationIssues.Add((PolSourceObservationIssue)objTarget);
                    }
                    break;
                case "RatingCurveValue":
                    {
                        ((RatingCurveValue)objTarget).RatingCurveValueID = 0;
                        ((RatingCurveValue)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.RatingCurveValues.Add((RatingCurveValue)objTarget);
                    }
                    break;
                case "RatingCurve":
                    {
                        ((RatingCurve)objTarget).RatingCurveID = 0;
                        ((RatingCurve)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.RatingCurves.Add((RatingCurve)objTarget);
                    }
                    break;
                case "SamplingPlan":
                    {
                        ((SamplingPlan)objTarget).SamplingPlanID = 0;
                        ((SamplingPlan)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.SamplingPlans.Add((SamplingPlan)objTarget);
                    }
                    break;
                case "SamplingPlanSubsector":
                    {
                        ((SamplingPlanSubsector)objTarget).SamplingPlanSubsectorID = 0;
                        ((SamplingPlanSubsector)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.SamplingPlanSubsectors.Add((SamplingPlanSubsector)objTarget);
                    }
                    break;
                case "SamplingPlanSubsectorSite":
                    {
                        ((SamplingPlanSubsectorSite)objTarget).SamplingPlanSubsectorSiteID = 0;
                        ((SamplingPlanSubsectorSite)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.SamplingPlanSubsectorSites.Add((SamplingPlanSubsectorSite)objTarget);
                    }
                    break;
                case "Tel":
                    {
                        ((Tel)objTarget).TelID = 0;
                        ((Tel)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.Tels.Add((Tel)objTarget);
                    }
                    break;
                case "TVFile":
                    {
                        ((TVFile)objTarget).TVFileID = 0;
                        ((TVFile)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.TVFiles.Add((TVFile)objTarget);
                    }
                    break;
                case "TVFileLanguage":
                    {
                        ((TVFileLanguage)objTarget).TVFileLanguageID = 0;
                        ((TVFileLanguage)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.TVFileLanguages.Add((TVFileLanguage)objTarget);
                    }
                    break;
                case "TVItem":
                    {
                        ((TVItem)objTarget).TVItemID = 0;
                        ((TVItem)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.TVItems.Add((TVItem)objTarget);
                    }
                    break;
                case "TVItemLanguage":
                    {
                        ((TVItemLanguage)objTarget).TVItemLanguageID = 0;
                        ((TVItemLanguage)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.TVItemLanguages.Add((TVItemLanguage)objTarget);
                    }
                    break;
                case "TVItemLink":
                    {
                        ((TVItemLink)objTarget).TVItemLinkID = 0;
                        ((TVItemLink)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.TVItemLinks.Add((TVItemLink)objTarget);
                    }
                    break;
                case "UseOfSite":
                    {
                        ((UseOfSite)objTarget).UseOfSiteID = 0;
                        ((UseOfSite)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.UseOfSites.Add((UseOfSite)objTarget);
                    }
                    break;
                case "VPAmbient":
                    {
                        ((VPAmbient)objTarget).VPAmbientID = 0;
                        ((VPAmbient)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.VPAmbients.Add((VPAmbient)objTarget);
                    }
                    break;
                case "VPResult":
                    {
                        ((VPResult)objTarget).VPResultID = 0;
                        ((VPResult)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.VPResults.Add((VPResult)objTarget);
                    }
                    break;
                case "VPScenario":
                    {
                        ((VPScenario)objTarget).VPScenarioID = 0;
                        ((VPScenario)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.VPScenarios.Add((VPScenario)objTarget);
                    }
                    break;
                case "VPScenarioLanguage":
                    {
                        ((VPScenarioLanguage)objTarget).VPScenarioLanguageID = 0;
                        ((VPScenarioLanguage)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.VPScenarioLanguages.Add((VPScenarioLanguage)objTarget);
                    }
                    break;
                default:
                    {
                        ErrorEvent(new ErrorEventArgs("Type [" + TypeName + "] not implemented"));
                        return false;
                    }
            }

            try
            {
                dbTestDBWrite.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                return false;
            }

            return true;
        }
        private bool CorrectTVPath(TVItem tvItem, TVItem tvItemParent)
        {
            tvItem.TVPath = tvItemParent.TVPath + "p" + tvItem.TVItemID.ToString();

            try
            {
                dbTestDBWrite.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                return false;
            }

            return true;
        }
        private bool LoadDBInfo(List<Table> tableList, string ConnectionString)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    cnn.Open();
                    DataTable tblList = cnn.GetSchema("Tables");
                    DataTable clmList = cnn.GetSchema("Columns");

                    foreach (DataRow tbl in tblList.Rows)
                    {
                        Table table = new Table();
                        table.TableName = tbl.ItemArray[2].ToString();
                        tableList.Add(table);

                        foreach (DataRow dr in clmList.Rows)
                        {
                            if (dr[2].ToString() == table.TableName)
                            {
                                Col col = new Col();
                                col.FieldName = dr[3].ToString();
                                col.AllowNull = (dr[6].ToString() == "NO" ? false : true);
                                col.DataType = dr[7].ToString();
                                col.StringLength = (string.IsNullOrWhiteSpace(dr[8].ToString()) ? 0 : int.Parse(dr[8].ToString()));

                                table.colList.Add(col);
                            }
                        }
                    }

                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                return false;
            }

            return true;
        }
        private bool SetTestDBDeleteOrderedList(List<Table> tableTestDBList)
        {
            List<string> ListTableToDelete = new List<string>()
            {
                "Logs",
                "RainExceedances",
                "EmailDistributionListContacts",
                "EmailDistributionLists",
                "ContactLogins",
                "AppErrLogs",
                "AppTaskLanguages",
                "AppTasks",
                "AspNetRoles",
                "AspNetUserClaims",
                "AspNetUserLogins",
                "AspNetUserRoles",
                "BoxModelLanguages",
                "BoxModelResults",
                "BoxModels",
                "UseOfSites",
                "ClimateDataValues",
                "ClimateSites",
                "DocTemplates",
                "Addresses",
                "Emails",
                "Tels",
                "RatingCurves",
                "RatingCurveValues",
                "HydrometricDataValues",
                "HydrometricSites",
                "InfrastructureLanguages",
                "Infrastructures",
                "LabSheetTubeMPNDetails",
                "LabSheetDetails",
                "LabSheets",
                "MapInfoPoints",
                "MapInfos",
                "MikeBoundaryConditions",
                "MikeSources",
                "MikeSourceStartEnds",
                "MWQMLookupMPNs",
                "SamplingPlans",
                "SamplingPlanSubsectors",
                "SamplingPlanSubsectorSites",
                "MWQMRunLanguages",
                "MWQMRuns",
                "MWQMSampleLanguages",
                "MWQMSamples",
                "MWQMSiteStartEndDates",
                "MWQMSites",
                "MWQMSubsectorLanguages",
                "MWQMSubsectors",
                "PolSourceObservationIssues",
                "PolSourceObservations",
                "PolSourceSites",
                "ResetPasswords",
                "SpillLanguages",
                "Spills",
                "TideDataValues",
                "TideLocations",
                "TideSites",
                "TVFileLanguages",
                "TVFiles",
                "TVItemLanguages",
                "TVItemLinks",
                "TVItemUserAuthorizations",
                "TVTypeUserAuthorizations",
                "VPAmbients",
                "VPResults",
                "VPScenarioLanguages",
                "VPScenarios",
                "MikeScenarios",
                "ContactPreferences",
                "ContactShortcuts",
                "Contacts",
                "AspNetUsers",
                "TVItemStats",
                "TVItems",
            };

            // checking if all table exist in the table to delete ordered list
            foreach (Table table in tableTestDBList)
            {
                if (!ListTableToDelete.Where(c => c == table.TableName).Any())
                {
                    ErrorEvent(new ErrorEventArgs(table.TableName + " is missing in the list of table to delete"));
                    return false;
                }
            }

            int OrdinalToDelete = 0;
            foreach (string s in ListTableToDelete)
            {
                OrdinalToDelete += 1;

                Table table = (from c in tableTestDBList
                               where c.TableName == s
                               select c).FirstOrDefault();

                if (table == null)
                {
                    ErrorEvent(new ErrorEventArgs(s + " is missing in the list of table"));
                    return false;
                }

                table.ordinalToDelete = OrdinalToDelete;
            }

            return true;
        }
        #endregion Functions private
    }
}
