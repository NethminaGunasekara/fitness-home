namespace fitness_home.Utils.Types
{
    public enum Role
    {
        Administrator,
        Trainer,
        Member,
    }

    public enum Gender
    {
        Male,
        Female,
    }

    public enum LoginStatus
    {
        Success,
        InvalidEmail,
        InvalidPassword,
        DatabaseError,
    }

    public enum InputState
    {
        Valid,
        Invalid,
        Initial, // Initial value (placeholder)
    }
}