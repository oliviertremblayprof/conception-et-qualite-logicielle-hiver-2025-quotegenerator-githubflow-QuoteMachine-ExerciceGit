using QuoteMachine_ExerciceGit;

namespace QuoteMachineTests
{
    public class QuoteManagerTest
    {
        private readonly QuoteManager _manager;

        public QuoteManagerTest()
        {
            _manager = new QuoteManager();
        }

        //[Fact]
        //public void GetRandomQuote_ShouldReturnNonNullQuote()
        //{
        //    var quote = _manager.GetRandomQuote();
        //    Assert.NotNull(quote);
        //    Assert.IsType<Quote>(quote);
        //}

        //[Fact]
        //public void AddQuote_ShouldIncreaseQuoteCount()
        //{
        //    int countBefore = _manager.GetAllQuotes().Count;
        //    _manager.AddQuote("Test", "Moi");
        //    int countAfter = _manager.GetAllQuotes().Count;
        //    Assert.Equal(++countBefore, countAfter);
        //}

        //[Fact]
        //public void SaveToFile_ShouldCreateFile()
        //{
        //    var path = "test_quotes.csv";
        //    _manager.SaveToCSVFile(path);
        //    Assert.True(File.Exists(path));
        //    File.Delete(path);
        //}

        //[Fact]
        //public void SaveToFile_ShouldThrowIfNotInCSVExtension()
        //{
        //    var path = "fichier-invalide.txt"; // nom invalide

        //    var ex = Assert.Throws<QuoteFileException>(() => _manager.SaveToCSVFile(path));
        //    Assert.Contains("Erreur lors de la sauvegarde : le fichier doit avoir l'extension .csv", ex.Message);
        //}

        [Fact]
        public void LoadFromFile_ShouldAppendQuotesToList()
        {
            var path = "test_quotes.csv";
            File.WriteAllLines(path, new[]
            {
            "Le test est la preuve,Professeur X"
            });

            _manager.LoadFromCSVFile(path);
            var allQuotes = _manager.GetAllQuotes();

            Assert.Equal("Le test est la preuve", allQuotes.LastOrDefault(new Quote()).Text);
            Assert.Equal("Professeur X", allQuotes.LastOrDefault(new Quote()).Author);

            File.Delete(path);
        }

        [Fact]
        public void LoadFromFile_ShouldThrowIfFileMissing()
        {
            var path = "fichier_inexistant.csv";

            var ex = Assert.Throws<QuoteFileException>(() => _manager.LoadFromCSVFile(path));
            Assert.Contains("Erreur lors du chargement : le fichier n'existe pas", ex.Message);
        }

        [Fact]
        public void LoadFromFile_ShouldThrowIfNotInCSVExtension()
        {
            var path = "fichier_non_csv.txt";
            File.WriteAllLines(path, new[] { "" });

            var ex = Assert.Throws<QuoteFileException>(() => _manager.LoadFromCSVFile(path));
            Assert.Contains("Erreur lors de la sauvegarde : le fichier doit avoir l'extension .csv", ex.Message);

            File.Delete(path);
        }
    }
}