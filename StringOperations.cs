using System.Web;

namespace Oyku
{
    public static class StringOperations
    {
        public static string ClearCharacters(string text)
        {
            string returnValue = text.ToLower();
            returnValue = DisableTurkishCharacters(returnValue);
            returnValue = DisableSymbolCharacters(returnValue);
            returnValue = HttpContext.Current.Server.UrlEncode(returnValue);
            return returnValue;
        }

        private static string DisableSymbolCharacters(string InputText)
        {
            string value = InputText.Trim();
            value = value.Replace("    ", " ");
            value = value.Replace("   ", " ");
            value = value.Replace("  ", " ");
            value = value.Replace(" ", "-");
            value = value.Replace(" ", "-");

            value = value.Replace("<", ""); value = value.Replace(">", "");
            value = value.Replace("\"", ""); value = value.Replace("/", "");

            value = value.Replace("(", ""); value = value.Replace(")", "");
            value = value.Replace("{", ""); value = value.Replace("}", "");
            value = value.Replace("%", ""); value = value.Replace("&", "");
            value = value.Replace("+", ""); value = value.Replace(",", "");
            value = value.Replace("?", ""); value = value.Replace(".", "");
            value = value.Replace("#", ""); value = value.Replace(";", "");
            value = value.Replace("'", ""); value = value.Replace(":", "");
            value = value.Replace("*", "-"); value = value.Replace("”", "");
            value = value.Replace("½", ""); value = value.Replace("˝", "");
            value = value.Replace("[", ""); value = value.Replace("]", "");
            value = value.Replace("!", ""); value = value.Replace("~", "");
            value = value.Replace("`", ""); value = value.Replace("|", "");
            value = value.Replace("™", "");
            value = value.Replace("----", "-");
            value = value.Replace("---", "-");
            value = value.Replace("--", "-");
            value = value.Trim();
            return value;
        }

        private static string DisableTurkishCharacters(string InputText)
        {
            string retVal = InputText;

            retVal = retVal.Replace("ı", "i");
            retVal = retVal.Replace("İ", "I");
            retVal = retVal.Replace("Ü", "U");
            retVal = retVal.Replace("ü", "u");
            retVal = retVal.Replace("Ö", "O");
            retVal = retVal.Replace("ö", "o");
            retVal = retVal.Replace("Ç", "C");
            retVal = retVal.Replace("ç", "c");
            retVal = retVal.Replace("Ş", "S");
            retVal = retVal.Replace("ş", "s");
            retVal = retVal.Replace("Ğ", "G");
            retVal = retVal.Replace("ğ", "g");

            return retVal;
        }
    }
}