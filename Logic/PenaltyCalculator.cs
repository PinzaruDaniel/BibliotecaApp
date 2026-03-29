namespace BibliotecaApp.Logic
{
    /// <summary>
    /// Clasa OOP pentru calculul penalităților de întârziere la returnarea cărților.
    /// Implementează logica de afaceri separată de interfața grafică (principiu SoC).
    /// </summary>
    public class PenaltyCalculator
    {
        // Tariful implicit per zi de întârziere (USD)
        public const decimal DEFAULT_RATE_PER_DAY = 0.50m;

        /// <summary>Tariful configurabil per zi de întârziere.</summary>
        public decimal RatePerDay { get; set; }

        public PenaltyCalculator(decimal ratePerDay = DEFAULT_RATE_PER_DAY)
        {
            RatePerDay = ratePerDay;
        }

        /// <summary>
        /// Calculează numărul de zile de întârziere față de data curentă sau data returnării reale.
        /// </summary>
        /// <param name="dataReturnareEstimata">Data limită de returnare.</param>
        /// <param name="dataReturnareReala">Data efectivă de returnare (null = nereturnată încă).</param>
        /// <returns>Numărul de zile de întârziere (0 dacă nu există întârziere).</returns>
        public int CalculeazaZileIntarziere(DateTime dataReturnareEstimata, DateTime? dataReturnareReala = null)
        {
            DateTime dataReferinta = dataReturnareReala?.Date ?? DateTime.Today;
            int zile = (dataReferinta - dataReturnareEstimata.Date).Days;
            return Math.Max(0, zile);
        }

        /// <summary>
        /// Calculează penalitatea totală în USD.
        /// </summary>
        public decimal CalculeazaPenalitate(DateTime dataReturnareEstimata, DateTime? dataReturnareReala = null, decimal? tarifCustom = null)
        {
            int zile = CalculeazaZileIntarziere(dataReturnareEstimata, dataReturnareReala);
            decimal tarif = tarifCustom ?? RatePerDay;
            return zile * tarif;
        }

        /// <summary>
        /// Generează un raport complet de penalitate pentru un împrumut.
        /// </summary>
        public PenaltyReport GenereazaRaport(
            string numeCititor,
            string titluCarte,
            DateTime dataImprumut,
            DateTime dataReturnareEstimata,
            DateTime? dataReturnareReala,
            bool returnat,
            decimal tarifPerZi)
        {
            int zileIntarziere = CalculeazaZileIntarziere(dataReturnareEstimata, dataReturnareReala);
            decimal penalitate = zileIntarziere * tarifPerZi;
            string status = returnat
                ? (zileIntarziere > 0 ? "Returnat cu întârziere" : "Returnat la timp")
                : (zileIntarziere > 0 ? "NERETURNATĂ - Întârziere activă" : "În termen");

            return new PenaltyReport
            {
                NumeCititor           = numeCititor,
                TitluCarte            = titluCarte,
                DataImprumut          = dataImprumut,
                DataReturnareEstimata = dataReturnareEstimata,
                DataReturnareReala    = dataReturnareReala,
                ZileIntarziere        = zileIntarziere,
                TarifPerZi            = tarifPerZi,
                PenalitateTotala      = penalitate,
                StatusImprumut        = status,
                Returnat              = returnat
            };
        }
    }

    /// <summary>Structura de date pentru raportul de penalitate.</summary>
    public class PenaltyReport
    {
        public string NumeCititor           { get; set; } = "";
        public string TitluCarte            { get; set; } = "";
        public DateTime DataImprumut        { get; set; }
        public DateTime DataReturnareEstimata { get; set; }
        public DateTime? DataReturnareReala { get; set; }
        public int ZileIntarziere           { get; set; }
        public decimal TarifPerZi           { get; set; }
        public decimal PenalitateTotala     { get; set; }
        public string StatusImprumut        { get; set; } = "";
        public bool Returnat                { get; set; }

        public bool AreIntarziere => ZileIntarziere > 0;

        public override string ToString() =>
            $"Cititor: {NumeCititor} | Carte: {TitluCarte} | " +
            $"Zile întârziere: {ZileIntarziere} | Penalitate: ${PenalitateTotala:F2} | Status: {StatusImprumut}";
    }
}
