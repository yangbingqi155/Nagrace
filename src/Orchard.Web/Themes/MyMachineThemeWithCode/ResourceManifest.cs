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
        }
    }
}