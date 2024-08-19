using Bussiness.Manager;
using Microsoft.AspNetCore.Localization;

namespace Presentation.Helper
{
    public class LanguageService
    {
        private readonly LanguageManager _localizationService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LanguageService(LanguageManager localizationService, IHttpContextAccessor httpContextAccessor)
        {
            _localizationService = localizationService;
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetKey(string key)
        {
            var culture = _httpContextAccessor.HttpContext.Features.Get<IRequestCultureFeature>()?.RequestCulture.Culture.Name ?? "az-AZ";
            return _localizationService.GetResource(culture, key);
        }
    }
}
