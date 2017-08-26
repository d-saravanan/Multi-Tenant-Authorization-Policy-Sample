namespace MT.Framework.Core.Authorization.AuthRequirements
{
    public partial class Operations
    {
        public static string CreateOperation => "Create";
        public static string ViewOperation => "View";
        public static string UpdateOperation => "Update";
        public static string DeleteOperation => "Delete";
        public static string SearchOperation => "Search";
        public static string ApproveOperation => "Approve";
    }

    public enum OperationType : int
    {
        View = 0,
        Create,
        Update,
        Search,
        Delete,
        Approve
    }
}
