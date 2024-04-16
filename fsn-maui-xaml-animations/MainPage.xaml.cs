namespace fsn_maui_xaml_animations;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnRotateAnimation(object sender, EventArgs e)
    {
        await animatedLabel.RelRotateTo(180, 800);
        await animatedLabel.RelRotateTo(-180, 800);
    }

    private async void OnScaleAnimation(object sender, EventArgs e)
    {
        await animatedLabel.ScaleTo(4, 800);
        await animatedLabel.ScaleTo(1, 800);
    }

    private async void OnScaleAndRotateAnimation(object sender, EventArgs e)
    {
        await Task.WhenAll<bool>(
         animatedLabel.ScaleTo(4, 800),
         animatedLabel.RelRotateTo(180, 800)
        );

        await Task.WhenAll<bool>(
         animatedLabel.ScaleTo(1, 800),
         animatedLabel.RelRotateTo(-180, 800)
        );

    }

    private async void OnTranslateAndRotate(object sender, EventArgs e)
    {
        // Let op: de animatie loopt zodra je een ViewExtension animatie aanroept.
        // dus volgorde van Task<> definities maakt uit
        Task<bool> t1 = animatedLabel.TranslateTo(100, 200, 800);
        Task<bool> t2 = animatedLabel.RelRotateTo(180, 800);

        await Task.WhenAll(t1, t2);

        Task<bool> t3 = animatedLabel.TranslateTo(0, 0, 800);
        Task<bool> t4 = animatedLabel.RelRotateTo(-180, 800);

        await Task.WhenAll(t3, t4);
    }

    private async void OnScaleAndFade(object sender, EventArgs e)
    {
        // Let op: de animatie loopt zodra je en ViewExtension animatie aanroept.
        // dus volgorde van Task<> definities maakt uit
        Task<bool> t1 = animatedLabel.ScaleTo(4, 800, Easing.BounceIn);
        Task<bool> t2 = animatedLabel.FadeTo(0, 800);

        await Task.WhenAll(t1, t2);

        Task<bool> t3 = animatedLabel.ScaleTo(1, 800, Easing.BounceOut);
        Task<bool> t4 = animatedLabel.FadeTo(1, 800);

        await Task.WhenAll(t3, t4);
    }

    private void OnCancel(object sender, EventArgs e)
    {
        animatedLabel.CancelAnimations();
    }

}
