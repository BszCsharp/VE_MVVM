using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EinsModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;

namespace EinsViewModel
{
    public class MainViewModel:INotifyPropertyChanged
    {
        Spiel wuerfelspiel;
        Spieler vmspieler;
        ICommand btnWuerfeln;
        ICommand btnEnd;
        ICommand btnRegistrieren;
        int wuerfelzahl;
        
        public MainViewModel()
        {
            
                Wuerfelspiel =   new Spiel();
                Wuerfelspiel.LoadSpieler();
                BtnWuerfeln = new UserCommand(Wuerfeln);
                BtnEnd = new UserCommand(SpielEnde);
                BtnRegistrieren = new UserCommand(Registrieren);
        }

        private void Registrieren(object obj)
        {
            String name = (String)obj;
            Wuerfelspiel.Registrieren(name);

        }

        private void SpielEnde(object obj)
        {
            Wuerfelspiel.SaveAlleSpieler();
            Window w = (Window)obj;
            w.Close();
        }

        private void Wuerfeln(object obj)
        {
            this.Wuerfelzahl = wuerfelspiel.Wuerfeln((Spieler)obj);
        }

        private Spiel Wuerfelspiel { get => wuerfelspiel; set => wuerfelspiel = value; }
        public ObservableCollection<Spieler> LstSpieler
        {
            get { return Wuerfelspiel.LstSpieler; }
        }
        public Spieler Vmspieler { get => vmspieler; set => vmspieler = value; }
        public int Wuerfelzahl { get => wuerfelzahl;
            set
            {
                wuerfelzahl = value;
                OnPorpertyChanged(new PropertyChangedEventArgs("Wuerfelzahl"));
            }
         }

        public ICommand BtnWuerfeln { get => btnWuerfeln; set => btnWuerfeln = value; }
        public ICommand BtnEnd { get => btnEnd; set => btnEnd = value; }
        public ICommand BtnRegistrieren { get => btnRegistrieren; set => btnRegistrieren = value; }

        private void OnPorpertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
