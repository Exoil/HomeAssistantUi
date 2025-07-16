using Microsoft.AspNetCore.Components.Forms;

namespace HomeAssistantUi.Extenstions;

public static class BrowseFileExtension
{
    public static string GetSizeInMb(this IBrowserFile file) => $"{file.Size / 1024.0 / 1024.0:0.00}";
}
