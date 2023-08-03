namespace BookService.Data
{
    public class ConectionsStrings
    {

        public const string NpgSqlKey = "npgSqlConectionsString";
        private static string _npgSql;
        public static string NpgSql { get { return _npgSql ?? throw new ArgumentNullException("NpgSql", "Error gettng conecion string to NpgSql because paremeter is null"); } }
        public ConectionsStrings(string npgSql)
        {
            _npgSql = npgSql ?? throw new ArgumentNullException(nameof(npgSql), "Error Initialize conection string to NpgSql");
        }
    }
}
