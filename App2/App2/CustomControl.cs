using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace App2
{
    public class CustomControl : Windows.UI.Xaml.Controls.Control
    {
        private static readonly string listViewName = "CustomControl_ListView";
        private ListView listView;
        private int offset = 0;

        public CustomControl() { }

        public static readonly DependencyProperty ItemListPropery = DependencyProperty.Register("ItemList", typeof(List<string>), typeof(CustomControl), new PropertyMetadata(null));
        public List<string> ItemList
        {
            get { return (List<string>)GetValue(ItemListPropery); }
            set { SetValue(ItemListPropery, value); }
        }

       

        private int elementCount = 0;
        public int ElementCount
        {
            get { return elementCount; }
            set { elementCount = value; }
        }

        private List<string> VisibleItemList
        {
            get { return ItemList.Skip(offset).Take(elementCount).ToList(); }
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            listView = (ListView)GetTemplateChild(listViewName);
            listView.ItemsSource = VisibleItemList;
        }

        protected override void OnTapped(TappedRoutedEventArgs e)
        {
            base.OnTapped(e);

            offset += elementCount;
            if (offset >= ItemList.Count)
            {
                offset = 0;
            }
            OnApplyTemplate();
        }
    }
}
