using Utm.Builder.Core.Extensions;
using Utm.Builder.Core.ValueObjects;
using Utm.Builder.Core.ValueObjects.Exceptions;

namespace Utm.Builder.Core;

public class UtmLink
{
    public UtmLink(Url url, Campaign campaign)
    {
        Url = url;
        Campaign = campaign;
    }

    /// <summary>
    /// URL (Website Link)
    /// </summary>
    public Url Url { get; set; }

    /// <summary>
    /// Campaign Details
    /// </summary>
    public Campaign Campaign { get; set; }

    // static implicit operator -> quero transformar um utm em uma string, retorno deve ser um string
    public static implicit operator string(UtmLink utm)
        => utm.ToString();

    // static implicit operator -> transformar um string em utm
    public static implicit operator UtmLink(string link)
    {
        if (string.IsNullOrEmpty(link))
            throw new InvalidUrlException();

        var url = new Url(link);
        var segments = url.Address.Split("?");
        if (segments.Length == 1)
            throw new InvalidUrlException("No segments were provided");

        var pars = segments[1].Split("&");
        var source = pars.Where(x => x.StartsWith("utm_source")).FirstOrDefault("").Split("=")[1];
        var medium = pars.Where(x => x.StartsWith("utm_medium")).FirstOrDefault("").Split("=")[1];
        var name = pars.Where(x => x.StartsWith("utm_campaign")).FirstOrDefault("").Split("=")[1];
        var id = pars.Where(x => x.StartsWith("utm_id")).FirstOrDefault("").Split("=")[1];
        var term = pars.Where(x => x.StartsWith("utm_term")).FirstOrDefault("").Split("=")[1];
        var content = pars.Where(x => x.StartsWith("utm_content")).FirstOrDefault("").Split("=")[1];

        var utm = new UtmLink(
            new Url(segments[0]),
            new Campaign(source, medium, name, id, term, content));
        return utm;
    }

    public override string ToString()
    {
        var segments = new List<string>();
        segments.AddIfNotNull("utm_source", Campaign.Source);
        segments.AddIfNotNull("utm_medium", Campaign.Medium);
        segments.AddIfNotNull("utm_campaign", Campaign.Name);
        segments.AddIfNotNull("utm_id", Campaign.Id);
        segments.AddIfNotNull("utm_term", Campaign.Term);
        segments.AddIfNotNull("utm_content", Campaign.Content);
        return $"{Url.Address}?{string.Join("&", segments)}";
    }

}
