#include "pch.h"
#include "UserControl.h"

using namespace Windows::UI::Xaml;

DPCPP::UserControl::UserControl()
{
}

void DPCPP::UserControl::UpdateProperty()
{
    this->Items = ref new Platform::Collections::Vector<int>();
    this->CheckBinding();
}

void DPCPP::UserControl::s_OnItemsChanged(Windows::UI::Xaml::DependencyObject ^ obj, Windows::UI::Xaml::DependencyPropertyChangedEventArgs ^ e)
{
	auto items = dynamic_cast<Windows::Foundation::Collections::IVector<int>^>(e->NewValue);
	if (items != nullptr)
	{
		//yey
	}
	else
	{
		throw ref new Platform::FailureException("sad..");
	}
    auto objAsControl = dynamic_cast<DPCPP::UserControl^>(obj);
    if (objAsControl != nullptr)
    {
        objAsControl->CheckBinding();
    }
}

void DPCPP::UserControl::CheckBinding()
{
    auto bindingExpression = this->GetBindingExpression(DPCPP::UserControl::m_itemsProperty);
    auto dataItem = bindingExpression->DataItem;
    auto binding = bindingExpression->ParentBinding;
    auto elementName = binding->ElementName;
    auto mode = binding->Mode;
    auto source = binding->Source;
    auto dataContext = dynamic_cast<DPCPP::ViewModel^>(this->DataContext);
    bindingExpression->UpdateSource();
}

DependencyProperty^ DPCPP::UserControl::m_itemsProperty = DependencyProperty::Register(
    "Items",
	//Platform::Collections::Vector<int>::typeid,
    Platform::Object::typeid,
	UserControl::typeid,
    ref new PropertyMetadata(static_cast<Platform::Object^>(nullptr), ref new PropertyChangedCallback(&UserControl::s_OnItemsChanged))
);
