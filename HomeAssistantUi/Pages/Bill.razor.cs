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

    private void AddFiles(IReadOnlyList<IBrowserFile> files)
    {
        _files = files;
    }

    private async Task UploadFiles()
    {
        await _homeAssistantApiService.UploadFiles(_files);
    }

    public bool IsLocked => _files.Count >= MaximumFileCount || _files.Count == 0;
}
