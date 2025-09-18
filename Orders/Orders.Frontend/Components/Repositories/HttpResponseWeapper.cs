using System.Net;

namespace Orders.Frontend.Components.Repositories
{
    public class httpResponseWrapper<T>
    {
        public httpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Response = response;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }

        public T? Response { get; }
        public bool Error { get; }
        public HttpResponseMessage HttpResponseMessage { get; }

        public async Task<string?> GetErrorMessageAsync()
        {
            if (!Error)
            {
                return null;
            }

            var statuscode = HttpResponseMessage.StatusCode;
            if (statuscode == HttpStatusCode.NotFound)
            {
                return "Resource not found.";
            }
            if (statuscode == HttpStatusCode.BadRequest)
            {
                var errorContent = await HttpResponseMessage.Content.ReadAsStringAsync();
                return $"Bad Request: {errorContent}";
            }
            if (statuscode == HttpStatusCode.Unauthorized)
            {
                return "Tienes que estar logeado para ejecutar esta operacion.";
            }
            if (statuscode == HttpStatusCode.Forbidden)
            {
                return "No tienes permisos para ejecutar esta operacion.";
            }

            return "Ha ocurrido un error inesperado";
        }
    }
}