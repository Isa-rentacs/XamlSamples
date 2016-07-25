#include "pch.h"
#include "ViewModel.h"

using namespace Windows::UI::Xaml;

DependencyProperty^ DPCPP::ViewModel::s_itemsProperty = DependencyProperty::Register
(
    "Items",
    Platform::Object::typeid,
    ViewModel::typeid,
    ref new PropertyMetadata(static_cast<Platform::Object^>(nullptr))
);

DPCPP::ViewModel::ViewModel()
{
    m_dispatcher = Windows::UI::Core::CoreWindow::GetForCurrentThread()->Dispatcher;
    m_model = ref new Model(m_dispatcher);
    m_model->PropertyChanged += ref new Windows::UI::Xaml::Data::PropertyChangedEventHandler(this, &ViewModel::OnPropertyChanged);
    m_model->Initialize();
}

void DPCPP::ViewModel::s_onItemsChanged(Windows::UI::Xaml::DependencyObject ^ obj, Windows::UI::Xaml::DependencyPropertyChangedEventArgs ^ args)
{
    auto viewModel = dynamic_cast<ViewModel^>(obj);
    auto items = dynamic_cast<Platform::Collections::Vector<int>^>(args->NewValue);
}

void DPCPP::ViewModel::OnPropertyChanged(Platform::Object^ sender, Windows::UI::Xaml::Data::PropertyChangedEventArgs^ e)
{
    this->Items = this->m_model->Items;
}
