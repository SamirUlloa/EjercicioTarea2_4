using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CamN
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void TakePhoto_Clicked(object sender, EventArgs e)
        {
            var cameraOptions = new StoreCameraMediaOptions();
            cameraOptions.SaveToAlbum = true;
            
            var photo =
                await Plugin.Media.CrossMedia.Current
                .TakePhotoAsync(cameraOptions);

            if (photo != null)
            {
                Photo.Source = ImageSource.FromStream(() =>
                {
                    return photo.GetStream();
                });

                await DisplayAlert("Aviso", "Guardado Con Exito", "OK");
            }
           
        }
    }
}
