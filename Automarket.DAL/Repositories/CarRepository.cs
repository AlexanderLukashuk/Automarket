using System;
using Automarket.DAL.Interfaces;
using Automarket.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Automarket.DAL.Repositories
{
	public class CarRepository : IBaseRepository<Car>
	{
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Car entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Car entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Car> GetAll()
        {
            return _context.Cars;
        }

        public async Task<Car> Update(Car entity)
        {
            _context.Cars.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        //public async Task<bool> Create(Car entity)
        //{
        //    await _context.Cars.AddAsync(entity);
        //    await _context.SaveChangesAsync();

        //    return true;
        //}

        //public async Task<bool> Delete(Car entity)
        //{
        //    _context.Remove(entity);
        //    await _context.SaveChangesAsync();

        //    return true;
        //}

        //public async Task<Car> Get(int id)
        //{
        //    return await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
        //}

        //public IQueryable<Car> GetAll()
        //{
        //    return _context.Cars;
        //}

        //public async Task<Car> GetByName(string name)
        //{
        //    return await _context.Cars.FirstOrDefaultAsync(c => string.Equals(c.Name, name));
        //}

        //public async Task<List<Car>> Select()
        //{
        //    return await _context.Cars.ToListAsync();
        //}

        //public async Task<Car> Update(Car entity)
        //{
        //    _context.Cars.Update(entity);
        //    await _context.SaveChangesAsync();

        //    return entity;
        //}
    }
}

