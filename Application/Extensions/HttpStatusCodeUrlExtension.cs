using System.Net;

namespace Application.Extensions;

public static class HttpStatusCodeUrlExtension
{
    private static readonly Dictionary<HttpStatusCode, string?> _url = new()
    {
        [HttpStatusCode.BadRequest] = "https://www.rfc-editor.org/rfc/rfc7231#section-6.5.4",
        [HttpStatusCode.InternalServerError] = "https://www.rfc-editor.org/rfc/rfc7231#sectio",
        [HttpStatusCode.UnprocessableEntity] = "https://www.rfc-editor.org/rfc/rfc2518#section-10.3",
    };

    public static string? GetUriProblemType(this HttpStatusCode statusCode)
    {
        _url.TryGetValue(statusCode, out var type);
        return type ?? "about:blank";
    }

    public static string? GetUriProblemType(this int statusCode)
    {
        return ((HttpStatusCode)statusCode).GetUriProblemType();
    }
}
