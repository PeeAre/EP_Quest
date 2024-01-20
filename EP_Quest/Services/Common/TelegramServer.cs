using Microsoft.AspNetCore.Hosting.Server;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace EP_Quest.Services.Common
{
    public class TelegramSender
    {
        private readonly IConfiguration _configuration;

        public TelegramSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendAsync(string message)
        {
            try
            {
                var section = _configuration.GetSection("TelegramMessaging");
                var chatId = section.GetValue<string>("ChatId");
                var token = section.GetValue<string>("TelegramToken");
                var bot = new TelegramBotClient(token);
                await bot.SendTextMessageAsync(chatId, message, parseMode: ParseMode.Markdown);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}