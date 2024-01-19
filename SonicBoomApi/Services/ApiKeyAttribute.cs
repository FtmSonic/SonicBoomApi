using Microsoft.AspNetCore.Mvc;

namespace SonicBoomApi.Services
{
    public class ApiKeyAttribute : ServiceFilterAttribute
    {
        public ApiKeyAttribute()
            : base(typeof(ApiKeyAuthFilter))
        {
        }
    }
}
