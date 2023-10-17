using Microsoft.Identity.Client;

namespace WebApplication1.Helpers
{
    public class Helper : IHelper
    {
        public string Upper(string text)
        {
            return text.ToUpper();
        }
    }
}
