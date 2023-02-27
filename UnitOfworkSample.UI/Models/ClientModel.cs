namespace UnitOfworkSample.UI.Models
{
    public class ClientModel
    {
        private int _id;
        private string _nom;
        private string _prenom;

        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
    }
}
