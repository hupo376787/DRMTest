using PallyConSDK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DRMTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Work : Page
    {
        public static PallyConPRSDK pallyconsdk = PallyConPRSDK.GetInstance;
        public string SiteID = "BGJK";
        public string SiteKey = "kwOinfUDGHHcVkmNPs0jTkXPePONkm2L";
        public string ContentURL = "https://dev-drm.ottuat.com/video/drm/dash0326/stream.mpd";        //Bad
        //public string ContentURL = "https://work.viuers.com/eddy/bitmovin/BJ2/dash/stream.mpd";   //OK
        public string Token = "eyJrZXlfcm90YXRpb24iOmZhbHNlLCJyZXNwb25zZV9mb3JtYXQiOiJvcmlnaW5hbCIsInVzZXJfaWQiOiJ2aXVkZXYiLCJkcm1fdHlwZSI6IlBsYXlSZWFkeSIsInNpdGVfaWQiOiJCR0pLIiwiaGFzaCI6InMyNmR2Z09haGVybkVFZ3RHMFhrUE92bkxDMXNDd2R4K3BMVTRrQVVwdzA9IiwiY2lkIjoiYmpzYW1wbGU1IiwicG9saWN5IjoiT0RMbkZQaFBYb1pPaFd3YStBZThtdz09IiwidGltZXN0YW1wIjoiMjAyMS0wMy0yNlQwOTowMDowMFoifQ==";

        public Work()
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
                // 4. content license information set
                var protect = await pallyconsdk.CreateProtectionManagerByToken(Token, false);
                Player.ProtectionManager = protect;

                // 5. Play
                Player.Source = new Uri(ContentURL);
                Player.Play();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

    }
}
