using System.ComponentModel;

namespace OnionArcExample.Domain
{
    public class Role
    {
        public const string Admin = "Admin";
        public const string EditorQTNS = "EditorQTNS";
        public const string EditorQTDA = "EditorQTDA";
        public const string Viewer = "Viewer";
    }
    public enum RoleEnum
    {
        [Description(Role.Admin)]
        Admin = 1,

        [Description(Role.EditorQTNS)]
        EditorQTNS = 2,

        [Description(Role.EditorQTDA)]
        EditorQTDA = 3,

        [Description(Role.Viewer)]
        Viewer = 4

    }
}
