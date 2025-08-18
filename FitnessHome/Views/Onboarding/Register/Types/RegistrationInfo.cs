using fitness_home.Utils;
using fitness_home.Utils.Types;
using System;

namespace fitness_home.Views.Onboarding.Register.Types
{
    public class RegistrationInfo
    {
        // -- User Info --
        public string FirstName;
        public string LastName;
        public DateTime DOB;
        public string NIC;
        public Gender Gender;
        public string Email;
        public string Phone;
        public string Address;
        public string Password;
        public string ECName; // Emergency contact name
        public string ECPhone;// Emergency contact phone

        // -- Membership Info --
        public MembershipPlanDetails MembershipPlan;

        // -- Payment Info --
        public PaymentMethod PaymentMethod;
        public decimal Amount;
        public PaymentMethod CardType; // Card info isn't required for cash payments
        public string Cardholder;
        public string CardNumber;
        public string ExpiryDate;
        public string CVC;

        public RegistrationInfo(string firstName, string lastName, DateTime dob, string nic, Gender gender, string email, string phone, string address, string password, string ecName, string ecPhone)
        {
            FirstName = firstName;
            LastName = lastName;
            DOB = dob;
            // Set NIC to null if it still holds the placeholder value (When no NIC is provided)
            NIC = nic == Placeholder.placeholders["textBox_nic"] ? null : nic;
            Gender = gender;
            Email = email;
            Phone = phone;
            Address = address;
            Password = password;
            ECName = ecName;
            ECPhone = ecPhone;
        }
    }

    public enum PaymentMethod
    {
        VISA,
        MasterCard,
        Cash,
    }
}
