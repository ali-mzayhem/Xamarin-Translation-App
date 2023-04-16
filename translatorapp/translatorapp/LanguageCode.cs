using System;
namespace translatorapp
{
    
		public class LanguageCode
		{
			string Language;
			string Code;

			public LanguageCode(string language, string code)
			{
				this.Language = language;
				this.Code = code;

			}
			public string getCode()
			{
				return Code;
			}
		public string getLanguage()
		{
			return Language;
		}
	}
	
}

