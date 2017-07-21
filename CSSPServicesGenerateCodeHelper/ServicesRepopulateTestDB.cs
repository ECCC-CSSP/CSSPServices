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
                            }
                        }
                        else
                        {
                            queryString = "DELETE FROM " + table.TableName;
                        }

                        using (SqlCommand cmd = new SqlCommand(queryString, cnn))
                        {
                            cmd.ExecuteNonQuery();
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
                ErrorEvent(new ErrorEventArgs(ex.Message));
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
            Address address = dbCSSPWebToolsDBRead.Addresses.Take(1).FirstOrDefault();
            
            //List<int> TVItemIDList = new List<int>() { 1 };

            //foreach (int tvItemID in TVItemIDList)
            //{
            //    TVItem tvItem = (from c in dbCSSPWebToolsDBRead.TVItems
            //                     where c.TVItemID == tvItemID
            //                     select c).Take(1).FirstOrDefault();

            //    if (tvItem != null)
            //    {
            //        dbTestDBWrite.TVItems.Add(tvItem);
            //        try
            //        {
            //            dbTestDBWrite.SaveChanges();
            //        }
            //        catch (Exception ex)
            //        {
            //            ErrorEvent(new ErrorEventArgs(ex.Message));
            //            return false;
            //        }
            //    }
            //}

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
                ErrorEvent(new ErrorEventArgs(ex.Message));
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
