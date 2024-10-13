using Timer = System.Timers.Timer;
namespace pract6RMP
{
    public partial class MainPage : ContentPage
    {
        private Timer time1;
        public MainPage()
        {
            InitializeComponent();
            StartWatch();
            CheckTime();
        }  
         
        private void dpDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateTime setDate;
            //поулчаем выбранную дату
            setDate = dpDate.Date;
            
        }
        private void CheckTime()
        {
            time1 = new Timer(1000);
            time1.Elapsed += (s, e) => StartWatch();
            time1.Start();
            
        }
        private void StartWatch()
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                watchLabel.Text = DateTime.Now.ToString("HH:mm:ss");
            });     
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            StartWatch();
        }
    }

}
