using SavingCloud.Application;
using System.Collections.Generic;
using System.Web.Http;

namespace SavingCloud.Web.Controllers
{
    /// <summary>
    /// 文档操作
    /// </summary>
    public class ArticleController : ControllerBase
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
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _articleService.Delete(id);

        }

        /// <summary>
        /// 获取所有文档
        /// </summary>
        /// <returns></returns>
        public List<Application.Article.Dto.GetArticleListOutput> GetAll()
        {
            return _articleService.GetAll();
        }
    }
}
