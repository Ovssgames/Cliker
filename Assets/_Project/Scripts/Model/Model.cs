namespace _Project.Scripts.Model
{
    public interface IModel
    {
        int Clicks { get; }
        float TimeLeft { get; }
        bool IsGameActive { get; }

        void AddClick();
        void UpdateTime(float time);
        void Restart();
    }

    public class Model : IModel
    {
        public int Clicks { get; private set; }
        public float TimeLeft { get; private set;}
        public bool IsGameActive { get; private set;}

        private const float StartTime = 10f;
        
        public void AddClick()
        {
            if(!IsGameActive) return;
            
            Clicks++;
        }

        public void UpdateTime(float time)
        {
            if(!IsGameActive) return;
            
            TimeLeft -= time;

            if (TimeLeft <= 0)
            {
                TimeLeft = 0;
                IsGameActive = false; 
            }
        }

        public void Restart()
        {
            Clicks = 0;
            TimeLeft = StartTime;
            IsGameActive = true;
        }
    }
}
