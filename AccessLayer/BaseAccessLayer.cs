using Microsoft.EntityFrameworkCore;
using ProjetZORK.DataAccessLayer;
using ProjetZORK.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;



public abstract class BaseAccessLayer<TModel>
        where TModel : BaseDataObject
{
    /// <summary>
    ///     Gets the Db context.
    /// </summary>
    private readonly ZorkManagerDbContext context;

    /// <summary>
    ///     Gets the Db model set.
    /// </summary>
    protected readonly DbSet<TModel> modelSet;

    /// <summary>
    ///     Initializes a new instance of the <see cref="BaseAccessLayer{TModel}" /> class.
    /// </summary>
    /// <param name="context">The context.</param>
    protected BaseAccessLayer(ZorkManagerDbContext context)
    {
        this.context = context;
        this.modelSet = this.context.Set<TModel>();
    }

    /// <summary>
    ///     Async Method that add new object in Db.
    /// </summary>
    /// <param name="model">Object model to add</param>
    /// <returns>Returns the Id of newly created object.</returns>
    public async Task<TModel> AddAsync(TModel model)
    {
        var result = this.modelSet.Add(model);
        await this.context.SaveChangesAsync().ConfigureAwait(false);

        return result.Entity;
    }

    /// <summary>
    ///     Method that retrieve a collection of data according to the filter.
    /// </summary>
    /// <remarks>
    ///     Tracking on data returned is disabled by default. 
    /// </remarks>
    /// <param name="filter">Expression to filter data to return.</param>
    /// <param name="trackingEnabled">true if tracking is needed on data returned, false otherwise.</param>
    /// <returns>Returns Enumerable of <typeparamref name="TModel" />.</returns>
    public virtual IEnumerable<TModel> GetCollection(Expression<Func<TModel, bool>> filter = null, bool trackingEnabled = false)
    {
        var dbQuery = this.modelSet.AsQueryable();

        var filterToApply =
            filter == null
            ? x => true
            : filter;

        var collection = trackingEnabled
                        ? dbQuery.Where(filterToApply)
                        : dbQuery.AsNoTracking().Where(filterToApply);

        return collection;
    }

    /// <summary>
    ///     Async Method that retrieve first data object matching the given filter.
    /// </summary>
    /// <remarks>
    ///     Tracking on data returned is disabled by default.
    /// </remarks>
    /// <param name="filter">filter to apply</param>
    /// <param name="trackingEnabled">true if tracking is needed on data returned, false otherwise.</param>
    /// <returns>Returns <typeparamref name="TModel" />.</returns>
    public virtual TModel GetSingle(Expression<Func<TModel, bool>> filter, bool trackingEnabled = false)
    {
        var dbQuery = this.modelSet.AsQueryable();

        var item = trackingEnabled
                        ? dbQuery.FirstOrDefault(filter)
                        : dbQuery.AsNoTracking().FirstOrDefault(filter);
        return item;
    }
    public virtual async Task<TModel> GetSingleAsync(Expression<Func<TModel, bool>> filter, bool trackingEnabled = false)
    {
        var dbQuery = this.modelSet.AsQueryable();

        var item = trackingEnabled
                        ? await dbQuery.FirstOrDefaultAsync(filter)
                        : await dbQuery.AsNoTracking().FirstOrDefaultAsync(filter);

        return item;
    }
    /// <summary>
    ///     Async method that update a specific data object.
    /// </summary>
    /// <param name="model">The object data model to update.</param>
    /// <returns>Returns number of state entries written to the database.</returns>
    public async Task<TModel> UpdateAsync(TModel model)
    {
        //this.context.Entry(await this.modelSet.FirstOrDefaultAsync(x => x.Id == model.Id)).CurrentValues.SetValues(model);
        using (var db = new ZorkManagerDbContext())
        {
            context.Entry(model).CurrentValues.SetValues(model);
            context.SaveChanges();
            return model;
        }
        
        /*this.modelSet.Update(model);
        await this.context.SaveChangesAsync().ConfigureAwait(false); //Problem Dispose context
        return model;*/
    }

    /// <summary>
    ///     Removes an object by its Id
    /// </summary>
    /// <param name="id">if of object to remove</param>
    /// <returns>Returns number of state entries written to the database.</returns>
    public async Task<int> RemoveAsync(int id)
    {
        this.modelSet.Remove(this.modelSet.FirstOrDefault(model => model.Id == id));
        return await this.context.SaveChangesAsync().ConfigureAwait(false);
    }
}