using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Blogs.Models;
using Orchard.Comments.Models;
using Orchard.Comments.Services;
using Orchard.Comments.ViewModels;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Core.Common.Models;

namespace Orchard.Comments.Drivers {
    public class RecentCommentsPartDriver :ContentPartDriver<RecentCommentsPart>{
        IContentManager _contentManager;
        ICommentService _commentService;
        IRecentCommentsService _recentCommentsService;
        public RecentCommentsPartDriver(IContentManager contentManager,ICommentService commentService,IRecentCommentsService recentCommentsService) {
            _contentManager = contentManager;
            _recentCommentsService = recentCommentsService;
            _commentService = commentService;
        }

        protected override DriverResult Display(RecentCommentsPart part,string displayType,dynamic shapeHelper) {
            return ContentShape("Parts_RecentComments",()=> {

                var blog = _contentManager.Get<BlogPart>(part.ContainerID);

                if (blog == null) {
                    return null;
                }
                // create a hierarchy of shapes
                var firstLevelShapes = new List<dynamic>();
                var allShapes = new Dictionary<int, dynamic>();

                var comments = _contentManager.Query<CommentPart, CommentPartRecord>()
                .Where(en=>en.Status== CommentStatus.Approved)
                .Join<CommonPartRecord>()
                .Where(cr=>cr.Container.Id==part.ContainerID)
                 .OrderByDescending(cr => cr.CreatedUtc)
                    .Slice(0, part.Count)
                    .Select(ci => ci.As<CommentPart>())
                    .OrderBy(x => x.Position)
                    .ToList(); ;
                //var comments = _commentService
                //    .GetComments()
                //    .Where(x => x.Status == CommentStatus.Approved)
                //    .OrderBy(x => x.Position)
                //    .List()
                //    .ToList();

                foreach (var item in comments) {
                    var shape = shapeHelper.Parts_Comment(ContentPart: item, ContentItem: item.ContentItem);
                    allShapes.Add(item.Id, shape);
                }

                foreach (var item in comments) {
                    var shape = allShapes[item.Id];
                    if (item.RepliedOn.HasValue) {
                        allShapes[item.RepliedOn.Value].Add(shape);
                    }
                    else {
                        firstLevelShapes.Add(shape);
                    }
                }

                var list = shapeHelper.List(Items: firstLevelShapes);

                return shapeHelper.Parts_RecentComments(
                    List: list,
                    CommentCount: part.Count);

            });
        }

        protected override DriverResult Editor(RecentCommentsPart part, dynamic shapeHelper) {
            var viewModel =new RecentCommentsViewModel();
            viewModel.ContainerID = part.ContainerID;
            viewModel.Count = part.Count;
            viewModel.Blogs = _contentManager.Query<BlogPart>().List().ToList().OrderBy(b => _contentManager.GetItemMetadata(b).DisplayText);
            return ContentShape("Parts_RecentComments_Edit",()=> 
                shapeHelper.EditorTemplate(TemplateName: "Parts.RecentComments", Model: viewModel, Prefix: Prefix)
            );
        }

        protected override DriverResult Editor(RecentCommentsPart part, IUpdateModel updater, dynamic shapeHelper) {
            var viewModel = new RecentCommentsViewModel();
            if (updater.TryUpdateModel(viewModel, Prefix, null, null)) {
                part.ContainerID = viewModel.ContainerID;
                part.Count = viewModel.Count;
            }
            return Editor(part,shapeHelper);

        }
    }
}