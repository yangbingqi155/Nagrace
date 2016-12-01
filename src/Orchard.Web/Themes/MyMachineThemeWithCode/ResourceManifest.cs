using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.UI.Resources;

namespace MyMachineThemeWithCode {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();
            
            /********Javascript*******/
            manifest.DefineScript("Bootstrap").SetUrl("bootstrap-3.3.5/js/bootstrap.min.js", "bootstrap-3.3.5/js/bootstrap.js").SetVersion("3.3.4").SetDependencies("jQuery");
            manifest.DefineScript("Less").SetUrl("CssLess/less.min.js", "CssLess/less.js");
            manifest.DefineScript("Nav").SetUrl("Nav.js").SetDependencies("jQuery");
            manifest.DefineScript("Animate").SetUrl("Wow/wow.min.js", "Wow/wow.js");
            manifest.DefineScript("Wowinit").SetUrl("Wow/Wowinit.js").SetDependencies("Animate");
            //manifest.DefineScript("HTML5shiv").SetUrl("html5shiv/html5shiv.min.js", "html5shiv/html5shiv.js");
            manifest.DefineScript("Respond").SetUrl("Respond/respond.min.js", "Respond/respond.src.js");

            /*******Css********/
            //Bootstrap
            manifest.DefineStyle("Bootstrap").SetUrl("bootstrap-3.3.5/less/bootstrap.less").SetAttribute("rel", "stylesheet/less");

            //Less css file
            //default
            manifest.DefineStyle("DefaultGrid").SetUrl("default-grid.less").SetAttribute("rel", "stylesheet/less");
            manifest.DefineStyle("SiteDefault").SetUrl("site-default.less").SetAttribute("rel", "stylesheet/less");
            manifest.DefineStyle("SiteLayout").SetUrl("site-layout.less").SetAttribute("rel", "stylesheet/less");
            manifest.DefineStyle("SiteHome").SetUrl("site-home.less").SetAttribute("rel", "stylesheet/less");

            //blog
            manifest.DefineStyle("SiteLayoutBlog").SetUrl("site-layout-blog.less").SetAttribute("rel", "stylesheet/less");

            //product detail
            manifest.DefineStyle("SiteProductDetail").SetUrl("site-prodetail.less").SetAttribute("rel", "stylesheet/less");

            //Wow animate
            manifest.DefineStyle("Animate").SetUrl("Wow/animate.css").SetAttribute("rel", "stylesheet");
        }
    }
}