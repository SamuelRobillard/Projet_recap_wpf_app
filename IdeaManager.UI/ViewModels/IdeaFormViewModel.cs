using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using System.Collections.ObjectModel;
using IdeaManager.Data.Db;

namespace IdeaManager.UI.ViewModels
{


    public class StringToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => string.IsNullOrWhiteSpace(value as string) ? Visibility.Collapsed : Visibility.Visible;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }
    public partial class IdeaFormViewModel : ObservableObject
    {
        public static ObservableCollection<Idea> ideas = new ObservableCollection<Idea>();
        private readonly IIdeaService _ideaService;

        public IdeaFormViewModel(IIdeaService ideaService)
        {
            _ideaService = ideaService;
        }

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private string errorMessage;

        [RelayCommand]
        private async Task SubmitAsync()
        {
            try
            {
                var idea = new Idea
                {
                    Id = ideas.Count + 1,
                    Title = Title,
                    Description = Description
                    

                };
                
                
                Console.WriteLine(idea.Title);
                ideas.Add(idea);
                Console.WriteLine(ideas.Count);
                await _ideaService.SubmitIdeaAsync(idea);
                ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}