using System.Text.RegularExpressions;
using SkiaSharp;

namespace FIT_Api_Example.Helper;

public static class Class
{
    public static string RemoveTags(this string input)
    {
        return Regex.Replace(input, "<.*?>", String.Empty);
    }

    public static List<T> GetRandomElements<T>(this IEnumerable<T> list, int elementsCount)
    {
        return list.OrderBy(arg => Guid.NewGuid()).Take(elementsCount).ToList();
    }

    public static string RandomString(int size)
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        Random random = new Random();
        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
        }
        return builder.ToString();
    }

    public static byte[] ParsirajBase64(this string base64string)
    {
        base64string = base64string.Split(',')[1];
        return System.Convert.FromBase64String(base64string);
    }

    public static byte[]? resize(byte[] slikaBajtovi, int size, int quality = 75)
    {
        using var input = new MemoryStream(slikaBajtovi);
        using var inputStream = new SKManagedStream(input);
        using var original = SKBitmap.Decode(inputStream);
        int width, height;
        if (original.Width > original.Height)
        {
            width = size;
            height = original.Height * size / original.Width;
        }
        else
        {
            width = original.Width * size / original.Height;
            height = size;
        }

        using var resized = original
            .Resize(new SKImageInfo(width, height), SKBitmapResizeMethod.Lanczos3);
        if (resized == null) return null;

        using var image = SKImage.FromBitmap(resized);
        return image.Encode(SKEncodedImageFormat.Jpeg, quality)
            .ToArray();
    }
}