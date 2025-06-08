using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI_WpfApp.Controls
{
    /// <summary>
    /// Interaction logic for BusyIndicator.xaml
    /// </summary>

    public partial class BusyIndicator : UserControl
    {
        public BusyIndicator()
        {
            InitializeComponent();            
        }

        public static readonly DependencyProperty IsBusyProperty =
           DependencyProperty.Register(nameof(IsBusy), typeof(bool), typeof(BusyIndicator), new PropertyMetadata(false));

        public bool IsBusy
        {
            get => (bool)GetValue(IsBusyProperty);
            set => SetValue(IsBusyProperty, value);
        }

        public static readonly DependencyProperty InnerContentProperty =
            DependencyProperty.Register(nameof(InnerContent), typeof(UIElement), typeof(BusyIndicator), new PropertyMetadata(null, OnContentChanged));

        public UIElement InnerContent
        {
            get => (UIElement)GetValue(InnerContentProperty);
            set => SetValue(InnerContentProperty, value);
        }

        private static void OnContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ; ;
        
        }
    }

    

}
