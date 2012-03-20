namespace MetalMastery.Core.Web
{
    public static class Extentions
    {
        public static string GetPreviewText(this string str)
        {
            const int previewTxtLength = 100;

            return str != null && str.Length > previewTxtLength
                       ? HtmlRemoval.StripTags(str.Substring(0, previewTxtLength)) + ("...")
                       : str;
        }
    }
}
