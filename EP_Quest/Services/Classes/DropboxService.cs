using Dropbox.Api;
using static Dropbox.Api.Files.PathOrLink;

namespace EP_Quest.Services.Classes
{
    public class DropboxService
    {
        private readonly string _refreshToken;
        private readonly string _appKey;
        private readonly string _appSecret;
        public readonly string ScenesLocalDirectory = "./models";
        public readonly string ScenesRemoteDirectory = "/Quest/Scenes";

        public DropboxService(string refreshToken, string appKey, string appSecret)
        {
            _refreshToken = refreshToken;
            _appKey = appKey;
            _appSecret = appSecret;
        }
        public async Task DownloadFileAsync(string remotePath, string localPath)
        {
            using (var dbx = new DropboxClient(_refreshToken, _appKey, _appSecret))
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
