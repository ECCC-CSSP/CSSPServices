using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using CSSPModels;
using CSSPEnums;
using CSSPModelsGenerateCodeHelper;
using CSSPServices;
using CSSPGenerateCodeBase;

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

        #region Functions private
        private void CreateClass_Key_Testing(CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"                    " + TypeNameLower + @" = null;");
            sb.AppendLine(@"                    " + TypeNameLower + @" = GetFilledRandom" + TypeName + @"("""");");
            sb.AppendLine(@"                    " + TypeNameLower + "." + csspProp.PropName + " = 0;");
            sb.AppendLine(@"                    " + TypeNameLower + @"Service.Update(" + TypeNameLower + @");");
            sb.AppendLine(@"                    Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes." + TypeName + csspProp.PropName + "), " + TypeNameLower + ".ValidationResults.FirstOrDefault().ErrorMessage);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    " + TypeNameLower + @" = null;");
            sb.AppendLine(@"                    " + TypeNameLower + @" = GetFilledRandom" + TypeName + @"("""");");
            sb.AppendLine(@"                    " + TypeNameLower + "." + csspProp.PropName + " = 10000000;");
            sb.AppendLine(@"                    " + TypeNameLower + @"Service.Update(" + TypeNameLower + @");");
            sb.AppendLine(@"                    Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes." + TypeName + ", ModelsRes." + TypeName + csspProp.PropName + ", " + TypeNameLower + "." + csspProp.PropName + ".ToString()), " + TypeNameLower + ".ValidationResults.FirstOrDefault().ErrorMessage);");
            sb.AppendLine(@"");
        }
        private void CreateClass_CSSPEnumType_Testing(CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.IsVirtual || csspProp.IsKey || csspProp.PropName == "ValidationResults")
            {
                return;
            }

            if (csspProp.PropType.EndsWith("Enum"))
            {
                if (csspProp.HasCSSPEnumTypeAttribute)
                {
                    sb.AppendLine(@"                    " + TypeNameLower + @" = null;");
                    sb.AppendLine(@"                    " + TypeNameLower + @" = GetFilledRandom" + TypeName + @"("""");");
                    sb.AppendLine(@"                    " + TypeNameLower + "." + csspProp.PropName + " = (" + csspProp.PropType + ")1000000;");
                    if (TypeName == "Contact")
                    {
                        sb.AppendLine(@"                    " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", AddContactTypeEnum.LoggedIn);");
                    }
                    else
                    {
                        sb.AppendLine(@"                    " + TypeNameLower + @"Service.Add(" + TypeNameLower + @");");
                    }
                    sb.AppendLine(@"                    Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes." + TypeName + csspProp.PropName + @"), " + TypeNameLower + ".ValidationResults.FirstOrDefault().ErrorMessage);");
                    sb.AppendLine(@"");
                }
            }
        }
        private void CreateClass_CSSPExist_Testing(CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.IsVirtual || csspProp.IsKey || csspProp.PropName == "ValidationResults")
            {
                return;
            }

            switch (csspProp.PropType)
            {
                case "Int16":
                case "Int32":
                case "Int64":
                case "Boolean":
                case "Single":
                    {
                        if (csspProp.IsKey)
                        {
                            break;
                        }

                        if (csspProp.HasCSSPExistAttribute)
                        {
                            sb.AppendLine(@"                    " + TypeNameLower + @" = null;");
                            sb.AppendLine(@"                    " + TypeNameLower + @" = GetFilledRandom" + TypeName + @"("""");");
                            sb.AppendLine(@"                    " + TypeNameLower + "." + csspProp.PropName + " = 0;");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine(@"                    " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", AddContactTypeEnum.LoggedIn);");
                            }
                            else
                            {
                                sb.AppendLine(@"                    " + TypeNameLower + @"Service.Add(" + TypeNameLower + @");");
                            }
                            sb.AppendLine(@"                    Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes." + csspProp.ExistTypeName + ", ModelsRes." + TypeName + csspProp.PropName + ", " + TypeNameLower + "." + csspProp.PropName + ".ToString()), " + TypeNameLower + ".ValidationResults.FirstOrDefault().ErrorMessage);");
                            sb.AppendLine(@"");

                            if (csspProp.ExistTypeName == "TVItem")
                            {
                                int TVItemIDNotGoodType = 0;
                                TVItem tvItem = null;
                                tvItem = (from c in dbTestDBWrite.TVItems
                                          where !csspProp.AllowableTVTypeList.Contains(c.TVType)
                                          select c).FirstOrDefault();

                                if (tvItem != null)
                                {
                                    TVItemIDNotGoodType = tvItem.TVItemID;
                                }

                                sb.AppendLine(@"                    " + TypeNameLower + @" = null;");
                                sb.AppendLine(@"                    " + TypeNameLower + @" = GetFilledRandom" + TypeName + @"("""");");
                                sb.AppendLine(@"                    " + TypeNameLower + "." + csspProp.PropName + " = " + TVItemIDNotGoodType + ";");
                                if (TypeName == "Contact")
                                {
                                    sb.AppendLine(@"                    " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", AddContactTypeEnum.LoggedIn);");
                                }
                                else
                                {
                                    sb.AppendLine(@"                    " + TypeNameLower + @"Service.Add(" + TypeNameLower + @");");
                                }
                                sb.AppendLine(@"                    Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes." + TypeName + csspProp.PropName + @", """ + String.Join(",", csspProp.AllowableTVTypeList) + @"""), " + TypeNameLower + ".ValidationResults.FirstOrDefault().ErrorMessage);");
                                sb.AppendLine(@"");
                            }
                        }
                    }
                    break;
                default:
                    {
                    }
                    break;
            }
        }
        private void CreateClass_CRUD_Testing(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"                count = " + TypeNameLower + @"Service.GetRead().Count();");
            sb.AppendLine(@"");
            sb.AppendLine(@"                Assert.AreEqual(" + TypeNameLower + @"Service.GetRead().Count(), " + TypeNameLower + @"Service.GetEdit().Count());");
            sb.AppendLine(@"");
            if (TypeName == "Contact")
            {
                sb.AppendLine(@"                " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", AddContactTypeEnum.LoggedIn);");
            }
            else
            {
                sb.AppendLine(@"                " + TypeNameLower + @"Service.Add(" + TypeNameLower + @");");
            }
            sb.AppendLine(@"                if (" + TypeNameLower + @".HasErrors)");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    Assert.AreEqual("""", " + TypeNameLower + @".ValidationResults.FirstOrDefault().ErrorMessage);");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"                Assert.AreEqual(true, " + TypeNameLower + @"Service.GetRead().Where(c => c == " + TypeNameLower + @").Any());");
            sb.AppendLine(@"                " + TypeNameLower + @"Service.Update(" + TypeNameLower + @");");
            sb.AppendLine(@"                if (" + TypeNameLower + @".HasErrors)");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    Assert.AreEqual("""", " + TypeNameLower + @".ValidationResults.FirstOrDefault().ErrorMessage);");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"                Assert.AreEqual(count + 1, " + TypeNameLower + @"Service.GetRead().Count());");
            sb.AppendLine(@"                " + TypeNameLower + @"Service.Delete(" + TypeNameLower + @");");
            sb.AppendLine(@"                if (" + TypeNameLower + @".HasErrors)");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    Assert.AreEqual("""", " + TypeNameLower + @".ValidationResults.FirstOrDefault().ErrorMessage);");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"                Assert.AreEqual(count, " + TypeNameLower + @"Service.GetRead().Count());");
        }
        private void CreateClass_Min_And_Max_Properties_Testing(CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.IsVirtual || csspProp.IsKey || csspProp.PropName == "ValidationResults")
            {
                return;
            }

            switch (csspProp.PropType)
            {

                case "Int16":
                case "Int32":
                case "Int64":
                case "Single":
                case "Double":
                    {
                        //string propTypeTxt = "Int";
                        string numbExt = "";
                        if (csspProp.PropType == "Single")
                        {
                            //  propTypeTxt = "Float";
                            numbExt = ".0f";
                        }
                        else if (csspProp.PropType == "Double")
                        {
                            //propTypeTxt = "Double";
                            numbExt = ".0D";
                        }

                        if (csspProp.Min != null)
                        {
                            sb.AppendLine(@"                    " + TypeNameLower + @" = null;");
                            sb.AppendLine(@"                    " + TypeNameLower + @" = GetFilledRandom" + TypeName + @"("""");");
                            sb.AppendLine(@"                    " + TypeNameLower + @"." + csspProp.PropName + @" = " + (csspProp.Min - 1).ToString() + numbExt + ";");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine(@"                    Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", AddContactTypeEnum.First));");
                            }
                            else
                            {
                                sb.AppendLine(@"                    Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                            }
                            if (csspProp.Max != null)
                            {
                                sb.AppendLine(@"                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.Min.ToString() + @""", """ + csspProp.Max.ToString() + @"""), " + TypeNameLower + ".ValidationResults.FirstOrDefault().ErrorMessage);");
                            }
                            else
                            {
                                sb.AppendLine(@"                    Assert.AreEqual(string.Format(ServicesRes._MinValueIs_, ModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.Min.ToString() + @"""), " + TypeNameLower + ".ValidationResults.FirstOrDefault().ErrorMessage);");
                            }
                            sb.AppendLine(@"                    Assert.AreEqual(count, " + TypeNameLower + @"Service.GetRead().Count());");
                        }
                        if (csspProp.Max != null)
                        {
                            sb.AppendLine(@"                    " + TypeNameLower + @" = null;");
                            sb.AppendLine(@"                    " + TypeNameLower + @" = GetFilledRandom" + TypeName + @"("""");");

                            sb.AppendLine(@"                    " + TypeNameLower + @"." + csspProp.PropName + @" = " + (csspProp.Max + 1).ToString() + numbExt + ";");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine(@"                    Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", AddContactTypeEnum.First));");
                            }
                            else
                            {
                                sb.AppendLine(@"                    Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                            }
                            if (csspProp.Min != null)
                            {
                                sb.AppendLine(@"                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.Min.ToString() + @""", """ + csspProp.Max.ToString() + @"""), " + TypeNameLower + ".ValidationResults.FirstOrDefault().ErrorMessage);");
                            }
                            else
                            {
                                sb.AppendLine(@"                    Assert.AreEqual(string.Format(ServicesRes._MaxValueIs_, ModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.Max.ToString() + @"""), " + TypeNameLower + ".ValidationResults.FirstOrDefault().ErrorMessage);");
                            }
                            sb.AppendLine(@"                    Assert.AreEqual(count, " + TypeNameLower + @"Service.GetRead().Count());");
                        }
                    }
                    break;
                case "Boolean":
                    {
                        // nothing
                    }
                    break;
                case "DateTime":
                case "DateTimeOffset":
                    {
                        // nothing
                    }
                    break;
                case "String":
                    {
                        if (csspProp.Min != null)
                        {
                            sb.AppendLine(@"                    " + TypeNameLower + @" = null;");
                            sb.AppendLine(@"                    " + TypeNameLower + @" = GetFilledRandom" + TypeName + @"("""");");

                            if (csspProp.Min - 1 > 0)
                            {
                                sb.AppendLine(@"                    " + TypeNameLower + @"." + csspProp.PropName + @" = GetRandomString("""", " + (csspProp.Min - 1).ToString() + ");");
                                if (TypeName == "Contact")
                                {
                                    sb.AppendLine(@"                    Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", AddContactTypeEnum.First));");
                                }
                                else
                                {
                                    sb.AppendLine(@"                    Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                                }
                                if (csspProp.Max != null)
                                {
                                    sb.AppendLine(@"                    Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.Min.ToString() + @""", """ + csspProp.Max.ToString() + @"""), " + TypeNameLower + ".ValidationResults.FirstOrDefault().ErrorMessage);");
                                }
                                else
                                {
                                    sb.AppendLine(@"                    Assert.AreEqual(string.Format(ServicesRes._MinLengthIs_, ModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.Min.ToString() + @"""), " + TypeNameLower + ".ValidationResults.FirstOrDefault().ErrorMessage);");
                                }
                                sb.AppendLine(@"                    Assert.AreEqual(count, " + TypeNameLower + @"Service.GetRead().Count());");
                            }
                        }
                        if (csspProp.Max > 0)
                        {
                            sb.AppendLine(@"                    " + TypeNameLower + @" = null;");
                            sb.AppendLine(@"                    " + TypeNameLower + @" = GetFilledRandom" + TypeName + @"("""");");

                            sb.AppendLine(@"                    " + TypeNameLower + @"." + csspProp.PropName + @" = GetRandomString("""", " + (csspProp.Max + 1).ToString() + ");");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine(@"                    Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", AddContactTypeEnum.First));");
                            }
                            else
                            {
                                sb.AppendLine(@"                    Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                            }
                            if (csspProp.Min != null)
                            {
                                sb.AppendLine(@"                    Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.Min.ToString() + @""", """ + csspProp.Max.ToString() + @"""), " + TypeNameLower + ".ValidationResults.FirstOrDefault().ErrorMessage);");
                            }
                            else
                            {
                                sb.AppendLine(@"                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes." + TypeName + csspProp.PropName + @", """ + csspProp.Max.ToString() + @"""), " + TypeNameLower + ".ValidationResults.FirstOrDefault().ErrorMessage);");
                            }
                            sb.AppendLine(@"                    Assert.AreEqual(count, " + TypeNameLower + @"Service.GetRead().Count());");
                        }
                    }
                    break;
                default:
                    {
                    }
                    break;
            }
        }
        private void CreateClass_Required_Properties_Testing(CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.IsVirtual || csspProp.IsKey || csspProp.PropName == "ValidationResults")
            {
                return;
            }

            switch (csspProp.PropType)
            {
                case "Int16":
                case "Int32":
                case "Int64":
                case "Boolean":
                case "Single":
                case "DateTime":
                case "DateTimeOffset":
                    break;
                case "String":
                    {
                        if (!csspProp.IsNullable)
                        {
                            sb.AppendLine(@"                    " + TypeNameLower + @" = null;");
                            sb.AppendLine(@"                    " + TypeNameLower + @" = GetFilledRandom" + TypeName + @"(""" + csspProp.PropName + @""");");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine(@"                    Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @", AddContactTypeEnum.LoggedIn));");
                            }
                            else
                            {
                                sb.AppendLine(@"                    Assert.AreEqual(false, " + TypeNameLower + @"Service.Add(" + TypeNameLower + @"));");
                            }
                            sb.AppendLine(@"                    Assert.AreEqual(1, " + TypeNameLower + @".ValidationResults.Count());");
                            sb.AppendLine(@"                    Assert.IsTrue(" + TypeNameLower + @".ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes." + TypeName + csspProp.PropName + @")).Any());");
                            sb.AppendLine(@"                    Assert.AreEqual(null, " + TypeNameLower + @"." + csspProp.PropName + @");");
                            sb.AppendLine(@"                    Assert.AreEqual(count, " + TypeNameLower + @"Service.GetRead().Count());");
                            sb.AppendLine(@"");
                        }
                    }
                    break;
                default:
                    {
                        if (csspProp.HasCSSPEnumTypeAttribute)
                        {
                            // nothing for now
                        }
                        else
                        {
                            sb.AppendLine(@"                    //Error: Type not implemented [" + csspProp.PropName + "]");
                            sb.AppendLine(@"");
                        }
                    }
                    break;
            }
        }
        private void CreateGetFilledRandomClass(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            switch (csspProp.PropType)
            {
                case "Int16":
                case "Int32":
                case "Int64":
                case "Single":
                case "Double":
                    {
                        string propTypeTxt = "Int";
                        string numbExt = "";
                        if (csspProp.PropType == "Single")
                        {
                            propTypeTxt = "Float";
                            numbExt = ".0f";
                        }
                        else if (csspProp.PropType == "Double")
                        {
                            propTypeTxt = "Double";
                            numbExt = ".0D";
                        }

                        if (csspProp.IsKey)
                        {
                            //sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = " + prop.Name + @";");
                        }
                        else
                        {
                            if (csspProp.PropName == "LastUpdateContactTVItemID")
                            {
                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = 2;");
                            }
                            else if (csspProp.HasCSSPExistAttribute)
                            {
                                switch (csspProp.ExistTypeName)
                                {
                                    case "AppTask":
                                        {
                                            AppTaskService appTaskService = new AppTaskService(LanguageEnum.en, dbTestDBWrite, 2 /* charles LeBlanc */);
                                            AppTask appTask = appTaskService.GetRead().FirstOrDefault();
                                            if (appTask == null)
                                            {
                                                sb.AppendLine(@"            // Need to implement (no items found, would need to add at least one in the TestDB) [" + TypeName + " " + csspProp.PropName + " " + csspProp.ExistTypeName + " " + csspProp.ExistFieldID + "]");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = " + appTask.AppTaskID + ";");
                                            }
                                        }
                                        break;
                                    case "BoxModel":
                                        {
                                            BoxModelService boxModelService = new BoxModelService(LanguageEnum.en, dbTestDBWrite, 2 /* charles LeBlanc */);
                                            BoxModel boxModel = boxModelService.GetRead().FirstOrDefault();
                                            if (boxModel == null)
                                            {
                                                sb.AppendLine(@"            // Need to implement (no items found, would need to add at least one in the TestDB) [" + TypeName + " " + csspProp.PropName + " " + csspProp.ExistTypeName + " " + csspProp.ExistFieldID + "]");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = " + boxModel.BoxModelID + ";");
                                            }
                                        }
                                        break;
                                    case "ClimateSite":
                                        {
                                            ClimateSiteService climateSiteService = new ClimateSiteService(LanguageEnum.en, dbTestDBWrite, 2 /* charles LeBlanc */);
                                            ClimateSite climateSite = climateSiteService.GetRead().FirstOrDefault();
                                            if (climateSite == null)
                                            {
                                                sb.AppendLine(@"            // Need to implement (no items found, would need to add at least one in the TestDB) [" + TypeName + " " + csspProp.PropName + " " + csspProp.ExistTypeName + " " + csspProp.ExistFieldID + "]");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = " + climateSite.ClimateSiteID + ";");
                                            }
                                        }
                                        break;
                                    case "Contact":
                                        {
                                            ContactService contactService = new ContactService(LanguageEnum.en, dbTestDBWrite, 2 /* charles LeBlanc */);
                                            Contact contact = contactService.GetRead().FirstOrDefault();
                                            if (contact == null)
                                            {
                                                sb.AppendLine(@"            // Need to implement (no items found, would need to add at least one in the TestDB) [" + TypeName + " " + csspProp.PropName + " " + csspProp.ExistTypeName + " " + csspProp.ExistFieldID + "]");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = " + contact.ContactID + ";");
                                            }
                                        }
                                        break;
                                    case "EmailDistributionList":
                                        {
                                            EmailDistributionListService emailDistributionListService = new EmailDistributionListService(LanguageEnum.en, dbTestDBWrite, 2 /* charles LeBlanc */);
                                            EmailDistributionList emailDistributionList = emailDistributionListService.GetRead().FirstOrDefault();
                                            if (emailDistributionList == null)
                                            {
                                                sb.AppendLine(@"            // Need to implement (no items found, would need to add at least one in the TestDB) [" + TypeName + " " + csspProp.PropName + " " + csspProp.ExistTypeName + " " + csspProp.ExistFieldID + "]");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = " + emailDistributionList.EmailDistributionListID + ";");
                                            }
                                        }
                                        break;
                                    case "HydrometricSite":
                                        {
                                            HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(LanguageEnum.en, dbTestDBWrite, 2 /* charles LeBlanc */);
                                            HydrometricSite hydrometricSite = hydrometricSiteService.GetRead().FirstOrDefault();
                                            if (hydrometricSite == null)
                                            {
                                                sb.AppendLine(@"            // Need to implement (no items found, would need to add at least one in the TestDB) [" + TypeName + " " + csspProp.PropName + " " + csspProp.ExistTypeName + " " + csspProp.ExistFieldID + "]");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = " + hydrometricSite.HydrometricSiteID + ";");
                                            }
                                        }
                                        break;
                                    case "Infrastructure":
                                        {
                                            InfrastructureService infrastructureService = new InfrastructureService(LanguageEnum.en, dbTestDBWrite, 2 /* charles LeBlanc */);
                                            Infrastructure infrastructure = infrastructureService.GetRead().FirstOrDefault();
                                            if (infrastructure == null)
                                            {
                                                sb.AppendLine(@"            // Need to implement (no items found, would need to add at least one in the TestDB) [" + TypeName + " " + csspProp.PropName + " " + csspProp.ExistTypeName + " " + csspProp.ExistFieldID + "]");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = " + infrastructure.InfrastructureID + ";");
                                            }
                                        }
                                        break;
                                    case "LabSheet":
                                        {
                                            LabSheetService labSheetService = new LabSheetService(LanguageEnum.en, dbTestDBWrite, 2 /* charles LeBlanc */);
                                            LabSheet labSheet = labSheetService.GetRead().FirstOrDefault();
                                            if (labSheet == null)
                                            {
                                                sb.AppendLine(@"            // Need to implement (no items found, would need to add at least one in the TestDB) [" + TypeName + " " + csspProp.PropName + " " + csspProp.ExistTypeName + " " + csspProp.ExistFieldID + "]");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = " + labSheet.LabSheetID + ";");
                                            }
                                        }
                                        break;
                                    case "LabSheetDetail":
                                        {
                                            LabSheetDetailService labSheetDetailService = new LabSheetDetailService(LanguageEnum.en, dbTestDBWrite, 2 /* charles LeBlanc */);
                                            LabSheetDetail labSheetDetail = labSheetDetailService.GetRead().FirstOrDefault();
                                            if (labSheetDetail == null)
                                            {
                                                sb.AppendLine(@"            // Need to implement (no items found, would need to add at least one in the TestDB) [" + TypeName + " " + csspProp.PropName + " " + csspProp.ExistTypeName + " " + csspProp.ExistFieldID + "]");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = " + labSheetDetail.LabSheetDetailID + ";");
                                            }
                                        }
                                        break;
                                    case "MapInfo":
                                        {
                                            MapInfoService mapInfoService = new MapInfoService(LanguageEnum.en, dbTestDBWrite, 2 /* charles LeBlanc */);
                                            MapInfo mapInfo = mapInfoService.GetRead().FirstOrDefault();
                                            if (mapInfo == null)
                                            {
                                                sb.AppendLine(@"            // Need to implement (no items found, would need to add at least one in the TestDB) [" + TypeName + " " + csspProp.PropName + " " + csspProp.ExistTypeName + " " + csspProp.ExistFieldID + "]");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = " + mapInfo.MapInfoID + ";");
                                            }
                                        }
                                        break;
                                    case "MikeSource":
                                        {
                                            MikeSourceService mikeSourceService = new MikeSourceService(LanguageEnum.en, dbTestDBWrite, 2 /* charles LeBlanc */);
                                            MikeSource mikeSource = mikeSourceService.GetRead().FirstOrDefault();
                                            if (mikeSource == null)
                                            {
                                                sb.AppendLine(@"            // Need to implement (no items found, would need to add at least one in the TestDB) [" + TypeName + " " + csspProp.PropName + " " + csspProp.ExistTypeName + " " + csspProp.ExistFieldID + "]");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = " + mikeSource.MikeSourceID + ";");
                                            }
                                        }
                                        break;
                                    case "MWQMRun":
                                        {
                                            MWQMRunService mwqmRunService = new MWQMRunService(LanguageEnum.en, dbTestDBWrite, 2 /* charles LeBlanc */);
                                            MWQMRun mwqmRun = mwqmRunService.GetRead().FirstOrDefault();
                                            if (mwqmRun == null)
                                            {
                                                sb.AppendLine(@"            // Need to implement (no items found, would need to add at least one in the TestDB) [" + TypeName + " " + csspProp.PropName + " " + csspProp.ExistTypeName + " " + csspProp.ExistFieldID + "]");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = " + mwqmRun.MWQMRunID + ";");
                                            }
                                        }
                                        break;
                                    case "MWQMSample":
                                        {
                                            MWQMSampleService mwqmSampleService = new MWQMSampleService(LanguageEnum.en, dbTestDBWrite, 2 /* charles LeBlanc */);
                                            MWQMSample mwqmSample = mwqmSampleService.GetRead().FirstOrDefault();
                                            if (mwqmSample == null)
                                            {
                                                sb.AppendLine(@"            // Need to implement (no items found, would need to add at least one in the TestDB) [" + TypeName + " " + csspProp.PropName + " " + csspProp.ExistTypeName + " " + csspProp.ExistFieldID + "]");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = " + mwqmSample.MWQMSampleID + ";");
                                            }
                                        }
                                        break;
                                    case "MWQMSubsector":
                                        {
                                            MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(LanguageEnum.en, dbTestDBWrite, 2 /* charles LeBlanc */);
                                            MWQMSubsector mwqmSubsector = mwqmSubsectorService.GetRead().FirstOrDefault();
                                            if (mwqmSubsector == null)
                                            {
                                                sb.AppendLine(@"            // Need to implement (no items found, would need to add at least one in the TestDB) [" + TypeName + " " + csspProp.PropName + " " + csspProp.ExistTypeName + " " + csspProp.ExistFieldID + "]");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = " + mwqmSubsector.MWQMSubsectorID + ";");
                                            }
                                        }
                                        break;
                                    case "PolSourceObservation":
                                        {
                                            PolSourceObservationService polSourceObservationService = new PolSourceObservationService(LanguageEnum.en, dbTestDBWrite, 2 /* charles LeBlanc */);
                                            PolSourceObservation polSourceObservation = polSourceObservationService.GetRead().FirstOrDefault();
                                            if (polSourceObservation == null)
                                            {
                                                sb.AppendLine(@"            // Need to implement (no items found, would need to add at least one in the TestDB) [" + TypeName + " " + csspProp.PropName + " " + csspProp.ExistTypeName + " " + csspProp.ExistFieldID + "]");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = " + polSourceObservation.PolSourceObservationID + ";");
                                            }
                                        }
                                        break;
                                    case "PolSourceSite":
                                        {
                                            PolSourceSiteService polSourceSiteService = new PolSourceSiteService(LanguageEnum.en, dbTestDBWrite, 2 /* charles LeBlanc */);
                                            PolSourceSite polSourceSite = polSourceSiteService.GetRead().FirstOrDefault();
                                            if (polSourceSite == null)
                                            {
                                                sb.AppendLine(@"            // Need to implement (no items found, would need to add at least one in the TestDB) [" + TypeName + " " + csspProp.PropName + " " + csspProp.ExistTypeName + " " + csspProp.ExistFieldID + "]");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = " + polSourceSite.PolSourceSiteID + ";");
                                            }
                                        }
                                        break;
                                    case "RatingCurve":
                                        {
                                            RatingCurveService ratingCurveService = new RatingCurveService(LanguageEnum.en, dbTestDBWrite, 2 /* charles LeBlanc */);
                                            RatingCurve ratingCurve = ratingCurveService.GetRead().FirstOrDefault();
                                            if (ratingCurve == null)
                                            {
                                                sb.AppendLine(@"            // Need to implement (no items found, would need to add at least one in the TestDB) [" + TypeName + " " + csspProp.PropName + " " + csspProp.ExistTypeName + " " + csspProp.ExistFieldID + "]");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = " + ratingCurve.RatingCurveID + ";");
                                            }
                                        }
                                        break;
                                    case "SamplingPlanSubsector":
                                        {
                                            SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(LanguageEnum.en, dbTestDBWrite, 2 /* charles LeBlanc */);
                                            SamplingPlanSubsector samplingPlanSubsector = samplingPlanSubsectorService.GetRead().FirstOrDefault();
                                            if (samplingPlanSubsector == null)
                                            {
                                                sb.AppendLine(@"            // Need to implement (no items found, would need to add at least one in the TestDB) [" + TypeName + " " + csspProp.PropName + " " + csspProp.ExistTypeName + " " + csspProp.ExistFieldID + "]");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = " + samplingPlanSubsector.SamplingPlanSubsectorID + ";");
                                            }
                                        }
                                        break;
                                    case "SamplingPlan":
                                        {
                                            SamplingPlanService samplingPlanService = new SamplingPlanService(LanguageEnum.en, dbTestDBWrite, 2 /* charles LeBlanc */);
                                            SamplingPlan samplingPlan = samplingPlanService.GetRead().FirstOrDefault();
                                            if (samplingPlan == null)
                                            {
                                                sb.AppendLine(@"            // Need to implement (no items found, would need to add at least one in the TestDB) [" + TypeName + " " + csspProp.PropName + " " + csspProp.ExistTypeName + " " + csspProp.ExistFieldID + "]");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = " + samplingPlan.SamplingPlanID + ";");
                                            }
                                        }
                                        break;
                                    case "Spill":
                                        {
                                            SpillService spillService = new SpillService(LanguageEnum.en, dbTestDBWrite, 2 /* charles LeBlanc */);
                                            Spill spill = spillService.GetRead().FirstOrDefault();
                                            if (spill == null)
                                            {
                                                sb.AppendLine(@"            // Need to implement (no items found, would need to add at least one in the TestDB) [" + TypeName + " " + csspProp.PropName + " " + csspProp.ExistTypeName + " " + csspProp.ExistFieldID + "]");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = " + spill.SpillID + ";");
                                            }
                                        }
                                        break;
                                    case "TVFile":
                                        {
                                            TVFileService tvFileService = new TVFileService(LanguageEnum.en, dbTestDBWrite, 2 /* charles LeBlanc */);
                                            TVFile tvFile = tvFileService.GetRead().FirstOrDefault();
                                            if (tvFile == null)
                                            {
                                                sb.AppendLine(@"            // Need to implement (no items found, would need to add at least one in the TestDB) [" + TypeName + " " + csspProp.PropName + " " + csspProp.ExistTypeName + " " + csspProp.ExistFieldID + "]");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = " + tvFile.TVFileID + ";");
                                            }
                                        }
                                        break;
                                    case "VPScenario":
                                        {
                                            VPScenarioService vpScenarioService = new VPScenarioService(LanguageEnum.en, dbTestDBWrite, 2 /* charles LeBlanc */);
                                            VPScenario vpScenario = vpScenarioService.GetRead().FirstOrDefault();
                                            if (vpScenario == null)
                                            {
                                                sb.AppendLine(@"            // Need to implement (no items found, would need to add at least one in the TestDB) [" + TypeName + " " + csspProp.PropName + " " + csspProp.ExistTypeName + " " + csspProp.ExistFieldID + "]");
                                            }
                                            else
                                            {
                                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = " + vpScenario.VPScenarioID + ";");
                                            }
                                        }
                                        break;
                                    case "TVItem":
                                        {
                                            if (TypeName == "MikeScenario" && csspProp.PropName == "ParentMikeScenarioID")
                                            {
                                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = null;");
                                            }
                                            else
                                            {
                                                TVItemService tvItemService = new TVItemService(LanguageEnum.en, dbTestDBWrite, 2 /* charles LeBlanc */);
                                                TVItem tvItem = tvItemService.GetRead().Where(c => c.TVType == csspProp.AllowableTVTypeList[0]).FirstOrDefault();
                                                if (tvItem == null)
                                                {
                                                    sb.AppendLine(@"            // Need to implement (no items found, would need to add at least one in the TestDB) [" + TypeName + " " + csspProp.PropName + " " + csspProp.ExistTypeName + " " + csspProp.ExistFieldID + "]");
                                                }
                                                else
                                                {
                                                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = " + tvItem.TVItemID + ";");
                                                }
                                            }
                                        }
                                        break;
                                    default:
                                        {
                                            sb.AppendLine(@"            // Need to implement [" + TypeName + " " + csspProp.PropName + " " + csspProp.ExistTypeName + " " + csspProp.ExistFieldID + "]");
                                        }
                                        break;
                                }
                            }
                            else if (csspProp.Min != null && csspProp.Max != null)
                            {
                                if (csspProp.Min > csspProp.Max)
                                {
                                    sb.AppendLine(@"            " + prop.Name + @" = MinBiggerMaxPleaseFix,");
                                }
                                else
                                {
                                    if (TypeName == "MWQMLookupMPN" && prop.Name == "Tubes01")
                                    {
                                        sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = 0;");
                                    }
                                    else if (TypeName == "MWQMLookupMPN" && prop.Name == "MPN_100ml")
                                    {
                                        sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = 14;");
                                    }
                                    else
                                    {
                                        sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandom" + propTypeTxt + "(" + csspProp.Min.ToString() + numbExt + ", " + csspProp.Max.ToString() + numbExt + ");");
                                    }
                                }
                            }
                            else if (csspProp.Min != null)
                            {
                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandom" + propTypeTxt + "(" + csspProp.Min.ToString() + numbExt + ", " + (csspProp.Min + 10).ToString() + numbExt + ");");
                            }
                            else if (csspProp.Max != null)
                            {
                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandom" + propTypeTxt + "(" + (csspProp.Max - 10).ToString() + numbExt + ", " + csspProp.Max.ToString() + numbExt + ");");
                            }
                            else
                            {
                                sb.AppendLine(@"            // should implement a Range for the property " + prop.Name + @" and type " + TypeName);
                            }
                        }
                    }
                    break;
                case "DateTime":
                case "DateTimeOffset":
                    {
                        switch (TypeName + "_" + csspProp.PropName)
                        {
                            case "AppTask_EndDateTime_UTC":
                            case "ClimateSite_HourlyEndDate_Local":
                            case "ClimateSite_DailyEndDate_Local":
                            case "ClimateSite_MonthlyEndDate_Local":
                            case "HydrometricSite_EndDate_Local":
                            case "MikeScenario_MikeScenarioEndDateTime_Local":
                            case "MikeSourceStartEnd_EndDateAndTime_Local":
                            case "MWQMRun_EndDateTime_Local":
                            case "MWQMSiteStartEndDate_EndDate":
                            case "MWQMSubsector_IncludeRainEndDate":
                            case "MWQMSubsector_NoRainEndDate":
                            case "MWQMSubsector_OnlyRainEndDate":
                            case "Spill_EndDateTime_Local":
                            case "TVItemLink_EndDateTime_Local":
                                break;
                            case "AppTask_StartDateTime_UTC":
                            case "ClimateSite_HourlyStartDate_Local":
                            case "ClimateSite_DailyStartDate_Local":
                            case "ClimateSite_MonthlyStartDate_Local":
                            case "HydrometricSite_StartDate_Local":
                            case "MikeScenario_MikeScenarioStartDateTime_Local":
                            case "MikeSourceStartEnd_StartDateAndTime_Local":
                            case "MWQMRun_StartDateTime_Local":
                            case "MWQMSiteStartEndDate_StartDate":
                            case "MWQMSubsector_IncludeRainStartDate":
                            case "MWQMSubsector_NoRainStartDate":
                            case "MWQMSubsector_OnlyRainStartDate":
                            case "Spill_StartDateTime_Local":
                            case "TVItemLink_StartDateTime_Local":
                                {
                                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = new DateTime(2005, 3, 6);");
                                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name.Replace("Start", "End") + @""") " + TypeNameLower + @"." + prop.Name.Replace("Start", "End") + @" = new DateTime(2005, 3, 7);");
                                }
                                break;
                            default:
                                {
                                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = new DateTime(2005, 3, 6);");
                                }
                                break;
                        }
                    }
                    break;
                case "Boolean":
                    {
                        sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = true;");
                    }
                    break;
                case "String":
                    {
                        if (csspProp.HasDataTypeAttribute) // will have to do this better ... works because it's only use when email
                        {
                            sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomEmail();");
                        }
                        else
                        {
                            if (csspProp.Min != null && csspProp.Max > 0)
                            {
                                if (csspProp.Min > csspProp.Max)
                                {
                                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = MinBiggerMaxLengthPleaseFix;");
                                }
                                else
                                {
                                    double? StrLen = (int)csspProp.Min + 5;
                                    if (StrLen > csspProp.Max)
                                    {
                                        StrLen = csspProp.Max;
                                    }
                                    sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomString(""""" + ", " + StrLen.ToString() + ");");
                                }
                            }
                            else if (csspProp.Min != null)
                            {
                                double StrLen = (int)csspProp.Min + 5;
                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomString(""""" + ", " + StrLen.ToString() + ");");
                            }
                            else if (csspProp.Max > 0)
                            {
                                double? StrLen = 5;
                                if (StrLen > csspProp.Max)
                                {
                                    StrLen = csspProp.Max;
                                }
                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomString(""""" + ", " + StrLen.ToString() + ");");
                            }
                            else
                            {
                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + @" = GetRandomString("""", 20);");
                            }
                        }
                    }
                    break;
                case "Byte[]":
                    {
                        if (TypeName == "ContactLogin")
                        {
                            if (csspProp.PropName == "PasswordSalt")
                            {
                                // Don't do anything for this property
                                // everything will be done while at the PasswordHash property
                            }

                            if (csspProp.PropName == "PasswordHash")
                            {
                                sb.AppendLine(@"            ContactService contactService = new ContactService(LanguageRequest, dbTestDB, ContactID);");
                                sb.AppendLine(@"");
                                sb.AppendLine(@"            Register register = new Register();");
                                sb.AppendLine(@"            register.Password = GetRandomPassword(); // the only thing needed for CreatePasswordHashAndSalt");
                                sb.AppendLine(@"");
                                sb.AppendLine(@"            byte[] passwordHash;");
                                sb.AppendLine(@"            byte[] passwordSalt;");
                                sb.AppendLine(@"            contactService.CreatePasswordHashAndSalt(register, out passwordHash, out passwordSalt);");
                                sb.AppendLine(@"");
                                sb.AppendLine(@"            if (OmitPropName != ""PasswordHash"") contactLogin.PasswordHash = passwordHash;");
                                sb.AppendLine(@"            if (OmitPropName != ""PasswordSalt"") contactLogin.PasswordSalt = passwordSalt;");
                            }
                        }
                    }
                    break;
                default:
                    {
                        if (csspProp.PropType.Contains("Enum"))
                        {
                            if (csspProp.PropType.Contains("LanguageEnum"))
                            {
                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + " = LanguageRequest;");
                            }
                            else
                            {
                                sb.AppendLine(@"            if (OmitPropName != """ + prop.Name + @""") " + TypeNameLower + @"." + prop.Name + " = (" + csspProp.PropType + @")GetRandomEnumType(typeof(" + csspProp.PropType + "));");
                            }
                        }
                        else
                        {
                            sb.AppendLine(@"            //Error: property [" + csspProp.PropName + "] and type [" + TypeName + "] is  not implemented");
                        }
                    }
                    break;
            }
        }
        #endregion Functions private

        #region Functions private
        public void GenerateCodeOf_ClassServiceTestGenerated()
        {
            FileInfo fiDLL = new FileInfo(servicesFiles.CSSPModelsDLL);

            if (!fiDLL.Exists)
            {
                ErrorEvent(new ErrorEventArgs(fiDLL.FullName + " does not exist"));
                return;
            }

            var importAssembly = Assembly.LoadFile(fiDLL.FullName);
            Type[] types = importAssembly.GetTypes();
            foreach (Type type in types)
            {
                bool ClassNotMapped = false;
                StringBuilder sb = new StringBuilder();
                string TypeName = type.Name;

                string TypeNameLower = "";

                if (type.Name.StartsWith("MWQM"))
                {
                    TypeNameLower = type.Name.Substring(0, 4).ToLower() + type.Name.Substring(4);
                }
                else if (type.Name.StartsWith("TV") || type.Name.StartsWith("VP"))
                {
                    TypeNameLower = type.Name.Substring(0, 2).ToLower() + type.Name.Substring(2);
                }
                else
                {
                    TypeNameLower = type.Name.Substring(0, 1).ToLower() + type.Name.Substring(1);
                }

                StatusTempEvent(new StatusEventArgs(TypeName));
                Application.DoEvents();

                if (modelsGenerateCodeHelper.SkipType(type))
                {
                    continue;
                }

                foreach (CustomAttributeData customAttributeData in type.CustomAttributes)
                {
                    if (customAttributeData.AttributeType.Name == "NotMappedAttribute")
                    {
                        ClassNotMapped = true;
                        break;
                    }
                }

                //if (TypeName != "Address")
                //{
                //    continue;
                //}

                sb.AppendLine(@"using System;");
                sb.AppendLine(@"using Microsoft.VisualStudio.TestTools.UnitTesting;");
                sb.AppendLine(@"using System.Linq;");
                sb.AppendLine(@"using System.Collections.Generic;");
                sb.AppendLine(@"using CSSPModels;");
                sb.AppendLine(@"using CSSPServices;");
                sb.AppendLine(@"using Microsoft.EntityFrameworkCore.Metadata;");
                sb.AppendLine(@"using System.Reflection;");
                sb.AppendLine(@"using CSSPEnums;");
                sb.AppendLine(@"using System.Security.Principal;");
                sb.AppendLine(@"using System.Globalization;");
                sb.AppendLine(@"using CSSPServices.Resources;");
                sb.AppendLine(@"using CSSPModels.Resources;");
                sb.AppendLine(@"using CSSPEnums.Resources;");
                sb.AppendLine(@"");
                sb.AppendLine(@"namespace CSSPServices.Tests");
                sb.AppendLine(@"{");
                sb.AppendLine(@"    [TestClass]");
                sb.AppendLine(@"    public partial class " + TypeName + "ServiceTest : TestHelper");
                sb.AppendLine(@"    {");
                sb.AppendLine(@"        #region Variables");
                sb.AppendLine(@"        #endregion Variables");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Properties");
                sb.AppendLine(@"        //private " + TypeName + @"Service " + TypeNameLower + @"Service { get; set; }");
                sb.AppendLine(@"        #endregion Properties");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Constructors");
                sb.AppendLine(@"        public " + TypeName + "ServiceTest() : base()");
                sb.AppendLine(@"        {");
                sb.AppendLine(@"            //" + TypeNameLower + @"Service = new " + TypeName + @"Service(LanguageRequest, dbTestDB, ContactID);");
                sb.AppendLine(@"        }");
                sb.AppendLine(@"        #endregion Constructors");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Functions public");
                sb.AppendLine(@"        #endregion Functions public");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Functions private");
                sb.AppendLine(@"        private " + TypeName + @" GetFilledRandom" + TypeName + @"(string OmitPropName)");
                sb.AppendLine(@"        {");
                sb.AppendLine(@"            " + TypeName + " " + TypeNameLower + @" = new " + TypeName + @"();");
                sb.AppendLine(@"");

                foreach (PropertyInfo prop in type.GetProperties())
                {
                    CSSPProp csspProp = new CSSPProp();
                    if (!modelsGenerateCodeHelper.FillCSSPProp(prop, csspProp, type))
                    {
                        return;
                    }

                    if (csspProp.IsKey || prop.GetGetMethod().IsVirtual || prop.Name == "ValidationResults")
                    {
                        continue;
                    }

                    CreateGetFilledRandomClass(prop, csspProp, TypeName, TypeNameLower, sb);
                }

                sb.AppendLine(@"");
                sb.AppendLine(@"            return " + TypeNameLower + @";");
                sb.AppendLine(@"        }");
                sb.AppendLine(@"        #endregion Functions private");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Tests Generated CRUD and Properties");
                sb.AppendLine(@"        [TestMethod]");
                sb.AppendLine(@"        public void " + TypeName + @"_CRUD_And_Properties_Test()");
                sb.AppendLine(@"        {");
                sb.AppendLine(@"            foreach (CultureInfo culture in AllowableCulture)");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                ChangeCulture(culture);");
                sb.AppendLine(@"");
                sb.AppendLine(@"                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))");
                sb.AppendLine(@"                {");
                sb.AppendLine(@"                    " + TypeName + "Service " + TypeNameLower + @"Service = new " + TypeName + @"Service(LanguageRequest, dbTestDB, ContactID);");
                sb.AppendLine(@"");
                sb.AppendLine(@"                    int count = 0;");
                sb.AppendLine(@"                    if (count == 1)");
                sb.AppendLine(@"                    {");
                sb.AppendLine(@"                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]");
                sb.AppendLine(@"                    }");
                sb.AppendLine(@"");
                sb.AppendLine(@"                    " + TypeName + @" " + TypeNameLower + @" = GetFilledRandom" + TypeName + @"("""");");
                sb.AppendLine(@"");

                sb.AppendLine(@"                    // -------------------------------");
                sb.AppendLine(@"                    // -------------------------------");
                sb.AppendLine(@"                    // CRUD testing");
                sb.AppendLine(@"                    // -------------------------------");
                sb.AppendLine(@"                    // -------------------------------");
                sb.AppendLine(@"");


                if (!ClassNotMapped)
                {
                    CreateClass_CRUD_Testing(TypeName, TypeNameLower, sb);
                    sb.AppendLine(@"");
                }

                sb.AppendLine(@"                    // -------------------------------");
                sb.AppendLine(@"                    // -------------------------------");
                sb.AppendLine(@"                    // Properties testing");
                sb.AppendLine(@"                    // -------------------------------");
                sb.AppendLine(@"                    // -------------------------------");
                sb.AppendLine(@"");

                if (!ClassNotMapped)
                {
                    foreach (PropertyInfo prop in type.GetProperties())
                    {
                        CSSPProp csspProp = new CSSPProp();
                        if (!modelsGenerateCodeHelper.FillCSSPProp(prop, csspProp, type))
                        {
                            return;
                        }

                        sb.AppendLine(@"");
                        sb.AppendLine(@"                    // -----------------------------------");
                        if (csspProp.IsKey)
                        {
                            sb.AppendLine(@"                    // [Key]");
                        }
                        if (csspProp.IsNullable)
                        {
                            sb.AppendLine(@"                    // Is Nullable");
                        }
                        else
                        {
                            sb.AppendLine(@"                    // Is NOT Nullable");
                        }
                        if (csspProp.IsVirtual)
                        {
                            sb.AppendLine(@"                    // [IsVirtual]");
                        }
                        if (csspProp.HasCompareAttribute)
                        {
                            sb.AppendLine(@"                    // [Compare(OtherField = " + csspProp.OtherField + ")]");
                        }
                        if (csspProp.HasCSSPAfterAttribute)
                        {
                            sb.AppendLine(@"                    // [CSSPAfter(Year = " + csspProp.Year + ")]");
                        }
                        if (csspProp.HasCSSPAllowNullAttribute)
                        {
                            sb.AppendLine(@"                    // [CSSPAllowNull]");
                        }
                        if (csspProp.HasCSSPBiggerAttribute)
                        {
                            sb.AppendLine(@"                    // [CSSPBigger(OtherField = " + csspProp.OtherField + ")]");
                        }
                        if (csspProp.HasCSSPEnumTypeAttribute)
                        {
                            sb.AppendLine(@"                    // [CSSPEnumType]");
                        }
                        if (csspProp.HasCSSPExistAttribute)
                        {
                            sb.AppendLine(@"                    // [CSSPExist(ExistTypeName = """ + csspProp.ExistTypeName + @""", ExistPlurial = """ + csspProp.ExistPlurial + @""", ExistFieldID = """ + csspProp.ExistFieldID + @""", AllowableTVtypeList = " + String.Join(",", csspProp.AllowableTVTypeList) + ")]");
                        }
                        if (csspProp.HasCSSPFillAttribute)
                        {
                            sb.AppendLine(@"                    // [CSSPFill(FillTypeName = """ + csspProp.FillTypeName + @""", FillPlurial = """ + csspProp.FillPlurial + @""", FillFieldID = """ + csspProp.FillFieldID + @""", FillEqualField = """ + csspProp.FillEqualField + @""", FillReturnField = """ + csspProp.FillReturnField + @""", FillNeedLanguage = """ + csspProp.FillReturnField + @""")]");
                        }
                        if (csspProp.HasDataTypeAttribute)
                        {
                            sb.AppendLine(@"                    // [DataType(DataType." + csspProp.dataType.ToString() + @")]");
                        }
                        if (csspProp.HasNotMappedAttribute)
                        {
                            sb.AppendLine(@"                    // [NotMapped]");
                        }
                        if (csspProp.HasRangeAttribute)
                        {
                            sb.AppendLine(@"                    // [Range(" + csspProp.Min + ", " + (csspProp.Max == null ? "-1" : csspProp.Max.ToString()) + ")]");
                        }
                        if (csspProp.HasStringLengthAttribute)
                        {
                            sb.AppendLine(@"                    // [StringLength(" + csspProp.Max + (csspProp.Min == null ? ")" : ", MinimumLength = " + csspProp.Min.ToString()) + ")]");
                        }
                        sb.AppendLine(@"                    // " + TypeNameLower + "." + csspProp.PropName + "   (" + csspProp.PropType + ")");
                        sb.AppendLine(@"                    // -----------------------------------");
                        sb.AppendLine(@"");

                        if (csspProp.IsVirtual || csspProp.PropName == "ValidationResults")
                        {
                            continue;
                        }
                        if (csspProp.IsKey)
                        {
                            CreateClass_Key_Testing(csspProp, TypeName, TypeNameLower, sb);
                        }

                        CreateClass_CSSPExist_Testing(csspProp, TypeName, TypeNameLower, sb);
                        CreateClass_CSSPEnumType_Testing(csspProp, TypeName, TypeNameLower, sb);
                        CreateClass_Required_Properties_Testing(csspProp, TypeName, TypeNameLower, sb);
                        CreateClass_Min_And_Max_Properties_Testing(csspProp, TypeName, TypeNameLower, sb);
                    }
                }

                sb.AppendLine(@"                }");
                sb.AppendLine(@"            }");
                sb.AppendLine(@"        }");

                sb.AppendLine(@"        #endregion Tests Generated CRUD and Properties");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Tests Generated Get With Key");
                if (!ClassNotMapped)
                {
                    sb.AppendLine(@"        [TestMethod]");
                    sb.AppendLine(@"        public void " + TypeName + @"_Get_With_Key_Test()");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"            foreach (CultureInfo culture in AllowableCulture)");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                ChangeCulture(culture);");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))");
                    sb.AppendLine(@"                {");
                    sb.AppendLine(@"                    " + TypeName + @"Service " + TypeNameLower + @"Service = new " + TypeName + @"Service(LanguageRequest, dbTestDB, ContactID);");
                    sb.AppendLine(@"                    " + TypeName + @" " + TypeNameLower + @" = (from c in " + TypeNameLower + @"Service.GetRead() select c).FirstOrDefault();");
                    sb.AppendLine(@"                    Assert.IsNotNull(" + TypeNameLower + @");");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"                    " + TypeName + @" " + TypeNameLower + @"Ret = " + TypeNameLower + @"Service.Get" + TypeName + @"With" + TypeName + @"ID(" + TypeNameLower + @"." + TypeName + @"ID);");
                    bool FirstNotMapped = true;
                    foreach (PropertyInfo prop in type.GetProperties())
                    {
                        CSSPProp csspProp = new CSSPProp();
                        if (!modelsGenerateCodeHelper.FillCSSPProp(prop, csspProp, type))
                        {
                            return;
                        }
                        if (csspProp.HasNotMappedAttribute)
                        {
                            if (csspProp.PropName == "ValidationResults")
                            {
                                continue;
                            }

                            if (TypeName == "ContactLogin" && (csspProp.PropName == "Password" || csspProp.PropName == "ConfirmPassword"))
                            {
                                continue;
                            }

                            if (TypeName == "ResetPassword" && (csspProp.PropName == "Password" || csspProp.PropName == "ConfirmPassword"))
                            {
                                continue;
                            }

                            if (FirstNotMapped)
                            {
                                FirstNotMapped = !FirstNotMapped;
                                sb.AppendLine(@"");
                            }
                            if (csspProp.HasCSSPFillAttribute)
                            {
                                bool FillEqualFieldIsNullable = false;
                                foreach (PropertyInfo prop2 in type.GetProperties())
                                {
                                    CSSPProp csspProp2 = new CSSPProp();
                                    if (!modelsGenerateCodeHelper.FillCSSPProp(prop2, csspProp2, type))
                                    {
                                        return;
                                    }

                                    if (csspProp2.PropName == csspProp.FillEqualField)
                                    {
                                        if (csspProp2.IsNullable)
                                        {
                                            FillEqualFieldIsNullable = true;
                                        }
                                    }
                                }
                                if (FillEqualFieldIsNullable)
                                {
                                    sb.AppendLine(@"                    if (" + TypeNameLower + @"Ret." + csspProp.FillEqualField + @" != null)");
                                    sb.AppendLine(@"                    {");
                                }
                                sb.AppendLine(@"                    " + (FillEqualFieldIsNullable ? "   " : "") + @"Assert.IsNotNull(" + TypeNameLower + @"Ret." + csspProp.PropName + @");");
                                if (csspProp.PropType == "String")
                                {
                                    sb.AppendLine(@"                    " + (FillEqualFieldIsNullable ? "   " : "") + @"Assert.IsFalse(string.IsNullOrWhiteSpace(" + TypeNameLower + @"Ret." + csspProp.PropName + @"));");
                                }
                                if (FillEqualFieldIsNullable)
                                {
                                    sb.AppendLine(@"                    }");
                                }
                            }
                            else
                            {
                                sb.AppendLine(@"                    Assert.IsNotNull(" + TypeNameLower + @"Ret." + csspProp.PropName + @");");
                                if (csspProp.PropType == "String")
                                {
                                    sb.AppendLine(@"                    Assert.IsFalse(string.IsNullOrWhiteSpace(" + TypeNameLower + @"Ret." + csspProp.PropName + @"));");
                                }
                            }
                        }
                        else
                        {
                            if (csspProp.IsNullable)
                            {
                                sb.AppendLine(@"                    if (" + TypeNameLower + @"Ret." + csspProp.PropName + @" != null)");
                                sb.AppendLine(@"                    {");
                            }
                            sb.AppendLine(@"                    " + (csspProp.IsNullable ? "   " : "") + @"Assert.IsNotNull(" + TypeNameLower + @"Ret." + csspProp.PropName + @");");
                            if (csspProp.PropType == "String")
                            {
                                sb.AppendLine(@"                    " + (csspProp.IsNullable ? "   " : "") + @"Assert.IsFalse(string.IsNullOrWhiteSpace(" + TypeNameLower + @"Ret." + csspProp.PropName + @"));");
                            }
                            if (csspProp.IsNullable)
                            {
                                sb.AppendLine(@"                    }");
                            }
                        }
                    }

                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"        }");
                }
                sb.AppendLine(@"        #endregion Tests Get With Key");
                sb.AppendLine(@"");
                sb.AppendLine(@"    }");
                sb.AppendLine(@"}");

                FileInfo fiOutputGen = new FileInfo(servicesFiles.BaseDir + servicesFiles.BaseDirTest + TypeName + "ServiceTestGenerated.cs");
                using (StreamWriter sw2 = fiOutputGen.CreateText())
                {
                    sw2.Write(sb.ToString());
                }

                ErrorEvent(new ErrorEventArgs("Created [" + fiOutputGen.FullName + "] ..."));

                StatusTempEvent(new StatusEventArgs("Done ..."));
            }
        }
        #endregion Functions private
    }
}
