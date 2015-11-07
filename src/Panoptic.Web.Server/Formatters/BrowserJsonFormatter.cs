using System;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Panoptic.Web.Server.Formatters
{
    /// <summary>
    /// Defines methods to format JSON in the browser.
    /// </summary>
    public class BrowserJsonFormatter : JsonMediaTypeFormatter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BrowserJsonFormatter"/> class.
        /// </summary>
        public BrowserJsonFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            this.SerializerSettings.Formatting = Formatting.Indented;
        }

        /// <summary>
        /// Sets the default headers for content that will be formatted using this formatter.
        /// This method is called from the System.Net.Http.ObjectContent constructor. This
        /// implementation sets the Content-Type header to the value of mediaType if it is
        /// not null. If it is null it sets the Content-Type to the default media type of
        /// this formatter. If the Content-Type does not specify a charset it will set it
        /// using this formatters configured System.Text.Encoding.
        /// </summary>
        /// <param name="type">The type of the object being serialized. See System.Net.Http.ObjectContent.</param>
        /// <param name="headers">The content headers that should be configured.</param>
        /// <param name="mediaType">The authoritative media type. Can be null.</param>
        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
            headers.ContentType = new MediaTypeHeaderValue("application/json");
        }
    }
}