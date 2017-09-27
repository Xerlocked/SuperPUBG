using System.Diagnostics;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Navigation;

namespace SuperPUBG.User
{
    /// <summary>
    /// ucSetting.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ucSetting : UserControl
    {
        public ucSetting()
        {
            InitializeComponent();
        }

        public static DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(ucSetting));

        public static DependencyProperty BodyProperty = DependencyProperty.Register("Body", typeof(string), typeof(ucSetting));

        public static DependencyProperty IconsProperty = DependencyProperty.Register("Icons", typeof(ImageSource), typeof(ucSetting));

        public static DependencyProperty ImagesProperty = DependencyProperty.Register("Images", typeof(ImageSource), typeof(ucSetting));

        public static DependencyProperty ShowImageProperty = DependencyProperty.Register("ShowImage", typeof(bool), typeof(ucSetting));

        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }
            set
            {
                SetValue(TitleProperty, value);
            }
        }

        public string Body
        {
            get
            {
                return (string)GetValue(BodyProperty);
            }
            set
            {
                SetValue(BodyProperty, value);
            }

        }

        public ImageSource Icons
        {
            get
            {
                return (ImageSource)GetValue(IconsProperty);
            }
            set
            {
                SetValue(IconsProperty, value);
            }
        }

        public ImageSource Images
        {
            get
            {
                return (ImageSource)GetValue(ImagesProperty);
            }
            set
            {
                SetValue(ImagesProperty, value);
            }
        }

        public bool ShowImage
        {
            get
            {
                return (bool)GetValue(ShowImageProperty);
            }
            set
            {
                SetValue(ShowImageProperty, value);
            }
        }

        private void imgView_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ImageViewer viewer = new ImageViewer(imgView.Source);
            viewer.Show();
            viewer.Activate();
        }
    }
}
