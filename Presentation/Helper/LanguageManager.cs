using DAL.DbConnection;

namespace Presentation.Helper
{
    public class LanguageManager
    {
        private readonly Context _db;
        public LanguageManager(Context db)
        {
            _db = db;
        }
        public string GetResource(string culture, string key)
        {
            var resource = _db.Languages.FirstOrDefault(r => r.Culture == culture && r.ResourceKey == key);

            return resource?.ResourceValue ?? key;
        }
    }
}
