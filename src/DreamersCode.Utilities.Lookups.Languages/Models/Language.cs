#if NET8_0_OR_GREATER
using System.Collections.Frozen;
#endif
using System.Collections.Generic;

namespace DreamersCode.Utilities.Lookups.Languages.Models
{
    /// <summary>
    /// Provides display information for the given language
    /// </summary>
    public record DisplayInfo
    {
        /// <summary>
        /// The Three letter code representing language code (based on the ISO-639-2)
        /// </summary>
        public string LanguageCode { get; private set; }

        /// <summary>
        /// The way the record needs to be displayed for the given language
        /// </summary>
        public string DisplayValue { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="langCode">The Three letter code representing language code (based on the ISO-639-2)</param>
        /// <param name="displayValue">The way the record needs to be displayed for the given language</param>
        public DisplayInfo(string langCode, string displayValue)
        {
            LanguageCode = langCode;
            DisplayValue = displayValue;
        }

    }
    /// <summary>
    /// Model representation of a language as per ISO 639-2
    /// </summary>
    public record Language
    {
        /// <summary>
        /// Three letter code representing the language as per ISO 639-2
        /// </summary>
        public string ThreeLetterCode{ get; private set; }

        /// <summary>
        /// Two letter code that represents the language based on ISO 639-1
        /// </summary>
        public string? TwoLetterCode { get; private set; }
        
#if NET8_0_OR_GREATER
        /// <summary>
        /// The names of the language for a given language code.  English is always present, other languages might be missing
        /// </summary>
        public FrozenSet<DisplayInfo> LanguageNames { get; internal set; }
#else
        /// <summary>
        /// The names of the language for a given language code.  English is always present, other languages might be missing
        /// </summary>
        public IReadOnlyCollection<DisplayInfo> LanguageNames{ get; internal set; }
#endif


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="threeLetterCode">The three letter code as per ISO 639-2 representing the language</param>
        /// <param name="twoLetterCode">The three letter code as per ISO 639-1 representing the language</param>        
        /// <param name="langNames">Names for the language based on the language code</param>        
        public Language(string threeLetterCode, string? twoLetterCode, List<DisplayInfo> langNames)
        {
            ThreeLetterCode = threeLetterCode;
            TwoLetterCode = twoLetterCode;
#if NET8_0_OR_GREATER
            LanguageNames = langNames.ToFrozenSet();
#else
            LanguageNames = langNames;
#endif
        }
    }
}
