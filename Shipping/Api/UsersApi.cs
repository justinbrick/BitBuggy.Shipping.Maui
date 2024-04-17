/*
 * FastAPI
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 0.1.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using BitBuggy.Shipping.Maui.Shipping.Client;
using BitBuggy.Shipping.Maui.Shipping.Model;

namespace BitBuggy.Shipping.Maui.Shipping.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IUsersApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get User Shipments
        /// </summary>
        /// <remarks>
        /// Get all the shipments for a given user.
        /// </remarks>
        /// <exception cref="BitBuggy.Shipping.Maui.Shipping.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>List&lt;Shipment&gt;</returns>
        List<Shipment> GetUserShipmentsUsersShipmentsGet(int operationIndex = 0);

        /// <summary>
        /// Get User Shipments
        /// </summary>
        /// <remarks>
        /// Get all the shipments for a given user.
        /// </remarks>
        /// <exception cref="BitBuggy.Shipping.Maui.Shipping.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of List&lt;Shipment&gt;</returns>
        ApiResponse<List<Shipment>> GetUserShipmentsUsersShipmentsGetWithHttpInfo(int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IUsersApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Get User Shipments
        /// </summary>
        /// <remarks>
        /// Get all the shipments for a given user.
        /// </remarks>
        /// <exception cref="BitBuggy.Shipping.Maui.Shipping.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;Shipment&gt;</returns>
        System.Threading.Tasks.Task<List<Shipment>> GetUserShipmentsUsersShipmentsGetAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get User Shipments
        /// </summary>
        /// <remarks>
        /// Get all the shipments for a given user.
        /// </remarks>
        /// <exception cref="BitBuggy.Shipping.Maui.Shipping.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;Shipment&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<Shipment>>> GetUserShipmentsUsersShipmentsGetWithHttpInfoAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IUsersApi : IUsersApiSync, IUsersApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class UsersApi : IUsersApi
    {
        private BitBuggy.Shipping.Maui.Shipping.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UsersApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UsersApi(string basePath)
        {
            this.Configuration = BitBuggy.Shipping.Maui.Shipping.Client.Configuration.MergeConfigurations(
                BitBuggy.Shipping.Maui.Shipping.Client.GlobalConfiguration.Instance,
                new BitBuggy.Shipping.Maui.Shipping.Client.Configuration { BasePath = basePath }
            );
            this.Client = new BitBuggy.Shipping.Maui.Shipping.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new BitBuggy.Shipping.Maui.Shipping.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = BitBuggy.Shipping.Maui.Shipping.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public UsersApi(BitBuggy.Shipping.Maui.Shipping.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = BitBuggy.Shipping.Maui.Shipping.Client.Configuration.MergeConfigurations(
                BitBuggy.Shipping.Maui.Shipping.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.Client = new BitBuggy.Shipping.Maui.Shipping.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new BitBuggy.Shipping.Maui.Shipping.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = BitBuggy.Shipping.Maui.Shipping.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public UsersApi(BitBuggy.Shipping.Maui.Shipping.Client.ISynchronousClient client, BitBuggy.Shipping.Maui.Shipping.Client.IAsynchronousClient asyncClient, BitBuggy.Shipping.Maui.Shipping.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = BitBuggy.Shipping.Maui.Shipping.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public BitBuggy.Shipping.Maui.Shipping.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public BitBuggy.Shipping.Maui.Shipping.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public BitBuggy.Shipping.Maui.Shipping.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public BitBuggy.Shipping.Maui.Shipping.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Get User Shipments Get all the shipments for a given user.
        /// </summary>
        /// <exception cref="BitBuggy.Shipping.Maui.Shipping.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>List&lt;Shipment&gt;</returns>
        public List<Shipment> GetUserShipmentsUsersShipmentsGet(int operationIndex = 0)
        {
            BitBuggy.Shipping.Maui.Shipping.Client.ApiResponse<List<Shipment>> localVarResponse = GetUserShipmentsUsersShipmentsGetWithHttpInfo();
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get User Shipments Get all the shipments for a given user.
        /// </summary>
        /// <exception cref="BitBuggy.Shipping.Maui.Shipping.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of List&lt;Shipment&gt;</returns>
        public BitBuggy.Shipping.Maui.Shipping.Client.ApiResponse<List<Shipment>> GetUserShipmentsUsersShipmentsGetWithHttpInfo(int operationIndex = 0)
        {
            BitBuggy.Shipping.Maui.Shipping.Client.RequestOptions localVarRequestOptions = new BitBuggy.Shipping.Maui.Shipping.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = BitBuggy.Shipping.Maui.Shipping.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = BitBuggy.Shipping.Maui.Shipping.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }


            localVarRequestOptions.Operation = "UsersApi.GetUserShipmentsUsersShipmentsGet";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<Shipment>>("/users/shipments", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetUserShipmentsUsersShipmentsGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get User Shipments Get all the shipments for a given user.
        /// </summary>
        /// <exception cref="BitBuggy.Shipping.Maui.Shipping.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;Shipment&gt;</returns>
        public async System.Threading.Tasks.Task<List<Shipment>> GetUserShipmentsUsersShipmentsGetAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            BitBuggy.Shipping.Maui.Shipping.Client.ApiResponse<List<Shipment>> localVarResponse = await GetUserShipmentsUsersShipmentsGetWithHttpInfoAsync(operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get User Shipments Get all the shipments for a given user.
        /// </summary>
        /// <exception cref="BitBuggy.Shipping.Maui.Shipping.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;Shipment&gt;)</returns>
        public async System.Threading.Tasks.Task<BitBuggy.Shipping.Maui.Shipping.Client.ApiResponse<List<Shipment>>> GetUserShipmentsUsersShipmentsGetWithHttpInfoAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            BitBuggy.Shipping.Maui.Shipping.Client.RequestOptions localVarRequestOptions = new BitBuggy.Shipping.Maui.Shipping.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = BitBuggy.Shipping.Maui.Shipping.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = BitBuggy.Shipping.Maui.Shipping.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }


            localVarRequestOptions.Operation = "UsersApi.GetUserShipmentsUsersShipmentsGet";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<List<Shipment>>("/users/shipments", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetUserShipmentsUsersShipmentsGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
