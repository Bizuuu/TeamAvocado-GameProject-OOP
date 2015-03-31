namespace GameProject.Models
{
    using System;
    using Microsoft.Xna.Framework.Audio;

    public class SoundPublisher
    {
        public event EventHandler Tick;

        public SoundEffect SoundEffect { get; set; }

        public delegate void EventHandler(SoundPublisher publisher, EventArgs e);

        public SoundPublisher(SoundEffect soundEffect)
        {
            this.SoundEffect = soundEffect;
        }

        public void Execute()
        {
            if (Tick != null)
            {
                Tick(this, EventArgs.Empty);
            }
        }
    }
}
