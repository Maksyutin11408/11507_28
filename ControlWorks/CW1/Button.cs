using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW1
{
    public class ClickEventArgs : EventArgs
    {
        public int TotalClicks { get; set; }
        public DateTime LastClickTime { get; set; }
        public ClickEventArgs (int clicks, DateTime datetime)
        {
            TotalClicks = clicks; 
            LastClickTime = datetime;
        }
    }

    public class MyButton
    {
        private int _clickCount = 0;
        public event EventHandler<ClickEventArgs> Click;

        public void OnClick()
        {
            _clickCount++;
            Click.Invoke(Click, new ClickEventArgs(_clickCount, DateTime.Now));
        }

        public void Message(object sender, ClickEventArgs data)
        {
            Console.WriteLine("Кнопка нажата! Всего кликов: " + data.TotalClicks + ", Время: " + data.LastClickTime);
        }
    }
}
