using System.Collections.Generic;

namespace Data
{
    internal static class RomajiConverter
    {
        public static readonly Dictionary<string, List<string>> HiraganaToRomajiMap = new()
        {
            // あ行
            { "あ", new List<string> { "a" } },
            { "い", new List<string> { "i" } },
            { "う", new List<string> { "u" } },
            { "え", new List<string> { "e" } },
            { "お", new List<string> { "o" } },

            // か行
            { "か", new List<string> { "ka" } },
            { "き", new List<string> { "ki" } },
            { "く", new List<string> { "ku" } },
            { "け", new List<string> { "ke" } },
            { "こ", new List<string> { "ko" } },

            // さ行
            { "さ", new List<string> { "sa" } },
            { "し", new List<string> { "shi", "si" } },
            { "す", new List<string> { "su" } },
            { "せ", new List<string> { "se" } },
            { "そ", new List<string> { "so" } },

            // た行
            { "た", new List<string> { "ta" } },
            { "ち", new List<string> { "chi", "ti" } },
            { "つ", new List<string> { "tsu", "tu" } },
            { "て", new List<string> { "te" } },
            { "と", new List<string> { "to" } },

            // な行
            { "な", new List<string> { "na" } },
            { "に", new List<string> { "ni" } },
            { "ぬ", new List<string> { "nu" } },
            { "ね", new List<string> { "ne" } },
            { "の", new List<string> { "no" } },

            // は行
            { "は", new List<string> { "ha" } },
            { "ひ", new List<string> { "hi" } },
            { "ふ", new List<string> { "fu", "hu" } },
            { "へ", new List<string> { "he" } },
            { "ほ", new List<string> { "ho" } },

            // ま行
            { "ま", new List<string> { "ma" } },
            { "み", new List<string> { "mi" } },
            { "む", new List<string> { "mu" } },
            { "め", new List<string> { "me" } },
            { "も", new List<string> { "mo" } },

            // や行
            { "や", new List<string> { "ya" } },
            { "ゆ", new List<string> { "yu" } },
            { "よ", new List<string> { "yo" } },

            // ら行
            { "ら", new List<string> { "ra" } },
            { "り", new List<string> { "ri" } },
            { "る", new List<string> { "ru" } },
            { "れ", new List<string> { "re" } },
            { "ろ", new List<string> { "ro" } },

            // わ行
            { "わ", new List<string> { "wa" } },
            { "を", new List<string> { "wo" } },

            // ん
            { "ん", new List<string> { "n", "nn", "n'" } },

            // 濁音
            { "が", new List<string> { "ga" } },
            { "ぎ", new List<string> { "gi" } },
            { "ぐ", new List<string> { "gu" } },
            { "げ", new List<string> { "ge" } },
            { "ご", new List<string> { "go" } },

            { "ざ", new List<string> { "za" } },
            { "じ", new List<string> { "ji", "zi" } },
            { "ず", new List<string> { "zu" } },
            { "ぜ", new List<string> { "ze" } },
            { "ぞ", new List<string> { "zo" } },

            { "だ", new List<string> { "da" } },
            { "ぢ", new List<string> { "ji", "di" } },
            { "づ", new List<string> { "zu", "du" } },
            { "で", new List<string> { "de" } },
            { "ど", new List<string> { "do" } },

            { "ば", new List<string> { "ba" } },
            { "び", new List<string> { "bi" } },
            { "ぶ", new List<string> { "bu" } },
            { "べ", new List<string> { "be" } },
            { "ぼ", new List<string> { "bo" } },

            // 半濁音
            { "ぱ", new List<string> { "pa" } },
            { "ぴ", new List<string> { "pi" } },
            { "ぷ", new List<string> { "pu" } },
            { "ぺ", new List<string> { "pe" } },
            { "ぽ", new List<string> { "po" } },

            // 拗音（きゃ、しゃなど）
            { "きゃ", new List<string> { "kya", "kilya", "kixya" } },
            { "きゅ", new List<string> { "kyu", "kilyu", "kixyu" } },
            { "きょ", new List<string> { "kyo", "kilyo", "kixyo" } },

            { "しゃ", new List<string> { "sha", "sya", "shixya", "sixya" } },
            { "しゅ", new List<string> { "shu", "syu", "shixyu", "sixyu" } },
            { "しょ", new List<string> { "sho", "syo", "shixyo", "sixyo" } },

            { "ちゃ", new List<string> { "cha", "cya", "chixya", "tixya" } },
            { "ちゅ", new List<string> { "chu", "cyu", "chixyu", "tixyu" } },
            { "ちょ", new List<string> { "cho", "cyo", "chixyo", "tixyo" } },

            { "にゃ", new List<string> { "nya", "niya", "nixya" } },
            { "にゅ", new List<string> { "nyu", "niyu", "nixyu" } },
            { "にょ", new List<string> { "nyo", "niyo", "nixyo" } },

            { "ひゃ", new List<string> { "hya", "hiya", "hixya" } },
            { "ひゅ", new List<string> { "hyu", "hiyu", "hixyu" } },
            { "ひょ", new List<string> { "hyo", "hiyo", "hixyo" } },

            { "みゃ", new List<string> { "mya", "miya", "mixya" } },
            { "みゅ", new List<string> { "myu", "miyu", "mixyu" } },
            { "みょ", new List<string> { "myo", "miyo", "mixyo" } },

            { "りゃ", new List<string> { "rya", "riya", "rixya" } },
            { "りゅ", new List<string> { "ryu", "riyu", "rixyu" } },
            { "りょ", new List<string> { "ryo", "riyo", "rixyo" } },

            // 小文字（あくまで単体入力用として）
            { "ぁ", new List<string> { "la", "xa" } },
            { "ぃ", new List<string> { "li", "xi" } },
            { "ぅ", new List<string> { "lu", "xu" } },
            { "ぇ", new List<string> { "le", "xe" } },
            { "ぉ", new List<string> { "lo", "xo" } },
            { "ゃ", new List<string> { "lya", "xya" } },
            { "ゅ", new List<string> { "lyu", "xyu" } },
            { "ょ", new List<string> { "lyo", "xyo" } },
            { "っ", new List<string> { "ltu", "xtu", "ltsu", "xtsu" } },

            // ぎゃ行
            { "ぎゃ", new List<string> { "gya", "giya", "gixya" } },
            { "ぎゅ", new List<string> { "gyu", "giyu", "gixyu" } },
            { "ぎょ", new List<string> { "gyo", "giyo", "gixyo" } },

            // じゃ行（じ＋拗音）
            { "じゃ", new List<string> { "ja", "jya", "jiya", "zya", "ziya", "jixya", "zixya" } },
            { "じゅ", new List<string> { "ju", "jyu", "jiyu", "zyu", "ziyu", "jixyu", "zixyu" } },
            { "じょ", new List<string> { "jo", "jyo", "jiyo", "zyo", "ziyo", "jixyo", "zixyo" } },

            // びゃ行
            { "びゃ", new List<string> { "bya", "biya", "bixya" } },
            { "びゅ", new List<string> { "byu", "biyu", "bixyu" } },
            { "びょ", new List<string> { "byo", "biyo", "bixyo" } },

            // ぴゃ行（半濁音＋拗音）
            { "ぴゃ", new List<string> { "pya", "piya", "pixya" } },
            { "ぴゅ", new List<string> { "pyu", "piyu", "pixyu" } },
            { "ぴょ", new List<string> { "pyo", "piyo", "pixyo" } },

            // ぢゃ行（ちの濁音＋拗音）
            { "ぢゃ", new List<string> { "ja", "dya", "diya", "jya", "jixya", "dixya" } },
            { "ぢゅ", new List<string> { "ju", "dyu", "diyu", "jyu", "jixyu", "dixyu" } },
            { "ぢょ", new List<string> { "jo", "dyo", "diyo", "jyo", "jixyo", "dixyo" } },

            // ヴァ行（ヴ＋拗音も含む）
            { "ゔ", new List<string> { "vu" } }, // 一般的に "vu" で表現（環境によって "bu" を使うケースもあるが非推奨）

            { "ゔぁ", new List<string> { "va", "vua", "vuxa" } },
            { "ゔぃ", new List<string> { "vi", "vui", "vuxi" } },
            { "ゔぇ", new List<string> { "ve", "vue", "vuxe" } },
            { "ゔぉ", new List<string> { "vo", "vuo", "vuxo" } },

            // 拗音風（非標準だが稀に使用）
            { "ゔゃ", new List<string> { "vya", "vuya", "vuxya" } },
            { "ゔゅ", new List<string> { "vyu", "vuyu", "vuxyu" } },
            { "ゔょ", new List<string> { "vyo", "vuyo", "vuxyo" } }
        };
    }
}