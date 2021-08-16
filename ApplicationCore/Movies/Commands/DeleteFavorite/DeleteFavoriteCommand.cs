using MediatR;
using System.Threading.Tasks;

namespace ApplicationCore.Movies.Commands.DeleteFavorite
{
    public class DeleteFavoriteCommand : IRequest<Task>
    {
        public int Id { get; set; }

        public DeleteFavoriteCommand(int id)
        {
            Id = id;
        }
    }
}
