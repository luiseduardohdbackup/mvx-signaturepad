using System;
using System.Collections.Generic;


namespace Acr.MvvmCross.Plugins.SignaturePad.WindowsPhone {
    
    public class WinPhoneSignatureService : AbstractSignatureService {

        public override void Request(Action<SignatureResult> onResult) {
            throw new NotImplementedException();
        }


        public override void Load(IEnumerable<DrawPoint> points) {
            throw new NotImplementedException();
        }
    }
}
/*
 *  public partial class MainPage : PhoneApplicationPage
    {
        Point [] points;

        // Constructor
        public MainPage ()
        {
            InitializeComponent ();
        }

        private void btnSave_Click (object sender, RoutedEventArgs e)
        {
            points = signatureView.Points;

            MessageBox.Show ("Vector saved!");
        }

        private void btnLoad_Click (object sender, RoutedEventArgs e)
        {
            signatureView.LoadPoints (points);
        }

        private void btnSaveImage_Click (object sender, RoutedEventArgs e)
        {
            WriteableBitmap bitmap = signatureView.GetImage ();

            using (MemoryStream stream = new MemoryStream ()) {
                bitmap.SaveJpeg (stream, bitmap.PixelWidth, bitmap.PixelHeight, 0, 100);
                stream.Seek (0, SeekOrigin.Begin);

                using (MediaLibrary mediaLibrary = new MediaLibrary ())
                    mediaLibrary.SavePicture ("signature.jpg", stream);
            }
            MessageBox.Show ("Picture saved to photo library");
        }
    }
<phone:PhoneApplicationPage 
    x:Class="Sample.WP7.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:phone="clr-namespace:Microsoft.Phone.Controls;assembly=Microsoft.Phone"
    xmlns:shell="clr-namespace:Microsoft.Phone.Shell;assembly=Microsoft.Phone"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d" d:DesignWidth="728" d:DesignHeight="480"
    FontFamily="{StaticResource PhoneFontFamilyNormal}"
    FontSize="{StaticResource PhoneFontSizeNormal}"
    Foreground="{StaticResource PhoneForegroundBrush}"
    SupportedOrientations="PortraitOrLandscape" Orientation="Landscape"
    shell:SystemTray.IsVisible="True" xmlns:my="clr-namespace:Xamarin.Controls;assembly=SignaturePad.WP7">

    <!--LayoutRoot is the root grid where all page content is placed-->
    <Grid x:Name="LayoutRoot" Background="LightGray">
        <my:SignaturePad Margin="10,10,10,78" Name="signatureView" />
        <Button Content="Save" Background="DarkGray" Foreground="Black" BorderBrush="Black" Height="72" HorizontalAlignment="Left" Margin="0,0,0,0" Name="btnSave" VerticalAlignment="Bottom" Width="160" Click="btnSave_Click" />
        <Button Content="Load Last" Background="DarkGray" Foreground="Black" BorderBrush="Black" Height="72" HorizontalAlignment="Right" Margin="0,0,0,0" Name="btnLoad" VerticalAlignment="Bottom" Width="160" Click="btnLoad_Click" />
        <Button Content="Save Image" Background="DarkGray" Foreground="Black" BorderBrush="Black" Height="72" HorizontalAlignment="Center" Margin="0,0,0,0" Name="btnSaveImage" VerticalAlignment="Bottom" Width="180" Click="btnSaveImage_Click" />
    </Grid>
</phone:PhoneApplicationPage>*/