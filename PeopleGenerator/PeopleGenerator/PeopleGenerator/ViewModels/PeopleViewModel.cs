using PeopleGenerator.Services.Peoples;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace PeopleGenerator.ViewModels
{
    /// <summary>
    /// ViewModel to get a current random person.
    /// </summary>
    public class PeopleViewModel : BaseViewModel
    {
        private readonly IPeopleService _peopleService;
        private string _name;
        private string _gender;
        private string _nationality;
        private string _pathToPhoto;
        private UriImageSource _sourceForImage;
        private ImageSource _sourcePhoto;

        public PeopleViewModel()
        {
            _peopleService = new PeopleService();
            this.ChoosePersonCommand = new Command(FindPerson);

            _sourceForImage = new UriImageSource();

            _pathToPhoto = "https://randomuser.me/api/portraits/women/19.jpg";
            _sourceForImage.Uri = new Uri(_pathToPhoto);
            SourcePhoto = _sourceForImage;
        }

        /// <summary>
        /// Gets or sets the person name.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the person gender.
        /// </summary>
        public string Gender
        {
            get { return _gender; }
            set
            {
                if (_gender != value)
                {
                    _gender = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the person nationality.
        /// </summary>
        public string Nationality
        {
            get { return _nationality; }
            set
            {
                if (_nationality != value)
                {
                    _nationality = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the path to person photo.
        /// </summary>
        public ImageSource SourcePhoto
        {
            get { return _sourcePhoto; }
            set
            {
                if (_sourcePhoto != value)
                {
                    _sourcePhoto = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Raised when person schould be chosen.
        /// </summary>
        public ICommand ChoosePersonCommand { get; }

        private async void FindPerson()
        {
            var peopleResult = await _peopleService.GetPersonAsync();

            var randomGenerator = new Random();
            var resultNumber = randomGenerator.Next(0, peopleResult.results.Count - 1);

            var currentPersonData = peopleResult.results[resultNumber].user;

            Name = $"{currentPersonData.name.first} {currentPersonData.name.last}";
            Gender = currentPersonData.gender;
            Nationality = peopleResult.nationality;

            _pathToPhoto = currentPersonData.picture.large;
            _sourceForImage.Uri = new Uri(_pathToPhoto);
            SourcePhoto = _sourceForImage;
        }
    }
}
