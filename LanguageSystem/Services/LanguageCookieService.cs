﻿using LanguageSystem.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using LanguageSystem.ExtensionMethods;
namespace LanguageSystem.Services
{
    public class LanguageCookieService : ILanguageCookieService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LanguageCookieService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Language Get(string key)
        {
            return _httpContextAccessor.HttpContext.Request.Cookies.Get<Language>(key);
        }


        public void Set(string key, object value, int? expireTime)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Set(key, value, expireTime);
        }

        public void Remove(string key)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Remove(key);
        }
    }
}
