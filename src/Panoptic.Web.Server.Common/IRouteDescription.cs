namespace Panoptic.Web.Server.Common
{
    /// <summary>
    /// Describes a route in the application.
    /// </summary>
    public interface IRouteDescription
    {
        /// <summary>
        /// Gets the name of the angular controller that will be used to display
        /// the area information.
        /// </summary>
        string AngularController
        {
            get;
        }

        /// <summary>
        /// Gets the path to the html template that will be used by the angular controller
        /// to display the area information.
        /// </summary>
        string AngularTemplateUri
        {
            get;
        }

        /// <summary>
        /// Gets the relative path to the area.
        /// </summary>
        string AreaPath
        {
            get;
        }
    }
}
