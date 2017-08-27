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
            string CSSPWebToolsDBConnectionString = ConfigurationManager.ConnectionStrings["CSSPWebToolsDB"].ConnectionString;
            string TestDBConnectionString = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
            if (System.Environment.UserName == "Charles")
            {
                CSSPWebToolsDBConnectionString = CSSPWebToolsDBConnectionString.Replace("wmon01dtchlebl2", "charles-pc");
                TestDBConnectionString = TestDBConnectionString.Replace("wmon01dtchlebl2", "charles-pc");
            }

            ServicesFiles servicesFiles = new ServicesFiles();
            servicesFiles.CSSPServicesDLL = textBoxCSSPServicesDLL.Text;
            servicesFiles.CSSPModelsDLL = textBoxCSSPModelsDLL.Text;
            servicesFiles.BaseDir = textBoxBaseDir.Text;
            servicesFiles.BaseDirTest = textBoxFile1ToGenerate.Text;
            servicesFiles.BaseDirServices = textBoxFile2ToGenerate.Text;
            servicesFiles.BaseDirFillDBTest = textBoxFile3ToGenerate.Text;
            servicesFiles.CSSPWebToolsDBConnectionString = CSSPWebToolsDBConnectionString;
            servicesFiles.TestDBConnectionString = TestDBConnectionString;

            servicesGenerateCodeHelper = new ServicesGenerateCodeHelper(servicesFiles);
            servicesGenerateCodeHelper.ErrorHandler += ServicesGenerateCodeHelper_ErrorHandler;
            servicesGenerateCodeHelper.StatusTempHandler += ServicesGenerateCodeHelper_StatusTempHandler;
            servicesGenerateCodeHelper.StatusPermanentHandler += ServicesGenerateCodeHelper_StatusPermanentHandler;
        }

        #endregion Functions private
     
    }

}
