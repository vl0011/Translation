using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translation_API.Papago;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Papago papago = new Papago();

            // papago.Translate(Language.en, Language.ko, "Hello, World");
            papago.RegistTranslationEventHandler(Success, Fail);
            while (true)
            {
                string text
                = Console.ReadLine();
                papago.Translate(Language.ko, Language.en, text);
            }

            void Success(object sender, PapagoTranslationEventArgs e)
            {
                Console.WriteLine(e.TranslationText);
            }
            void Fail(object sender, PapagoTranslationEventArgs e)
            {
                Console.WriteLine(e.TranslationText);
            }
        }
    }
}
