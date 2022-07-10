using System;
using Microsoft.Toolkit.Uwp.Notifications;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var controller = new WhaleAlertsLibrary.Controllers.WhaleTransactionController();
            var transactions = controller.GetWhaleTransactions();

            /*
            new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .AddArgument("conversationId", 9813)
                .AddText("Adam sent you a message")
                .AddText("Check this out, The Enchantments in Washington!")
                .Show();
            */

            var test = new WhaleAlertsLibrary.Controllers.CryptoCompareApiController();
            var symbol_url = test.GetSymbolLogo("BTC");

            Console.WriteLine("Hello World!");
        }
    }
}
