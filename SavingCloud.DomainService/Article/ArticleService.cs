using SavingCloud.DomainService.Article.Dto;
using SavingCloud.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SavingCloud.DomainService
{
    /// <summary>
    /// 文档服务
    /// </summary>
    public class ArticleService : IArticleService
    {
        //SavingCloudContainer db = new SavingCloudContainer();

        private readonly IRepository<ArticleBasic> _articleBasicRepository;

        public ArticleService(IRepository<ArticleBasic> articleBasicRepository)
        {
            _articleBasicRepository = articleBasicRepository;
        }

        /// <summary>
        /// 创建文档
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public int Create(string title, string content)
        {
            var ArticleBasic = new ArticleBasic
            {
                Content = content,
                CreateUser = "admin",
                CreateOn = DateTime.Now,
                CreateBy = 0,
                Title = title
            };
            return _articleBasicRepository.Create(ArticleBasic).Id;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            _articleBasicRepository.Delete(id);
            return true;
        }

        /// <summary>
        /// 获取所有文档
        /// </summary>
        /// <returns></returns>
        public List<GetArticleListOutput> GetAll()
        {
            return _articleBasicRepository.GetAll().ToList().MapTo<List<GetArticleListOutput>>();
            //return new List<GetArticleListOutput>();
        }
    }
}