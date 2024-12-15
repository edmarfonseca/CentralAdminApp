namespace CentralAdminApp.Domain.Helpers
{
    public class GenerateIdHelper
    {
        public static int NewIdFromGuid()
        {
            Guid guid = Guid.NewGuid();
            int hash = guid.GetHashCode();
            return Math.Abs(hash);
        }
    }
}