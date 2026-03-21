namespace Ascend_Forum.Core.Common
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(object identifier, string entityName)
            : base($"{entityName} with id {identifier} was not found")
        {
        }
    }
}
