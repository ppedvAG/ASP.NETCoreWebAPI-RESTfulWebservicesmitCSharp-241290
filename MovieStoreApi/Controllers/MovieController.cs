using BusinessLogic.Contracts;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace M004_MovieDbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _service;

        public MovieController(IMovieService service)
        {
            _service = service;
        }

        // GET: api/<MovieController>
        [HttpGet]
        [Route("all")]
        public IList<Movie> GetMovies()
                => _service.GetMovies();

        // GET api/<MovieController>/5
        [HttpGet]
        [Route("find/{id:int:min(1)}")]
        public Movie GetById(int id)
                => _service.GetMovie(id);

        // POST api/<MovieController>
        [HttpPost]
        [Route("create")]
        public void AddMovie(Movie movie)
            => _service.AddMovie(movie);

        // PUT api/<MovieController>/5
        [HttpPut]
        [Route("update/{id:int:min(1)}")]
        public void UpdateMovie(int id, Movie movie)
        {
            if (id != movie.Id)
                throw new ArgumentException();

            _service.UpdateMove(movie);
        }

        // DELETE api/<MovieController>/5
        [HttpDelete]
        [Route("delete/{id:int:min(1)}")]
        public void DeleteMovie(int id)
            => _service.DeleteMovie(id);
    }
}
