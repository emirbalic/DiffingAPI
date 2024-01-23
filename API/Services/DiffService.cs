using API.Models;
using API.Util;

namespace API.Services
{
    public class DiffService
    {
        public static DiffResponse GetDiffResponse(Item item)
        {
            string encodedStringLeft = item.Left;
            string encodedStringRight = item.Right;

            string decodedStringLeft = Helper.ConvertBase64(encodedStringLeft);
            string decodedStringRight = Helper.ConvertBase64(encodedStringRight);

            string binLeft = Helper.GetBytesAsString(decodedStringLeft);
            string binRight = Helper.GetBytesAsString(decodedStringRight);


            var diffs = new List<Diff>();
            var length = 0;

            for (int i = 0; i < binLeft.Length; i++)
            {

                if (binLeft[i] != binRight[i])
                {
                    length++;
                    diffs.Add(
                        new Diff
                        {
                            Offset = i,
                            Length = length
                        });
                }
            }

            var diffResponse = new DiffResponse
            {
                DiffResultType = "ContentDoNotMatch",
                Diffs = diffs
            };
            return diffResponse;
        }
    }
}
