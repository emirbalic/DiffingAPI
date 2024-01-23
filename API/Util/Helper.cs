using System.Text;

namespace API.Util
{
    public class Helper
    {
        public static string GetBytesAsString(string s)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var chars = s.ToCharArray();

            foreach (char c in chars)
            {
                stringBuilder.Append(((int)c).ToString("x"));
            }
            return stringBuilder.ToString();
        }

        public static string ConvertBase64(string s)
        {
            
            return Encoding.UTF8.GetString(Convert.FromBase64String(s)); ;
        }

        public static bool IsBase64String(string base64)
        {
            Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
            return Convert.TryFromBase64String(base64, buffer, out int bytesParsed);
        }
    }
}
