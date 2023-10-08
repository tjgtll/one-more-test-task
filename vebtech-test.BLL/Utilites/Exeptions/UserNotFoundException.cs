namespace vebtech_test.BLL.Utilites.Exeptions
{

    public class UserNotFoundException : Exception
    {
        public Guid UserId { get; }

        public UserNotFoundException()
        {
        }

        public UserNotFoundException(Guid userId)
        {
            UserId = userId;
        }
        public UserNotFoundException(string message)
            : base(message)
        {
        }

        public UserNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
