using LAB9_FOST.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LAB9_FOST.ViewModel
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        #region Основная модель

        public MathObjectModel Model { get; set; } = new MathObjectModel();

        #endregion

        #region Команды

        private ObjectsCommand displayCommand;
        public ObjectsCommand DisplayCommand
        {
            get
            {
                return displayCommand ??
                (displayCommand = new ObjectsCommand(obj =>
                {
                    Model.ObjectParameters.Angle = decimal.Parse(Angle);
                    Model.ObjectParameters.Mass = decimal.Parse(Mass);
                    Model.ObjectParameters.Speed = decimal.Parse(Speed);
                    Model.ObjectParameters.Resistance = decimal.Parse(Resistance);
                    Model.FindPoints(IsFirstFormula);
                }));
            }
        }

        #endregion

        #region Входные параметры

        private string speed;
        private string angle;
        private string mass;
        private string resistance;
        public string Speed
        {
            get => speed;
            set
            {
                speed = setString(value);
                checkStartButton();
            }
        }
        public string Angle
        {
            get => angle;
            set
            {
                angle = setString(value);
                checkStartButton();
            }
        }
        public string Mass
        {
            get => mass;
            set
            {
                mass = setString(value);
                checkStartButton();
            }
        }
        public string Resistance
        {
            get => resistance;
            set
            {
                resistance = setString(value);
                checkStartButton();
            }
        }
        public bool IsFirstFormula { get; set; }

        #endregion

        // Настройки кнопок

        private bool isStartButtonEnabled = false;
        public bool IsStartButtonEnabled
        {
            get => isStartButtonEnabled;
            set
            {
                isStartButtonEnabled = value;
                OnPropertyChanged("IsStartButtonEnabled");
            }
        }
        // Прочее

        private void checkStartButton()
        {
            IsStartButtonEnabled = float.TryParse(speed, out _) && float.TryParse(angle, out _) && float.TryParse(mass, out _) && float.TryParse(resistance, out _);
        }
        private string setString(string value)
        {
            return value.Replace(".", ",").Replace(" ", "");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
