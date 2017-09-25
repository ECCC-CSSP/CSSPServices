using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSSPServicesGenerateCodeHelper;
using System.Configuration;
using CSSPServices;
using CSSPEnums;
using CSSPModels;
using CSSPGenerateCodeBase;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;

namespace CSSPServicesGenerateCode
{
    public partial class CSSPServicesGenerateCode : Form
    {
        #region Variables
        #endregion Variables

        #region Properties
        ServicesGenerateCodeHelper servicesGenerateCodeHelper { get; set; }
        public object AddressServices { get; private set; }
        #endregion Properties

        #region Constructors
        public CSSPServicesGenerateCode()
        {
            InitializeComponent();
            StartUp();
        }
        #endregion Construtors

        #region Events
        private void butRepopulateTesDB_Click(object sender, EventArgs e)
        {
            richTextBoxStatus.Text = "";

            // -----------------------------------------------------------------
            // -----------------------------------------------------------------
            // Will generate CSSPServices/[ClassName]ServiceGenerated.cs files
            // -----------------------------------------------------------------
            // -----------------------------------------------------------------

            servicesGenerateCodeHelper.RepopulateTestDB();
            butRepopulateTesDB.Enabled = false;
        }
        private void butGenerateClassServiceGenerated_Click(object sender, EventArgs e)
        {
            richTextBoxStatus.Text = "";

            // -----------------------------------------------------------------
            // -----------------------------------------------------------------
            // Will generate CSSPServices/[ClassName]ServiceGenerated.cs files
            // -----------------------------------------------------------------
            // -----------------------------------------------------------------

            servicesGenerateCodeHelper.GenerateCodeOf_ClassServiceGenerated();
        }
        private void butGenerateClassServiceTestGenerated_Click(object sender, EventArgs e)
        {
            richTextBoxStatus.Text = "";

            // -----------------------------------------------------------------
            // -----------------------------------------------------------------
            // Will generate CSSPServices.Tests/[ClassName]TestGenerated.cs files
            // -----------------------------------------------------------------
            // -----------------------------------------------------------------

            servicesGenerateCodeHelper.GenerateCodeOf_ClassServiceTestGenerated();
        }
        private void ServicesGenerateCodeHelper_ErrorHandler(object sender, GenerateCodeBase.ErrorEventArgs e)
        {
            richTextBoxStatus.AppendText(e.Error + "\r\n");
            Application.DoEvents();
        }
        private void ServicesGenerateCodeHelper_StatusPermanentHandler(object sender, GenerateCodeBase.StatusEventArgs e)
        {
            richTextBoxStatus.AppendText(e.Status + "\r\n");
            Application.DoEvents();
        }
        private void ServicesGenerateCodeHelper_StatusTempHandler(object sender, GenerateCodeBase.StatusEventArgs e)
        {
            lblStatus.Text = e.Status;
            lblStatus.Refresh();
            Application.DoEvents();
        }
        #endregion Events

        #region Functions private
        private void StartUp()
        {
            servicesGenerateCodeHelper = new ServicesGenerateCodeHelper();
            servicesGenerateCodeHelper.ErrorHandler += ServicesGenerateCodeHelper_ErrorHandler;
            servicesGenerateCodeHelper.StatusTempHandler += ServicesGenerateCodeHelper_StatusTempHandler;
            servicesGenerateCodeHelper.StatusPermanentHandler += ServicesGenerateCodeHelper_StatusPermanentHandler;
        }

        #endregion Functions private

        public enum FilterEnum
        {
            Error = 0,
            Contains = 1,
            StartsWith = 2,
            EndsWith = 3,
            Equals = 4,
            GreaterThan = 5,
            LessThan = 6,
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerCSSPWebToolsDB))
            {
                TVItemService tvItemService = new TVItemService(LanguageEnum.en, db, 2);
                TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(LanguageEnum.en, db, 2);
                TVItemStatService tvItemStatService = new TVItemStatService(LanguageEnum.en, db, 2);
                var tvList = (from c in tvItemService.GetRead()
                              from cl in tvItemLanguageService.GetRead()
                              let p = (from a in tvItemStatService.GetRead()
                                       where a.TVItemID == c.TVItemID
                                       select a)
                              where c.TVItemID == cl.TVItemID
                              && cl.Language == LanguageEnum.en
                              select new { c, cl, p });

                string allo = tvList.ToString();
                //var sql = ((System.Data.Objects.ObjectQuery)tvList).ToTraceString();

                tvList = tvList.Where("c.TVType == @0", TVTypeEnum.Province).OrderBy("cl.TVText desc");

                foreach (var tv in tvList.Take(20))
                {
                    richTextBoxStatus.AppendText(tv.c.TVItemID + "\t" + tv.c.TVPath + "\t" + (int)tv.c.TVType + "\t\t" + tv.cl.LastUpdateDate_UTC + "\t" + tv.cl.TVText + "\r\n");
                }

                foreach (var aa in tvList.Take(20).Select("new(c.TVItemID, c.TVPath, cl.TVText, p)"))
                {
                    richTextBoxStatus.AppendText(((dynamic)aa).TVItemID + " --- " + ((dynamic)aa).TVPath + "\r\n");
                    foreach (var pp in ((dynamic)aa).p)
                    {
                        richTextBoxStatus.AppendText(((TVItemStat)pp).TVType.ToString() + " (" + pp.ChildCount + ")\t");
                    }
                    richTextBoxStatus.AppendText("\r\n");
                }

                foreach (var aa in tvList.Take(20).ToList<dynamic>())
                {
                    richTextBoxStatus.AppendText(aa.c.TVItemID + "\t" + aa.cl.TVText + "\r\n");
                }


            }

            lblStatus.Text = "Done...";
        }


    }
}
