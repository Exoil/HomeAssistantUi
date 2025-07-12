using System.Net.Http.Json;

using HomeAssistantUi.Common;
using HomeAssistantUi.Common.Exceptions;

using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace HomeAssistantUi.Services;

public sealed class HomeAssistantApiService :
    IDisposable,
    IAsyncDisposable,
    IHomeAssistantApiService
{
    private const string FieldFileName = "bills";
    private readonly HttpClient _httpClient;
    private bool _disposed;

    public HomeAssistantApiService(HomeAssistantApiOptions options)
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(options.Url);
    }

    public void Dispose()
    {
        Dispose(true);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            _httpClient.Dispose();
        }

        _disposed = true;
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsync(true);
    }

    private async ValueTask DisposeAsync(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            if (_httpClient is IAsyncDisposable httpClientAsyncDisposable)
            {
                await httpClientAsyncDisposable.DisposeAsync();
            }
            else
            {
                Dispose(true);
            }
        }

        _disposed = true;
    }

    public async Task UploadFiles(IReadOnlyList<IBrowserFile> files, CancellationToken cancellationToken = default)
    {
        const string route = "/bills";
        var content = ConvertFilesToMultipartDataContent(files, cancellationToken);

        var response = await _httpClient.PostAsync(route, content, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>(cancellationToken);
            throw new ExternalServiceHttpException(problemDetails ?? ExceptionDefaults.GetDefaultProblemDetails);
        }
    }

    private static MultipartFormDataContent ConvertFilesToMultipartDataContent(
        IReadOnlyList<IBrowserFile> files,
        CancellationToken cancellationToken)
    {
        var content = new MultipartFormDataContent();

        foreach (var file in files)
        {
            var streamContent = new StreamContent(file.OpenReadStream(long.MaxValue, cancellationToken));
            streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);

            content.Add(streamContent, FieldFileName, file.Name);
        }

        return content;
    }
}
