namespace GameProject.Models
{
    using System;

    public class DeadPlayerException : ApplicationException
    {
        private int health;

        public DeadPlayerException(int health)
            : base(string.Format("The player died! (health = {0})", health), null)
        {
            this.Health = health;
        }

        public int Health
        {
            get { return this.health; }
            private set { this.health = value; }
        }
    }
}
