using SavingCloud.DomainService.Article;
using SavingCloud.Web.Services.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SavingCloud.Web.Controllers
{
    /// <summary>
    /// 文档操作
    /// </summary>
    public class ArticleController : ApiController
    {


        private readonly IArticleService _articleService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleService"></param>
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        /// <summary>
        /// 创建文档
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public int Create(string title, string content)
        {
            return _articleService.Create(title, content);
        }

        /// <summary>
        /// 获取所有文档
        /// </summary>
        /// <returns></returns>
        public List<DomainService.Article.Dto.GetArticleListOutput> GetAll()
        {
            return _articleService.GetAll();
        }
    }
}
