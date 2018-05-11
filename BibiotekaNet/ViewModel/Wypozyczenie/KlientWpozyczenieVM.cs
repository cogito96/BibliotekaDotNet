﻿using BibiotekaNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibiotekaNet.ViewModel.Wypozyczenie
{
    public class KlientWpozyczenieVM
    {
        public WypozyczenieEM wypozyczenie { get; set; }
        public string kolorStatusWypozyczenia
        {
            get
            {
                if (this.wypozyczenie.StatusWypozyczenia == WypozyczenieStatusWypozyczeniaEnum.W_TRAKCIE.ToString())
                {
                    return kolorStatusWypozyczenia = "yellow";
                }
                //  else if (this.wypozyczenie.StatusWypozyczenia == WypozyczenieStatusWypozyczeniaEnum.ZREALIZOWANO.ToString())
                else
                { 
                    return kolorStatusWypozyczenia = "green";
                }
            }
            set { }
        }
        public KlientWpozyczenieVM(WypozyczenieEM wypozyczenieEM)
        {
            this.wypozyczenie = wypozyczenieEM;
        }
    }

}