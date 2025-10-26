using System.Text;

namespace LFC.BuildingBlocks.Core.Common
{
    public static class StringUtils
    {
        public static string OnlyNumbers(string value)
        {
            var sb = new StringBuilder();
            foreach (var ch in value)
                if (char.IsDigit(ch))
                    sb.Append(ch);
            return sb.ToString();
        }
    }
}
