namespace BusinessLogic.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public MovieType Genre { get; set; }
    }

    public enum MovieType 
    { 
        Action, 
        Thriller, 
        Comedy, 
        Drama, 
        Animation, 
        Docu 
    }

}
