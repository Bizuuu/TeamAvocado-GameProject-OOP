namespace GameProject.Models
{
    using Microsoft.Xna.Framework.Audio;  

    public class SoundCaller
    {
        SoundPublisher publisher;
        SoundSubscriber subscriber;

        public SoundCaller(SoundEffect eff)
        {
            publisher = new SoundPublisher(eff);
            subscriber = new SoundSubscriber();
            subscriber.Subscribe(publisher);
            publisher.Execute();
        }
    }
}
