namespace KovserHediyyeler.Infrastructure.Operations
{
    public class NameOperation
    {
        public static string CharacterRegularity(string name)
       =>
       (name.Replace("/", "")
        .Replace("!", "")
        .Replace("@", "")
        .Replace("#", "")
        .Replace("$", "")
        .Replace("%", "")
        .Replace("^", "")
        .Replace("&", "")
        .Replace("*", "")
        .Replace("|", "")
        .Replace("<", "")
        .Replace(">", "")
        .Replace("?", "")
        .Replace("/", "")
        .Replace(".", "")
        .Replace(",", "")
        .Replace("'", "")
        .Replace("\"", "")
        .Replace(";", "")
        .Replace(":", "")
        .Replace("(", "")
        .Replace(")", "")
        .Replace("[", "")
        .Replace("]", "")
        .Replace("{", "")
        .Replace("}", "")
        .Replace("+", "")
        .Replace("=", "")
        .Replace("~", "")
        .Replace("`", "")
        .Replace(" ", "-")
        .Replace("ı", "i")    // Türk dilindəki "ı" hərfi
        .Replace("İ", "I")    // Türk dilindəki "İ" hərfi
        .Replace("ç", "c")    // Türk dilindəki "ç" hərfi
        .Replace("Ç", "C")    // Türk dilindəki "Ç" hərfi
        .Replace("ö", "o")    // Türk dilindəki "ö" hərfi
        .Replace("Ö", "O")    // Türk dilindəki "Ö" hərfi
        .Replace("ü", "u")    // Türk dilindəki "ü" hərfi
        .Replace("Ü", "U")    // Türk dilindəki "Ü" hərfi
        .Replace("ğ", "g")    // Türk dilindəki "ğ" hərfi
        .Replace("Ğ", "G")    // Türk dilindəki "Ğ" hərfi
        .Replace("ş", "s")    // Türk dilindəki "ş" hərfi
        .Replace("Ş", "S")    // Türk dilindəki "Ş" hərfi
        .Replace("á", "a")    // Diakritik işarəli "á"
        .Replace("é", "e")    // Diakritik işarəli "é"
        .Replace("ñ", "n")    // İspan dilindəki "ñ"
        .Replace("ý", "y")    // Diakritik işarəli "ý"
        .Replace("ß", "ss")   // Alman dilindəki "ß")
        .Replace("ä", "a")    // Alman dilindəki "ä"
        .Replace("Ä", "A")
        .Replace("ø", "o")    // Skandinav hərfi
        .Replace("Ø", "O")
        .Replace("å", "a")    // Skandinav hərfi
        .Replace("Å", "A")
        // Rus hərflərinin Azərbaycan qarşılıqları
        .Replace("А", "A")
        .Replace("а", "a")
        .Replace("Б", "B")
        .Replace("б", "b")
        .Replace("В", "V")
        .Replace("в", "v")
        .Replace("Г", "G")
        .Replace("г", "g")
        .Replace("Д", "D")
        .Replace("д", "d")
        .Replace("Е", "E")
        .Replace("е", "e")
        .Replace("Ё", "E")
        .Replace("ё", "e")
        .Replace("Ж", "J")
        .Replace("ж", "j")
        .Replace("З", "Z")
        .Replace("з", "z")
        .Replace("И", "I")
        .Replace("и", "i")
        .Replace("Й", "Y")
        .Replace("й", "y")
        .Replace("К", "K")
        .Replace("к", "k")
        .Replace("Л", "L")
        .Replace("л", "l")
        .Replace("М", "M")
        .Replace("м", "m")
        .Replace("Н", "N")
        .Replace("н", "n")
        .Replace("О", "O")
        .Replace("о", "o")
        .Replace("П", "P")
        .Replace("п", "p")
        .Replace("Р", "R")
        .Replace("р", "r")
        .Replace("С", "S")
        .Replace("с", "s")
        .Replace("Т", "T")
        .Replace("т", "t")
        .Replace("У", "U")
        .Replace("у", "u")
        .Replace("Ф", "F")
        .Replace("ф", "f")
        .Replace("Х", "X")
        .Replace("х", "x")
        .Replace("Ц", "Ts")
        .Replace("ц", "ts")
        .Replace("Ч", "Ch")
        .Replace("ч", "ch")
        .Replace("Ш", "Sh")
        .Replace("ш", "sh")
        .Replace("Щ", "Sch")
        .Replace("щ", "sch")
        .Replace("Ъ", "")
        .Replace("ъ", "")
        .Replace("Ы", "I")
        .Replace("ы", "i")
        .Replace("Ь", "")
        .Replace("ь", "")
        .Replace("Э", "E")
        .Replace("э", "e")
        .Replace("Ю", "Yu")
        .Replace("ю", "yu")
        .Replace("Я", "Ya")
        .Replace("я", "ya"));

    }
}
