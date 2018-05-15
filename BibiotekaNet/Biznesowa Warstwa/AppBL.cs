using BibiotekaNet.Models;
using BibiotekaNet.ViewModel.Autoryzacja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace BibiotekaNet.Biznesowa_Warstwa
{
    public class AppBL
    {
        DBKontekst db = new DBKontekst();
        public bool isValidAutoryzacja(string login, string haslo, TypUzytkownikaEnum typUzytkownika)
        {
            if(typUzytkownika == TypUzytkownikaEnum.KLIENT)
            {
                Klient klient = db.Klienci.Where(model => model.LoginKlient == login && model.HasloKlienta == haslo).FirstOrDefault();
                if (klient != null)
                {
                    return true;
                }
            }
            else
            {
                Pracownik pracownik = db.Pracownicy.Where(model => model.LoginPracownika == login && model.HasloPracownika == haslo).FirstOrDefault();
                if (pracownik != null)
                {
                    return true;
                }
            }
            return false;
        }

        public void Zaloguj(LogowanieVM vm)
        {
            var session = HttpContext.Current.Session;
            session["TypUzytkownika"] = vm.typUzytkownika;
            FormsAuthentication.SetAuthCookie(vm.login, false);
        }

    }
}