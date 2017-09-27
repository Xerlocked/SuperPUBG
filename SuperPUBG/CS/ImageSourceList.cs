using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SuperPUBG.CS
{
    public class ImageSourceList
    {
        private ImageSource imageGoClean    = new BitmapImage(new Uri("pack://application:,,,/Resources/goclean.ico"));
        private ImageSource imageSteam      = new BitmapImage(new Uri("pack://application:,,,/Resources/steam.ico"));
        private ImageSource imageDisCord    = new BitmapImage(new Uri("pack://application:,,,/Resources/discord.ico"));
        private ImageSource imageReShade    = new BitmapImage(new Uri("pack://application:,,,/Resources/reshade.ico"));
        private ImageSource imagePUBG       = new BitmapImage(new Uri("pack://application:,,,/Resources/pubg.ico"));
        private ImageSource imageNvidia     = new BitmapImage(new Uri("pack://application:,,,/Resources/nvidia.ico"));

        private ImageSource GoClean_Png     = new BitmapImage(new Uri("pack://application:,,,/Resources/gocleans.png"));
        private ImageSource Memory_Png      = new BitmapImage(new Uri("pack://application:,,,/Resources/memory.png"));

        public ImageSource IconType(string iconName)
        {
            switch (iconName)
            {
                case "GoClean":
                    return imageGoClean;
                case "Steam":
                    return imageSteam;
                case "Discord":
                    return imageDisCord;
                case "Reshade":
                    return imageReShade;
                case "PUBG":
                    return imagePUBG;
                case "Memory":
                    return Memory_Png;
                case "Nvidia":
                    return imageNvidia;
                default:
                    return imagePUBG;
            }
        }

        public ImageSource SettingType(string imgName)
        {
            switch (imgName)
            {
                case "GoClean":
                    return GoClean_Png;
                default:
                    return null;
            }
        }

    }
}
