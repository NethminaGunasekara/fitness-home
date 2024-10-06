using fitness_home.Views.Dashboard;
using fitness_home.Views.Onboarding.Register;

namespace fitness_home.Services
{
    internal class FormProvider
    {
        // Onboarding Views: Login
        public static Welcome Welcome;
        public static Login Login;

        // Onboarding Views: Registration
        public static Register Register;
        public static Membership Membership;
        public static Payment Payment;

        // User Dashboards
        public static MemberDashboard MemberDashboard;
    }
}
