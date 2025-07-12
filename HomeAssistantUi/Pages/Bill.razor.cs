using HomeAssistantUi.Services;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace HomeAssistantUi.Pages;

public partial class Bill : ComponentBase
{
    private const string AcceptedFileTypes = ".png, .jpg, .jpeg";
    private const int MaximumFileCount = 20;
    private IReadOnlyCollection<IBrowserFile> _files = new List<IBrowserFile>();
    private IHomeAssistantApiService _homeAssistantApiService;

    public Bill(IHomeAssistantApiService homeAssistantApiService)
    {
        _homeAssistantApiService = homeAssistantApiService;
    }

    private async Task UploadFiles(IReadOnlyList<IBrowserFile> files)
    {
        _files = files;
        //TODO upload the files to the server
        await _homeAssistantApiService.UploadFiles(files);
    }
}
