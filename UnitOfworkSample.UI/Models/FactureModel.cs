namespace UnitOfworkSample.UI.Models
{
    public class FactureModel
    {
        private int _id;
        private string _numFacture;
        private double _montant;
        private int _idClient;

        public int Id { get => _id; set => _id = value; }
        public string NumFacture { get => _numFacture; set => _numFacture = value; }
        public double Montant { get => _montant; set => _montant = value; }
        public int IdClient { get => _idClient; set => _idClient = value; }
    }
}
