//
// MainPage.xaml.cpp
// Implementation of the MainPage class.
//

#include "pch.h"
#include "MainPage.xaml.h"

using namespace DPCPP;

using namespace Platform;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Controls::Primitives;
using namespace Windows::UI::Xaml::Data;
using namespace Windows::UI::Xaml::Input;
using namespace Windows::UI::Xaml::Media;
using namespace Windows::UI::Xaml::Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

MainPage::MainPage()
{
	InitializeComponent();
    m_viewModel = ref new ViewModel();

	//this->ParentGrid->DataContext = m_viewModel;
    m_viewModelButton = ref new ViewModel();
	//this->DataContext = m_viewModelButton;
    this->UserControl1->DataContext = m_viewModelButton;
    this->button->DataContext = m_viewModelButton;
	this->ListView->DataContext = m_viewModelButton;
	this->textBlock->DataContext = m_viewModelButton;
}


void DPCPP::MainPage::button_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
    m_viewModelButton->Text = "Clicked times : ";
	m_viewModelButton->Items = ref new Platform::Collections::Vector<int>({1,2,3,4,5});
}

void DPCPP::MainPage::button_Click2(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
    auto items = dynamic_cast<Platform::Collections::Vector<int>^>(m_viewModelButton->Items);
    this->UserControl1->UpdateProperty();
}

void DPCPP::MainPage::button_Click3(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
    this->ListView->ItemsSource = ref new Platform::Collections::Vector<int>();
}