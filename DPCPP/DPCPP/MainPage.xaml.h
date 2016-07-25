//
// MainPage.xaml.h
// Declaration of the MainPage class.
//

#pragma once

#include "MainPage.g.h"
#include "UserControl.h"
#include "ViewModel.h"
namespace DPCPP
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public ref class MainPage sealed
	{
	public:
		MainPage();

    private:
        void button_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);
        void button_Click2(Platform::Object ^ sender, Windows::UI::Xaml::RoutedEventArgs ^ e);
        void button_Click3(Platform::Object ^ sender, Windows::UI::Xaml::RoutedEventArgs ^ e);
        ViewModel^ m_viewModel;
        ViewModel^ m_viewModelButton;
    };
}
