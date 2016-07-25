#include "pch.h"
#include "Model.h"

DPCPP::Model::Model() : m_count(0)
{

}

DPCPP::Model::Model(Windows::UI::Core::CoreDispatcher^ dispatcher)
{
    m_dispatcher = dispatcher;
}

void DPCPP::Model::Initialize()
{
    Windows::Foundation::TimeSpan timespan;
    timespan.Duration = 3 * 1000 * 1000 * 10;
    m_timer = Windows::System::Threading::ThreadPoolTimer::CreatePeriodicTimer(ref new Windows::System::Threading::TimerElapsedHandler([&, this](auto x) -> void {
        auto vector = ref new Platform::Collections::Vector<int>();
        for (int i = 0; i < 5; ++i)
        {
            vector->Append(i + m_count);
        }
        m_count += 5;
        this->Items = vector;
    }), timespan);
}
