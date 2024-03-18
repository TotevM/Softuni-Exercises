namespace Raiding.Models
{
    public abstract class BaseHero
    {
		private string name;
        private int power;

        protected BaseHero(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public string Name
		{
			get { return name; }
			set { name = value; }
		}


        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public abstract string CastAbility();
    }
}
