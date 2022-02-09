﻿


using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CurrencyExchangeApi.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CurrencyCode
    {
        AED, NIO, NOK, NPR, NZD, OMR, PAB, PEN, PGK, PHP, PKR, PLN, PYG, QAR, RON, RSD, RUB, RWF, NGN, SAR, NAD, MYR, LRD, LSL, LTL, LVL, LYD, MAD, MDL, MGA, MKD, MMK, MNT, MOP, MRO, MUR, MVR, MWK, MXN, MZN, LKR, SBD, SDG, USD, UYU, UZS, VEF, VND, VUV, WST, XAF, XAG, XAU, XCD, XDR, XOF, XPF, YER, ZAR, ZMK, UGX, SCR, UAH, TWD, SEK, SGD, SHP, SLL, SOS, SRD, STD, SVC, SYP, SZL, THB, TJS, TMT, TND, TOP, TRY, TTD, TZS, LBP, LAK, KZT, BTN, BWP, BYN, BYR, BZD, CAD, CDF, CHF, CLF, CLP, CNY, COP, CRC, CUC, CUP, CVE, CZK, BTC, DJF, BSD, BOB, AFN, ALL, AMD, ANG, AOA, ARS, AUD, AWG, AZN, BAM, BBD, BDT, BGN, BHD, BIF, BMD, BND, BRL, DKK, DOP, DZD, IMP, INR, IQD, IRR, ISK, JEP, JMD, JOD, JPY, KES, KGS, KHR, KMF, KPW, KRW, KWD, KYD, ILS, IDR, HUF, HTG, EGP, ERN, ETB, EUR, FJD, FKP, GBP, GEL, ZMW, GGP, GIP, GMD, GNF, GTQ, GYD, HKD, HNL, HRK, GHS, ZWL
    }
}
