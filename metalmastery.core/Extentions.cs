﻿namespace MetalMastery.Core
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
    }
}
