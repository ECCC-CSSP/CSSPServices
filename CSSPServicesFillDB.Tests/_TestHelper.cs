using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using CSSPModels;
using CSSPServices;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using System.Text;
using CSSPEnums;
using System.Security.Principal;
using System.Threading;
using System.Globalization;

namespace CSSPServicesFillDB.Tests
{
    public partial class TestHelper
    {
        #region Variables
        StringBuilder sb = new StringBuilder();
        Random random = new Random();
        #endregion Variables

        #region Properties
        public LanguageEnum LanguageRequest { get; set; }
        public List<CultureInfo> AllowableCulture { get; set; }
        public int ContactID = 1;
        #endregion Properties

        #region Constructors
        public TestHelper()
        {
            AllowableCulture = new List<CultureInfo>() { new CultureInfo("en-CA"), new CultureInfo("fr-CA")/*, new CultureInfo("es-ES")*/ };
            random = new Random();
        }
        #endregion Constructors

        #region Functions public
        public Contact GetRandomContact()
        {
            Contact contact = null;

            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.MemoryTestDB))
            {
                ContactService contactService = new ContactService(LanguageRequest, db, ContactID);

                int Count = contactService.GetRead().Count();

                if (Count == 0)
                {
                    return new Contact() { ContactID = 0 };
                }

                int skip = random.Next(0, Count);

                contact = contactService.GetRead().Skip(skip).Take(1).FirstOrDefault<Contact>();
            }

            return contact;
        }
        public DateTime GetRandomDateTime()
        {
            int Year = random.Next(2005, 2050);
            int Month = random.Next(1, 12);
            int Day = random.Next(1, 28);
            int Hour = random.Next(1, 24);
            int Minute = random.Next(0, 60);
            int Second = random.Next(0, 60);

            return new DateTime(Year, Month, Day, Hour, Minute, Second);
        }
        public double GetRandomDouble(double min, double max)
        {
            return min + (random.NextDouble() * (max - min));
        }
        public string GetRandomEmail()
        {
            string Part1 = GetRandomString("", 12);
            string Part2 = GetRandomString("", 12);
            string Part3 = GetRandomString("", 3);
            string Part4 = GetRandomString("", 2);
            string Part5 = GetRandomString("", 2);

            string Email = Part1 + "." + Part2 + "@" + Part3 + "." + Part4 + "." + Part5;

            return Email;
        }
        public float GetRandomFloat(float min, float max)
        {
            return (float)(min + (random.NextDouble() * (max - min)));
        }
        public Guid GetRandomGuid()
        {
            Guid guid = new Guid();

            return guid;
        }
        public int GetRandomInt(int min, int max)
        {
            int randomInt = 0;
            randomInt = random.Next(min, max);

            return randomInt;
        }
        public string GetRandomPassword()
        {
            string Part1 = GetRandomString("", 7);
            int Part2 = GetRandomInt(1, 20);

            string Password = Part1 + Part2 + "!";

            return Password;
        }
        public string GetRandomString(string startString, int length)
        {
            string retStr = startString;

            if (retStr.Length > length)
            {
                retStr = retStr.Substring(0, length);
            }
            else
            {
                int Count = length - retStr.Length;
                for (int i = 0; i < Count; i++)
                {
                    retStr += (char)random.Next(97, 122);
                }
            }

            return retStr;
        }
        public string GetRandomTel()
        {
            string Part1 = GetRandomInt(1, 1).ToString();
            string Part2 = GetRandomInt(506, 506).ToString();
            string Part3 = GetRandomInt(200, 900).ToString();
            string Part4 = GetRandomInt(1000, 9000).ToString();

            string Email = Part1 + " (" + Part2 + ") " + Part3 + "-" + Part4;

            return Email;
        }
        public TVItem GetRandomTVItem(TVTypeEnum TVType)
        {
            TVItem tvItem = null;
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.MemoryTestDB))
            {
                TVItemService tvItemService = new TVItemService(LanguageRequest, db, ContactID);

                int Count = tvItemService.GetRead().Where(c => c.TVType == TVType).Count();

                if (Count == 0)
                {
                    return new TVItem() { TVItemID = 0 };
                }

                int skip = random.Next(0, Count);

                tvItem = tvItemService.GetRead().Where(c => c.TVType == TVType).Skip(skip).Take(1).FirstOrDefault<TVItem>();
            }

            return tvItem;
        }
        public int GetRandomEnumType(Type enumType)
        {
            int retValue = 0;

            int count = Enum.GetNames(enumType).Count();

            int[] valArr = Enum.GetValues(enumType) as int[];

            List<int> valList = (from c in valArr.ToList()
                                 where c > 0
                                 orderby c
                                 select c).ToList();

            int Min = valList.ToList().FirstOrDefault();
            int Max = valList.ToList().OrderByDescending(c => c).FirstOrDefault();

            retValue = GetRandomInt(Min, Max);
            while (!valList.Where(c => c == retValue).Any())
            {
                retValue = GetRandomInt(Min, Max);
            }

            return retValue;
        }
        public void SetupTestHelper(CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            if (culture.TwoLetterISOLanguageName == "fr")
            {
                LanguageRequest = LanguageEnum.fr;
            }
            else if (culture.TwoLetterISOLanguageName == "es")
            {
                LanguageRequest = LanguageEnum.es;
            }
            else
            {
                LanguageRequest = LanguageEnum.en;
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private


    }
}
