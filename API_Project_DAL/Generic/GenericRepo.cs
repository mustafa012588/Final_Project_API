﻿
//using API_Project_DAL.Context;
//using Microsoft.EntityFrameworkCore;

//namespace API_Project_DAL.Generic;

//public class GenericRepository<T> : IGenericRepo<T> where T : class
//{
//    protected readonly BugsContext _context;
//    protected readonly DbSet<T> _dbSet;

//    public GenericRepository(BugsContext context)
//    {
//        _context = context;
//        _dbSet = _context.Set<T>();
//    }

//    public async Task<T> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);

//    public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

//    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

//    public void Update(T entity) => _dbSet.Update(entity);

//    public void Delete(T entity) => _dbSet.Remove(entity);

//}
