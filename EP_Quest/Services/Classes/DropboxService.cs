using Dropbox.Api;
using static Dropbox.Api.Files.PathOrLink;

namespace EP_Quest.Services.Classes
{
    public class DropboxService
    {
        private readonly string _accessToken;
        public readonly string ScenesLocalDirectory = "./models";
        public readonly string ScenesRemoteDirectory = "/Quest/Scenes";

        public DropboxService(string accessToken)
        {
            _accessToken = accessToken;
        }

        public async Task DownloadFileAsync(string remotePath, string localPath)
        {
            using (var dbx = new DropboxClient(_accessToken))
            {
                using (var response = await dbx.Files.DownloadAsync(remotePath))
                {
                    using (var fileStream = File.Create(localPath))
                    {
                        await (await response.GetContentAsStreamAsync()).CopyToAsync(fileStream);
                        fileStream.Close();
                    }
                }
            }
        }
    }
}
