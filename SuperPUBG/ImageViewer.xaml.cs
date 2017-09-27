using System.Windows;
using System.Windows.Media;

namespace SuperPUBG
{
    /// <summary>
    /// ImageViewer.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ImageViewer : Window
    {
        public ImageViewer()
        {
            InitializeComponent();
        }
        public ImageViewer(ImageSource imageSource)
        {
            InitializeComponent();
            ImageView.Source = imageSource;
        }
    }
}
