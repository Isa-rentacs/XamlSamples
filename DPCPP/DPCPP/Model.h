#pragma once
namespace DPCPP
{

    public ref class Model sealed : Windows::UI::Xaml::Data::INotifyPropertyChanged
    {
    public:
        Model();
        Model(Windows::UI::Core::CoreDispatcher^ dispatcher);

        property Windows::Foundation::Collections::IVector<int>^ Items
        {
            Windows::Foundation::Collections::IVector<int>^ get()
            {
                return this->m_items;
            }

            void set(Windows::Foundation::Collections::IVector<int>^ items)
            {
                this->m_items = items;

                if (m_dispatcher != nullptr)
                {
                    m_dispatcher->RunAsync(Windows::UI::Core::CoreDispatcherPriority::Normal, ref new Windows::UI::Core::DispatchedHandler([this]() ->void {
                        PropertyChanged(this, ref new Windows::UI::Xaml::Data::PropertyChangedEventArgs("Items"));
                    }));
                }
            }
        }

        void Initialize();
        virtual event Windows::UI::Xaml::Data::PropertyChangedEventHandler ^ PropertyChanged;
    private:
        Windows::Foundation::Collections::IVector<int>^ m_items;
        Windows::System::Threading::ThreadPoolTimer^ m_timer;
        Windows::UI::Core::CoreDispatcher^ m_dispatcher;
        int m_count;
    };
}