﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace EinsModel
{
    public class Spieler:INotifyPropertyChanged
    {
        private int id;
        private String spielername;
        private int gesamtpunkte;
        public int Id { get => id; set => id = value; }
        public string Spielername { get => spielername; set => spielername = value; }
        public int Gesamtpunkte { get => gesamtpunkte;
            set  { 
                 gesamtpunkte = value;
                 OnPorpertyChanged(new PropertyChangedEventArgs("Gesamtpunkte"));
            }
        }
        public override string ToString()
        {
            return String.Format("{0}: {1}",this.Id.ToString(),this.Spielername);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPorpertyChanged(PropertyChangedEventArgs e)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    }
}
