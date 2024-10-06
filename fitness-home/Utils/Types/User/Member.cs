namespace fitness_home.Utils.Types.User
{
    internal class Member : IUser
    {
        public int ID { get; }
        public Role Role { get; }

        public Member(int id)
        {
            ID = id;
            Role = Role.Member;
        }
    }
}
