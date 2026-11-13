using Chantin.Domain.Models;

namespace Chantin.Application.Interfaces.Common;

/// <summary>
/// Generic repository interface for CRUD operations on domain entities.
/// Follows the Repository Pattern to abstract data access logic.
/// </summary>
/// <typeparam name="TEntity">The domain entity type.</typeparam>
/// <typeparam name="TId">The type of the entity identifier.</typeparam>
public interface IRepository<TEntity> where TEntity : class
{
	/// <summary>
	/// Retrieves an entity by its identifier.
	/// </summary>
	/// <param name="id">The entity identifier.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The entity if found, null otherwise.</returns>
	Task<ResultModel<TEntity>> GetByIdAsync(int id, string token);
	/// <summary>
	/// Retrieves all entities of the specified type.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>List of all entities.</returns>
	Task<ResultsModel<TEntity>> GetAllAsync(TEntity? filter, int? page, int? records, string token);
	/// <summary>
	/// Adds a new entity to the repository.
	/// </summary>
	/// <param name="entity">The entity to add.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The added entity with generated ID.</returns>
	Task<ResultModel<TEntity>> AddAsync(TEntity entity, string token);
	/// <summary>
	/// Updates an existing entity in the repository.
	/// </summary>
	/// <param name="entity">The entity to update.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The updated entity.</returns>
	Task<ResultModel<TEntity>> UpdateAsync(TEntity entity, string token);
	/// <summary>
	/// Removes an entity from the repository (soft delete by deactivating).
	/// </summary>
	/// <param name="entity">The entity to remove.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	Task<ResultModel<TEntity>> RemoveAsync(TEntity entity, string token);
	/// <summary>
	/// Permanently deletes an entity from the repository.
	/// Use with caution - this bypasses soft delete.
	/// </summary>
	/// <param name="id">The entity identifier.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	Task HardDeleteAsync(int id, CancellationToken cancellationToken = default);

	/// <summary>
	/// Checks if an entity exists by its identifier.
	/// </summary>
	/// <param name="id">The entity identifier.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>True if the entity exists, false otherwise.</returns>
	Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default);

	/// <summary>
	/// Counts the total number of entities.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>The total count of entities.</returns>
	Task<int> CountAsync(CancellationToken cancellationToken = default);
}