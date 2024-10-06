namespace fitness_home.Utils.Types.User
{
    internal class Admin: IUser
    {
        public int ID { get; }
        public Role Role { get; }

        public Admin(int id)
        {
            ID = id;
            Role = Role.Member;
        }
    }
}
