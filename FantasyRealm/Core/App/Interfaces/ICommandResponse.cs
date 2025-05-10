

namespace Core.App.Interfaces
{
    public interface ICommandResponse
    {
        public bool IsSuccessful { get; }

        public string? Message { get; }
    }
}
