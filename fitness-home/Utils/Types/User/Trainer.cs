using fitness_home.Services.Types;

namespace fitness_home.Utils.Types.User
{
    internal class Trainer: IUser
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
