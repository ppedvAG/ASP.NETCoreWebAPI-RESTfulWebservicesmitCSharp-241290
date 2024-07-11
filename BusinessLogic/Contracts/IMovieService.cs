using BusinessLogic.Models;

namespace BusinessLogic.Contracts
{
    public interface IMovieService
    {
        void AddMovie(Movie movie);
        void DeleteMovie(int id);
        Movie GetMovie(int id);
        IList<Movie> GetMovies();
        void UpdateMove(Movie movie);
    }
}