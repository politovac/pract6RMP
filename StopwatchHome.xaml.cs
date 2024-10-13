using System.Timers;
using Timer = System.Timers.Timer;
namespace pract6RMP;

public partial class StopwatchHome : ContentPage
{
    private Timer timer;
    private DateTime startTime;
    private TimeSpan elapsedTime1; // Время, прошедшее с начала работы
    private bool pysk;
    public StopwatchHome()
    {
        InitializeComponent();
        timer = new Timer(300);
        timer.Elapsed += DoTime;
    }
    private void DoTime(object sender, ElapsedEventArgs e)
    {
        var elapsedTime = DateTime.Now - startTime + elapsedTime1;
        MainThread.BeginInvokeOnMainThread(() =>
        {
            timeLabel.Text = elapsedTime.ToString(@"hh\:mm\:ss");//обновление
        });
    }
    private void Start_Clicked(object sender, EventArgs e)
    {
        Stop.IsEnabled = true;
        Start.IsEnabled = false;
        Reset.IsEnabled = true;
        if (!pysk)
        {
            startTime = DateTime.Now;
            timer.Start();
            pysk = true;
        }
        
    }

    private void Stop_Clicked(object sender, EventArgs e)
    {
        Stop.IsEnabled = false;
        Start.IsEnabled = true;
        Reset.IsEnabled = true;
        if (pysk)
        {
            timer.Stop();
            elapsedTime1 += DateTime.Now - startTime;
            pysk = false;
        }
        
    }

    private void Reset_Clicked(object sender, EventArgs e)
    {
        Stop.IsEnabled = false;
        Start.IsEnabled = true;
        Reset.IsEnabled = false;
        timer.Stop();
        pysk = false;
        elapsedTime1 = TimeSpan.Zero; // Сбрасываем прошедшее время
        timeLabel.Text = "00:00:00";
    }
}