using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Shared.Paging;
public class PaginationMiddleware
{
    private readonly RequestDelegate _next;

    public PaginationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var originalBody = context.Response.Body;
        try
        {
            var memoryStream = new MemoryStream();
            context.Response.Body = memoryStream;

            await _next(context);

            if (context.Response.ContentType == "application/json; charset=utf-8")
            {
                var responseBody = Encoding.UTF8.GetString(memoryStream.ToArray());
                var responseObject = JsonConvert.DeserializeObject(responseBody);

                if (responseObject.GetType().IsGenericType)
                {
                    if (responseObject.GetType().GetGenericTypeDefinition() == typeof(PagedList<>))
                    {
                        var metaData = new
                        {
                            TotalCount = responseObject.GetType().GetProperty("TotalCount").GetValue(responseObject),
                            PageSize = responseObject.GetType().GetProperty("PageSize").GetValue(responseObject),
                            CurrentPage = responseObject.GetType().GetProperty("CurrentPage").GetValue(responseObject),
                            HasNext = responseObject.GetType().GetProperty("HasNext").GetValue(responseObject),
                            HasPrevious = responseObject.GetType().GetProperty("HasPrevious").GetValue(responseObject)
                        };
                        context.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metaData));
                    }
                }
            }

            memoryStream.Position = 0;
            await memoryStream.CopyToAsync(originalBody);
        }
        finally
        {
            context.Response.Body = originalBody;
        }
    }
}