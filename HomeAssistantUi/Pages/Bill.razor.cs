using HomeAssistantUi.Services;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace HomeAssistantUi.Pages;

public partial class Bill : ComponentBase
{
    private const string AcceptedFileTypes = ".png, .jpg, .jpeg";
    private const int MaximumFileCount = 20;
    private IReadOnlyCollection<IBrowserFile> _files = new List<IBrowserFile>();

    [Inject]
    private IHomeAssistantApiService _homeAssistantApiService { get; set; } = default!;

    private async Task UploadFiles(IReadOnlyList<IBrowserFile> files)
    {
        _files = files;
        // await _homeAssistantApiService.UploadFiles(files);
    }

    private string GetSizeInMB(IBrowserFile file) =>  string.Format("{0:0.00}", file.Size / 1024.0 / 1024.0);
}
