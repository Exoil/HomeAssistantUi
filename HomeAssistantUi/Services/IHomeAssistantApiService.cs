using Microsoft.AspNetCore.Components.Forms;

namespace HomeAssistantUi.Services;

public interface IHomeAssistantApiService
{
    Task UploadFiles(IReadOnlyCollection<IBrowserFile> file, CancellationToken cancellationToken = default);
}
