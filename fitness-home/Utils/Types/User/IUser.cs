using fitness_home.Services.Types;

namespace fitness_home.Utils.Types
{
    internal interface IUser
    {
        int ID { get; }
        Role Role { get; }
    }
}
