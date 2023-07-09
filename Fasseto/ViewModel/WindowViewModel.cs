using System.Windows;
using System.Windows.Input;
using Fasetto;

namespace Fasseto
{
    public class WindowViewModel : BaseViewModel
    {

        private Window mWindow;
        public WindowViewModel(Window window)
        {
            mWindow = window;

            mWindow.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarzinSize));
                OnPropertyChanged(nameof(OuterMarzinSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowConerRadius));

            };

            //Create command
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));

            //Fix window resizer issue
            var resizer = new WindowResizer(mWindow);
        }

        private Point GetMousePosition()
        {
            // Position of the mouse relative to the window
            var position = Mouse.GetPosition(mWindow);

            // Add the window position so its a "ToScreen"
            return new Point(position.X + (mWindow.WindowState == WindowState.Maximized ? 0.0 : mWindow.Left), position.Y + (mWindow.WindowState == WindowState.Maximized ? 0.0 : mWindow.Top));
        }

        private int mOutermarginSize = 10;

        private int mWindownRadius = 10;

        public string Test { get; set; }

        public int ResizeBorder { get; set; } = 6;

        public double WindowMinimumWidth { get; set; } = 400;
        public double WindowMinimumHeight { get; set; } = 400;
        public Thickness InnerContentPadding { get { return new Thickness(ResizeBorder); } }
        public Thickness ResizeBorderThickness
        {
            get { return new Thickness(ResizeBorder + OuterMarzinSize); }
        }

        public int OuterMarzinSize
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mOutermarginSize;

            }
            set
            {
                mOutermarginSize = value;
            }
        }

        public Thickness OuterMarzinSizeThickness
        {
            get
            {
                return new Thickness(OuterMarzinSize);
            }
        }

        public int WindowRadius
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mWindownRadius;

            }
            set
            {
                mWindownRadius = value;
            }
        }

        public Thickness WindowConerRadius
        {
            get
            {
                return new Thickness(WindowRadius);
            }
        }

        public int TitleHeight { get; set; } = 42;

        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }

        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand MenuCommand { get; set; }


    }
}
