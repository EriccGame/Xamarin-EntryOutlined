using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SustentApp.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StandardEntryOutlined : ContentView
    {

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(String), typeof(StandardEntryOutlined), null);

        public static readonly BindableProperty PlaceholderProperty =
            BindableProperty.Create(nameof(Placeholder), typeof(String), typeof(StandardEntryOutlined), null);

        public static readonly BindableProperty PlaceholderColorProperty =
            BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(StandardEntryOutlined), Color.Blue);

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(StandardEntryOutlined), Color.Blue);

        public static BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(StandardEntryOutlined), 0);

        public static BindableProperty BorderThicknessProperty =
            BindableProperty.Create(nameof(BorderThickness), typeof(int), typeof(StandardEntryOutlined), 0);

        public static BindableProperty PaddingEntryProperty =
            BindableProperty.Create(nameof(PaddingEntry), typeof(Thickness), typeof(StandardEntryOutlined), new Thickness(5));

        public static BindableProperty KeyboardProperty =
            BindableProperty.Create(nameof(Padding), typeof(Keyboard), typeof(StandardEntryOutlined), Keyboard.Default);

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(String), typeof(StandardEntryOutlined), null);

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(Double), typeof(StandardEntryOutlined), null);

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(StandardEntryOutlined), Color.Black);

        public static readonly BindableProperty BackgroundColorEntryProperty =
            BindableProperty.Create(nameof(BackgroundColorEntry), typeof(Color), typeof(StandardEntryOutlined), Color.Transparent);

        public static readonly BindableProperty PlaceholderBackgroundColorProperty =
            BindableProperty.Create(nameof(PlaceholderBackgroundColor), typeof(Color), typeof(StandardEntryOutlined), Color.Transparent);

        public Color PlaceholderBackgroundColor
        {
            get { return (Color)GetValue(PlaceholderBackgroundColorProperty); }
            set { SetValue(PlaceholderBackgroundColorProperty, value); }
        }
        public Color BackgroundColorEntry
        {
            get { return (Color)GetValue(BackgroundColorEntryProperty); }
            set { SetValue(BackgroundColorEntryProperty, value); }
        }

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public Double FontSize
        {
            get { return (Double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }
        public String FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public Keyboard Keyboard
        {
            get => (Keyboard)GetValue(KeyboardProperty);
            set => SetValue(KeyboardProperty, value);
        }
        public int CornerRadius
        {
            get => (int)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public int BorderThickness
        {
            get => (int)GetValue(BorderThicknessProperty);
            set => SetValue(BorderThicknessProperty, value);
        }

        public Thickness PaddingEntry
        {
            get => (Thickness)GetValue(PaddingEntryProperty);
            set => SetValue(PaddingEntryProperty, value);
        }

        public StandardEntryOutlined()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public Color PlaceholderColor
        {
            get { return (Color)GetValue(PlaceholderColorProperty); }
            set { SetValue(PlaceholderColorProperty, value); }
        }

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        async void TextBox_Focused(object sender, FocusEventArgs e)
        {
            await TranslateLabelToTitle();
        }

        async void TextBox_Unfocused(object sender, FocusEventArgs e)
        {
            await TranslateLabelToPlaceHolder();
        }

        async Task TranslateLabelToTitle()
        {
            if (string.IsNullOrEmpty(this.Text))
            {
                var placeHolder = this.PlaceHolderLabel;
                var distance = GetPlaceholderDistance(placeHolder);
                await placeHolder.TranslateTo(0, -distance);
            }
        }

        async Task TranslateLabelToPlaceHolder()
        {
            if (string.IsNullOrEmpty(this.Text))
            {
                await this.PlaceHolderLabel.TranslateTo(0, 0);
            }
        }

        double GetPlaceholderDistance(Label control)
        {
            var distance = 0d;
            //if (Device.RuntimePlatform == Device.iOS) distance = 0;
            //else distance = 10;

            distance = control.Height + distance;
            return distance;
        }

        public event EventHandler<TextChangedEventArgs> TextChanged;
        public virtual void OnTextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            TextChanged?.Invoke(this, e);
        }
    }
}