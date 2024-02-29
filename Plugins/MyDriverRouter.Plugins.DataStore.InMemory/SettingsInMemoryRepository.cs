﻿using MyDriverRouter.CoreBusiness;
using MyDriverRouter.UseCases;

namespace MyDriverRouter.Plugins.DataStore.InMemory;

public class SettingsInMemoryRepository : ISettingsRepository
{

    private string _tenant;
    private IEnumerable<Language> _languages;

    public SettingsInMemoryRepository()
    {
        _tenant = "";
        _languages = new List<Language>();
    }

    public Task<IEnumerable<Language>> GetLanguagesAvaliebles(string tenant)
    {
        return Task.FromResult(_languages);
    }

    public Task<string> GetTenant()
    {
        return Task.FromResult(_tenant);
    }

    public Task SetTenant(string tenant)
    {
        _tenant = tenant;
        this.GetAllLanguagesAPI(tenant);
        return Task.CompletedTask;
    }

    private void GetAllLanguagesAPI(string tenant)
    {
        _languages = new[] {
                new Language { Description = "English" },
                new Language { Description = "Portuguese" }
            };
    }
}