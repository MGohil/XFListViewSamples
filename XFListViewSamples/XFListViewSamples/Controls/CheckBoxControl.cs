using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace XFListViewSamples.Controls
{
    /// <summary>
    /// A custom Checkbox Control:
    /// Properties : 
    ///     - CheckIcon
    ///     - UnCheckIcon
    ///     - IsChecked
    ///     - Text
    ///     - TextColor
    ///     - TextSize
    ///     - CheckBoxPosition
    /// Commands:
    ///     - Command
    /// </summary>
    public class CheckBoxControl : Grid
    {
        /// <summary>
        /// Decides if Checkbox should be positioned to the Left of the Text or right of the Text
        /// </summary>
        public enum CheckboxPosition
        {
            Default,
            Left,
            Right,
        }
        private Image _checkboxImage;
        private Label _checkboxTextLabel;

        #region Bindable Properties        
        public static readonly BindableProperty CheckIconProperty = BindableProperty.Create(nameof(CheckIconProperty), typeof(string), typeof(CheckBoxControl), "checkbox_checked.png");
        public string CheckIcon
        {
            get { return (string)GetValue(CheckIconProperty); }
            set { SetValue(CheckIconProperty, value); }
        }

        public static readonly BindableProperty UnCheckIconProperty = BindableProperty.Create(nameof(UnCheckIconProperty), typeof(string), typeof(CheckBoxControl), "checkbox_unchecked.png");
        public string UnCheckIcon
        {
            get { return (string)GetValue(UnCheckIconProperty); }
            set { SetValue(UnCheckIconProperty, value); }
        }

        public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(nameof(IsCheckedProperty), typeof(bool), typeof(CheckBoxControl), false, propertyChanged: IsCheckedChanged);
        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }
        private static void IsCheckedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CheckBoxControl Control = (bindable as CheckBoxControl);
            Control._checkboxImage.Source = Control.IsChecked ? Control.CheckIcon : Control.UnCheckIcon;           
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(TextProperty), typeof(string), typeof(CheckBoxControl), string.Empty, BindingMode.TwoWay, propertyChanged: TextPropertyChanged);
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        static void TextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CheckBoxControl checkboxControl = (bindable as CheckBoxControl);
            checkboxControl._checkboxTextLabel.Text = newValue as string;
            checkboxControl.ColumnSpacing = !string.IsNullOrEmpty(checkboxControl._checkboxTextLabel.Text) && !string.IsNullOrWhiteSpace(checkboxControl._checkboxTextLabel.Text) ? 5 : 0;
        }

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColorProperty), typeof(Color), typeof(CheckBoxControl), Color.Gray, BindingMode.TwoWay, propertyChanged: TextColorPropertyChanged);
        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }
        private static void TextColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as CheckBoxControl)._checkboxTextLabel.TextColor = (Color)newValue;
        }

        public static readonly BindableProperty TextSizeProperty = BindableProperty.Create(nameof(TextSizeProperty), typeof(double), typeof(CheckBoxControl), 0.0, defaultValueCreator: bindable => Device.GetNamedSize(NamedSize.Default, (Label)bindable));
        public double TextSize
        {
            get { return (double)GetValue(TextSizeProperty); }
            set { SetValue(TextSizeProperty, value); }
        }
        private static void TextSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CheckBoxControl checkboxControl = (bindable as CheckBoxControl);
            checkboxControl._checkboxTextLabel.FontSize = (double)newValue;
        }

        public static BindableProperty CheckBoxPositionProperty = BindableProperty.Create(nameof(CheckBoxPositionProperty), typeof(CheckboxPosition), typeof(CheckBoxControl), CheckboxPosition.Default, BindingMode.TwoWay, propertyChanged: CheckBoxPositionChanged);
        public CheckboxPosition CheckBoxPosition
        {
            get { return (CheckboxPosition)GetValue(CheckBoxPositionProperty); }
            set { SetValue(CheckBoxPositionProperty, value); }
        }
        static void CheckBoxPositionChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as CheckBoxControl).CreateControl();
        }

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(CheckBoxControl), null);
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(CheckBoxControl), null);
        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        #endregion

        #region Methods

        private void CreateControl()
        {
            var checkboxControlTapGuesture = new TapGestureRecognizer();
            checkboxControlTapGuesture.Tapped += OnCheckboxControlTapped;
            GestureRecognizers.Add(checkboxControlTapGuesture);

            _checkboxImage = new Image();
            _checkboxTextLabel = new Label();
            _checkboxImage.VerticalOptions = LayoutOptions.CenterAndExpand;
            _checkboxTextLabel.VerticalTextAlignment = TextAlignment.Center;
            _checkboxImage.Source = ImageSource.FromFile(UnCheckIcon);

            if (CheckBoxPosition == CheckboxPosition.Right)
            {
                RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                Children.Add(_checkboxTextLabel, 0, 0);
                Children.Add(_checkboxImage, 1, 0);
                ColumnSpacing = 5;
            }
            else
            {
                ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
                this.Children.Add(_checkboxImage, 0, 0);
                this.Children.Add(_checkboxTextLabel, 1, 0);
                ColumnSpacing = 0;
            }

            VerticalOptions = LayoutOptions.CenterAndExpand;
            HorizontalOptions = LayoutOptions.FillAndExpand;

            Margin = new Thickness(0);
            Padding = new Thickness(8.0);
            RowSpacing = 0;           
        }

        /// <summary>
        /// Invokes when twe tap on whole Checkbox Control
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="eventArgs">Event arguments.</param>
        private void OnCheckboxControlTapped(object sender, EventArgs eventArgs)
        {
            if (IsEnabled)
                IsChecked = !IsChecked;
            if ((sender as Grid) != null)
                Command?.Execute((sender as Grid).BindingContext);
            else
                Command?.Execute(IsChecked);
        }
        #endregion
    }
}
