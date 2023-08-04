using System.Text.RegularExpressions;

namespace Utm.Builder.Core.ValueObjects.Exceptions;

<<<<<<< HEAD
public partial class InvalidUrlException : Exception
{
    private const string DefaultErrorMessage = "Invalid URL";

    public InvalidUrlException(string message = DefaultErrorMessage)
        : base(message)
    {
    }

    public static void ThrowIfInvalid(string address, string message = DefaultErrorMessage)
    {
        if (string.IsNullOrEmpty(address))
            throw new InvalidUrlException(message);

        if (!UrlRegex().IsMatch(address))
            throw new InvalidUrlException();
    }

    [GeneratedRegex(
        "^(http|https):(\\/\\/www\\.|\\/\\/www\\.|\\/\\/|\\/\\/)[a-z0-9]+([\\-\\.]{1}[a-z0-9]+)*\\.[a-z]{2,5}(:[0-9]{1,5})?(\\/.*)?$|(http|https):(\\/\\/localhost:\\d*|\\/\\/127\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]))(:[0-9]{1,5})?(\\/.*)?$")]
    private static partial Regex UrlRegex();
=======
public class InvalidUrlException : Exception
{
    private const string DefaultErrorMessage = "Invalid Url";
    private const string UrlRegexPattern =
        @"^(http|https):(\\/\\/www\\.|\\/\\/www\\.|\\/\\/|\\/\\/)[a-z0-9]+([\\-\\.]{1}[a-z0-9]+)*\\.[a-z]{2,5}(:[0-9]{1,5})?(\\/.*)?$|(http|https):(\\/\\/localhost:\\d*|\\/\\/127\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]))(:[0-9]{1,5})?(\\/.*)?$";

    public InvalidUrlException(string message = "Invalid URL") 
        : base(message) 
    {
    
    }

    public static void ThrowIfInvalid(string address, string message)
    {
        if(string.IsNullOrEmpty(address))
            throw new InvalidUrlException(message);

        if(!Regex.IsMatch(address, UrlRegexPattern))
            throw new InvalidUrlException(message);
    }

    public static void ThrowIfInvalidUrl(string address)
    {
        throw new NotImplementedException();
    }
>>>>>>> 0a22806f5e46b2731b7db91ddb01fdaa4f35dbbe
}
