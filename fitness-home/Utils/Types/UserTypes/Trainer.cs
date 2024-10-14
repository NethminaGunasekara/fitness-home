namespace fitness_home.Utils.Types.UserTypes
{
    internal class Trainer : User
    {
        public int ID { get; }
        public Role Role { get; }

        public Trainer(int id)
        {
            ID = id;
            Role = Role.Member;
        }
    }
}
