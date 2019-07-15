using FluentValidator;

namespace ModernStore.Domain.ValueObjects
{
    public class Password : Notifiable
    {
        public string Value { get; protected set; }

        protected Password() { }

        public Password(string value)
        {
            Value = value;

            new ValidationContract<Password>(this)
                .IsRequired(x => x.Value, "Password is required")
                .HasMinLenght(x => x.Value, 8);
        }
    }
}