using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the task endpoint.
    /// </summary>
    public class TaskApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="TaskApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public TaskApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/task", httpClient, credentials)
        {
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Creates the task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="TaskEntity"/>.</returns>
        public virtual Task<ApiResponse<TaskEntity>> CreateAsync(TaskEntity task) => CreateAsync<TaskEntity>(task);

        /// <summary>
        /// Creates the task note.
        /// </summary>
        /// <param name="taskId">The task id.</param>
        /// <param name="taskNote">The task note.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="TaskNote"/>.</returns>
        public virtual Task<ApiResponse<TaskNote>> CreateNoteAsync(Guid taskId, TaskNote taskNote)
        {
            if (taskNote == null)
                throw new ArgumentNullException(nameof(taskNote));

            var requestContext = new RequestContext($"{Path}/{taskId.ToString()}/notes", HttpMethod.Post)
                .WithBody(taskNote);

            return CallAsync<TaskNote>(requestContext);
        }

        /// <summary>
        /// Deletes the task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        public virtual Task<ApiResponse> DeleteAsync(TaskEntity task) => DeleteAsync<TaskEntity>(task);

        /// <summary>
        /// Deletes the task.
        /// </summary>
        /// <param name="id">The task id.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        public virtual Task<ApiResponse> DeleteAsync(Guid id) => DeleteByIdAsync(id);

        /// <summary>
        /// Deletes the task note.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="taskId">The task id.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        public virtual Task<ApiResponse> DeleteNoteAsync(Guid id, Guid taskId)
        {
            var requestContext = new RequestContext($"{Path}/{taskId.ToString()}/notes/{id.ToString()}", HttpMethod.Delete);

            return CallAsync(requestContext);
        }

        /// <summary>
        /// Deletes the task note.
        /// </summary>
        /// <param name="taskId">The task id.</param>
        /// <param name="taskNote">The task note.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        public virtual Task<ApiResponse> DeleteNoteAsync(Guid taskId, TaskNote taskNote)
        {
            if (taskNote == null)
                throw new ArgumentNullException(nameof(taskNote));

            var taskNoteId = taskNote.GetId();
            if (!taskNoteId.HasValue)
                throw new InvalidOperationException("The entity id cannot be null.");

            return DeleteNoteAsync(taskNoteId.Value, taskId);
        }

        /// <summary>
        /// Gets the tasks.
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="EntitiesResponse{TaskEntity}"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<TaskEntity>>> GetAllAsync(ApiParameterBuilder query = null) => GetAsync<EntitiesResponse<TaskEntity>>(query);

        /// <summary>
        /// Gets the task by id.
        /// </summary>
        /// <param name="id">The task id.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="TaskEntity"/>.</returns>
        public virtual Task<ApiResponse<TaskEntity>> GetAsync(Guid id) => GetByIdAsync<TaskEntity>(id);

        /// <summary>
        /// Gets the task note by id and task id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="taskId">The task id.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="TaskNote"/>.</returns>
        public virtual Task<ApiResponse<TaskNote>> GetNoteAsync(Guid id, Guid taskId)
        {
            var requestContext = new RequestContext($"{Path}/{taskId.ToString()}/notes/{id.ToString()}");

            return CallAsync<TaskNote>(requestContext);
        }

        /// <summary>
        /// Gets the task notes.
        /// </summary>
        /// <param name="taskId">The task id.</param>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="EntitiesResponse{TaskNote}"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<TaskNote>>> GetNotesAsync(Guid taskId, ApiParameterBuilder query = null)
        {
            var requestContext = new RequestContext($"{Path}/{taskId.ToString()}/notes");

            if (query != null)
                requestContext.WithQuery(query.Build());

            return CallAsync<EntitiesResponse<TaskNote>>(requestContext);
        }

        /// <summary>
        /// Updates the task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="TaskEntity"/>.</returns>
        public virtual Task<ApiResponse<TaskEntity>> UpdateAsync(TaskEntity task) => UpdateAsync<TaskEntity>(task);

        /// <summary>
        /// Updates the task note.
        /// </summary>
        /// <param name="taskId">The task id.</param>
        /// <param name="taskNote">The task note.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="TaskNote"/>.</returns>
        public virtual Task<ApiResponse<TaskNote>> UpdateNoteAsync(Guid taskId, TaskNote taskNote)
        {
            if (taskNote == null)
                throw new ArgumentNullException(nameof(taskNote));

            var taskNoteId = taskNote.GetId();
            if (!taskNoteId.HasValue)
                throw new InvalidOperationException("The entity id cannot be null.");

            var requestContext = new RequestContext($"{Path}/{taskId.ToString()}/notes/{taskNoteId.ToString()}", HttpMethod.Put)
                .WithBody(taskNote);

            return CallAsync<TaskNote>(requestContext);
        }

        #endregion Methods
    }
}