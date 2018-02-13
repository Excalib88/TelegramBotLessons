using System;
using Telegram.Bot;
using System.Threading.Tasks;

namespace MyFirstBotForLesson
{
    class Program
    {
        const string TOKEN = "484848836:AAGg2EXlGFJTVZC5BZPRJfdMnyGiK17ETrc";

        static void Main(string[] args)
        {
            while(true)
            {
                try
                {
                    GetMessages().Wait();
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                }
            }
        }

        static async Task GetMessages()
        {
            TelegramBotClient bot = new TelegramBotClient(TOKEN);
            int offset = 0;
            int timeout = 0;
            try
            {
                await bot.SetWebhookAsync("");
                while(true)
                {
                    var updates = await bot.GetUpdatesAsync(offset, timeout);

                    foreach(var update in updates)
                    {
                        var message = update.Message;

                        if(message.Text == "MyFirstBot")
                        {
                            Console.WriteLine("Получено сообщение:" + message.Text);
                            await bot.SendTextMessageAsync(message.Chat.Id, "Привет создатель, я твой бот! " + message.Chat.Username);
                        }
                        offset = update.Id + 1;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }
    }
}
