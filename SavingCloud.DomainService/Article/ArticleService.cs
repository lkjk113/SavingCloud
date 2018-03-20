using SavingCloud.DomainService.Article;
using SavingCloud.DomainService.Article.Dto;
using SavingCloud.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SavingCloud.Web.Services.Article
{
    /// <summary>
    /// 文档服务
    /// </summary>
    public class ArticleService: IArticleService
    {
        //SavingCloudContainer db = new SavingCloudContainer();

        /// <summary>
        /// 创建文档
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public int Create(string title, string content)
        {
            throw new NotImplementedException();

            //var ArticleBasic = new ArticleBasic
            //{
            //    Content = content,
            //    CreateUser = "admin",
            //    CreateOn = DateTime.Now,
            //    CreateBy = 0,
            //    Title = title
            //};
            //db.ArticleBasic.Add(ArticleBasic);
            //db.SaveChanges();
            //return ArticleBasic.Id;
        }

        /// <summary>
        /// 获取所有文档
        /// </summary>
        /// <returns></returns>
        public List<GetArticleListOutput> GetAll()
        {
            //return db.ArticleBasic.ToList().MapTo<List<GetArticleListOutput>>();
            return new List<GetArticleListOutput>();
        }
    }
}