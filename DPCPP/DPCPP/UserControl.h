#pragma once
#include "ViewModel.h"
namespace DPCPP
{
    public ref class UserControl sealed : public Windows::UI::Xaml::Controls::Control
    {
    public:
        UserControl();

        static property Windows::UI::Xaml::DependencyProperty^ ItemsProperty
        {
            Windows::UI::Xaml::DependencyProperty^ get()
            {
                return m_itemsProperty;
            }
        }

        property DPCPP::ViewModel^ ViewModel
        {
            DPCPP::ViewModel^ get()
            {
                if (m_viewModel == nullptr)
                {
                    m_viewModel = ref new DPCPP::ViewModel();
                }

                return m_viewModel;
            }
        }

        property Windows::Foundation::Collections::IVector<int>^ Items
        {
            Windows::Foundation::Collections::IVector<int>^ get()
            {
                return (Windows::Foundation::Collections::IVector<int>^)GetValue(ItemsProperty);
            }

            void set(Windows::Foundation::Collections::IVector<int>^ items)
            {
                SetValue(ItemsProperty, items);
            }
        }

        property int Value
        {
            int get()
            {
                return m_int;
            }

            void set(int i)
            {
                m_int = i;
            }
        }

        void UpdateProperty();
    private:
        static Windows::UI::Xaml::DependencyProperty^ m_itemsProperty;
        static void s_OnItemsChanged(Windows::UI::Xaml::DependencyObject^ obj, Windows::UI::Xaml::DependencyPropertyChangedEventArgs^ e);
        void CheckBinding();
        DPCPP::ViewModel^ m_viewModel;
        int m_int;
    };
}