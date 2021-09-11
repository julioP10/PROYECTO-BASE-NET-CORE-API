namespace Infraestructure.Crosscutting
{
    public class ResourcesNames
    {
        public class Label
        {
            public const string Usuario = "UsuarioLabel";
            public const string Password = "PasswordLabel";
        }

        public class Validation
        {
            public const string UserNameUnique = "UserNameUnique";
            public const string NameUnique = "NameUnique";
            public const string DuplicatedKeyRowError = "DuplicatedKeyRowError";
            public const string ConstraintCheckViolation = "ConstraintCheckViolation";
            public const string UniqueConstraintError = "UniqueConstraintError";
            public const string InvalidCredentials = "InvalidCredentials";
            public const string UserDisabled = "UserDisabled";
            public const string DniUnique = "DniUnique";
        }
    }
}