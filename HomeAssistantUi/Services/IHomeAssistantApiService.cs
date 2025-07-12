using Microsoft.AspNetCore.Components.Forms;

namespace HomeAssistantUi.Services;

public interface IHomeAssistantApiService
{
    Task UploadFiles(IReadOnlyList<IBrowserFile> file, CancellationToken cancellationToken = default);
}
