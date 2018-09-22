using FluentValidation.Attributes;
using Nop.Web.Framework.Mvc;
using Nop.Web.Validators.News;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Nop.Web.Models.News
{
	[Validator(typeof(NewsItemValidator))]
    public partial class NewsItemModel : BaseNopEntityModel
    {
        public NewsItemModel()
        {
            Comments = new List<NewsCommentModel>();
            AddNewComment = new AddNewsCommentModel();
        }

        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public string SeName { get; set; }

        public string Title { get; set; }
        public string Short { get; set; }
        public string Full { get; set; }

		public string FirstPostImage
		{
			get
			{
				string pattern = @"<(img)\b[^>]*>";
				Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
				MatchCollection matches = rgx.Matches(Full);
				return matches[0].ToString();
			}
		}

		public bool AllowComments { get; set; }
        public int NumberOfComments { get; set; }
        public DateTime CreatedOn { get; set; }

        public IList<NewsCommentModel> Comments { get; set; }
        public AddNewsCommentModel AddNewComment { get; set; }
    }
}