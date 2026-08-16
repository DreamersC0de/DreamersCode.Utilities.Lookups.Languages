
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DreamersCode.Utilities.Lookups.Languages.Tests
{
    [TestClass]
    public class BasicTests
    {       
        [TestMethod]
        public void FetchOneLanguage()
        {
            var result = LanguageCollection.AllLanguages.SingleOrDefault(x => x.ThreeLetterCode.Equals("MLT", StringComparison.OrdinalIgnoreCase));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void FetchMoreThenOneLanguage()
        {
            var result = LanguageCollection.AllLanguages.Where(x => x.TwoLetterCode != null);


            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.IsGreaterThan(1, result.Count());
        }
        [TestMethod]
        public void AllLanguages_IsPopulated()
        {
            Assert.IsNotNull(LanguageCollection.AllLanguages);
            Assert.IsTrue(LanguageCollection.AllLanguages.Any(), "AllLanguages should contain at least one entry.");
        }

        [TestMethod]
        public void Lookup_ByTwoLetterCode_Returns_Expected_ThreeLetterCode()
        {
            var result = LanguageCollection.AllLanguages
                .SingleOrDefault(x => string.Equals(x.TwoLetterCode, "en", StringComparison.OrdinalIgnoreCase));

            Assert.IsNotNull(result, "Language with TwoLetterCode 'en' should exist.");
            Assert.AreEqual("eng", result.ThreeLetterCode, ignoreCase: true);
        }

        [TestMethod]
        public void EveryLanguage_Has_English_DisplayName()
        {
            foreach (var lang in LanguageCollection.AllLanguages)
            {
                Assert.IsTrue(
                    lang.LanguageNames.Any(n => string.Equals(n.LanguageCode, "eng", StringComparison.OrdinalIgnoreCase)),
                    $"Missing English display name for language '{lang.ThreeLetterCode}'");
            }
        }

        [TestMethod]
        public void ThreeLetterCodes_Are_Unique()
        {
            var duplicates = LanguageCollection.AllLanguages
                .GroupBy(l => l.ThreeLetterCode?.ToLowerInvariant())
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            string collectedDupplicates = string.Empty;
            foreach (var item in duplicates)
            {
                collectedDupplicates += $",{item}";
            }

            Assert.IsFalse(duplicates.Any(), $"Duplicate ThreeLetterCode(s) found: {collectedDupplicates}");
        }

        [TestMethod]
        public void TwoLetterCodes_WhenPresent_AreLengthTwo()
        {
            foreach (var lang in LanguageCollection.AllLanguages.Where(l => l.TwoLetterCode != null))
            {
                Assert.AreEqual(2, lang.TwoLetterCode!.Length, $"TwoLetterCode for '{lang.ThreeLetterCode}' must be length 2.");
            }
        }

        [TestMethod]
        public void DisplayInfo_Entries_Are_NotEmpty()
        {
            foreach (var lang in LanguageCollection.AllLanguages)
            {
                foreach (var di in lang.LanguageNames)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(di.LanguageCode), $"LanguageCode empty for display entry on '{lang.ThreeLetterCode}'");
                    Assert.IsFalse(string.IsNullOrWhiteSpace(di.DisplayValue), $"DisplayValue empty for display entry on '{lang.ThreeLetterCode}'");
                }
            }
        }

        [TestMethod]
        public void Can_Find_By_DisplayValue_CaseInsensitive()
        {
            var found = LanguageCollection.AllLanguages
                .SingleOrDefault(l => l.LanguageNames.Any(n => string.Equals(n.DisplayValue, "Maltese", StringComparison.OrdinalIgnoreCase)));

            Assert.IsNotNull(found, "Should find language by display value 'Maltese'");
            Assert.AreEqual("mlt", found.ThreeLetterCode, ignoreCase: true);
        }
    }
}
