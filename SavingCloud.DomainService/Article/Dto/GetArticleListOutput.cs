using SavingCloud.Infrastructure;
using System;

namespace SavingCloud.DomainService.Article.Dto
{
    [AutoMap(typeof(ArticleBasic))]
    public class GetArticleListOutput
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? UpdateOn { get; set; }
        public int? UpdateBy { get; set; }
        public string UpdateUser { get; set; }
        public DateTime CreateOn { get; set; }
        public int CreateBy { get; set; }
        public string CreateUser { get; set; }
    }
}