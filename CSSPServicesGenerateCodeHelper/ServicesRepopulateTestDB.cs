using System;
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
using CSSPGenerateCodeBase;
using System.Configuration;

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
            string CSSPWebToolsDBConnectionString = ConfigurationManager.ConnectionStrings["CSSPWebToolsDB"].ConnectionString;
            string TestDBConnectionString = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
            if (System.Environment.UserName == "Charles")
            {
                CSSPWebToolsDBConnectionString = CSSPWebToolsDBConnectionString.Replace("wmon01dtchlebl2", "charles-pc");
                TestDBConnectionString = TestDBConnectionString.Replace("wmon01dtchlebl2", "charles-pc");
            }

            List<Table> tableCSSPWebToolsDBList = new List<Table>();
            List<Table> tableTestDBList = new List<Table>();

            StatusPermanentEvent(new StatusEventArgs("Loading CSSPWebTools table information..."));
            if (!LoadDBInfo(tableCSSPWebToolsDBList, CSSPWebToolsDBConnectionString))
            {
                return;
            }

            StatusPermanentEvent(new StatusEventArgs("Loading TestDB table information..."));
            if (!LoadDBInfo(tableTestDBList, TestDBConnectionString))
            {
                return;
            }

            StatusPermanentEvent(new StatusEventArgs("Comparing tables ..."));
            if (!CompareDBs(tableCSSPWebToolsDBList, tableTestDBList)) return;
            StatusPermanentEvent(new StatusEventArgs("Done comparing ... everything ok"));

            StatusPermanentEvent(new StatusEventArgs("Cleaning TestDB ..."));
            if (!CleanTestDB(tableTestDBList, TestDBConnectionString)) return;
            StatusPermanentEvent(new StatusEventArgs("Done Cleaning TestDB ... everything ok"));

            StatusPermanentEvent(new StatusEventArgs("Filling TestDB ..."));
            if (!FillTestDB(tableTestDBList)) return;
            StatusPermanentEvent(new StatusEventArgs("Done Filling TestDB ... everything ok"));

            StatusPermanentEvent(new StatusEventArgs("Making sure every table within TestDB has at least 10 items ..."));
            if (!MakingSureEveryTableHasEnoughItemsInTestDB()) return;
            StatusPermanentEvent(new StatusEventArgs("Done Making sure every table within TestDB has at least 10 items"));

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
            StatusTempEvent(new StatusEventArgs("doing ... root"));
            // TVItem Root TVItemID = 1
            TVItem tvItemRoot = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == c.ParentID && c.TVLevel == 0).FirstOrDefault();
            int RootTVItemID = tvItemRoot.TVItemID;
            if (!AddObject("TVItem", tvItemRoot)) return false;

            // TVItemLanguage EN Root TVItemID = 1
            TVItemLanguage tvItemLanguageENRoot = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 1 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENRoot.TVItemID = tvItemRoot.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENRoot)) return false;

            // TVItemLanguage FR Root TVItemID = 1
            TVItemLanguage tvItemLanguageFRRoot = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 1 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRRoot.TVItemID = tvItemRoot.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRRoot)) return false;
            #endregion  TVItem Root
            #region Contact Charles with TVItem
            StatusTempEvent(new StatusEventArgs("doing ... Contact Charles with TVItem"));
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

            StatusTempEvent(new StatusEventArgs("doing ... Contact Charles with TVItem"));

            ContactService contactService = new ContactService(new GetParam(), dbTestDBWrite, 2);

            // Contact Charles G. LeBlanc
            Contact contactCharles = dbCSSPWebToolsDBRead.Contacts.AsNoTracking().Where(c => c.ContactTVItemID == 2).FirstOrDefault();
            AspNetUser aspNetUserCharles = dbCSSPWebToolsDBRead.AspNetUsers.AsNoTracking().Where(c => c.Id == contactCharles.Id).FirstOrDefault();
            if (!AddObject("AspNetUser", aspNetUserCharles)) return false;
            if (!AddObject("Contact", contactCharles)) return false;
            #endregion Contact Charles with TVItem
            #region Contact Test User 1 with TVItem
            StatusTempEvent(new StatusEventArgs("doing ... TVItem Contact and Contact Login test user 1"));
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
            AspNetUser aspNetUserTestUser1 = dbCSSPWebToolsDBRead.AspNetUsers.AsNoTracking().Where(c => c.Id == contactTestUser1.Id).FirstOrDefault();
            if (!AddObject("AspNetUser", aspNetUserTestUser1)) return false;
            if (!AddObject("Contact", contactTestUser1)) return false;
            #endregion Contact Test User 1 with TVItem
            #region Contact Test User 2 with TVItem
            StatusTempEvent(new StatusEventArgs("doing ... TVItem Contact and Contact Login test user 1"));

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
            AspNetUser aspNetUserTestUser2 = dbCSSPWebToolsDBRead.AspNetUsers.AsNoTracking().Where(c => c.Id == contactTestUser2.Id).FirstOrDefault();
            if (!AddObject("AspNetUser", aspNetUserTestUser2)) return false;
            if (!AddObject("Contact", contactTestUser2)) return false;
            #endregion Contact Test User 2 with TVItem
            #region TVItem Country Canada
            StatusTempEvent(new StatusEventArgs("doing ... Canada"));
            // TVItem Canada TVItemID = 5
            TVItem tvItemCanada = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 5).FirstOrDefault();
            tvItemCanada.ParentID = tvItemRoot.TVItemID;
            if (!AddObject("TVItem", tvItemCanada)) return false;
            if (!CorrectTVPath(tvItemCanada, tvItemRoot)) return false;
            if (!AddMapInfo(tvItemCanada, 5, tvItemContactCharles.TVItemID)) return false;

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
            StatusTempEvent(new StatusEventArgs("doing ... New Brunswick"));
            // TVItem Province NB TVItemID = 7
            TVItem tvItemNB = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 7).FirstOrDefault();
            int NBTVItemID = tvItemNB.TVItemID;
            tvItemNB.ParentID = tvItemCanada.TVItemID;
            if (!AddObject("TVItem", tvItemNB)) return false;
            if (!CorrectTVPath(tvItemNB, tvItemCanada)) return false;
            if (!AddMapInfo(tvItemNB, NBTVItemID, tvItemContactCharles.TVItemID)) return false;

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
            StatusTempEvent(new StatusEventArgs("doing ... Climate Site"));
            // TVItem ClimateSite Bouctouche CDA TVItemID = 229528
            TVItem tvItemNBClimateSiteBouctoucheCDA = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 229528).FirstOrDefault();
            tvItemNBClimateSiteBouctoucheCDA.ParentID = tvItemNB.TVItemID;
            if (!AddObject("TVItem", tvItemNBClimateSiteBouctoucheCDA)) return false;
            if (!CorrectTVPath(tvItemNBClimateSiteBouctoucheCDA, tvItemNB)) return false;
            if (!AddMapInfo(tvItemNBClimateSiteBouctoucheCDA, 229528, tvItemContactCharles.TVItemID)) return false;

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
                climateDataValue.HourlyValues = "Some value";
                if (!AddObject("ClimateDataValue", climateDataValue)) return false;
            }
            #endregion ClimateSite Bouctouche CDA
            #region TVItem HydrometricSite Big Tracadie 01BL003 
            StatusTempEvent(new StatusEventArgs("doing ... Hydrometric Site"));
            // TVItem HydrometricSite Big Tracadie 01BL003 TVItemID = 55401
            TVItem tvItemNBHydrometricSiteBigTracadie = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 55401).FirstOrDefault();
            tvItemNBHydrometricSiteBigTracadie.ParentID = tvItemNB.TVItemID;
            if (!AddObject("TVItem", tvItemNBHydrometricSiteBigTracadie)) return false;
            if (!CorrectTVPath(tvItemNBHydrometricSiteBigTracadie, tvItemNB)) return false;
            if (!AddMapInfo(tvItemNBHydrometricSiteBigTracadie, 55401, tvItemContactCharles.TVItemID)) return false;

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
            HydrometricDataValue hydrometricDataValue = new HydrometricDataValue();
            hydrometricDataValue.HydrometricSiteID = hydrometricSite.HydrometricSiteID;
            hydrometricDataValue.DateTime_Local = DateTime.Now;
            hydrometricDataValue.Keep = true;
            hydrometricDataValue.StorageDataType = StorageDataTypeEnum.Archived;
            hydrometricDataValue.Flow_m3_s = 23.4f;
            hydrometricDataValue.HourlyValues = "Some hourly values text";
            hydrometricDataValue.LastUpdateDate_UTC = DateTime.Now;
            hydrometricDataValue.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("HydrometricDataValue", hydrometricDataValue)) return false;
            #endregion HydrometricSite Big Tracadie 01BL003 
            #region RatingCurve Big Tracadie 01BL003 
            StatusTempEvent(new StatusEventArgs("doing ... Rating Curve"));

            // NB Hydrometric site Big Tracadie where HydrometricSiteTVItemID = 55401
            RatingCurve ratingCurve = dbCSSPWebToolsDBRead.RatingCurves.AsNoTracking().Where(c => c.HydrometricSiteID == HydrometricSiteID).FirstOrDefault();
            int RatingCurveID = ratingCurve.RatingCurveID;
            ratingCurve.HydrometricSiteID = hydrometricSite.HydrometricSiteID;
            if (!AddObject("RatingCurve", ratingCurve)) return false;
            #endregion RatingCurve Big Tracadie 01BL003 
            #region RatingCurveValue Big Tracadie 01BL003 
            StatusTempEvent(new StatusEventArgs("doing ... Rating Curve Value"));
            // NB Hydrometric site Big Tracadie where HydrometricSiteTVItemID = 55401
            List<RatingCurveValue> ratingCurveValueList = dbCSSPWebToolsDBRead.RatingCurveValues.AsNoTracking().Where(c => c.RatingCurveID == RatingCurveID).Take(5).ToList();
            foreach (RatingCurveValue ratingCurveValue in ratingCurveValueList)
            {
                ratingCurveValue.RatingCurveID = ratingCurve.RatingCurveID;
                if (!AddObject("RatingCurveValue", ratingCurveValue)) return false;
            }
            #endregion RatingCurve Big Tracadie 01BL003 
            #region TVItem Area NB-06 
            StatusTempEvent(new StatusEventArgs("doing ... Area NB-06"));
            // TVItem Area NB-06 TVItemID = 629
            TVItem tvItemNB_06 = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 629).FirstOrDefault();
            tvItemNB_06.ParentID = tvItemNB.TVItemID;
            if (!AddObject("TVItem", tvItemNB_06)) return false;
            if (!CorrectTVPath(tvItemNB_06, tvItemNB)) return false;
            if (!AddMapInfo(tvItemNB_06, 629, tvItemContactCharles.TVItemID)) return false;

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
            StatusTempEvent(new StatusEventArgs("doing ... Sector NB-06-020"));
            // TVItem Sector NB-06_020 TVItemID = 633
            TVItem tvItemNB_06_020 = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 633).FirstOrDefault();
            tvItemNB_06_020.ParentID = tvItemNB_06.TVItemID;
            if (!AddObject("TVItem", tvItemNB_06_020)) return false;
            if (!CorrectTVPath(tvItemNB_06_020, tvItemNB_06)) return false;
            if (!AddMapInfo(tvItemNB_06_020, 633, tvItemContactCharles.TVItemID)) return false;

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
            StatusTempEvent(new StatusEventArgs("doing ... Subsector NB-06-020-001"));
            // TVItem Subsector NB-06_020_001 TVItemID = 634
            TVItem tvItemNB_06_020_001 = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 634).FirstOrDefault();
            tvItemNB_06_020_001.ParentID = tvItemNB_06_020.TVItemID;
            if (!AddObject("TVItem", tvItemNB_06_020_001)) return false;
            if (!CorrectTVPath(tvItemNB_06_020_001, tvItemNB_06_020)) return false;
            if (!AddMapInfo(tvItemNB_06_020_001, 634, tvItemContactCharles.TVItemID)) return false;

            // TVItemLanguage EN NB-06_020_001 TVItemID = 634
            TVItemLanguage tvItemLanguageENNB_06_020_001 = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 634 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENNB_06_020_001.TVItemID = tvItemNB_06_020_001.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENNB_06_020_001)) return false;

            // TVItemLanguage FR NB_06_020 TVItemID = 634
            TVItemLanguage tvItemLanguageFRNB_06_020_001 = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 634 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRNB_06_020_001.TVItemID = tvItemNB_06_020_001.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020_001)) return false;
            #endregion TVItem Subsector NB-06_020_001 
            #region MWQMSubsector NB-06_020_001 and MWQMSubsectorLanguage
            StatusTempEvent(new StatusEventArgs("doing ... MWQM Subsector NB-06-020-001"));
            // MWQMSubsector NB-06_020_001 TVItemID = 634
            MWQMSubsector mwqmSubsector001 = dbCSSPWebToolsDBRead.MWQMSubsectors.AsNoTracking().Where(c => c.MWQMSubsectorTVItemID == 634).FirstOrDefault();
            int MWQMSubsector001ID = mwqmSubsector001.MWQMSubsectorID;
            mwqmSubsector001.MWQMSubsectorTVItemID = tvItemNB_06_020_001.TVItemID;
            if (!AddObject("MWQMSubsector", mwqmSubsector001)) return false;

            // MWQMSubsectorLanguage EN NB-06_020_001 TVItemID = 634
            MWQMSubsectorLanguage mwqmSubsector001EN = dbCSSPWebToolsDBRead.MWQMSubsectorLanguages.AsNoTracking().Where(c => c.MWQMSubsectorID == MWQMSubsector001ID && c.Language == LanguageEnum.en).FirstOrDefault();
            mwqmSubsector001EN.MWQMSubsectorID = mwqmSubsector001.MWQMSubsectorID;
            mwqmSubsector001EN.LogBook = "somthing in the logbook";
            if (!AddObject("MWQMSubsectorLanguage", mwqmSubsector001EN)) return false;

            // MWQMSubsectorLanguage FR NB-06_020_001 TVItemID = 634
            MWQMSubsectorLanguage mwqmSubsector001FR = dbCSSPWebToolsDBRead.MWQMSubsectorLanguages.AsNoTracking().Where(c => c.MWQMSubsectorID == MWQMSubsector001ID && c.Language == LanguageEnum.fr).FirstOrDefault();
            mwqmSubsector001FR.MWQMSubsectorID = mwqmSubsector001.MWQMSubsectorID;
            mwqmSubsector001FR.LogBook = "somthing in the logbook";
            if (!AddObject("MWQMSubsectorLanguage", mwqmSubsector001FR)) return false;
            #endregion TVItem Subsector NB-06_020_001 
            #region TVItem Subsector NB-06_020_002 
            StatusTempEvent(new StatusEventArgs("doing ... Subsector NB-06-020-002"));
            // TVItem Subsector NB-06_020_002 TVItemID = 635
            TVItem tvItemNB_06_020_002 = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 635).FirstOrDefault();
            tvItemNB_06_020_002.ParentID = tvItemNB_06_020.TVItemID;
            if (!AddObject("TVItem", tvItemNB_06_020_002)) return false;
            if (!CorrectTVPath(tvItemNB_06_020_002, tvItemNB_06_020)) return false;
            if (!AddMapInfo(tvItemNB_06_020_002, 635, tvItemContactCharles.TVItemID)) return false;

            // TVItemLanguage EN NB-06_020_001 TVItemID = 635
            TVItemLanguage tvItemLanguageENNB_06_020_002 = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 635 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENNB_06_020_002.TVItemID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENNB_06_020_002)) return false;

            // TVItemLanguage FR NB_06_020 TVItemID = 635
            TVItemLanguage tvItemLanguageFRNB_06_020_002 = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 635 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRNB_06_020_002.TVItemID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRNB_06_020_002)) return false;
            #endregion TVItem Subsector NB-06_020_001 
            #region MWQMSubsector NB-06_020_002 and MWQMSubsectorLanguage
            StatusTempEvent(new StatusEventArgs("doing ... MWQM Subsector NB-06-020-002"));
            // MWQMSubsector NB-06_020_002 TVItemID = 635
            MWQMSubsector mwqmSubsector002 = dbCSSPWebToolsDBRead.MWQMSubsectors.AsNoTracking().Where(c => c.MWQMSubsectorTVItemID == 635).FirstOrDefault();
            int MWQMSubsector002ID = mwqmSubsector002.MWQMSubsectorID;
            mwqmSubsector002.MWQMSubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("MWQMSubsector", mwqmSubsector002)) return false;

            // MWQMSubsectorLanguage EN NB-06_020_002 TVItemID = 635
            MWQMSubsectorLanguage mwqmSubsector002EN = dbCSSPWebToolsDBRead.MWQMSubsectorLanguages.AsNoTracking().Where(c => c.MWQMSubsectorID == MWQMSubsector002ID && c.Language == LanguageEnum.en).FirstOrDefault();
            mwqmSubsector002EN.MWQMSubsectorID = mwqmSubsector002.MWQMSubsectorID;
            mwqmSubsector002EN.LogBook = "Something in the logbook";
            if (!AddObject("MWQMSubsectorLanguage", mwqmSubsector002EN)) return false;

            // MWQMSubsectorLanguage FR NB-06_020_002 TVItemID = 635
            MWQMSubsectorLanguage mwqmSubsector002FR = dbCSSPWebToolsDBRead.MWQMSubsectorLanguages.AsNoTracking().Where(c => c.MWQMSubsectorID == MWQMSubsector002ID && c.Language == LanguageEnum.fr).FirstOrDefault();
            mwqmSubsector002FR.MWQMSubsectorID = mwqmSubsector002.MWQMSubsectorID;
            mwqmSubsector002FR.LogBook = "Something in the logbook";
            if (!AddObject("MWQMSubsectorLanguage", mwqmSubsector002FR)) return false;
            #endregion TVItem Subsector NB-06_020_002 
            #region TVItem TideSite Subsector NB-06-020-002
            StatusTempEvent(new StatusEventArgs("doing ... Tide Site"));
            // TVItem TideSite Subsector NB-06-020-002 TVItemID = 1553
            TVItem tvItemNBTideSite = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 1553).FirstOrDefault();
            tvItemNBTideSite.ParentID = tvItemNB.TVItemID;
            if (!AddObject("TVItem", tvItemNBTideSite)) return false;
            if (!CorrectTVPath(tvItemNBTideSite, tvItemNB)) return false;
            if (!AddMapInfo(tvItemNBTideSite, 229528, tvItemContactCharles.TVItemID)) return false;

            // TVItemLanguage EN Subsector NB-06-020-002 TVItemID = 1553
            TVItemLanguage tvItemLanguageENNBTideSite = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 1553 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENNBTideSite.TVItemID = tvItemNBTideSite.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENNBTideSite)) return false;

            // TVItemLanguage FR Subsector NB-06-020-002 TVItemID = 1553
            TVItemLanguage tvItemLanguageFRNBTideSite = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 1553 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRNBTideSite.TVItemID = tvItemNBTideSite.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRNBTideSite)) return false;
            #endregion TVItem TideSite Bouctouche CDA
            #region TideSite Bouctouche CDA
            // Tide Site NB-06-020-002 where TideSiteTVItemID = 1553
            TideSite TideSite = dbCSSPWebToolsDBRead.TideSites.AsNoTracking().Where(c => c.TideSiteTVItemID == 1553).FirstOrDefault();
            int TideSiteID = TideSite.TideSiteID;
            TideSite.TideSiteTVItemID = tvItemNBTideSite.TVItemID;
            if (!AddObject("TideSite", TideSite)) return false;

            // Tide Data Value NB-06-020-002 where TideSiteTVItemID = 1553
            List<TideDataValue> tideDataValueList = dbCSSPWebToolsDBRead.TideDataValues.AsNoTracking().Where(c => c.TideSiteTVItemID == 1923 /* should be 1553 bu 1553 does not have data yet */).Take(5).ToList();
            foreach (TideDataValue tideDataValue in tideDataValueList)
            {
                tideDataValue.TideSiteTVItemID = TideSite.TideSiteTVItemID;
                if (!AddObject("TideDataValue", tideDataValue)) return false;
            }
            #endregion TideSite Bouctouche CDA
            #region TVItem Municipality Bouctouche
            StatusTempEvent(new StatusEventArgs("doing ... Bouctouche"));
            // TVItem Municipality Bouctouche TVItemID = 27764
            TVItem tvItemBouctouche = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 27764).FirstOrDefault();
            tvItemBouctouche.ParentID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("TVItem", tvItemBouctouche)) return false;
            if (!CorrectTVPath(tvItemBouctouche, tvItemNB_06_020_002)) return false;
            if (!AddMapInfo(tvItemBouctouche, 27764, tvItemContactCharles.TVItemID)) return false;

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
            StatusTempEvent(new StatusEventArgs("doing ... Ste-Marie-de-Kent"));
            // TVItem Municipality Ste Marie de Kent TVItemID = 44855
            TVItem tvItemSteMarieDeKent = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 44855).FirstOrDefault();
            tvItemSteMarieDeKent.ParentID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("TVItem", tvItemSteMarieDeKent)) return false;
            if (!CorrectTVPath(tvItemSteMarieDeKent, tvItemNB_06_020_002)) return false;
            if (!AddMapInfo(tvItemSteMarieDeKent, 44855, tvItemContactCharles.TVItemID)) return false;

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
            StatusTempEvent(new StatusEventArgs("doing ... Bouctouche WWTP"));
            // TVItem Municipality Bouctouche WWTP TVItemID = 28689
            TVItem tvItemBouctoucheWWTP = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 28689).FirstOrDefault();
            tvItemBouctoucheWWTP.ParentID = tvItemBouctouche.TVItemID;
            if (!AddObject("TVItem", tvItemBouctoucheWWTP)) return false;
            if (!CorrectTVPath(tvItemBouctoucheWWTP, tvItemBouctouche)) return false;
            if (!AddMapInfo(tvItemBouctoucheWWTP, 28689, tvItemContactCharles.TVItemID)) return false;

            // TVItemLanguage EN Bouctouche WWTP TVItemID = 28689
            TVItemLanguage tvItemLanguageENBouctoucheWWTP = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28689 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENBouctoucheWWTP.TVItemID = tvItemBouctoucheWWTP.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageENBouctoucheWWTP)) return false;

            // TVItemLanguage FR Bouctouche WWTP TVItemID = 28689
            TVItemLanguage tvItemLanguageFRBouctoucheWWTP = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 28689 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRBouctoucheWWTP.TVItemID = tvItemBouctoucheWWTP.TVItemID;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRBouctoucheWWTP)) return false;
            #endregion TVItem Municipality Bouctouche WWTP 
            #region ReportType and ReportTypeLanguage
            StatusTempEvent(new StatusEventArgs("doing ... ReportTypes and ReportTypeLanguages"));
            ReportType reportType = dbCSSPWebToolsDBRead.ReportTypes.AsNoTracking().FirstOrDefault();
            int ReportTypeIDOld = reportType.ReportTypeID;
            reportType.ReportTypeID = 0;
            if (!AddObject("ReportType", reportType)) return false;

            // ReportTypeLanguage EN 
            ReportTypeLanguage reportTypeLanguageEN = dbCSSPWebToolsDBRead.ReportTypeLanguages.AsNoTracking().Where(c => c.ReportTypeID == ReportTypeIDOld && c.Language == LanguageEnum.en).FirstOrDefault();
            reportTypeLanguageEN.ReportTypeLanguageID = 0;
            reportTypeLanguageEN.ReportTypeID = reportType.ReportTypeID;
            if (!AddObject("ReportTypeLanguage", reportTypeLanguageEN)) return false;

            // ReportTypeLanguage FR 
            ReportTypeLanguage reportTypeLanguageFR = dbCSSPWebToolsDBRead.ReportTypeLanguages.AsNoTracking().Where(c => c.ReportTypeID == ReportTypeIDOld && c.Language == LanguageEnum.fr).FirstOrDefault();
            reportTypeLanguageFR.ReportTypeLanguageID = 0;
            reportTypeLanguageFR.ReportTypeID = reportType.ReportTypeID;
            if (!AddObject("ReportTypeLanguage", reportTypeLanguageFR)) return false;
            #endregion ReportType and ReportTypeLanguage
            #region ReportSection and ReportSectionLanguage
            StatusTempEvent(new StatusEventArgs("doing ... ReportSections and ReportSectionLanguages"));
            ReportSection reportSection = dbCSSPWebToolsDBRead.ReportSections.AsNoTracking().Where(c => c.ReportTypeID == ReportTypeIDOld).FirstOrDefault();
            int ReportSectionIDOld = reportSection.ReportSectionID;
            reportSection.ReportSectionID = 0;
            reportSection.ReportTypeID = reportType.ReportTypeID;
            if (!AddObject("ReportSection", reportSection)) return false;

            // ReportSectionLanguage EN 
            ReportSectionLanguage reportSectionLanguageEN = dbCSSPWebToolsDBRead.ReportSectionLanguages.AsNoTracking().Where(c => c.ReportSectionID == ReportSectionIDOld && c.Language == LanguageEnum.en).FirstOrDefault();
            reportSectionLanguageEN.ReportSectionLanguageID = 0;
            reportSectionLanguageEN.ReportSectionID = reportSection.ReportSectionID;
            if (!AddObject("ReportSectionLanguage", reportSectionLanguageEN)) return false;

            // ReportSectionLanguage FR 
            ReportSectionLanguage reportSectionLanguageFR = dbCSSPWebToolsDBRead.ReportSectionLanguages.AsNoTracking().Where(c => c.ReportSectionID == ReportSectionIDOld && c.Language == LanguageEnum.fr).FirstOrDefault();
            reportSectionLanguageFR.ReportSectionLanguageID = 0;
            reportSectionLanguageFR.ReportSectionID = reportSection.ReportSectionID;
            if (!AddObject("ReportSectionLanguage", reportSectionLanguageFR)) return false;
            #endregion ReportSection and ReportSectionLanguage
            #region TVItem TVFile Bouctouche WWTP 
            StatusTempEvent(new StatusEventArgs("doing ... Bouctouche WWTP TVFile"));
            // TVItem TVFile Bouctouche WWTP TVItemID = 28689
            TVItem TempBouctWWTP = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 28689).FirstOrDefault();
            TVItem tvItemBouctoucheWWTPTVFile = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVPath.StartsWith(TempBouctWWTP.TVPath + "p") && c.TVType == TVTypeEnum.File).FirstOrDefault();
            int TempTVItemID = tvItemBouctoucheWWTPTVFile.TVItemID;
            tvItemBouctoucheWWTPTVFile.ParentID = tvItemBouctoucheWWTP.TVItemID;
            if (!AddObject("TVItem", tvItemBouctoucheWWTPTVFile)) return false;
            if (!CorrectTVPath(tvItemBouctoucheWWTPTVFile, tvItemBouctoucheWWTP)) return false;
            if (!AddMapInfo(tvItemBouctoucheWWTPTVFile, TempTVItemID, tvItemContactCharles.TVItemID)) return false;

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
            StatusTempEvent(new StatusEventArgs("doing ... Bouctouche WWTP TVFile"));
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
            StatusTempEvent(new StatusEventArgs("doing ... Bouctouche WWTP Infrastructure"));
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
            StatusTempEvent(new StatusEventArgs("doing ... Bouctouche WWTP Infrastructure Box Model"));
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
            StatusTempEvent(new StatusEventArgs("doing ... Bouctouche WWTP Infrastructure Box Model Result"));

            // BoxModelResult Bouctouche WWTP TVItemID = 28689
            for (int i = 1; i < 6; i++)
            {
                BoxModelResult boxModelResult = dbCSSPWebToolsDBRead.BoxModelResults.AsNoTracking().Where(c => c.BoxModelID == BoxModelID && c.BoxModelResultType == (BoxModelResultTypeEnum)i).FirstOrDefault();
                boxModelResult.BoxModelID = boxModel.BoxModelID;
                if (!AddObject("BoxModelResult", boxModelResult)) return false;
            }
            #endregion BoxModelResult Bouctouche WWTP
            #region VPScenario Bouctouche WWTP 
            StatusTempEvent(new StatusEventArgs("doing ... Bouctouche WWTP Infrastructure VPScenario"));

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
            List<VPResult> VPResultList = dbCSSPWebToolsDBRead.VPResults.AsNoTracking().Where(c => c.VPScenarioID == VPScenarioID).Take(5).ToList();
            foreach (VPResult vpResult in VPResultList)
            {
                vpResult.VPScenarioID = VPScenario.VPScenarioID;
                if (!AddObject("VPResult", vpResult)) return false;
            }
            #endregion VPScenario Bouctouche WWTP 
            #region TVItem Municipality Bouctouche LS 2 Rue Acadie
            StatusTempEvent(new StatusEventArgs("doing ... Bouctouche LS 2"));

            // TVItem Municipality Bouctouche LS 2 Rue Acadie TVItemID = 28695
            TVItem tvItemBouctoucheLS2RueAcadie = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 28695).FirstOrDefault();
            tvItemBouctoucheLS2RueAcadie.ParentID = tvItemBouctouche.TVItemID;
            if (!AddObject("TVItem", tvItemBouctoucheLS2RueAcadie)) return false;
            if (!CorrectTVPath(tvItemBouctoucheLS2RueAcadie, tvItemBouctouche)) return false;
            if (!AddMapInfo(tvItemBouctoucheLS2RueAcadie, 28695, tvItemContactCharles.TVItemID)) return false;

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
            StatusTempEvent(new StatusEventArgs("doing ... Subsector NB-06-020-002 MWQM site 001"));
            // TVItem Subsector NB-06_020_002 MWQM Site 0001 TVItemID = 7460
            TVItem tvItemNB_06_020_002Site0001 = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 7460).FirstOrDefault();
            int MWQMSiteID0001 = tvItemNB_06_020_002Site0001.TVItemID;
            tvItemNB_06_020_002Site0001.ParentID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("TVItem", tvItemNB_06_020_002Site0001)) return false;
            if (!CorrectTVPath(tvItemNB_06_020_002Site0001, tvItemNB_06_020_002)) return false;
            if (!AddMapInfo(tvItemNB_06_020_002Site0001, 7460, tvItemContactCharles.TVItemID)) return false;

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
            StatusTempEvent(new StatusEventArgs("doing ... Subsector NB-06-020-002 MWQM site 002"));
            // TVItem Subsector NB-06_020_002 MWQM Site 0001 TVItemID = 7462
            TVItem tvItemNB_06_020_002Site0002 = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 7462).FirstOrDefault();
            int MWQMSiteID0002 = tvItemNB_06_020_002Site0002.TVItemID;
            tvItemNB_06_020_002Site0002.ParentID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("TVItem", tvItemNB_06_020_002Site0002)) return false;
            if (!CorrectTVPath(tvItemNB_06_020_002Site0002, tvItemNB_06_020_002)) return false;
            if (!AddMapInfo(tvItemNB_06_020_002Site0002, 7462, tvItemContactCharles.TVItemID)) return false;

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
            StatusTempEvent(new StatusEventArgs("doing ... Subsector NB-06-020-002 PolSource site 00023"));
            // TVItem Subsector NB-06_020_002 Pol Source Site 000023 TVItemID = 202466
            TVItem tvItemNB_06_020_002PolSite000023 = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 202466).FirstOrDefault();
            tvItemNB_06_020_002PolSite000023.ParentID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("TVItem", tvItemNB_06_020_002PolSite000023)) return false;
            if (!CorrectTVPath(tvItemNB_06_020_002PolSite000023, tvItemNB_06_020_002)) return false;
            if (!AddMapInfo(tvItemNB_06_020_002PolSite000023, 202466, tvItemContactCharles.TVItemID)) return false;

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
            StatusTempEvent(new StatusEventArgs("doing ... Subsector NB-06-020-002 PolSource site 00023 Observation"));
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
            StatusTempEvent(new StatusEventArgs("doing ... Subsector NB-06-020-002 PolSource site 00024"));
            // TVItem Subsector NB-06_020_002 Pol Source Site 000024 TVItemID = 202467
            TVItem tvItemNB_06_020_002PolSite000024 = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 202467).FirstOrDefault();
            tvItemNB_06_020_002PolSite000024.ParentID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("TVItem", tvItemNB_06_020_002PolSite000024)) return false;
            if (!CorrectTVPath(tvItemNB_06_020_002PolSite000024, tvItemNB_06_020_002)) return false;
            if (!AddMapInfo(tvItemNB_06_020_002PolSite000024, 202467, tvItemContactCharles.TVItemID)) return false;

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
            StatusTempEvent(new StatusEventArgs("doing ... Sampling Plan"));
            // NB TVItem Sampling Plan with SamplingPlanID = 42 and TVFileTVItemID = 322276
            TVItem tvItemNBSamplingPlanFileTVItem = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 322276).FirstOrDefault();
            tvItemNBSamplingPlanFileTVItem.ParentID = tvItemNB.TVItemID;
            if (!AddObject("TVItem", tvItemNBSamplingPlanFileTVItem)) return false;
            if (!CorrectTVPath(tvItemNBSamplingPlanFileTVItem, tvItemNB)) return false;
            if (!AddMapInfo(tvItemNBSamplingPlanFileTVItem, 322276, tvItemContactCharles.TVItemID)) return false;

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
            samplingPlan.ApprovalCode = "aaabbb";
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
            StatusTempEvent(new StatusEventArgs("doing ... MWQM Run"));
            // TVItem MWQMRun with Subsector NB-06_020_002 TVItemID = 635 MWQMSite 0001 TVItemID = 7460 MWQMRunTVItemID = 324152
            TVItem tvItemRun = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 324152).FirstOrDefault();
            tvItemRun.ParentID = tvItemNB_06_020_002.TVItemID;
            if (!AddObject("TVItem", tvItemRun)) return false;
            if (!CorrectTVPath(tvItemRun, tvItemNB_06_020_002)) return false;
            if (!AddMapInfo(tvItemRun, 324152, tvItemContactCharles.TVItemID)) return false;

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
            StatusTempEvent(new StatusEventArgs("doing ... UseOfSite"));
            // NB UseOfSite with SubsectorTVItemID = 635 ClimateSiteTVItemID = 229528
            UseOfSite useOfSite = dbCSSPWebToolsDBRead.UseOfSites.AsNoTracking().Where(c => c.SubsectorTVItemID == 635 && c.SiteTVItemID == 229528).FirstOrDefault();
            useOfSite.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
            useOfSite.SiteTVItemID = tvItemNBClimateSiteBouctoucheCDA.TVItemID;
            if (!AddObject("UseOfSite", useOfSite)) return false;

            // NB UseOfSite with SubsectorTVItemID = 635 TideSiteTVItemID = 1553
            useOfSite = dbCSSPWebToolsDBRead.UseOfSites.AsNoTracking().Where(c => c.SubsectorTVItemID == 635 && c.SiteTVItemID == 1553).FirstOrDefault();
            useOfSite.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
            useOfSite.SiteTVItemID = tvItemNBTideSite.TVItemID;
            if (!AddObject("UseOfSite", useOfSite)) return false;
            #endregion UseOfSite
            #region MWQMSamples
            StatusTempEvent(new StatusEventArgs("doing ... MWQMSamples"));
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
            StatusTempEvent(new StatusEventArgs("doing ... MWQMSite and MWQMSiteStartEndDate"));
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
            StatusTempEvent(new StatusEventArgs("doing ... MikeScenario, MikeBoundaryCondition, MikeSource, MikeSourceStartEnd"));
            // TVItem MikeScenario with MikeScenairoTVItemID = 28475 under Bouctouche
            TVItem tvItemMikeScenario = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 28475).FirstOrDefault();
            int MikeScenarioTVItemID = tvItemMikeScenario.TVItemID;
            tvItemMikeScenario.ParentID = tvItemBouctouche.TVItemID;
            if (!AddObject("TVItem", tvItemMikeScenario)) return false;
            if (!CorrectTVPath(tvItemMikeScenario, tvItemBouctouche)) return false;
            if (!AddMapInfo(tvItemMikeScenario, 28475, tvItemContactCharles.TVItemID)) return false;

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
            if (!AddMapInfo(tvItemMikeBoundaryCondition, 92456, tvItemContactCharles.TVItemID)) return false;

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
            mikeBoundaryCondition.WebTideDataFromStartToEndDate = "some text";
            if (!AddObject("MikeBoundaryCondition", mikeBoundaryCondition)) return false;

            // TVItem MikeSource with MikeSourceTVItemID = 28476 under Bouctouche WWTP
            TVItem tvItemMikeSource = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 28476).FirstOrDefault();
            tvItemMikeSource.ParentID = tvItemMikeScenario.TVItemID;
            if (!AddObject("TVItem", tvItemMikeSource)) return false;
            if (!CorrectTVPath(tvItemMikeSource, tvItemMikeScenario)) return false;
            if (!AddMapInfo(tvItemMikeSource, 28476, tvItemContactCharles.TVItemID)) return false;

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
            StatusTempEvent(new StatusEventArgs("doing ... LabSheet, LabSheetDetail, LabSheetTubeMPNDetail"));
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
            StatusTempEvent(new StatusEventArgs("doing ... Address"));
            // TVItem Address 730 Chemin de la Pointe, Richibouctou, NB E4W, Canada TVItemID = 232655
            TVItem tvItemAddress = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 232655).FirstOrDefault();
            tvItemAddress.ParentID = tvItemRoot.TVItemID;
            if (!AddObject("TVItem", tvItemAddress)) return false;
            if (!CorrectTVPath(tvItemAddress, tvItemRoot)) return false;
            if (!AddMapInfo(tvItemAddress, 232655, tvItemContactCharles.TVItemID)) return false;

            // Address 730 Chemin de la Pointe, Richibouctou, NB E4W, Canada TVItemID = 232655
            Address address = dbCSSPWebToolsDBRead.Addresses.AsNoTracking().Where(c => c.AddressTVItemID == 232655).FirstOrDefault();
            address.AddressTVItemID = tvItemAddress.TVItemID;
            address.CountryTVItemID = tvItemCanada.TVItemID;
            address.ProvinceTVItemID = tvItemNB.TVItemID;
            address.MunicipalityTVItemID = tvItemBouctouche.TVItemID;
            if (!AddObject("Address", address)) return false;

            using (CSSPWebToolsDBContext db2 = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                AddressService addressService = new AddressService(new GetParam(), db2, contactCharles.ContactID);
                addressService.FillAddressTVText(address);
            }

            // TVItem Address 730 Chemin de la Pointe, Richibouctou, NB E4W, Canada TVItemID = 232655
            TVItemLanguage tvItemLanguageENAddress = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 232655 && c.Language == LanguageEnum.en).FirstOrDefault();
            tvItemLanguageENAddress.TVItemID = tvItemAddress.TVItemID;
            tvItemLanguageENAddress.TVText = address.AddressWeb.AddressTVText;
            if (!AddObject("TVItemLanguage", tvItemLanguageENAddress)) return false;

            // TVItem Address 730 Chemin de la Pointe, Richibouctou, NB E4W, Canada TVItemID = 232655
            TVItemLanguage tvItemLanguageFRAddress = dbCSSPWebToolsDBRead.TVItemLanguages.AsNoTracking().Where(c => c.TVItemID == 232655 && c.Language == LanguageEnum.fr).FirstOrDefault();
            tvItemLanguageFRAddress.TVItemID = tvItemAddress.TVItemID;
            tvItemLanguageFRAddress.TVText = address.AddressWeb.AddressTVText;
            if (!AddObject("TVItemLanguage", tvItemLanguageFRAddress)) return false;
            #endregion TVItem Address and Address
            #region TVItem Email and Email
            StatusTempEvent(new StatusEventArgs("doing ... Email"));

            // Email Charles.LeBlanc@ec.gc.ca TVItemID = 110249
            TVItem tvItemEmail = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 110249).FirstOrDefault();
            tvItemEmail.ParentID = tvItemRoot.TVItemID;
            if (!AddObject("TVItem", tvItemEmail)) return false;
            if (!CorrectTVPath(tvItemEmail, tvItemRoot)) return false;
            if (!AddMapInfo(tvItemEmail, 110249, tvItemContactCharles.TVItemID)) return false;

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
            StatusTempEvent(new StatusEventArgs("doing ... Tel"));
            // Tel Charles.LeBlanc@ec.gc.ca TVItemID = 108984
            TVItem tvItemTel = dbCSSPWebToolsDBRead.TVItems.AsNoTracking().Where(c => c.TVItemID == 108984).FirstOrDefault();
            tvItemTel.ParentID = tvItemRoot.TVItemID;
            if (!AddObject("TVItem", tvItemTel)) return false;
            if (!CorrectTVPath(tvItemTel, tvItemRoot)) return false;
            if (!AddMapInfo(tvItemTel, 108984, tvItemContactCharles.TVItemID)) return false;

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
            StatusTempEvent(new StatusEventArgs("doing ... TVItemLink"));
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
            #region Spill and SpillLanguage
            StatusTempEvent(new StatusEventArgs("doing ... Spill and SpillLanguage"));
            Spill spill = new Spill();
            spill.MunicipalityTVItemID = tvItemBouctouche.TVItemID;
            spill.InfrastructureTVItemID = tvItemBouctoucheWWTP.TVItemID;
            spill.StartDateTime_Local = DateTime.Now.AddYears(-5);
            spill.EndDateTime_Local = DateTime.Now.AddYears(-5).AddHours(6);
            spill.AverageFlow_m3_day = 34.5D;
            spill.LastUpdateDate_UTC = DateTime.Now;
            spill.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("Spill", spill)) return false;

            SpillLanguage spillLanguageEN = new SpillLanguage();
            spillLanguageEN.SpillID = spill.SpillID;
            spillLanguageEN.Language = LanguageEnum.en;
            spillLanguageEN.SpillComment = "This is the spill comment";
            spillLanguageEN.TranslationStatus = TranslationStatusEnum.Translated;
            spillLanguageEN.LastUpdateDate_UTC = DateTime.Now;
            spillLanguageEN.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("SpillLanguage", spillLanguageEN)) return false;

            SpillLanguage spillLanguageFR = new SpillLanguage();
            spillLanguageFR.SpillID = spill.SpillID;
            spillLanguageFR.Language = LanguageEnum.fr;
            spillLanguageFR.SpillComment = "This is the spill comment";
            spillLanguageFR.TranslationStatus = TranslationStatusEnum.NotTranslated;
            spillLanguageFR.LastUpdateDate_UTC = DateTime.Now;
            spillLanguageFR.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("SpillLanguage", spillLanguageFR)) return false;
            #endregion Spill and SpillLanguage
            #region EmailDistributionList and EmailDistributionListContact
            StatusTempEvent(new StatusEventArgs("doing ... EmailDistributionList and EmailDistributionListContact"));
            EmailDistributionList emailDistributionList = dbCSSPWebToolsDBRead.EmailDistributionLists.AsNoTracking().FirstOrDefault();
            int EmailDistributionListID = emailDistributionList.EmailDistributionListID;
            emailDistributionList.CountryTVItemID = tvItemCanada.TVItemID;
            if (!AddObject("EmailDistributionList", emailDistributionList)) return false;

            EmailDistributionListLanguage emailDistributionListLanguageEN = dbCSSPWebToolsDBRead.EmailDistributionListLanguages.AsNoTracking().Where(c => c.EmailDistributionListID == EmailDistributionListID && c.Language == LanguageEnum.en).FirstOrDefault();
            emailDistributionListLanguageEN.EmailDistributionListID = emailDistributionList.EmailDistributionListID;
            if (!AddObject("EmailDistributionListLanguage", emailDistributionListLanguageEN)) return false;

            EmailDistributionListLanguage emailDistributionListLanguageFR = dbCSSPWebToolsDBRead.EmailDistributionListLanguages.AsNoTracking().Where(c => c.EmailDistributionListID == EmailDistributionListID && c.Language == LanguageEnum.fr).FirstOrDefault();
            emailDistributionListLanguageFR.EmailDistributionListID = emailDistributionList.EmailDistributionListID;
            if (!AddObject("EmailDistributionListLanguage", emailDistributionListLanguageFR)) return false;


            List<EmailDistributionListContact> emailDistributionListContactList = dbCSSPWebToolsDBRead.EmailDistributionListContacts.AsNoTracking().Where(c => c.EmailDistributionListID == EmailDistributionListID).Take(5).ToList();
            foreach (EmailDistributionListContact emailDistributionListContact in emailDistributionListContactList)
            {
                emailDistributionListContact.EmailDistributionListID = emailDistributionList.EmailDistributionListID;
                int EmailDistributionListContactID = emailDistributionListContact.EmailDistributionListContactID;
                if (!AddObject("EmailDistributionListContact", emailDistributionListContact)) return false;

                EmailDistributionListContactLanguage emailDistributionListContactLanguageEN = dbCSSPWebToolsDBRead.EmailDistributionListContactLanguages.AsNoTracking().Where(c => c.EmailDistributionListContactID == EmailDistributionListContactID && c.Language == LanguageEnum.en).FirstOrDefault();
                emailDistributionListContactLanguageEN.EmailDistributionListContactID = emailDistributionListContact.EmailDistributionListContactID;
                if (!AddObject("EmailDistributionListContactLanguage", emailDistributionListContactLanguageEN)) return false;

                EmailDistributionListContactLanguage emailDistributionListContactLanguageFR = dbCSSPWebToolsDBRead.EmailDistributionListContactLanguages.AsNoTracking().Where(c => c.EmailDistributionListContactID == EmailDistributionListContactID && c.Language == LanguageEnum.fr).FirstOrDefault();
                emailDistributionListContactLanguageFR.EmailDistributionListContactID = emailDistributionListContact.EmailDistributionListContactID;
                if (!AddObject("EmailDistributionListContactLanguage", emailDistributionListContactLanguageFR)) return false;

            }
            #endregion EmailDistributionList and EmailDistributionListContact
            #region AppTask and AppTaskLanguage
            StatusTempEvent(new StatusEventArgs("doing ... AppTask and AppTaskLanguage"));
            AppTask appTask = new AppTask();
            appTask.TVItemID = tvItemCanada.TVItemID;
            appTask.TVItemID2 = tvItemCanada.TVItemID;
            appTask.AppTaskCommand = AppTaskCommandEnum.GenerateWebTide;
            appTask.AppTaskStatus = AppTaskStatusEnum.Created;
            appTask.PercentCompleted = 1;
            appTask.Parameters = "a,a";
            appTask.Language = LanguageEnum.en;
            appTask.StartDateTime_UTC = DateTime.Now.AddYears(-5);
            appTask.EndDateTime_UTC = DateTime.Now.AddYears(-5).AddHours(4);
            appTask.EstimatedLength_second = 1201;
            appTask.RemainingTime_second = 234;
            appTask.LastUpdateDate_UTC = DateTime.Now;
            appTask.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("AppTask", appTask)) return false;

            AppTaskLanguage appTaskLanguageEN = new AppTaskLanguage();
            appTaskLanguageEN.AppTaskID = appTask.AppTaskID;
            appTaskLanguageEN.Language = LanguageEnum.en;
            appTaskLanguageEN.StatusText = "This is the Status text";
            appTaskLanguageEN.ErrorText = "This is the Error text";
            appTaskLanguageEN.TranslationStatus = TranslationStatusEnum.Translated;
            appTaskLanguageEN.LastUpdateDate_UTC = DateTime.Now;
            appTaskLanguageEN.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("AppTaskLanguage", appTaskLanguageEN)) return false;

            AppTaskLanguage appTaskLanguageFR = new AppTaskLanguage();
            appTaskLanguageFR.AppTaskID = appTask.AppTaskID;
            appTaskLanguageFR.Language = LanguageEnum.fr;
            appTaskLanguageFR.StatusText = "This is the Status text";
            appTaskLanguageFR.ErrorText = "This is the Error text";
            appTaskLanguageFR.TranslationStatus = TranslationStatusEnum.NotTranslated;
            appTaskLanguageFR.LastUpdateDate_UTC = DateTime.Now;
            appTaskLanguageFR.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("AppTaskLanguage", appTaskLanguageFR)) return false;
            #endregion AppTask and AppTaskLanguage
            #region AppErrLog
            StatusTempEvent(new StatusEventArgs("doing ... AppErrLog"));
            AppErrLog appErrLog = new AppErrLog();
            appErrLog.Tag = "SomeTag";
            appErrLog.LineNumber = 234;
            appErrLog.Source = "Some text for source";
            appErrLog.Message = "Some text for message";
            appErrLog.DateTime_UTC = DateTime.Now;
            appErrLog.LastUpdateDate_UTC = DateTime.Now;
            appErrLog.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("AppErrLog", appErrLog)) return false;
            #endregion AppErrLog
            #region ContactPreference
            StatusTempEvent(new StatusEventArgs("doing ... ContactPreference"));
            ContactPreference contactPreference = new ContactPreference();
            contactPreference.ContactID = contactCharles.ContactID;
            contactPreference.TVType = TVTypeEnum.ClimateSite;
            contactPreference.MarkerSize = 100;
            contactPreference.LastUpdateDate_UTC = DateTime.Now;
            contactPreference.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("ContactPreference", contactPreference)) return false;
            #endregion ContactPreference
            #region ContactShortcut
            StatusTempEvent(new StatusEventArgs("doing ... ContactShortcut"));
            ContactShortcut contactShortcut = new ContactShortcut();
            contactShortcut.ContactID = contactCharles.ContactID;
            contactShortcut.ShortCutText = "Some shortcut text";
            contactShortcut.ShortCutAddress = "http://www.ibm.com";
            contactShortcut.LastUpdateDate_UTC = DateTime.Now;
            contactShortcut.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("ContactShortcut", contactShortcut)) return false;
            #endregion ContactShortcut
            #region DocTemplate
            StatusTempEvent(new StatusEventArgs("doing ... DocTemplate"));
            DocTemplate docTemplate = new DocTemplate();
            docTemplate.Language = LanguageEnum.en;
            docTemplate.TVType = TVTypeEnum.Subsector;
            docTemplate.TVFileTVItemID = tvFile.TVFileTVItemID;
            docTemplate.FileName = tvItemBouctoucheWWTPTVFileImageEN.TVText;
            docTemplate.LastUpdateDate_UTC = DateTime.Now;
            docTemplate.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("DocTemplate", docTemplate)) return false;
            #endregion DocTemplate
            #region Log
            StatusTempEvent(new StatusEventArgs("doing ... Log"));
            Log log = new Log();
            log.TableName = "TVItems";
            log.ID = 20;
            log.LogCommand = LogCommandEnum.Add;
            log.Information = "The Information Text";
            log.LastUpdateDate_UTC = DateTime.Now;
            log.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("Log", log)) return false;
            #endregion Log
            #region MWQMLookupMPN
            StatusTempEvent(new StatusEventArgs("doing ... MWQMLookupMPN"));
            List<MWQMLookupMPN> mwqmLookupMPNList = dbCSSPWebToolsDBRead.MWQMLookupMPNs.AsNoTracking().Take(12).ToList();
            foreach(MWQMLookupMPN mwqmLookupMPN2 in mwqmLookupMPNList)
            {
                MWQMLookupMPN mwqmLookupMPN = new MWQMLookupMPN();
                mwqmLookupMPN.Tubes10 = mwqmLookupMPN2.Tubes10;
                mwqmLookupMPN.Tubes1 = mwqmLookupMPN2.Tubes1;
                mwqmLookupMPN.Tubes01 = mwqmLookupMPN2.Tubes01;
                mwqmLookupMPN.MPN_100ml = mwqmLookupMPN2.MPN_100ml;
                mwqmLookupMPN.LastUpdateDate_UTC = DateTime.Now;
                mwqmLookupMPN.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
                if (!AddObject("MWQMLookupMPN", mwqmLookupMPN)) return false;
            }
            #endregion MWQMLookupMPN
            #region RainExceedance
            StatusTempEvent(new StatusEventArgs("doing ... RainExceedance"));
            RainExceedance rainExceedance = new RainExceedance();
            rainExceedance.YearRound = true;
            rainExceedance.StartDate_Local = DateTime.Now;
            rainExceedance.EndDate_Local = DateTime.Now;
            rainExceedance.RainMaximum_mm = 12.5f;
            rainExceedance.RainExtreme_mm = 14.6f;
            rainExceedance.DaysPriorToStart = 5;
            rainExceedance.RepeatEveryYear = true;
            rainExceedance.ProvinceTVItemIDs = tvItemNB.TVItemID.ToString();
            rainExceedance.SubsectorTVItemIDs = tvItemNB_06_020_002.TVItemID.ToString();
            rainExceedance.ClimateSiteTVItemIDs = tvItemNBClimateSiteBouctoucheCDA.TVItemID.ToString();
            rainExceedance.EmailDistributionListIDs = emailDistributionList.EmailDistributionListID.ToString();
            rainExceedance.LastUpdateDate_UTC = DateTime.Now;
            rainExceedance.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("RainExceedance", rainExceedance)) return false;
            #endregion RainExceedance
            #region ResetPassword
            StatusTempEvent(new StatusEventArgs("doing ... ResetPassword"));
            ResetPassword resetPassword = new ResetPassword();
            resetPassword.Email = contactCharles.LoginEmail;
            resetPassword.ExpireDate_Local = DateTime.Now;
            resetPassword.Code = "12345678";
            resetPassword.LastUpdateDate_UTC = DateTime.Now;
            resetPassword.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("ResetPassword", resetPassword)) return false;
            #endregion ResetPassword
            #region TideLocation
            StatusTempEvent(new StatusEventArgs("doing ... TideLocation"));
            foreach (int TideLocationSID in new List<int>() { 1815, 1812, 1810 })
            {
                TideLocation tideLocation = dbCSSPWebToolsDBRead.TideLocations.AsNoTracking().Where(c => c.sid == TideLocationSID).FirstOrDefault();

                if (tideLocation != null)
                {
                    tideLocation.TideLocationID = 0;
                    if (!AddObject("TideLocation", tideLocation)) return false;
                }
            }
            #endregion TideLocation
            #region TVItemStat
            StatusTempEvent(new StatusEventArgs("doing ... TVItemStat"));
            TVItemStat tvItemStat = dbCSSPWebToolsDBRead.TVItemStats.AsNoTracking().Where(c => c.TVItemID == RootTVItemID && c.TVType == TVTypeEnum.Municipality).FirstOrDefault();

            if (tvItemStat != null)
            {
                tvItemStat.TVItemStatID = 0;
                tvItemStat.TVItemID = tvItemRoot.TVItemID;
                tvItemStat.ChildCount = 2;
                if (!AddObject("TVItemStat", tvItemStat)) return false;
            }
            #endregion TVItemStat
            #region TVItemUserAuthorization
            StatusTempEvent(new StatusEventArgs("doing ... TVItemUserAuthorization"));
            TVItemUserAuthorization tvItemUserAuthorization = dbCSSPWebToolsDBRead.TVItemUserAuthorizations.AsNoTracking().FirstOrDefault();

            if (tvItemUserAuthorization != null)
            {
                tvItemUserAuthorization.ContactTVItemID = contactCharles.ContactTVItemID;
                tvItemUserAuthorization.TVItemID1 = tvItemBouctouche.TVItemID;
                tvItemUserAuthorization.TVAuth = TVAuthEnum.Write;
                if (!AddObject("TVItemUserAuthorization", tvItemUserAuthorization)) return false;
            }
            #endregion TVItemUserAuthorization
            #region TVTypeUserAuthorization
            StatusTempEvent(new StatusEventArgs("doing ... TVTypeUserAuthorization"));
            TVTypeUserAuthorization tvTypeUserAuthorization = dbCSSPWebToolsDBRead.TVTypeUserAuthorizations.AsNoTracking().FirstOrDefault();

            if (tvTypeUserAuthorization != null)
            {
                tvTypeUserAuthorization.ContactTVItemID = contactCharles.ContactTVItemID;
                tvTypeUserAuthorization.TVType = TVTypeEnum.Root;
                tvTypeUserAuthorization.TVAuth = TVAuthEnum.Admin;
                if (!AddObject("TVTypeUserAuthorization", tvTypeUserAuthorization)) return false;
            }
            #endregion TVTypeUserAuthorization
            #region MWQMAnalysisReportParameter
            StatusTempEvent(new StatusEventArgs("doing ... MWQMAnalysisReportParameter"));
            MWQMAnalysisReportParameter mwqmAnalysisReportParameter = new MWQMAnalysisReportParameter();
            mwqmAnalysisReportParameter.SubsectorTVItemID = tvItemNB_06_020_002.TVItemID;
            mwqmAnalysisReportParameter.AnalysisName = "Name of analysis report parameter";
            mwqmAnalysisReportParameter.AnalysisReportYear = 2016;
            mwqmAnalysisReportParameter.StartDate = new DateTime(2010, 1, 1);
            mwqmAnalysisReportParameter.EndDate = new DateTime(2016, 12, 31);
            mwqmAnalysisReportParameter.AnalysisCalculationType = AnalysisCalculationTypeEnum.AllAllAll;
            mwqmAnalysisReportParameter.NumberOfRuns = 30;
            mwqmAnalysisReportParameter.FullYear = true;
            mwqmAnalysisReportParameter.SalinityHighlightDeviationFromAverage = 8.0f;
            mwqmAnalysisReportParameter.ShortRangeNumberOfDays = 3;
            mwqmAnalysisReportParameter.MidRangeNumberOfDays = 6;
            mwqmAnalysisReportParameter.DryLimit24h = 4;
            mwqmAnalysisReportParameter.DryLimit48h = 8;
            mwqmAnalysisReportParameter.DryLimit72h = 12;
            mwqmAnalysisReportParameter.DryLimit96h = 16;
            mwqmAnalysisReportParameter.WetLimit24h = 12;
            mwqmAnalysisReportParameter.WetLimit48h = 24;
            mwqmAnalysisReportParameter.WetLimit72h = 36;
            mwqmAnalysisReportParameter.WetLimit96h = 48;
            mwqmAnalysisReportParameter.RunsToOmit = ",";
            mwqmAnalysisReportParameter.ExcelTVFileTVItemID = null;
            mwqmAnalysisReportParameter.Command = AnalysisReportExportCommandEnum.Report;
            mwqmAnalysisReportParameter.LastUpdateDate_UTC = DateTime.Now;
            mwqmAnalysisReportParameter.LastUpdateContactTVItemID = tvItemContactCharles.TVItemID;
            if (!AddObject("MWQMAnalysisReportParameter", mwqmAnalysisReportParameter)) return false;
            #endregion MWQMAnalysisReportParameter

            return true;
        }
        private bool AddMapInfo(TVItem NewTVItem, int OldTVItemID, int ContactTVItemID)
        {
            List<MapInfo> mapInfoList = (from c in dbCSSPWebToolsDBRead.MapInfos.AsNoTracking()
                                         where c.TVItemID == OldTVItemID
                                         select c).ToList();
            int MapInfoID = 0;
            foreach (MapInfo mapInfo in mapInfoList)
            {
                MapInfoID = mapInfo.MapInfoID;

                mapInfo.TVItemID = NewTVItem.TVItemID;
                mapInfo.LastUpdateContactTVItemID = ContactTVItemID;

                mapInfo.MapInfoID = 0;
                MapInfoService mapInfoService = new MapInfoService(new GetParam(), dbTestDBWrite, 2);
                mapInfoService.Add(mapInfo);
                if (mapInfo.ValidationResults.Count() > 0)
                {
                    ErrorEvent(new ErrorEventArgs(mapInfo.ValidationResults.First().ErrorMessage));
                    return false;
                }

                List<MapInfoPoint> mapInfoPointList = (from c in dbCSSPWebToolsDBRead.MapInfoPoints.AsNoTracking()
                                                       where c.MapInfoID == MapInfoID
                                                       select c).ToList();

                MapInfoPointService mapInfoPointService = new MapInfoPointService(new GetParam(), dbTestDBWrite, 2);
                foreach (MapInfoPoint mapInfoPoint in mapInfoPointList)
                {
                    mapInfoPoint.MapInfoPointID = 0;
                    mapInfoPoint.MapInfoID = mapInfo.MapInfoID;
                    mapInfoPoint.LastUpdateContactTVItemID = ContactTVItemID;

                    mapInfoPointService.Add(mapInfoPoint);
                    if (mapInfoPoint.ValidationResults.Count() > 0)
                    {
                        ErrorEvent(new ErrorEventArgs(mapInfoPoint.ValidationResults.First().ErrorMessage));
                        return false;
                    }
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
                case "AppErrLog":
                    {
                        ((AppErrLog)objTarget).AppErrLogID = 0;
                        ((AppErrLog)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.AppErrLogs.Add((AppErrLog)objTarget);
                    }
                    break;
                case "AppTask":
                    {
                        ((AppTask)objTarget).AppTaskID = 0;
                        ((AppTask)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.AppTasks.Add((AppTask)objTarget);
                    }
                    break;
                case "AppTaskLanguage":
                    {
                        ((AppTaskLanguage)objTarget).AppTaskLanguageID = 0;
                        ((AppTaskLanguage)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.AppTaskLanguages.Add((AppTaskLanguage)objTarget);
                    }
                    break;
                case "AspNetUser":
                    {
                        dbTestDBWrite.AspNetUsers.Add((AspNetUser)objTarget);
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
                //case "ContactLogin":
                //    {
                //        ((ContactLogin)objTarget).ContactLoginID = 0;
                //        ((ContactLogin)objTarget).LastUpdateContactTVItemID = 2;
                //        dbTestDBWrite.ContactLogins.Add((ContactLogin)objTarget);
                //    }
                //    break;
                case "ContactPreference":
                    {
                        ((ContactPreference)objTarget).ContactPreferenceID = 0;
                        ((ContactPreference)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.ContactPreferences.Add((ContactPreference)objTarget);
                    }
                    break;
                case "ContactShortcut":
                    {
                        ((ContactShortcut)objTarget).ContactShortcutID = 0;
                        ((ContactShortcut)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.ContactShortcuts.Add((ContactShortcut)objTarget);
                    }
                    break;
                case "DocTemplate":
                    {
                        ((DocTemplate)objTarget).DocTemplateID = 0;
                        ((DocTemplate)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.DocTemplates.Add((DocTemplate)objTarget);
                    }
                    break;
                case "Email":
                    {
                        ((Email)objTarget).EmailID = 0;
                        ((Email)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.Emails.Add((Email)objTarget);
                    }
                    break;
                case "EmailDistributionList":
                    {
                        ((EmailDistributionList)objTarget).EmailDistributionListID = 0;
                        ((EmailDistributionList)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.EmailDistributionLists.Add((EmailDistributionList)objTarget);
                    }
                    break;
                case "EmailDistributionListContact":
                    {
                        ((EmailDistributionListContact)objTarget).EmailDistributionListContactID = 0;
                        ((EmailDistributionListContact)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.EmailDistributionListContacts.Add((EmailDistributionListContact)objTarget);
                    }
                    break;
                case "EmailDistributionListContactLanguage":
                    {
                        ((EmailDistributionListContactLanguage)objTarget).EmailDistributionListContactLanguageID = 0;
                        ((EmailDistributionListContactLanguage)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.EmailDistributionListContactLanguages.Add((EmailDistributionListContactLanguage)objTarget);
                    }
                    break;
                case "EmailDistributionListLanguage":
                    {
                        ((EmailDistributionListLanguage)objTarget).EmailDistributionListLanguageID = 0;
                        ((EmailDistributionListLanguage)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.EmailDistributionListLanguages.Add((EmailDistributionListLanguage)objTarget);
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
                case "Log":
                    {
                        ((Log)objTarget).LogID = 0;
                        ((Log)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.Logs.Add((Log)objTarget);
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
                case "MWQMAnalysisReportParameter":
                    {
                        ((MWQMAnalysisReportParameter)objTarget).MWQMAnalysisReportParameterID = 0;
                        ((MWQMAnalysisReportParameter)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.MWQMAnalysisReportParameters.Add((MWQMAnalysisReportParameter)objTarget);
                    }
                    break;
                case "MWQMLookupMPN":
                    {
                        ((MWQMLookupMPN)objTarget).MWQMLookupMPNID = 0;
                        ((MWQMLookupMPN)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.MWQMLookupMPNs.Add((MWQMLookupMPN)objTarget);
                    }
                    break;
                case "MWQMRun":
                    {
                        ((MWQMRun)objTarget).MWQMRunID = 0;
                        ((MWQMRun)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.MWQMRuns.Add((MWQMRun)objTarget);
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
                case "MWQMSubsector":
                    {
                        ((MWQMSubsector)objTarget).MWQMSubsectorID = 0;
                        ((MWQMSubsector)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.MWQMSubsectors.Add((MWQMSubsector)objTarget);
                    }
                    break;
                case "MWQMSubsectorLanguage":
                    {
                        ((MWQMSubsectorLanguage)objTarget).MWQMSubsectorLanguageID = 0;
                        ((MWQMSubsectorLanguage)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.MWQMSubsectorLanguages.Add((MWQMSubsectorLanguage)objTarget);
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
                case "RainExceedance":
                    {
                        ((RainExceedance)objTarget).RainExceedanceID = 0;
                        ((RainExceedance)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.RainExceedances.Add((RainExceedance)objTarget);
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
                case "ReportSection":
                    {
                        ((ReportSection)objTarget).ReportSectionID = 0;
                        ((ReportSection)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.ReportSections.Add((ReportSection)objTarget);
                    }
                    break;
                case "ReportSectionLanguage":
                    {
                        ((ReportSectionLanguage)objTarget).ReportSectionLanguageID = 0;
                        ((ReportSectionLanguage)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.ReportSectionLanguages.Add((ReportSectionLanguage)objTarget);
                    }
                    break;
                case "ReportType":
                    {
                        ((ReportType)objTarget).ReportTypeID = 0;
                        ((ReportType)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.ReportTypes.Add((ReportType)objTarget);
                    }
                    break;
                case "ReportTypeLanguage":
                    {
                        ((ReportTypeLanguage)objTarget).ReportTypeLanguageID = 0;
                        ((ReportTypeLanguage)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.ReportTypeLanguages.Add((ReportTypeLanguage)objTarget);
                    }
                    break;
                case "ResetPassword":
                    {
                        ((ResetPassword)objTarget).ResetPasswordID = 0;
                        ((ResetPassword)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.ResetPasswords.Add((ResetPassword)objTarget);
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
                case "Spill":
                    {
                        ((Spill)objTarget).SpillID = 0;
                        ((Spill)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.Spills.Add((Spill)objTarget);
                    }
                    break;
                case "SpillLanguage":
                    {
                        ((SpillLanguage)objTarget).SpillLanguageID = 0;
                        ((SpillLanguage)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.SpillLanguages.Add((SpillLanguage)objTarget);
                    }
                    break;
                case "Tel":
                    {
                        ((Tel)objTarget).TelID = 0;
                        ((Tel)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.Tels.Add((Tel)objTarget);
                    }
                    break;
                case "TideSite":
                    {
                        ((TideSite)objTarget).TideSiteID = 0;
                        ((TideSite)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.TideSites.Add((TideSite)objTarget);
                    }
                    break;
                case "TideDataValue":
                    {
                        ((TideDataValue)objTarget).TideDataValueID = 0;
                        ((TideDataValue)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.TideDataValues.Add((TideDataValue)objTarget);
                    }
                    break;
                case "TideLocation":
                    {
                        ((TideLocation)objTarget).TideLocationID = 0;
                        //((TideLocation)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.TideLocations.Add((TideLocation)objTarget);
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
                case "TVItemStat":
                    {
                        ((TVItemStat)objTarget).TVItemStatID = 0;
                        ((TVItemStat)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.TVItemStats.Add((TVItemStat)objTarget);
                    }
                    break;
                case "TVItemUserAuthorization":
                    {
                        ((TVItemUserAuthorization)objTarget).TVItemUserAuthorizationID = 0;
                        ((TVItemUserAuthorization)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.TVItemUserAuthorizations.Add((TVItemUserAuthorization)objTarget);
                    }
                    break;
                case "TVTypeUserAuthorization":
                    {
                        ((TVTypeUserAuthorization)objTarget).TVTypeUserAuthorizationID = 0;
                        ((TVTypeUserAuthorization)objTarget).LastUpdateContactTVItemID = 2;
                        dbTestDBWrite.TVTypeUserAuthorizations.Add((TVTypeUserAuthorization)objTarget);
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
        private bool MakingSureEveryTableHasEnoughItemsInTestDB()
        {
            int count = 0;

            #region Addresses
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.Addresses select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        Address address = (from c in db.Addresses select c).OrderByDescending(c => c.AddressID).FirstOrDefault();
                        try
                        {
                            address.AddressID = 0;
                            address.StreetName = address.StreetName + "a";
                            if (!AddObject("Address", address)) return false;
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion Addresses
            #region AppErrLogs
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.AppErrLogs select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        AppErrLog AppErrLog = (from c in db.AppErrLogs select c).OrderByDescending(c => c.AppErrLogID).FirstOrDefault();
                        try
                        {
                            AppErrLog.AppErrLogID = 0;
                            AppErrLog.Source = AppErrLog.Source + "a";
                            if (!AddObject("AppErrLog", AppErrLog)) return false;
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion AppErrLogs
            #region AppTasks
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.AppTasks select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        AppTask AppTask = (from c in db.AppTasks select c).OrderByDescending(c => c.AppTaskID).FirstOrDefault();
                        AppTaskLanguage AppTaskLanguageEN = (from c in db.AppTaskLanguages where c.AppTaskID == AppTask.AppTaskID && c.Language == LanguageEnum.en select c).FirstOrDefault();
                        AppTaskLanguage AppTaskLanguageFR = (from c in db.AppTaskLanguages where c.AppTaskID == AppTask.AppTaskID && c.Language == LanguageEnum.fr select c).FirstOrDefault();
                        try
                        {
                            AppTask.AppTaskID = 0;
                            AppTask.Parameters = AppTask.Parameters + "a";
                            if (!AddObject("AppTask", AppTask)) return false;

                            AppTaskLanguageEN.AppTaskLanguageID = 0;
                            AppTaskLanguageEN.AppTaskID = AppTask.AppTaskID;
                            AppTaskLanguageEN.StatusText = AppTaskLanguageEN.StatusText + "a";
                            if (!AddObject("AppTaskLanguage", AppTaskLanguageEN)) return false;

                            AppTaskLanguageFR.AppTaskLanguageID = 0;
                            AppTaskLanguageFR.AppTaskID = AppTask.AppTaskID;
                            AppTaskLanguageFR.StatusText = AppTaskLanguageFR.StatusText + "a";
                            if (!AddObject("AppTaskLanguage", AppTaskLanguageFR)) return false;
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion AppTasks
            #region BoxModels
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.BoxModels select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        BoxModel BoxModel = (from c in db.BoxModels select c).OrderByDescending(c => c.BoxModelID).FirstOrDefault();
                        BoxModelLanguage BoxModelLanguageEN = (from c in db.BoxModelLanguages where c.BoxModelID == BoxModel.BoxModelID && c.Language == LanguageEnum.en select c).FirstOrDefault();
                        BoxModelLanguage BoxModelLanguageFR = (from c in db.BoxModelLanguages where c.BoxModelID == BoxModel.BoxModelID && c.Language == LanguageEnum.fr select c).FirstOrDefault();
                        List<BoxModelResult> BoxModelResultList = (from c in db.BoxModelResults where c.BoxModelID == BoxModel.BoxModelID select c).ToList();
                        try
                        {
                            BoxModel.BoxModelID = 0;
                            BoxModel.DecayRate_per_day = BoxModel.DecayRate_per_day + 0.1f;
                            if (!AddObject("BoxModel", BoxModel)) return false;

                            BoxModelLanguageEN.BoxModelLanguageID = 0;
                            BoxModelLanguageEN.BoxModelID = BoxModel.BoxModelID;
                            BoxModelLanguageEN.ScenarioName = BoxModelLanguageEN.ScenarioName + "a";
                            if (!AddObject("BoxModelLanguage", BoxModelLanguageEN)) return false;

                            BoxModelLanguageFR.BoxModelLanguageID = 0;
                            BoxModelLanguageFR.BoxModelID = BoxModel.BoxModelID;
                            BoxModelLanguageFR.ScenarioName = BoxModelLanguageFR.ScenarioName + "a";
                            if (!AddObject("BoxModelLanguage", BoxModelLanguageFR)) return false;

                            foreach (BoxModelResult boxModelResult in BoxModelResultList)
                            {
                                boxModelResult.BoxModelResultID = 0;
                                boxModelResult.BoxModelID = BoxModel.BoxModelID;
                                boxModelResult.Radius_m = boxModelResult.Radius_m + 1.0f;
                                if (!AddObject("BoxModelResult", boxModelResult)) return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion BoxModels
            #region ClimateSites
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.ClimateSites select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        ClimateSite ClimateSite = (from c in db.ClimateSites select c).OrderByDescending(c => c.ClimateSiteID).FirstOrDefault();
                        List<ClimateDataValue> ClimateDataValueList = (from c in db.ClimateDataValues where c.ClimateSiteID == ClimateSite.ClimateSiteID select c).ToList();
                        try
                        {
                            ClimateSite.ClimateSiteID = 0;
                            ClimateSite.ClimateSiteName = ClimateSite.ClimateSiteName + "a";
                            if (!AddObject("ClimateSite", ClimateSite)) return false;

                            foreach (ClimateDataValue climateDataValue in ClimateDataValueList)
                            {
                                climateDataValue.ClimateDataValueID = 0;
                                climateDataValue.ClimateSiteID = ClimateSite.ClimateSiteID;
                                climateDataValue.TotalPrecip_mm_cm = climateDataValue.TotalPrecip_mm_cm + 1.0f;
                                if (!AddObject("ClimateDataValue", climateDataValue)) return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion ClimateSites
            #region ContactPreferences
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.ContactPreferences select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        ContactPreference ContactPreference = (from c in db.ContactPreferences select c).OrderByDescending(c => c.ContactPreferenceID).FirstOrDefault();
                        try
                        {
                            ContactPreference.ContactPreferenceID = 0;
                            ContactPreference.MarkerSize = ContactPreference.MarkerSize + 1;
                            if (!AddObject("ContactPreference", ContactPreference)) return false;
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion ContactPreferences
            #region Contacts
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.Contacts select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        Contact Contact = (from c in db.Contacts select c).OrderByDescending(c => c.ContactID).FirstOrDefault();
                        try
                        {
                            Contact.ContactID = 0;
                            Contact.FirstName = Contact.FirstName + "a";
                            if (!AddObject("Contact", Contact)) return false;
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion Contacts
            #region ContactShortcuts
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.ContactShortcuts select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        ContactShortcut ContactShortcut = (from c in db.ContactShortcuts select c).OrderByDescending(c => c.ContactShortcutID).FirstOrDefault();
                        try
                        {
                            ContactShortcut.ContactShortcutID = 0;
                            ContactShortcut.ShortCutText = ContactShortcut.ShortCutText + "a";
                            if (!AddObject("ContactShortcut", ContactShortcut)) return false;
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion ContactShortcuts
            #region DocTemplates
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.DocTemplates select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        DocTemplate DocTemplate = (from c in db.DocTemplates select c).OrderByDescending(c => c.DocTemplateID).FirstOrDefault();
                        try
                        {
                            DocTemplate.DocTemplateID = 0;
                            DocTemplate.FileName = DocTemplate.FileName + "a";
                            if (!AddObject("DocTemplate", DocTemplate)) return false;
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion DocTemplates
            #region EmailDistributionListContactLanguages
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.EmailDistributionLists select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        EmailDistributionList EmailDistributionList = (from c in db.EmailDistributionLists select c).OrderByDescending(c => c.EmailDistributionListID).FirstOrDefault();
                        List<EmailDistributionListLanguage> EmailDistributionListLanguageList = (from c in db.EmailDistributionListLanguages where c.EmailDistributionListID == EmailDistributionList.EmailDistributionListID select c).ToList();
                        List<EmailDistributionListContact> EmailDistributionListContactList = (from c in db.EmailDistributionListContacts where c.EmailDistributionListID == EmailDistributionList.EmailDistributionListID select c).ToList();
                         try
                        {
                            EmailDistributionList.EmailDistributionListID = 0;
                            //EmailDistributionList.Agency = EmailDistributionList.Agency + "a";
                            if (!AddObject("EmailDistributionList", EmailDistributionList)) return false;

                            foreach (EmailDistributionListLanguage emailDistributionListLanguage in EmailDistributionListLanguageList)
                            {
                                emailDistributionListLanguage.EmailDistributionListLanguageID = 0;
                                emailDistributionListLanguage.EmailDistributionListID = EmailDistributionList.EmailDistributionListID;
                                emailDistributionListLanguage.RegionName = emailDistributionListLanguage.RegionName + "a";
                                if (!AddObject("EmailDistributionListLanguage", emailDistributionListLanguage)) return false;
                            }

                            foreach (EmailDistributionListContact emailDistributionListContact in EmailDistributionListContactList)
                            {
                                emailDistributionListContact.EmailDistributionListContactID = 0;
                                emailDistributionListContact.EmailDistributionListID = EmailDistributionList.EmailDistributionListID;
                                emailDistributionListContact.Name = emailDistributionListContact.Name + "a";
                                if (!AddObject("EmailDistributionListContact", emailDistributionListContact)) return false;

                                List<EmailDistributionListContactLanguage> EmailDistributionListContactLanguageList = (from c in db.EmailDistributionListContactLanguages select c).OrderByDescending(c => c.EmailDistributionListContactLanguageID).Take(2).ToList();

                                foreach (EmailDistributionListContactLanguage emailDistributionListContactLanguage in EmailDistributionListContactLanguageList)
                                {
                                    emailDistributionListContactLanguage.EmailDistributionListContactLanguageID = 0;
                                    emailDistributionListContactLanguage.EmailDistributionListContactID = emailDistributionListContact.EmailDistributionListContactID;
                                    emailDistributionListContactLanguage.Agency = emailDistributionListContactLanguage.Agency + "a";
                                    if (!AddObject("EmailDistributionListContactLanguage", emailDistributionListContactLanguage)) return false;                                
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion EmailDistributionLists
            #region Emails
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.Emails select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        Email Email = (from c in db.Emails select c).OrderByDescending(c => c.EmailID).FirstOrDefault();
                        try
                        {
                            Email.EmailID = 0;
                            Email.EmailAddress = Email.EmailAddress + "a";
                            if (!AddObject("Email", Email)) return false;
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion Emails
            #region HydrometricSites
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.HydrometricSites select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        HydrometricSite HydrometricSite = (from c in db.HydrometricSites select c).OrderByDescending(c => c.HydrometricSiteID).FirstOrDefault();
                        List<HydrometricDataValue> HydrometricDataValueList = (from c in db.HydrometricDataValues where c.HydrometricSiteID == HydrometricSite.HydrometricSiteID select c).ToList();
                        try
                        {
                            HydrometricSite.HydrometricSiteID = 0;
                            HydrometricSite.HydrometricSiteName = HydrometricSite.HydrometricSiteName + "a";
                            if (!AddObject("HydrometricSite", HydrometricSite)) return false;

                            foreach (HydrometricDataValue hydrometricDataValue in HydrometricDataValueList)
                            {
                                hydrometricDataValue.HydrometricDataValueID = 0;
                                hydrometricDataValue.HydrometricSiteID = HydrometricSite.HydrometricSiteID;
                                hydrometricDataValue.HourlyValues = hydrometricDataValue.HourlyValues + "a";
                                if (!AddObject("HydrometricDataValue", hydrometricDataValue)) return false;
                            }

                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion HydrometricSites
            #region Infrastructures
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.Infrastructures select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        Infrastructure Infrastructure = (from c in db.Infrastructures select c).OrderByDescending(c => c.InfrastructureID).FirstOrDefault();
                        InfrastructureLanguage InfrastructureLanguageEN = (from c in db.InfrastructureLanguages where c.InfrastructureID == Infrastructure.InfrastructureID && c.Language == LanguageEnum.en select c).FirstOrDefault();
                        InfrastructureLanguage InfrastructureLanguageFR = (from c in db.InfrastructureLanguages where c.InfrastructureID == Infrastructure.InfrastructureID && c.Language == LanguageEnum.fr select c).FirstOrDefault();
                        try
                        {
                            Infrastructure.InfrastructureID = 0;
                            Infrastructure.PortElevation_m = Infrastructure.PortElevation_m + 0.1f;
                            if (!AddObject("Infrastructure", Infrastructure)) return false;

                            InfrastructureLanguageEN.InfrastructureLanguageID = 0;
                            InfrastructureLanguageEN.InfrastructureID = Infrastructure.InfrastructureID;
                            InfrastructureLanguageEN.Comment = InfrastructureLanguageEN.Comment + "a";
                            if (!AddObject("InfrastructureLanguage", InfrastructureLanguageEN)) return false;

                            InfrastructureLanguageFR.InfrastructureLanguageID = 0;
                            InfrastructureLanguageFR.InfrastructureID = Infrastructure.InfrastructureID;
                            InfrastructureLanguageFR.Comment = InfrastructureLanguageFR.Comment + "a";
                            if (!AddObject("InfrastructureLanguage", InfrastructureLanguageFR)) return false;
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion Infrastructures
            #region LabSheets
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.LabSheets select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        LabSheet LabSheet = (from c in db.LabSheets select c).OrderByDescending(c => c.LabSheetID).FirstOrDefault();
                        LabSheetDetail LabSheetDetail = (from c in db.LabSheetDetails select c).OrderByDescending(c => c.LabSheetDetailID).FirstOrDefault();
                        try
                        {
                            LabSheet.LabSheetID = 0;
                            LabSheet.SamplingPlanName = LabSheet.SamplingPlanName + "a";
                            if (!AddObject("LabSheet", LabSheet)) return false;

                            LabSheetDetail.LabSheetDetailID = 0;
                            LabSheetDetail.RunComment = LabSheetDetail.RunComment + "a";
                            if (!AddObject("LabSheetDetail", LabSheetDetail)) return false;

                            LabSheetTubeMPNDetail LabSheetTubeMPNDetail = (from c in db.LabSheetTubeMPNDetails select c).OrderByDescending(c => c.LabSheetTubeMPNDetailID).FirstOrDefault();

                            LabSheetTubeMPNDetail.LabSheetTubeMPNDetailID = 0;
                            LabSheetTubeMPNDetail.LabSheetDetailID = LabSheetDetail.LabSheetDetailID;
                            LabSheetTubeMPNDetail.SiteComment = LabSheetTubeMPNDetail.SiteComment + "a";
                            if (!AddObject("LabSheetTubeMPNDetail", LabSheetTubeMPNDetail)) return false;

                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion LabSheets
            #region Logs
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.Logs select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        Log Log = (from c in db.Logs select c).OrderByDescending(c => c.LogID).FirstOrDefault();
                        try
                        {
                            Log.LogID = 0;
                            Log.Information = Log.Information + "a";
                            if (!AddObject("Log", Log)) return false;
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion Logs
            #region MikeBoundaryConditions
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.MikeBoundaryConditions select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        MikeBoundaryCondition MikeBoundaryCondition = (from c in db.MikeBoundaryConditions select c).OrderByDescending(c => c.MikeBoundaryConditionID).FirstOrDefault();
                        try
                        {
                            MikeBoundaryCondition.MikeBoundaryConditionID = 0;
                            MikeBoundaryCondition.MikeBoundaryConditionCode = MikeBoundaryCondition.MikeBoundaryConditionCode + "a";
                            if (!AddObject("MikeBoundaryCondition", MikeBoundaryCondition)) return false;
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion MikeBoundaryConditions
            #region MikeScenarios
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.MikeScenarios select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        MikeScenario MikeScenario = (from c in db.MikeScenarios select c).OrderByDescending(c => c.MikeScenarioID).FirstOrDefault();
                        try
                        {
                            MikeScenario.MikeScenarioID = 0;
                            MikeScenario.ManningNumber = MikeScenario.ManningNumber + 0.1f;
                            if (!AddObject("MikeScenario", MikeScenario)) return false;
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion MikeScenarios
            #region MikeSources
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.MikeSources select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        MikeSource MikeSource = (from c in db.MikeSources select c).OrderByDescending(c => c.MikeSourceID).FirstOrDefault();
                        MikeSourceStartEnd MikeSourceStartEnd = (from c in db.MikeSourceStartEnds select c).OrderByDescending(c => c.MikeSourceStartEndID).FirstOrDefault();
                        try
                        {
                            MikeSource.MikeSourceID = 0;
                            MikeSource.SourceNumberString = MikeSource.SourceNumberString + "a";
                            if (!AddObject("MikeSource", MikeSource)) return false;

                            MikeSourceStartEnd.MikeSourceStartEndID = 0;
                            MikeSourceStartEnd.SourcePollutionStart_MPN_100ml = MikeSourceStartEnd.SourcePollutionStart_MPN_100ml + 1;
                            MikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = MikeSourceStartEnd.SourcePollutionEnd_MPN_100ml + 1;
                            if (!AddObject("MikeSourceStartEnd", MikeSourceStartEnd)) return false;

                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion MikeSources
            #region MWQMAnalysisReportParameters
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.MWQMAnalysisReportParameters select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        MWQMAnalysisReportParameter MWQMAnalysisReportParameter = (from c in db.MWQMAnalysisReportParameters select c).OrderByDescending(c => c.MWQMAnalysisReportParameterID).FirstOrDefault();
                        try
                        {
                            MWQMAnalysisReportParameter.MWQMAnalysisReportParameterID = 0;
                            MWQMAnalysisReportParameter.AnalysisName = MWQMAnalysisReportParameter.AnalysisName + "a";
                            if (!AddObject("MWQMAnalysisReportParameter", MWQMAnalysisReportParameter)) return false;
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion MWQMAnalysisReportParameters            
            #region MWQMRuns
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.MWQMRuns select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        MWQMRun MWQMRun = (from c in db.MWQMRuns select c).OrderByDescending(c => c.MWQMRunID).FirstOrDefault();
                        List<MWQMRunLanguage> MWQMRunLanguageList = (from c in db.MWQMRunLanguages select c).OrderByDescending(c => c.MWQMRunLanguageID).Take(2).ToList();
                        try
                        {
                            MWQMRun.MWQMRunID = 0;
                            MWQMRun.TemperatureControl1_C = MWQMRun.TemperatureControl1_C + 1.1f;
                            if (!AddObject("MWQMRun", MWQMRun)) return false;

                            foreach (MWQMRunLanguage MWQMRunLanguage in MWQMRunLanguageList)
                            {
                                MWQMRunLanguage.MWQMRunLanguageID = 0;
                                MWQMRunLanguage.RunComment = MWQMRunLanguage.RunComment + "a";
                                if (!AddObject("MWQMRunLanguage", MWQMRunLanguage)) return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion MWQMRuns
            #region MWQMSamples
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.MWQMSamples select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        MWQMSample MWQMSample = (from c in db.MWQMSamples select c).OrderByDescending(c => c.MWQMSampleID).FirstOrDefault();
                        List<MWQMSampleLanguage> MWQMSampleLanguageList = (from c in db.MWQMSampleLanguages select c).OrderByDescending(c => c.MWQMSampleLanguageID).Take(2).ToList();
                        try
                        {
                            MWQMSample.MWQMSampleID = 0;
                            MWQMSample.PH = MWQMSample.PH + 1.1f;
                            if (!AddObject("MWQMSample", MWQMSample)) return false;

                            foreach (MWQMSampleLanguage MWQMSampleLanguage in MWQMSampleLanguageList)
                            {
                                MWQMSampleLanguage.MWQMSampleLanguageID = 0;
                                MWQMSampleLanguage.MWQMSampleNote = MWQMSampleLanguage.MWQMSampleNote + "a";
                                if (!AddObject("MWQMSampleLanguage", MWQMSampleLanguage)) return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion MWQMSamples
            #region MWQMSites
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.MWQMSites select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        MWQMSite MWQMSite = (from c in db.MWQMSites select c).OrderByDescending(c => c.MWQMSiteID).FirstOrDefault();
                        MWQMSiteStartEndDate MWQMSiteStartEndDate = (from c in db.MWQMSiteStartEndDates select c).OrderByDescending(c => c.MWQMSiteStartEndDateID).FirstOrDefault();
                        try
                        {
                            MWQMSite.MWQMSiteID = 0;
                            MWQMSite.MWQMSiteDescription = MWQMSite.MWQMSiteDescription + "a";
                            if (!AddObject("MWQMSite", MWQMSite)) return false;

                            MWQMSiteStartEndDate.MWQMSiteStartEndDateID = 0;
                            MWQMSiteStartEndDate.StartDate = MWQMSiteStartEndDate.StartDate.AddHours(1);
                            MWQMSiteStartEndDate.EndDate = MWQMSiteStartEndDate.EndDate.Value.AddHours(1);
                            if (!AddObject("MWQMSiteStartEndDate", MWQMSiteStartEndDate)) return false;
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion MWQMSites
            #region MWQMSubsectors
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.MWQMSubsectors select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        MWQMSubsector MWQMSubsector = (from c in db.MWQMSubsectors select c).OrderByDescending(c => c.MWQMSubsectorID).FirstOrDefault();
                        List<MWQMSubsectorLanguage> MWQMSubsectorLanguageList = (from c in db.MWQMSubsectorLanguages select c).OrderByDescending(c => c.MWQMSubsectorLanguageID).Take(2).ToList();
                        try
                        {
                            MWQMSubsector.MWQMSubsectorID = 0;
                            MWQMSubsector.SubsectorHistoricKey = (MWQMSubsector.SubsectorHistoricKey.Length > 19 ? "bbb" : MWQMSubsector.SubsectorHistoricKey + "a");
                            if (!AddObject("MWQMSubsector", MWQMSubsector)) return false;

                            foreach (MWQMSubsectorLanguage MWQMSubsectorLanguage in MWQMSubsectorLanguageList)
                            {
                                MWQMSubsectorLanguage.MWQMSubsectorLanguageID = 0;
                                MWQMSubsectorLanguage.SubsectorDesc = MWQMSubsectorLanguage.SubsectorDesc + "a";
                                if (!AddObject("MWQMSubsectorLanguage", MWQMSubsectorLanguage)) return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion MWQMSubsectors
            #region PolSourceSites
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.PolSourceSites select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        PolSourceSite PolSourceSite = (from c in db.PolSourceSites select c).OrderByDescending(c => c.PolSourceSiteID).FirstOrDefault();
                        PolSourceObservation PolSourceObservation = (from c in db.PolSourceObservations select c).OrderByDescending(c => c.PolSourceObservationID).FirstOrDefault();
                        PolSourceObservationIssue PolSourceObservationIssue = (from c in db.PolSourceObservationIssues select c).OrderByDescending(c => c.PolSourceObservationIssueID).FirstOrDefault();
                        try
                        {
                            PolSourceSite.PolSourceSiteID = 0;
                            PolSourceSite.Temp_Locator_CanDelete = PolSourceSite.Temp_Locator_CanDelete + "a";
                            if (!AddObject("PolSourceSite", PolSourceSite)) return false;

                            PolSourceObservation.PolSourceObservationID = 0;
                            PolSourceObservation.PolSourceSiteID = PolSourceSite.PolSourceSiteID;
                            PolSourceObservation.Observation_ToBeDeleted = PolSourceObservation.Observation_ToBeDeleted + "a";
                            if (!AddObject("PolSourceObservation", PolSourceObservation)) return false;

                            PolSourceObservationIssue.PolSourceObservationIssueID = 0;
                            PolSourceObservationIssue.PolSourceObservationID = PolSourceObservation.PolSourceObservationID;
                            PolSourceObservationIssue.ExtraComment = PolSourceObservationIssue.ExtraComment + "a";
                            if (!AddObject("PolSourceObservationIssue", PolSourceObservationIssue)) return false;

                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion PolSourceSites
            #region RainExceedances
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.RainExceedances select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        RainExceedance RainExceedance = (from c in db.RainExceedances select c).OrderByDescending(c => c.RainExceedanceID).FirstOrDefault();
                        try
                        {
                            RainExceedance.RainExceedanceID = 0;
                            RainExceedance.DaysPriorToStart = RainExceedance.DaysPriorToStart + 1;
                            if (!AddObject("RainExceedance", RainExceedance)) return false;
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion RainExceedances
            #region RatingCurves
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.RatingCurves select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        RatingCurve RatingCurve = (from c in db.RatingCurves select c).OrderByDescending(c => c.RatingCurveID).FirstOrDefault();
                        RatingCurveValue RatingCurveValue = (from c in db.RatingCurveValues select c).OrderByDescending(c => c.RatingCurveValueID).FirstOrDefault();
                        try
                        {
                            RatingCurve.RatingCurveID = 0;
                            RatingCurve.RatingCurveNumber = RatingCurve.RatingCurveNumber + 1;
                            if (!AddObject("RatingCurve", RatingCurve)) return false;

                            RatingCurveValue.RatingCurveValueID = 0;
                            RatingCurveValue.RatingCurveID = RatingCurve.RatingCurveID;
                            RatingCurveValue.StageValue_m = RatingCurveValue.StageValue_m + 1;
                            if (!AddObject("RatingCurveValue", RatingCurveValue)) return false;
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion RatingCurves
            #region ReportSections
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.ReportSections select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        ReportSection ReportSection = (from c in db.ReportSections select c).OrderByDescending(c => c.ReportSectionID).FirstOrDefault();
                        List<ReportSectionLanguage> ReportSectionLanguageList = (from c in db.ReportSectionLanguages select c).OrderByDescending(c => c.ReportSectionLanguageID).Take(2).ToList();
                        try
                        {
                            ReportSection.ReportSectionID = 0;
                            ReportSection.Year = ReportSection.Year + 1;
                            if (!AddObject("ReportSection", ReportSection)) return false;

                            foreach (ReportSectionLanguage ReportSectionLanguage in ReportSectionLanguageList)
                            {
                                ReportSectionLanguage.ReportSectionLanguageID = 0;
                                ReportSectionLanguage.ReportSectionID = ReportSection.ReportSectionID;
                                ReportSectionLanguage.ReportSectionName = ReportSectionLanguage.ReportSectionName + "a";
                                if (!AddObject("ReportSectionLanguage", ReportSectionLanguage)) return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion ReportSections
            #region ReportTypes
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.ReportTypes select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        ReportType ReportType = (from c in db.ReportTypes select c).OrderByDescending(c => c.ReportTypeID).FirstOrDefault();
                        List<ReportTypeLanguage> ReportTypeLanguageList = (from c in db.ReportTypeLanguages select c).OrderByDescending(c => c.ReportTypeLanguageID).Take(2).ToList();
                        try
                        {
                            ReportType.ReportTypeID = 0;
                            ReportType.UniqueCode = ReportType.UniqueCode + "a";
                            if (!AddObject("ReportType", ReportType)) return false;

                            foreach (ReportTypeLanguage ReportTypeLanguage in ReportTypeLanguageList)
                            {
                                ReportTypeLanguage.ReportTypeLanguageID = 0;
                                ReportTypeLanguage.ReportTypeID = ReportType.ReportTypeID;
                                ReportTypeLanguage.Name = ReportTypeLanguage.Name + "a";
                                if (!AddObject("ReportTypeLanguage", ReportTypeLanguage)) return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion ReportTypes
            #region ResetPasswords
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.ResetPasswords select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        ResetPassword ResetPassword = (from c in db.ResetPasswords select c).OrderByDescending(c => c.ResetPasswordID).FirstOrDefault();
                        try
                        {
                            ResetPassword.ResetPasswordID = 0;
                            ResetPassword.Email = ResetPassword.Email + "a";
                            if (!AddObject("ResetPassword", ResetPassword)) return false;
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion ResetPasswords
            #region SamplingPlans
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.SamplingPlans select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        SamplingPlan SamplingPlan = (from c in db.SamplingPlans select c).OrderByDescending(c => c.SamplingPlanID).FirstOrDefault();
                        SamplingPlanSubsector SamplingPlanSubsector = (from c in db.SamplingPlanSubsectors select c).OrderByDescending(c => c.SamplingPlanSubsectorID).FirstOrDefault();
                        SamplingPlanSubsectorSite SamplingPlanSubsectorSite = (from c in db.SamplingPlanSubsectorSites select c).OrderByDescending(c => c.SamplingPlanSubsectorSiteID).FirstOrDefault();
                        try
                        {
                            SamplingPlan.SamplingPlanID = 0;
                            SamplingPlan.ForGroupName = SamplingPlan.ForGroupName + "a";
                            SamplingPlan.SamplingPlanName = SamplingPlan.SamplingPlanName + "a";
                            if (!AddObject("SamplingPlan", SamplingPlan)) return false;

                            SamplingPlanSubsector.SamplingPlanSubsectorID = 0;
                            SamplingPlanSubsector.SamplingPlanID = SamplingPlan.SamplingPlanID;
                            if (!AddObject("SamplingPlanSubsector", SamplingPlanSubsector)) return false;

                            SamplingPlanSubsectorSite.SamplingPlanSubsectorSiteID = 0;
                            SamplingPlanSubsectorSite.SamplingPlanSubsectorID = SamplingPlanSubsectorSite.SamplingPlanSubsectorID;
                            if (!AddObject("SamplingPlanSubsectorSite", SamplingPlanSubsectorSite)) return false;

                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion SamplingPlans
            #region Spills
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.Spills select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        Spill Spill = (from c in db.Spills select c).OrderByDescending(c => c.SpillID).FirstOrDefault();
                        List<SpillLanguage> SpillLanguageList = (from c in db.SpillLanguages select c).OrderByDescending(c => c.SpillLanguageID).Take(2).ToList();
                        try
                        {
                            Spill.SpillID = 0;
                            Spill.AverageFlow_m3_day = Spill.AverageFlow_m3_day + 1;
                            if (!AddObject("Spill", Spill)) return false;

                            foreach (SpillLanguage SpillLanguage in SpillLanguageList)
                            {
                                SpillLanguage.SpillLanguageID = 0;
                                SpillLanguage.SpillComment = SpillLanguage.SpillComment + "a";
                                if (!AddObject("SpillLanguage", SpillLanguage)) return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion Spills
            #region Tels
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.Tels select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        Tel Tel = (from c in db.Tels select c).OrderByDescending(c => c.TelID).FirstOrDefault();
                        try
                        {
                            Tel.TelID = 0;
                            Tel.TelNumber = Tel.TelNumber.Substring(Tel.TelNumber.Length - 2) + count*2;
                            if (!AddObject("Tel", Tel)) return false;
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion Tels
            #region TideDataValues
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.TideDataValues select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        TideDataValue TideDataValue = (from c in db.TideDataValues select c).OrderByDescending(c => c.TideDataValueID).FirstOrDefault();
                        try
                        {
                            TideDataValue.TideDataValueID = 0;
                            TideDataValue.Depth_m = TideDataValue.Depth_m + 1;
                            if (!AddObject("TideDataValue", TideDataValue)) return false;
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion TideDataValues
            #region TideLocations
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.TideLocations select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        TideLocation TideLocation = (from c in db.TideLocations select c).OrderByDescending(c => c.TideLocationID).FirstOrDefault();
                        try
                        {
                            TideLocation.TideLocationID = 0;
                            TideLocation.Name = TideLocation.Name + "a";
                            if (!AddObject("TideLocation", TideLocation)) return false;
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion TideLocations
            #region TideSites
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.TideSites select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        TideSite TideSite = (from c in db.TideSites select c).OrderByDescending(c => c.TideSiteID).FirstOrDefault();
                        try
                        {
                            TideSite.TideSiteID = 0;
                            TideSite.WebTideModel = TideSite.WebTideModel + "a";
                            if (!AddObject("TideSite", TideSite)) return false;
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion TideSites
            #region TVFiles
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.TVFiles select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        TVFile TVFile = (from c in db.TVFiles select c).OrderByDescending(c => c.TVFileID).FirstOrDefault();
                        List<TVFileLanguage> TVFileLanguageList = (from c in db.TVFileLanguages select c).OrderByDescending(c => c.TVFileLanguageID).Take(2).ToList();
                        try
                        {
                            TVFile.TVFileID = 0;
                            TVFile.Parameters = TVFile.Parameters + "a";
                            if (!AddObject("TVFile", TVFile)) return false;

                            foreach (TVFileLanguage TVFileLanguage in TVFileLanguageList)
                            {
                                TVFileLanguage.TVFileLanguageID = 0;
                                TVFileLanguage.FileDescription = TVFileLanguage.FileDescription + "a";
                                if (!AddObject("TVFileLanguage", TVFileLanguage)) return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion TVFiles
            #region TVItemLinks
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.TVItemLinks select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        TVItemLink TVItemLink = (from c in db.TVItemLinks select c).OrderByDescending(c => c.TVItemLinkID).FirstOrDefault();
                        try
                        {
                            TVItemLink.TVItemLinkID = 0;
                            //TVItemLink.Email = TVItemLink.Email + "a";
                            if (!AddObject("TVItemLink", TVItemLink)) return false;
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion TVItemLinks
            #region TVItemStats
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.TVItemStats select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        TVItemStat TVItemStat = (from c in db.TVItemStats select c).OrderByDescending(c => c.TVItemStatID).FirstOrDefault();
                        try
                        {
                            TVItemStat.TVItemStatID = 0;
                            TVItemStat.ChildCount = TVItemStat.ChildCount + 1;
                            if (!AddObject("TVItemStat", TVItemStat)) return false;
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion TVItemStats
            #region TVItemUserAuthorizations
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.TVItemUserAuthorizations select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        TVItemUserAuthorization TVItemUserAuthorization = (from c in db.TVItemUserAuthorizations select c).OrderByDescending(c => c.TVItemUserAuthorizationID).FirstOrDefault();
                        try
                        {
                            TVItemUserAuthorization.TVItemUserAuthorizationID = 0;
                            if (!AddObject("TVItemUserAuthorization", TVItemUserAuthorization)) return false;
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion TVItemUserAuthorizations
            #region TVTypeUserAuthorizations
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.TVTypeUserAuthorizations select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        TVTypeUserAuthorization TVTypeUserAuthorization = (from c in db.TVTypeUserAuthorizations select c).OrderByDescending(c => c.TVTypeUserAuthorizationID).FirstOrDefault();
                        try
                        {
                            TVTypeUserAuthorization.TVTypeUserAuthorizationID = 0;
                            if (!AddObject("TVTypeUserAuthorization", TVTypeUserAuthorization)) return false;
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion TVTypeUserAuthorizations
            #region UseOfSites
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.UseOfSites select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        UseOfSite UseOfSite = (from c in db.UseOfSites select c).OrderByDescending(c => c.UseOfSiteID).FirstOrDefault();
                        try
                        {
                            UseOfSite.UseOfSiteID = 0;
                            UseOfSite.Weight_perc = UseOfSite.Weight_perc + 1;
                            if (!AddObject("UseOfSite", UseOfSite)) return false;
                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion UseOfSites
            #region VPScenarios
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                count = (from c in db.VPScenarios select c).Count();
                if (count < 10)
                {
                    for (int i = count; i < 10; i++)
                    {
                        VPScenario VPScenario = (from c in db.VPScenarios select c).OrderByDescending(c => c.VPScenarioID).FirstOrDefault();
                        VPResult VPResult = (from c in db.VPResults select c).OrderByDescending(c => c.VPResultID).FirstOrDefault();
                        VPAmbient VPAmbient = (from c in db.VPAmbients select c).OrderByDescending(c => c.VPAmbientID).FirstOrDefault();
                        List<VPScenarioLanguage> VPScenarioLanguageList = (from c in db.VPScenarioLanguages select c).OrderByDescending(c => c.VPScenarioLanguageID).Take(2).ToList();
                        try
                        {
                            VPScenario.VPScenarioID = 0;
                            VPScenario.PortDiameter_m = VPScenario.PortDiameter_m + 0.1f;
                            if (!AddObject("VPScenario", VPScenario)) return false;

                            VPResult.VPResultID = 0;
                            VPResult.VPScenarioID = VPScenario.VPScenarioID;
                            VPResult.TravelTime_hour = VPResult.TravelTime_hour + 1;
                            if (!AddObject("VPResult", VPResult)) return false;

                            VPAmbient.VPAmbientID = 0;
                            VPAmbient.VPScenarioID = VPAmbient.VPScenarioID;
                            VPAmbient.MeasurementDepth_m = VPAmbient.MeasurementDepth_m + 0.02f;
                            if (!AddObject("VPAmbient", VPAmbient)) return false;

                            foreach (VPScenarioLanguage VPScenarioLanguage in VPScenarioLanguageList)
                            {
                                VPScenarioLanguage.VPScenarioLanguageID = 0;
                                VPScenarioLanguage.VPScenarioID = VPScenario.VPScenarioID;
                                VPScenarioLanguage.VPScenarioName = VPScenarioLanguage.VPScenarioName + "a";
                                if (!AddObject("VPScenarioLanguage", VPScenarioLanguage)) return false;
                            }

                        }
                        catch (Exception ex)
                        {
                            ErrorEvent(new ErrorEventArgs(ex.Message + (ex.InnerException != null ? " Inner: [" + ex.InnerException.Message + "]" : "")));
                            return false;
                        }
                    }
                }
            }
            #endregion VPScenarios

            return true;
        }
        private bool SetTestDBDeleteOrderedList(List<Table> tableTestDBList)
        {
            List<string> ListTableToDelete = new List<string>()
            {
                "Logs",
                "RainExceedances",
                "EmailDistributionListContactLanguages",
                "EmailDistributionListContacts",
                "EmailDistributionListLanguages",
                "EmailDistributionLists",
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
                "MWQMAnalysisReportParameters",
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
                "ReportSectionLanguages",
                "ReportSections",
                "ReportTypeLanguages",
                "ReportTypes",
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
