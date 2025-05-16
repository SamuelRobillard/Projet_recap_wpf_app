using Examen2.Pratique.Data;
using Examen2.Pratique.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace Examen2.Pratique.ViewModel
{
    // Ajoutez et complétez le code manquant pour implémenter le modèle MVVM
    public class LivresViewModel : INotifyPropertyChanged
    {
        private readonly ILivreDataProvider _livreDataProvider;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Livre> Livres { get; } = new ObservableCollection<Livre>();
        public ObservableCollection<Livre> LivresRecherches { get; } = new ObservableCollection<Livre>();
        private Livre _selectedLivre;
        
        public Livre SelectedLivre {  get { return _selectedLivre; }
            set {
                if (_selectedLivre != value)
                {
                    _selectedLivre = value;
                    RaisePropertyChanged(nameof(_selectedLivre));
                }
            
            } }
        

        // Ajoutez les champs et propriétés manquants

        public ICommand RechercherTrierLivreCommand { get; set; }
        
        public LivresViewModel(ILivreDataProvider livreDataProvider)
        {
            _livreDataProvider = livreDataProvider;
            //RechercherTrierLivreCommand = new RelayCommand(RechercherTrierLivre);
            
        }

        public async Task LoadAsync() 
        {
            var livres = await _livreDataProvider.GetAllAsync();
            if(livres != null)
            {
                foreach(var livre in livres)
                {
                    Livres.Add(livre);
                    
                }
            }
        }

       
        private void RaisePropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); 
        }

    }

}
