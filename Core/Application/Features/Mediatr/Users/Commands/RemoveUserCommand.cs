using MediatR;

namespace Application.Features.Mediatr.Users.Commands
{
    public class RemoveUsercommand:IRequest
    {
        public int Id { get; set; }

        public RemoveUsercommand(int ıd)
        {
            Id = ıd;
        }
    }
}
