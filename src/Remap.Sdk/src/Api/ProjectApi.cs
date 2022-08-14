using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the project endpoint.
    /// </summary>
    public class ProjectApi : ApiAccessor
    {
        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ProjectApi" /> class
        /// with the HTTP client and the MoySklad credentials.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="credentials">The MoySklad credentials.</param>
        public ProjectApi(HttpClient httpClient, MoySkladCredentials credentials)
            : base("/api/remap/1.2/entity/project", httpClient, credentials)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the projects.
        /// </summary>
        /// <param name="query">The query builder.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="EntitiesResponse{Project}"/>.</returns>
        public virtual Task<ApiResponse<EntitiesResponse<Project>>> GetAllAsync(ApiParameterBuilder query = null) => GetAsync<EntitiesResponse<Project>>(query);

        /// <summary>
        /// Gets the project.
        /// </summary>
        /// <param name="id">The id to get the entity.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Project"/>.</returns>
        public virtual Task<ApiResponse<Project>> GetAsync(Guid id) => GetByIdAsync<Project>(id);

        /// <summary>
        /// Creates the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Project"/>.</returns>
        public virtual Task<ApiResponse<Project>> CreateAsync(Project project) => CreateAsync<Project>(project);

        /// <summary>
        /// Updates the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>The <see cref="Task"/> containing the API response with <see cref="Project"/>.</returns>
        public virtual Task<ApiResponse<Project>> UpdateAsync(Project project) => UpdateAsync<Project>(project);

        /// <summary>
        /// Deletes the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        public virtual Task<ApiResponse> DeleteAsync(Project project) => DeleteAsync<Project>(project);

        /// <summary>
        /// Deletes the project by ID.
        /// </summary>
        /// <param name="id">The project ID.</param>
        /// <returns>The <see cref="Task"/> containing the API response.</returns>
        public virtual Task<ApiResponse> DeleteAsync(Guid id) => DeleteByIdAsync(id);

        #endregion
    }
}