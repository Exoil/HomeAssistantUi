using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace HomeAssistantUi.Pages;

public partial class Bill : ComponentBase
{
    private readonly IList<IBrowserFile> _files = new List<IBrowserFile>();

    private void UploadFiles(IBrowserFile file)
    {
        _files.Add(file);
        //TODO upload the files to the server
    }
}
