using System.Collections.Generic;
using System.IO;
using System.Web.Routing;
using Nop.Core;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Plugin.Widgets.BsProductVideo.Data;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.Widgets.BsProductVideo
{
    /// <summary>
    /// PLugin
    /// </summary>
    public class ProductVideoPlugin : BasePlugin, IWidgetPlugin, IAdminMenuPlugin
    {
        private readonly IPictureService _pictureService;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;
        private readonly ProductVideoObjectContext _objectContext;

        public ProductVideoPlugin(IPictureService pictureService,
            ISettingService settingService, IWebHelper webHelper, ProductVideoObjectContext objectContext)
        {
            this._pictureService = pictureService;
            this._settingService = settingService;
            this._webHelper = webHelper;
            this._objectContext = objectContext;
        }



        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>Widget zones</returns>
        public IList<string> GetWidgetZones()
        {
            return new List<string> { "productdetails_after_pictures", "home_page_VisitorCount" };
        }

        /// <summary>
        /// Gets a route for provider configuration
        /// </summary>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "ProductVideo";
            routeValues = new RouteValueDictionary { { "Namespaces", "Nop.Plugin.Widgets.BsProductVideo.Controllers" }, { "area", null } };
        }

        /// <summary>
        /// Gets a route for displaying widget
        /// </summary>
        /// <param name="widgetZone">Widget zone where it's displayed</param>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        public void GetDisplayWidgetRoute(string widgetZone, out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "PublicInfo";
            controllerName = "ProductVideo";
            routeValues = new RouteValueDictionary
            {
                {"Namespaces", "Nop.Plugin.Widgets.BsProductVideo.Controllers"},
                {"area", null},
                {"widgetZone", widgetZone}
            };
        }
        
        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            //pictures
            //var sampleImagesPath = _webHelper.MapPath("~/Plugins/Widgets.NivoSlider/Content/nivoslider/sample-images/");


            //settings
            //var settings = new NivoSliderSettings
            //{
            //    Picture1Id = _pictureService.InsertPicture(File.ReadAllBytes(sampleImagesPath + "banner1.jpg"), "image/pjpeg", "banner_1").Id,
            //    Text1 = "",
            //    Link1 = _webHelper.GetStoreLocation(false),
            //    Picture2Id = _pictureService.InsertPicture(File.ReadAllBytes(sampleImagesPath + "banner2.jpg"), "image/pjpeg", "banner_2").Id,
            //    Text2 = "",
            //    Link2 = _webHelper.GetStoreLocation(false),
               
            //};
            //_settingService.SaveSetting(settings);


            //this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.NivoSlider.Picture1", "Picture 1");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.NivoSlider.Picture2", "Picture 2");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.NivoSlider.Picture3", "Picture 3");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.NivoSlider.Picture4", "Picture 4");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.NivoSlider.Picture5", "Picture 5");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.NivoSlider.Picture", "Picture");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.NivoSlider.Picture.Hint", "Upload picture.");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.NivoSlider.Text", "Comment");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.NivoSlider.Text.Hint", "Enter comment for picture. Leave empty if you don't want to display any text.");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.NivoSlider.Link", "URL");
            //this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.NivoSlider.Link.Hint", "Enter URL. Leave empty if you don't want this picture to be clickable.");
            //data
            _objectContext.Install();


            base.Install();


           
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            //settings
            //_settingService.DeleteSetting<NivoSliderSettings>();

            //locales
            //this.DeletePluginLocaleResource("Plugins.Widgets.NivoSlider.Picture1");
            //this.DeletePluginLocaleResource("Plugins.Widgets.NivoSlider.Picture2");
            //this.DeletePluginLocaleResource("Plugins.Widgets.NivoSlider.Picture3");
            //this.DeletePluginLocaleResource("Plugins.Widgets.NivoSlider.Picture4");
            //this.DeletePluginLocaleResource("Plugins.Widgets.NivoSlider.Picture5");
            //this.DeletePluginLocaleResource("Plugins.Widgets.NivoSlider.Picture");
            //this.DeletePluginLocaleResource("Plugins.Widgets.NivoSlider.Picture.Hint");
            //this.DeletePluginLocaleResource("Plugins.Widgets.NivoSlider.Text");
            //this.DeletePluginLocaleResource("Plugins.Widgets.NivoSlider.Text.Hint");
            //this.DeletePluginLocaleResource("Plugins.Widgets.NivoSlider.Link");
            //this.DeletePluginLocaleResource("Plugins.Widgets.NivoSlider.Link.Hint");
            //data
            _objectContext.Uninstall();

            base.Uninstall();
        }

        public void ManageSiteMap(SiteMapNode rootNode)
        {
            var menuItemBuilder = new SiteMapNode()
            {
                Visible = true,
                Title = "Product Video",
                Url = "/product-video/product-list",
                RouteValues = new RouteValueDictionary() { { "Area", "Admin" } }
            };

            rootNode.ChildNodes.Add(menuItemBuilder);
            
        }
    }
}
