#pragma once

#include "Model.h"

namespace DPCPP
{
    [Windows::UI::Xaml::Data::Bindable]
    public ref class ViewModel sealed : 
        public Windows::UI::Xaml::DependencyObject
    {
    public:
        ViewModel();

        static property Windows::UI::Xaml::DependencyProperty^ ItemsProperty
        {
            Windows::UI::Xaml::DependencyProperty^ get()
            {
                return s_itemsProperty;
            }
        }
        /*
        property Windows::Foundation::Collections::IVector<int>^ Items
        {
            Windows::Foundation::Collections::IVector<int>^ get()
            {
                return m_items;
            }

            void set(Windows::Foundation::Collections::IVector<int>^ items)
            {
                m_items = items;
                if (m_dispatcher != nullptr)
                {
                    auto var = m_dispatcher->RunAsync(Windows::UI::Core::CoreDispatcherPriority::Normal, ref new Windows::UI::Core::DispatchedHandler([this]() -> void {
                        PropertyChanged(this, ref new Windows::UI::Xaml::Data::PropertyChangedEventArgs("Items"));
                    }));

                }
            }
        }
        */

        property Windows::Foundation::Collections::IVector<int>^ Items
        {
            Windows::Foundation::Collections::IVector<int>^ get()
            {
                return dynamic_cast<Windows::Foundation::Collections::IVector<int>^>(GetValue(ItemsProperty));
            }

            void set(Windows::Foundation::Collections::IVector<int>^ items)
            {
                SetValue(ItemsProperty, items);
            }
        }
        property Platform::String^ Text
        {
            Platform::String^ get()
            {
                return m_str;
            }

            void set(Platform::String^ str)
            {
                m_count++;
                m_str = str + m_count;
            }
        }

    private:
        static Windows::UI::Xaml::DependencyProperty^ s_itemsProperty;
        static void s_onItemsChanged(Windows::UI::Xaml::DependencyObject^ obj, Windows::UI::Xaml::DependencyPropertyChangedEventArgs^ args);
        Windows::Foundation::Collections::IVector<int>^ m_items;
        Windows::UI::Core::CoreDispatcher^ m_dispatcher;
        DPCPP::Model^ m_model;
        Platform::String^ m_str;
        int m_count = 0;
        void OnPropertyChanged(Platform::Object^ sender, Windows::UI::Xaml::Data::PropertyChangedEventArgs^ e);
    };
}