namespace KovserHediyyeler.Domain.Enums
{
    public enum PaymentMethod
    {
        Cash,              // Nağd ödəniş
        CreditCard,        // Kredit kartı ilə ödəniş (Visa, MasterCard, AMEX)
        DebitCard,         // Debet kartı ilə ödəniş
        BankTransfer,      // Bank köçürməsi (Elektron köçürmələr, Swift)
        EManat,            // E-manat ödəmə terminalı
        MilliOn,           // MilliÖn ödəmə terminalı
        PayPal,            // PayPal ilə ödəniş (Azərbaycanda məhdud istifadə olunsa da, bəzi hallarda mümkündür)
        ApplePay,          // Apple Pay
        GooglePay,         // Google Pay
        MobilePayment,     // Mobil operator vasitəsilə ödəniş (Bakcell, Azercell, Nar)
        GiftCard,          // Hədiyyə kartı ilə ödəniş
        QRPayment,         // QR kod ilə ödəniş (bank tətbiqləri ilə)
        Cryptocurrencies,  // Kriptovalyutalar (Bitcoin, Ethereum və s.)
        Wallet,            // Elektron pulqabı (Portmanat, Umico və s.)
        Installment        // Hissə-hissə ödəniş (BirKart, TamKart, BolKart)
    }
}
