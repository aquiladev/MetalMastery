namespace MetalMastery.Core
{
    public static class Extentions
    {
        public static int ToInt(this string str)
        {
            int result;
            if (int.TryParse(str, out result))
                return result;
            return default(int);
        }

        public static string GetPreviewText(this string str)
        {
            const int previewTxtLength = 50;

            return str != null && str.Length > previewTxtLength
                       ? str.Substring(0, previewTxtLength) + ("...")
                       : str;
        }
    }
}
