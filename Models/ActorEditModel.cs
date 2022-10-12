namespace csharp_boolflix.Models
{
    public class ActorEditModel
    {
        public ActorEditModel()
        {
            Actor = new Actor();
            Actors = new List<Actor>();
        }

        public List<Actor> Actors { get; set; }
        public Actor Actor { get; set; }
    }
}
