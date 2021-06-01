﻿using CompanyAPI.Data;
using CompanyAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAPI.Repositories
{
    public class Repo<T> : IRepo<T> where T : class
    {
        private readonly CompanyContext db;

        public Repo(CompanyContext injectedContext)
        {
            db = injectedContext;
        }

        public async Task<List<T>> GetAll()
        {
            return await db.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id, int second_id = 0)
        {
            if (second_id == 0)
                return await db.Set<T>().FindAsync(id);
            else
                return await db.Set<T>().FindAsync(id, second_id);
        }

        public async Task<int> Edit(T editedEntity)
        {
            db.Entry(editedEntity).State = EntityState.Modified;
            try
            {
                return await db.SaveChangesAsync();
            }
            catch
            {
                return -1;
            }
        }

        public async Task<int> Add(T addedEntity)
        {
            db.Set<T>().Add(addedEntity);
            return await db.SaveChangesAsync();
        }

        public async Task<int> Remove(T removedEntity)
        {
            db.Set<T>().Remove(removedEntity);
            return await db.SaveChangesAsync();
        }

        public bool EntityExists(int id, int second_id = 0)
        {
            if (second_id == 0)
                return db.Set<T>().Find(id) != null;
            else
                return db.Set<T>().Find(id, second_id) != null;
        }
    }
}
