using PallyConSDK;
using System;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DRMTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static PallyConPRSDK pallyconsdk = PallyConPRSDK.GetInstance;
        public string SiteID = "BGJK";
        public string SiteKey = "kwOinfUDGHHcVkmNPs0jTkXPePONkm2L";
        public string ContentURL = "https://dev-drm.ottuat.com/video/drm/dash0326/stream.mpd";        //Bad
        //public string ContentURL = "https://work.viuers.com/eddy/bitmovin/BJ2/dash/stream.mpd";   //OK
        public string Token = "eyJrZXlfcm90YXRpb24iOmZhbHNlLCJyZXNwb25zZV9mb3JtYXQiOiJvcmlnaW5hbCIsInVzZXJfaWQiOiJ2aXVkZXYiLCJkcm1fdHlwZSI6IlBsYXlSZWFkeSIsInNpdGVfaWQiOiJCR0pLIiwiaGFzaCI6InMyNmR2Z09haGVybkVFZ3RHMFhrUE92bkxDMXNDd2R4K3BMVTRrQVVwdzA9IiwiY2lkIjoiYmpzYW1wbGU1IiwicG9saWN5IjoiT0RMbkZQaFBYb1pPaFd3YStBZThtdz09IiwidGltZXN0YW1wIjoiMjAyMS0wMy0yNlQwOTowMDowMFoifQ==";

        public MainPage()
        {
            this.InitializeComponent();
            try
            {
                // 3. PallyConPR SDK initialize
                pallyconsdk.Initialize(SiteID, SiteKey);
                //pallyconsdk.ConfigureHardwareDRM(Player.MediaPlayer);

                PallyConPlayReady();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public async void PallyConPlayReady()
        {
            try
            {
                var mediaPlayer = new MediaPlayer();
                Player.SetMediaPlayer(mediaPlayer);

                // 4. content license information set
                var protect = await pallyconsdk.CreateProtectionManagerByToken(Token, false);
                mediaPlayer.ProtectionManager = protect;

                // 5. Play
                mediaPlayer.Source = MediaSource.CreateFromUri(new Uri(ContentURL));
                mediaPlayer.Play();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
