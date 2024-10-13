using System.Timers;
using Timer = System.Timers.Timer;
namespace pract6RMP;

public partial class TimerHome : ContentPage
{
    private Timer timer;
    private DateTime backTime;
    private TimeSpan stayTime;
    public TimerHome()
	{
		InitializeComponent();
        timer = new Timer(1000);
        timer.Elapsed += DoTime;
        timer.AutoReset = true;//��������������
    }
    async private void DoTime(object sender, ElapsedEventArgs e)
    {
        stayTime = backTime - DateTime.Now;

        if (stayTime.TotalSeconds <= 0)
        {
            timer.Stop();
            // ���������� ������������ � ���������� �������
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("��������", "����� �����!", "��");
            });

        }
        else
        {
            // ��������� ���������� ����� � ���������� 
            MainThread.BeginInvokeOnMainThread(() =>
            {
                timeLabel.Text = $"{stayTime.Hours:D2}:{stayTime.Minutes:D2}:{stayTime.Seconds:D2}";
            });
        }
    }
    private void Start_Clicked(object sender, EventArgs e)
    {
        Stop.IsEnabled = true;
        backTime = DateTime.Now.Add(timePicker.Time);
        stayTime = timePicker.Time;
        timer.Start();
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await DisplayAlert("��������", $"������ ������� �� {timePicker.Time.Hours:D2}:{timePicker.Time.Minutes:D2}:{stayTime.Seconds:D2}", "��");
        });
    }

    private void Stop_Clicked(object sender, EventArgs e)
    {
        Clear.IsEnabled = true;
        timer.Stop();
    }

    private void Clear_Clicked(object sender, EventArgs e)
    {
               
        timeLabel.Text = "��������:";
        timePicker.Time = TimeSpan.Zero; 

        
        Start.IsEnabled = true;
        Stop.IsEnabled = false;
        Clear.IsEnabled = false;
    }
}