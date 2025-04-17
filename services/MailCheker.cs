using System.Net.Mail;
using System.Text.RegularExpressions;


namespace Mail.Checker
{

    public class MailService
    {

        private static readonly string[] MajorEmailDomains = new string[]
        {
        "gmail.com",
        "googlemail.com",
        "outlook.com",
        "hotmail.com",
        "yahoo.com",
        "aol.com",
        "icloud.com",
        "me.com",
        "mac.com",
        "ymail.com",
        "live.com",
        // Aggiungi qui altri domini maggiori che ti interessano
        };


        //verifichiamo la mail ha una formattazione corretta
        public static bool IsCorrectMail(string email)
        {

            try
            {
                var addr = new MailAddress(email);
                if (IsICloudEmail(email) == true)
                {
                    return addr.Address == email;
                }
                return false;
            }
            catch
            {
                Console.WriteLine("❌Errore: L'Email utilizzata non è formattata correttamente");
                return false;
            }
        }

        //VERIFICHIAMO SE UNA MAIL APPARTIENE AD UNO DEI DOMINI DA NOI INTERESSATI
        public static bool IsICloudEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false; // L'input è nullo o vuoto, quindi non è un'email valida
            }

            // Espressione regolare per controllare se il dominio dell'email è @icloud.com, @me.com o @mac.com
            string domainPattern = $"@({string.Join("|", MajorEmailDomains.Select(Regex.Escape))})$";
            if (Regex.IsMatch(email, domainPattern, RegexOptions.IgnoreCase) == true)
            {
                return Regex.IsMatch(email, domainPattern, RegexOptions.IgnoreCase);

            }
            else
            {
                Console.WriteLine("❌Errore: L'email non apartiene ad un dominio corretto!");
                return false;

            }
            // Utilizziamo Regex.IsMatch per verificare se l'email termina con uno dei domini iCloud
        }

    }
}