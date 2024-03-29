using System.Collections.Generic;
using System.Reflection;

namespace Nasfaq.JSON
{
    public static class Coins
    {
        static Coins()
        {
            List<string> allCoins = new List<string>();
            foreach(FieldInfo field in typeof(Coins).GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                string name = (string)field.GetValue(null);    
                if(name != Blank)
                {
                    allCoins.Add(name);
                }
            }
            CoinsList = allCoins;
        }

        public static readonly IReadOnlyList<string> CoinsList;
        public static readonly string Blank = "blank";

        public static readonly string Hololive = "hololive";

        public static readonly string Sora = "sora";
        public static readonly string Roboco = "roboco";
        public static readonly string Miko = "miko";
        public static readonly string Suisei = "suisei";
        public static readonly string Azki = "azki";

        public static readonly string Mel = "mel";
        public static readonly string Fubuki = "fubuki";
        public static readonly string Matsuri = "matsuri";
        public static readonly string Aki = "aki";
        public static readonly string Haato = "haato";
        
        public static readonly string Aqua = "aqua";
        public static readonly string Shion = "shion";
        public static readonly string Ayame = "ayame";
        public static readonly string Choco = "choco";
        public static readonly string Subaru = "subaru";

        public static readonly string Mio = "mio";
        public static readonly string Okayu = "okayu";
        public static readonly string Korone = "korone";

        public static readonly string Pekora = "pekora";
        public static readonly string Rushia = "rushia";
        public static readonly string Flare = "flare";
        public static readonly string Noel = "noel";
        public static readonly string Marine = "marine";

        public static readonly string Kanata = "kanata";
        public static readonly string Coco = "coco";
        public static readonly string Watame = "watame";
        public static readonly string Towa = "towa";
        public static readonly string Luna = "himemoriluna";

        public static readonly string Lamy = "lamy";
        public static readonly string Nene = "nene";
        public static readonly string Botan = "botan";
        public static readonly string Polka = "polka";

        public static readonly string Laplus = "laplus";
        public static readonly string Lui = "lui";
        public static readonly string Koyori = "koyori";
        public static readonly string Chloe = "chloe";
        public static readonly string Iroha = "iroha";

        public static readonly string Mori = "calliope";
        public static readonly string Kiara = "kiara";
        public static readonly string Ina = "inanis";
        public static readonly string Gura = "gura";
        public static readonly string Amelia = "amelia";

        public static readonly string IRyS = "irys";

        public static readonly string Sana = "sana";
        public static readonly string Fauna = "fauna";
        public static readonly string Kronii = "kronii";
        public static readonly string Mumei = "mumei";
        public static readonly string Baelz = "baelz";

        public static readonly string Risu = "risu";
        public static readonly string Moona = "moona";
        public static readonly string Iofi = "iofi";

        public static readonly string Ollie = "ollie";
        public static readonly string Anya = "melfissa";
        public static readonly string Reine = "reine";

        public static readonly string Ui = "ui";
        public static readonly string Nana = "nana";
        public static readonly string Pochi = "pochimaru";
        public static readonly string Ayamy = "ayamy";
        public static readonly string Nabi = "nabi";
        public static readonly string Nachoneko = "nachoneko";

        public static readonly string Zeta = "zeta";
        public static readonly string Kovalskia = "kovalskia";
        public static readonly string Kanaeru = "kanaeru";

        public static readonly string Miyabi = "miyabi";
        public static readonly string Izuru = "izuru";
        public static readonly string Arurandeisu = "aruran";
        public static readonly string Rikka = "rikka";

        public static readonly string Leda = "leda";
        public static readonly string Temma = "temma";
        public static readonly string Roberu = "roberu";

        public static readonly string Shien = "shien";
        public static readonly string Oga = "oga";

        public static readonly string Fuma = "fuma";
        public static readonly string Uyu = "uyu";
        public static readonly string Gamma = "gamma";
        public static readonly string Rio = "rio";

        public static readonly string Altare = "altare";
        public static readonly string Dezmond = "dezmond";
        public static readonly string Syrios = "syrios";
        public static readonly string Vesper = "vesper";

        public static readonly string Civia = "civia";
    }
}