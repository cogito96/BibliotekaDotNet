using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibiotekaNet.Models
{
    public class KlientEM : Klient
    {
        public KlientEM() : base() { }
        public KlientEM(Klient klient)
        {
            KlientID = klient.KlientID;
            ImieKlienta = klient.ImieKlienta;
            NazwiskoKlienta = klient.NazwiskoKlienta;
            MiastoKlienta = klient.MiastoKlienta;
            UlicaKlienta = klient.UlicaKlienta;
            EmailKlienta = klient.EmailKlienta;
            NumerTelefonuKlienta = klient.NumerTelefonuKlienta;
            LoginKlient = klient.LoginKlient;
            HasloKlienta = klient.HasloKlienta;
            PESEL = klient.PESEL;
            PotwierdzenieRejestracji = klient.PotwierdzenieRejestracji;
            WypożyczeniaKlienta = klient.WypożyczeniaKlienta;
        }
    }
}