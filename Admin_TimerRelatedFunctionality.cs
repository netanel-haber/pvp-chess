using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Chess___netanel
{
    partial class Admin
    {
        //everything having to do with managing time and turns
        Timer whiteTimer;
        Timer blackTimer;
        TimeSpan CountdownWhite;
        TimeSpan CountdownBlack;

        public void MitigateTimers()
        {
            CountdownWhite = new TimeSpan(0, 30, 0);
            CountdownBlack = new TimeSpan(0, 30, 0);

            whiteTimer = new System.Timers.Timer() { Interval = 1000, AutoReset = true, SynchronizingObject = null };
            whiteTimer.Elapsed += countdownWhite;
            whiteTimer.Start();

            blackTimer = new System.Timers.Timer() { Interval = 1000, AutoReset = true, SynchronizingObject = null };
            blackTimer.Elapsed += countdownBlack;
        }
        public void FlipTurns()
        {
            if (whiteTimer.Enabled)
            {
                whiteTimer.Stop();
                blackTimer.Start();
            }
            else
            {
                blackTimer.Stop();
                whiteTimer.Start();
            }

            Invocation delg = UIForm.ToggleTurnLabel;
            UIForm.Invoke(delg);
        }
        public void StopTheClocksExclemationPoint()
        {
            blackTimer.Stop();
            whiteTimer.Stop();
        }

        private void countdownTick(ref TimeSpan timer)
        {

            timer = timer.Subtract(new TimeSpan(0, 0, 1));
            Colors current = blackTimer.Enabled ? Colors.Black : Colors.White;
            if (timer.Equals(new TimeSpan(0, 0, 0)))
            {
                StopTheClocksExclemationPoint();
                gameEndsOnTime(current);
                return;
            }
            TimerInvokationDelegate delg = UIForm.UpdateTimer;

            lock (this)
            {
                if (UIForm.IsDisposed)
                    UIForm = null;
                else
                    UIForm.Invoke(delg, timer.ToString("mm\\:ss"), current);
            }
        }

        private void disposedUI(object sender, EventArgs e)
        {
            StopTheClocksExclemationPoint();
        }

        private void countdownWhite(object sent, ElapsedEventArgs e)
        {
            countdownTick(ref CountdownWhite);
        }
        private void countdownBlack(object sent, ElapsedEventArgs e)
        {
            countdownTick(ref CountdownBlack);
        }
    }
    delegate void Invocation();
    delegate void TimerInvokationDelegate(string UpdatedTime, Colors color);
}
