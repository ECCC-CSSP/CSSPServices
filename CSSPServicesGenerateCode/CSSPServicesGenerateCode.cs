using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSSPServicesGenerateCodeHelper;


namespace CSSPServicesGenerateCode
{
    public partial class CSSPServicesGenerateCode : Form
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public CSSPServicesGenerateCode()
        {
            InitializeComponent();
        }
        #endregion Construtors

        #region Events
        private void butGenerateClassServiceGenerated_Click(object sender, EventArgs e)
        {
            // -----------------------------------------------------------------
            // -----------------------------------------------------------------
            // Will generate CSSPServices/[ClassName]ServiceGenerated.cs files
            // -----------------------------------------------------------------
            // -----------------------------------------------------------------

            GenerateClassServices generateClassServices = new GenerateClassServices(textBoxCSSPModelsDLL.Text, textBoxBaseDir.Text + textBoxFile2ToGenerate.Text, richTextBoxStatus, lblStatus);
            generateClassServices.GenerateCodeOf_ClassServiceGenerated();
        }
        private void butGenerateClassTestGenerated_Click(object sender, EventArgs e)
        {
            // -----------------------------------------------------------------
            // -----------------------------------------------------------------
            // Will generate CSSPServices.Tests/[ClassName]TestGenerated.cs files
            // -----------------------------------------------------------------
            // -----------------------------------------------------------------

            GenerateClassServicesTest generateClassServicesTest = new GenerateClassServicesTest(textBoxCSSPModelsDLL.Text, textBoxBaseDir.Text + textBoxFile1ToGenerate.Text, richTextBoxStatus, lblStatus);
            generateClassServicesTest.GenerateCodeOf_ClassTestGenerated();
        }
        private void ButGenerateFillDBTestingGenerated_Click(object sender, EventArgs e)
        {
            // -----------------------------------------------------------------
            // -----------------------------------------------------------------
            // Will generate CSSPServices.Tests/FillDBAllTestGenerated.cs file
            // -----------------------------------------------------------------
            // -----------------------------------------------------------------

            GenerateFillDBTesting generateFillDBTesting = new GenerateFillDBTesting(textBoxCSSPModelsDLL.Text, textBoxBaseDir.Text + textBoxFile3ToGenerate.Text, richTextBoxStatus, lblStatus);
            generateFillDBTesting.GenerateCodeOf__FillDBTestGenerated();
        }
        #endregion Events
    }

}
