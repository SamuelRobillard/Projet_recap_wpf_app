using Examen2.Pratique.Data;
using Examen2.Pratique.ViewModel;
using IdeaManager.Core.Entities;
using IdeaManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IdeaManager.UI.Views
{
    /// <summary>
    /// Logique d'interaction pour IdeaListView.xaml
    /// </summary>
    public partial class IdeaListView : Page

    {
        private LivresViewModel _viewModel;
        ObservableCollection<Idea> ideas = IdeaFormViewModel.ideas;


        public IdeaListView()
        {
            InitializeComponent();

            _viewModel = new LivresViewModel(new LivreDataProvider());
            Console.WriteLine(ideas);


            List<Idea> e = new List<Idea>();
            
            
            DataContext = ideas;
           
        }

        public async void OnLoaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();

        }

        private void OnBackClick(object sender, RoutedEventArgs e)
        {
            if (NavigationService?.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }

    }
}
