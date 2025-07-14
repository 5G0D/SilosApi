using Microsoft.EntityFrameworkCore;
using SilosApi.DbContexts;
using SilosApi.Dto;
using SilosApi.Entities;

namespace SilosApi.Repositories;

public class SilosRepository(SilosDbContext context) : ISilosRepository
{
    public async Task<IEnumerable<Silos>> GetAllAsync(SilosFilterDto? silosFilterDto)
    {
        var query = context.Silos.AsQueryable();

        if (silosFilterDto != null)
        {
            query = ApplyFilters(query, silosFilterDto);
        }
        
        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<Silos?> GetByIdAsync(int id)
    {
        return await context.Silos.FindAsync(id);
    }

    public async Task<Silos> CreateAsync(Silos silos)
    {
        context.Silos.Add(silos);
        await context.SaveChangesAsync();
        return silos;
    }

    public async Task<bool> UpdateAsync(Silos silos)
    {
        context.Entry(silos).State = EntityState.Modified;
        try
        {
            return await context.SaveChangesAsync() > 0;
        }
        catch (DbUpdateConcurrencyException)
        {
            return false;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var silos = await context.Silos.FindAsync(id);
        
        if (silos == null)
        {
            return false;
        }

        context.Silos.Remove(silos);
        return await context.SaveChangesAsync() > 0;
    }

    private IQueryable<Silos> ApplyFilters(IQueryable<Silos> query, SilosFilterDto filter)
    {
        // Фильтрация по текстовым полям
        if (!string.IsNullOrEmpty(filter.Name))
            query = query.Where(s => s.Name.Contains(filter.Name));
        
        if (!string.IsNullOrEmpty(filter.Culture))
            query = query.Where(s => s.Culture.Contains(filter.Culture));

        // Фильтрация по числовым диапазонам
        query = ApplyNumericFilters(query, filter);

        // Фильтрация по датам
        query = ApplyDateFilters(query, filter);
        
        return query;
    }

    private IQueryable<Silos> ApplyNumericFilters(IQueryable<Silos> query, SilosFilterDto filter)
    {
        // Горчак
        if (filter.GorchakFrom.HasValue)
            query = query.Where(s => s.Gorchak >= filter.GorchakFrom);
        if (filter.GorchakTo.HasValue)
            query = query.Where(s => s.Gorchak <= filter.GorchakTo);

        // Белок
        if (filter.ProteinFrom.HasValue)
            query = query.Where(s => s.Protein >= filter.ProteinFrom);
        if (filter.ProteinTo.HasValue)
            query = query.Where(s => s.Protein <= filter.ProteinTo);

        // Клоп
        if (filter.BugFrom.HasValue)
            query = query.Where(s => s.Bug >= filter.BugFrom);
        if (filter.BugTo.HasValue)
            query = query.Where(s => s.Bug <= filter.BugTo);

        // Сорные растения
        if (filter.SornayaFrom.HasValue)
            query = query.Where(s => s.Sornaya >= filter.SornayaFrom);
        if (filter.SornayaTo.HasValue)
            query = query.Where(s => s.Sornaya <= filter.SornayaTo);

        // Зерновые
        if (filter.ZernovayaFrom.HasValue)
            query = query.Where(s => s.Zernovaya >= filter.ZernovayaFrom);
        if (filter.ZernovayaTo.HasValue)
            query = query.Where(s => s.Zernovaya <= filter.ZernovayaTo);

        // IDK
        if (filter.IdkFrom.HasValue)
            query = query.Where(s => s.Idk >= filter.IdkFrom);
        if (filter.IdkTo.HasValue)
            query = query.Where(s => s.Idk <= filter.IdkTo);

        // Натура
        if (filter.NatureFrom.HasValue)
            query = query.Where(s => s.Nature >= filter.NatureFrom);
        if (filter.NatureTo.HasValue)
            query = query.Where(s => s.Nature <= filter.NatureTo);

        // Влажность
        if (filter.HumidityFrom.HasValue)
            query = query.Where(s => s.Humidity >= filter.HumidityFrom);
        if (filter.HumidityTo.HasValue)
            query = query.Where(s => s.Humidity <= filter.HumidityTo);

        // Класс
        if (filter.ClassFrom.HasValue)
            query = query.Where(s => s.Class >= filter.ClassFrom);
        if (filter.ClassTo.HasValue)
            query = query.Where(s => s.Class <= filter.ClassTo);

        // Клейковина
        if (filter.GlutenFrom.HasValue)
            query = query.Where(s => s.Gluten >= filter.GlutenFrom);
        if (filter.GlutenTo.HasValue)
            query = query.Where(s => s.Gluten <= filter.GlutenTo);

        // Полнота зерна
        if (filter.FullnessFrom.HasValue)
            query = query.Where(s => s.Fullness >= filter.FullnessFrom);
        if (filter.FullnessTo.HasValue)
            query = query.Where(s => s.Fullness <= filter.FullnessTo);

        // Общая вместимость
        if (filter.TotalFootageFrom.HasValue)
            query = query.Where(s => s.TotalFootage >= filter.TotalFootageFrom);
        if (filter.TotalFootageTo.HasValue)
            query = query.Where(s => s.TotalFootage <= filter.TotalFootageTo);

        // Свободная вместимость
        if (filter.FreeFootageFrom.HasValue)
            query = query.Where(s => s.FreeFootage >= filter.FreeFootageFrom);
        if (filter.FreeFootageTo.HasValue)
            query = query.Where(s => s.FreeFootage <= filter.FreeFootageTo);
        
        return query;
    }

    private IQueryable<Silos> ApplyDateFilters(IQueryable<Silos> query, SilosFilterDto filter)
    {
        // Дата начала хранения
        if (filter.StartDateFrom.HasValue)
            query = query.Where(s => s.StartDate >= filter.StartDateFrom);
        if (filter.StartDateTo.HasValue)
            query = query.Where(s => s.StartDate <= filter.StartDateTo);
        
        // Год Урожая
        if (filter.HarvestYearFrom.HasValue)
            query = query.Where(s => s.HarvestYear >= filter.HarvestYearFrom);
        if (filter.HarvestYearTo.HasValue)
            query = query.Where(s => s.HarvestYear <= filter.HarvestYearTo);

        return query;
    }
}