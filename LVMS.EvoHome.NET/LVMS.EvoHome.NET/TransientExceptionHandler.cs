﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LVMS.EvoHome.Exceptions;
using Newtonsoft.Json;
using Polly;
using PortableRest;

namespace LVMS.EvoHome
{
    internal static class TransientExceptionHandler
    {
        internal static async Task<T> ExecuteWithPolicyAsync<T>(this RestClient restClient, EvoHomeClient evoHomeClient, RestRequest restRequest,
            CancellationToken cancellationToken = default(CancellationToken), bool retryHttpPostAndPut = true, bool byPassCheckInitialized = false) where T : class
        {
            PreSendRequest<T>(evoHomeClient, restRequest, byPassCheckInitialized);

            if (!evoHomeClient.UsePollyTransientFaultHandling)
                return await restClient.ExecuteAsync<T>(restRequest, cancellationToken);

            try
            {
                var retVal = await SendRequestWithPolicy<T>(restClient, restRequest, cancellationToken);
                return retVal.Content;
            }
            catch (Exception e)
            {
                throw new RequestFailedException("Even with transient fault handling enabled, the request failed.", e);
            }
        }

        internal static async Task<RestResponse<T>> SendWithPolicyAsync<T>(this RestClient restClient, EvoHomeClient evoHomeClient, RestRequest restRequest,
            CancellationToken cancellationToken = default(CancellationToken), bool retryHttpPostAndPut = true, bool byPassCheckInitialized = false) where T : class
        {
            PreSendRequest<T>(evoHomeClient, restRequest, byPassCheckInitialized);

            if (!evoHomeClient.UsePollyTransientFaultHandling)
                return await restClient.SendAsync<T>(restRequest, cancellationToken);

            try
            {
                var retVal = await SendRequestWithPolicy<T>(restClient, restRequest, cancellationToken);
                return retVal;
            }
            catch (Exception e)
            {
                throw new RequestFailedException("Even with transient fault handling enabled, the request failed.", e);
            }
        }

        private static async Task<RestResponse<T>> SendRequestWithPolicy<T>(RestClient restClient, RestRequest restRequest, CancellationToken cancellationToken)
            where T : class
        {
            var retVal = await Policy
                .Handle<JsonReaderException>()
                .Or<RequestFailedException>()
                .Or<TaskCanceledException>()
                .Or<HttpRequestException>()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                .ExecuteAsync<RestResponse<T>>(
                    () => SendRequestAndCheckForException<T>(restClient, restRequest, cancellationToken));
            return retVal;
        }

        private static void PreSendRequest<T>(EvoHomeClient evoHomeClient, RestRequest restRequest, bool byPassCheckInitialized) where T : class
        {
            if (evoHomeClient == null)
                throw new ArgumentNullException("evoHomeClient");

            if (!byPassCheckInitialized)
                evoHomeClient.CheckInitialized();
            restRequest.AddHeader("Cookie", "JSESSIONID=" + evoHomeClient.Jessionid);
        }

        private static async Task<RestResponse<T>> SendRequestAndCheckForException<T>(RestClient restClient, RestRequest restRequest,
            CancellationToken cancellationToken) where T : class
        {
            var response = await restClient.SendAsync<T>(restRequest, cancellationToken);
            if (response.Exception != null)
                throw response.Exception;
            else if (response.HttpResponseMessage.IsSuccessStatusCode)
                return response;
            else if (response.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound ||
                     response.HttpResponseMessage.StatusCode == HttpStatusCode.Forbidden ||
                     response.HttpResponseMessage.StatusCode == HttpStatusCode.InternalServerError ||
                     response.HttpResponseMessage.StatusCode == HttpStatusCode.ServiceUnavailable ||
                     response.HttpResponseMessage.StatusCode == HttpStatusCode.BadGateway ||
                     response.HttpResponseMessage.StatusCode == HttpStatusCode.GatewayTimeout ||
                     response.HttpResponseMessage.StatusCode == HttpStatusCode.NoContent ||
                     response.HttpResponseMessage.StatusCode == HttpStatusCode.RequestTimeout)
                throw new RequestFailedException(response.HttpResponseMessage.StatusCode);
            else
                throw new EvoHomeException("Unexpected HTTP status code. Code: " + response.HttpResponseMessage.StatusCode);
        }
    }
}
